namespace SocialMedia.Core.Interfaces.Generic
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGenericService<T>
    {
        Task<IEnumerable<T>> Get();

        Task<T> GetById(int id);

        Task<T> Save(T publication);

        Task<bool> Update(T publication);

        Task<bool> Delete(int id);
    }
}
