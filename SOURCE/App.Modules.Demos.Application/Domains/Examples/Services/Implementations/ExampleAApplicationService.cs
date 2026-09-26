using App.Modules.Demos.Application.Domains.Examples.Structures.InTransit.Dtos;
using App.Modules.Demos.Domain.Domains.Examples.Repositories;
using App.Modules.Demos.Domain.Domains.Examples.Structures.AtRest.Entities;
using App.Modules.Demos.Infrastructure.Persistence.EF;
using App.Modules.Sys.Application.Base;
using App.Modules.Sys.Infrastructure.Services;
using App.Modules.Sys.Infrastructure.Domains.RequestContext.Services;
using App.Modules.Sys.Application.Domains.Users.Context.Services;
using App.Modules.Sys.Shared.Domains.Diagnostics;
using App.Modules.Sys.Shared.Social.Models;
using App.Modules.Sys.Shared.Social.Services;
using App.Modules.Sys.Shared.Domains.Application.StateTransitions;
using App.Modules.Sys.Shared.Domains.AccessControl.Models.Enums;
using App.Modules.Sys.Shared.Domains.AccessControl.Services;
using App.Modules.Sys.Domains.Exceptions;
using App.Modules.Demos.Constants;
using App.Modules.Demos.Domain.Domains.Examples.Validation;
using System.Collections.Frozen;
using Microsoft.EntityFrameworkCore;
using App.Modules.Sys.Substrate.Domains.Browse.Models;
using App.Modules.Demos.Application.Domains.Examples.Providers;
using App.Modules.Sys.Shared.Domains.Queries;
using System.Text.Json;

namespace App.Modules.Demos.Application.Domains.Examples.Services.Implementations
{
    /// <summary>CRUST application service for the Demos ExampleA aggregate.</summary>
    /// <remarks>Projection and persistence flow through the application and repository seams; the controller does not access EF.</remarks>
    public class ExampleAApplicationService
        : CrustStateAppServiceBase<ExampleA, ExampleAReadDto, ExampleAWriteDto, ExampleAWriteDto>,
          IExampleAApplicationService
    {
        private static readonly Guid CurrentFixtureFirstId = Guid.Parse("70000001-0001-0001-0001-000000000101");
        private static readonly Guid CurrentFixtureLastId = Guid.Parse("70000001-0001-0001-0001-000000000142");
        /// <summary>Initializes the ExampleA application service.</summary>
        private readonly ModuleDbContext _dbContext;
        private readonly IReadOnlyList<IPersonIdentityResolverService> _identityResolvers;
        private readonly IRequestContextService _requestContext;
        private readonly IUserContextService _userContext;
        private readonly IPermissionEvaluationService _permissionEvaluation;
        private readonly DemosExampleQueryCapabilityProvider _queryCapabilityProvider = new();

        public ExampleAApplicationService(
            IExampleARepository repository,
            ModuleDbContext dbContext,
            IObjectMappingService objectMappingService,
            IAppLogger loggingService,
            IEnumerable<IPersonIdentityResolverService> identityResolvers,
            IRequestContextService requestContext,
            IUserContextService userContext,
            IPermissionEvaluationService permissionEvaluation)
            : base(repository, objectMappingService, loggingService)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this._identityResolvers = identityResolvers?.ToList() ?? throw new ArgumentNullException(nameof(identityResolvers));
            this._requestContext = requestContext ?? throw new ArgumentNullException(nameof(requestContext));
            this._userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
            this._permissionEvaluation = permissionEvaluation ?? throw new ArgumentNullException(nameof(permissionEvaluation));
        }

        /// <summary>Creates a parent record scoped to the authenticated current workspace.</summary>
        /// <remarks>The caller cannot provide a workspace foreign key; application ownership injects it before the repository write.</remarks>
        public override async Task<ExampleAReadDto> CreateAsync(ExampleAWriteDto dto, CancellationToken cancellationToken = default)
        {
            if (!this._userContext.IsAuthenticated)
            {
                throw new UnauthorizedAccessException("An authenticated workspace member is required.");
            }

            ExampleSpatialCapabilityValidation.Validate(dto.Latitude, dto.Longitude);
            ExampleA entity = this.ObjectMappingService.Map<ExampleAWriteDto, ExampleA>(dto);
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
            entity.WorkspaceFK = this._userContext.CurrentWorkspaceId;
            ExampleA created = await ((IExampleARepository)this.Repository).CreateAsync(entity, cancellationToken).ConfigureAwait(false);
            return this.ObjectMappingService.Map<ExampleA, ExampleAReadDto>(created);
        }

        /// <summary>Updates a parent after validating its optional spatial capability.</summary>
        /// <remarks>The application boundary rejects invalid WGS84 input before the inherited mapper or repository can observe it.</remarks>
        public override async Task<ExampleAReadDto> UpdateAsync(Guid id, ExampleAWriteDto dto, CancellationToken cancellationToken = default)
        {
            ExampleSpatialCapabilityValidation.Validate(dto.Latitude, dto.Longitude);
            return await base.UpdateAsync(id, dto, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>Returns the governed parent collection only for authenticated requests.</summary>
        /// <remarks>Anonymous callers receive no rows before the repository query is exposed; authenticated callers still pass through CRUST workspace/share visibility.</remarks>
        public override IQueryable<ExampleAReadDto> Query()
        {
            return this._requestContext.IsAuthenticated
                ? base.Query()
                    .Where(example => example.IsActive)
                    .Where(example => example.Id >= CurrentFixtureFirstId && example.Id <= CurrentFixtureLastId)
                    .Where(example => !example.Title.StartsWith("ExampleA.") && example.Title != "Foo")
                : Enumerable.Empty<ExampleAReadDto>().AsQueryable();
        }

        /// <summary>Returns one active parent only when it is visible to the authenticated caller.</summary>
        public override IQueryable<ExampleAReadDto> QueryById(Guid id)
        {
            return this.Query().Where(example => example.Id == id);
        }

        /// <inheritdoc />
        public BrowseQueryCapability GetQueryCapability()
        {
            return this._queryCapabilityProvider.Describe();
        }

        /// <inheritdoc />
        public Task<QueryPageResult<ExampleAReadDto>> SearchAsync(QueryInstructionPackage query, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(query);

            IQueryable<ExampleAReadDto> examples = this.Query();
            string searchTerm = query.SearchTerm.Trim();
            if (searchTerm.Length > 0)
            {
                examples = examples.Where(example => example.Title.Contains(searchTerm) || example.Description.Contains(searchTerm));
            }

            foreach (QueryInstructionFilter filter in query.Filters)
            {
                examples = ApplyFilter(examples, filter);
            }

            examples = ApplySorts(examples, query.Sorts);
            int page = Math.Max(1, query.Paging?.Page ?? 1);
            int pageSize = Math.Clamp(query.Paging?.PageSize ?? 12, 1, 100);
            long totalCount = examples.LongCount();
            IReadOnlyList<ExampleAReadDto> items = examples
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToArray();

            QueryPageResult<ExampleAReadDto> result = new()
            {
                Items = items,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
            };
            return Task.FromResult(result);
        }

        private static IQueryable<ExampleAReadDto> ApplyFilter(IQueryable<ExampleAReadDto> examples, QueryInstructionFilter filter)
        {
            string value = ReadString(filter.Value);
            return filter.Field switch
            {
                "title" => ApplyStringFilter(examples, example => example.Title, filter.Operator, value),
                "description" => ApplyStringFilter(examples, example => example.Description, filter.Operator, value),
                "isActive" => ApplyBooleanFilter(examples, example => example.IsActive, filter.Operator, filter.Value),
                "latitude" => ApplyNumberFilter(examples, example => example.Latitude, filter.Operator, filter.Value),
                "longitude" => ApplyNumberFilter(examples, example => example.Longitude, filter.Operator, filter.Value),
                _ => examples,
            };
        }

        private static IQueryable<ExampleAReadDto> ApplyStringFilter(
            IQueryable<ExampleAReadDto> examples,
            System.Linq.Expressions.Expression<Func<ExampleAReadDto, string>> selector,
            string operatorName,
            string value)
        {
            return operatorName switch
            {
                "contains" => examples.Where(System.Linq.Expressions.Expression.Lambda<Func<ExampleAReadDto, bool>>(
                    System.Linq.Expressions.Expression.Call(selector.Body, nameof(string.Contains), Type.EmptyTypes, System.Linq.Expressions.Expression.Constant(value)), selector.Parameters)),
                "startsWith" => examples.Where(System.Linq.Expressions.Expression.Lambda<Func<ExampleAReadDto, bool>>(
                    System.Linq.Expressions.Expression.Call(selector.Body, nameof(string.StartsWith), Type.EmptyTypes, System.Linq.Expressions.Expression.Constant(value)), selector.Parameters)),
                "endsWith" => examples.Where(System.Linq.Expressions.Expression.Lambda<Func<ExampleAReadDto, bool>>(
                    System.Linq.Expressions.Expression.Call(selector.Body, nameof(string.EndsWith), Type.EmptyTypes, System.Linq.Expressions.Expression.Constant(value)), selector.Parameters)),
                "ne" => examples.Where(System.Linq.Expressions.Expression.Lambda<Func<ExampleAReadDto, bool>>(
                    System.Linq.Expressions.Expression.NotEqual(selector.Body, System.Linq.Expressions.Expression.Constant(value)), selector.Parameters)),
                _ => examples.Where(System.Linq.Expressions.Expression.Lambda<Func<ExampleAReadDto, bool>>(
                    System.Linq.Expressions.Expression.Equal(selector.Body, System.Linq.Expressions.Expression.Constant(value)), selector.Parameters)),
            };
        }

        private static IQueryable<ExampleAReadDto> ApplyBooleanFilter(
            IQueryable<ExampleAReadDto> examples,
            System.Linq.Expressions.Expression<Func<ExampleAReadDto, bool>> selector,
            string operatorName,
            JsonElement? value)
        {
            if (value is not JsonElement json || json.ValueKind != JsonValueKind.True && json.ValueKind != JsonValueKind.False)
            {
                return examples;
            }

            bool parsed = json.GetBoolean();

            System.Linq.Expressions.Expression body = operatorName == "ne"
                ? System.Linq.Expressions.Expression.NotEqual(selector.Body, System.Linq.Expressions.Expression.Constant(parsed))
                : System.Linq.Expressions.Expression.Equal(selector.Body, System.Linq.Expressions.Expression.Constant(parsed));
            return examples.Where(System.Linq.Expressions.Expression.Lambda<Func<ExampleAReadDto, bool>>(body, selector.Parameters));
        }

        private static IQueryable<ExampleAReadDto> ApplyNumberFilter(
            IQueryable<ExampleAReadDto> examples,
            System.Linq.Expressions.Expression<Func<ExampleAReadDto, double?>> selector,
            string operatorName,
            JsonElement? value)
        {
            if (value is not JsonElement json || !json.TryGetDouble(out double parsed))
            {
                return examples;
            }

            System.Linq.Expressions.Expression left = selector.Body;
            System.Linq.Expressions.Expression right = System.Linq.Expressions.Expression.Convert(
                System.Linq.Expressions.Expression.Constant(parsed),
                typeof(double?));
            System.Linq.Expressions.Expression body = operatorName switch
            {
                "ne" => System.Linq.Expressions.Expression.NotEqual(left, right),
                "lt" => System.Linq.Expressions.Expression.LessThan(left, right),
                "lte" => System.Linq.Expressions.Expression.LessThanOrEqual(left, right),
                "gt" => System.Linq.Expressions.Expression.GreaterThan(left, right),
                "gte" => System.Linq.Expressions.Expression.GreaterThanOrEqual(left, right),
                _ => System.Linq.Expressions.Expression.Equal(left, right),
            };
            return examples.Where(System.Linq.Expressions.Expression.Lambda<Func<ExampleAReadDto, bool>>(body, selector.Parameters));
        }

        private static IQueryable<ExampleAReadDto> ApplySorts(IQueryable<ExampleAReadDto> examples, IReadOnlyList<QueryInstructionSort> sorts)
        {
            IOrderedQueryable<ExampleAReadDto>? ordered = null;
            foreach (QueryInstructionSort sort in sorts)
            {
                bool descending = string.Equals(sort.Direction, "desc", StringComparison.OrdinalIgnoreCase);
                ordered = sort.Field switch
                {
                    "description" => ApplySort(examples, ordered, example => example.Description, descending),
                    "isActive" => ApplySort(examples, ordered, example => example.IsActive, descending),
                    "fromUtc" => ApplySort(examples, ordered, example => example.FromUtc, descending),
                    "toUtc" => ApplySort(examples, ordered, example => example.ToUtc, descending),
                    "latitude" => ApplySort(examples, ordered, example => example.Latitude, descending),
                    "longitude" => ApplySort(examples, ordered, example => example.Longitude, descending),
                    _ => ApplySort(examples, ordered, example => example.Title, descending),
                };
            }

            return ordered ?? examples.OrderBy(example => example.Title);
        }

        private static IOrderedQueryable<ExampleAReadDto> ApplySort<TKey>(
            IQueryable<ExampleAReadDto> examples,
            IOrderedQueryable<ExampleAReadDto>? ordered,
            System.Linq.Expressions.Expression<Func<ExampleAReadDto, TKey>> selector,
            bool descending)
        {
            if (ordered == null)
            {
                return descending ? examples.OrderByDescending(selector) : examples.OrderBy(selector);
            }

            return descending ? ordered.ThenByDescending(selector) : ordered.ThenBy(selector);
        }

        private static string ReadString(JsonElement? value)
        {
            return value is JsonElement json && json.ValueKind == JsonValueKind.String
                ? json.GetString() ?? string.Empty
                : value?.ToString() ?? string.Empty;
        }
        
        /// <summary>
        /// Defines the reversible Demos parent lifecycle.
        /// </summary>
        /// <remarks>
        /// `Publish` and `Withdraw` are domain operations over <see cref="ExampleA.IsActive"/>;
        /// infrastructure RecordState remains a separate persistence lifecycle. The Coordinator/VDL
        /// action layer will consume these named operations later; ordinary Update cannot silently
        /// change lifecycle state because IsActive is intentionally excluded from update mapping policy.
        /// </remarks>
        protected override FrozenDictionary<string, StateTransitionDefinition>? AllowedTransitions =>
            CoreStateTransitions.BuildDomainOnlyTransitions(
                new StateTransitionDefinition(
                    "Publish",
                    "Active",
                    DemosPermissionConstants.ExamplesTransition,
                    "Publish an inactive Demos parent for Browse and child composition."),
                new StateTransitionDefinition(
                    "Withdraw",
                    "Inactive",
                    DemosPermissionConstants.ExamplesTransition,
                    "Withdraw an active Demos parent from Browse while retaining its history."));

        /// <summary>Enforces the declared transition permission in the current workspace scope.</summary>
        protected override async Task BeforeTransitionAsync(Guid id, StateTransitionDefinition definition, CancellationToken cancellationToken)
        {
            if (!this._userContext.IsAuthenticated)
            {
                throw new AuthenticationRequiredException("An authenticated principal is required for Demos transitions.");
            }

            bool permitted = await this._permissionEvaluation
                .HasPermissionAsync(
                    this._userContext.CurrentUserId,
                    definition.RequiredPermission,
                    RoleScope.Workspace,
                    this._userContext.CurrentWorkspaceId,
                    cancellationToken)
                .ConfigureAwait(false);

            if (!permitted)
            {
                throw new AuthorizationDeniedException(
                    "The current principal is not permitted to transition this Demos parent.",
                    this._userContext.CurrentUserId,
                    definition.RequiredPermission);
            }

            await base.BeforeTransitionAsync(id, definition, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<IReadOnlyList<ExampleAReadDto>> GetDeveloperDemoAsync(CancellationToken cancellationToken = default)
        {
            // Deliberate exception: this route is guarded by ForDemoOnly and the
            // controller's Development check. It reads only deterministic demo rows
            // so visual validation can proceed while the normal authorization seed
            // migration is repaired; it is never a production data path.
            return await this.ObjectMappingService.ProjectTo<ExampleA, ExampleAReadDto>(
                this._dbContext.ExampleAs
                    .IgnoreQueryFilters()
                    .AsNoTracking()
                    .Where(example => example.IsActive)
                    .Where(example => example.Id >= CurrentFixtureFirstId && example.Id <= CurrentFixtureLastId)
                    .Where(example => !example.Title.StartsWith("ExampleA.") && example.Title != "Foo")
                    .OrderBy(example => example.Title))
                .ToListAsync(cancellationToken);
        }

        /// <summary>Returns whether the request resolved to an authenticated canonical identity.</summary>
        private async Task<bool> HasAuthenticatedIdentityAsync(CancellationToken cancellationToken)
        {
            foreach (IPersonIdentityResolverService resolver in this._identityResolvers.OrderBy(item => item.IsLiteMode))
            {
                IPersonIdentityInfo? identity = await resolver.GetCurrentUserIdentityAsync(cancellationToken).ConfigureAwait(false);
                if (identity?.Id is Guid identityId && identityId != Guid.Empty && identity.PersonaId is Guid personaId && personaId != Guid.Empty)
                {
                    return true;
                }
            }

            return false;
        }
    }
}