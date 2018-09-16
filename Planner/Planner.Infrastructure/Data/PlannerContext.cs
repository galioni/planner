using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Core.Domain;

namespace Planner.Infrastructure.Data
{
    class PlannerContext : DbContext
    {
        public PlannerContext(DbContextOptions<PlannerContext> options) : base(options) { }

        public PlannerContext() { }

        public DbSet<Project> Projects {get;set;}  
    }
}
