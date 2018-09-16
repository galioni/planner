using Microsoft.EntityFrameworkCore;
using Planner.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Infrastructure.Repository
{
	public abstract class RepositoryBase<T> : IRepository<T> where T : class
	{
		private PlannerContext _dbcontext { get; set; }

		public RepositoryBase(PlannerContext repositoryContext)
		{
			this._dbcontext = repositoryContext;
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await this._dbcontext.Set<T>().ToListAsync();
		}

		public void AddAsync(T entity)
		{
			this._dbcontext.Set<T>().Add(entity);
		}

		public void UpdateAsync(T entity)
		{
			this._dbcontext.Set<T>().Add(entity);
		}

		public void DeleteAsync(T entity)
		{
			this._dbcontext.Set<T>().Add(entity);
		}

		public async Task SaveAsync()
		{
			await this._dbcontext.SaveChangesAsync();
		}
	}
}
