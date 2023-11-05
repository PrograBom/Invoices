using Invoices.Common.Bases;
using Invoices.Common.Interfaces;
using Invoices.Model;

namespace Invoices.Dtos
{
    public class SaveProductDto : BaseDto, IApplyChanges<Product>
    {
        //public SaveProductDto(Product product)
        //{
        //    product.Name = Name;
        //    product.Price = Price;
        //}

        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product ApplyChanges(Product entity)
        {
            entity.Name = Name;
            entity.Price = Price;
            return entity;
        }
    }
}