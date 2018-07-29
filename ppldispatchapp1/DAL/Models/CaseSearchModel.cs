using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public partial class CaseSearchModel 
    {
        
        public string BeginDate { get; set; }
        public int Customer { get; set; }
        public int Employee { get; set; }
        public string EndDate { get; set; }
        public string ApartmentNumber { get; set; }
    }
}
