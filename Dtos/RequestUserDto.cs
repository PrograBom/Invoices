using Invoices.Common.Bases;
using Invoices.Common.Interfaces;
using Invoices.Enums;
using Invoices.Model;

namespace Invoices.Dtos
{
    public class RequestUserDto : BaseDto, IApplyChanges<User>
    {
        public string TaxId { get; set; }
        public string VatId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string BankNumber { get; set; }
        public string Country { get; set; }
        //public EUserType UserType { get; set; }

        public User ApplyChanges(User entity)
        {
            if (entity.Address == null)
            {
               var address = new Address();
               entity.Address = address;
            }
            entity.Address.Street = Street;
            entity.Address.City = City;
            entity.Address.ZipCode = PostalCode;
            entity.Address.Country = Country;
            entity.Name = Name;
            entity.BankNumber = BankNumber;
            if(!string.IsNullOrEmpty(TaxId))
            {
                if(entity.ClientDetail == null) { entity.ClientDetail = new ClientDetail();}
                entity.ClientDetail.TaxId = TaxId;
            }
            if (!string.IsNullOrEmpty(VatId))
            {
                if(entity.ClientDetail == null) { entity.ClientDetail = new ClientDetail { VatId = VatId }; }
                entity.ClientDetail.VatId = VatId;

            }
            return entity;
        }
    }
}
