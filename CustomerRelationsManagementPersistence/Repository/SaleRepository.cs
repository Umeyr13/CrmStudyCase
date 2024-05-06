using CustomerRelationsManagementDomain.Entities;
using CustomerRelationsMangementApplication.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsManagementPersistence.Repository
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        public SaleRepository(CustomerRelationManagementDbContext context) : base(context)
        {
        }
    }
}
