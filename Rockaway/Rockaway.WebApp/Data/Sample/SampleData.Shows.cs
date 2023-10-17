using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Data.Sample;

public partial class SampleData {

	public static class Shows {
		public static readonly Show show1 =
			Venues.Barracuda
				.BookShow(Artists.DevLeppard, new(2023, 10, 17))
				.WithTicketType("General Admission", 25);

		public static readonly Show show2 =
			Venues.Columbia.BookShow(Artists.DevLeppard, new(2023, 10, 18))
				.WithTicketType("General Admission", 35)
				.WithTicketType("VIP Meet & Greet", 75);
		public static readonly Show show3 =
			Venues.Bataclan.BookShow(Artists.DevLeppard, new(2023, 10, 19))
				.WithTicketType("General Admission", 35)
				.WithTicketType("VIP Meet & Greet", 75);
		public static readonly Show show4 =
			Venues.NewCrossInn.BookShow(Artists.DevLeppard, new(2023, 10, 20))
				.WithTicketType("General Admission", 25)
				.WithTicketType("VIP Meet & Greet", 55);

		public static readonly Show show5 =
			Venues.JohnDee.BookShow(Artists.DevLeppard, new(2023, 10, 22))
				.WithTicketType("General Admission", 350)
				.WithTicketType("VIP Meet & Greet", 750);

		public static readonly Show show6 =
			Venues.PubAnchor.BookShow(Artists.DevLeppard, new(2023, 10, 23))
				.WithTicketType("General Admission", 300)
				.WithTicketType("VIP Meet & Greet", 720);
			

		public static readonly Show show7 =
			Venues.Gagarin.BookShow(Artists.DevLeppard, new(2023, 10, 25))
				.WithTicketType("General Admission", 25);

		public static IEnumerable<Show> AllShows = new[] {
			show1, show2, show3, show4, show5, show6, show7
		};

		public static class TicketTypes {
			public static IEnumerable<TicketType>
				AllTicketTypes => AllShows.SelectMany(show => show.TicketTypes);

			public static IEnumerable<object> SeedData
				=> AllTicketTypes.Select(tt => tt.ToSeedData());
		}

		public static IEnumerable<object> SeedData
			=> AllShows.Select(show => show.ToSeedData());
	}
}