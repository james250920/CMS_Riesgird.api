namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateUserPermissionDto
{
    public Guid UserId { get; set; }
    public string? ModuleName { get; set; }
    public string? ActionName { get; set; }
    public bool IsAllowed { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateUserPermissionDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public bool IsAllowed { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class UserPermissionResponseDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? ModuleName { get; set; }
    public string? ActionName { get; set; }
    public bool IsAllowed { get; set; }
    public DateTime CreatedAt { get; set; }
}
