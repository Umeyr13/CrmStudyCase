using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsManagementDomain.Entities
{
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }
        public int Description { get; set; }
        public DateTime DeadLine { get; set; }
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
