
Dictionary<string, string> map = new Dictionary<string, string>();
map.Add("maktab","school");
map.Add("maktab1","school1");
map.Add("maktab2","school2");

Check(map);





void Check(Dictionary<string,string> dictionaries)
{
    Console.Write("Sozni kiriting >>>");
    string word = Console.ReadLine()!;
    if (dictionaries.ContainsValue(word))
    {
        foreach (var key in dictionaries.Keys)
        {
            if (dictionaries[key] == word)
            {
                Console.WriteLine($"key : {key}");
            }
        }
    }
    else
    {
        Console.WriteLine("bunday qiymat yuq");
    }
}