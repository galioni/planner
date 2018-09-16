using Microsoft.EntityFrameworkCore;
using Planner.Core.Domain;
using Planner.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Infrastructure.Repositories
{
    class ProjectRepository<T> : IRepository<T> where T:Project
    {
        private readonly PlannerContext _dbcontext;

        public ProjectRepository(PlannerContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async void AddAsync(T project)
        {
            await _dbcontext.Projects.AddAsync(project);
            await _dbcontext.SaveChangesAsync();
        }

        public async void DeleteAsync(T project)
        {
            _dbcontext.Projects.Remove(project);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbcontext.Projects.AsNoTracking().ToListAsync();
        }
    }
}
