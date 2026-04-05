namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateForumEventDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Location { get; set; }
    public string? BannerUrl { get; set; }
    public List<string>? Organizers { get; set; }
    public string? TargetAudience { get; set; }
    public int? Capacity { get; set; }
    public int? RegisteredCount { get; set; }
    public bool? RequiresRegistration { get; set; }
    public string? VirtualLink { get; set; }
    public string? ProgramFileUrl { get; set; }
    public string? RegistrationUrl { get; set; }
    public int? MaxParticipants { get; set; }
    public int? CurrentParticipants { get; set; }
    public bool IsPublic { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateForumEventDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Location { get; set; }
    public string? BannerUrl { get; set; }
    public List<string>? Organizers { get; set; }
    public string? TargetAudience { get; set; }
    public int? Capacity { get; set; }
    public int? RegisteredCount { get; set; }
    public bool? RequiresRegistration { get; set; }
    public string? VirtualLink { get; set; }
    public string? ProgramFileUrl { get; set; }
    public string? RegistrationUrl { get; set; }
    public int? MaxParticipants { get; set; }
    public int? CurrentParticipants { get; set; }
    public bool IsPublic { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class ForumEventResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Location { get; set; }
    public string? BannerUrl { get; set; }
    public List<string>? Organizers { get; set; }
    public string? TargetAudience { get; set; }
    public int? Capacity { get; set; }
    public int? RegisteredCount { get; set; }
    public bool? RequiresRegistration { get; set; }
    public string? VirtualLink { get; set; }
    public string? ProgramFileUrl { get; set; }
    public string? RegistrationUrl { get; set; }
    public int? MaxParticipants { get; set; }
    public int? CurrentParticipants { get; set; }
    public bool IsPublic { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
