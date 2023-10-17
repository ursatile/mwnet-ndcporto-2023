using NodaTime;

namespace Rockaway.WebApp.Data.Entities;

public class Show {
	public Venue Venue { get; set; } = default!;
	public LocalDate Date { get; set; }
	public Artist HeadlineArtist { get; set; } = default!;
	public List<TicketType> TicketTypes { get; set; } = new();

	public Show WithTicketType(string name, decimal price) {
		var tt = new TicketType {
			Id = Guid.NewGuid(),
			Name = name,
			Price = price,
			Show = this
		};
		this.TicketTypes.Add(tt);
		return this;
	}
}
