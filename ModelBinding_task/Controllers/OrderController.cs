using Microsoft.AspNetCore.Mvc;
using ModelBinding_task.Models;
using System.Text;

namespace ModelBinding_task.Controllers {
    public class OrderController : Controller {
        public IActionResult Index() {
            return View();
        }

        [Route("/order")]
        [HttpPost]
        public IActionResult order(OrderModel order) {
            if (ModelState.IsValid) {
                return Content((new Random()).Next(99999).ToString());
            } else {
                StringBuilder errors = new();
                foreach (var propErrors in ModelState.Values) {
                    foreach(var err in propErrors.Errors) {
                        errors.AppendLine(err.ErrorMessage);
                    }
                }
                return BadRequest(errors.ToString());
            }
        }
    }
}
