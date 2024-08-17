using Library.api.Model;
using Library.api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly IMemberService _memberService;
        private readonly ILoanService _loanService;
        private readonly IBookCopyService _bookCopyService;
        private readonly ICategoryService _categoryService;

        public LibraryController(
            IAuthorService authorService,
            IBookService bookService,
            IMemberService memberService,
            ILoanService loanService,
            IBookCopyService bookCopyService,
            ICategoryService categoryService)
        {
            _authorService = authorService;
            _bookService = bookService;
            _memberService = memberService;
            _loanService = loanService;
            _bookCopyService = bookCopyService;
            _categoryService = categoryService;
        }

        #region Author Endpoints

        [HttpGet("authors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        [HttpGet("authors/{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            return Ok(author);
        }

        [HttpPost("authors")]
        public async Task<IActionResult> AddAuthor([FromBody] Author author)
        {
            var newAuthor = await _authorService.AddAuthorAsync(author);
            return CreatedAtAction(nameof(GetAuthorById), new { id = newAuthor.AuthorID }, newAuthor);
        }

        [HttpPut("authors/{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] Author author)
        {
            if (id != author.AuthorID)
            {
                return BadRequest();
            }

            await _authorService.UpdateAuthorAsync(author);
            return NoContent();
        }

        [HttpDelete("authors/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
            return NoContent();
        }

        #endregion

        #region Book Endpoints

        [HttpGet("books")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("books/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return Ok(book);
        }

        [HttpPost("books")]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            var newBook = await _bookService.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBookById), new { id = newBook.BookID }, newBook);
        }

        [HttpPut("books/{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            if (id != book.BookID)
            {
                return BadRequest();
            }

            await _bookService.UpdateBookAsync(book);
            return NoContent();
        }

        [HttpDelete("books/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }

        #endregion

        #region Member Endpoints

        [HttpGet("members")]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = await _memberService.GetAllMembersAsync();
            return Ok(members);
        }

        [HttpGet("members/{id}")]
        public async Task<IActionResult> GetMemberById(int id)
        {
            var member = await _memberService.GetMemberByIdAsync(id);
            return Ok(member);
        }

        [HttpPost("members")]
        public async Task<IActionResult> AddMember([FromBody] Member member)
        {
            var newMember = await _memberService.AddMemberAsync(member);
            return CreatedAtAction(nameof(GetMemberById), new { id = newMember.MemberID }, newMember);
        }

        [HttpPut("members/{id}")]
        public async Task<IActionResult> UpdateMember(int id, [FromBody] Member member)
        {
            if (id != member.MemberID)
            {
                return BadRequest();
            }

            await _memberService.UpdateMemberAsync(member);
            return NoContent();
        }

        [HttpDelete("members/{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            await _memberService.DeleteMemberAsync(id);
            return NoContent();
        }

        #endregion

        #region Loan Endpoints

        [HttpGet("loans")]
        public async Task<IActionResult> GetAllLoans()
        {
            var loans = await _loanService.GetAllLoansAsync();
            return Ok(loans);
        }

        [HttpGet("loans/{id}")]
        public async Task<IActionResult> GetLoanById(int id)
        {
            var loan = await _loanService.GetLoanByIdAsync(id);
            return Ok(loan);
        }

        [HttpPost("loans")]
        public async Task<IActionResult> AddLoan([FromBody] Loan loan)
        {
            var newLoan = await _loanService.AddLoanAsync(loan);
            return CreatedAtAction(nameof(GetLoanById), new { id = newLoan.LoanID }, newLoan);
        }

        [HttpPut("loans/{id}")]
        public async Task<IActionResult> UpdateLoan(int id, [FromBody] Loan loan)
        {
            if (id != loan.LoanID)
            {
                return BadRequest();
            }

            await _loanService.UpdateLoanAsync(loan);
            return NoContent();
        }

        [HttpDelete("loans/{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            await _loanService.DeleteLoanAsync(id);
            return NoContent();
        }

        #endregion

        #region BookCopy Endpoints

        [HttpGet("bookcopies")]
        public async Task<IActionResult> GetAllBookCopies()
        {
            var bookCopies = await _bookCopyService.GetAllBookCopiesAsync();
            return Ok(bookCopies);
        }

        [HttpGet("bookcopies/{id}")]
        public async Task<IActionResult> GetBookCopyById(int id)
        {
            var bookCopy = await _bookCopyService.GetBookCopyByIdAsync(id);
            return Ok(bookCopy);
        }

        [HttpPost("bookcopies")]
        public async Task<IActionResult> AddBookCopy([FromBody] BookCopy bookCopy)
        {
            try
            {
                if (bookCopy == null)
                {
                    return BadRequest("BookCopy cannot be null");
                }

                await _bookCopyService.AddBookCopyAsync(bookCopy);
                return CreatedAtAction(nameof(GetBookCopyById), new { id = bookCopy.CopyID }, bookCopy);
            }
            catch (Exception ex)
            {
                // Log the exception here if necessary
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("bookcopies/{id}")]
        public async Task<IActionResult> UpdateBookCopy(int id, [FromBody] BookCopy bookCopy)
        {
            if (id != bookCopy.CopyID)
            {
                return BadRequest();
            }

            await _bookCopyService.UpdateBookCopyAsync(bookCopy);
            return NoContent();
        }

        [HttpDelete("bookcopies/{id}")]
        public async Task<IActionResult> DeleteBookCopy(int id)
        {
            await _bookCopyService.DeleteBookCopyAsync(id);
            return NoContent();
        }

        #endregion

        #region Category Endpoints

        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("categories/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(category);
        }

        [HttpPost("categories")]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            var newCategory = await _categoryService.AddCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = newCategory.CategoryID }, newCategory);
        }

        [HttpPut("categories/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            if (id != category.CategoryID)
            {
                return BadRequest();
            }

            await _categoryService.UpdateCategoryAsync(category);
            return NoContent();
        }

        [HttpDelete("categories/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }

        #endregion
    }
}
