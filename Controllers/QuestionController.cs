using Jawlaty.Models;
using Jawlaty.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jawlaty.Controllers;

public class QuestionController : Controller
{
    private readonly IQuestionService _service;

    public QuestionController(IQuestionService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _service.GetQuestion());
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Question question)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        try
        {
            await _service.AddQuestion(question);
        }
        catch (Exception ex)
        {

            return BadRequest(ex);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var question = await _service.GetByID(id);
        if(question.ID is 0)
        {
            return NotFound();
        }
        return View(question);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Question question)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        try
        {
            await _service.UpdateQuestion(question);
        }
        catch (Exception ex)
        {

            BadRequest(ex);
        }
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Details(int ID)
    {
        var question = await _service.GetByID(ID);
        if (question.ID is 0)
        {
            return NotFound();
        }
        return View(question);
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int ID)
    {
        var question = await _service.GetByID(ID);
        if(question.ID is 0)
            return NotFound();
        
        return View(question);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
   public async Task<IActionResult> ConfirmDelete(int ID)
    {
        try
        {
            var question = await _service.GetByID(ID);
            if (question.ID is 0)
                return NotFound();
            await _service.DeleteQuestion(ID);
        }
        catch (Exception ex)
        {

           return BadRequest(ex);
        }
        return RedirectToAction(nameof(Index));

    }
}
