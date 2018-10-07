using Microsoft.EntityFrameworkCore;
using Planner.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Test.TestHelper
{
    public static class DataHelper
    {
        public static PlannerContext GetPlannerDataContext()
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";
            DbContextOptions<PlannerContext> options;
            var builder = new DbContextOptionsBuilder<PlannerContext>();
            builder.UseInMemoryDatabase(connection);
            options = builder.Options;
            PlannerContext planerDataContext = new PlannerContext(options);
            planerDataContext.Database.EnsureDeleted();
            planerDataContext.Database.EnsureCreated();
            return planerDataContext;
        }
    }
}
