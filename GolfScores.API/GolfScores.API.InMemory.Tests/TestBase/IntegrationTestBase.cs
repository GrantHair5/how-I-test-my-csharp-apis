using System.Net.Http;
using GolfScores.API.InMemory.Tests.Factory;
using Xunit;

namespace GolfScores.API.InMemory.Tests.TestBase
{
    public class IntegrationTestBase : IClassFixture<ApiWebApplicationFactory>
    {
        protected readonly ApiWebApplicationFactory Factory;
        protected readonly HttpClient Client;

        public IntegrationTestBase(ApiWebApplicationFactory fixture)
        {
            Factory = fixture;
            Client = Factory.CreateClient();
        }
    }
}
