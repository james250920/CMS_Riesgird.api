namespace CMS_Riesgird.Core.Core.DTOs;

public class CreatePublicationDto
{
    public Guid ResearcherId { get; set; }
    public string Title { get; set; } = null!;
    public List<string> Authors { get; set; } = null!;
    public int Year { get; set; }
    public string? Journal { get; set; }
    public string? Volume { get; set; }
    public string? Pages { get; set; }
    public string? Doi { get; set; }
    public string? Url { get; set; }
    public string? FileUrl { get; set; }
    public string? Abstract { get; set; }
    public List<string> Keywords { get; set; } = null!;
    public bool IsPublic { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdatePublicationDto
{
    public Guid Id { get; set; }
    public Guid ResearcherId { get; set; }
    public string Title { get; set; } = null!;
    public List<string> Authors { get; set; } = null!;
    public int Year { get; set; }
    public string? Journal { get; set; }
    public string? Volume { get; set; }
    public string? Pages { get; set; }
    public string? Doi { get; set; }
    public string? Url { get; set; }
    public string? FileUrl { get; set; }
    public string? Abstract { get; set; }
    public List<string> Keywords { get; set; } = null!;
    public bool IsPublic { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class PublicationResponseDto
{
    public Guid Id { get; set; }
    public Guid ResearcherId { get; set; }
    public string Title { get; set; } = null!;
    public List<string> Authors { get; set; } = null!;
    public int Year { get; set; }
    public string? Journal { get; set; }
    public string? Volume { get; set; }
    public string? Pages { get; set; }
    public string? Doi { get; set; }
    public string? Url { get; set; }
    public string? FileUrl { get; set; }
    public string? Abstract { get; set; }
    public List<string> Keywords { get; set; } = null!;
    public bool IsPublic { get; set; }
    public DateTime CreatedAt { get; set; }
}
