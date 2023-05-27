using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json;
using WebApi.Entities;

namespace WebApi.Database;

public class DataService
{
    private readonly IConfiguration _configuration;
    public List<User> Users = new List<User>();

    private string FileName => _configuration.GetValue<string>("DataBase:FileName")!;
    public DataService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void SaveData()
    {
        if (!File.Exists(FileName))
        {
            File.Create(FileName);
        }
        var json =  JsonConvert.SerializeObject(Users);
        File.WriteAllText(FileName, json);

    }

    public void ReadData()
    {
        var file = File.ReadAllText(FileName);
        Users = JsonConvert.DeserializeObject<List<User>>(file)!;
    }
}