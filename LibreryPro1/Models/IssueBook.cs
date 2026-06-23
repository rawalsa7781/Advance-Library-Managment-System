using LibraryPro1.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibreryPro1.Models
{
    public class IssueBook
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int BookId { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public bool IsReturned { get; set; }
        public Student Student { get; set; }

        public Book Book { get; set; }
    }
}