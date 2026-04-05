using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IAgendaItemRepository
{
    Task<IEnumerable<AgendaItems>> GetAllItemsAsync();
    Task<AgendaItems?> GetItemByIdAsync(Guid id);
    Task<IEnumerable<AgendaItems>> GetItemsByAssemblyIdAsync(Guid assemblyId);
    Task AddItemAsync(AgendaItems item);
    Task UpdateItemAsync(AgendaItems item);
    Task DeleteItemAsync(Guid id);
}
