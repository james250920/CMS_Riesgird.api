using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface ISpeakerRepository
{
    Task<IEnumerable<Speakers>> GetAllSpeakersAsync();
    Task<Speakers?> GetSpeakerByIdAsync(Guid id);
    Task<IEnumerable<Speakers>> GetSpeakersByCongressIdAsync(Guid congressId);
    Task<IEnumerable<Speakers>> GetSpeakersByCountryAsync(string country);
    Task<IEnumerable<Speakers>> GetSpeakersByInstitutionAsync(string institution);
    Task AddSpeakerAsync(Speakers speaker);
    Task UpdateSpeakerAsync(Speakers speaker);
    Task DeleteSpeakerAsync(Guid id);
}
