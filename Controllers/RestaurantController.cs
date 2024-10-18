using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Jawlaty.Models;
using Jawlaty.Services.Rating;
using Microsoft.AspNetCore.Mvc;


    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IRatingService _ratingService;
    private readonly IUserFavoriteService _userFavoriteService;


        public RestaurantController(IRestaurantService restaurantService,
        IWebHostEnvironment webHostEnvironment , IRatingService ratingService, IUserFavoriteService userFavoriteService)
        {
            _restaurantService = restaurantService;
            _webHostEnvironment = webHostEnvironment;
            _ratingService = ratingService;
            _userFavoriteService = userFavoriteService;
        }

   

        public IActionResult Index()
    {
        var restaurants = _restaurantService.GetAllRestaurants();
        foreach (var res in restaurants)
        {
            if (res.Ratings != null && res.Ratings.Any())
            {
                res.AverageRating = res.Ratings.Average(r => r.RatingValue);
            }
            else
            {
                res.AverageRating = 0; // Or handle it as "no rating"
            }
        }

        return View(restaurants);
    }



        public IActionResult ViewRestaurant(int id)
        {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var restaurant = _restaurantService.GetRestaurantById(id);

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
            isFavorite = _userFavoriteService.IsFavorite(userId, restaurant.Id, "Restaurant");
        }

        ViewBag.IsFavorite = isFavorite;

        return View(restaurant);
        }



   

    public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Restaurant restaurant, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads/restaurants");
                    Directory.CreateDirectory(folderPath); // Ensure the directory exists

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    string filePath = Path.Combine(folderPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    restaurant.ImageUrl = "/uploads/restaurants/" + fileName;
                }

          //      _restaurantService.AddRestaurant(restaurant);
                return RedirectToAction(nameof(Index));
            }

            return View(restaurant);
        }

        public IActionResult Edit(int id)
        {
            var restaurant = _restaurantService.GetRestaurantById(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        [HttpPost]
        public IActionResult Edit(Restaurant restaurant, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads/restaurants");
                    Directory.CreateDirectory(folderPath); // Ensure the directory exists

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    string filePath = Path.Combine(folderPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    restaurant.ImageUrl = "/uploads/restaurants/" + fileName;
                }

             //   _restaurantService.UpdateRestaurant(restaurant);
                return RedirectToAction(nameof(Index));
            }

            return View(restaurant);
        }

        public IActionResult Delete(int id)
        {
            var restaurant = _restaurantService.GetRestaurantById(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _restaurantService.DeleteRestaurant(id);
            return RedirectToAction(nameof(Index));
        }









    [HttpPost]
    public IActionResult AddRating(int restId, int ratingValue, string comment)
    {
        // Get the current user (assuming you're using Identity)
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        // Check if the rest exists
        var rest = _restaurantService.GetRestaurantById(restId);
        if (rest == null)
        {
            return NotFound();
        }

        // Create a new UserRating
        var rating = new UserRating
        {
            RatingValue = ratingValue,
            Comment = comment,
            RestaurantId = restId,
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
        _restaurantService.UpdateRestaurant(rest);

        // Redirect back to the rest details page
        return RedirectToAction("ViewRestaurant", new { id = restId });
    }



    [HttpPost]
    public IActionResult ToggleFavorite(int restId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Retrieve the current user's ID

        if (userId == null)
        {
            return Unauthorized();
        }

        // Check if the rest is already favorited
        bool isFavorite = _userFavoriteService.IsFavorite(userId, restId, "Restaurant");

        if (isFavorite)
        {
            // Retrieve the specific UserFavorite entity to remove it
            var existingFavorite = _userFavoriteService.GetFavoriteByUserAndPlace(userId, restId, "Restaurant");
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
                RestaurantId = restId
            };
            _userFavoriteService.AddToFavourite(newFavorite);
        }

        return Json(new { isFavorite = !isFavorite });
    }












}