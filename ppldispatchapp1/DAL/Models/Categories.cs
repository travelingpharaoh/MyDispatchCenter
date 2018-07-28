using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Categories
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? CustomerPrice { get; set; }
    }
}
