using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsMangementApplication.DTOs
{
    public class CreateEmployee
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Pasword { get; set; }
    }
}
