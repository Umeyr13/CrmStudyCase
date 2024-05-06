using CustomerRelationsManagementDomain.Entities;
using CustomerRelationsMangementApplication.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsManagementPersistence.Repository
{
    public class SuggestionRepository : Repository<Suggestion>, ISuggestionRepository
    {
        public SuggestionRepository(CustomerRelationManagementDbContext context) : base(context)
        {
        }
    }
}
