using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Employees
    {
        public Employees()
        {
            CasesAssignedToNavigation = new HashSet<Case>();
            CasesOpenedByNavigation = new HashSet<Case>();
        }

        public int Id { get; set; }
        public string Company { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EMailAddress { get; set; }
        public string JobTitle { get; set; }
        public string BusinessPhone { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string FaxNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string ZipPostalCode { get; set; }
        public string CountryRegion { get; set; }
        public string WebPage { get; set; }
        public string Notes { get; set; }
        public string Attachments { get; set; }
        public int Comision { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public ICollection<Case> CasesAssignedToNavigation { get; set; }
        public ICollection<Case> CasesOpenedByNavigation { get; set; }
    }
}
