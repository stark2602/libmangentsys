using Library.api.Model;
using Microsoft.EntityFrameworkCore;
namespace Library.api.Services
{

    public class BookService : IBookService
{
    private readonly LibraryDbContext _context;

    public BookService(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _context.Books.Include(b => b.Author)
                                   .Include(b => b.BookCategories)
                                   .ThenInclude(bc => bc.Category)
                                   .ToListAsync();
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        var book = await _context.Books.Include(b => b.Author)
                                       .Include(b => b.BookCategories)
                                       .ThenInclude(bc => bc.Category)
                                       .FirstOrDefaultAsync(b => b.BookID == id);

        if (book == null)
        {
            throw new KeyNotFoundException($"Book with ID {id} not found.");
        }

        return book;
    }


    public async Task<Book> AddBookAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<Book> UpdateBookAsync(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
}