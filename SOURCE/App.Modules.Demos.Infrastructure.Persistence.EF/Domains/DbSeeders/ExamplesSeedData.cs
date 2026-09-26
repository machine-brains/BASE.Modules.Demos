using App.Modules.Demos.Domain.Domains.Examples.Structures.AtRest.Entities;
using App.Modules.Demos.Domain.Domains.Relationships.Structures.Entities;

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
            string[] regions = [
                "Northland",
                "Auckland",
                "Waikato",
                "Bay of Plenty",
                "Wellington",
                "Canterbury",
                "Otago",
            ];
            (double Latitude, double Longitude)[] regionCoordinates = [
                (-35.7275, 174.3166),
                (-36.8485, 174.7633),
                (-37.7870, 175.2793),
                (-37.6878, 176.1651),
                (-41.2866, 174.7756),
                (-43.5321, 172.6362),
                (-45.8788, 170.5028),
            ];
            string[] operationTypes = [
                "coastal supply run",
                "community health visit",
                "rural equipment transfer",
                "weather response deployment",
                "conservation field check",
                "regional team rotation",
            ];
            List<ExampleA> examples = [];
            DateTimeOffset firstOperation = new(2026, 10, 1, 8, 0, 0, TimeSpan.Zero);

            for (int index = 1; index <= 44; index++)
            {
                int regionIndex = (index - 1) % regions.Length;
                int operationIndex = (index - 1) % operationTypes.Length;
                (double latitude, double longitude) = regionCoordinates[regionIndex];
                DateTimeOffset fromUtc = firstOperation.AddDays(index - 1);
                DateTimeOffset toUtc = fromUtc.AddHours(3);
                string region = regions[regionIndex];
                string operationType = operationTypes[operationIndex];

                examples.Add(new ExampleA
                {
                    Id = CreateExampleAId(index),
                    WorkspaceFK = MachineBrainsWorkspaceId,
                    Title = $"{region} {operationType} {index:00}",
                    Description = $"Field team itinerary for a {operationType} across {region}. Confirm the route, crew handover and arrival evidence.",
                    FromUtc = fromUtc,
                    ToUtc = toUtc,
                    Latitude = latitude,
                    Longitude = longitude,
                    IsActive = true
                });
            }

            examples.AddRange([
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
            ]);
            return examples;
        }

        internal static IEnumerable<ExampleB> GetExampleBs()
        {
            List<ExampleB> children = [];
            DateTimeOffset firstOperation = new(2026, 10, 1, 8, 0, 0, TimeSpan.Zero);
            for (int index = 1; index <= 44; index++)
            {
                Guid parentId = CreateExampleAId(index);
                DateTimeOffset fromUtc = firstOperation.AddDays(index - 1);
                children.Add(new ExampleB
                {
                    Id = CreateExampleBId(index, 1),
                    WorkspaceFK = MachineBrainsWorkspaceId,
                    ExampleAId = parentId,
                    Name = $"Arrival and crew handover {index:00}",
                    Description = "Confirm arrival, unload equipment and record the next crew handover.",
                    FromUtc = fromUtc,
                    ToUtc = fromUtc.AddHours(1),
                    Latitude = -41.2866 + (index % 7) * 0.15,
                    Longitude = 174.7756 + (index % 7) * 0.12,
                    SortOrder = 1
                });
                children.Add(new ExampleB
                {
                    Id = CreateExampleBId(index, 2),
                    WorkspaceFK = MachineBrainsWorkspaceId,
                    ExampleAId = parentId,
                    Name = $"Evidence and departure {index:00}",
                    Description = "Capture field evidence, close the work package and release the vehicle for departure.",
                    FromUtc = fromUtc.AddHours(2),
                    ToUtc = fromUtc.AddHours(3),
                    Latitude = -41.2866 + (index % 7) * 0.18,
                    Longitude = 174.7756 + (index % 7) * 0.14,
                    SortOrder = 1
                });
            }

            children.AddRange([
                new ExampleB
                {
                    Id = Guid.Parse("70000002-0002-0002-0002-000000000099"),
                    WorkspaceFK = CloudOpsWorkspaceId,
                    ExampleAId = ExampleAOutsideMembershipId,
                    Name = "ExampleB.OutsideMembership.One",
                    Description = "A child that must not be disclosed to the seeded admin.",
                    SortOrder = 1
                }
            ]);
            return children;
        }

        internal static IEnumerable<DemosOperationRelationship> GetOperationRelationships()
        {
            Guid[] operationIds = [
                CreateExampleAId(1),
                CreateExampleAId(2),
                CreateExampleAId(3),
                CreateExampleAId(4),
                CreateExampleAId(5),
                CreateExampleAId(6),
            ];
            (int Source, int Target, string Kind, string Label, string Description)[] definitions = [
                (1, 2, "route-handoff", "Shares a northern supply corridor", "Operation 01 hands the northern corridor plan to Operation 02."),
                (2, 3, "crew-dependency", "Depends on the same field crew", "Operation 03 inherits the crew readiness evidence established by Operation 02."),
                (3, 4, "evidence-link", "Extends the evidence trail", "Operation 04 continues the evidence trail opened by Operation 03."),
                (4, 5, "regional-sequence", "Follows the regional sequence", "Operation 05 follows the planned movement from the central region to the south."),
                (5, 6, "return-route", "Closes the return route", "Operation 06 closes the return route after the previous field handover."),
                (6, 1, "shared-resource", "Reuses the shared resource plan", "Operation 01 reuses the resource plan recorded by Operation 06."),
            ];

            return definitions.Select((definition, index) => new DemosOperationRelationship
            {
                Id = Guid.Parse($"71000003-0003-0003-0003-{(index + 1):D12}"),
                WorkspaceFK = MachineBrainsWorkspaceId,
                SourceExampleAId = operationIds[definition.Source - 1],
                TargetExampleAId = operationIds[definition.Target - 1],
                RelationshipKind = definition.Kind,
                Label = definition.Label,
                Description = definition.Description,
                IsDirected = true,
                SortOrder = index + 1,
            });
        }

        private static Guid CreateExampleAId(int index)
        {
            return Guid.Parse($"70000001-0001-0001-0001-{(index + 100):D12}");
        }

        private static Guid CreateExampleBId(int parentIndex, int legIndex)
        {
            int childIndex = ((parentIndex - 1) * 2) + legIndex;
            return Guid.Parse($"70000002-0002-0002-0002-{childIndex:D12}");
        }
    }
}