using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Jawlaty.Models;
using Jawlaty.Services.Rating;
using Microsoft.AspNetCore.Mvc;


    public class EntertainmentController : Controller
    {
    private readonly IEntertainmentService _entertainmentService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IRatingService _ratingService;
    private readonly IUserFavoriteService _userFavoriteService;



    public EntertainmentController(IEntertainmentService entertainmentService, IWebHostEnvironment webHostEnvironment, IRatingService ratingService, IUserFavoriteService userFavoriteService)
    {
        _entertainmentService = entertainmentService;
        _webHostEnvironment = webHostEnvironment;
        _ratingService = ratingService;
        _userFavoriteService = userFavoriteService;
}

    public IActionResult Index()
    {
        var entertainments = _entertainmentService.GetAllEntertainments();
        return View(entertainments);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Entertainment entertainment, IFormFile imageFile)
    {
        if (ModelState.IsValid)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads/entertainment");
                Directory.CreateDirectory(folderPath); // Ensure the directory exists

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                string filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                entertainment.ImageUrl = "/uploads/entertainment/" + fileName;
            }

            _entertainmentService.AddEntertainment(entertainment);
            return RedirectToAction(nameof(Index));
        }

        return View(entertainment);
    }

    public IActionResult Edit(int id)
    {
        var entertainment = _entertainmentService.GetEntertainmentById(id);
        if (entertainment == null)
        {
            return NotFound();
        }
        return View(entertainment);
    }

    [HttpPost]
    public IActionResult Edit(Entertainment entertainment, IFormFile imageFile)
    {
        if (ModelState.IsValid)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads/entertainment");
                Directory.CreateDirectory(folderPath); // Ensure the directory exists

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                string filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                entertainment.ImageUrl = "/uploads/entertainment/" + fileName;
            }

            _entertainmentService.UpdateEntertainment(entertainment);
            return RedirectToAction(nameof(Index));
        }

        return View(entertainment);
    }

    public IActionResult Delete(int id)
    {
        var entertainment = _entertainmentService.GetEntertainmentById(id);
        if (entertainment == null)
        {
            return NotFound();
        }

        _entertainmentService.DeleteEntertainment(id);
        return RedirectToAction(nameof(Index));
    }



    public IActionResult ViewEntertainment(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var restaurant = _entertainmentService.GetEntertainmentById(id);

        if (restaurant == null)
        {
            return NotFound();
        }

        if (restaurant.Ratings != null && restaurant.Ratings.Any())
        {
            restaurant.AverageRating = restaurant.Ratings.Average(r => r.RatingValue);
        }

        bool isFavorite = false;
        if (userId != null)
        {
            isFavorite = _userFavoriteService.IsFavorite(userId, restaurant.Id, "Entertainment");
        }

        ViewBag.IsFavorite = isFavorite;

        return View(restaurant);
    }












    [HttpPost]
    public IActionResult AddRating(int entertainmentId, int ratingValue, string comment)
    {
        // Get the current user (assuming you're using Identity)
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        // Check if the rest exists
        var rest = _entertainmentService.GetEntertainmentById(entertainmentId);
        if (rest == null)
        {
            return NotFound();
        }

        // Create a new UserRating
        var rating = new UserRating
        {
            RatingValue = ratingValue,
            Comment = comment,
            EntertainmentId = entertainmentId,
            UserId = userId,

        };

        // Add the rating to the database (you may need to inject a service for handling ratings)
        _ratingService.AddRating(rating);

        // Optionally, recalculate the average rating for the rest
        if (rest.Ratings != null)
        {
            rest.AverageRating = rest.Ratings.Average(r => r.RatingValue);
        }
        else
        {
            rest.AverageRating = ratingValue;
        }
        _entertainmentService.UpdateEntertainment(rest);

        // Redirect back to the rest details page
        return RedirectToAction("ViewEntertainment", new { id = entertainmentId });
    }





    [HttpPost]
    public IActionResult ToggleFavorite(int entertainmentId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Retrieve the current user's ID

        if (userId == null)
        {
            return Unauthorized();
        }

        // Check if the rest is already favorited
        bool isFavorite = _userFavoriteService.IsFavorite(userId, entertainmentId, "Entertainment");

        if (isFavorite)
        {
            // Retrieve the specific UserFavorite entity to remove it
            var existingFavorite = _userFavoriteService.GetFavoriteByUserAndPlace(userId, entertainmentId, "Entertainment");
            if (existingFavorite != null)
            {
                _userFavoriteService.RemoveFromFavourite(existingFavorite);
            }
        }
        else
        {
            // Add to favorites using the service
            var newFavorite = new UserFavorite
            {
                UserId = userId,
                EntertainmentId = entertainmentId
            };
            _userFavoriteService.AddToFavourite(newFavorite);
        }

        return Json(new { isFavorite = !isFavorite });
    }










}