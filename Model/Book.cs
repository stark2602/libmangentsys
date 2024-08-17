using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Library.api.Model
{
    
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorID { get; set; }
        public string? Genre { get; set; }

        public Author? Author { get; set; }
        public ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();
        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    }


}
