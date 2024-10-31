using Jawlaty.Models;
using Jawlaty.Services;
using Jawlaty.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Jawlaty.Controllers
{
    public class VenueController : Controller
    {
        private readonly IVenueService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICityService _cityService;
        public VenueController(IVenueService service, IWebHostEnvironment webHostEnvironment, ICityService cityService)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Venue = await _service.GetAllVenue();
            return View(Venue);
        }

        [HttpGet]
        public async Task<IActionResult> IndexAdmin()
        {
            var Venue = await _service.GetAllVenue();
            return View(Venue);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var city = _cityService.GetAllCities().ToList();
            CreateVenue createVenue = new()
            {
                Citys = city.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).OrderBy(x => x.Text)
            };
            return View(createVenue);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVenue CreateVenu, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                var city = _cityService.GetAllCities().ToList();
                CreateVenue createVenue = new()
                {
                    Citys = city.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).OrderBy(x => x.Text)
                };
                return View(createVenue);
            }
            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads/venue");
                    Directory.CreateDirectory(folderPath); // Ensure the directory exists

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    string filePath = Path.Combine(folderPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }
                    CreateVenu.ImageUrl = $"/uploads/venue/{fileName}";
                }
                Venue venue = new()
                {
                    ArName = CreateVenu.ArName,
                    EnName = CreateVenu.EnName,
                    CityID = CreateVenu.CityID,
                    Description = CreateVenu.Description,
                    ImageUrl = CreateVenu.ImageUrl,
                    Title = CreateVenu.Title,
                    VenueType = CreateVenu.VenueType,
                };
                await _service.AddVenue(venue);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> Details(int ID)
        {
            var Venue = await _service.GetByID(ID);
            if (Venue is null)
            {
                return NotFound();
            }
            return View(Venue);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Venue venue = await _service.GetByID(id);
            var cityname = _cityService.GetCityById(venue.CityID);
            venue.CityName = cityname.Name;
            if (venue is null)
            {
                return NotFound();
            }
            return View(venue);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Venue venue, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(venue);
            }
            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads/venue");
                    Directory.CreateDirectory(folderPath); // Ensure the directory exists

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    string filePath = Path.Combine(folderPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }
                    venue.ImageUrl = $"uploads/venue{fileName}";
                }

                await _service.UpdateVenue(venue);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpGet]
        public async Task<IActionResult> DetailsAdmin(int ID)
        {
            var Venue = await _service.GetByID(ID);
            if (Venue is null)
            {
                return NotFound();
            }
            return View(Venue);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailsAdminApproved(Venue venue)
        {
            try
            {
                Venue Venueobj = await _service.GetByID(venue.ID);
                Venueobj.Succsed = true;
                await _service.UpdateVenue(Venueobj);
                await _service.ApprovedVenue(Venueobj);
            }
            catch (Exception ex)
            {

                return View(ex);
            }
            return RedirectToAction(nameof(IndexAdmin));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailsAdminNonApproved(Venue venue)
        {
            try
            {

                Venue Venueobj = await _service.GetByID(venue.ID);
                Venueobj.Succsed = false;
                await _service.UpdateVenue(Venueobj);
            }
            catch (Exception ex)
            {

                return View(ex);
            }
            return RedirectToAction(nameof(IndexAdmin));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteVenue(int id)
        {
            Venue venue = await _service.GetByID(id);
            var cityname = _cityService.GetCityById(venue.CityID);
            venue.CityName = cityname.Name;
            if (venue is null)
            {
                return NotFound();
            }
            return View(venue);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>ConfirmDelete(int Id)
        {
            try
            {
                await _service.DeleteVenue(Id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteVenueAdmin(int id)
        {
            Venue venue = await _service.GetByID(id);
            var cityname = _cityService.GetCityById(venue.CityID);
            venue.CityName = cityname.Name;
            if (venue is null)
            {
                return NotFound();
            }
            return View(venue);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDeleteAdmin(int Id)
        {
            try
            {
                await _service.DeleteVenue(Id);
                return RedirectToAction(nameof(IndexAdmin));
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}
