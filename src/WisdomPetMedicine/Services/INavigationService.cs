namespace WisdomPetMedicine.Services;
public interface INavigationService
{
    Task GoToAsync(string uri);
    Task GoToAsync(string uri, IDictionary<string, object> parameters);
}