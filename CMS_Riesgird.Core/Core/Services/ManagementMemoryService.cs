using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class ManagementMemoryService : IManagementMemoryService
{
    private readonly IManagementMemoryRepository _repository;

    public ManagementMemoryService(IManagementMemoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ManagementMemoryResponseDto>> GetAllMemories()
    {
        var memories = await _repository.GetAllMemoriesAsync();
        return memories.Select(m => MapToResponseDto(m));
    }

    public async Task<ManagementMemoryResponseDto?> GetMemoryById(Guid id)
    {
        var memory = await _repository.GetMemoryByIdAsync(id);
        if (memory == null)
            return null;

        return MapToResponseDto(memory);
    }

    public async Task<IEnumerable<ManagementMemoryResponseDto>> GetPublicMemories()
    {
        var memories = await _repository.GetPublicMemoriesAsync();
        return memories.Select(m => MapToResponseDto(m));
    }

    public async Task<IEnumerable<ManagementMemoryResponseDto>> GetMemoriesByYear(int year)
    {
        var memories = await _repository.GetMemoriesByYearAsync(year);
        return memories.Select(m => MapToResponseDto(m));
    }

    public async Task<IEnumerable<ManagementMemoryResponseDto>> GetMemoriesByPeriod(string period)
    {
        var memories = await _repository.GetMemoriesByPeriodAsync(period);
        return memories.Select(m => MapToResponseDto(m));
    }

    public async Task<ManagementMemoryResponseDto?> GetLatestMemory()
    {
        var memory = await _repository.GetLatestMemoryAsync();
        if (memory == null)
            return null;

        return MapToResponseDto(memory);
    }

    public async Task<Guid> CreateMemory(CreateManagementMemoryDto dto)
    {
        var memory = new ManagementMemories
        {
            Id = Guid.NewGuid(),
            Year = dto.Year,
            Period = dto.Period,
            Title = dto.Title,
            Description = dto.Description,
            President = dto.President,
            Introduction = dto.Introduction,
            Summary = dto.Summary,
            PageCount = dto.PageCount,
            Highlights = dto.Highlights,
            DocumentUrl = dto.DocumentUrl,
            DigitalBookUrl = dto.DigitalBookUrl,
            CoverImageUrl = dto.CoverImageUrl,
            CustomStats = dto.CustomStats,
            IsPublic = dto.IsPublic,
            PublishedDate = dto.PublishedDate,
            PublishedAt = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            CreatedBy = dto.CreatedBy
        };

        await _repository.AddMemoryAsync(memory);
        return memory.Id;
    }

    public async Task UpdateMemory(Guid id, UpdateManagementMemoryDto dto)
    {
        var memory = await _repository.GetMemoryByIdAsync(id);
        if (memory == null)
            throw new Exception("Memoria de gestión no encontrada");

        memory.Year = dto.Year;
        memory.Period = dto.Period ?? memory.Period;
        memory.Title = dto.Title ?? memory.Title;
        memory.Description = dto.Description ?? memory.Description;
        memory.President = dto.President ?? memory.President;
        memory.Introduction = dto.Introduction ?? memory.Introduction;
        memory.Summary = dto.Summary ?? memory.Summary;
        memory.PageCount = dto.PageCount ?? memory.PageCount;
        memory.Highlights = dto.Highlights ?? memory.Highlights;
        memory.DocumentUrl = dto.DocumentUrl ?? memory.DocumentUrl;
        memory.DigitalBookUrl = dto.DigitalBookUrl ?? memory.DigitalBookUrl;
        memory.CoverImageUrl = dto.CoverImageUrl ?? memory.CoverImageUrl;
        memory.CustomStats = dto.CustomStats ?? memory.CustomStats;
        memory.IsPublic = dto.IsPublic;
        memory.PublishedDate = dto.PublishedDate ?? memory.PublishedDate;
        memory.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateMemoryAsync(memory);
    }

    public async Task DeleteMemory(Guid id)
    {
        await _repository.DeleteMemoryAsync(id);
    }

    private ManagementMemoryResponseDto MapToResponseDto(ManagementMemories memory)
    {
        return new ManagementMemoryResponseDto
        {
            Id = memory.Id,
            Year = memory.Year,
            Period = memory.Period,
            Title = memory.Title,
            Description = memory.Description,
            President = memory.President,
            Introduction = memory.Introduction,
            Summary = memory.Summary,
            PageCount = memory.PageCount,
            Highlights = memory.Highlights,
            DocumentUrl = memory.DocumentUrl,
            DigitalBookUrl = memory.DigitalBookUrl,
            CoverImageUrl = memory.CoverImageUrl,
            CustomStats = memory.CustomStats,
            IsPublic = memory.IsPublic,
            PublishedDate = memory.PublishedDate,
            CreatedAt = memory.CreatedAt,
            UpdatedAt = memory.UpdatedAt
        };
    }
}
