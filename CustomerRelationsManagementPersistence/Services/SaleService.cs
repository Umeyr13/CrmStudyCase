using CustomerRelationsManagementDomain.Entities;
using CustomerRelationsMangementApplication.IRepository;
using CustomerRelationsMangementApplication.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsManagementPersistence.Services
{
    public class SaleService : ISaleService
    {
        readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public Task CreateSaleAsync(Sale sale)
        {
            return _saleRepository.AddAsync(sale);
        }

        public  Task DeleteSaleAsync(int saleId)
        {
            return  _saleRepository.RemoveIdAsync(saleId);
        }

        public async Task<List<Sale>> GetAllSaleAsync()
        {
            var query = await _saleRepository.Table.Include(sale => sale.Suggestion)
                .ThenInclude(s => s.Customer)
                .Include(sale => sale.Suggestion.Employee).ToListAsync();
            return query;
        }

        public async Task<Sale> GetSaleByIdAsync(int saleId)
        {
            return await _saleRepository.GetByIdAsync(saleId);
        }

        public bool UpdateSaleAsync(Sale sale)
        {
            return true;
           
        }
    }
}
