using Task.Entities;
using Task.FileHelper;
using Task.Models;
using Task.Repositories;

namespace Task.Managers;

public class QuestionManager
{
    private readonly IQuestion _questionRepository;

    public QuestionManager(IQuestion questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<List<Question>> GetQuestions()
    {
        return await _questionRepository.GetQuestions();
    }

    public async Task<Question> GetQuestionById(int id)
    {
        if(id == null) return null;
        var question =  await _questionRepository.GetQuestionById(id);
        return question;

    }

    public async Task<Question> AddQuestion(CreateQuestionModel model)
    {
        var question = ParseToQuestion(model);
        await _questionRepository.AddQuestion(await question);
        return await question;
    }

    public async Task<Question> UpdateQuestion(CreateQuestionModel model, int questionId)
    {
        var question = await _questionRepository.GetQuestionById(questionId);
        if (question != null)
        {
            question = await ParseToQuestion(model);
           await  _questionRepository.UpdateQuestion(question);
           return question;
        }

        return null;
    }

    public async System.Threading.Tasks.Task<string> DeleteQuestion(int id)
    {
        var question = await _questionRepository.GetQuestionById(id);
        if (question != null)
        {
            await _questionRepository.DeleteQuestion(id);
            return "Success";
        }

        return "Not found";
    }


    private async Task<Question> ParseToQuestion(CreateQuestionModel model)
    {
        int maxId = 0;
        var questions =  await _questionRepository.GetQuestions();

        if (questions is { Count: > 0 })
        {
            maxId = questions.Max(c => c.QuestionId);
            maxId = maxId + 1;
        }
        var question = new Question()
        {
            QuestionId = maxId,
            Title = model.Title,
            Choices = model.Choices.Select(c=> new Choice()
            {
                Text = c.Text,
                Answer = c.Answer,
            }).ToList(),
        };
        if (IsExist(model.Media.PhotoFile))
        {
            question.Media = new Media()
            {
                PhotoId = WorkWithFiles.QuestionImages(model.Media.PhotoFile, question.QuestionId),
                Exist = true
            };
        }
        else
        {
            question.Media = new Media() {Exist = false};
        }
        return question;
    }


    private bool IsExist(IFormFile? file)
    {
        return file != null;
    }
}