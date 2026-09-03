using App.Modules.Demos.Domain.Domains.Contributions.Structures.AtRest.Entities;
using App.Modules.Demos.Domain.Domains.Creations.Structures.AtRest.Models;
using App.Modules.Demos.Domain.Domains.Discoverers.Structures;
using App.Modules.Demos.Domain.Domains.Discoveries.Structures.AtRest.Entities;
using App.Modules.Demos.Domain.Domains.Influences.Structures.Entities;
using App.Modules.Demos.Domain.Domains.Structures.ReferenceData;
using App.Modules.Demos.Shared.Domains.Profiles.Models;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.DbContexts.Implementations.Base;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Demos.Infrastructure.Persistence.EF
{
    /// <summary>
    /// Database context for the Demos module.
    /// Each module has its own <see cref="DbContext"/> to enforce
    /// bounded context separation. Schema configurations are
    /// discovered automatically via <see cref="IEntityTypeConfiguration{TEntity}"/>
    /// implementations within this assembly.
    /// </summary>
    public class ModuleDbContext : ModuleDbContextBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleDbContext"/> class.
        /// </summary>
        /// <param name="options">
        /// The <see cref="DbContextOptions{TContext}"/> for this context.
        /// </param>
        public ModuleDbContext(DbContextOptions<ModuleDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the set of <see cref="DiscovererProfile"/> entities.
        /// </summary>
        public DbSet<DiscovererProfile> DiscovererProfiles { get; set; } = null!;

        /// <summary>
        /// Gets or sets the set of <see cref="CreatorProfile"/> entities.
        /// </summary>
        public DbSet<CreatorProfile> CreatorProfiles { get; set; } = null!;

        /// <summary>
        /// Gets or sets the set of <see cref="BelieverProfile"/> entities.
        /// </summary>
        public DbSet<BelieverProfile> BelieverProfiles { get; set; } = null!;

        /// <summary>
        /// Gets or sets the set of <see cref="Discovery"/> entities.
        /// </summary>
        public DbSet<Discovery> Discoveries { get; set; } = null!;

        /// <summary>
        /// Gets or sets the set of <see cref="Creation"/> entities.
        /// </summary>
        public DbSet<Creation> Creations { get; set; } = null!;

        /// <summary>
        /// Gets or sets the set of <see cref="Contribution"/> entities.
        /// </summary>
        public DbSet<Contribution> Contributions { get; set; } = null!;

        /// <summary>
        /// Gets or sets the set of <see cref="Influence"/> entities.
        /// </summary>
        public DbSet<Influence> Influences { get; set; } = null!;

        /// <summary>
        /// Gets or sets the set of <see cref="ProfileTypeReferenceData"/> reference data.
        /// </summary>
        public DbSet<ProfileTypeReferenceData> ProfileTypes { get; set; } = null!;

        /// <summary>
        /// Gets or sets the set of <see cref="InfluenceTypeReferenceData"/> reference data.
        /// </summary>
        public DbSet<InfluenceTypeReferenceData> InfluenceTypes { get; set; } = null!;

        /// <summary>
        /// Gets or sets the set of <see cref="InfluenceStrengthReferenceData"/> reference data.
        /// </summary>
        public DbSet<InfluenceStrengthReferenceData> InfluenceStrengths { get; set; } = null!;

        /// <summary>
        /// Gets or sets the set of <see cref="CreativeMediumReferenceData"/> reference data.
        /// </summary>
        public DbSet<CreativeMediumReferenceData> CreativeMedia { get; set; } = null!;

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ArgumentNullException.ThrowIfNull(modelBuilder);

            // Set schema before base call so all entities use this module's schema.
            this.SchemaKey = App.Modules.Demos.ModuleConstants.DbSchemaKey;

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ModuleDbContext).Assembly);
        }
    }
}
