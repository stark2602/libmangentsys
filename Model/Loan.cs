using System.ComponentModel.DataAnnotations;

namespace Library.api.Model
{
    public class Loan
    {
        [Key]
        public int LoanID { get; set; }
        public int BookID { get; set; }
        public int MemberID { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool Returned { get; set; }

        public Book ?Book { get; set; }
        public Member? Member { get; set; }
    }

}
