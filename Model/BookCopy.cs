using System.ComponentModel.DataAnnotations;

namespace Library.api.Model
{
    public class BookCopy
    {
        [Key]
        public int CopyID { get; set; }
        public int BookID { get; set; }
        public int CopyNumber { get; set; }
        public bool Available { get; set; }

        public Book? Book { get; set; }
    }

}
