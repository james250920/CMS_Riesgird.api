using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IThematicAxisService
{
    Task<IEnumerable<ThematicAxisResponseDto>> GetAllAxes();
    Task<ThematicAxisResponseDto?> GetAxisById(Guid id);
    Task<IEnumerable<ThematicAxisResponseDto>> GetAxesByCongressId(Guid congressId);
    Task<Guid> CreateAxis(CreateThematicAxisDto dto);
    Task UpdateAxis(Guid id, UpdateThematicAxisDto dto);
    Task DeleteAxis(Guid id);
}
