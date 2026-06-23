using System.ComponentModel.DataAnnotations;

namespace LibraryPro1.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string BookName { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public int Quantity { get; set; }
    }
}