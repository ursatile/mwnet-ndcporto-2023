using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rockaway.WebApp.Data;

namespace Rockaway.WebApp.Controllers {
	public class ArtistsController : Controller {
		private readonly RockawayDbContext db;
		private readonly ILogger<ArtistsController> logger;

		public ArtistsController(RockawayDbContext db, ILogger<ArtistsController> logger) {
			this.db = db;
			this.logger = logger;
		}
		public IActionResult Index() {
			var artists = db.Artists.OrderBy(a => a.Name).ToList();
			return View(artists);
		}

		[Route("/artists/{slug}")]
		public async Task<IActionResult> Details(string slug) {
			var artist = await db.Artists
				.Include(a => a.HeadlineShows)
				.ThenInclude(s => s.Venue)
				.SingleOrDefaultAsync(a => a.Slug == slug);
			if (artist == default) return NotFound();
			return View(artist);
		}
	}
}
