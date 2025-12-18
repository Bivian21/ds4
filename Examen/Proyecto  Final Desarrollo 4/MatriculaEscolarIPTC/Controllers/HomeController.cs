using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaEscolarIPTC.Controllers;

public class HomeController : Controller
{
    [AllowAnonymous]
    public IActionResult Index() => View();

    [Authorize]
    public IActionResult Dashboard() => View();
}
