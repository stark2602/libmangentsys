using System.ComponentModel.DataAnnotations;

namespace Library.api.Model
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        // Navigation property for BookCategories
        public ICollection<BookCategory> ?BookCategories { get; set; }
    }

}
