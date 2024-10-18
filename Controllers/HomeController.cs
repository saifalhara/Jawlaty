using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Jawlaty.Models;
using System.Security.Claims;
using Jawlaty.Auth.Services;
using Microsoft.EntityFrameworkCore;

namespace Jawlaty.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAnnouncementService _announcementService;
    private IUser _userService;
    private IUserFavoriteService _userFavoriteService;

    public HomeController(ILogger<HomeController> logger, IAnnouncementService announcementService, IUser userService, IUserFavoriteService userFavoriteService)
    {
        _logger = logger;
        _announcementService = announcementService;
        _userService = userService;
        _userFavoriteService = userFavoriteService;

    }


    public async Task<IActionResult> Index()
    {
        var announcements = _announcementService.GetAllAnnouncements().ToList();

        if (User.Identity.IsAuthenticated){

            var user = await _userService.GetUser(User.Identity.Name);

            if (user != null)
            {
                foreach (var announcement in announcements)
                {
                  //  announcement.IsFavorite = await _userFavoriteService.IsFavoriteAsync(user.Id, announcement.Id);
                }
            }
        }

       
        return View(announcements);
    }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }










}

