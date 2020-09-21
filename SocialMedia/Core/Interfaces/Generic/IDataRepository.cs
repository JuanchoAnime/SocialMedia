using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces.Generic
{
    public interface IDataRepository<T>
    {
        Task<IEnumerable<T>> Get();

        Task<T> GetById(int id);

        Task<T> Save(T model);

        Task<bool> Update(T model);

        Task<bool> Delete(int id);
    }
}
