using Planner.Core.Domain;
using Planner.Infrastructure.Data;
using Planner.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Infrastructure.Repository
{
	public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
	{
		public ProjectRepository(PlannerContext context)
			: base(context)
		{
		}

		public async Task<Project> GetProjectByIdAsync(Guid ProjectId)
		{
			var project = await GetByConditionAync(o => o.ID.Equals(ProjectId));
			return project.FirstOrDefault();
		}

		public async Task AddProjectAsync(Project project)
		{
			Add(project);
			await SaveAsync();
		}

		public async Task UpdateProjectAsync(Project project)
		{
			Update(project);
			await SaveAsync();
		}

		public async Task DeleteProjectAsync(Project project)
		{
			 Delete(project);
			await SaveAsync();
		}

		public async Task<IEnumerable<Project>> GetAllProjectsAsync()
		{
			var projects = await GetAllAsync();
			return projects.OrderBy(x => x.Name);
		}
	}
}