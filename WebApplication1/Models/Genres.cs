using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Genres
    {
        [Key]
        public int Id_Genres { get; set; }
        public string Name { get; set; }
    }
}
