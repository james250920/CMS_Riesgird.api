namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateAgreementDto
{
    public Guid AssemblyId { get; set; }
    public string Number { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? Responsible { get; set; }
    public DateOnly? DueDate { get; set; }
    public bool IsPublic { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateAgreementDto
{
    public Guid Id { get; set; }
    public Guid AssemblyId { get; set; }
    public string Number { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? Responsible { get; set; }
    public DateOnly? DueDate { get; set; }
    public bool IsPublic { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class AgreementResponseDto
{
    public Guid Id { get; set; }
    public Guid AssemblyId { get; set; }
    public string Number { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? Responsible { get; set; }
    public DateOnly? DueDate { get; set; }
    public bool IsPublic { get; set; }
}
