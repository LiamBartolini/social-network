using System.Linq;
using System.Diagnostics;
using fake_social.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;

namespace fake_social.Controllers;

public class SocialController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private SocialNetwork _db = new();
    private long _userId;

    public SocialController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // GET Social/Profile/2
    [HttpGet]
    public IActionResult Profile(long userId)
    {
        _userId = userId;

        List<Post> ps = new();
        foreach (Publish publish in _db.Publishes)
        {
            Post post = (from p in _db.Posts
                        where p.Id == publish.FkIdpost && p.FkIduser == userId
                        select p).First();

            ps.Add(post);
        }

        return View(ps);
    }

    // GET /Social/AddPost
    [HttpGet]
    public IActionResult AddPost()
    {
        return View();
    }

    // POST
    [HttpPost]
    public IActionResult AddPost(Post post)
    {
        // add post in db
        post.Description = $"User id: {_userId}";
        post.FkIduser = _userId;
        _db.Posts.Add(post);
        _db.SaveChanges();

        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
