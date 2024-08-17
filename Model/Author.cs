using System.ComponentModel.DataAnnotations;
namespace Library.api.Model
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        public string ?FirstName { get; set; }
        public string ?LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }

}
