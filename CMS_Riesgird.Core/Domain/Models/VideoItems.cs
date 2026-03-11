using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Videos asociados a congresos y álbumes multimedia
/// </summary>
public partial class VideoItems
{
    public Guid Id { get; set; }

    public Guid? CongressId { get; set; }

    public Guid? AlbumId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Url { get; set; } = null!;

    public string? ThumbnailUrl { get; set; }

    public int? Duration { get; set; }

    public int SortOrder { get; set; }

    public virtual PhotoAlbums? Album { get; set; }

    public virtual Congresses? Congress { get; set; }
}
