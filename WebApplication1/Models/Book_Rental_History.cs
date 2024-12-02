using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Book_Rental_History
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Books")]
        public int Books_Id { get; set; }
        public Books Books { get; set; }

        [Required]
        [ForeignKey("Readers")]
        public int Reader_Id { get; set; }
        public Readers Readers { get; set; }

        public DateTime RentalDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public DateTime DueDate { get; set; }
    }
}
