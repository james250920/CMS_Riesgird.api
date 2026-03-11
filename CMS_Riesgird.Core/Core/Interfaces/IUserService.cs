using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces
{
    public interface IUserService
    {
        Task DeleteUser(Guid id);
        Task<IEnumerable<UserResponseDto>> GetAllUsers();
        Task<UserResponseDto> GetUserById(Guid id);
        Task<UserLoginResponseDto> Login(LoginDto dto);
        Task<Guid> Register(RegisterUserDto dto);
        Task UpdateUser(Guid id, UpdateUserDto dto);
    }
}