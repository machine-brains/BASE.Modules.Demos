using App.Modules.Demos.Application.Domains.Examples.Services.Implementations;
using App.Modules.Demos.Application.Domains.Examples.Structures.InTransit.Dtos;
using App.Modules.Demos.Domain.Domains.Examples.Repositories;
using App.Modules.Demos.Domain.Domains.Examples.Structures.AtRest.Entities;
using App.Modules.Demos.Infrastructure.Persistence.EF;
using App.Modules.Sys.Application.Domains.Users.Context.Services;
using App.Modules.Sys.Shared.Domains.AccessControl.Services;
using App.Modules.Sys.Infrastructure.Services;
using App.Modules.Sys.Shared.Domains.Diagnostics;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace Tests.Modules.Demos.Dynamic
{
    /// <summary>Focused application-service checks for Demos parent scope ownership.</summary>
    /// <remarks>
    /// These tests exercise DTO -> application service -> repository ownership rules without a database:
    /// the application injects workspace scope, while the child update contract cannot reparent a row.
    /// Runtime endpoint checks separately prove CRUST visibility and authenticated/anonymous disclosure.
    /// </remarks>
    public sealed class ExamplesApplicationServiceTests
    {
        private static readonly Guid WorkspaceId = Guid.Parse("5044d734-5b0f-5c60-e4de-a090b51396dc");
        private static readonly Guid ParentId = Guid.Parse("70000001-0001-0001-0001-000000000001");
        private static readonly Guid ChildId = Guid.Parse("70000002-0002-0002-0002-000000000001");

        [Fact]
        public async Task CreateChildInjectsCurrentWorkspaceScope()
        {
            IExampleARepository parentRepository = Substitute.For<IExampleARepository>();
            IExampleBRepository childRepository = Substitute.For<IExampleBRepository>();
            IObjectMappingService mapping = Substitute.For<IObjectMappingService>();
            IAppLogger logger = Substitute.For<IAppLogger>();
            IUserContextService userContext = Substitute.For<IUserContextService>();
            ModuleDbContext dbContext = CreateDbContextSubstitute();

            userContext.IsAuthenticated.Returns(true);
            userContext.CurrentWorkspaceId.Returns(WorkspaceId);
            parentRepository.QueryById(ParentId).Returns(new[] { new ExampleA { Id = ParentId, WorkspaceFK = WorkspaceId, IsActive = true } }.AsQueryable());

            ExampleB mapped = new() { Id = ChildId, ExampleAId = ParentId, Name = "Child", SortOrder = 1 };
            ExampleBReadDto read = new() { Id = ChildId, ExampleAId = ParentId, Name = "Child", SortOrder = 1 };
            mapping.Map<ExampleBWriteDto, ExampleB>(Arg.Any<ExampleBWriteDto>()).Returns(mapped);
            mapping.Map<ExampleB, ExampleBReadDto>(Arg.Any<ExampleB>()).Returns(read);
            childRepository.CreateAsync(mapped, Arg.Any<CancellationToken>()).Returns(Task.FromResult(mapped));

            ExampleBApplicationService service = new(
                childRepository,
                parentRepository,
                dbContext,
                mapping,
                logger,
                Array.Empty<App.Modules.Sys.Shared.Social.Services.IPersonIdentityResolverService>(),
                userContext);

            await service.CreateAsync(new ExampleBWriteDto
            {
                Id = ChildId,
                ExampleAId = ParentId,
                Name = "Child",
                SortOrder = 1,
            });

            Assert.Equal(WorkspaceId, mapped.WorkspaceFK);
            await childRepository.Received(1).CreateAsync(mapped, Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task CreateParentRejectsUnpairedCoordinatesBeforeRepository()
        {
            IExampleARepository parentRepository = Substitute.For<IExampleARepository>();
            IObjectMappingService mapping = Substitute.For<IObjectMappingService>();
            IAppLogger logger = Substitute.For<IAppLogger>();
            IUserContextService userContext = Substitute.For<IUserContextService>();
            ModuleDbContext dbContext = CreateDbContextSubstitute();

            userContext.IsAuthenticated.Returns(true);
            userContext.CurrentWorkspaceId.Returns(WorkspaceId);

            ExampleAApplicationService service = new(
                parentRepository,
                dbContext,
                mapping,
                logger,
                Array.Empty<App.Modules.Sys.Shared.Social.Services.IPersonIdentityResolverService>(),
                Substitute.For<App.Modules.Sys.Infrastructure.Domains.RequestContext.Services.IRequestContextService>(),
                userContext,
                Substitute.For<IPermissionEvaluationService>());

            await Assert.ThrowsAsync<ArgumentException>(() => service.CreateAsync(new ExampleAWriteDto
            {
                Id = ParentId,
                Title = "Invalid spatial parent",
                Latitude = -41.2866,
            }));

            await parentRepository.DidNotReceive().CreateAsync(Arg.Any<ExampleA>(), Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task UpdateChildRejectsOutOfRangeLongitudeBeforeRepository()
        {
            IExampleARepository parentRepository = Substitute.For<IExampleARepository>();
            IExampleBRepository childRepository = Substitute.For<IExampleBRepository>();
            IObjectMappingService mapping = Substitute.For<IObjectMappingService>();
            IAppLogger logger = Substitute.For<IAppLogger>();
            IUserContextService userContext = Substitute.For<IUserContextService>();
            ModuleDbContext dbContext = CreateDbContextSubstitute();
            ExampleB existing = new()
            {
                Id = ChildId,
                ExampleAId = ParentId,
                WorkspaceFK = WorkspaceId,
                Name = "Existing",
                SortOrder = 1,
            };

            userContext.CurrentWorkspaceId.Returns(WorkspaceId);
            childRepository.GetForUpdateAsync(ChildId, Arg.Any<CancellationToken>()).Returns(Task.FromResult<ExampleB?>(existing));

            ExampleBApplicationService service = new(
                childRepository,
                parentRepository,
                dbContext,
                mapping,
                logger,
                Array.Empty<App.Modules.Sys.Shared.Social.Services.IPersonIdentityResolverService>(),
                userContext);

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => service.UpdateAsync(ChildId, new ExampleBWriteDto
            {
                Id = ChildId,
                ExampleAId = ParentId,
                Name = "Invalid spatial child",
                Latitude = -41.2866,
                Longitude = 180.0001,
            }));

            await childRepository.DidNotReceive().UpdateAsync(Arg.Any<ExampleB>(), Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task UpdateChildRejectsReparenting()
        {
            IExampleARepository parentRepository = Substitute.For<IExampleARepository>();
            IExampleBRepository childRepository = Substitute.For<IExampleBRepository>();
            IObjectMappingService mapping = Substitute.For<IObjectMappingService>();
            IAppLogger logger = Substitute.For<IAppLogger>();
            IUserContextService userContext = Substitute.For<IUserContextService>();
            ModuleDbContext dbContext = CreateDbContextSubstitute();
            ExampleB existing = new() { Id = ChildId, ExampleAId = ParentId, WorkspaceFK = WorkspaceId, Name = "Existing", SortOrder = 1 };

            userContext.CurrentWorkspaceId.Returns(WorkspaceId);
            childRepository.GetForUpdateAsync(ChildId, Arg.Any<CancellationToken>()).Returns(Task.FromResult<ExampleB?>(existing));

            ExampleBApplicationService service = new(
                childRepository,
                parentRepository,
                dbContext,
                mapping,
                logger,
                Array.Empty<App.Modules.Sys.Shared.Social.Services.IPersonIdentityResolverService>(),
                userContext);

            await Assert.ThrowsAsync<InvalidOperationException>(() => service.UpdateAsync(ChildId, new ExampleBWriteDto
            {
                Id = ChildId,
                ExampleAId = Guid.Parse("70000001-0001-0001-0001-000000000002"),
                Name = "Attempted Reparent",
                SortOrder = 99,
            }));

            await childRepository.DidNotReceive().UpdateAsync(Arg.Any<ExampleB>(), Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task DeniedParentTransitionDoesNotReachRepository()
        {
            IExampleARepository parentRepository = Substitute.For<IExampleARepository>();
            IObjectMappingService mapping = Substitute.For<IObjectMappingService>();
            IAppLogger logger = Substitute.For<IAppLogger>();
            IUserContextService userContext = Substitute.For<IUserContextService>();
            IPermissionEvaluationService permissionEvaluation = Substitute.For<IPermissionEvaluationService>();
            ModuleDbContext dbContext = CreateDbContextSubstitute();

            userContext.IsAuthenticated.Returns(true);
            userContext.CurrentUserId.Returns(Guid.Parse("00000000-0000-0000-0000-000000000001"));
            userContext.CurrentWorkspaceId.Returns(WorkspaceId);
            permissionEvaluation.HasPermissionAsync(
                    Arg.Any<Guid>(),
                    Arg.Any<string>(),
                    Arg.Any<App.Modules.Sys.Shared.Domains.AccessControl.Models.Enums.RoleScope>(),
                    Arg.Any<Guid?>(),
                    Arg.Any<CancellationToken>())
                .Returns(false);

            ExampleA existing = new() { Id = ParentId, WorkspaceFK = WorkspaceId, IsActive = true };
            parentRepository.GetForUpdateAsync(ParentId, Arg.Any<CancellationToken>()).Returns(Task.FromResult<ExampleA?>(existing));

            ExampleAApplicationService service = new(
                parentRepository,
                dbContext,
                mapping,
                logger,
                Array.Empty<App.Modules.Sys.Shared.Social.Services.IPersonIdentityResolverService>(),
                Substitute.For<App.Modules.Sys.Infrastructure.Domains.RequestContext.Services.IRequestContextService>(),
                userContext,
                permissionEvaluation);

            await Assert.ThrowsAsync<App.Modules.Sys.Domains.Exceptions.AuthorizationDeniedException>(
                () => service.TransitionStateAsync(ParentId, "Withdraw"));

            await parentRepository.DidNotReceive().TransitionStateAsync(Arg.Any<Guid>(), Arg.Any<string>(), Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task InvalidParentTransitionDoesNotReachRepository()
        {
            IExampleARepository parentRepository = Substitute.For<IExampleARepository>();
            IObjectMappingService mapping = Substitute.For<IObjectMappingService>();
            IAppLogger logger = Substitute.For<IAppLogger>();
            IUserContextService userContext = Substitute.For<IUserContextService>();
            IPermissionEvaluationService permissionEvaluation = Substitute.For<IPermissionEvaluationService>();
            ModuleDbContext dbContext = CreateDbContextSubstitute();

            userContext.IsAuthenticated.Returns(true);
            userContext.CurrentUserId.Returns(Guid.Parse("00000000-0000-0000-0000-000000000001"));
            userContext.CurrentWorkspaceId.Returns(WorkspaceId);

            ExampleAApplicationService service = new(
                parentRepository,
                dbContext,
                mapping,
                logger,
                Array.Empty<App.Modules.Sys.Shared.Social.Services.IPersonIdentityResolverService>(),
                Substitute.For<App.Modules.Sys.Infrastructure.Domains.RequestContext.Services.IRequestContextService>(),
                userContext,
                permissionEvaluation);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => service.TransitionStateAsync(ParentId, "Approve"));

            await parentRepository.DidNotReceive().TransitionStateAsync(Arg.Any<Guid>(), Arg.Any<string>(), Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task ConcurrentParentTransitionPreservesConcurrencyException()
        {
            IExampleARepository parentRepository = Substitute.For<IExampleARepository>();
            IObjectMappingService mapping = Substitute.For<IObjectMappingService>();
            IAppLogger logger = Substitute.For<IAppLogger>();
            IUserContextService userContext = Substitute.For<IUserContextService>();
            IPermissionEvaluationService permissionEvaluation = Substitute.For<IPermissionEvaluationService>();
            ModuleDbContext dbContext = CreateDbContextSubstitute();

            userContext.IsAuthenticated.Returns(true);
            userContext.CurrentUserId.Returns(Guid.Parse("00000000-0000-0000-0000-000000000001"));
            userContext.CurrentWorkspaceId.Returns(WorkspaceId);
            permissionEvaluation.HasPermissionAsync(
                    Arg.Any<Guid>(),
                    Arg.Any<string>(),
                    Arg.Any<App.Modules.Sys.Shared.Domains.AccessControl.Models.Enums.RoleScope>(),
                    Arg.Any<Guid?>(),
                    Arg.Any<CancellationToken>())
                .Returns(true);
            parentRepository.TransitionStateAsync(ParentId, "Inactive", Arg.Any<CancellationToken>())
                .Returns(Task.FromException(new DbUpdateConcurrencyException("The parent changed before this transition was committed.")));

            ExampleAApplicationService service = new(
                parentRepository,
                dbContext,
                mapping,
                logger,
                Array.Empty<App.Modules.Sys.Shared.Social.Services.IPersonIdentityResolverService>(),
                Substitute.For<App.Modules.Sys.Infrastructure.Domains.RequestContext.Services.IRequestContextService>(),
                userContext,
                permissionEvaluation);

            await Assert.ThrowsAsync<DbUpdateConcurrencyException>(
                () => service.TransitionStateAsync(ParentId, "Withdraw"));
        }

        private static ModuleDbContext CreateDbContextSubstitute()
        {
            DbContextOptions<ModuleDbContext> options = new DbContextOptionsBuilder<ModuleDbContext>().Options;
            return Substitute.For<ModuleDbContext>(options);
        }
    }
}
