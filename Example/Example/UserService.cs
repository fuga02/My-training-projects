using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Example;

public class UserService
{
    public List<User> Users = new List<User>();

    public void Write()
    {
        var jsonString = JsonConvert.SerializeObject(Users);
        File.WriteAllText("data.json",jsonString);
    }

    public void Read()
    {
         string malumot = File.ReadAllText("data.json");
        Users = JsonConvert.DeserializeObject<List<User>>(malumot)!;
    }
}