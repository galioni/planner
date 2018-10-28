using Planner.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Infrastructure.Validation
{
    public interface IProjectValidaiton
    {
        bool IsNameValid(string name);
        bool IsValid(Project project);
    }
}
