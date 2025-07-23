using CreditBuildingSimulation.Models;

namespace CreditBuildingSimulation.DataAccess.ADO.Repository.Contract
{
    public interface ILoanRepository
    {
        Task<Loans> CreateAsync(Loans loan);
        Task<Loans> DeleteLoans(Loans loan);
        Task<Loans> UpdateAsync(Loans loan);
        Task<Loans> GetByIdAsync(Guid loanID);
        Task<List<Loans>> GetAllAsync();

    }
}
