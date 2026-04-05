using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class AgendaItemRepository : IAgendaItemRepository
{
    private readonly RiesgirdDbContext _context;

    public AgendaItemRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AgendaItems>> GetAllItemsAsync()
    {
        return await _context.AgendaItems
            .OrderBy(a => a.SortOrder)
            .ToListAsync();
    }

    public async Task<AgendaItems?> GetItemByIdAsync(Guid id)
    {
        return await _context.AgendaItems
            .Include(a => a.Assembly)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<AgendaItems>> GetItemsByAssemblyIdAsync(Guid assemblyId)
    {
        return await _context.AgendaItems
            .Where(a => a.AssemblyId == assemblyId)
            .OrderBy(a => a.SortOrder)
            .ToListAsync();
    }

    public async Task AddItemAsync(AgendaItems item)
    {
        _context.AgendaItems.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateItemAsync(AgendaItems item)
    {
        _context.AgendaItems.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteItemAsync(Guid id)
    {
        var item = await _context.AgendaItems.FindAsync(id);
        if (item != null)
        {
            _context.AgendaItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
