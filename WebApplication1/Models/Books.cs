using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Books
    {
         [Key]
        public int Id_Books { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        [Required]
        [ForeignKey("Genres")] 
        public int Genre_ID {  get; set; }
        public Genres Genres { get; set; }
        public int PublicationYear {  get; set; }
        public int AvailableCopies { get; set;}
        public DateTime DateAdded { get; set; }
        [NotMapped]
        public DateTime? Year { get; set; }
    }
}
