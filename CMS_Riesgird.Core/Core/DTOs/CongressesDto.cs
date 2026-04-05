namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateCongressDto
{
    public int Edition { get; set; }
    public string? RomanNumber { get; set; }
    public string Name { get; set; } = null!;
    public int Year { get; set; }
    public string? Theme { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string Location { get; set; } = null!;
    public string? Venue { get; set; }
    public string? HostUniversity { get; set; }
    public string Description { get; set; } = null!;
    public List<string>? Objectives { get; set; }
    public int? ParticipantsCount { get; set; }
    public int? PresentationsCount { get; set; }
    public int? SpeakersCount { get; set; }
    public string? BannerUrl { get; set; }
    public string? ProceedingsFileUrl { get; set; }
    public string? AbstractsBookFileUrl { get; set; }
    public string? ProgramFileUrl { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? RegistrationUrl { get; set; }
    public string? PhotosAlbumUrl { get; set; }
    public string? VideosPlaylistUrl { get; set; }
    public bool IsPublic { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateCongressDto
{
    public Guid Id { get; set; }
    public int Edition { get; set; }
    public string? RomanNumber { get; set; }
    public string Name { get; set; } = null!;
    public int Year { get; set; }
    public string? Theme { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string Location { get; set; } = null!;
    public string? Venue { get; set; }
    public string? HostUniversity { get; set; }
    public string Description { get; set; } = null!;
    public List<string>? Objectives { get; set; }
    public int? ParticipantsCount { get; set; }
    public int? PresentationsCount { get; set; }
    public int? SpeakersCount { get; set; }
    public string? BannerUrl { get; set; }
    public string? ProceedingsFileUrl { get; set; }
    public string? AbstractsBookFileUrl { get; set; }
    public string? ProgramFileUrl { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? RegistrationUrl { get; set; }
    public string? PhotosAlbumUrl { get; set; }
    public string? VideosPlaylistUrl { get; set; }
    public bool IsPublic { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class CongressResponseDto
{
    public Guid Id { get; set; }
    public int Edition { get; set; }
    public string? RomanNumber { get; set; }
    public string Name { get; set; } = null!;
    public int Year { get; set; }
    public string? Theme { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string Location { get; set; } = null!;
    public string? Venue { get; set; }
    public string? HostUniversity { get; set; }
    public string Description { get; set; } = null!;
    public List<string>? Objectives { get; set; }
    public int? ParticipantsCount { get; set; }
    public int? PresentationsCount { get; set; }
    public int? SpeakersCount { get; set; }
    public string? BannerUrl { get; set; }
    public string? ProceedingsFileUrl { get; set; }
    public string? AbstractsBookFileUrl { get; set; }
    public string? ProgramFileUrl { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? RegistrationUrl { get; set; }
    public string? PhotosAlbumUrl { get; set; }
    public string? VideosPlaylistUrl { get; set; }
    public bool IsPublic { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
