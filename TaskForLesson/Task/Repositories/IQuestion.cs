using MongoDB.Driver;
using Task.Entities;


namespace Task.Repositories;

public interface IQuestion
{
    Task<List<Question>> GetQuestions();
    Task<Question> GetQuestionById(int id);
    System.Threading.Tasks.Task AddQuestion(Question question);
    System.Threading.Tasks.Task UpdateQuestion(Question question);
    System.Threading.Tasks.Task DeleteQuestion(int id);
}

public class QuestionRepository:IQuestion
{
    private IMongoCollection<Question> _questions;
    public QuestionRepository()
    {
        var client = new MongoClient("mongodb://mongo_db:asd12345@mongodb:27017");
        var database = client.GetDatabase("question_db");
        _questions = database.GetCollection<Question>("questions");
    }
    public async Task<List<Question>> GetQuestions()
    {
        return  await (_questions.Find(_ => true)).ToListAsync();
    }

    public async Task<Question> GetQuestionById(int id)
    {
        return await (await _questions.FindAsync(q => q.QuestionId == id))
            .FirstOrDefaultAsync();
    }

    public async System.Threading.Tasks.Task AddQuestion(Question question)
    {
        await _questions.InsertOneAsync(question);
    }

    public async System.Threading.Tasks.Task UpdateQuestion(Question question)
    {
        var filter = Builders<Question>.Filter.Eq(f => f.QuestionId, question.QuestionId);
        
        await _questions.ReplaceOneAsync(filter,question);
    }

    public async System.Threading.Tasks.Task DeleteQuestion(int id)
    {

        var filter = Builders<Question>.Filter.Eq(f => f.QuestionId, id);

        await _questions.DeleteOneAsync(filter);
    }
}