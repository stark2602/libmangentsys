using System.ComponentModel.DataAnnotations;

namespace Library.api.Model
{
    public class Member
    {
        [Key]
        public int MemberID { get; set; }
        public string ?FirstName { get; set; }
        public string ?LastName { get; set; }
        public string ?Email { get; set; }
        public string ?PhoneNumber { get; set; }
        public DateTime JoinDate { get; set; }

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }

}
