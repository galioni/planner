using Planner.Core.Domain;
using Planner.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Infrastructure.Repository
{
	public class ProjectRepository : RepositoryBase<Project>
	{
		public ProjectRepository(PlannerContext dbcontext)
			: base(dbcontext)
		{
		}

		public async void CreateProjectAsync(Project project)
		{
			AddAsync(project);
			await SaveAsync();
		}

		public async void UpdateProjectAsync(Project project)
		{
			UpdateAsync(project);
			await SaveAsync();
		}

		public async void DeleteProjectAsync(Project project)
		{
			DeleteAsync(project);
			await SaveAsync();
		}

		public async Task<IEnumerable<Project>> GetAllProjectsAsync()
		{
			var projects = await GetAllAsync();
			return projects.OrderBy(x => x.Name);
		}
	}
}