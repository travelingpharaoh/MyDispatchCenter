// ====================================================
// More Templates: https://www.ebenmonney.com/templates
// Email: support@ebenmonney.com
// ====================================================

using System;
using System.Linq;


namespace ppldispatchapp1.ViewModels
{
    public class CaseViewModel
    {
        public int Id { get; set; }
        public decimal CasePrice { get; set; }
        public string Description { get; set; }
        public DateTime ResolvedDate { get; set; }
        public string Title { get; set; }
    }
}
