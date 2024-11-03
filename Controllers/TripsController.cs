using Jawlaty.Models.Trips;
using Jawlaty.Services;
using Jawlaty.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Jawlaty.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService _service;
        private readonly IQuestionService _questionService;
        public TripsController(ITripsService service, IQuestionService questionService)
        {
            _service = service;
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetTrips());
        }
        [HttpGet]
        public async Task<IActionResult> Details(int ID)
        {
            var Trips = await _service.GetByID(ID);
            if (Trips.ID is 0)
            {
                return NotFound();
            }
            return View(Trips);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var question = (await _questionService.GetQuestion()).ToList();
            Trips tripsobj = new()
            {
                QuestionOne = question[0].Text,
                QuestionTwo = question[1].Text,
                QuestionThree = question[2].Text,
                QuestionFour = question[3].Text,
                HasChlidren=false
            };
            var model = new TripsViewModel
            {
                WithtravelingOptions = Enum.GetValues(typeof(Withtraveling))
          .Cast<Withtraveling>()
          .Select(e => new SelectListItem
          {
              Value = ((int)e).ToString(),
              Text = e.ToString()
          })
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Trips trips)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                var model = new TripsViewModel();
                model.WithtravelingOptions = Enum.GetValues(typeof(Withtraveling))
       .Cast<Withtraveling>()
       .Select(e => new SelectListItem
       {
           Value = ((int)e).ToString(),
           Text = e.ToString()
       });
                await _service.AddTrips(trips);
            }
            catch (Exception ex)
            {

                BadRequest(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int ID)
        {
            Trips trips = await _service.GetByID(ID);
            if (trips.ID is 0)
            {
                return NotFound();
            }
            var question = (await _questionService.GetQuestion()).ToList();
            trips.QuestionOne = question[0].Text;
            trips.QuestionTwo = question[1].Text;
            trips.QuestionThree = question[2].Text;
            trips.QuestionFour = question[3].Text;
            return View(trips);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Trips trips)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            try
            {
               await _service.UpdateTrips(trips);
            }
            catch (Exception ex)
            {

                BadRequest(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int ID)
        {
            var Trips = await _service.GetByID(ID);
            if (Trips.ID is 0)
                return NotFound();

            return View(Trips);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int ID)
        {
            try
            {
                var Trips = await _service.GetByID(ID);
                if (Trips.ID is 0)
                    return NotFound();
                await _service.DeleteTrips(ID);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
