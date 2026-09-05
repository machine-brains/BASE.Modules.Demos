using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Schema.Implementations;
using App.Modules.Demos.Shared.Domains.Profiles.Models;
using Microsoft.EntityFrameworkCore;
using App.Modules.Demos.Domain.Domains.Creations.Structures.AtRest.Models;
using App.Modules.Demos.Domain.Domains.Creations.Structures.AtRest.Enums;
using App.Modules.Demos.Domain.Domains.Contributions.Structures.AtRest.Entities;
using App.Modules.Demos.Domain.Domains.Discoverers.Structures;
using App.Modules.Demos.Domain.Domains.Discoveries.Structures.AtRest.Entities;
using App.Modules.Demos.Domain.Domains.Influences.Structures.Entities;
using App.Modules.Demos.Domain.Domains.Influences.Structures.Enums;
using App.Modules.Demos.Domain.Domains.Structures.ReferenceData;
using App.Modules.Sys.Substrate.Domains.Indexes;

namespace App.Modules.Demos.Infrastructure.Domains.DbSeeders.DbSeeders
{
    /// <summary>
    /// Seeds the Demos module with rich historical data from the Boorstin Trilogy.
    /// <para>
    /// Populates Discoverer, Creator, and Believer profiles with their
    /// contributions (discoveries, creations, and belief-system contributions)
    /// and a network of influence chains demonstrating how ideas propagate
    /// across disciplines and centuries.
    /// </para>
    /// <para>
    /// All GUIDs are deterministic to ensure idempotent seeding across
    /// environments. Cross-profile figures (e.g., Leonardo da Vinci as both
    /// Discoverer and Creator) share a single <c>PersonId</c>.
    /// </para>
    /// </summary>
    public class DemoDataSeeder : EFDataSeederBase
    {
        // ------------------------------------------------------------------
        //  Person GUIDs — Discoverer-only persons
        // ------------------------------------------------------------------

        private static readonly Guid _personColumbus = Guid.Parse("20000001-0001-0001-0001-000000000001");
        private static readonly Guid _personCopernicus = Guid.Parse("20000001-0001-0001-0001-000000000002");
        private static readonly Guid _personGalileo = Guid.Parse("20000001-0001-0001-0001-000000000003");
        private static readonly Guid _personNewton = Guid.Parse("20000001-0001-0001-0001-000000000004");
        private static readonly Guid _personDarwin = Guid.Parse("20000001-0001-0001-0001-000000000005");
        private static readonly Guid _personLeonardo = Guid.Parse("20000001-0001-0001-0001-000000000006");
        private static readonly Guid _personAristotle = Guid.Parse("20000001-0001-0001-0001-000000000007");
        private static readonly Guid _personLeeuwenhoek = Guid.Parse("20000001-0001-0001-0001-000000000008");
        private static readonly Guid _personCurie = Guid.Parse("20000001-0001-0001-0001-000000000009");
        private static readonly Guid _personWatt = Guid.Parse("20000001-0001-0001-0001-000000000010");

        // ------------------------------------------------------------------
        //  Person GUIDs — Creator-only persons
        // ------------------------------------------------------------------

        private static readonly Guid _personShakespeare = Guid.Parse("20000002-0002-0002-0002-000000000001");
        private static readonly Guid _personMichelangelo = Guid.Parse("20000002-0002-0002-0002-000000000002");
        private static readonly Guid _personBach = Guid.Parse("20000002-0002-0002-0002-000000000003");
        // Leonardo: uses _personLeonardo (cross-profile)
        private static readonly Guid _personGutenberg = Guid.Parse("20000002-0002-0002-0002-000000000005");
        private static readonly Guid _personMozart = Guid.Parse("20000002-0002-0002-0002-000000000006");
        // Newton: uses _personNewton (cross-profile)
        // Watt: uses _personWatt (cross-profile)

        // ------------------------------------------------------------------
        //  Person GUIDs — Believer-only persons
        // ------------------------------------------------------------------

        private static readonly Guid _personAquinas = Guid.Parse("20000003-0003-0003-0003-000000000001");
        private static readonly Guid _personLuther = Guid.Parse("20000003-0003-0003-0003-000000000002");
        private static readonly Guid _personConfucius = Guid.Parse("20000003-0003-0003-0003-000000000003");
        private static readonly Guid _personBuddha = Guid.Parse("20000003-0003-0003-0003-000000000004");
        private static readonly Guid _personMaimonides = Guid.Parse("20000003-0003-0003-0003-000000000005");
        // Aristotle: uses _personAristotle (cross-profile)
        private static readonly Guid _personPlato = Guid.Parse("20000003-0003-0003-0003-000000000007");

        // ------------------------------------------------------------------
        //  Discoverer Profile GUIDs
        // ------------------------------------------------------------------

        private static readonly Guid _discovererColumbus = Guid.Parse("10000001-0001-0001-0001-000000000001");
        private static readonly Guid _discovererCopernicus = Guid.Parse("10000001-0001-0001-0001-000000000002");
        private static readonly Guid _discovererGalileo = Guid.Parse("10000001-0001-0001-0001-000000000003");
        private static readonly Guid _discovererNewton = Guid.Parse("10000001-0001-0001-0001-000000000004");
        private static readonly Guid _discovererDarwin = Guid.Parse("10000001-0001-0001-0001-000000000005");
        private static readonly Guid _discovererLeonardo = Guid.Parse("10000001-0001-0001-0001-000000000006");
        private static readonly Guid _discovererAristotle = Guid.Parse("10000001-0001-0001-0001-000000000007");
        private static readonly Guid _discovererLeeuwenhoek = Guid.Parse("10000001-0001-0001-0001-000000000008");
        private static readonly Guid _discovererCurie = Guid.Parse("10000001-0001-0001-0001-000000000009");
        private static readonly Guid _discovererWatt = Guid.Parse("10000001-0001-0001-0001-000000000010");

        // ------------------------------------------------------------------
        //  Creator Profile GUIDs
        // ------------------------------------------------------------------

        private static readonly Guid _creatorShakespeare = Guid.Parse("10000002-0002-0002-0002-000000000001");
        private static readonly Guid _creatorMichelangelo = Guid.Parse("10000002-0002-0002-0002-000000000002");
        private static readonly Guid _creatorBach = Guid.Parse("10000002-0002-0002-0002-000000000003");
        private static readonly Guid _creatorLeonardo = Guid.Parse("10000002-0002-0002-0002-000000000004");
        private static readonly Guid _creatorGutenberg = Guid.Parse("10000002-0002-0002-0002-000000000005");
        private static readonly Guid _creatorMozart = Guid.Parse("10000002-0002-0002-0002-000000000006");
        private static readonly Guid _creatorNewton = Guid.Parse("10000002-0002-0002-0002-000000000007");
        private static readonly Guid _creatorWatt = Guid.Parse("10000002-0002-0002-0002-000000000008");

        // ------------------------------------------------------------------
        //  Believer Profile GUIDs
        // ------------------------------------------------------------------

        private static readonly Guid _believerAquinas = Guid.Parse("10000003-0003-0003-0003-000000000001");
        private static readonly Guid _believerLuther = Guid.Parse("10000003-0003-0003-0003-000000000002");
        private static readonly Guid _believerConfucius = Guid.Parse("10000003-0003-0003-0003-000000000003");
        private static readonly Guid _believerBuddha = Guid.Parse("10000003-0003-0003-0003-000000000004");
        private static readonly Guid _believerMaimonides = Guid.Parse("10000003-0003-0003-0003-000000000005");
        private static readonly Guid _believerAristotle = Guid.Parse("10000003-0003-0003-0003-000000000006");
        private static readonly Guid _believerPlato = Guid.Parse("10000003-0003-0003-0003-000000000007");

        // ------------------------------------------------------------------
        //  Discovery GUIDs
        // ------------------------------------------------------------------

        private static readonly Guid _discoveryNewWorld = Guid.Parse("30000001-0001-0001-0001-000000000001");
        private static readonly Guid _discoveryHeliocentrism = Guid.Parse("30000001-0001-0001-0001-000000000002");
        private static readonly Guid _discoveryMoonsOfJupiter = Guid.Parse("30000001-0001-0001-0001-000000000003");
        private static readonly Guid _discoveryPhasesOfVenus = Guid.Parse("30000001-0001-0001-0001-000000000004");
        private static readonly Guid _discoveryLawsOfMotion = Guid.Parse("30000001-0001-0001-0001-000000000005");
        private static readonly Guid _discoveryWhiteLight = Guid.Parse("30000001-0001-0001-0001-000000000006");
        private static readonly Guid _discoveryNaturalSelection = Guid.Parse("30000001-0001-0001-0001-000000000007");
        private static readonly Guid _discoveryHumanAnatomy = Guid.Parse("30000001-0001-0001-0001-000000000008");
        private static readonly Guid _discoveryPrinciplesOfFlight = Guid.Parse("30000001-0001-0001-0001-000000000009");
        private static readonly Guid _discoveryFormalLogic = Guid.Parse("30000001-0001-0001-0001-000000000010");
        private static readonly Guid _discoveryClassificationOfLiving = Guid.Parse("30000001-0001-0001-0001-000000000011");
        private static readonly Guid _discoveryMicroorganisms = Guid.Parse("30000001-0001-0001-0001-000000000012");
        private static readonly Guid _discoveryRadioactivity = Guid.Parse("30000001-0001-0001-0001-000000000013");
        private static readonly Guid _discoverySeparateCondenser = Guid.Parse("30000001-0001-0001-0001-000000000014");

        // ------------------------------------------------------------------
        //  Creation GUIDs
        // ------------------------------------------------------------------

        private static readonly Guid _creationHamlet = Guid.Parse("30000002-0002-0002-0002-000000000001");
        private static readonly Guid _creationTempest = Guid.Parse("30000002-0002-0002-0002-000000000002");
        private static readonly Guid _creationSistineChapel = Guid.Parse("30000002-0002-0002-0002-000000000003");
        private static readonly Guid _creationDavid = Guid.Parse("30000002-0002-0002-0002-000000000004");
        private static readonly Guid _creationWellTemperedClavier = Guid.Parse("30000002-0002-0002-0002-000000000005");
        private static readonly Guid _creationMassInBMinor = Guid.Parse("30000002-0002-0002-0002-000000000006");
        private static readonly Guid _creationMonaLisa = Guid.Parse("30000002-0002-0002-0002-000000000007");
        private static readonly Guid _creationLastSupper = Guid.Parse("30000002-0002-0002-0002-000000000008");
        private static readonly Guid _creationPrintingPress = Guid.Parse("30000002-0002-0002-0002-000000000009");
        private static readonly Guid _creationGutenbergBible = Guid.Parse("30000002-0002-0002-0002-000000000010");
        private static readonly Guid _creationMarriageOfFigaro = Guid.Parse("30000002-0002-0002-0002-000000000011");
        private static readonly Guid _creationRequiem = Guid.Parse("30000002-0002-0002-0002-000000000012");
        private static readonly Guid _creationPrincipia = Guid.Parse("30000002-0002-0002-0002-000000000013");
        private static readonly Guid _creationFluxions = Guid.Parse("30000002-0002-0002-0002-000000000014");
        private static readonly Guid _creationSteamEngine = Guid.Parse("30000002-0002-0002-0002-000000000015");

        // ------------------------------------------------------------------
        //  Contribution GUIDs
        // ------------------------------------------------------------------

        private static readonly Guid _contributionSummaTheologica = Guid.Parse("30000003-0003-0003-0003-000000000001");
        private static readonly Guid _contribution95Theses = Guid.Parse("30000003-0003-0003-0003-000000000002");
        private static readonly Guid _contributionGermanBible = Guid.Parse("30000003-0003-0003-0003-000000000003");
        private static readonly Guid _contributionAnalects = Guid.Parse("30000003-0003-0003-0003-000000000004");
        private static readonly Guid _contributionFourNobleTruths = Guid.Parse("30000003-0003-0003-0003-000000000005");
        private static readonly Guid _contributionGuidePerplexed = Guid.Parse("30000003-0003-0003-0003-000000000006");
        private static readonly Guid _contributionNicomacheanEthics = Guid.Parse("30000003-0003-0003-0003-000000000007");
        private static readonly Guid _contributionMetaphysics = Guid.Parse("30000003-0003-0003-0003-000000000008");
        private static readonly Guid _contributionRepublic = Guid.Parse("30000003-0003-0003-0003-000000000009");

        // ------------------------------------------------------------------
        //  Influence GUIDs
        // ------------------------------------------------------------------

        private static readonly Guid _influenceAristotleToPtolemy = Guid.Parse("40000001-0001-0001-0001-000000000001");
        private static readonly Guid _influenceAristotleToAquinas = Guid.Parse("40000001-0001-0001-0001-000000000002");
        private static readonly Guid _influencePlatoToAristotle = Guid.Parse("40000001-0001-0001-0001-000000000003");
        private static readonly Guid _influenceCopernicusToGalileo = Guid.Parse("40000001-0001-0001-0001-000000000004");
        private static readonly Guid _influenceGalileoToNewton = Guid.Parse("40000001-0001-0001-0001-000000000005");
        private static readonly Guid _influenceNewtonToDarwin = Guid.Parse("40000001-0001-0001-0001-000000000006");
        private static readonly Guid _influenceGutenbergToLuther = Guid.Parse("40000001-0001-0001-0001-000000000007");
        private static readonly Guid _influenceGutenbergToShakespeare = Guid.Parse("40000001-0001-0001-0001-000000000008");
        private static readonly Guid _influenceGutenbergToCopernicus = Guid.Parse("40000001-0001-0001-0001-000000000009");
        private static readonly Guid _influenceLeonardoToGalileo = Guid.Parse("40000001-0001-0001-0001-000000000010");
        private static readonly Guid _influenceLeonardoToMichelangelo = Guid.Parse("40000001-0001-0001-0001-000000000011");
        private static readonly Guid _influenceBachToMozart = Guid.Parse("40000001-0001-0001-0001-000000000012");
        private static readonly Guid _influenceWattToDarwin = Guid.Parse("40000001-0001-0001-0001-000000000013");
        private static readonly Guid _influenceLeeuwenhoekToCurie = Guid.Parse("40000001-0001-0001-0001-000000000014");
        private static readonly Guid _influenceConfuciusToBuddha = Guid.Parse("40000001-0001-0001-0001-000000000015");
        private static readonly Guid _influenceAristotleToMaimonides = Guid.Parse("40000001-0001-0001-0001-000000000016");
        private static readonly Guid _influenceMaimonidesToAquinas = Guid.Parse("40000001-0001-0001-0001-000000000017");

        // ------------------------------------------------------------------
        //  Ptolemy — referenced in influence chains but not in the primary
        //  discoverer list. Included as a minimal discoverer so the
        //  influence from Aristotle → Ptolemy has a valid target profile.
        // ------------------------------------------------------------------

        private static readonly Guid _personPtolemy = Guid.Parse("20000001-0001-0001-0001-000000000011");
        private static readonly Guid _discovererPtolemy = Guid.Parse("10000001-0001-0001-0001-000000000011");

        /// <summary>
        /// Seeds all historical demo data into the <see cref="ModelBuilder"/>
        /// using EF Core HasData seed configuration.
        /// <para>
        /// This method is idempotent: deterministic GUIDs and a fixed
        /// timestamp ensure the same rows are produced on every run.
        /// </para>
        /// </summary>
        /// <param name="modelBuilder">
        /// The <see cref="ModelBuilder"/> to receive seed data.
        /// </param>
        public override void Seed(ModelBuilder modelBuilder)
        {
            ArgumentNullException.ThrowIfNull(modelBuilder);

            // Reference data seeders (ProfileType, InfluenceType, InfluenceStrength,
            // CreativeMedium) are discovered and called independently by the
            // RunTimeModelBuilderOrchestrator. Do not call them here as well
            // or EF will detect duplicate HasData entries for the same key.

            SeedDiscovererProfiles(modelBuilder);
            SeedCreatorProfiles(modelBuilder);
            SeedBelieverProfiles(modelBuilder);

            SeedDiscoveries(modelBuilder);
            SeedCreations(modelBuilder);
            SeedContributions(modelBuilder);

            SeedInfluences(modelBuilder);
        }

        // ==================================================================
        //  Discoverer Profiles
        // ==================================================================

        /// <summary>
        /// Seeds <see cref="DiscovererProfile"/> entities representing
        /// historical figures whose primary contribution was the
        /// expansion of knowledge through exploration and inquiry.
        /// </summary>
        private static void SeedDiscovererProfiles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiscovererProfile>().HasData(
                new DiscovererProfile
                {
                    Id = _discovererColumbus,
                    PersonId = _personColumbus,
                    Title = "Christopher Columbus",
                    Description = "Genoese navigator whose transatlantic voyages opened sustained European contact with the Americas.",
                    EraFrom = 1451,
                    EraTo = 1506,
                    FieldOfStudy = "Navigation and Exploration",
                    Nationality = "Genoese"
                },
                new DiscovererProfile
                {
                    Id = _discovererCopernicus,
                    PersonId = _personCopernicus,
                    Title = "Nicolaus Copernicus",
                    Description = "Renaissance polymath who formulated the heliocentric model of the universe, displacing the Earth from the centre of the cosmos.",
                    EraFrom = 1473,
                    EraTo = 1543,
                    FieldOfStudy = "Astronomy and Mathematics",
                    Nationality = "Polish"
                },
                new DiscovererProfile
                {
                    Id = _discovererGalileo,
                    PersonId = _personGalileo,
                    Title = "Galileo Galilei",
                    Description = "Italian astronomer and physicist whose telescopic observations and experiments laid the groundwork for modern observational science.",
                    EraFrom = 1564,
                    EraTo = 1642,
                    FieldOfStudy = "Astronomy and Physics",
                    Nationality = "Italian"
                },
                new DiscovererProfile
                {
                    Id = _discovererNewton,
                    PersonId = _personNewton,
                    Title = "Isaac Newton",
                    Description = "English mathematician and natural philosopher who unified celestial and terrestrial mechanics through the laws of motion and universal gravitation.",
                    EraFrom = 1643,
                    EraTo = 1727,
                    FieldOfStudy = "Physics, Mathematics, and Optics",
                    Nationality = "English"
                },
                new DiscovererProfile
                {
                    Id = _discovererDarwin,
                    PersonId = _personDarwin,
                    Title = "Charles Darwin",
                    Description = "English naturalist whose theory of evolution by natural selection transformed the understanding of biological diversity.",
                    EraFrom = 1809,
                    EraTo = 1882,
                    FieldOfStudy = "Natural History and Biology",
                    Nationality = "English"
                },
                new DiscovererProfile
                {
                    Id = _discovererLeonardo,
                    PersonId = _personLeonardo,
                    Title = "Leonardo da Vinci",
                    Description = "Florentine polymath whose empirical investigations of anatomy, flight, and engineering anticipated modern scientific method.",
                    EraFrom = 1452,
                    EraTo = 1519,
                    FieldOfStudy = "Anatomy, Engineering, and Natural Philosophy",
                    Nationality = "Italian"
                },
                new DiscovererProfile
                {
                    Id = _discovererAristotle,
                    PersonId = _personAristotle,
                    Title = "Aristotle",
                    Description = "Greek philosopher who established formal logic and pioneered the systematic classification of knowledge across natural philosophy, ethics, and politics.",
                    EraFrom = -384,
                    EraTo = -322,
                    FieldOfStudy = "Logic, Natural Philosophy, and Biology",
                    Nationality = "Greek"
                },
                new DiscovererProfile
                {
                    Id = _discovererLeeuwenhoek,
                    PersonId = _personLeeuwenhoek,
                    Title = "Antonie van Leeuwenhoek",
                    Description = "Dutch tradesman and self-taught lens grinder who first observed microorganisms, founding the discipline of microbiology.",
                    EraFrom = 1632,
                    EraTo = 1723,
                    FieldOfStudy = "Microscopy and Microbiology",
                    Nationality = "Dutch"
                },
                new DiscovererProfile
                {
                    Id = _discovererCurie,
                    PersonId = _personCurie,
                    Title = "Marie Curie",
                    Description = "Polish-French physicist and chemist who conducted pioneering research on radioactivity, discovering polonium and radium.",
                    EraFrom = 1867,
                    EraTo = 1934,
                    FieldOfStudy = "Physics and Chemistry",
                    Nationality = "Polish-French"
                },
                new DiscovererProfile
                {
                    Id = _discovererWatt,
                    PersonId = _personWatt,
                    Title = "James Watt",
                    Description = "Scottish inventor and mechanical engineer whose separate condenser transformed steam power and catalysed the Industrial Revolution.",
                    EraFrom = 1736,
                    EraTo = 1819,
                    FieldOfStudy = "Mechanical Engineering and Thermodynamics",
                    Nationality = "Scottish"
                },
                new DiscovererProfile
                {
                    Id = _discovererPtolemy,
                    PersonId = _personPtolemy,
                    Title = "Claudius Ptolemy",
                    Description = "Greco-Egyptian astronomer and mathematician whose geocentric model dominated Western and Islamic astronomy for over a millennium.",
                    EraFrom = 100,
                    EraTo = 170,
                    FieldOfStudy = "Astronomy, Geography, and Mathematics",
                    Nationality = "Greco-Egyptian"
                }
            );
        }

        // ==================================================================
        //  Creator Profiles
        // ==================================================================

        /// <summary>
        /// Seeds <see cref="CreatorProfile"/> entities representing
        /// historical figures whose primary contribution was the
        /// production of enduring creative or intellectual works.
        /// </summary>
        private static void SeedCreatorProfiles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreatorProfile>().HasData(
                new CreatorProfile
                {
                    Id = _creatorShakespeare,
                    PersonId = _personShakespeare,
                    Title = "William Shakespeare",
                    Description = "English playwright and poet widely regarded as the greatest writer in the English language and the world's pre-eminent dramatist.",
                    EraFrom = 1564,
                    EraTo = 1616,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.Literature),
                    Nationality = "English"
                },
                new CreatorProfile
                {
                    Id = _creatorMichelangelo,
                    PersonId = _personMichelangelo,
                    Title = "Michelangelo Buonarroti",
                    Description = "Italian sculptor, painter, and architect whose works in the Sistine Chapel and the statue of David epitomise Renaissance art.",
                    EraFrom = 1475,
                    EraTo = 1564,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.VisualArt),
                    Nationality = "Italian"
                },
                new CreatorProfile
                {
                    Id = _creatorBach,
                    PersonId = _personBach,
                    Title = "Johann Sebastian Bach",
                    Description = "German composer and musician whose mastery of counterpoint and harmonic organisation profoundly shaped Western classical music.",
                    EraFrom = 1685,
                    EraTo = 1750,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.Music),
                    Nationality = "German"
                },
                new CreatorProfile
                {
                    Id = _creatorLeonardo,
                    PersonId = _personLeonardo,
                    Title = "Leonardo da Vinci",
                    Description = "Florentine polymath whose paintings, including the Mona Lisa and The Last Supper, set enduring standards for artistic achievement.",
                    EraFrom = 1452,
                    EraTo = 1519,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.VisualArt),
                    Nationality = "Italian"
                },
                new CreatorProfile
                {
                    Id = _creatorGutenberg,
                    PersonId = _personGutenberg,
                    Title = "Johannes Gutenberg",
                    Description = "German blacksmith and inventor who introduced mechanical movable-type printing to Europe, revolutionising the dissemination of knowledge.",
                    EraFrom = 1400,
                    EraTo = 1468,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.Technology),
                    Nationality = "German"
                },
                new CreatorProfile
                {
                    Id = _creatorMozart,
                    PersonId = _personMozart,
                    Title = "Wolfgang Amadeus Mozart",
                    Description = "Austrian composer and child prodigy whose prolific output in symphonies, operas, and chamber music epitomises the Classical era.",
                    EraFrom = 1756,
                    EraTo = 1791,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.Music),
                    Nationality = "Austrian"
                },
                new CreatorProfile
                {
                    Id = _creatorNewton,
                    PersonId = _personNewton,
                    Title = "Isaac Newton",
                    Description = "English polymath whose Principia Mathematica and invention of calculus rank among the most influential intellectual creations in history.",
                    EraFrom = 1643,
                    EraTo = 1727,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.Science),
                    Nationality = "English"
                },
                new CreatorProfile
                {
                    Id = _creatorWatt,
                    PersonId = _personWatt,
                    Title = "James Watt",
                    Description = "Scottish inventor whose improved steam engine with a separate condenser was a decisive technological creation of the Industrial Revolution.",
                    EraFrom = 1736,
                    EraTo = 1819,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.Technology),
                    Nationality = "Scottish"
                }
            );
        }

        // ==================================================================
        //  Believer Profiles
        // ==================================================================

        /// <summary>
        /// Seeds <see cref="BelieverProfile"/> entities representing
        /// historical figures whose primary contribution was shaping
        /// civilisation through faith, philosophy, or ideological vision.
        /// </summary>
        private static void SeedBelieverProfiles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BelieverProfile>().HasData(
                new BelieverProfile
                {
                    Id = _believerAquinas,
                    PersonId = _personAquinas,
                    Title = "Thomas Aquinas",
                    Description = "Italian Dominican friar and theologian who synthesised Aristotelian philosophy with Christian doctrine in the Summa Theologica.",
                    EraFrom = 1225,
                    EraTo = 1274,
                    TraditionName = "Christianity / Scholasticism",
                    Nationality = "Italian"
                },
                new BelieverProfile
                {
                    Id = _believerLuther,
                    PersonId = _personLuther,
                    Title = "Martin Luther",
                    Description = "German theologian and reformer whose 95 Theses ignited the Protestant Reformation and reshaped Western Christianity.",
                    EraFrom = 1483,
                    EraTo = 1546,
                    TraditionName = "Protestantism",
                    Nationality = "German"
                },
                new BelieverProfile
                {
                    Id = _believerConfucius,
                    PersonId = _personConfucius,
                    Title = "Confucius",
                    Description = "Chinese philosopher whose teachings on ethics, family loyalty, and governance became the foundation of East Asian moral and political thought.",
                    EraFrom = -551,
                    EraTo = -479,
                    TraditionName = "Confucianism",
                    Nationality = "Chinese"
                },
                new BelieverProfile
                {
                    Id = _believerBuddha,
                    PersonId = _personBuddha,
                    Title = "Siddhartha Gautama (Buddha)",
                    Description = "Indian spiritual teacher whose Four Noble Truths and Eightfold Path founded Buddhism, one of the world's major wisdom traditions.",
                    EraFrom = -563,
                    EraTo = -483,
                    TraditionName = "Buddhism",
                    Nationality = "Indian"
                },
                new BelieverProfile
                {
                    Id = _believerMaimonides,
                    PersonId = _personMaimonides,
                    Title = "Moses Maimonides",
                    Description = "Medieval Sephardic Jewish philosopher and Torah scholar whose Guide for the Perplexed harmonised Aristotelian philosophy with Jewish theology.",
                    EraFrom = 1138,
                    EraTo = 1204,
                    TraditionName = "Judaism",
                    Nationality = "Andalusian"
                },
                new BelieverProfile
                {
                    Id = _believerAristotle,
                    PersonId = _personAristotle,
                    Title = "Aristotle",
                    Description = "Greek philosopher whose ethical and metaphysical writings shaped Western philosophy, Christian scholasticism, and Islamic thought for two millennia.",
                    EraFrom = -384,
                    EraTo = -322,
                    TraditionName = "Aristotelian Philosophy",
                    Nationality = "Greek"
                },
                new BelieverProfile
                {
                    Id = _believerPlato,
                    PersonId = _personPlato,
                    Title = "Plato",
                    Description = "Athenian philosopher and founder of the Academy whose theory of Forms and political philosophy profoundly influenced Western thought.",
                    EraFrom = -428,
                    EraTo = -348,
                    TraditionName = "Platonism",
                    Nationality = "Greek"
                }
            );
        }

        // ==================================================================
        //  Discoveries
        // ==================================================================

        /// <summary>
        /// Seeds <see cref="Discovery"/> entities representing landmark
        /// moments of empirical insight and exploration.
        /// </summary>
        private static void SeedDiscoveries(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discovery>().HasData(
                new Discovery
                {
                    Id = _discoveryNewWorld,
                    DiscovererProfileId = _discovererColumbus,
                    Title = "New World",
                    Description = "First sustained European contact with the American continents following the transatlantic voyage of 1492.",
                    Year = 1492,
                    LocationName = "Caribbean Sea",
                    Latitude = 18.2,
                    Longitude = -66.5,
                    Significance = "Initiated the Columbian Exchange and permanently linked the Eastern and Western hemispheres."
                },
                new Discovery
                {
                    Id = _discoveryHeliocentrism,
                    DiscovererProfileId = _discovererCopernicus,
                    Title = "Heliocentrism",
                    Description = "The model placing the Sun rather than the Earth at the centre of the universe, published in De Revolutionibus Orbium Coelestium.",
                    Year = 1543,
                    LocationName = "Frombork, Poland",
                    Latitude = 54.35,
                    Longitude = 19.68,
                    Significance = "Overturned the Ptolemaic geocentric model and launched the Scientific Revolution."
                },
                new Discovery
                {
                    Id = _discoveryMoonsOfJupiter,
                    DiscovererProfileId = _discovererGalileo,
                    Title = "Moons of Jupiter",
                    Description = "Telescopic observation of four moons orbiting Jupiter, demonstrating that not all celestial bodies revolve around the Earth.",
                    Year = 1610,
                    LocationName = "Padua, Italy",
                    Latitude = 45.41,
                    Longitude = 11.88,
                    Significance = "Provided direct observational evidence against geocentrism and bolstered the Copernican model."
                },
                new Discovery
                {
                    Id = _discoveryPhasesOfVenus,
                    DiscovererProfileId = _discovererGalileo,
                    Title = "Phases of Venus",
                    Description = "Telescopic observation that Venus exhibits a full set of phases, consistent only with an orbit around the Sun.",
                    Year = 1610,
                    LocationName = "Padua, Italy",
                    Latitude = 45.41,
                    Longitude = 11.88,
                    Significance = "Decisively refuted the Ptolemaic model and confirmed a heliocentric arrangement of the inner planets."
                },
                new Discovery
                {
                    Id = _discoveryLawsOfMotion,
                    DiscovererProfileId = _discovererNewton,
                    Title = "Laws of Motion and Universal Gravitation",
                    Description = "Three laws of motion and the inverse-square law of gravitational attraction, unifying terrestrial and celestial mechanics.",
                    Year = 1687,
                    LocationName = "Cambridge, England",
                    Latitude = 52.2,
                    Longitude = 0.12,
                    Significance = "Established the foundation of classical mechanics and dominated physics for over two centuries."
                },
                new Discovery
                {
                    Id = _discoveryWhiteLight,
                    DiscovererProfileId = _discovererNewton,
                    Title = "Composition of White Light",
                    Description = "Prism experiments demonstrating that white light is composed of a spectrum of colours that can be separated and recombined.",
                    Year = 1672,
                    LocationName = "Cambridge, England",
                    Latitude = 52.2,
                    Longitude = 0.12,
                    Significance = "Founded the science of optics and overturned the ancient theory that colour is a modification of white light."
                },
                new Discovery
                {
                    Id = _discoveryNaturalSelection,
                    DiscovererProfileId = _discovererDarwin,
                    Title = "Natural Selection",
                    Description = "The mechanism by which organisms with favourable traits are more likely to survive and reproduce, driving evolutionary change.",
                    Year = 1859,
                    LocationName = "Down House, Kent",
                    Latitude = 51.33,
                    Longitude = 0.05,
                    Significance = "Provided a unifying explanatory framework for the diversity and adaptation of life on Earth."
                },
                new Discovery
                {
                    Id = _discoveryHumanAnatomy,
                    DiscovererProfileId = _discovererLeonardo,
                    Title = "Human Anatomy Studies",
                    Description = "Detailed dissections and anatomical drawings revealing the structure of the human body with unprecedented accuracy.",
                    Year = 1489,
                    LocationName = "Milan, Italy",
                    Latitude = 45.46,
                    Longitude = 9.19,
                    Significance = "Advanced understanding of human anatomy centuries ahead of formal medical science."
                },
                new Discovery
                {
                    Id = _discoveryPrinciplesOfFlight,
                    DiscovererProfileId = _discovererLeonardo,
                    Title = "Principles of Flight",
                    Description = "Studies of bird flight and designs for flying machines based on empirical observation of aerodynamic principles.",
                    Year = 1505,
                    LocationName = "Florence, Italy",
                    Latitude = 43.77,
                    Longitude = 11.25,
                    Significance = "Anticipated principles of aerodynamics and inspired centuries of flight research."
                },
                new Discovery
                {
                    Id = _discoveryFormalLogic,
                    DiscovererProfileId = _discovererAristotle,
                    Title = "Formal Logic and Syllogism",
                    Description = "The system of deductive reasoning through syllogisms, establishing logic as a formal discipline.",
                    Year = -340,
                    LocationName = "Athens, Greece",
                    Latitude = 37.97,
                    Longitude = 23.72,
                    Significance = "Created the foundation of Western logic that remained definitive until the advent of modern mathematical logic."
                },
                new Discovery
                {
                    Id = _discoveryClassificationOfLiving,
                    DiscovererProfileId = _discovererAristotle,
                    Title = "Classification of Living Things",
                    Description = "Systematic observation and categorisation of animal species, distinguishing genera and species by shared characteristics.",
                    Year = -340,
                    LocationName = "Athens, Greece",
                    Latitude = 37.97,
                    Longitude = 23.72,
                    Significance = "Pioneered biological taxonomy and remained the basis of natural history classification until Linnaeus."
                },
                new Discovery
                {
                    Id = _discoveryMicroorganisms,
                    DiscovererProfileId = _discovererLeeuwenhoek,
                    Title = "Microorganisms",
                    Description = "First observation of single-celled organisms through hand-crafted high-powered microscope lenses.",
                    Year = 1676,
                    LocationName = "Delft, Netherlands",
                    Latitude = 52.01,
                    Longitude = 4.36,
                    Significance = "Revealed an invisible world of microbial life and founded the discipline of microbiology."
                },
                new Discovery
                {
                    Id = _discoveryRadioactivity,
                    DiscovererProfileId = _discovererCurie,
                    Title = "Radioactivity / Polonium and Radium",
                    Description = "Isolation of two new radioactive elements and pioneering research into the nature of radioactive decay.",
                    Year = 1898,
                    LocationName = "Paris, France",
                    Latitude = 48.85,
                    Longitude = 2.35,
                    Significance = "Opened the field of nuclear physics and earned the first Nobel Prizes awarded to a woman."
                },
                new Discovery
                {
                    Id = _discoverySeparateCondenser,
                    DiscovererProfileId = _discovererWatt,
                    Title = "Separate Condenser Principle",
                    Description = "The insight that condensing steam in a separate vessel dramatically improves the efficiency of the steam engine.",
                    Year = 1765,
                    LocationName = "Glasgow, Scotland",
                    Latitude = 55.86,
                    Longitude = -4.25,
                    Significance = "Multiplied the efficiency of steam power and catalysed the Industrial Revolution."
                }
            );
        }

        // ==================================================================
        //  Creations
        // ==================================================================

        /// <summary>
        /// Seeds <see cref="Creation"/> entities representing enduring
        /// works of art, literature, music, science, and technology.
        /// </summary>
        private static void SeedCreations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Creation>().HasData(
                new Creation
                {
                    Id = _creationHamlet,
                    CreatorProfileId = _creatorShakespeare,
                    Title = "Hamlet",
                    Description = "Tragedy exploring the moral complexities of revenge, madness, and mortality through the Prince of Denmark.",
                    Year = 1601,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.Literature),
                    Genre = "Tragedy",
                    Significance = "Considered the most influential play in the English language and a cornerstone of Western drama."
                },
                new Creation
                {
                    Id = _creationTempest,
                    CreatorProfileId = _creatorShakespeare,
                    Title = "The Tempest",
                    Description = "Romance exploring themes of power, magic, forgiveness, and colonial encounter on an enchanted island.",
                    Year = 1611,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.Literature),
                    Genre = "Romance",
                    Significance = "Shakespeare's final solo play and a profound meditation on art, authority, and reconciliation."
                },
                new Creation
                {
                    Id = _creationSistineChapel,
                    CreatorProfileId = _creatorMichelangelo,
                    Title = "Sistine Chapel Ceiling",
                    Description = "Monumental fresco cycle depicting scenes from Genesis, painted on the vault of the Sistine Chapel in Vatican City.",
                    Year = 1512,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.VisualArt),
                    Genre = "Fresco",
                    Significance = "One of the supreme achievements of Renaissance art and a defining masterpiece of Western visual culture."
                },
                new Creation
                {
                    Id = _creationDavid,
                    CreatorProfileId = _creatorMichelangelo,
                    Title = "David",
                    Description = "Monumental marble sculpture of the biblical hero David, embodying the Renaissance ideal of human beauty and civic virtue.",
                    Year = 1504,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.VisualArt),
                    Genre = "Sculpture",
                    Significance = "A symbol of Florentine strength and one of the most recognised works of sculpture in history."
                },
                new Creation
                {
                    Id = _creationWellTemperedClavier,
                    CreatorProfileId = _creatorBach,
                    Title = "Well-Tempered Clavier",
                    Description = "Collection of preludes and fugues in all 24 major and minor keys, demonstrating the viability of well temperament.",
                    Year = 1722,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.Music),
                    Genre = "Keyboard",
                    Significance = "A foundational work for keyboard technique and a touchstone for every subsequent generation of composers."
                },
                new Creation
                {
                    Id = _creationMassInBMinor,
                    CreatorProfileId = _creatorBach,
                    Title = "Mass in B Minor",
                    Description = "Monumental choral setting of the Latin Mass regarded as one of the greatest compositions in the history of music.",
                    Year = 1749,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.Music),
                    Genre = "Choral / Sacred",
                    Significance = "Represents the culmination of Baroque choral writing and a universal statement of musical faith."
                },
                new Creation
                {
                    Id = _creationMonaLisa,
                    CreatorProfileId = _creatorLeonardo,
                    Title = "Mona Lisa",
                    Description = "Half-length portrait renowned for its sfumato technique, enigmatic expression, and atmospheric landscape.",
                    Year = 1503,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.VisualArt),
                    Genre = "Portrait",
                    Significance = "The most famous painting in the world and an enduring icon of Renaissance art."
                },
                new Creation
                {
                    Id = _creationLastSupper,
                    CreatorProfileId = _creatorLeonardo,
                    Title = "The Last Supper",
                    Description = "Mural depicting the moment Christ announces one of his disciples will betray him, painted in the refectory of Santa Maria delle Grazie.",
                    Year = 1498,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.VisualArt),
                    Genre = "Mural",
                    Significance = "A masterpiece of narrative composition and one of the most studied works in art history."
                },
                new Creation
                {
                    Id = _creationPrintingPress,
                    CreatorProfileId = _creatorGutenberg,
                    Title = "Printing Press",
                    Description = "Mechanical movable-type printing system that enabled the mass production of books and printed material.",
                    Year = 1440,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.Technology),
                    Genre = "Mechanical Innovation",
                    Significance = "Arguably the most transformative invention of the second millennium, enabling the democratisation of knowledge."
                },
                new Creation
                {
                    Id = _creationGutenbergBible,
                    CreatorProfileId = _creatorGutenberg,
                    Title = "Gutenberg Bible",
                    Description = "The first major book printed using movable type in the West, a Latin Vulgate Bible of extraordinary craftsmanship.",
                    Year = 1455,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.Literature),
                    Genre = "Sacred Text",
                    Significance = "Demonstrated the commercial and cultural viability of printed books, launching the print revolution."
                },
                new Creation
                {
                    Id = _creationMarriageOfFigaro,
                    CreatorProfileId = _creatorMozart,
                    Title = "The Marriage of Figaro",
                    Description = "Comic opera in four acts based on Beaumarchais's play, blending wit, emotional depth, and social commentary.",
                    Year = 1786,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.Music),
                    Genre = "Opera",
                    Significance = "A pinnacle of operatic art that redefined the integration of music and dramatic characterisation."
                },
                new Creation
                {
                    Id = _creationRequiem,
                    CreatorProfileId = _creatorMozart,
                    Title = "Requiem",
                    Description = "Unfinished Requiem Mass in D minor composed in the final weeks of Mozart's life, completed posthumously.",
                    Year = 1791,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.Music),
                    Genre = "Choral / Sacred",
                    Significance = "One of the most celebrated and emotionally powerful sacred choral works ever composed."
                },
                new Creation
                {
                    Id = _creationPrincipia,
                    CreatorProfileId = _creatorNewton,
                    Title = "Principia Mathematica",
                    Description = "Philosophiæ Naturalis Principia Mathematica, laying out the laws of motion and universal gravitation in mathematical form.",
                    Year = 1687,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.Science),
                    Genre = "Treatise",
                    Significance = "The single most influential scientific publication in history, unifying terrestrial and celestial mechanics."
                },
                new Creation
                {
                    Id = _creationFluxions,
                    CreatorProfileId = _creatorNewton,
                    Title = "Method of Fluxions (Calculus)",
                    Description = "Development of the mathematical method of fluxions, Newton's formulation of infinitesimal calculus.",
                    Year = 1671,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.Science),
                    Genre = "Mathematical Method",
                    Significance = "Provided the mathematical language essential for physics, engineering, and the modern sciences."
                },
                new Creation
                {
                    Id = _creationSteamEngine,
                    CreatorProfileId = _creatorWatt,
                    Title = "Steam Engine (Improved)",
                    Description = "Watt's improved steam engine with a separate condenser, dramatically increasing thermal efficiency.",
                    Year = 1776,
                    CreativeMediumId = DeterministicGuid.FromEnum(CreativeMedium.Technology),
                    Genre = "Mechanical Engineering",
                    Significance = "Powered the factories, mines, and transport networks of the Industrial Revolution."
                }
            );
        }

        // ==================================================================
        //  Contributions (Believers)
        // ==================================================================

        /// <summary>
        /// Seeds <see cref="Contribution"/> entities representing landmark
        /// works of faith, philosophy, and ideological vision.
        /// </summary>
        private static void SeedContributions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contribution>().HasData(
                new Contribution
                {
                    Id = _contributionSummaTheologica,
                    BelieverProfileId = _believerAquinas,
                    Title = "Summa Theologica",
                    Description = "Comprehensive theological treatise synthesising Aristotelian philosophy with Christian doctrine across five volumes.",
                    Year = 1274,
                    TraditionName = "Christianity / Scholasticism",
                    Significance = "The most influential work of medieval theology and a pillar of Catholic intellectual tradition."
                },
                new Contribution
                {
                    Id = _contribution95Theses,
                    BelieverProfileId = _believerLuther,
                    Title = "95 Theses",
                    Description = "List of propositions challenging the sale of indulgences and papal authority, posted at Wittenberg in 1517.",
                    Year = 1517,
                    TraditionName = "Protestantism",
                    Significance = "Ignited the Protestant Reformation and permanently fractured Western Christendom."
                },
                new Contribution
                {
                    Id = _contributionGermanBible,
                    BelieverProfileId = _believerLuther,
                    Title = "German Translation of Bible",
                    Description = "Luther's translation of the Bible into vernacular German, making scripture accessible to ordinary readers.",
                    Year = 1534,
                    TraditionName = "Protestantism",
                    Significance = "Standardised the German language and advanced the principle of individual scriptural engagement."
                },
                new Contribution
                {
                    Id = _contributionAnalects,
                    BelieverProfileId = _believerConfucius,
                    Title = "Analects",
                    Description = "Collection of sayings and ideas attributed to Confucius, covering ethics, governance, and personal cultivation.",
                    Year = -500,
                    TraditionName = "Confucianism",
                    Significance = "The foundational text of Confucian thought, shaping East Asian civilisation for over two millennia."
                },
                new Contribution
                {
                    Id = _contributionFourNobleTruths,
                    BelieverProfileId = _believerBuddha,
                    Title = "Four Noble Truths",
                    Description = "The core teaching of Buddhism: the truth of suffering, its origin, its cessation, and the path leading to cessation.",
                    Year = -500,
                    TraditionName = "Buddhism",
                    Significance = "The cornerstone of Buddhist philosophy and practice, adopted across Asia and beyond."
                },
                new Contribution
                {
                    Id = _contributionGuidePerplexed,
                    BelieverProfileId = _believerMaimonides,
                    Title = "Guide for the Perplexed",
                    Description = "Philosophical work harmonising Aristotelian rationalism with Jewish theology for intellectually troubled believers.",
                    Year = 1190,
                    TraditionName = "Judaism",
                    Significance = "The foremost work of medieval Jewish philosophy, influential in both Jewish and Christian scholasticism."
                },
                new Contribution
                {
                    Id = _contributionNicomacheanEthics,
                    BelieverProfileId = _believerAristotle,
                    Title = "Nicomachean Ethics",
                    Description = "Treatise on the nature of the good life, virtue, and human flourishing through rational activity of the soul.",
                    Year = -340,
                    TraditionName = "Aristotelian Philosophy",
                    Significance = "The most influential work of Western ethical philosophy and a foundation of virtue ethics."
                },
                new Contribution
                {
                    Id = _contributionMetaphysics,
                    BelieverProfileId = _believerAristotle,
                    Title = "Metaphysics",
                    Description = "Investigation into the nature of being, substance, causation, and the first principles of reality.",
                    Year = -340,
                    TraditionName = "Aristotelian Philosophy",
                    Significance = "Defined the discipline of metaphysics and shaped ontological inquiry for two millennia."
                },
                new Contribution
                {
                    Id = _contributionRepublic,
                    BelieverProfileId = _believerPlato,
                    Title = "The Republic",
                    Description = "Dialogue exploring justice, the ideal state, and the philosopher-king, centred on the Allegory of the Cave.",
                    Year = -375,
                    TraditionName = "Platonism",
                    Significance = "One of the most influential works of philosophy and political theory in Western history."
                }
            );
        }

        // ==================================================================
        //  Influences
        // ==================================================================

        /// <summary>
        /// Seeds <see cref="Influence"/> entities representing directional
        /// chains of intellectual, creative, and spiritual influence
        /// across historical figures and their profile roles.
        /// <para>
        /// Influence chains illustrate how ideas propagate and transform
        /// across disciplines and centuries — from ancient philosophy
        /// through the Scientific Revolution, the printing revolution,
        /// the Renaissance, musical inheritance, and technological
        /// catalysis.
        /// </para>
        /// </summary>
        private static void SeedInfluences(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Influence>().HasData(

                // ----------------------------------------------------------
                //  The Great Chain of Scientific Method
                // ----------------------------------------------------------

                // 1. Aristotle → Ptolemy (logic → astronomy)
                new Influence
                {
                    Id = _influenceAristotleToPtolemy,
                    InfluencerProfileId = _discovererAristotle,
                    InfluencerProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Discoverer),
                    InfluencedProfileId = _discovererPtolemy,
                    InfluencedProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Discoverer),
                    Description = "Aristotle's cosmological and logical framework provided the philosophical scaffolding for Ptolemy's geocentric astronomical model.",
                    InfluenceTypeId = DeterministicGuid.FromEnum(InfluenceType.Intellectual),
                    InfluenceStrengthId = DeterministicGuid.FromEnum(InfluenceStrength.Major)
                },

                // 2. Aristotle → Aquinas (philosophy → theology)
                new Influence
                {
                    Id = _influenceAristotleToAquinas,
                    InfluencerProfileId = _believerAristotle,
                    InfluencerProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Believer),
                    InfluencedProfileId = _believerAquinas,
                    InfluencedProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Believer),
                    Description = "Aristotle's metaphysics and ethics were the intellectual bedrock on which Aquinas constructed the Summa Theologica.",
                    InfluenceTypeId = DeterministicGuid.FromEnum(InfluenceType.Intellectual),
                    InfluenceStrengthId = DeterministicGuid.FromEnum(InfluenceStrength.Transformative)
                },

                // 3. Plato → Aristotle (philosophy → philosophy)
                new Influence
                {
                    Id = _influencePlatoToAristotle,
                    InfluencerProfileId = _believerPlato,
                    InfluencerProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Believer),
                    InfluencedProfileId = _believerAristotle,
                    InfluencedProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Believer),
                    Description = "Plato's Academy shaped Aristotle's formative intellectual development; Aristotle's philosophy arose partly in critical dialogue with Plato's theory of Forms.",
                    InfluenceTypeId = DeterministicGuid.FromEnum(InfluenceType.Direct),
                    InfluenceStrengthId = DeterministicGuid.FromEnum(InfluenceStrength.Transformative)
                },

                // 4. Copernicus → Galileo (heliocentrism → telescopic proof)
                new Influence
                {
                    Id = _influenceCopernicusToGalileo,
                    InfluencerProfileId = _discovererCopernicus,
                    InfluencerProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Discoverer),
                    InfluencedProfileId = _discovererGalileo,
                    InfluencedProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Discoverer),
                    Description = "Copernicus's heliocentric model motivated Galileo's telescopic observations that provided the first empirical confirmation.",
                    InfluenceTypeId = DeterministicGuid.FromEnum(InfluenceType.Direct),
                    InfluenceStrengthId = DeterministicGuid.FromEnum(InfluenceStrength.Transformative)
                },

                // 5. Galileo → Newton (experimental method → laws of motion)
                new Influence
                {
                    Id = _influenceGalileoToNewton,
                    InfluencerProfileId = _discovererGalileo,
                    InfluencerProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Discoverer),
                    InfluencedProfileId = _discovererNewton,
                    InfluencedProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Discoverer),
                    Description = "Galileo's kinematics and experimental methodology laid the groundwork on which Newton built his three laws of motion.",
                    InfluenceTypeId = DeterministicGuid.FromEnum(InfluenceType.Direct),
                    InfluenceStrengthId = DeterministicGuid.FromEnum(InfluenceStrength.Major)
                },

                // 6. Newton → Darwin (systematic observation → natural philosophy)
                new Influence
                {
                    Id = _influenceNewtonToDarwin,
                    InfluencerProfileId = _discovererNewton,
                    InfluencerProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Discoverer),
                    InfluencedProfileId = _discovererDarwin,
                    InfluencedProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Discoverer),
                    Description = "Newton's example of explaining natural phenomena through universal laws inspired Darwin's ambition to find a comparable law for biology.",
                    InfluenceTypeId = DeterministicGuid.FromEnum(InfluenceType.Indirect),
                    InfluenceStrengthId = DeterministicGuid.FromEnum(InfluenceStrength.Moderate)
                },

                // ----------------------------------------------------------
                //  The Printing Revolution Chain
                // ----------------------------------------------------------

                // 7. Gutenberg → Luther (printing press → mass distribution of 95 Theses)
                new Influence
                {
                    Id = _influenceGutenbergToLuther,
                    InfluencerProfileId = _creatorGutenberg,
                    InfluencerProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Creator),
                    InfluencedProfileId = _believerLuther,
                    InfluencedProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Believer),
                    Description = "Gutenberg's printing press enabled the rapid mass reproduction of Luther's 95 Theses, amplifying the Reformation across Europe.",
                    InfluenceTypeId = DeterministicGuid.FromEnum(InfluenceType.Indirect),
                    InfluenceStrengthId = DeterministicGuid.FromEnum(InfluenceStrength.Transformative)
                },

                // 8. Gutenberg → Shakespeare (printing → mass literacy → theatre audiences)
                new Influence
                {
                    Id = _influenceGutenbergToShakespeare,
                    InfluencerProfileId = _creatorGutenberg,
                    InfluencerProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Creator),
                    InfluencedProfileId = _creatorShakespeare,
                    InfluencedProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Creator),
                    Description = "The print revolution expanded literacy and created the reading public that sustained Elizabethan theatre and Shakespeare's audience.",
                    InfluenceTypeId = DeterministicGuid.FromEnum(InfluenceType.Indirect),
                    InfluenceStrengthId = DeterministicGuid.FromEnum(InfluenceStrength.Major)
                },

                // 9. Gutenberg → Copernicus (printing → dissemination of De Revolutionibus)
                new Influence
                {
                    Id = _influenceGutenbergToCopernicus,
                    InfluencerProfileId = _creatorGutenberg,
                    InfluencerProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Creator),
                    InfluencedProfileId = _discovererCopernicus,
                    InfluencedProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Discoverer),
                    Description = "Gutenberg's press enabled the wide dissemination of De Revolutionibus, ensuring Copernicus's heliocentric theory reached scholars across Europe.",
                    InfluenceTypeId = DeterministicGuid.FromEnum(InfluenceType.Indirect),
                    InfluenceStrengthId = DeterministicGuid.FromEnum(InfluenceStrength.Major)
                },

                // ----------------------------------------------------------
                //  The Renaissance Chain
                // ----------------------------------------------------------

                // 10. Leonardo → Galileo (empirical observation → scientific method)
                new Influence
                {
                    Id = _influenceLeonardoToGalileo,
                    InfluencerProfileId = _discovererLeonardo,
                    InfluencerProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Discoverer),
                    InfluencedProfileId = _discovererGalileo,
                    InfluencedProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Discoverer),
                    Description = "Leonardo's insistence on empirical observation and systematic experimentation foreshadowed and influenced Galileo's scientific method.",
                    InfluenceTypeId = DeterministicGuid.FromEnum(InfluenceType.Direct),
                    InfluenceStrengthId = DeterministicGuid.FromEnum(InfluenceStrength.Major)
                },

                // 11. Leonardo → Michelangelo (anatomical study → artistic form)
                new Influence
                {
                    Id = _influenceLeonardoToMichelangelo,
                    InfluencerProfileId = _creatorLeonardo,
                    InfluencerProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Creator),
                    InfluencedProfileId = _creatorMichelangelo,
                    InfluencedProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Creator),
                    Description = "Leonardo's anatomical studies and mastery of human proportion influenced Michelangelo's sculptural and painted depiction of the human form.",
                    InfluenceTypeId = DeterministicGuid.FromEnum(InfluenceType.Indirect),
                    InfluenceStrengthId = DeterministicGuid.FromEnum(InfluenceStrength.Moderate)
                },

                // ----------------------------------------------------------
                //  The Music Chain
                // ----------------------------------------------------------

                // 12. Bach → Mozart (counterpoint mastery → classical synthesis)
                new Influence
                {
                    Id = _influenceBachToMozart,
                    InfluencerProfileId = _creatorBach,
                    InfluencerProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Creator),
                    InfluencedProfileId = _creatorMozart,
                    InfluencedProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Creator),
                    Description = "Bach's contrapuntal mastery deeply influenced Mozart's later works, particularly his integration of fugal techniques into the Classical style.",
                    InfluenceTypeId = DeterministicGuid.FromEnum(InfluenceType.Direct),
                    InfluenceStrengthId = DeterministicGuid.FromEnum(InfluenceStrength.Major)
                },

                // ----------------------------------------------------------
                //  The Technology Revolution Chain
                // ----------------------------------------------------------

                // 13. Watt → Darwin (steam engine → global shipping → Voyage of the Beagle)
                new Influence
                {
                    Id = _influenceWattToDarwin,
                    InfluencerProfileId = _discovererWatt,
                    InfluencerProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Discoverer),
                    InfluencedProfileId = _discovererDarwin,
                    InfluencedProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Discoverer),
                    Description = "Watt's steam engine powered the global shipping networks that enabled Darwin's Voyage of the Beagle and his collection of worldwide specimens.",
                    InfluenceTypeId = DeterministicGuid.FromEnum(InfluenceType.Indirect),
                    InfluenceStrengthId = DeterministicGuid.FromEnum(InfluenceStrength.Major)
                },

                // 14. Leeuwenhoek → Curie (microscopy → scientific instruments → radiation study)
                new Influence
                {
                    Id = _influenceLeeuwenhoekToCurie,
                    InfluencerProfileId = _discovererLeeuwenhoek,
                    InfluencerProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Discoverer),
                    InfluencedProfileId = _discovererCurie,
                    InfluencedProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Discoverer),
                    Description = "Leeuwenhoek's pioneering use of precision instruments to reveal invisible phenomena established the tradition of instrument-driven discovery that Curie continued.",
                    InfluenceTypeId = DeterministicGuid.FromEnum(InfluenceType.Indirect),
                    InfluenceStrengthId = DeterministicGuid.FromEnum(InfluenceStrength.Moderate)
                },

                // ----------------------------------------------------------
                //  The Philosophy Chain
                // ----------------------------------------------------------

                // 15. Confucius → Buddha (Eastern wisdom traditions, parallel development)
                new Influence
                {
                    Id = _influenceConfuciusToBuddha,
                    InfluencerProfileId = _believerConfucius,
                    InfluencerProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Believer),
                    InfluencedProfileId = _believerBuddha,
                    InfluencedProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Believer),
                    Description = "Confucius and Buddha developed parallel Eastern wisdom traditions; their shared cultural milieu fostered complementary ethical frameworks.",
                    InfluenceTypeId = DeterministicGuid.FromEnum(InfluenceType.Indirect),
                    InfluenceStrengthId = DeterministicGuid.FromEnum(InfluenceStrength.Minor)
                },

                // 16. Aristotle → Maimonides (Greek philosophy → Jewish philosophy)
                new Influence
                {
                    Id = _influenceAristotleToMaimonides,
                    InfluencerProfileId = _believerAristotle,
                    InfluencerProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Believer),
                    InfluencedProfileId = _believerMaimonides,
                    InfluencedProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Believer),
                    Description = "Aristotle's rational philosophy was the primary intellectual source for Maimonides's Guide for the Perplexed.",
                    InfluenceTypeId = DeterministicGuid.FromEnum(InfluenceType.Intellectual),
                    InfluenceStrengthId = DeterministicGuid.FromEnum(InfluenceStrength.Major)
                },

                // 17. Maimonides → Aquinas (Jewish philosophy → Christian philosophy)
                new Influence
                {
                    Id = _influenceMaimonidesToAquinas,
                    InfluencerProfileId = _believerMaimonides,
                    InfluencerProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Believer),
                    InfluencedProfileId = _believerAquinas,
                    InfluencedProfileTypeId = DeterministicGuid.FromEnum(ProfileType.Believer),
                    Description = "Maimonides's synthesis of Aristotelian philosophy with monotheistic theology directly informed Aquinas's own scholastic project.",
                    InfluenceTypeId = DeterministicGuid.FromEnum(InfluenceType.Intellectual),
                    InfluenceStrengthId = DeterministicGuid.FromEnum(InfluenceStrength.Major)
                }
            );
        }
    }
}
