namespace Tests.Modules.Demos.Dynamic.Helpers
{
	/// <summary>
	/// Trait name constants for categorising Demos module tests.
	/// <para>
	/// Every test should carry at least a <see cref="Type"/> and a
	/// <see cref="Domain"/> trait; add a <see cref="Quality"/> trait
	/// whenever the test addresses an ISO-25010 quality characteristic.
	/// </para>
	/// <para>
	/// Usage:
	/// <code>
	/// [Trait(TestTraits.Type, TestTraits.Types.Dynamic)]
	/// [Trait(TestTraits.Domain, TestTraits.Domains.Discoveries)]
	/// [Trait(TestTraits.Quality, TestTraits.Iso25010.Reliability.Maturity)]
	/// </code>
	/// </para>
	/// <para>
	/// Filters:
	/// <c>dotnet test --filter "Type=Dynamic"</c>,
	/// <c>dotnet test --filter "Domain=Discoveries"</c>,
	/// <c>dotnet test --filter "Quality=Reliability.Maturity"</c>
	/// </para>
	/// <para>
	/// NOTE: an identical copy of this file exists in
	/// <c>Tests.Modules.Demos.Static</c>. Keep the two in sync.
	/// </para>
	/// </summary>
	public static class TestTraits
	{
		/// <summary>
		/// Trait key for the execution mode of the test.
		/// </summary>
		public const string Type = "Type";

		/// <summary>
		/// Execution modes. Mirrors the two test assemblies per module.
		/// </summary>
		public static class Types
		{
			/// <summary>Runs fully in-process: no host, no network, no real database.</summary>
			public const string Static = "Static";

			/// <summary>Requires a running host, real infrastructure, or real database.</summary>
			public const string Dynamic = "Dynamic";
		}

		/// <summary>
		/// Trait key for the functional domain or capability under test.
		/// Values are module-specific; extend <see cref="Domains"/> per module.
		/// </summary>
		public const string Domain = "Domain";

		/// <summary>
		/// Functional domains of the Demos module. Extend as the module grows.
		/// </summary>
		public static class Domains
		{
			/// <summary>Discoverer profiles and discovery operations.</summary>
			public const string Discoveries = "Discoveries";

			/// <summary>Module-wide structural and DI conventions.</summary>
			public const string Conventions = "Conventions";

			/// <summary>Assembly-level structural health and layer completeness.</summary>
			public const string Assembly = "Assembly";
		}

		/// <summary>
		/// Trait key for ISO-25010 quality attribute classifications.
		/// </summary>
		public const string Quality = "Quality";

		/// <summary>
		/// ISO-25010 Product Quality Model characteristics.
		/// </summary>
		public static class Iso25010
		{
			/// <summary>
			/// Functional Suitability: degree to which the product provides
			/// functions that meet stated and implied needs.
			/// </summary>
			public static class FunctionalSuitability
			{
				/// <summary>Degree to which functions cover all specified tasks and user objectives.</summary>
				public const string Completeness = "FunctionalSuitability.Completeness";

				/// <summary>Degree to which functions provide correct results with needed precision.</summary>
				public const string Correctness = "FunctionalSuitability.Correctness";
			}

			/// <summary>
			/// Reliability: degree to which a system performs specified functions
			/// under specified conditions for a specified period of time.
			/// </summary>
			public static class Reliability
			{
				/// <summary>Degree to which a system meets needs for reliability under normal operation.</summary>
				public const string Maturity = "Reliability.Maturity";
			}

			/// <summary>
			/// Maintainability: degree of effectiveness and efficiency with which
			/// a product can be modified.
			/// </summary>
			public static class Maintainability
			{
				/// <summary>Degree to which a system is composed of discrete components.</summary>
				public const string Modularity = "Maintainability.Modularity";

				/// <summary>Degree of effectiveness and efficiency with which it is possible to assess impact of a change.</summary>
				public const string Analysability = "Maintainability.Analysability";
			}
		}
	}
}
