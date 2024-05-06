using CustomerRelationsManagementDomain.Entities;
using CustomerRelationsMangementApplication.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsManagementPersistence.Repository
{
    public class TaskRepository : Repository<Tasks>, ITaskRepository
    {
        public TaskRepository(CustomerRelationManagementDbContext context) : base(context)
        {
        }
    }
}
