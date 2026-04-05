using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IAgendaItemService
{
    Task<IEnumerable<AgendaItemResponseDto>> GetAllItems();
    Task<AgendaItemResponseDto?> GetItemById(Guid id);
    Task<IEnumerable<AgendaItemResponseDto>> GetItemsByAssemblyId(Guid assemblyId);
    Task<Guid> CreateItem(CreateAgendaItemDto dto);
    Task UpdateItem(Guid id, UpdateAgendaItemDto dto);
    Task DeleteItem(Guid id);
}
