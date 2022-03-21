using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using fake_social.Models;

namespace fake_social.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private SocialNetwork _db = new();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    // GET /Home/Login
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    // POST
    [HttpPost]
    public IActionResult Login(User userToLog)
    {
        foreach (User user in _db.Users)
        {
            if (user.Username == userToLog.Username &&
                user.Password == userToLog.Password) 
            {
                // TempData["userId"] = userToLog.Id.ToString();
                return RedirectToAction("Profile", "Social", userToLog.Id);
            }
        }

        return View();
    }

    // GET Home/Signup
    [HttpGet]
    public IActionResult Signup()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Signup(User user)
    {
        // add user into db
        var db = new SocialNetwork();
        db.Users.Add(user);
        db.SaveChanges();

        return RedirectToAction("Login");
    }

    public IActionResult CreateCookie()
    {
        string key = "UserId", value = "HelloWorld";
        CookieOptions cookieOptions = new CookieOptions{
            Expires = DateTime.Now.AddDays(5)
        };

        Response.Cookies.Append(
            key,
            value,
            cookieOptions
        );

        return View("Login");
    }

    public IActionResult ReadCookie()
    {
        string key = "UserId";
        var cookieValue = Request.Cookies[key];

        return View("Login");
    }

    public IActionResult DeleteCookie()
    {
        string key = "UserId", value = string.Empty;
        CookieOptions cookieOptions = new CookieOptions{
            Expires = DateTime.Now.AddDays(-1)
        };

        Response.Cookies.Append(
            key,
            value,
            cookieOptions
        );

        return View("Login");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
