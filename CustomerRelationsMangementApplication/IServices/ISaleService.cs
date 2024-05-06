using CustomerRelationsManagementDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsMangementApplication.IServices
{
    public interface ISaleService
    {
        Task<List<Sale>> GetAllSaleAsync();
        Task<Sale> GetSaleByIdAsync(int saleId);
        Task CreateSaleAsync(Sale sale);
        bool UpdateSaleAsync(Sale sale);
        Task DeleteSaleAsync(int saleId);
    }
}
