using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

public partial class VwDashboardStats
{
    public long? TotalUniversitiesActive { get; set; }

    public long? TotalMembers { get; set; }

    public long? TotalResearchers { get; set; }

    public long? TotalExperts { get; set; }

    public long? TotalPublications { get; set; }

    public long? ActivePrograms { get; set; }

    public long? TotalBrigades { get; set; }

    public long? PendingApplications { get; set; }

    public long? AssembliesThisYear { get; set; }

    public long? TotalCongresses { get; set; }

    public long? ActiveEvents { get; set; }

    public long? TotalAlbums { get; set; }
}
