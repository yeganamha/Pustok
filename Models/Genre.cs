using System.ComponentModel.DataAnnotations;

namespace Pustok.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [MaxLength(25)]
        [Required]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
