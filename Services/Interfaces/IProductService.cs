using Invoices.Dtos;
using Invoices.Model;

namespace Invoices.Services
{
    public interface IProductService
    {
        Task<Product> SaveProductAsync(SaveProductDto saveProduct);
        public void DeleteProduct(int id);
    }
}