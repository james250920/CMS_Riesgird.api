using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface ICongressService
{
    Task<IEnumerable<CongressResponseDto>> GetAllCongresses();
    Task<CongressResponseDto?> GetCongressById(Guid id);
    Task<IEnumerable<CongressResponseDto>> GetCongressesByYear(int year);
    Task<IEnumerable<CongressResponseDto>> GetPublicCongresses();
    Task<IEnumerable<CongressResponseDto>> GetCongressesByEdition(int edition);
    Task<Guid> CreateCongress(CreateCongressDto dto);
    Task UpdateCongress(Guid id, UpdateCongressDto dto);
    Task DeleteCongress(Guid id);
}
