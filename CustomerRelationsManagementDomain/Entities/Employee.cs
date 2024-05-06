using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsManagementDomain.Entities
{
    public class Employee:AppUser
    {
        public string FullName { get; set; }
        public string Department { get; set; }
        public ICollection<Tasks> Tasks { get; set; }
        public ICollection<Suggestion> Suggestions { get; set; }
    }
}
