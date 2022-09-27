using CommunityToolkit.Mvvm.ComponentModel;
using WisdomPetMedicine.DataAccess;

namespace WisdomPetMedicine.ViewModels;
public partial class DashboardViewModel : ViewModelBase
{
    [ObservableProperty]
    int visits;

    [ObservableProperty]
    int clients;

    [ObservableProperty]
    decimal totalAmount;

    [ObservableProperty]
    int totalProducts;

    public DashboardViewModel(WpmOutDbContext outDbContext)
    {
        var db = new WpmDbContext();
        Visits = outDbContext.Sales
            .ToList()
            .DistinctBy(s => s.ClientId)
            .ToList()
            .Count();
        Clients = db.Clients.Count();
        TotalAmount = outDbContext.Sales.ToList().Sum(s => s.Quantity * s.Price);
        TotalProducts = outDbContext.Sales.Sum(s => s.Quantity);
    }
}