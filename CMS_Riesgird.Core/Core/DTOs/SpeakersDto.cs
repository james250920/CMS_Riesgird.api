namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateSpeakerDto
{
    public Guid CongressId { get; set; }
    public string FullName { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Institution { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string? PhotoUrl { get; set; }
    public string? Biography { get; set; }
    public string? PresentationTitle { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateSpeakerDto
{
    public Guid Id { get; set; }
    public Guid CongressId { get; set; }
    public string FullName { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Institution { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string? PhotoUrl { get; set; }
    public string? Biography { get; set; }
    public string? PresentationTitle { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class SpeakerResponseDto
{
    public Guid Id { get; set; }
    public Guid CongressId { get; set; }
    public string FullName { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Institution { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string? PhotoUrl { get; set; }
    public string? Biography { get; set; }
    public string? PresentationTitle { get; set; }
}
