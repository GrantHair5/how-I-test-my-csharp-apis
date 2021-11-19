using System;
using System.Collections.Generic;
using System.Linq;
using GolfScores.API.InMemory.Tests.Mocks;
using GolfScores.DB;
using GolfScores.DB.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GolfScores.API.InMemory.Tests.Factory
{
    public class ApiWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                         typeof(DbContextOptions<GolfScoresDbContext>));

                services.Remove(descriptor);

                services.AddDbContext<GolfScoresDbContext>(options =>
                {
                    options.UseInMemoryDatabase("GolfScoresApiShould");
                });


                var serviceProvider = services.BuildServiceProvider();
                using var scope = serviceProvider.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<GolfScoresDbContext>();

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                InitializeDbForTests(db);


            });
        }


        private void InitializeDbForTests(GolfScoresDbContext context)
        {
            context.Courses.Add(new Course
            {
                Id = Guid.Parse("6791509A-AF9A-4DD2-8A2E-32F28C94A19F"),
                Name = "Dumfries & Galloway Golf Course",
                Par = 70,
                Holes = new List<Hole>
                {
                    new Hole
                    {
                        Id = Guid.NewGuid(),
                        Par = 4,
                        HandicapIndex = 13,
                        Yardage = 334,
                        Name = "Norwest",
                        Number = 1
                    },
                    new Hole
                    {
                        Id = Guid.NewGuid(),
                        Par = 5,
                        HandicapIndex = 9,
                        Yardage = 493,
                        Name = "Summerhill",
                        Number = 2
                    }
                }
            });
            context.SaveChanges();

        }
    }
}
