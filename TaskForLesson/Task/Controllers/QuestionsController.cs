using Microsoft.AspNetCore.Mvc;
using Task.Managers;
using Task.Models;

namespace Task.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionsController : ControllerBase
{
    private readonly QuestionManager _questionManager;

    public QuestionsController(QuestionManager questionManager)
    {
        _questionManager = questionManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetQuestions()
    {
        return Ok(await _questionManager.GetQuestions());
    }

    [HttpGet("{questionId}")]
    public async Task<IActionResult> GetQuestion(int questionId)
    {
        return Ok(await _questionManager.GetQuestionById(questionId));
    }

    [HttpPost]
    public async Task<IActionResult> AddQuestion([FromForm] CreateQuestionModel model)
    {
        return Ok(await _questionManager.AddQuestion(model));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateQuestion([FromForm] CreateQuestionModel model, int questionId)
    {
        return Ok(await _questionManager.UpdateQuestion(model, questionId));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteQuestion(int questionI)
    {
        return Ok(await _questionManager.DeleteQuestion(questionI));
    }
}