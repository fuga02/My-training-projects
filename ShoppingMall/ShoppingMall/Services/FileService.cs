namespace ShoppingMall.Services;

public class FileService
{
    private const string Wwwroot = "wwwroot";

    private static void CheckDirectory(string folder)
    {
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);
    }


    public static async Task<string> SaveProductImage(IFormFile file)
    {
        return await SaveFile(file, "ProductImages");
    }

    private static async Task<string> SaveFile(IFormFile file, string folder)
    {
        CheckDirectory(folder);
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var ms = new MemoryStream();
        await file.CopyToAsync(ms);
        await File.WriteAllBytesAsync(Path.Combine(Wwwroot, folder, fileName), ms.ToArray());
        return $"/{folder}/{fileName}";
    }
}