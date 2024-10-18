using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Jawlaty.Auth.Services;
using Jawlaty.Controllers;
using Jawlaty.Models;
using Jawlaty.Services.Rating;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


public class HotelController : Controller
{

    private readonly IHotelService _hotelService;
    private readonly IRatingService _ratingService;
    private readonly IUserFavoriteService _userFavoriteService;
    private readonly IUser _userService;

    private readonly IWebHostEnvironment _webHostEnvironment;
    
public HotelController(IHotelService hotelService, IWebHostEnvironment webHostEnvironment,
    IRatingService ratingService, IUserFavoriteService userFavoriteService, IUser userService)
{
    _hotelService = hotelService;
    _webHostEnvironment = webHostEnvironment;
    _ratingService = ratingService;
    _userFavoriteService = userFavoriteService;
        _userService = userService;
}

public IActionResult Index()
{
    var hotels = _hotelService.GetAllHotels();
        // For each hotel, calculate the average rating
        foreach (var hotel in hotels)
        {
            if (hotel.Ratings != null && hotel.Ratings.Any())
            {
                hotel.AverageRating = hotel.Ratings.Average(r => r.RatingValue);
            }
            else
            {
                hotel.AverageRating = 0; // Or handle it as "no rating"
            }
        }

        return View(hotels);
}




    public IActionResult ViewHotel(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var hotel = _hotelService.GetHotelById(id);

        if (hotel == null)
        {
            return NotFound();
        }

        if (hotel.Ratings != null && hotel.Ratings.Any())
        {
            hotel.AverageRating = hotel.Ratings.Average(r => r.RatingValue);
        }


        // Check if the hotel is a favorite for the current user
        bool isFavorite = false;
        if (userId != null)
        {
            isFavorite = _userFavoriteService.IsFavorite(userId, hotel.Id, "Hotel");
        }

        // Pass the favorite status using ViewData
        ViewBag.IsFavorite = isFavorite;

        return View(hotel);

    }


    public IActionResult Create()
{
    return View();
}

[HttpPost]
public IActionResult Create(Hotel hotel, IFormFile imageFile)
{
    if (ModelState.IsValid)
    {
        if (imageFile != null && imageFile.Length > 0)
        {
            string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads/hotels");
            Directory.CreateDirectory(folderPath); // Ensure the directory exists

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            string filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }

           // hotel.ImageUrl = "/uploads/hotels/" + fileName;
        }

        _hotelService.AddHotel(hotel);
        return RedirectToAction(nameof(Index));
    }

    return View(hotel);
}

public IActionResult Edit(int id)
{
    var hotel = _hotelService.GetHotelById(id);
    if (hotel == null)
    {
        return NotFound();
    }
    return View(hotel);
}

[HttpPost]
public IActionResult Edit(Hotel hotel, IFormFile imageFile)
{
    if (ModelState.IsValid)
    {
        if (imageFile != null && imageFile.Length > 0)
        {
            string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads/hotels");
            Directory.CreateDirectory(folderPath); // Ensure the directory exists

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            string filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }

           // hotel.ImageUrl = "/uploads/hotels/" + fileName;
        }

        _hotelService.UpdateHotel(hotel);
        return RedirectToAction(nameof(Index));
    }

    return View(hotel);
}

public IActionResult Delete(int id)
{
    var hotel = _hotelService.GetHotelById(id);
    if (hotel == null)
    {
        return NotFound();
    }

    _hotelService.DeleteHotel(id);
    return RedirectToAction(nameof(Index));
}







    [HttpPost]
    public IActionResult AddRating(int hotelId, int ratingValue, string comment)
    {
        // Get the current user (assuming you're using Identity)
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        // Check if the hotel exists
        var hotel = _hotelService.GetHotelById(hotelId);
        if (hotel == null)
        {
            return NotFound();
        }

        // Create a new UserRating
        var rating = new UserRating
        {
            RatingValue = ratingValue,
            Comment = comment,
            HotelId = hotelId,
            UserId = userId,
            
        };

        // Add the rating to the database (you may need to inject a service for handling ratings)
        _ratingService.AddRating(rating);

        // Optionally, recalculate the average rating for the hotel
        if(hotel.Ratings != null) {
            hotel.AverageRating = hotel.Ratings.Average(r => r.RatingValue);
        }
        else
        {
            hotel.AverageRating = ratingValue;
        }
        _hotelService.UpdateHotel(hotel);

        // Redirect back to the hotel details page
        return RedirectToAction("ViewHotel", new { id = hotelId });
    }



    [HttpPost]
    public IActionResult ToggleFavorite(int hotelId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Retrieve the current user's ID

        if (userId == null)
        {
            return Unauthorized();
        }

        // Check if the hotel is already favorited
        bool isFavorite = _userFavoriteService.IsFavorite(userId, hotelId, "Hotel");

        if (isFavorite)
        {
            // Retrieve the specific UserFavorite entity to remove it
            var existingFavorite = _userFavoriteService.GetFavoriteByUserAndPlace(userId, hotelId, "Hotel");
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
                HotelId = hotelId
            };
            _userFavoriteService.AddToFavourite(newFavorite);
        }

        return Json(new { isFavorite = !isFavorite });
    }



}