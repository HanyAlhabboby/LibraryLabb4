using System.ComponentModel.DataAnnotations;

namespace LibraryLabb4.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public string BookDescripition { get; set; }
        [Required]
        public string Author { get; set; }

        public ICollection <BookCustomer>? BookCustomers { get; set; }
    }
}
