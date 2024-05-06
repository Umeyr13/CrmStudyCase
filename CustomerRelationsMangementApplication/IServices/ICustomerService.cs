using CustomerRelationsManagementDomain.Entities;
using CustomerRelationsMangementApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsMangementApplication.IServices
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int Customerid);
        Task<List<Customer>> MyCustomers(ClaimsPrincipal Employe);
        Task CreateCustomerAsync(CreateCustomer createCustomer);
        Task DeleteCustomerAsync(int Customerid);
        Task<bool> UpdateCustomer(Customer Customer);
    }
}
