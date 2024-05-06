using CustomerRelationsManagementDomain.Entities;
using CustomerRelationsMangementApplication.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsManagementPersistence.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerRelationManagementDbContext context) : base(context)
        {
        }
    }
}
