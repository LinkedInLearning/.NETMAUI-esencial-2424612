namespace WisdomPetMedicine.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WisdomPetMedicine.DataAccess;
using WisdomPetMedicine.Models;

public partial class VisitDetailsViewModel : ViewModelBase
{
    public int ClientId { get; set; }

    [ObservableProperty]
    private ObservableCollection<Product> products;

    [ObservableProperty]
    private Product selectedProduct;

    [ObservableProperty]
    private int quantity;


    [ObservableProperty]
    private ObservableCollection<Sale> sales = new ObservableCollection<Sale>();

    public ICommand AddCommand { get; set; }

    public VisitDetailsViewModel()
    {
        var db = new WpmDbContext();
        Products = new ObservableCollection<Product>(db.Products);

        AddCommand = new Command(() =>
        {
            var sale = new Sale(ClientId, SelectedProduct.Id, Quantity);
            Sales.Add(sale);
        }, () => true);
    }
}