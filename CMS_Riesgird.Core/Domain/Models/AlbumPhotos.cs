using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Fotos individuales dentro de cada álbum
/// </summary>
public partial class AlbumPhotos
{
    public Guid Id { get; set; }

    public Guid AlbumId { get; set; }

    public string Url { get; set; } = null!;

    public string? ThumbnailUrl { get; set; }

    public string? Caption { get; set; }

    public string? Photographer { get; set; }

    public DateTime? TakenAt { get; set; }

    public int SortOrder { get; set; }

    public bool IsCover { get; set; }

    public bool IsPublic { get; set; }

    public virtual PhotoAlbums Album { get; set; } = null!;
}
