using Aegis.AddressBook.Application.Data;
using Aegis.AddressBook.Domain;

namespace Aegis.AddressBook.Data
{
    public class AddressTypeRepository : BaseRepository<AddressType>, IAddressTypeRepository
    {
        public AddressTypeRepository(AddressBookContext context) : base(context)
        {

        }
    }
}