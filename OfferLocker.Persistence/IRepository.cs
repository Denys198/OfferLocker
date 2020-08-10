using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OfferLocker.Entities;

namespace OfferLocker.Persistence
{
	public interface IRepository<T> where T : Entity
	{
		Task<T> GetById(Guid id);

		Task<IList<T>> GetAll();

		Task Add(T entity);

		void Update(T entity);

		void Delete(T entity);

		Task SaveChanges();
	}
}
