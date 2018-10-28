using Planner.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Infrastructure.Validation
{
    public interface IProjectValidation : IValidation
    {
        bool IsNameValid(string name);
        bool IsValid(Project project);
    }
}
