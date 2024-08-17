using Library.api.Model;
namespace Library.api.Services
{
    public interface IBookCopyService
    {
        Task<BookCopy> GetBookCopyByIdAsync(int id);
        Task<IEnumerable<BookCopy>> GetAllBookCopiesAsync();
        Task AddBookCopyAsync(BookCopy bookCopy);
        Task UpdateBookCopyAsync(BookCopy bookCopy);
        Task DeleteBookCopyAsync(int id);
    }


}