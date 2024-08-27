using Microsoft.AspNetCore.Mvc;

namespace StudentRegister.API.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
