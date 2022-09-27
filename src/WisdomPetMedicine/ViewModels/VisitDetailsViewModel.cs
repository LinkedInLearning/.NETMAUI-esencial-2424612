namespace WisdomPetMedicine.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WisdomPetMedicine.DataAccess;
using WisdomPetMedicine.Models;
using WisdomPetMedicine.Services;

public partial class VisitDetailsViewModel : ViewModelBase, IQueryAttributable
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
    private readonly IConnectivity connectivity;
    private readonly SyncService syncService;
    private readonly WpmOutDbContext outDbContext;

    public ICommand AddCommand { get; set; }

    public VisitDetailsViewModel(IConnectivity connectivity,
        SyncService syncService,
        WpmOutDbContext outDbContext)
    {
        var db = new WpmDbContext();
        Products = new ObservableCollection<Product>(db.Products);

        AddCommand = new Command(() =>
        {
            var sale = new Sale(ClientId, 
                SelectedProduct.Id, 
                SelectedProduct.Name,
                SelectedProduct.Price,
                Quantity,
                SelectedProduct.Price * Quantity);
            Sales.Add(sale);
        }, () => true);
        
        this.connectivity = connectivity;
        this.syncService = syncService;
        this.outDbContext = outDbContext;

        connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
    }

    private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        FinishSaleCommand.NotifyCanExecuteChanged();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var clientId = int.Parse(query["id"].ToString());
        ClientId = clientId;
    }


    [RelayCommand]
    private void DeleteSale(Sale sale)
    {
        Sales.Remove(sale);
    }

    private bool CanFinishSale()
    {
        return connectivity.NetworkAccess == NetworkAccess.Internet;
    }

    [RelayCommand(CanExecute = nameof(CanFinishSale))]
    private async Task FinishSale()
    {
        outDbContext.Database.EnsureCreated();

        foreach (var item in Sales)
        {
            outDbContext.Sales.Add(new SaleItem(
                item.ClientId,
                item.ProductId,
                item.Quantity,
                item.ProductPrice
                ));
        }

        await outDbContext.SaveChangesAsync();

        await Shell.Current.DisplayAlert("Mensaje", "Datos almacenados.", "Aceptar");
    }
}