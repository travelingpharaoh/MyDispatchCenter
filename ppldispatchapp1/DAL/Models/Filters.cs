using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Filters
    {
        public int Id { get; set; }
        public short ObjectType { get; set; }
        public string ObjectName { get; set; }
        public string FilterName { get; set; }
        public string FilterString { get; set; }
        public string SortString { get; set; }
        public bool Default { get; set; }
        public string Description { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
