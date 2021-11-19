using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using GolfScores.DB;
using GolfScores.DB.Entities;
using GolfScores.Domain.Dto.Courses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace GolfScores.API.InMemory.Tests
{
    public class GolfScoresApiShould
    {
        public TestServer Server;
        private readonly HttpClient _client;

        public GolfScoresApiShould()
        {
            var server = new TestServer(new WebHostBuilder()
                .ConfigureAppConfiguration((context, conf) =>
                {
                    conf.AddJsonFile(Directory.GetCurrentDirectory() + "../appsettings.json");
                }).UseEnvironment("Testing")
                .UseStartup<Startup>()
                .ConfigureServices(services =>
                {
                    services.AddDbContext<GolfScoresDbContext>(options =>
                        options.UseInMemoryDatabase("GolfScoresApiShould.db"));
                })
            );

            _client = server.CreateClient();
            Server = server;


            using var scope = server.Host.Services.CreateScope();
            {
                var context = scope.ServiceProvider.GetRequiredService<GolfScoresDbContext>();
                var dAndGGolfCourseId = Guid.NewGuid();

                context.Courses.Add(new Course
                {
                    Id = dAndGGolfCourseId,
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

        [Fact]
        public  async Task Return_All_Courses()
        {
            var response = await _client.GetAsync("/api/Courses");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CourseDto>>(responseString);

            result.Count.Should().Be(1);
        }
    }
}
