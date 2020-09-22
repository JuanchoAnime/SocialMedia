namespace SocialMedia.Core.Interfaces.Generic
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SocialMedia.Core.QueryFilter;

    public interface IGenericService<T>
    {
        IEnumerable<T> Get(GetQueryFilter queryFilter);

        Task<T> GetById(int id);

        Task<T> Save(T publication);

        Task<bool> Update(T publication);

        Task<bool> Delete(int id);
    }
}
