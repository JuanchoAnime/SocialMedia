namespace SocialMedia.Core.Interfaces.Generic
{
    using SocialMedia.Core.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDataRepository<T> where T :BaseEntity
    {
        IEnumerable<T> Get();

        Task<T> GetById(int id);

        Task<T> Save(T model);

        Task<bool> Update(T model);

        Task<bool> Delete(int id);
    }
}
