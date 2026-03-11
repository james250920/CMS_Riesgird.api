namespace CMS_Riesgird.Core.Core.DTOs;

/// <summary>
/// DTOs para el CRUD de Roles del sistema
/// </summary>
public class CreateRoleDto
{
    public string Name { get; set; } = null!;
    public int Level { get; set; }
    public string? Color { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}

public class UpdateRoleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int Level { get; set; }
    public string? Color { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}

public class RoleResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int Level { get; set; }
    public string? Color { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
