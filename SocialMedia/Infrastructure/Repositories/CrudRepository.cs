namespace SocialMedia.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces.Generic;
    using SocialMedia.Infrastructure.Data;

    public class CrudRepository<T> : IDataRepository<T> where T : BaseEntity
    {
        private readonly SocialMediaContext _context;
        private readonly DbSet<T> _entity;

        public CrudRepository(SocialMediaContext context)
        {
            this._context = context;
            this._entity = _context.Set<T>();
        }

        public IEnumerable<T> Get()
        {
            return _entity.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entity.FirstOrDefaultAsync(l => l.Id.Equals(id));
        }

        public async Task<T> Save(T model)
        {
            await this._entity.AddAsync(model);
            return model;
        }

        public async Task<bool> Update(T model)
        {
            var item = await GetById(model.Id);
            if (item == null) return false;
            this._entity.Update(model);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await GetById(id);
            if (item == null) return false;
            this._entity.Remove(item);
            return true;
        }
    }
}
