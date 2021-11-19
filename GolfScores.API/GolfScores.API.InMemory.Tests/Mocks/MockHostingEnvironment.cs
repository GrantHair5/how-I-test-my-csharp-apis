using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

namespace GolfScores.API.InMemory.Tests.Mocks
{
    public class MockHostingEnvironment : IWebHostEnvironment
    {
        public string ApplicationName { get; set; }
        public IFileProvider ContentRootFileProvider { get; set; }
        public string ContentRootPath { get; set; }
        public string EnvironmentName { get; set; } = "Testing";

        public string WebRootPath { get; set; }
        public IFileProvider WebRootFileProvider { get; set; }
    }
}
