using Microsoft.EntityFrameworkCore;
using Planner.Core.Domain;
using Planner.Infrastructure.Data;
using Planner.Infrastructure.Interface;
using Planner.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Planner.Test.Repository
{
    public class ProjectRepositoryTest
    {
        ProjectRepository _projectRepository;

        public ProjectRepositoryTest()
        {
            _projectRepository = GetInMemoryProjectRepository();
        }
        private ProjectRepository GetInMemoryProjectRepository()
        {
            PlannerContext plannerDataContext = TestHelper.DataHelper.GetPlannerDataContext();
            return new ProjectRepository(plannerDataContext);
        }

        private Project GetProject()
        {
            return new Project("Test name", "Test description");
        }

        [Fact]
        public async void AddProject_saveChangesInDatabaseAsync()
        {
            var project = GetProject();
            Assert.Equal(0,project.ID);
            await _projectRepository.AddProjectAsync(project);
            Assert.NotEqual(0, project.ID);
            Project savedProject = await _projectRepository.GetProjectByIdAsync(project.ID);
            Assert.NotNull(savedProject);
            Assert.Equal("Test name", savedProject.Name);
            Assert.Equal("Test description", savedProject.Description);
        }

        [Fact]
        public async void GetProjectByIdAsync_returnAddedObject()
        {
            var project = GetProject();
            await _projectRepository.AddProjectAsync(project);
            Project savedProject = await _projectRepository.GetProjectByIdAsync(project.ID);
            Assert.NotNull(savedProject);
            Assert.Equal("Test name", savedProject.Name);
            Assert.Equal("Test description", savedProject.Description);
            var secondProject = GetProject();
            await _projectRepository.AddProjectAsync(secondProject);
            IEnumerable<Project> projects = await _projectRepository.GetAllProjectsAsync();
            Assert.NotEmpty(projects);
            Assert.Contains(project, projects);
            Assert.Contains(secondProject, projects);
            Assert.Equal(2, projects.Count());
        }

        [Fact]
        public async void GetAllProjectsAsync_returnTwoObjects()
        {
            var project = GetProject();
            await _projectRepository.AddProjectAsync(project);
            var secondProject = GetProject();
            await _projectRepository.AddProjectAsync(secondProject);
            IEnumerable<Project> projects = await _projectRepository.GetAllProjectsAsync();
            Assert.NotEmpty(projects);
            Assert.Contains(project, projects);
            Assert.Contains(secondProject, projects);
            Assert.Equal(2, projects.Count());
        }

        [Fact]
        public async void UpdateProjectAsync_UpdateProjectDescription()
        {
            string newDescription = "Changed description";
            var project = GetProject();
            Assert.Equal(0, project.ID);
            await _projectRepository.AddProjectAsync(project);
            Assert.NotEqual(0, project.ID);
            Project savedProject = await _projectRepository.GetProjectByIdAsync(project.ID);
            Assert.NotNull(savedProject);
            Assert.Equal("Test name", savedProject.Name);
            Assert.Equal("Test description", savedProject.Description);
            savedProject.SetDescription(newDescription);
            await _projectRepository.UpdateProjectAsync(savedProject);
            savedProject = await _projectRepository.GetProjectByIdAsync(project.ID);
            Assert.Equal(newDescription, savedProject.Description);
        }

        [Fact]
        public async void DeleteProjectAsync_RemovesLastSavedProject()
        {
            var project = GetProject();
            project.SetName("To be deleted");
            await _projectRepository.AddProjectAsync(project);
            Project savedProject = await _projectRepository.GetProjectByIdAsync(project.ID);
            Assert.NotNull(savedProject);
            Assert.Equal("To be deleted", savedProject.Name);
            Assert.Equal("Test description", savedProject.Description);

            await _projectRepository.DeleteProjectAsync(savedProject);
            IEnumerable<Project> projects = await _projectRepository.GetAllProjectsAsync();
            Assert.DoesNotContain(savedProject, projects);
        }
    }
}
