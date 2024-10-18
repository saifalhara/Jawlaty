using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jawlaty.Auth.Services;
using Jawlaty.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jawlaty.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly IAnnouncementService _announcement;
        public AnnouncementsController(IAnnouncementService announcement)
        {
            _announcement = announcement;

        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> AnnouncementDetails(int id)
        {
            var announcement = await _announcement.GetAnnouncementById(id);
            if (announcement == null)
            {
                return NotFound();
            }
            return View(announcement);
        }


    }
}