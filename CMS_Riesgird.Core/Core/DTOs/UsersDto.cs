using CMS_Riesgird.Domain.Models;
using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Core.Core.DTOs;

/// <summary>
/// Usuarios del sistema con autenticación y perfiles
/// </summary>
public class UsersDto
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? PhotoUrl { get; set; }

    public string? Phone { get; set; }

    public Guid RoleId { get; set; }

    public Guid? UniversityId { get; set; }

    public string? Position { get; set; }

    public bool IsActive { get; set; }

    public DateTime? LastLogin { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    
}

public class RegisterUserDto
{
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string? PhotoUrl { get; set; }
    public string? Phone { get; set; }
    public Guid RoleId { get; set; }
    public Guid? UniversityId { get; set; }
    public string? Position { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }

}

public class LoginDto
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}

public class UpdateUserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string? PhotoUrl { get; set; }
    public string? Phone { get; set; }
    public Guid RoleId { get; set; }
    public Guid? UniversityId { get; set; }
    public string? Position { get; set; }
    public bool IsActive { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class UserResponseDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string? PhotoUrl { get; set; }
    public string? Phone { get; set; }
    public Guid RoleId { get; set; }
    public Guid? UniversityId { get; set; }
    public string? Position { get; set; }
    public bool IsActive { get; set; }
}

public class UserLoginResponseDto
{
    public UserResponseDto User { get; set; }
    public string Token { get; set; }
}
