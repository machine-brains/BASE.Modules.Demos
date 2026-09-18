using App.Modules.Demos.Interfaces.API.REST.Domains.Constants;
using App.Modules.Demos.Application.Domains.Examples.Structures.InTransit.Dtos;
using App.Modules.Demos.Constants;

namespace Tests.Modules.Demos.Dynamic
{
    /// <summary>Focused contract checks for the host-loaded Demos Examples capability.</summary>
    public sealed class ExamplesContractTests
    {
        [Fact]
        public void RoutesComposeTheStableDemosExamplesPaths()
        {
            Assert.Equal("api/rest/demos/v1/examples", ApiRoutes.Rest.V1.Examples.Base);
            Assert.Equal("api/rest/demos/v1/examples/items", ApiRoutes.Rest.V1.ExampleItems.Base);
        }

        [Fact]
        public void WriteContractsDoNotExposeWorkspaceScope()
        {
            Assert.Null(typeof(ExampleAWriteDto).GetProperty("WorkspaceFK"));
            Assert.Null(typeof(ExampleBWriteDto).GetProperty("WorkspaceFK"));
            Assert.Equal("demos.examples.parents", DemosViewCapabilityKeys.ParentsSource);
            Assert.Equal("demos.examples.children", DemosViewCapabilityKeys.ChildrenSource);
        }
    }
}