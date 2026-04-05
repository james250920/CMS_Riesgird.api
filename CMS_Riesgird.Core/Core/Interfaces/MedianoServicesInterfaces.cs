using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IEventPhotoService
{
    Task<IEnumerable<EventPhotoResponseDto>> GetAllPhotos();
    Task<EventPhotoResponseDto?> GetPhotoById(Guid id);
    Task<IEnumerable<EventPhotoResponseDto>> GetPhotosByEventId(Guid eventId);
    Task<IEnumerable<EventPhotoResponseDto>> GetPublicPhotos();
    Task<IEnumerable<EventPhotoResponseDto>> GetFeaturedPhotos();
    Task<Guid> CreatePhoto(CreateEventPhotoDto dto);
    Task UpdatePhoto(Guid id, UpdateEventPhotoDto dto);
    Task DeletePhoto(Guid id);
}

public interface IInstitutionalContentService
{
    Task<IEnumerable<InstitutionalContentResponseDto>> GetAllContents();
    Task<InstitutionalContentResponseDto?> GetContentById(Guid id);
    Task<IEnumerable<InstitutionalContentResponseDto>> GetPublicContents();
    Task<InstitutionalContentResponseDto?> GetContentByTitle(string title);
    Task<Guid> CreateContent(CreateInstitutionalContentDto dto);
    Task UpdateContent(Guid id, UpdateInstitutionalContentDto dto);
    Task DeleteContent(Guid id);
}

public interface INormativeDocumentService
{
    Task<IEnumerable<NormativeDocumentResponseDto>> GetAllDocuments();
    Task<NormativeDocumentResponseDto?> GetDocumentById(Guid id);
    Task<IEnumerable<NormativeDocumentResponseDto>> GetActiveDocuments();
    Task<IEnumerable<NormativeDocumentResponseDto>> GetPublicDocuments();
    Task<IEnumerable<NormativeDocumentResponseDto>> GetDocumentsByValidDate(DateOnly date);
    Task<Guid> CreateDocument(CreateNormativeDocumentDto dto);
    Task UpdateDocument(Guid id, UpdateNormativeDocumentDto dto);
    Task DeleteDocument(Guid id);
}

public interface IApplicationDocumentService
{
    Task<IEnumerable<ApplicationDocumentResponseDto>> GetAllDocuments();
    Task<ApplicationDocumentResponseDto?> GetDocumentById(Guid id);
    Task<IEnumerable<ApplicationDocumentResponseDto>> GetDocumentsByApplicationId(Guid applicationId);
    Task<IEnumerable<ApplicationDocumentResponseDto>> GetValidDocuments();
    Task<Guid> CreateDocument(CreateApplicationDocumentDto dto);
    Task UpdateDocument(Guid id, UpdateApplicationDocumentDto dto);
    Task DeleteDocument(Guid id);
}

public interface IMembershipCertificateService
{
    Task<IEnumerable<MembershipCertificateResponseDto>> GetAllCertificates();
    Task<MembershipCertificateResponseDto?> GetCertificateById(Guid id);
    Task<IEnumerable<MembershipCertificateResponseDto>> GetCertificatesByUniversityId(Guid universityId);
    Task<IEnumerable<MembershipCertificateResponseDto>> GetValidCertificates();
    Task<IEnumerable<MembershipCertificateResponseDto>> GetExpiredCertificates();
    Task<Guid> CreateCertificate(CreateMembershipCertificateDto dto);
    Task UpdateCertificate(Guid id, UpdateMembershipCertificateDto dto);
    Task DeleteCertificate(Guid id);
}
