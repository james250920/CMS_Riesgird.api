using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Core.Core.Security;
using CMS_Riesgird.Core.Core.Services;
using CMS_Riesgird.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Riesgird.Core.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTService _jwtService;

        public UserService(IUserRepository userRepository, IJWTService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<Guid> Register(RegisterUserDto dto)
        {
            var exist = await _userRepository.GetByEmail(dto.Email);
            if (exist != null)
                throw new Exception("El email ya existe");

            var user = new Users
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                PasswordHash = PasswordHasher.Hash(dto.PasswordHash),
                FullName = dto.FullName,
                PhotoUrl = dto.PhotoUrl,
                Phone = dto.Phone,
                RoleId = dto.RoleId,
                UniversityId = dto.UniversityId,
                Position = dto.Position,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.UtcNow

            };
            return await _userRepository.AddUserAsync(user);
        }

        public async Task<UserLoginResponseDto> Login(LoginDto dto)
        {
            var user = await _userRepository.GetByEmail(dto.Email);

            if (user == null)
                return null;

            bool isPasswordValid = PasswordHasher.Verify(dto.PasswordHash, user.PasswordHash);

            if (!isPasswordValid)
                return null;

            user.LastLogin = DateTime.UtcNow;
            await _userRepository.Update(user);

            var token = _jwtService.GenerateJWToken(user);
            return new UserLoginResponseDto
            {
                User = new UserResponseDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    PhotoUrl = user.PhotoUrl,
                    Phone = user.Phone,
                    RoleId = user.RoleId,
                    UniversityId = user.UniversityId,
                    Position = user.Position,
                    IsActive = user.IsActive
                },
                Token = token
            };
        }
        public async Task<IEnumerable<UserResponseDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return users.Select(u => new UserResponseDto
            {
                Id = u.Id,
                Email = u.Email,
                FullName = u.FullName,
                PhotoUrl = u.PhotoUrl,
                Phone = u.Phone,
                RoleId = u.RoleId,
                UniversityId = u.UniversityId,
                Position = u.Position,
                IsActive = u.IsActive
            });
        }
        public async Task<UserResponseDto> GetUserById(Guid id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
                return null;
            return new UserResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                PhotoUrl = user.PhotoUrl,
                Phone = user.Phone,
                RoleId = user.RoleId,
                UniversityId = user.UniversityId,
                Position = user.Position,
                IsActive = user.IsActive
            };
        }
        public async Task UpdateUser(Guid id, UpdateUserDto dto)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
                throw new Exception("Usuario no encontrado");
            user.FullName = dto.FullName ?? user.FullName;
            user.PhotoUrl = dto.PhotoUrl ?? user.PhotoUrl;
            user.Phone = dto.Phone ?? user.Phone;
            user.RoleId = dto.RoleId;
            user.UniversityId = dto.UniversityId ?? user.UniversityId;
            user.Position = dto.Position ?? user.Position;
            user.IsActive = dto.IsActive;
            user.UpdatedAt = DateTime.UtcNow;
            await _userRepository.Update(user);
        }
        public async Task DeleteUser(Guid id)
        {
            await _userRepository.Delete(id);
        }
    }
}
