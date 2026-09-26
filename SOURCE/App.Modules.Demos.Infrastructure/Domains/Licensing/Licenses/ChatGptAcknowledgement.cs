using App.Modules.Sys.Shared.Domains.Licencing;

namespace App.Modules.Demos.Infrastructure.Domains.Licensing.Licenses
{
	/// <summary>Acknowledgement for ChatGPT as a software-assisted thinking partner.</summary>
	public sealed class ChatGptAcknowledgement : IAcknowledgement
	{
		public bool Enabled { get; set; } = true;
		public string Name => "ChatGPT";
		public string Provider => "OpenAI";
		public string? Version => null;
		public string Use => "Software-assisted discussion, drafting, and technical reasoning.";
		public string AttributionText => "For providing a talented thinking partner when a suitable local partner was not available.";
		public Uri? SourceUri => new("https://chatgpt.com/");
		public Uri? LicenseUri => null;
	}
}