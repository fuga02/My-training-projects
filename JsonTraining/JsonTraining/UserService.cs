
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace JsonTraining;

public class UserService
{
    public List<User> Users = new List<User>();

    

    public void Write()
    {
        string jsonString = JsonConvert.SerializeObject(Users);
        File.WriteAllText("data.json",jsonString);
    }

    public void Read()
    {
        string jsonString = File.ReadAllText("data.json");
        Users = JsonConvert.DeserializeObject<List<User>>(jsonString)!;
    }
}