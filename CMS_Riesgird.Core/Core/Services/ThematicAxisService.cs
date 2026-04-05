using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class ThematicAxisService : IThematicAxisService
{
    private readonly IThematicAxisRepository _repository;

    public ThematicAxisService(IThematicAxisRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ThematicAxisResponseDto>> GetAllAxes()
    {
        var axes = await _repository.GetAllAxesAsync();
        return axes.Select(a => MapToResponseDto(a));
    }

    public async Task<ThematicAxisResponseDto?> GetAxisById(Guid id)
    {
        var axis = await _repository.GetAxisByIdAsync(id);
        if (axis == null)
            return null;

        return MapToResponseDto(axis);
    }

    public async Task<IEnumerable<ThematicAxisResponseDto>> GetAxesByCongressId(Guid congressId)
    {
        var axes = await _repository.GetAxesByCongressIdAsync(congressId);
        return axes.Select(a => MapToResponseDto(a));
    }

    public async Task<Guid> CreateAxis(CreateThematicAxisDto dto)
    {
        var axis = new ThematicAxes
        {
            Id = Guid.NewGuid(),
            CongressId = dto.CongressId,
            Name = dto.Name,
            Description = dto.Description,
            Coordinator = dto.Coordinator,
            SortOrder = dto.SortOrder
        };

        await _repository.AddAxisAsync(axis);
        return axis.Id;
    }

    public async Task UpdateAxis(Guid id, UpdateThematicAxisDto dto)
    {
        var axis = await _repository.GetAxisByIdAsync(id);
        if (axis == null)
            throw new Exception("Eje temático no encontrado");

        axis.CongressId = dto.CongressId;
        axis.Name = dto.Name ?? axis.Name;
        axis.Description = dto.Description ?? axis.Description;
        axis.Coordinator = dto.Coordinator ?? axis.Coordinator;
        axis.SortOrder = dto.SortOrder;

        await _repository.UpdateAxisAsync(axis);
    }

    public async Task DeleteAxis(Guid id)
    {
        await _repository.DeleteAxisAsync(id);
    }

    private ThematicAxisResponseDto MapToResponseDto(ThematicAxes axis)
    {
        return new ThematicAxisResponseDto
        {
            Id = axis.Id,
            CongressId = axis.CongressId,
            Name = axis.Name,
            Description = axis.Description,
            Coordinator = axis.Coordinator,
            SortOrder = axis.SortOrder
        };
    }
}
