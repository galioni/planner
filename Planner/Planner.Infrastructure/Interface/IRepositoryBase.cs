using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Planner.Infrastructure.Interface
{
	public interface IRepositoryBase<TEntity>
	{
		Task<IEnumerable<TEntity>> GetAllAsync();
		Task<IEnumerable<TEntity>> GetByConditionAync(Expression<Func<TEntity, bool>> expression);
		void Add(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity entity);
		Task SaveAsync();
	}
}