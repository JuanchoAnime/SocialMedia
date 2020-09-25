namespace SocialMedia.Core.Interfaces.Generic
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SocialMedia.Core.QueryFilter;

    public interface IGenericService<T>
    {
        IEnumerable<T> Get();

        Task<T> GetById(int id);

        Task<T> Save(T model);

        Task<bool> Update(T model);

        Task<bool> Delete(int id);
    }
}
