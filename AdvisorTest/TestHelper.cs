using Advisor.Application;
using Advisor.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisorTest
{
    internal class TestHelper
    {
        private readonly ApiContext advisorDbContext;
        public TestHelper()
        {
            var builder = new DbContextOptionsBuilder<ApiContext>();
            builder.UseInMemoryDatabase(databaseName: "AdvisorDB");

            var dbContextOptions = builder.Options;
            advisorDbContext = new ApiContext(dbContextOptions);
            // Delete existing db before creating a new one
            advisorDbContext.Database.EnsureDeleted();
            advisorDbContext.Database.EnsureCreated();
        }

        public IAdvisorRepository GetInMemoryAdvisorRepository()
        {
            return new AdvisorRepository(advisorDbContext);
        }

    }
}
