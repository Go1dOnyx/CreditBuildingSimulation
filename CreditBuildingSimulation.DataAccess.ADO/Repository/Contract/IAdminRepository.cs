using CreditBuildingSimulation.Models;

namespace CreditBuildingSimulation.DataAccess.ADO.Repository.Contract
{
    internal interface IAdminRepository
    {
        Task<Admins> CreateAsync(Admins admins);
        Task<bool> DeleteAsync(Admins admins);
        Task<Admins> UpdateAsync(Admins admins);

        //Extra - try to apply SOLID principles if you can.
        Task<Admins> ChangePasswordAsync(string email, string old_hash_pass, string new_hash_pass);
        Task SignOutAsync(string email);
        Task LoginAsync(string username, string password_hash);
        Task<Admins?> GetByIdAsync(Guid adminID);
        Task<Admins> GetByEmailAsync(string email);
        Task<List<Admins>> GetAllAsync();

    }
}
