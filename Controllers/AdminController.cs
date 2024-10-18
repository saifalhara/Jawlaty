using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Jawlaty.Auth.Services;
using Jawlaty.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Jawlaty.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private readonly IAnnouncementService _announcement;
        private IUser _userService;
        private readonly IHotelService _hotelService;
        private readonly IRestaurantService _restaurant;

        private readonly IEntertainmentService _entertainment;
        private readonly ITransportationService _transportationService;

        private readonly ICityService _cityService;
        


        public AdminController( IUser userService, IAnnouncementService announcement,
            IHotelService hotelService, IRestaurantService restaurant, IEntertainmentService entertainment, ITransportationService transportationService, ICityService cityService)
        {
            _announcement = announcement;
            _userService = userService;
            _hotelService = hotelService;
            _restaurant = restaurant;
            _entertainment = entertainment;
            _transportationService = transportationService;
            _cityService = cityService;
        }


        public IActionResult Index()
        {
            return View();
        }


   
        public IActionResult Announcement()
        {
            var announcements = _announcement.GetAllAnnouncements();

            return View("Announcements/Announcement", announcements);
        }

        public IActionResult CreateAnnouncement()
        {
            return View("Announcements/CreateAnnouncement");
        }



        [HttpPost]
        public async Task<IActionResult> CreateAnnouncement(Announcement announcement, IFormFile ImageFile)
        {
            
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    // Save file to wwwroot/uploads
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    if (!Directory.Exists(uploads))
                    {
                        Directory.CreateDirectory(uploads);
                    }

                    var filePath = Path.Combine(uploads, ImageFile.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    announcement.ImageUrl = $"/uploads/{ImageFile.FileName}";
                }

                await _announcement.CreateAnnouncement(announcement);
                return RedirectToAction("Announcement"); 
           
            return View(announcement);
        }


        public async Task<IActionResult> EditAnnouncement(int id)
        {
            var announcement = await _announcement.GetAnnouncementById(id);
            if (announcement == null)
            {
                return NotFound();
            }
            return View("Announcements/EditAnnouncement",announcement);
        }



        public async Task<IActionResult> AnnouncementDetails(int id)
        {
            var announcement = await _announcement.GetAnnouncementById(id);
            if (announcement == null)
            {
                return NotFound();
            }
            return View("Announcements/AnnouncementDetails", announcement);
        }

     


        [HttpPost]
        public async Task<IActionResult> EditAnnouncement(int id, Announcement announcement, IFormFile imageFile)
        {
            if (id != announcement.Id)
            {
                return NotFound();
            }

         

            if (imageFile != null && imageFile.Length > 0)
            {
                try
                {
                    // Save file to wwwroot/uploads
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    var filePath = Path.Combine(uploads, imageFile.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    announcement.ImageUrl = $"/uploads/{imageFile.FileName}";
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while uploading the image.");
                    return View(announcement);
                }
            }
            else
            {
                ModelState.AddModelError("ImageFile", "Please upload an image.");
                return View(announcement);
            }

            try
            {
                await _announcement.UpdateAnnouncement(announcement);
                TempData["SuccessMessage"] = "Announcement updated successfully!";
                return RedirectToAction("Announcement");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while updating the announcement.");
                return View(announcement);
            }
        }






        public async Task<IActionResult> DeleteItem(int id, string type)
        {
            if (type == "announcement")
            {
                var announcement = await _announcement.GetAnnouncementById(id);
                if (announcement == null)
                {
                    return NotFound();
                }
                return View("Announcement", announcement);
            }
            else if (type == "hotel")
            {
                var hotel = _hotelService.GetHotelById(id);
                if (hotel == null)
                {
                    return NotFound();
                }
                return View("Hotels", hotel);
            }
            else if (type == "restaurant")
            {
                var restaurant = _restaurant.GetRestaurantById(id);
                if (restaurant == null)
                {
                    return NotFound();
                }
                return View("Restaurants", restaurant);
            }
            else if (type == "entertainment")
            {
                var entertainment = _entertainment.GetEntertainmentById(id);
                if (entertainment == null)
                {
                    return NotFound();
                }
                return View("Entertainments", entertainment);
            }
            else if (type == "transportation")
            {
                var transportation = _transportationService.GetTransportationById(id);
                if (transportation == null)
                {
                    return NotFound();
                }
                return View("Transportations/DeleteTransportation", transportation);
            }

            return BadRequest("Something went wrong!");
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteItemConfirmed(int id, string type)
        {
            if (type == "announcement")
            {
                await _announcement.DeleteAnnouncement(id);
                return RedirectToAction("Announcement");
            }
            else if (type == "hotel")
            {
                _hotelService.DeleteHotel(id);
                return RedirectToAction("Hotels");
            }
            else if (type == "restaurant")
            {
                _restaurant.DeleteRestaurant(id);
                return RedirectToAction("Restaurants");
            }
            else if (type == "entertainment")
            {
                 _entertainment.DeleteEntertainment(id);
                return RedirectToAction("Entertainments");

            }
            else if (type == "transportation")
            {
                _transportationService.DeleteTransportation(id);
                return RedirectToAction("Transportations");

            }
            return BadRequest("Something went wrong!");
        }






        public IActionResult Hotels()
        {
            var hotels = _hotelService.GetAllHotels();

            return View("Hotels/Hotels", hotels);
        }



        public IActionResult CreateHotel()
        {
            return View("Hotels/CreateHotel");
        }


        public IActionResult HotelDetails(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View("Hotels/HotelDetails", hotel);  
        }



        [HttpPost]
        public ActionResult CreateHotel(Hotel hotel, IFormFile ImageFile)
        {
            // Check if ImageFile is null or empty
            if (ImageFile == null || ImageFile.Length == 0)
            {
                // Add error to ModelState and return to the view
                ModelState.AddModelError("ImageFile", "Please upload an image.");
                return View("Hotels/CreateHotel", hotel);
            }

            try
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }

                var filePath = Path.Combine(uploads, ImageFile.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }

                hotel.ImageUrl = $"/uploads/{ImageFile.FileName}";

                _hotelService.AddHotel(hotel);

                TempData["SuccessMessage"] = "Hotel created successfully!";
                return RedirectToAction("Hotels");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while creating the hotel.");
                return View("Hotels/CreateHotel", hotel);
            }
        }


        public IActionResult EditHotel(int id)
        {
            var hotel =  _hotelService.GetHotelById(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View("Hotels/EditHotel", hotel);
        }


        [HttpPost]
        public IActionResult EditHotel(int id, Hotel hotel, IFormFile imageFile)
        {
            if (id != hotel.Id)
            {
                return NotFound();
            }

            if (imageFile == null || imageFile.Length == 0)
            {
                ModelState.AddModelError("ImageFile", "Please upload an image.");
                return View("Hotels/EditHotel", hotel);
            }

            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    var filePath = Path.Combine(uploads, imageFile.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    hotel.ImageUrl = $"/uploads/{imageFile.FileName}";
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while uploading the image.");
                return View("Hotels/EditHotel", hotel);
            }

            try
            {
                _hotelService.UpdateHotel(hotel);
                TempData["SuccessMessage"] = "Hotel updated successfully!";
                return RedirectToAction("Hotels");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while updating the hotel.");
                return View("Hotels/EditHotel", hotel);
            }
        }





  


        //Restaurant



        public IActionResult Restaurants()
        {
            var res = _restaurant.GetAllRestaurants();

            return View("Restaurants/Restaurants", res);
        }



        public IActionResult CreateRestaurant()
        {
            return View("Restaurants/CreateRestaurant");
        }




        [HttpPost]
        public ActionResult CreateRestaurant(Restaurant restaurant, IFormFile ImageFile)
        {
            // Check if ImageFile is null or empty
            if (ImageFile == null || ImageFile.Length == 0)
            {
                ModelState.AddModelError("ImageFile", "Please upload an image.");
                return View("Restaurants/CreateRestaurant", restaurant);
            }

            try
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }

                var filePath = Path.Combine(uploads, ImageFile.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }

                restaurant.ImageUrl = $"/uploads/{ImageFile.FileName}";

                _restaurant.AddRestaurant(restaurant);

                TempData["SuccessMessage"] = "Hotel created successfully!";
                return RedirectToAction("Restaurants");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while creating the hotel.");
                return View("Restaurants/CreateRestaurant", restaurant);
            }
        }


        public IActionResult EditRestaurant(int id)
        {
            var hotel = _restaurant.GetRestaurantById(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View("Restaurants/EditRestaurant", hotel);
        }





        [HttpPost]
        public IActionResult EditRestaurant(int id, Restaurant restaurant, IFormFile imageFile)
        {
            if (id != restaurant.Id)
            {
                return NotFound();
            }

            if (imageFile == null || imageFile.Length == 0)
            {
                ModelState.AddModelError("ImageFile", "Please upload an image.");
                return View("Restaurants/EditRestaurant", restaurant);
            }

            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    var filePath = Path.Combine(uploads, imageFile.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    restaurant.ImageUrl = $"/uploads/{imageFile.FileName}";
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while uploading the image.");
                return View("Restaurants/EditRestaurant", restaurant);
            }

            try
            {
                _restaurant.UpdateRestaurant(restaurant);
                TempData["SuccessMessage"] = "Item updated successfully!";
                return RedirectToAction("Restaurants");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while updating the restaurant.");
                return View("Restaurants/EditRestaurant", restaurant);
            }
        }


        public IActionResult RestaurantDetails(int id)
        {
            var restaurant = _restaurant.GetRestaurantById(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View("Restaurants/RestaurantDetails", restaurant);
        }





        //Entertainment




        public IActionResult Entertainments()
        {
            var res = _entertainment.GetAllEntertainments();

            return View("Entertainments/Entertainments", res);
        }



        public IActionResult CreateEntertainment()
        {
            return View("Entertainments/CreateEntertainment");
        }



        [HttpPost]
        public ActionResult CreateEntertainment(Entertainment entertainment, IFormFile ImageFile)
        {
            // Check if ImageFile is null or empty
            if (ImageFile == null || ImageFile.Length == 0)
            {
                ModelState.AddModelError("ImageFile", "Please upload an image.");
                return View("Entertainments/CreateEntertainment", entertainment);
            }

            try
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }

                var filePath = Path.Combine(uploads, ImageFile.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }

                entertainment.ImageUrl = $"/uploads/{ImageFile.FileName}";

                _entertainment.AddEntertainment(entertainment);

                TempData["SuccessMessage"] = "Entertainment created successfully!";
                return RedirectToAction("Entertainments");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while creating the entertainment.");
                return View("Entertainments/CreateEntertainment", entertainment);
            }
        }



        public IActionResult EditEntertainment(int id)
        {
            var hotel = _entertainment.GetEntertainmentById(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View("Entertainments/EditEntertainment", hotel);
        }







        [HttpPost]
        public IActionResult EditEntertainment(int id, Entertainment entertainment, IFormFile imageFile)
        {
            if (id != entertainment.Id)
            {
                return NotFound();
            }

            if (imageFile == null || imageFile.Length == 0)
            {
                ModelState.AddModelError("ImageFile", "Please upload an image.");
                return View("Entertainments/EditEntertainment", entertainment);
            }

            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    var filePath = Path.Combine(uploads, imageFile.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    entertainment.ImageUrl = $"/uploads/{imageFile.FileName}";
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while uploading the image.");
                return View("Entertainments/EditEntertainment", entertainment);
            }

            try
            {
                _entertainment.UpdateEntertainment(entertainment);
                TempData["SuccessMessage"] = "Item updated successfully!";
                return RedirectToAction("Entertainments");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while updating the entertainment.");
                return View("Entertainments/EditEntertainmen", entertainment);
            }
        }


        public IActionResult EntertainmentDetails(int id)
        {
            var restaurant = _entertainment.GetEntertainmentById(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View("Entertainments/EntertainmentDetails", restaurant);
        }











        //Transportations


        public IActionResult Transportations()
        {
            var transportations = _transportationService.GetAllTransportations();
            return View("Transportations/Transportations", transportations);
        }

        public IActionResult CreateTransportation()
        {
            ViewBag.Cities = _cityService.GetAllCities();

            return View("Transportations/CreateTransportation");
        }

        [HttpPost]
        public IActionResult CreateTransportation(Transportation transportation)
            {
            //if (ModelState.IsValid)
            //{
                _transportationService.AddTransportation(transportation);
                return RedirectToAction("Transportations");
            //}
            return View(transportation);
        }

        public IActionResult EditTransportation(int id)
        {
           
            var transportation = _transportationService.GetTransportationById(id);
            if (transportation == null)
            {
                return NotFound();
            }
            var cities = _cityService.GetAllCities();
            ViewBag.Cities = new SelectList(cities, "Id", "Name", transportation.CityId);

            return View("Transportations/EditTransportation", transportation);
        }

        [HttpPost]
        public IActionResult EditTransportation(int id, Transportation transportation)
        {

            if (id != transportation.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                _transportationService.UpdateTransportation(transportation);
                TempData["SuccessMessage"] = "Transportation updated successfully!";
                return RedirectToAction("Transportations");
            //}

            return View(transportation);
        }

        public IActionResult TransportationDetails(int id)
        {
            var transportation = _transportationService.GetTransportationById(id);
            if (transportation == null)
            {
                return NotFound();
            }
            return View("Transportations/TransportationDetails", transportation);
        }

















    }
}