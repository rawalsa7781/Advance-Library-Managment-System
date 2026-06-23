using System.ComponentModel.DataAnnotations;

namespace LibreryPro1.Models
{
    public class Rack
    {
        public int Id { get; set; }

        [Required]
        public string RackName { get; set; }

        [Required]
        public string Location { get; set; }

        public int Capacity { get; set; }
    }
}