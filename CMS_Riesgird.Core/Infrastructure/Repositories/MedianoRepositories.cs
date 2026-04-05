using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class EventPhotoRepository : IEventPhotoRepository
{
    private readonly RiesgirdDbContext _context;

    public EventPhotoRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EventPhotos>> GetAllPhotosAsync()
    {
        return await _context.EventPhotos.OrderBy(p => p.SortOrder).ToListAsync();
    }

    public async Task<EventPhotos?> GetPhotoByIdAsync(Guid id)
    {
        return await _context.EventPhotos.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<EventPhotos>> GetPhotosByEventIdAsync(Guid eventId)
    {
        return await _context.EventPhotos.Where(p => p.EventId == eventId).OrderBy(p => p.SortOrder).ToListAsync();
    }

    public async Task<IEnumerable<EventPhotos>> GetPublicPhotosAsync()
    {
        return await _context.EventPhotos.Where(p => p.IsPublic).OrderBy(p => p.SortOrder).ToListAsync();
    }

    public async Task<IEnumerable<EventPhotos>> GetFeaturedPhotosAsync()
    {
        return await _context.EventPhotos.Where(p => p.IsFeatured).OrderBy(p => p.SortOrder).ToListAsync();
    }

    public async Task AddPhotoAsync(EventPhotos photo)
    {
        _context.EventPhotos.Add(photo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePhotoAsync(EventPhotos photo)
    {
        _context.EventPhotos.Update(photo);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePhotoAsync(Guid id)
    {
        var photo = await _context.EventPhotos.FindAsync(id);
        if (photo != null)
        {
            _context.EventPhotos.Remove(photo);
            await _context.SaveChangesAsync();
        }
    }
}

public class InstitutionalContentRepository : IInstitutionalContentRepository
{
    private readonly RiesgirdDbContext _context;

    public InstitutionalContentRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<InstitutionalContents>> GetAllContentsAsync()
    {
        return await _context.InstitutionalContents.OrderBy(c => c.Title).ToListAsync();
    }

    public async Task<InstitutionalContents?> GetContentByIdAsync(Guid id)
    {
        return await _context.InstitutionalContents.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<InstitutionalContents>> GetPublicContentsAsync()
    {
        return await _context.InstitutionalContents.Where(c => c.IsPublic).OrderBy(c => c.Title).ToListAsync();
    }

    public async Task<InstitutionalContents?> GetContentByTitleAsync(string title)
    {
        return await _context.InstitutionalContents.FirstOrDefaultAsync(c => c.Title == title);
    }

    public async Task AddContentAsync(InstitutionalContents content)
    {
        _context.InstitutionalContents.Add(content);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateContentAsync(InstitutionalContents content)
    {
        _context.InstitutionalContents.Update(content);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteContentAsync(Guid id)
    {
        var content = await _context.InstitutionalContents.FindAsync(id);
        if (content != null)
        {
            _context.InstitutionalContents.Remove(content);
            await _context.SaveChangesAsync();
        }
    }
}

public class NormativeDocumentRepository : INormativeDocumentRepository
{
    private readonly RiesgirdDbContext _context;

    public NormativeDocumentRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<NormativeDocuments>> GetAllDocumentsAsync()
    {
        return await _context.NormativeDocuments.OrderByDescending(d => d.UploadDate).ToListAsync();
    }

    public async Task<NormativeDocuments?> GetDocumentByIdAsync(Guid id)
    {
        return await _context.NormativeDocuments.FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<IEnumerable<NormativeDocuments>> GetActiveDocumentsAsync()
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        return await _context.NormativeDocuments
            .Where(d => d.ValidFrom <= today)
            .OrderByDescending(d => d.UploadDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<NormativeDocuments>> GetPublicDocumentsAsync()
    {
        return await _context.NormativeDocuments.OrderByDescending(d => d.UploadDate).ToListAsync();
    }

    public async Task<IEnumerable<NormativeDocuments>> GetDocumentsByValidDateAsync(DateOnly date)
    {
        return await _context.NormativeDocuments
            .Where(d => d.ValidFrom <= date)
            .OrderByDescending(d => d.UploadDate)
            .ToListAsync();
    }

    public async Task AddDocumentAsync(NormativeDocuments document)
    {
        _context.NormativeDocuments.Add(document);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDocumentAsync(NormativeDocuments document)
    {
        _context.NormativeDocuments.Update(document);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDocumentAsync(Guid id)
    {
        var document = await _context.NormativeDocuments.FindAsync(id);
        if (document != null)
        {
            _context.NormativeDocuments.Remove(document);
            await _context.SaveChangesAsync();
        }
    }
}

public class ApplicationDocumentRepository : IApplicationDocumentRepository
{
    private readonly RiesgirdDbContext _context;

    public ApplicationDocumentRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ApplicationDocuments>> GetAllDocumentsAsync()
    {
        return await _context.ApplicationDocuments.OrderByDescending(d => d.UploadDate).ToListAsync();
    }

    public async Task<ApplicationDocuments?> GetDocumentByIdAsync(Guid id)
    {
        return await _context.ApplicationDocuments.FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<IEnumerable<ApplicationDocuments>> GetDocumentsByApplicationIdAsync(Guid applicationId)
    {
        return await _context.ApplicationDocuments.Where(d => d.ApplicationId == applicationId).OrderByDescending(d => d.UploadDate).ToListAsync();
    }

    public async Task<IEnumerable<ApplicationDocuments>> GetValidDocumentsAsync()
    {
        return await _context.ApplicationDocuments.Where(d => d.IsValid).OrderByDescending(d => d.UploadDate).ToListAsync();
    }

    public async Task AddDocumentAsync(ApplicationDocuments document)
    {
        _context.ApplicationDocuments.Add(document);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDocumentAsync(ApplicationDocuments document)
    {
        _context.ApplicationDocuments.Update(document);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDocumentAsync(Guid id)
    {
        var document = await _context.ApplicationDocuments.FindAsync(id);
        if (document != null)
        {
            _context.ApplicationDocuments.Remove(document);
            await _context.SaveChangesAsync();
        }
    }
}

public class MembershipCertificateRepository : IMembershipCertificateRepository
{
    private readonly RiesgirdDbContext _context;

    public MembershipCertificateRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MembershipCertificates>> GetAllCertificatesAsync()
    {
        return await _context.MembershipCertificates.OrderByDescending(c => c.IssueDate).ToListAsync();
    }

    public async Task<MembershipCertificates?> GetCertificateByIdAsync(Guid id)
    {
        return await _context.MembershipCertificates.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<MembershipCertificates>> GetCertificatesByUniversityIdAsync(Guid universityId)
    {
        return await _context.MembershipCertificates.Where(c => c.UniversityId == universityId).OrderByDescending(c => c.IssueDate).ToListAsync();
    }

    public async Task<IEnumerable<MembershipCertificates>> GetValidCertificatesAsync()
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        return await _context.MembershipCertificates
            .Where(c => c.ValidFrom <= today && (c.ValidTo == null || c.ValidTo >= today))
            .OrderByDescending(c => c.IssueDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<MembershipCertificates>> GetExpiredCertificatesAsync()
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        return await _context.MembershipCertificates
            .Where(c => c.ValidTo < today)
            .OrderByDescending(c => c.IssueDate)
            .ToListAsync();
    }

    public async Task AddCertificateAsync(MembershipCertificates certificate)
    {
        _context.MembershipCertificates.Add(certificate);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCertificateAsync(MembershipCertificates certificate)
    {
        _context.MembershipCertificates.Update(certificate);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCertificateAsync(Guid id)
    {
        var certificate = await _context.MembershipCertificates.FindAsync(id);
        if (certificate != null)
        {
            _context.MembershipCertificates.Remove(certificate);
            await _context.SaveChangesAsync();
        }
    }
}
