using Library.api.Model;
using Microsoft.EntityFrameworkCore;
namespace Library.api.Services
{

    public class BookCopyService : IBookCopyService
    {
        private readonly LibraryDbContext _dbContext;

        public BookCopyService(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookCopy> GetBookCopyByIdAsync(int id)
        {
            var bookCopy = await _dbContext.BookCopies.FindAsync(id);
            if (bookCopy == null)
            {
                throw new Exception("BookCopy not found");
            }
            return bookCopy;
        }

        public async Task<IEnumerable<BookCopy>> GetAllBookCopiesAsync()
        {
            return await _dbContext.BookCopies.ToListAsync();
        }

        public async Task AddBookCopyAsync(BookCopy bookCopy)
        {
            if (bookCopy == null)
            {
                throw new ArgumentNullException(nameof(bookCopy));
            }
            _dbContext.BookCopies.Add(bookCopy);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateBookCopyAsync(BookCopy bookCopy)
        {
            if (bookCopy == null)
            {
                throw new ArgumentNullException(nameof(bookCopy));
            }
            _dbContext.BookCopies.Update(bookCopy);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBookCopyAsync(int id)
        {
            var bookCopy = await _dbContext.BookCopies.FindAsync(id);
            if (bookCopy == null)
            {
                throw new Exception("BookCopy not found");
            }
            _dbContext.BookCopies.Remove(bookCopy);
            await _dbContext.SaveChangesAsync();
        }
    }


}