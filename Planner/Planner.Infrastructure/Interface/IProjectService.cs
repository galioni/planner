﻿using Planner.Core.Domain;
using Planner.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Infrastructure.Interface
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync();
        Task AddProjectAsync(ProjectDTO projectDTO);
        Task UpdateProjectAsync(ProjectDTO projectDTO);
        Task DeleteProjectAsync(int id);
        Task<ProjectDTO> GetProjectByIdAsync(int id);
    }
}