namespace App.Modules.Demos.Application.Domains.Examples.Structures.InTransit.Dtos
{
    /// <summary>Read-side ExampleB contract returned by REST collection and item queries.</summary>
    /// <remarks>The creation timestamp is infrastructure-managed and therefore absent from ExampleBWriteDto.</remarks>
    public class ExampleBReadDto : ExampleBWriteDto
    {
        /// <summary>Gets or sets the infrastructure creation timestamp.</summary>
        public DateTime CreatedUtc { get; set; }
    }
}