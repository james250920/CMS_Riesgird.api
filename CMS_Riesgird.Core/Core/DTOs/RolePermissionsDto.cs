namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateRolePermissionDto
{
    public Guid RoleId { get; set; }
    public string? ModuleName { get; set; }
    public string? ActionName { get; set; }
    public bool IsAllowed { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateRolePermissionDto
{
    public Guid Id { get; set; }
    public Guid RoleId { get; set; }
    public bool IsAllowed { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class RolePermissionResponseDto
{
    public Guid Id { get; set; }
    public Guid RoleId { get; set; }
    public string? ModuleName { get; set; }
    public string? ActionName { get; set; }
    public bool IsAllowed { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class PermissionCheckDto
{
    public Guid RoleId { get; set; }
    public string ModuleName { get; set; } = null!;
    public string ActionName { get; set; } = null!;
}
