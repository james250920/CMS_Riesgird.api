using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class AllyService : IAllyService
{
    private readonly IAllyRepository _repository;

    public AllyService(IAllyRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AllyResponseDto>> GetAllAllies()
    {
        var allies = await _repository.GetAllAlliesAsync();
        return allies.Select(a => MapToResponseDto(a));
    }

    public async Task<AllyResponseDto?> GetAllyById(Guid id)
    {
        var ally = await _repository.GetAllyByIdAsync(id);
        if (ally == null)
            return null;

        return MapToResponseDto(ally);
    }

    public async Task<IEnumerable<AllyResponseDto>> GetPublicAllies()
    {
        var allies = await _repository.GetPublicAlliesAsync();
        return allies.Select(a => MapToResponseDto(a));
    }

    public async Task<IEnumerable<AllyResponseDto>> GetActiveAllies()
    {
        var allies = await _repository.GetActiveAlliesAsync();
        return allies.Select(a => MapToResponseDto(a));
    }

    public async Task<Guid> CreateAlly(CreateAllyDto dto)
    {
        var ally = new Allies
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            LogoUrl = dto.LogoUrl,
            WebsiteUrl = dto.WebsiteUrl,
            ContactEmail = dto.ContactEmail,
            ContactPhone = dto.ContactPhone,
            Description = dto.Description,
            IsActive = dto.IsActive,
            IsPublic = dto.IsPublic,
            SortOrder = dto.SortOrder,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _repository.AddAllyAsync(ally);
        return ally.Id;
    }

    public async Task UpdateAlly(Guid id, UpdateAllyDto dto)
    {
        var ally = await _repository.GetAllyByIdAsync(id);
        if (ally == null)
            throw new Exception("Aliado no encontrado");

        ally.Name = dto.Name ?? ally.Name;
        ally.LogoUrl = dto.LogoUrl ?? ally.LogoUrl;
        ally.WebsiteUrl = dto.WebsiteUrl ?? ally.WebsiteUrl;
        ally.ContactEmail = dto.ContactEmail ?? ally.ContactEmail;
        ally.ContactPhone = dto.ContactPhone ?? ally.ContactPhone;
        ally.Description = dto.Description ?? ally.Description;
        ally.IsActive = dto.IsActive;
        ally.IsPublic = dto.IsPublic;
        ally.SortOrder = dto.SortOrder;
        ally.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAllyAsync(ally);
    }

    public async Task DeleteAlly(Guid id)
    {
        await _repository.DeleteAllyAsync(id);
    }

    private AllyResponseDto MapToResponseDto(Allies ally)
    {
        return new AllyResponseDto
        {
            Id = ally.Id,
            Name = ally.Name,
            LogoUrl = ally.LogoUrl,
            WebsiteUrl = ally.WebsiteUrl,
            ContactEmail = ally.ContactEmail,
            ContactPhone = ally.ContactPhone,
            Description = ally.Description,
            IsActive = ally.IsActive,
            IsPublic = ally.IsPublic,
            SortOrder = ally.SortOrder,
            CreatedAt = ally.CreatedAt,
            UpdatedAt = ally.UpdatedAt
        };
    }
}
