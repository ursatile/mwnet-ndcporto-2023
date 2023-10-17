using NodaTime;

namespace Rockaway.WebApp.Data.Entities;

public class Show {
	public Venue Venue { get; set; } = default!;
	public LocalDate Date { get; set; }
	public Artist HeadlineArtist { get; set; } = default!;
}
