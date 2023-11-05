using Invoices.Dtos;
using Invoices.Exceptions;
using Invoices.Model;

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

    }
}