namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateThematicAxisDto
{
    public Guid CongressId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? Coordinator { get; set; }
    public int SortOrder { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateThematicAxisDto
{
    public Guid Id { get; set; }
    public Guid CongressId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? Coordinator { get; set; }
    public int SortOrder { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class ThematicAxisResponseDto
{
    public Guid Id { get; set; }
    public Guid CongressId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? Coordinator { get; set; }
    public int SortOrder { get; set; }
}
