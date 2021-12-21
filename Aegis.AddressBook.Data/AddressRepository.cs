using Aegis.AddressBook.Application.Data;
using Aegis.AddressBook.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aegis.AddressBook.Data
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {

        public readonly AddressBookContext _addressBookContext;

        public AddressRepository(AddressBookContext context) : base(context)
        {
            _addressBookContext = context;
        }

        public async Task<IEnumerable<Address>> GetByContact(int contactID)
        {
            return await _addressBookContext.Addresses.Where(x => x.ContactID == contactID).ToListAsync();
        }

        public async Task<IEnumerable<Address>> GetLast10()
        {
            return await _addressBookContext.Addresses
                                            .OrderByDescending(x => x.AddressID)
                                            .Take(10)
                                            .ToListAsync();
        }
    }
}