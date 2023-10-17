using NodaTime;

namespace Rockaway.WebApp.Data;

using System.Linq;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sample;

public class RockawayDbContext : IdentityDbContext<IdentityUser> {
	// We must declare a constructor that takes a DbContextOptions<RockawayDbContext>
	// if we want to use Asp.NET to configure our database connection and provider.
	public RockawayDbContext(DbContextOptions<RockawayDbContext> options) : base(options) { }

	public DbSet<Artist> Artists { get; set; } = default!;
	public DbSet<Venue> Venues { get; set; } = default!;
	public DbSet<Show> Shows { get; set; } = default!;

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);

		// Override EF Core's default table naming (which pluralizes entity names)
		// and use the same names as the C# classes instead
		var rockawayEntities = modelBuilder.Model.GetEntityTypes()
			.Where(e => e.ClrType.Namespace == typeof(Artist).Namespace);

		foreach (var entity in rockawayEntities) {
			entity.SetTableName(entity.DisplayName());
		}

		modelBuilder.Entity<Artist>(entity => {
			entity.HasMany(artist => artist.HeadlineShows).WithOne(show => show.HeadlineArtist);
			entity.HasIndex(artist => artist.Slug).IsUnique();
		});
		modelBuilder.Entity<Venue>(entity => {
			entity.HasMany(venue => venue.Shows).WithOne(show => show.Venue);
			entity.HasIndex(venue => venue.Slug).IsUnique();
		});

		modelBuilder.Entity<TicketType>(entity => {
			entity.Property(tt => tt.Price).HasColumnType("money");
		});

		modelBuilder.Entity<Show>(entity => {
			entity.Property(e => e.Date).HasConversion(
				date => date.ToDateTimeUnspecified(),
				dtu => LocalDate.FromDateTime(dtu));

			entity.HasMany(show => show.TicketTypes)
				.WithOne(ticketType => ticketType.Show)
				.OnDelete(DeleteBehavior.Cascade);

			entity.HasKey(
				nameof(Show.Venue) + nameof(Show.Venue.Id),
				nameof(Show.Date)
			);
		});

		SampleData.Populate(modelBuilder);

		modelBuilder.Entity<IdentityUser>().HasData(SampleData.Users.Admin);

	}
}