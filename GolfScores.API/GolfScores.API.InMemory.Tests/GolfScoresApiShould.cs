using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using DeepEqual.Syntax;
using FluentAssertions;
using GolfScores.API.InMemory.Tests.Factory;
using GolfScores.API.InMemory.Tests.TestBase;
using GolfScores.Domain.Dto.Courses;
using Newtonsoft.Json;
using Xunit;

namespace GolfScores.API.InMemory.Tests
{
    public class GolfScoresApiShould : IntegrationTestBase
    {

        private Guid CourseId = Guid.Parse("6791509A-AF9A-4DD2-8A2E-32F28C94A19F");
        public GolfScoresApiShould(ApiWebApplicationFactory fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task Return_Course_By_Id()
        {
            var response = await Client.GetAsync($"/api/Courses/Course?id={CourseId}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CourseDto>(responseString);
            result.Name.Should().Be("Dumfries & Galloway Golf Course");
        }

        [Fact]
        public async Task Return_All_Courses()
        {
            var response = await Client.GetAsync("/api/Courses");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CourseDto>>(responseString);
            result.Count.Should().Be(1);
        }

       
    }
}
