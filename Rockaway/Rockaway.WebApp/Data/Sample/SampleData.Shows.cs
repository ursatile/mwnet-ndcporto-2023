using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Data.Sample;

public partial class SampleData {

	public static class Shows {
		public static readonly Show show1 =
			Venues.Barracuda.BookShow(Artists.DevLeppard, new(2023, 10, 17));
		public static readonly Show show2 =
			Venues.Columbia.BookShow(Artists.DevLeppard, new(2023, 10, 18));
		public static readonly Show show3 =
			Venues.Bataclan.BookShow(Artists.DevLeppard, new(2023, 10, 19));
		public static readonly Show show4 =
			Venues.NewCrossInn.BookShow(Artists.DevLeppard, new(2023, 10, 20));

		public static IEnumerable<Show> AllShows = new[] {
			show1, show2, show3, show4
		};

		public static IEnumerable<object> SeedData
			=> AllShows.Select(show => show.ToSeedData());
	}
}