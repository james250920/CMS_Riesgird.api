using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class EventPhotoService : IEventPhotoService
{
    private readonly IEventPhotoRepository _repository;

    public EventPhotoService(IEventPhotoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EventPhotoResponseDto>> GetAllPhotos()
    {
        var photos = await _repository.GetAllPhotosAsync();
        return photos.Select(p => MapToResponseDto(p));
    }

    public async Task<EventPhotoResponseDto?> GetPhotoById(Guid id)
    {
        var photo = await _repository.GetPhotoByIdAsync(id);
        return photo == null ? null : MapToResponseDto(photo);
    }

    public async Task<IEnumerable<EventPhotoResponseDto>> GetPhotosByEventId(Guid eventId)
    {
        var photos = await _repository.GetPhotosByEventIdAsync(eventId);
        return photos.Select(p => MapToResponseDto(p));
    }

    public async Task<IEnumerable<EventPhotoResponseDto>> GetPublicPhotos()
    {
        var photos = await _repository.GetPublicPhotosAsync();
        return photos.Select(p => MapToResponseDto(p));
    }

    public async Task<IEnumerable<EventPhotoResponseDto>> GetFeaturedPhotos()
    {
        var photos = await _repository.GetFeaturedPhotosAsync();
        return photos.Select(p => MapToResponseDto(p));
    }

    public async Task<Guid> CreatePhoto(CreateEventPhotoDto dto)
    {
        var photo = new EventPhotos
        {
            Id = Guid.NewGuid(),
            EventId = dto.EventId,
            Url = dto.Url,
            ThumbnailUrl = dto.ThumbnailUrl,
            Caption = dto.Caption,
            Photographer = dto.Photographer,
            TakenAt = dto.TakenAt,
            SortOrder = dto.SortOrder,
            IsPublic = dto.IsPublic,
            IsFeatured = dto.IsFeatured
        };

        await _repository.AddPhotoAsync(photo);
        return photo.Id;
    }

    public async Task UpdatePhoto(Guid id, UpdateEventPhotoDto dto)
    {
        var photo = await _repository.GetPhotoByIdAsync(id);
        if (photo == null) throw new Exception("Foto no encontrada");

        photo.EventId = dto.EventId;
        photo.Url = dto.Url ?? photo.Url;
        photo.ThumbnailUrl = dto.ThumbnailUrl ?? photo.ThumbnailUrl;
        photo.Caption = dto.Caption ?? photo.Caption;
        photo.Photographer = dto.Photographer ?? photo.Photographer;
        photo.TakenAt = dto.TakenAt ?? photo.TakenAt;
        photo.SortOrder = dto.SortOrder;
        photo.IsPublic = dto.IsPublic;
        photo.IsFeatured = dto.IsFeatured;

        await _repository.UpdatePhotoAsync(photo);
    }

    public async Task DeletePhoto(Guid id)
    {
        await _repository.DeletePhotoAsync(id);
    }

    private EventPhotoResponseDto MapToResponseDto(EventPhotos photo)
    {
        return new EventPhotoResponseDto
        {
            Id = photo.Id,
            EventId = photo.EventId,
            Url = photo.Url,
            ThumbnailUrl = photo.ThumbnailUrl,
            Caption = photo.Caption,
            Photographer = photo.Photographer,
            TakenAt = photo.TakenAt,
            SortOrder = photo.SortOrder,
            IsPublic = photo.IsPublic,
            IsFeatured = photo.IsFeatured
        };
    }
}

public class InstitutionalContentService : IInstitutionalContentService
{
    private readonly IInstitutionalContentRepository _repository;

    public InstitutionalContentService(IInstitutionalContentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<InstitutionalContentResponseDto>> GetAllContents()
    {
        var contents = await _repository.GetAllContentsAsync();
        return contents.Select(c => MapToResponseDto(c));
    }

    public async Task<InstitutionalContentResponseDto?> GetContentById(Guid id)
    {
        var content = await _repository.GetContentByIdAsync(id);
        return content == null ? null : MapToResponseDto(content);
    }

    public async Task<IEnumerable<InstitutionalContentResponseDto>> GetPublicContents()
    {
        var contents = await _repository.GetPublicContentsAsync();
        return contents.Select(c => MapToResponseDto(c));
    }

    public async Task<InstitutionalContentResponseDto?> GetContentByTitle(string title)
    {
        var content = await _repository.GetContentByTitleAsync(title);
        return content == null ? null : MapToResponseDto(content);
    }

    public async Task<Guid> CreateContent(CreateInstitutionalContentDto dto)
    {
        var content = new InstitutionalContents
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Content = dto.Content,
            IsPublic = dto.IsPublic,
            LastUpdated = DateTime.UtcNow,
            UpdatedBy = dto.UpdatedBy
        };

        await _repository.AddContentAsync(content);
        return content.Id;
    }

    public async Task UpdateContent(Guid id, UpdateInstitutionalContentDto dto)
    {
        var content = await _repository.GetContentByIdAsync(id);
        if (content == null) throw new Exception("Contenido no encontrado");

        content.Title = dto.Title ?? content.Title;
        content.Content = dto.Content ?? content.Content;
        content.IsPublic = dto.IsPublic;
        content.LastUpdated = DateTime.UtcNow;
        content.UpdatedBy = dto.UpdatedBy ?? content.UpdatedBy;

        await _repository.UpdateContentAsync(content);
    }

    public async Task DeleteContent(Guid id)
    {
        await _repository.DeleteContentAsync(id);
    }

    private InstitutionalContentResponseDto MapToResponseDto(InstitutionalContents content)
    {
        return new InstitutionalContentResponseDto
        {
            Id = content.Id,
            Title = content.Title,
            Content = content.Content,
            IsPublic = content.IsPublic,
            LastUpdated = content.LastUpdated
        };
    }
}

public class NormativeDocumentService : INormativeDocumentService
{
    private readonly INormativeDocumentRepository _repository;

    public NormativeDocumentService(INormativeDocumentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<NormativeDocumentResponseDto>> GetAllDocuments()
    {
        var documents = await _repository.GetAllDocumentsAsync();
        return documents.Select(d => MapToResponseDto(d));
    }

    public async Task<NormativeDocumentResponseDto?> GetDocumentById(Guid id)
    {
        var document = await _repository.GetDocumentByIdAsync(id);
        return document == null ? null : MapToResponseDto(document);
    }

    public async Task<IEnumerable<NormativeDocumentResponseDto>> GetActiveDocuments()
    {
        var documents = await _repository.GetActiveDocumentsAsync();
        return documents.Select(d => MapToResponseDto(d));
    }

    public async Task<IEnumerable<NormativeDocumentResponseDto>> GetPublicDocuments()
    {
        var documents = await _repository.GetPublicDocumentsAsync();
        return documents.Select(d => MapToResponseDto(d));
    }

    public async Task<IEnumerable<NormativeDocumentResponseDto>> GetDocumentsByValidDate(DateOnly date)
    {
        var documents = await _repository.GetDocumentsByValidDateAsync(date);
        return documents.Select(d => MapToResponseDto(d));
    }

    public async Task<Guid> CreateDocument(CreateNormativeDocumentDto dto)
    {
        var document = new NormativeDocuments
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            FileUrl = dto.FileUrl,
            FileName = dto.FileName,
            FileSize = dto.FileSize,
            UploadDate = DateTime.UtcNow,
            ValidFrom = dto.ValidFrom,
            IsPublic = dto.IsPublic
        };

        await _repository.AddDocumentAsync(document);
        return document.Id;
    }

    public async Task UpdateDocument(Guid id, UpdateNormativeDocumentDto dto)
    {
        var document = await _repository.GetDocumentByIdAsync(id);
        if (document == null) throw new Exception("Documento no encontrado");

        document.Name = dto.Name ?? document.Name;
        document.Description = dto.Description ?? document.Description;
        document.FileUrl = dto.FileUrl ?? document.FileUrl;
        document.FileName = dto.FileName ?? document.FileName;
        document.FileSize = dto.FileSize;
        document.ValidFrom = dto.ValidFrom;
        document.IsPublic = dto.IsPublic;

        await _repository.UpdateDocumentAsync(document);
    }

    public async Task DeleteDocument(Guid id)
    {
        await _repository.DeleteDocumentAsync(id);
    }

    private NormativeDocumentResponseDto MapToResponseDto(NormativeDocuments document)
    {
        return new NormativeDocumentResponseDto
        {
            Id = document.Id,
            Name = document.Name,
            Description = document.Description,
            FileUrl = document.FileUrl,
            FileName = document.FileName,
            FileSize = document.FileSize,
            UploadDate = document.UploadDate,
            ValidFrom = document.ValidFrom,
            IsPublic = document.IsPublic
        };
    }
}

public class ApplicationDocumentService : IApplicationDocumentService
{
    private readonly IApplicationDocumentRepository _repository;

    public ApplicationDocumentService(IApplicationDocumentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ApplicationDocumentResponseDto>> GetAllDocuments()
    {
        var documents = await _repository.GetAllDocumentsAsync();
        return documents.Select(d => MapToResponseDto(d));
    }

    public async Task<ApplicationDocumentResponseDto?> GetDocumentById(Guid id)
    {
        var document = await _repository.GetDocumentByIdAsync(id);
        return document == null ? null : MapToResponseDto(document);
    }

    public async Task<IEnumerable<ApplicationDocumentResponseDto>> GetDocumentsByApplicationId(Guid applicationId)
    {
        var documents = await _repository.GetDocumentsByApplicationIdAsync(applicationId);
        return documents.Select(d => MapToResponseDto(d));
    }

    public async Task<IEnumerable<ApplicationDocumentResponseDto>> GetValidDocuments()
    {
        var documents = await _repository.GetValidDocumentsAsync();
        return documents.Select(d => MapToResponseDto(d));
    }

    public async Task<Guid> CreateDocument(CreateApplicationDocumentDto dto)
    {
        var document = new ApplicationDocuments
        {
            Id = Guid.NewGuid(),
            ApplicationId = dto.ApplicationId,
            Name = dto.Name,
            FileUrl = dto.FileUrl,
            FileName = dto.FileName,
            UploadDate = DateTime.UtcNow,
            IsValid = dto.IsValid,
            ValidationNotes = dto.ValidationNotes
        };

        await _repository.AddDocumentAsync(document);
        return document.Id;
    }

    public async Task UpdateDocument(Guid id, UpdateApplicationDocumentDto dto)
    {
        var document = await _repository.GetDocumentByIdAsync(id);
        if (document == null) throw new Exception("Documento no encontrado");

        document.Name = dto.Name ?? document.Name;
        document.FileUrl = dto.FileUrl ?? document.FileUrl;
        document.FileName = dto.FileName ?? document.FileName;
        document.IsValid = dto.IsValid;
        document.ValidationNotes = dto.ValidationNotes ?? document.ValidationNotes;

        await _repository.UpdateDocumentAsync(document);
    }

    public async Task DeleteDocument(Guid id)
    {
        await _repository.DeleteDocumentAsync(id);
    }

    private ApplicationDocumentResponseDto MapToResponseDto(ApplicationDocuments document)
    {
        return new ApplicationDocumentResponseDto
        {
            Id = document.Id,
            ApplicationId = document.ApplicationId,
            Name = document.Name,
            FileUrl = document.FileUrl,
            FileName = document.FileName,
            UploadDate = document.UploadDate,
            IsValid = document.IsValid,
            ValidationNotes = document.ValidationNotes
        };
    }
}

public class MembershipCertificateService : IMembershipCertificateService
{
    private readonly IMembershipCertificateRepository _repository;

    public MembershipCertificateService(IMembershipCertificateRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<MembershipCertificateResponseDto>> GetAllCertificates()
    {
        var certificates = await _repository.GetAllCertificatesAsync();
        return certificates.Select(c => MapToResponseDto(c));
    }

    public async Task<MembershipCertificateResponseDto?> GetCertificateById(Guid id)
    {
        var certificate = await _repository.GetCertificateByIdAsync(id);
        return certificate == null ? null : MapToResponseDto(certificate);
    }

    public async Task<IEnumerable<MembershipCertificateResponseDto>> GetCertificatesByUniversityId(Guid universityId)
    {
        var certificates = await _repository.GetCertificatesByUniversityIdAsync(universityId);
        return certificates.Select(c => MapToResponseDto(c));
    }

    public async Task<IEnumerable<MembershipCertificateResponseDto>> GetValidCertificates()
    {
        var certificates = await _repository.GetValidCertificatesAsync();
        return certificates.Select(c => MapToResponseDto(c));
    }

    public async Task<IEnumerable<MembershipCertificateResponseDto>> GetExpiredCertificates()
    {
        var certificates = await _repository.GetExpiredCertificatesAsync();
        return certificates.Select(c => MapToResponseDto(c));
    }

    public async Task<Guid> CreateCertificate(CreateMembershipCertificateDto dto)
    {
        var certificate = new MembershipCertificates
        {
            Id = Guid.NewGuid(),
            UniversityId = dto.UniversityId,
            UniversityName = dto.UniversityName,
            CertificateNumber = dto.CertificateNumber,
            CertificateType = dto.CertificateType,
            IssueDate = dto.IssueDate,
            ValidFrom = dto.ValidFrom,
            ValidTo = dto.ValidTo
        };

        await _repository.AddCertificateAsync(certificate);
        return certificate.Id;
    }

    public async Task UpdateCertificate(Guid id, UpdateMembershipCertificateDto dto)
    {
        var certificate = await _repository.GetCertificateByIdAsync(id);
        if (certificate == null) throw new Exception("Certificado no encontrado");

        certificate.UniversityId = dto.UniversityId;
        certificate.UniversityName = dto.UniversityName ?? certificate.UniversityName;
        certificate.CertificateNumber = dto.CertificateNumber ?? certificate.CertificateNumber;
        certificate.CertificateType = dto.CertificateType ?? certificate.CertificateType;
        certificate.IssueDate = dto.IssueDate;
        certificate.ValidFrom = dto.ValidFrom;
        certificate.ValidTo = dto.ValidTo;

        await _repository.UpdateCertificateAsync(certificate);
    }

    public async Task DeleteCertificate(Guid id)
    {
        await _repository.DeleteCertificateAsync(id);
    }

    private MembershipCertificateResponseDto MapToResponseDto(MembershipCertificates certificate)
    {
        return new MembershipCertificateResponseDto
        {
            Id = certificate.Id,
            UniversityId = certificate.UniversityId,
            UniversityName = certificate.UniversityName,
            CertificateNumber = certificate.CertificateNumber,
            CertificateType = certificate.CertificateType,
            IssueDate = certificate.IssueDate,
            ValidFrom = certificate.ValidFrom,
            ValidTo = certificate.ValidTo,
            IsValid = true
        };
    }
}
