using Aegis.AddressBook.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aegis.AddressBook.Application.Data
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<IEnumerable<Address>> GetByContact(int contactID);

        Task<IEnumerable<Address>> GetLast10();
    }
}
