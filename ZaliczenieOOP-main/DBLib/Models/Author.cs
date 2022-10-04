using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DBLib.Models
{
    /// <summary>
    /// model autora
    /// <summary>
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public List<Book> AuthoredBooks { get; set; }
    }
}
