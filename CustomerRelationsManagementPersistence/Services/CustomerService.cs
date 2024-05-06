using CustomerRelationsManagementDomain.Entities;
using CustomerRelationsMangementApplication.DTOs;
using CustomerRelationsMangementApplication.IRepository;
using CustomerRelationsMangementApplication.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CustomerRelationsManagementPersistence.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly ISuggestionService _suggestionService;

        public CustomerService(ICustomerRepository customerRepository, UserManager<AppUser> userManager, ISuggestionService suggestionService)
        {
            _customerRepository = customerRepository;
            _userManager = userManager;
            _suggestionService = suggestionService;
        }

        public async Task CreateCustomerAsync(CreateCustomer createCustomer)
        {
            var customer = new Customer()
            {
                CompanyName = createCustomer.CompanyName,
                ContactPerson = createCustomer.ContactPerson,
                PhoneNumber = createCustomer.PhoneNumber,
                Email = createCustomer.Email,
                UserName = createCustomer.CompanyName,
                IsActive = createCustomer.IsActive
            };
            await _customerRepository.AddAsync(customer);
            await _customerRepository.SaveAsync();
        }

        public async Task DeleteCustomerAsync(int Customerid)
        {
            Customer customer = await GetCustomerByIdAsync(Customerid);
            if (customer != null)
            {
                customer.IsActive = false;
                await _customerRepository.SaveAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var customers =await _customerRepository.GetAll().ToListAsync();
           // var customers = appUser.Select(u => (Customer)u);
            return customers;
        }

        public async Task<Customer> GetCustomerByIdAsync(int Customerid)
        {
            var result = await _customerRepository.GetByIdAsync(Customerid);
            return result;
        }

        public async Task<List<Customer>> MyCustomers(ClaimsPrincipal employee)
        {
        
                var suggestions = await _suggestionService.GetAllSuggestionAsync(employee);
                var customerIds = suggestions.Select(s => s.CustomerId).Distinct().ToList();
                List<Customer> MyCustomers = new();

                foreach (var customerId in customerIds)
                {
                    var customer = await GetCustomerByIdAsync(customerId);
                    if (customer != null)
                    {
                        MyCustomers.Add(customer);
                    }
                }
                return MyCustomers;

        }

        public async Task<bool> UpdateCustomer(Customer Customer)
        {
            var customer = await _customerRepository.Find(c => c.Id == Customer.Id).FirstOrDefaultAsync();
            if (customer != null)
            {
                customer.CompanyName = Customer.CompanyName;
                customer.ContactPerson = Customer.ContactPerson;
                customer.PhoneNumber = Customer.PhoneNumber;
                customer.Email = Customer.Email;
                customer.IsActive = Customer.IsActive;
                var es = await _customerRepository.SaveAsync();
                return true;
            }
            return false;

        }
    }
}
