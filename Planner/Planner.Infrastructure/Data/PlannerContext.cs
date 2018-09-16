using Microsoft.EntityFrameworkCore;
using Planner.Core.Domain;

namespace Planner.Infrastructure.Data
{
	public class PlannerContext : DbContext
	{
		public PlannerContext(DbContextOptions<PlannerContext> options) : base(options) { }

		public PlannerContext() { }

		public DbSet<Project> Projects { get; set; }
	}
}
