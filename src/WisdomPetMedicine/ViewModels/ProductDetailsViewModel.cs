using CommunityToolkit.Mvvm.ComponentModel;
using WisdomPetMedicine.DataAccess;

namespace WisdomPetMedicine.ViewModels;
public partial class ProductDetailsViewModel : ViewModelBase, IQueryAttributable
{
    [ObservableProperty]
    string name;
    
    [ObservableProperty]
    string description;

    [ObservableProperty]
    decimal price;
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var dbContext = new WpmDbContext();
        var product = dbContext.Products.First(p => p.Id == int.Parse(query["id"].ToString()));
        Name = product.Name;
        Description = product.Description;
        Price = product.Price;
    }
}