using CustomerRelationsManagementDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsMangementApplication.IRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
}
