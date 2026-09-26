using App.Modules.Sys.Substrate.Domains.Browse.Models;
using App.Modules.Sys.Substrate.Domains.Browse.Services;

namespace App.Modules.Demos.Application.Domains.Examples.Providers
{
    /// <summary>
    /// Owns the Demos ExampleA parent resource's source-aware Browse query description.
    /// </summary>
    /// <remarks>
    /// The provider enumerates the public <c>ExampleAReadDto</c> query vocabulary used by
    /// the Demos CRUST endpoint. <c>DemosCoordinatorBroker</c> consumes the same source
    /// paths to translate canonical Coordinator query intent to the endpoint's OData
    /// vocabulary. The descriptor is deliberately not inferred from
    /// <c>UniversalDataItemDto</c>, because queryable fields such as latitude and
    /// longitude need not be rendered in every tile.
    /// </remarks>
    public sealed class DemosExampleQueryCapabilityProvider : IBrowseQueryCapabilityProvider
    {
        private const string ResourceKeyValue = "demos.examples";
        private const string VersionValue = "1.0";

        private static readonly BrowseQueryCapability Capability = new(
            ResourceKeyValue,
            VersionValue,
            [
                new BrowseQueryFieldDescriptor(
                    "title",
                    "Title",
                    "text",
                    Sortable: true,
                    Filterable: true,
                    Searchable: true,
                    AllowedOperators: ["contains", "eq", "ne", "startsWith", "endsWith"]),
                new BrowseQueryFieldDescriptor(
                    "description",
                    "Description",
                    "text",
                    Sortable: true,
                    Filterable: true,
                    Searchable: true,
                    AllowedOperators: ["contains", "eq", "ne", "startsWith", "endsWith"]),
                new BrowseQueryFieldDescriptor(
                    "isActive",
                    "Active",
                    "boolean",
                    Sortable: true,
                    Filterable: true,
                    AllowedOperators: ["eq"]),
                new BrowseQueryFieldDescriptor(
                    "fromUtc",
                    "Starts",
                    "datetime",
                    Sortable: true,
                    Filterable: true,
                    AllowedOperators: ["eq", "ne", "lt", "gt", "between"]),
                new BrowseQueryFieldDescriptor(
                    "toUtc",
                    "Ends",
                    "datetime",
                    Sortable: true,
                    Filterable: true,
                    AllowedOperators: ["eq", "ne", "lt", "gt", "between"]),
                new BrowseQueryFieldDescriptor(
                    "latitude",
                    "Latitude",
                    "number",
                    Sortable: true,
                    Filterable: true,
                    AllowedOperators: ["eq", "ne", "lt", "lte", "gt", "gte", "between"]),
                new BrowseQueryFieldDescriptor(
                    "longitude",
                    "Longitude",
                    "number",
                    Sortable: true,
                    Filterable: true,
                    AllowedOperators: ["eq", "ne", "lt", "lte", "gt", "gte", "between"]),
            ]);

        /// <inheritdoc />
        public string ResourceKey => ResourceKeyValue;

        /// <inheritdoc />
        public BrowseQueryCapability Describe()
        {
            return Capability;
        }
    }
}