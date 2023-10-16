namespace Rockaway.WebApp.Tests.Pages;
using Microsoft.AspNetCore.Mvc.Testing;
using AngleSharp;
using Shouldly;

public class PageTests {

	[Fact]
	public async Task Homepage_Works() {
		var factory = new WebApplicationFactory<Program>();
		var client = factory.CreateClient();
		var result = await client.GetAsync("/");
		result.EnsureSuccessStatusCode();
	}

	[Theory]
	[InlineData("/")]
	[InlineData("/privacy")]
	// [InlineData("/contact")]
	public async Task Page_Works(string url) {
		var factory = new WebApplicationFactory<Program>();
		var client = factory.CreateClient();
		var result = await client.GetAsync(url);
		result.EnsureSuccessStatusCode();
	}

	[Fact]
	public async Task Homepage_Title_Has_Correct_Content() {
		var browsingContext = BrowsingContext.New(Configuration.Default);
		var factory = new WebApplicationFactory<Program>();
		var client = factory.CreateClient();
		var html = await client.GetStringAsync("/");
		var dom = await browsingContext.OpenAsync(req => req.Content(html));
		var title = dom.QuerySelector("title");
		title.ShouldNotBeNull();
		title.InnerHtml.ShouldBe("Rockaway");
	}

}