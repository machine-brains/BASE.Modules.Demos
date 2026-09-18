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

namespace App.Modules.Demos.Application.Domains.Examples.Services.Implementations
{
    /// <summary>CRUST application service for the Demos ExampleA aggregate.</summary>
    /// <remarks>Projection and persistence flow through the application and repository seams; the controller does not access EF.</remarks>
    public class ExampleAApplicationService
        : CrustStateAppServiceBase<ExampleA, ExampleAReadDto, ExampleAWriteDto, ExampleAWriteDto>,
          IExampleAApplicationService
    {
        /// <summary>Initializes the ExampleA application service.</summary>
        private readonly ModuleDbContext _dbContext;
        private readonly IReadOnlyList<IPersonIdentityResolverService> _identityResolvers;
        private readonly IRequestContextService _requestContext;
        private readonly IUserContextService _userContext;
        private readonly IPermissionEvaluationService _permissionEvaluation;

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
                ? base.Query().Where(example => example.IsActive)
                : Enumerable.Empty<ExampleAReadDto>().AsQueryable();
        }

        /// <summary>Returns one active parent only when it is visible to the authenticated caller.</summary>
        public override IQueryable<ExampleAReadDto> QueryById(Guid id)
        {
            return this.Query().Where(example => example.Id == id);
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
            return await this._dbContext.ExampleAs
                .IgnoreQueryFilters()
                .AsNoTracking()
                .OrderBy(example => example.Title)
                .Select(example => new ExampleAReadDto
                {
                    Id = example.Id,
                    Title = example.Title,
                    Description = example.Description,
                    IsActive = example.IsActive,
                    FromUtc = example.FromUtc,
                    ToUtc = example.ToUtc,
                    Latitude = example.Latitude,
                    Longitude = example.Longitude,
                })
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