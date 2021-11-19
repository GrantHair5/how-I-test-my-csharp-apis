using System;
using System.Collections.Generic;
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
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace GolfScores.API.InMemory.Tests
{
    public class GolfScoresApiShould
    {
        public TestServer Server;
        private readonly HttpClient _client;
        private Guid CourseId = Guid.Parse("ad710974-2c2b-4443-a20e-f9adda994c43");

        public GolfScoresApiShould()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>()
                .ConfigureTestServices(services =>
                {
                    services.AddDbContext<GolfScoresDbContext>(options =>
                        options.UseInMemoryDatabase("GolfScoresApiShould.db"));
                })
            );

            _client = server.CreateClient();
            Server = server;


            using var scope = server.Host.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<GolfScoresDbContext>();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Courses.Add(new Course
                {
                    Id = CourseId,
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

        [Fact]
        public async Task Return_Course_By_Id()
        {
            var response = await _client.GetAsync($"/api/Courses/Course?id={CourseId}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CourseDto>(responseString);
            result.Name.Should().Be("Dumfries & Galloway Golf Course");
        }

        [Fact]
        public async Task Return_All_Courses()
        {
            var response = await _client.GetAsync("/api/Courses");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CourseDto>>(responseString);
            result.Count.Should().Be(1);
        }

       
    }
}
