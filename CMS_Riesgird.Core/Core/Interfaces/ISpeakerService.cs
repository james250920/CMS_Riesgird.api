using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface ISpeakerService
{
    Task<IEnumerable<SpeakerResponseDto>> GetAllSpeakers();
    Task<SpeakerResponseDto?> GetSpeakerById(Guid id);
    Task<IEnumerable<SpeakerResponseDto>> GetSpeakersByCongressId(Guid congressId);
    Task<IEnumerable<SpeakerResponseDto>> GetSpeakersByCountry(string country);
    Task<IEnumerable<SpeakerResponseDto>> GetSpeakersByInstitution(string institution);
    Task<Guid> CreateSpeaker(CreateSpeakerDto dto);
    Task UpdateSpeaker(Guid id, UpdateSpeakerDto dto);
    Task DeleteSpeaker(Guid id);
}
