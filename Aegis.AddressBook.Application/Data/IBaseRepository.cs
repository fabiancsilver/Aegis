using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aegis.AddressBook.Application.Data
{
    public interface IBaseRepository<T>
    {
        void Create(T entity);

        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

        Task<IReadOnlyList<T>> GetPagedReponse(int page, int size);

        Task Remove(int id);

        Task<int> SaveChanges();

        void Update(int id, T entity);
    }
}