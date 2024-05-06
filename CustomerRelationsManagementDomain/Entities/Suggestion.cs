using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsManagementDomain.Entities
{
    public class Suggestion
    {
        public int SuggestionId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public Sale Sale { get; set; }  

    }
}
