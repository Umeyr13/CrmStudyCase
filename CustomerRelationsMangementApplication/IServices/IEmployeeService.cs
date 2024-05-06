using CustomerRelationsManagementDomain.Entities;
using CustomerRelationsMangementApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsMangementApplication.IServices
{
    public interface IEmployeeService
    {
        Task<bool> CreateAsync(CreateEmployee model);
    }
}
