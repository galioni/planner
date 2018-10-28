using System;
using System.Collections.Generic;
using System.Text;
using Planner.Core.Domain;

namespace Planner.Infrastructure.Validation
{
    class ProjectValidation : IProjectValidaiton
    {
        public bool IsNameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;

            return true;
        }

        public bool IsValid(Project project)
        {
            return IsNameValid(project.Name);
        }
    }
}
