using Library.api.Model;
using Microsoft.EntityFrameworkCore;
namespace Library.api.Services
{
    public class LoanService : ILoanService
{
    private readonly LibraryDbContext _context;

    public LoanService(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Loan>> GetAllLoansAsync()
    {
        return await _context.Loans.Include(l => l.Book)
                                   .Include(l => l.Member)
                                   .ToListAsync();
    }

    public async Task<Loan> GetLoanByIdAsync(int id)
    {
        var loan = await _context.Loans.Include(l => l.Book)
                                       .Include(l => l.Member)
                                       .FirstOrDefaultAsync(l => l.LoanID == id);

        if (loan == null)
        {
            throw new KeyNotFoundException($"Loan with ID {id} not found.");
        }

        return loan;
    }


    public async Task<Loan> AddLoanAsync(Loan loan)
    {
        _context.Loans.Add(loan);
        await _context.SaveChangesAsync();
        return loan;
    }

    public async Task<Loan> UpdateLoanAsync(Loan loan)
    {
        _context.Loans.Update(loan);
        await _context.SaveChangesAsync();
        return loan;
    }

    public async Task DeleteLoanAsync(int id)
    {
        var loan = await _context.Loans.FindAsync(id);
        if (loan != null)
        {
            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
        }
    }
}
}