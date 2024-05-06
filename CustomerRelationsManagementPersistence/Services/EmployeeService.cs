using CustomerRelationsManagementDomain.Entities;
using CustomerRelationsMangementApplication.DTOs;
using CustomerRelationsMangementApplication.IServices;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsManagementPersistence.Services
{
    public class EmployeeService : IEmployeeService
    {
        readonly UserManager<AppUser> _userManager;

        public EmployeeService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CreateAsync(CreateEmployee model)
        {
           IdentityResult result = await _userManager.CreateAsync(new Employee {
                FullName = model.FullName,
                Department = model.Department,
                Email = model.Email,
                UserName = model.UserName
            },model.Pasword);
            return result.Succeeded;
        }
    }
}
