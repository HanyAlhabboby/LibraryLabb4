using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryLabb4.Models
{
    public class BookCustomer
    {
        public int BookCustomerId { get; set; }

        [ForeignKey("Book")]
        public int FkBookId { get; set; }
        public Book? Book { get; set; }

        [ForeignKey("Customer")]
        public int FkCustomerId { get; set; }
        public Customer? Customer { get; set; }

        public DateTime? BorrowDate { get; set; }

        public DateTime? ReturnDate { get; set; }

    }
}
