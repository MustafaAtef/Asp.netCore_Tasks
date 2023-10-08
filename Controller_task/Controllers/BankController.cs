using Microsoft.AspNetCore.Mvc;

namespace Controller_task.Controllers {
    public class BankController : Controller {
        [Route("/")]
        public IActionResult Index() {
            return Content("Welcome in the bank application", "text/plain");
        }

        [Route("/account-details")]
        public IActionResult AccountDetails() {

            var accountDetails = new {
                accountNumber = 1001,
                accountHolderName = "Example Name",
                currentBalance = 5000
            };
            return Json(accountDetails);
        }

        [Route("/account-statement")]
        public IActionResult AccountStatement() {
            return File("sample.pdf", "application/pdf");
        }

        [Route("/get-current-balance/{accountNumber?}")]
        public IActionResult CurrentBalance(int? accountNumber) {
            var accountDetails = new {
                accountNumber = 1001,
                accountHolderName = "Example Name",
                currentBalance = 5000
            };
            if (int.TryParse(Convert.ToString(accountNumber), out int id)) {
                if (id != 1001) {
                    Response.StatusCode = 400;
                    return Content("Account Number should be 1001", "text/plain");
                }
                return Content(accountDetails.currentBalance.ToString(), "text/plain");
            }
            Response.StatusCode = 404;
            return Content("Account Number should be supplied", "text/plain");
        }

    }
}
