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
                return RedirectToAction("Profile", "Social");
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
