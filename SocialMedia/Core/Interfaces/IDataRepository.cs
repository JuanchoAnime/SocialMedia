using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IDataRepository<T>
    {
        Task<IEnumerable<T>> Get();

        Task<T> GetById(int id);

        Task<T> Save(T model);
    }
}
