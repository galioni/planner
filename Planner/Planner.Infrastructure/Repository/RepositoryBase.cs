using Microsoft.EntityFrameworkCore;
using Planner.Infrastructure.Data;
using Planner.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Planner.Infrastructure.Repository
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
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

		public async Task<IEnumerable<T>> GetByConditionAync(Expression<Func<T, bool>> expression)
		{
			return await this._dbcontext.Set<T>().Where(expression).ToListAsync();
		}

		public void Add(T entity)
		{
			this._dbcontext.Set<T>().Add(entity);
		}

		public void Update(T entity)
		{
			this._dbcontext.Set<T>().Update(entity);
		}

		public void Delete(T entity)
		{
			this._dbcontext.Set<T>().Remove(entity);
		}

		public async Task SaveAsync()
		{
			await this._dbcontext.SaveChangesAsync();
		}
	}
}
