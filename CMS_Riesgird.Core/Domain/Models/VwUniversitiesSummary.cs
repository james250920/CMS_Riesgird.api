using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

public partial class VwUniversitiesSummary
{
    public Guid? Id { get; set; }

    public string? Name { get; set; }

    public string? ShortName { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public DateOnly? MembershipDate { get; set; }

    public bool? IsActive { get; set; }

    public long? CurrentAuthoritiesCount { get; set; }

    public long? ActiveTeamMembersCount { get; set; }

    public long? ActiveResearchersCount { get; set; }

    public long? ActiveBrigadesCount { get; set; }

    public long? ReportsCount { get; set; }
}
