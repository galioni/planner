using Planner.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Infrastructure.Interface
{
	public interface IProjectRepository
	{
		Task<IEnumerable<Project>> GetAllProjectsAsync();
		Task<Project> GetProjectByIdAsync(int ProjectId);
		Task AddProjectAsync(Project Project);
		Task UpdateProjectAsync(Project Project);
		Task DeleteProjectAsync(Project Project);
	}
}
