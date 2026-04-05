using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class AgendaItemService : IAgendaItemService
{
    private readonly IAgendaItemRepository _repository;

    public AgendaItemService(IAgendaItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AgendaItemResponseDto>> GetAllItems()
    {
        var items = await _repository.GetAllItemsAsync();
        return items.Select(i => MapToResponseDto(i));
    }

    public async Task<AgendaItemResponseDto?> GetItemById(Guid id)
    {
        var item = await _repository.GetItemByIdAsync(id);
        if (item == null)
            return null;

        return MapToResponseDto(item);
    }

    public async Task<IEnumerable<AgendaItemResponseDto>> GetItemsByAssemblyId(Guid assemblyId)
    {
        var items = await _repository.GetItemsByAssemblyIdAsync(assemblyId);
        return items.Select(i => MapToResponseDto(i));
    }

    public async Task<Guid> CreateItem(CreateAgendaItemDto dto)
    {
        var item = new AgendaItems
        {
            Id = Guid.NewGuid(),
            AssemblyId = dto.AssemblyId,
            SortOrder = dto.SortOrder,
            Title = dto.Title,
            Description = dto.Description,
            Presenter = dto.Presenter,
            Duration = dto.Duration
        };

        await _repository.AddItemAsync(item);
        return item.Id;
    }

    public async Task UpdateItem(Guid id, UpdateAgendaItemDto dto)
    {
        var item = await _repository.GetItemByIdAsync(id);
        if (item == null)
            throw new Exception("Punto de agenda no encontrado");

        item.AssemblyId = dto.AssemblyId;
        item.SortOrder = dto.SortOrder;
        item.Title = dto.Title ?? item.Title;
        item.Description = dto.Description ?? item.Description;
        item.Presenter = dto.Presenter ?? item.Presenter;
        item.Duration = dto.Duration ?? item.Duration;

        await _repository.UpdateItemAsync(item);
    }

    public async Task DeleteItem(Guid id)
    {
        await _repository.DeleteItemAsync(id);
    }

    private AgendaItemResponseDto MapToResponseDto(AgendaItems item)
    {
        return new AgendaItemResponseDto
        {
            Id = item.Id,
            AssemblyId = item.AssemblyId,
            SortOrder = item.SortOrder,
            Title = item.Title,
            Description = item.Description,
            Presenter = item.Presenter,
            Duration = item.Duration
        };
    }
}
