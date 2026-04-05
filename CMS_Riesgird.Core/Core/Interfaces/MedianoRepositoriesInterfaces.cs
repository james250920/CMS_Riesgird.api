using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IEventPhotoRepository
{
    Task<IEnumerable<EventPhotos>> GetAllPhotosAsync();
    Task<EventPhotos?> GetPhotoByIdAsync(Guid id);
    Task<IEnumerable<EventPhotos>> GetPhotosByEventIdAsync(Guid eventId);
    Task<IEnumerable<EventPhotos>> GetPublicPhotosAsync();
    Task<IEnumerable<EventPhotos>> GetFeaturedPhotosAsync();
    Task AddPhotoAsync(EventPhotos photo);
    Task UpdatePhotoAsync(EventPhotos photo);
    Task DeletePhotoAsync(Guid id);
}

public interface IInstitutionalContentRepository
{
    Task<IEnumerable<InstitutionalContents>> GetAllContentsAsync();
    Task<InstitutionalContents?> GetContentByIdAsync(Guid id);
    Task<IEnumerable<InstitutionalContents>> GetPublicContentsAsync();
    Task<InstitutionalContents?> GetContentByTitleAsync(string title);
    Task AddContentAsync(InstitutionalContents content);
    Task UpdateContentAsync(InstitutionalContents content);
    Task DeleteContentAsync(Guid id);
}

public interface INormativeDocumentRepository
{
    Task<IEnumerable<NormativeDocuments>> GetAllDocumentsAsync();
    Task<NormativeDocuments?> GetDocumentByIdAsync(Guid id);
    Task<IEnumerable<NormativeDocuments>> GetActiveDocumentsAsync();
    Task<IEnumerable<NormativeDocuments>> GetPublicDocumentsAsync();
    Task<IEnumerable<NormativeDocuments>> GetDocumentsByValidDateAsync(DateOnly date);
    Task AddDocumentAsync(NormativeDocuments document);
    Task UpdateDocumentAsync(NormativeDocuments document);
    Task DeleteDocumentAsync(Guid id);
}

public interface IApplicationDocumentRepository
{
    Task<IEnumerable<ApplicationDocuments>> GetAllDocumentsAsync();
    Task<ApplicationDocuments?> GetDocumentByIdAsync(Guid id);
    Task<IEnumerable<ApplicationDocuments>> GetDocumentsByApplicationIdAsync(Guid applicationId);
    Task<IEnumerable<ApplicationDocuments>> GetValidDocumentsAsync();
    Task AddDocumentAsync(ApplicationDocuments document);
    Task UpdateDocumentAsync(ApplicationDocuments document);
    Task DeleteDocumentAsync(Guid id);
}

public interface IMembershipCertificateRepository
{
    Task<IEnumerable<MembershipCertificates>> GetAllCertificatesAsync();
    Task<MembershipCertificates?> GetCertificateByIdAsync(Guid id);
    Task<IEnumerable<MembershipCertificates>> GetCertificatesByUniversityIdAsync(Guid universityId);
    Task<IEnumerable<MembershipCertificates>> GetValidCertificatesAsync();
    Task<IEnumerable<MembershipCertificates>> GetExpiredCertificatesAsync();
    Task AddCertificateAsync(MembershipCertificates certificate);
    Task UpdateCertificateAsync(MembershipCertificates certificate);
    Task DeleteCertificateAsync(Guid id);
}
