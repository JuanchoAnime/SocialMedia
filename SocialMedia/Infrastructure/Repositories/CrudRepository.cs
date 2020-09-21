namespace SocialMedia.Infrastructure.Repositories
{
    using System.Collections.Generic;
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

        public async Task<IEnumerable<T>> Get()
        {
            var list = await _entity.ToListAsync();
            return list;
        }

        public async Task<T> GetById(int id)
        {
            var item = await _entity.FirstOrDefaultAsync(l => l.Id.Equals(id));
            return item;
        }

        public async Task<T> Save(T model)
        {
            this._entity.Add(model);
            await this._context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> Update(T model)
        {
            var item = await GetById(model.Id);
            if (item == null) return false;
            this._entity.Update(model);
            return 0 < await this._context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var item = await GetById(id);
            this._entity.Remove(item);
            return 0 < await this._context.SaveChangesAsync();
        }
    }
}
