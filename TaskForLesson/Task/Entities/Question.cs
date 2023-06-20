using MongoDB.Bson.Serialization.Attributes;

namespace Task.Entities;

public class Question
{
    [BsonId]
    public int QuestionId { get; set; }
    public string Title { get; set; }
    public List<Choice> Choices { get; set; } 
    public Media Media { get; set; }
    
}