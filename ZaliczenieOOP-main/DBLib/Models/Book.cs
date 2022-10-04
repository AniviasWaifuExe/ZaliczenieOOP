using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace DBLib.Models
{
    /// <summary>
    /// model książki
    /// <summary>
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }

        public int? AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
