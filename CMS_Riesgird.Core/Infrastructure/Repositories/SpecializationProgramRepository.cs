using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class SpecializationProgramRepository : ISpecializationProgramRepository
{
    private readonly RiesgirdDbContext _context;

    public SpecializationProgramRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SpecializationPrograms>> GetAllProgramsAsync()
    {
        return await _context.SpecializationPrograms
            .OrderByDescending(p => p.StartDate)
            .ThenBy(p => p.Name)
            .ToListAsync();
    }

    public async Task<SpecializationPrograms?> GetProgramByIdAsync(Guid id)
    {
        return await _context.SpecializationPrograms.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<SpecializationPrograms>> GetPublicProgramsAsync()
    {
        return await _context.SpecializationPrograms
            .Where(p => p.IsPublic)
            .OrderByDescending(p => p.StartDate)
            .ThenBy(p => p.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<SpecializationPrograms>> GetOpenEnrollmentProgramsAsync()
    {
        return await _context.SpecializationPrograms
            .Where(p => p.EnrollmentOpen == true)
            .OrderByDescending(p => p.RegistrationDeadline)
            .ThenBy(p => p.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<SpecializationPrograms>> GetUpcomingProgramsAsync()
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        return await _context.SpecializationPrograms
            .Where(p => p.StartDate.HasValue && p.StartDate >= today)
            .OrderBy(p => p.StartDate)
            .ThenBy(p => p.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<SpecializationPrograms>> GetProgramsByUniversityAsync(string university)
    {
        return await _context.SpecializationPrograms
            .Where(p => p.OrganizingUniversities != null && p.OrganizingUniversities.Contains(university))
            .OrderByDescending(p => p.StartDate)
            .ThenBy(p => p.Name)
            .ToListAsync();
    }

    public async Task AddProgramAsync(SpecializationPrograms program)
    {
        _context.SpecializationPrograms.Add(program);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProgramAsync(SpecializationPrograms program)
    {
        _context.SpecializationPrograms.Update(program);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProgramAsync(Guid id)
    {
        var program = await _context.SpecializationPrograms.FindAsync(id);
        if (program != null)
        {
            _context.SpecializationPrograms.Remove(program);
            await _context.SaveChangesAsync();
        }
    }
}
