using Task.Entities;

namespace Task.Models;

public class CreateQuestionModel
{
    public string Title { get; set; }
    public List<Choice> Choices { get; set; } 
    public MediaModel Media { get; set; }
    
}