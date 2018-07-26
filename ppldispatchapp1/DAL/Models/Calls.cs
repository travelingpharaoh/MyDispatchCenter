using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Calls
    {
        public int Id { get; set; }
        public string Caller { get; set; }
        public DateTime? CallTime { get; set; }
        public string Notes { get; set; }
        public int? Case { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public Case CaseNavigation { get; set; }
    }
}
