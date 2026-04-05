namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateAgendaItemDto
{
    public Guid AssemblyId { get; set; }
    public int SortOrder { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? Presenter { get; set; }
    public int? Duration { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateAgendaItemDto
{
    public Guid Id { get; set; }
    public Guid AssemblyId { get; set; }
    public int SortOrder { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? Presenter { get; set; }
    public int? Duration { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class AgendaItemResponseDto
{
    public Guid Id { get; set; }
    public Guid AssemblyId { get; set; }
    public int SortOrder { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? Presenter { get; set; }
    public int? Duration { get; set; }
}
