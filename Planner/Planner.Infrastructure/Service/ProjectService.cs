using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Planner.Core.Domain;
using Planner.Infrastructure.DTO;
using Planner.Infrastructure.Helpers;
using Planner.Infrastructure.Interface;
using Planner.Infrastructure.Repository;
using Planner.Infrastructure.Validation;

namespace Planner.Infrastructure.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly IProjectValidation _projectValidation;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper, IProjectValidation projectValidaiton)
        {
            this._projectRepository = projectRepository;
            this._mapper = mapper;
            this._projectValidation = projectValidaiton;
        }
        public async Task<OperationResult> AddProjectAsync(ProjectDTO projectDTO)
        {
            OperationResult result = new OperationResult();
            var project = _mapper.Map<ProjectDTO, Project>(projectDTO);

            if (!_projectValidation.IsValid(project))
            {
                result.Success = false;
                return result;
            }

            await _projectRepository.AddProjectAsync(project);
            result.Success = true;
            return result;
        }

        public async Task DeleteProjectAsync(int id)
        {
            Project project = await _projectRepository.GetProjectByIdAsync(id);
            await _projectRepository.DeleteProjectAsync(project);
        }

        public async Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync()
        {
            var projects = await _projectRepository.GetAllProjectsAsync();
            return _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDTO>>(projects);
        }

        public async Task<ProjectDTO> GetProjectByIdAsync(int id)
        {
            var project = await _projectRepository.GetProjectByIdAsync(id);
            return _mapper.Map<Project, ProjectDTO>(project);
        }

        public async Task UpdateProjectAsync(ProjectDTO projectDTO)
        {
            Project project = await _projectRepository.GetProjectByIdAsync(projectDTO.ID);
            project.SetName(projectDTO.Name);
            project.SetDescription(projectDTO.Description);
            await _projectRepository.UpdateProjectAsync(project);
        }
    }
}
