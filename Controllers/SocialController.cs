using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using fake_social.Models;

namespace fake_social.Controllers;

public class SocialController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public SocialController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // GET Social/Profile
    [HttpGet]
    public IActionResult Profile()
    {
        return View();
    }

    // GET /Social/AddPost
    [HttpGet]
    public IActionResult AddPost()
    {
        return View();
    }

    // POST /Social/AddPost
    [HttpPost]
    public IActionResult AddPost(Post post)
    {
        // add post in db and publish
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
