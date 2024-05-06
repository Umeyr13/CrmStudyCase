using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsManagementDomain.Entities
{
    public class Customer:AppUser
    {
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Suggestion> Suggestions { get; set; }
    }
}
