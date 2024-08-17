using Library.api.Model;
namespace Library.api.Services
{
    public interface ILoanService
    {
        Task<IEnumerable<Loan>> GetAllLoansAsync();
        Task<Loan> GetLoanByIdAsync(int id);
        Task<Loan> AddLoanAsync(Loan loan);
        Task<Loan> UpdateLoanAsync(Loan loan);
        Task DeleteLoanAsync(int id);
    }
}