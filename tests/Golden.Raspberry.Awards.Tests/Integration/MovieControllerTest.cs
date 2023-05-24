using FluentAssertions;
using Golden.Raspberry.Awards.WebAPI.Commands;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;
using Xunit;

namespace Golden.Raspberry.Awards.Tests.Integration;

public partial class MovieControllerTest
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public MovieControllerTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory]
    [MemberData(nameof(TheoryGetAwardRangeShouldBeReturnCorrectContent))]
    public async Task GetAwardRangeShouldBeReturnCorrectContent(AwardRangeResponse awardRangeResponse)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/movies/award-range");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var contents = await response.Content.ReadAsStringAsync();
        var resutl = JsonSerializer.Deserialize<AwardRangeResponse>(contents, options);

        resutl.Should().BeEquivalentTo(
            awardRangeResponse,
            opt => opt.IncludingProperties());

    }
}