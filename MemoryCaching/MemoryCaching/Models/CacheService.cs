namespace MemoryCaching.Models;

public class CacheService
{
    public  Dictionary<string,Tuple<DateTime?, object>> CacheDictionary = new Dictionary<string,Tuple<DateTime?, object>>();

    public void Set(string key, object value, DateTime? expires = null)
    {
       CacheDictionary.Add(key, new (expires,value));
    }

    public bool TryGetValue(string key, out object? value)
    {
        value = null;
        if (CacheDictionary.TryGetValue(key, out var smth))
        {
            if (smth.Item1 <= DateTime.Now)
            {
                CacheDictionary.Remove(key);
                return false;
            }
            value = smth?.Item2;
            return true;
        }

        return false;
    }
}