using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository _universityRepository;

        public UniversityService(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        public async Task<IEnumerable<UniversityResponseDto>> GetAllUniversities()
        {
            var universities = await _universityRepository.GetAllUniversitiesAsync();
            return universities.Select(u => new UniversityResponseDto
            {
                Id = u.Id,
                Name = u.Name,
                ShortName = u.ShortName,
                LogoUrl = u.LogoUrl,
                WebsiteUrl = u.WebsiteUrl,
                Address = u.Address,
                City = u.City,
                Region = u.Region,
                FoundedYear = u.FoundedYear,
                MembershipDate = u.MembershipDate,
                CertificateNumber = u.CertificateNumber,
                CertificateFileUrl = u.CertificateFileUrl,
                IsActive = u.IsActive,
                IsPublic = u.IsPublic,
                CreatedAt = u.CreatedAt,
                UpdatedAt = u.UpdatedAt
            });
        }

        public async Task<UniversityResponseDto?> GetUniversityById(Guid id)
        {
            var university = await _universityRepository.GetUniversityByIdAsync(id);
            if (university == null)
                return null;

            return new UniversityResponseDto
            {
                Id = university.Id,
                Name = university.Name,
                ShortName = university.ShortName,
                LogoUrl = university.LogoUrl,
                WebsiteUrl = university.WebsiteUrl,
                Address = university.Address,
                City = university.City,
                Region = university.Region,
                FoundedYear = university.FoundedYear,
                MembershipDate = university.MembershipDate,
                CertificateNumber = university.CertificateNumber,
                CertificateFileUrl = university.CertificateFileUrl,
                IsActive = university.IsActive,
                IsPublic = university.IsPublic,
                CreatedAt = university.CreatedAt,
                UpdatedAt = university.UpdatedAt
            };
        }

        public async Task<Guid> CreateUniversity(CreateUniversityDto dto)
        {
            var university = new Universities
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                ShortName = dto.ShortName,
                LogoUrl = dto.LogoUrl,
                WebsiteUrl = dto.WebsiteUrl,
                Address = dto.Address,
                City = dto.City,
                Region = dto.Region,
                FoundedYear = dto.FoundedYear,
                MembershipDate = dto.MembershipDate,
                CertificateNumber = dto.CertificateNumber,
                CertificateFileUrl = dto.CertificateFileUrl,
                IsActive = dto.IsActive,
                IsPublic = dto.IsPublic,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CreatedBy = dto.CreatedBy
            };

            await _universityRepository.AddUniversityAsync(university);
            return university.Id;
        }

        public async Task UpdateUniversity(Guid id, UpdateUniversityDto dto)
        {
            var university = await _universityRepository.GetUniversityByIdAsync(id);
            if (university == null)
                throw new Exception("Universidad no encontrada");

            university.Name = dto.Name ?? university.Name;
            university.ShortName = dto.ShortName ?? university.ShortName;
            university.LogoUrl = dto.LogoUrl ?? university.LogoUrl;
            university.WebsiteUrl = dto.WebsiteUrl ?? university.WebsiteUrl;
            university.Address = dto.Address ?? university.Address;
            university.City = dto.City ?? university.City;
            university.Region = dto.Region ?? university.Region;
            university.FoundedYear = dto.FoundedYear ?? university.FoundedYear;
            university.MembershipDate = dto.MembershipDate ?? university.MembershipDate;
            university.CertificateNumber = dto.CertificateNumber ?? university.CertificateNumber;
            university.CertificateFileUrl = dto.CertificateFileUrl ?? university.CertificateFileUrl;
            university.IsActive = dto.IsActive;
            university.IsPublic = dto.IsPublic;
            university.UpdatedAt = DateTime.UtcNow;
            university.UpdatedBy = dto.UpdatedBy;

            await _universityRepository.UpdateUniversityAsync(university);
        }

        public async Task DeleteUniversity(Guid id)
        {
            await _universityRepository.DeleteUniversityAsync(id);
        }
    }
}
