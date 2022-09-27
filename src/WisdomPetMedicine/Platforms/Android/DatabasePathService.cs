namespace WisdomPetMedicine.Services;
public class DatabasePathService : IDatabasePathService
{
    public string Get(string filename)
    {
        var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return Path.Combine(folderPath, filename);
    }
}