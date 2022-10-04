using System;
using System.Collections.Generic;


namespace DBLib.Models
{
    /// <summary>
    /// model kategorii
    /// <summary>
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
