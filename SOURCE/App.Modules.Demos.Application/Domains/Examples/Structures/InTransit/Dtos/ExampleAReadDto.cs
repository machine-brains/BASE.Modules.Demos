namespace App.Modules.Demos.Application.Domains.Examples.Structures.InTransit.Dtos
{
    /// <summary>Read-side ExampleA contract returned by REST collection and item queries.</summary>
    /// <remarks>The split keeps transport output distinct from create/update input while preserving Spike's title and description.</remarks>
    public class ExampleAReadDto : ExampleAWriteDto
    {
    }
}