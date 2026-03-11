using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid> AddUserAsync(Users user);
        Task Delete(Guid id);
        Task<IEnumerable<Users>> GetAll();
        Task<Users?> GetByEmail(string email);
        Task<Users?> GetById(Guid id);
        Task Update(Users user);
    }
}