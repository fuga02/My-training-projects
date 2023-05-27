using System.Text.Json;

namespace JsonExample;

public class UserService
{
    public List<User> Users = new List<User>();

    public void Write()
    {
        var json = JsonSerializer.Serialize(Users);
        File.WriteAllText("data.json",json);
    }

    public void Read()
    {
        var json = File.ReadAllText("data.json");
        Users = JsonSerializer.Deserialize<List<User>>(json)!;
    }
}