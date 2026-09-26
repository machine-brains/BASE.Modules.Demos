using System;
using System.Collections.Generic;

namespace App.Modules.Demos.Infrastructure.Domains.Media.Licenses
{
	/// <summary>
	/// Single source of truth for Demos profile portrait source metadata.
	/// </summary>
	/// <remarks>
	/// The portrait media seeder and <see cref="DemosProfilePortraitCopyrightAcknowledgement"/>
	/// consume the same entries so a downloaded asset cannot silently lose its legal source
	/// page. This catalogue owns source metadata only; object storage and profile foreign
	/// keys remain owned by the seeder.
	/// </remarks>
	public static class DemosPortraitCatalog
	{
		/// <summary>Source metadata for one Demos profile portrait.</summary>
		public sealed record PortraitDefinition(string AssetKey, string SourceUrl, string AttributionUrl);

		/// <summary>Portrait source metadata keyed by the seeded profile title.</summary>
		public static IReadOnlyDictionary<string, PortraitDefinition> Entries { get; } =
			new Dictionary<string, PortraitDefinition>(StringComparer.OrdinalIgnoreCase)
			{
				["Christopher Columbus"] = new("christopher-columbus", "https://upload.wikimedia.org/wikipedia/commons/c/c2/Portrait_of_a_Man%2C_Said_to_be_Christopher_Columbus.jpg", "https://commons.wikimedia.org/wiki/File:Portrait_of_a_Man,_Said_to_be_Christopher_Columbus.jpg"),
				["Nicolaus Copernicus"] = new("nicolaus-copernicus", "https://upload.wikimedia.org/wikipedia/commons/e/e2/Nikolaus_Kopernikus_MOT.jpg", "https://commons.wikimedia.org/wiki/File:Nikolaus_Kopernikus_MOT.jpg"),
				["Galileo Galilei"] = new("galileo-galilei", "https://upload.wikimedia.org/wikipedia/commons/f/fc/Galileo_Galilei_%281564-1642%29_RMG_BHC2700.tiff", "https://commons.wikimedia.org/wiki/File:Galileo_Galilei_(1564-1642)_RMG_BHC2700.tiff"),
				["Isaac Newton"] = new("isaac-newton", "https://upload.wikimedia.org/wikipedia/commons/f/f7/Portrait_of_Sir_Isaac_Newton%2C_1689_%28brightened%29.jpg", "https://commons.wikimedia.org/wiki/File:Portrait_of_Sir_Isaac_Newton,_1689_(brightened).jpg"),
				["Charles Darwin"] = new("charles-darwin", "https://upload.wikimedia.org/wikipedia/commons/2/2e/Charles_Darwin_seated_crop.jpg", "https://commons.wikimedia.org/wiki/File:Charles_Darwin_seated_crop.jpg"),
				["Leonardo da Vinci"] = new("leonardo-da-vinci", "https://upload.wikimedia.org/wikipedia/commons/1/16/Francesco_Melzi_-_Portrait_of_Leonardo_%28colour_correction%29.png", "https://commons.wikimedia.org/wiki/File:Francesco_Melzi_-_Portrait_of_Leonardo_(colour_correction).png"),
				["Aristotle"] = new("aristotle", "https://upload.wikimedia.org/wikipedia/commons/a/ae/Aristotle_Altemps_Inv8575.jpg", "https://commons.wikimedia.org/wiki/File:Aristotle_Altemps_Inv8575.jpg"),
				["Antonie van Leeuwenhoek"] = new("antonie-van-leeuwenhoek", "https://upload.wikimedia.org/wikipedia/commons/1/1f/Anthonie_van_Leeuwenhoek_%281632-1723%29._Natuurkundige_te_Delft_Rijksmuseum_SK-A-957.jpeg", "https://commons.wikimedia.org/wiki/File:Anthonie_van_Leeuwenhoek_(1632-1723)._Natuurkundige_te_Delft_Rijksmuseum_SK-A-957.jpeg"),
				["Marie Curie"] = new("marie-curie", "https://upload.wikimedia.org/wikipedia/commons/c/c8/Marie_Curie_c._1920s.jpg", "https://commons.wikimedia.org/wiki/File:Marie_Curie_c._1920s.jpg"),
				["James Watt"] = new("james-watt", "https://upload.wikimedia.org/wikipedia/commons/1/15/Watt_James_von_Breda.jpg", "https://commons.wikimedia.org/wiki/File:Watt_James_von_Breda.jpg"),
				["Claudius Ptolemy"] = new("ptolemy", "https://upload.wikimedia.org/wikipedia/commons/c/c9/Ptolemy_1476_with_armillary_sphere_model.jpg", "https://commons.wikimedia.org/wiki/File:Ptolemy_1476_with_armillary_sphere_model.jpg"),
				["William Shakespeare"] = new("william-shakespeare", "https://upload.wikimedia.org/wikipedia/commons/2/21/William_Shakespeare_by_John_Taylor%2C_edited.jpg", "https://commons.wikimedia.org/wiki/File:William_Shakespeare_by_John_Taylor,_edited.jpg"),
				["Michelangelo Buonarroti"] = new("michelangelo", "https://upload.wikimedia.org/wikipedia/commons/0/02/Michelangelo_Daniele_da_Volterra_%28dettaglio%29.jpg", "https://commons.wikimedia.org/wiki/File:Michelangelo_Daniele_da_Volterra_(dettaglio).jpg"),
				["Johann Sebastian Bach"] = new("johann-sebastian-bach", "https://upload.wikimedia.org/wikipedia/commons/6/6a/Johann_Sebastian_Bach.jpg", "https://commons.wikimedia.org/wiki/File:Johann_Sebastian_Bach.jpg"),
				["Johannes Gutenberg"] = new("johannes-gutenberg", "https://upload.wikimedia.org/wikipedia/commons/5/5b/Mainz_Gutenbergdenkmal_2016_%28cropped%29.jpg", "https://commons.wikimedia.org/wiki/File:Mainz_Gutenbergdenkmal_2016_(cropped).jpg"),
				["Wolfgang Amadeus Mozart"] = new("wolfgang-amadeus-mozart", "https://upload.wikimedia.org/wikipedia/commons/a/ad/The_Mozart_Family_-_Wolfgang_Amadeus_Mozart_headshot.jpg", "https://commons.wikimedia.org/wiki/File:The_Mozart_Family_-_Wolfgang_Amadeus_Mozart_headshot.jpg"),
				["Thomas Aquinas"] = new("thomas-aquinas", "https://upload.wikimedia.org/wikipedia/commons/0/0a/St-thomas-aquinasFXD.jpg", "https://commons.wikimedia.org/wiki/File:St-thomas-aquinasFXD.jpg"),
				["Martin Luther"] = new("martin-luther", "https://upload.wikimedia.org/wikipedia/commons/9/90/Lucas_Cranach_d.%C3%84._-_Martin_Luther%2C_1528_%28Veste_Coburg%29.jpg", "https://commons.wikimedia.org/wiki/File:Lucas_Cranach_d.%C3%84._-_Martin_Luther,_1528_(Veste_Coburg).jpg"),
				["Confucius"] = new("confucius", "https://upload.wikimedia.org/wikipedia/commons/d/d5/Confucius%2C_fresco_from_a_Western_Han_tomb_of_Dongping_County%2C_Shandong_province%2C_China.jpg", "https://commons.wikimedia.org/wiki/File:Confucius,_fresco_from_a_Western_Han_tomb_of_Dongping_County,_Shandong_province,_China.jpg"),
				["Siddhartha Gautama (Buddha)"] = new("gautama-buddha", "https://upload.wikimedia.org/wikipedia/commons/f/ff/Buddha_in_Sarnath_Museum_%28Dhammajak_Mutra%29.jpg", "https://commons.wikimedia.org/wiki/File:Buddha_in_Sarnath_Museum_(Dhammajak_Mutra).jpg"),
				["Moses Maimonides"] = new("moses-maimonides", "https://upload.wikimedia.org/wikipedia/commons/3/38/Portrait_of_Moses_Maimonides_in_Thesaurus_antiquitatum_sacrarum.tif", "https://commons.wikimedia.org/wiki/File:Portrait_of_Moses_Maimonides_in_Thesaurus_antiquitatum_sacrarum.tif"),
				["Plato"] = new("plato", "https://upload.wikimedia.org/wikipedia/commons/2/21/Plato_Silanion_Musei_Capitolini_MC1377.png", "https://commons.wikimedia.org/wiki/File:Plato_Silanion_Musei_Capitolini_MC1377.png"),
			};
	}
}