using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsManagementDomain.Entities
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int SuggestionId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Employment { get; set; }

        public Suggestion Suggestion{ get; set; }
    }
}
