using System;
using System.Threading.Tasks;
using OfferLocker.Entities;

namespace OfferLocker.Persistence
{
	public abstract class Repository<T> : IRepository<T> where T : Entity
	{
        protected readonly OffersContext context;

        protected Repository(OffersContext context)
        {
            this.context = context;
        }

        public async Task<T> GetById(Guid id)
            => await this.context.Set<T>().FindAsync(id);

        public async Task Add(T entity)
            => await this.context.Set<T>().AddAsync(entity);

        public void Update(T entity)
            => this.context.Set<T>().Update(entity);

        public void Delete(T entity)
            => this.context.Set<T>().Remove(entity);

        public Task SaveChanges()
            => this.context.SaveChangesAsync();
    }
}
