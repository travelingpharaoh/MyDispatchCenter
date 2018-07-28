using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Case
    {
        public Case()
        {
            Calls = new HashSet<Calls>();
        }

        public int Id { get; set; }
        public int? AssignedTo { get; set; }
        public int? Caller { get; set; }
        public int? OpenedBy { get; set; }
        public int? Customer { get; set; }
        public string Status { get; set; }
        public int Category { get; set; }
        public string Priority { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Comments { get; set; }
        public DateTime? ResolvedDate { get; set; }
        public string RelatedCases { get; set; }
        public int? Kb { get; set; }
        public string Attachments { get; set; }
        public string Title { get; set; }
        public DateTime? OpenedDate { get; set; }
        public decimal? CasePrice { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public Employees AssignedToNavigation { get; set; }
        public Customers CustomerNavigation { get; set; }
        public Employees OpenedByNavigation { get; set; }
        public ICollection<Calls> Calls { get; set; }
    }
}
