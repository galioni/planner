using Planner.Core.Domain;
using System;
using System.Linq;
using Xunit;

namespace Planner.Test.Domain
{
    public class ProjectTest
    {
        public Project GetProject()
        {
            return new Project("Test name", "Test description");
        }
        [Fact]
        public void CTOR_AllParametersPopulated_objectCreated()
        {
            Project project = new Project("Test name", "Test description");
            Assert.Equal("Test name", project.Name);
            Assert.Equal("Test description", project.Description);
            Assert.NotEqual(new DateTime(), project.CreatedAt);
        }

        [Fact]
        public void CTOR_MissingDescription_objectCreated()
        {
            Project project = new Project("Test name", "");
            Assert.Equal("Test name", project.Name);
            Assert.Equal(String.Empty, project.Description);
            Assert.NotEqual(new DateTime(), project.CreatedAt);
        }

        [Fact]
        public void CTOR_MissingName_objectNotCreated_ExpcetionThrown()
        {
            Action act = () => new Project("", "");
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void SetName_UpdateName()
        {
            var project = GetProject();
            string newName = "New name";
            project.SetName(newName);
            Assert.Equal(newName, project.Name);
        }

        [Fact]
        public void SetName_MissingName_objectNotCreatedExpcetionThrown()
        {
            var project = GetProject();
            Action act = () => project.SetName("");
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void SetDescription_UpdateDescription()
        {
            var project = GetProject();
            string newDescription = "New description";
            project.SetDescription(newDescription);
            Assert.Equal(newDescription, project.Description);
        }

        [Fact]
        public void SetDescription_BlankNewValu_UpdateDescriptionDontThrowException()
        {
            var project = GetProject();
            string newDescription = "";
            project.SetDescription(newDescription);
            Assert.Equal(newDescription, project.Description);
        }
    }
}
