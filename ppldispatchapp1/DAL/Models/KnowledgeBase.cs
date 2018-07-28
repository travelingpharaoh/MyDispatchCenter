using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class KnowledgeBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Notes { get; set; }
        public string Tags { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
