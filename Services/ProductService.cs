using Invoices.Dtos;
using Invoices.Exceptions;
using Invoices.Model;
using Microsoft.EntityFrameworkCore;

namespace Invoices.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> SaveProductAsync(SaveProductDto saveProduct)
        {
            var dbProduct = new Product();
            //change product
            if (saveProduct.Id != 0)
            {  
                dbProduct = _dbContext.Products.Where(p => p.Id == saveProduct.Id).FirstOrDefault();
                if (dbProduct.Name == saveProduct.Name && dbProduct.Price == saveProduct.Price)
                {
                    throw new CustomException("Product with these parameters already exists");
                }
                else
                {
                    saveProduct.ApplyChanges(dbProduct);
                }
            }
            // new product
            else
            {
                saveProduct.ApplyChanges(dbProduct);
                _dbContext.Products.Add(dbProduct);
            }
            try
            {
                int takeId = await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new CustomException("Error saving product to the database");
            }
            return dbProduct;
        }

        public void DeleteProduct(int id)
        {
            var productToDelete = _dbContext.Products.FirstOrDefault(p => p.Id == id);

            if (productToDelete != null)
            {
                _dbContext.Products.Remove(productToDelete);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new CustomException("This product is not in database");
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var dbProduct = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if(dbProduct == null)
            {
                throw new CustomException("No such Product in the database");
            }
            return dbProduct as Product;
        }

        public async Task<IEnumerable<Product>> GetProductListAsync()
        {
            var dbProducts = await _dbContext.Products.ToListAsync();
            if(dbProducts == null)
            {
                throw new CustomException("Products table is empty");
            }
            return dbProducts;
        }
    }
}