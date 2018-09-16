using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Infrastructure.Repository
{
	public interface IRepository<TEntity>
	{
		Task<IEnumerable<TEntity>> GetAllAsync();
		void AddAsync(TEntity entity);
		void UpdateAsync(TEntity entity);
		void DeleteAsync(TEntity entity);
		Task SaveAsync();
	}
}