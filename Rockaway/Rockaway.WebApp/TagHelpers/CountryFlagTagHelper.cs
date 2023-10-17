using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Rockaway.WebApp.TagHelpers; 

public class CountryFlagTagHelper : TagHelper {

	public override void Process(TagHelperContext context, TagHelperOutput output) {
		var countryCode = context.AllAttributes["countryCode"].Value;
		output.TagName = "img";
		output.TagMode = TagMode.SelfClosing;
		output.Attributes.Add("src", $"/img/flags/{countryCode}.png");
		output.Attributes.Add("class", "country-flag");
	}
}