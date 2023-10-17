using Rockaway.WebApp.Data.Entities;
using Rockaway.WebApp.Data.Sample;

namespace Rockaway.WebApp.Tests.Entities; 

public class VenueTests {
	[Fact]
	public void Booking_Show_At_Venue_Works() {
		var v = new Venue();
		var a = new Artist();
		v.BookShow(a, new(2023, 10, 17));
		v.Shows.Count.ShouldBe(1);
		v.Shows.First().HeadlineArtist.ShouldBe(a);
	}
}