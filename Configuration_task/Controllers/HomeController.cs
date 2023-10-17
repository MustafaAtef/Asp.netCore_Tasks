using Configuration_task_one;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Configuration_task.Controllers {
    public class HomeController : Controller {
        private readonly IOptions<SocialMediaLinksOptions> _smlo;
        private readonly IWebHostEnvironment _environment;
        public HomeController(IOptions<SocialMediaLinksOptions> smlo, IWebHostEnvironment environment) {
            _smlo = smlo;
            _environment = environment;
        }
        [Route("/")]
        public IActionResult Index() {
            SocialMediaLinksOptions links = _smlo.Value;
            if (_environment.IsDevelopment()) links.Instagram = null;
            
            return Content(links.ToString());
        }
    }
}
