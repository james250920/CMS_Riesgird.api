using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class ApplicationStatusHistoryService : IApplicationStatusHistoryService
{
    private readonly IApplicationStatusHistoryRepository _repository;

    public ApplicationStatusHistoryService(IApplicationStatusHistoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ApplicationStatusHistoryResponseDto>> GetAllHistories()
    {
        var histories = await _repository.GetAllHistoriesAsync();
        return histories.Select(h => MapToResponseDto(h));
    }

    public async Task<ApplicationStatusHistoryResponseDto?> GetHistoryById(Guid id)
    {
        var history = await _repository.GetHistoryByIdAsync(id);
        if (history == null)
            return null;

        return MapToResponseDto(history);
    }

    public async Task<IEnumerable<ApplicationStatusHistoryResponseDto>> GetHistoriesByApplicationId(Guid applicationId)
    {
        var histories = await _repository.GetHistoriesByApplicationIdAsync(applicationId);
        return histories.Select(h => MapToResponseDto(h));
    }

    public async Task<IEnumerable<ApplicationStatusHistoryResponseDto>> GetHistoriesByStatus(string status)
    {
        var histories = await _repository.GetHistoriesByStatusAsync(status);
        return histories.Select(h => MapToResponseDto(h));
    }

    public async Task<Guid> CreateHistory(CreateApplicationStatusHistoryDto dto)
    {
        var history = new ApplicationStatusHistory
        {
            Id = Guid.NewGuid(),
            ApplicationId = dto.ApplicationId,
            Status = dto.Status,
            ChangedAt = DateTime.UtcNow,
            ChangedBy = dto.ChangedBy,
            Notes = dto.Notes
        };

        await _repository.AddHistoryAsync(history);
        return history.Id;
    }

    public async Task UpdateHistory(Guid id, UpdateApplicationStatusHistoryDto dto)
    {
        var history = await _repository.GetHistoryByIdAsync(id);
        if (history == null)
            throw new Exception("Historial no encontrado");

        history.ApplicationId = dto.ApplicationId;
        history.Status = dto.Status ?? history.Status;
        history.ChangedBy = dto.ChangedBy ?? history.ChangedBy;
        history.Notes = dto.Notes ?? history.Notes;

        await _repository.UpdateHistoryAsync(history);
    }

    public async Task DeleteHistory(Guid id)
    {
        await _repository.DeleteHistoryAsync(id);
    }

    private ApplicationStatusHistoryResponseDto MapToResponseDto(ApplicationStatusHistory history)
    {
        return new ApplicationStatusHistoryResponseDto
        {
            Id = history.Id,
            ApplicationId = history.ApplicationId,
            Status = history.Status,
            ChangedAt = history.ChangedAt,
            ChangedBy = history.ChangedBy,
            Notes = history.Notes
        };
    }
}
