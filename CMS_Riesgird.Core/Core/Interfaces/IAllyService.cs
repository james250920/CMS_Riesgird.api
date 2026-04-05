using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IAllyService
{
    Task<IEnumerable<AllyResponseDto>> GetAllAllies();
    Task<AllyResponseDto?> GetAllyById(Guid id);
    Task<IEnumerable<AllyResponseDto>> GetPublicAllies();
    Task<IEnumerable<AllyResponseDto>> GetActiveAllies();
    Task<Guid> CreateAlly(CreateAllyDto dto);
    Task UpdateAlly(Guid id, UpdateAllyDto dto);
    Task DeleteAlly(Guid id);
}
