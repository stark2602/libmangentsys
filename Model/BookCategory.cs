using Microsoft.EntityFrameworkCore;

namespace Library.api.Model
{

    public class BookCategory
    {
        public int BookID { get; set; }
        public Book ? Book { get; set; }

        public int CategoryID { get; set; }
        public Category ? Category { get; set; }
    }

}
