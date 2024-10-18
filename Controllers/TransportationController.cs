using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jawlaty.Auth.Services;
using Jawlaty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Jawlaty.Controllers
{
    public class TransportationController : Controller
    {

        private IUser _userService;
    
        private readonly ITransportationService _transportationService;
        private readonly ICityService _cityService;



        public TransportationController(IUser userService, 
            ITransportationService transportationService, ICityService cityService)
        {
            _userService = userService;
            _transportationService = transportationService;
            _cityService = cityService;
        }




        public IActionResult Index()
        {
            ViewBag.Cities = new SelectList(_cityService.GetAllCities(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult GetTransportationsByCity(int cityId)
        {
            var transportations = _transportationService.GetTransportationByCityId(cityId);

            if (transportations == null || !transportations.Any())
            {
                ViewBag.Message = "No articles found for the selected city.";
                return View("TransportationsList", new List<Transportation>());
            }

            return View("TransportationsList", transportations);
        }



        public IActionResult ViewTransportation(int id)
        {
            var transportation = _transportationService.GetTransportationById(id);
            if (transportation == null)
            {
                return NotFound();
            }
            return View("ViewTransportation", transportation);
        }











    }
}