using App.Modules.Demos.Domain.Domains.Examples.Structures.AtRest.Entities;

namespace App.Modules.Demos.Infrastructure.Domains.DbSeeders.DbSeeders
{
    /// <summary>Deterministic model seed data for the Demos Examples capability.</summary>
    /// <remarks>Parent and child IDs are fixed so authenticated Spike checks see stable hierarchy data after every seed run.</remarks>
    internal static class ExamplesSeedData
    {
        internal static readonly Guid MachineBrainsWorkspaceId = Guid.Parse("5044d734-5b0f-5c60-e4de-a090b51396dc");
        internal static readonly Guid CloudOpsWorkspaceId = Guid.Parse("10000000-0000-0000-0000-000000000002");
        internal static readonly Guid ExampleAOneId = Guid.Parse("70000001-0001-0001-0001-000000000001");
        internal static readonly Guid ExampleATwoId = Guid.Parse("70000001-0001-0001-0001-000000000002");
        internal static readonly Guid ExampleAInactiveId = Guid.Parse("70000001-0001-0001-0001-000000000098");
        internal static readonly Guid ExampleAOutsideMembershipId = Guid.Parse("70000001-0001-0001-0001-000000000099");

        internal static IEnumerable<ExampleA> GetExampleAs()
        {
            return new[]
            {
                new ExampleA
                {
                    Id = ExampleAOneId,
                    WorkspaceFK = MachineBrainsWorkspaceId,
                    Title = "ExampleA.Alpha",
                    Description = "A stable Demos parent example for the Spike browser.",
                    FromUtc = new DateTimeOffset(2026, 9, 15, 9, 0, 0, TimeSpan.Zero),
                    ToUtc = new DateTimeOffset(2026, 9, 15, 10, 30, 0, TimeSpan.Zero),
                    Latitude = -41.2866,
                    Longitude = 174.7756,
                    IsActive = true
                },
                new ExampleA
                {
                    Id = ExampleATwoId,
                    WorkspaceFK = MachineBrainsWorkspaceId,
                    Title = "ExampleA.Beta",
                    Description = "A second stable Demos parent example with child items.",
                    FromUtc = new DateTimeOffset(2026, 9, 16, 11, 0, 0, TimeSpan.Zero),
                    ToUtc = new DateTimeOffset(2026, 9, 16, 12, 0, 0, TimeSpan.Zero),
                    Latitude = -36.8485,
                    Longitude = 174.7633,
                    IsActive = true
                },
                new ExampleA
                {
                    Id = ExampleAInactiveId,
                    WorkspaceFK = MachineBrainsWorkspaceId,
                    Title = "ExampleA.Inactive",
                    Description = "A deterministic inactive row that must not enter the Browse projection.",
                    IsActive = false
                },
                new ExampleA
                {
                    Id = ExampleAOutsideMembershipId,
                    WorkspaceFK = CloudOpsWorkspaceId,
                    Title = "ExampleA.OutsideMembership",
                    Description = "A deterministic parent used to prove authenticated non-member exclusion.",
                    IsActive = true
                }
            };
        }

        internal static IEnumerable<ExampleB> GetExampleBs()
        {
            return new[]
            {
                new ExampleB
                {
                    Id = Guid.Parse("70000002-0002-0002-0002-000000000001"),
                    WorkspaceFK = MachineBrainsWorkspaceId,
                    ExampleAId = ExampleAOneId,
                    Name = "ExampleB.Alpha.One",
                    Description = "The first ordered child of ExampleA.Alpha.",
                    FromUtc = new DateTimeOffset(2026, 9, 15, 9, 15, 0, TimeSpan.Zero),
                    ToUtc = new DateTimeOffset(2026, 9, 15, 9, 45, 0, TimeSpan.Zero),
                    Latitude = -41.2924,
                    Longitude = 174.7787,
                    SortOrder = 1
                },
                new ExampleB
                {
                    Id = Guid.Parse("70000002-0002-0002-0002-000000000002"),
                    WorkspaceFK = MachineBrainsWorkspaceId,
                    ExampleAId = ExampleATwoId,
                    Name = "ExampleB.Beta.One",
                    Description = "The first ordered child of ExampleA.Beta.",
                    FromUtc = new DateTimeOffset(2026, 9, 16, 11, 15, 0, TimeSpan.Zero),
                    ToUtc = new DateTimeOffset(2026, 9, 16, 11, 45, 0, TimeSpan.Zero),
                    Latitude = -36.8529,
                    Longitude = 174.7681,
                    SortOrder = 1
                },
                new ExampleB
                {
                    Id = Guid.Parse("70000002-0002-0002-0002-000000000099"),
                    WorkspaceFK = CloudOpsWorkspaceId,
                    ExampleAId = ExampleAOutsideMembershipId,
                    Name = "ExampleB.OutsideMembership.One",
                    Description = "A child that must not be disclosed to the seeded admin.",
                    SortOrder = 1
                }
            };
        }
    }
}