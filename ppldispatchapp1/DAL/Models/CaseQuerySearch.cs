using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public partial class CaseQuerySearch : Paging
    {
        public CaseQuerySearch ()
        {
          BeginDate="";
          Customer=-1;
          Employee=-1;
          EndDate="";
          ApartmentNumber="";

        }
        public string BeginDate;
        public int Customer;
        public int Employee;
        public string EndDate;
        public string ApartmentNumber;
    }
}
