using Aegis.AddressBook.Application.Data;
using Aegis.AddressBook.Domain;

namespace Aegis.AddressBook.Data
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(AddressBookContext context) : base(context)
        {

        }
    }
}