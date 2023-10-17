namespace Rockaway.WebApp.Data.Entities;

public class TicketType {
	public Guid Id { get; set; }
	public string Name { get; set; } = default!;
	public Show Show { get; set; } = default!;
	public decimal Price { get; set; }
}