using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DBLib.Models
{
    /// <summary>
    /// model użytkownika
    /// <summary>
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<Book> BorrowedBooks { get; set; }
    }
}
