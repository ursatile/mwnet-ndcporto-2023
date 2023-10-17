using Microsoft.AspNetCore.Mvc;

namespace Rockaway.WebApp.Controllers {
	public class ArtistsController : Controller {
		public IActionResult Index() {
			return View();
		}
	}
}
