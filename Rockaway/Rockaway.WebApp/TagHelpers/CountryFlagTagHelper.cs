using Microsoft.AspNetCore.Razor.TagHelpers;
using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.TagHelpers;

public class CountryFlagTagHelper : TagHelper {

	public Venue Venue { get; set; } = default!;

	public override void Process(TagHelperContext context, TagHelperOutput output) {
		output.TagName = "img";
		output.TagMode = TagMode.SelfClosing;
		output.Attributes.Add("src", $"/img/flags/{Venue.CountryCode}.png");
		output.Attributes.Add("class", "country-flag");
	}
}