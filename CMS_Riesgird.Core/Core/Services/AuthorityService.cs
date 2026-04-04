using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services
{
    public class AuthorityService : IAuthorityService
    {
        private readonly IAuthorityRepository _authorityRepository;

        public AuthorityService(IAuthorityRepository authorityRepository)
        {
            _authorityRepository = authorityRepository;
        }

        public async Task<IEnumerable<AuthorityResponseDto>> GetAllAuthorities()
        {
            var authorities = await _authorityRepository.GetAllAuthoritiesAsync();
            return authorities.Select(a => MapToResponseDto(a));
        }

        public async Task<IEnumerable<AuthorityResponseDto>> GetAuthoritiesByUniversityId(Guid universityId)
        {
            var authorities = await _authorityRepository.GetAuthoritiesByUniversityIdAsync(universityId);
            return authorities.Select(a => MapToResponseDto(a));
        }

        public async Task<AuthorityResponseDto?> GetAuthorityById(Guid id)
        {
            var authority = await _authorityRepository.GetAuthorityByIdAsync(id);
            if (authority == null)
                return null;

            return MapToResponseDto(authority);
        }

        public async Task<Guid> CreateAuthority(CreateAuthorityDto dto)
        {
            var authority = new Authorities
            {
                Id = Guid.NewGuid(),
                UniversityId = dto.UniversityId,
                FullName = dto.FullName,
                AcademicDegree = dto.AcademicDegree,
                Email = dto.Email,
                Phone = dto.Phone,
                Dni = dto.Dni,
                PhotoUrl = dto.PhotoUrl,
                Position = dto.Position,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsCurrent = dto.IsCurrent,
                IsActive = dto.IsActive,
                IsPublic = dto.IsPublic,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _authorityRepository.AddAuthorityAsync(authority);
            return authority.Id;
        }

        public async Task UpdateAuthority(Guid id, UpdateAuthorityDto dto)
        {
            var authority = await _authorityRepository.GetAuthorityByIdAsync(id);
            if (authority == null)
                throw new Exception("Autoridad no encontrada");

            authority.UniversityId = dto.UniversityId;
            authority.FullName = dto.FullName ?? authority.FullName;
            authority.AcademicDegree = dto.AcademicDegree ?? authority.AcademicDegree;
            authority.Email = dto.Email ?? authority.Email;
            authority.Phone = dto.Phone ?? authority.Phone;
            authority.Dni = dto.Dni ?? authority.Dni;
            authority.PhotoUrl = dto.PhotoUrl ?? authority.PhotoUrl;
            authority.Position = dto.Position ?? authority.Position;
            authority.StartDate = dto.StartDate;
            authority.EndDate = dto.EndDate;
            authority.IsCurrent = dto.IsCurrent;
            authority.IsActive = dto.IsActive;
            authority.IsPublic = dto.IsPublic;
            authority.UpdatedAt = DateTime.UtcNow;

            await _authorityRepository.UpdateAuthorityAsync(authority);
        }

        public async Task DeleteAuthority(Guid id)
        {
            await _authorityRepository.DeleteAuthorityAsync(id);
        }

        private AuthorityResponseDto MapToResponseDto(Authorities authority)
        {
            return new AuthorityResponseDto
            {
                Id = authority.Id,
                UniversityId = authority.UniversityId,
                FullName = authority.FullName,
                AcademicDegree = authority.AcademicDegree,
                Email = authority.Email,
                Phone = authority.Phone,
                Dni = authority.Dni,
                PhotoUrl = authority.PhotoUrl,
                Position = authority.Position,
                StartDate = authority.StartDate,
                EndDate = authority.EndDate,
                IsCurrent = authority.IsCurrent,
                IsActive = authority.IsActive,
                IsPublic = authority.IsPublic,
                CreatedAt = authority.CreatedAt,
                UpdatedAt = authority.UpdatedAt
            };
        }
    }
}
