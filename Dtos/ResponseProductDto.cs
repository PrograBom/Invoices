using Invoices.Model;

namespace Invoices.Dtos
{
    public class ResponseProductDto : SaveProductDto
    {

        public static explicit operator ResponseProductDto(Product v)
        {
            return new ResponseProductDto
            {
                Id = v.Id,
                Name = v.Name,
                Price = (decimal)v.Price
            };
        }
    }
}