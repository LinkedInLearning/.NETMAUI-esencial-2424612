using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Platform.Compatibility;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WisdomPetMedicine.DataAccess;
using WisdomPetMedicine.Services;
using WisdomPetMedicine.Views;

namespace WisdomPetMedicine.ViewModels;
public partial class ProductsViewModel : ViewModelBase
{
    private readonly INavigationService navigationService;

    [ObservableProperty]
    ObservableCollection<Product> products;

    [ObservableProperty]
    Product selectedProduct;

    [ObservableProperty]
    bool isRefreshing;

    public ProductsViewModel(INavigationService navigationService)
    {
        this.navigationService = navigationService;
        LoadProducts();
        PropertyChanged += ProductsViewModel_PropertyChanged;
    }

    [RelayCommand]
    private async Task Refresh()
    {
        LoadProducts();
        await Task.Delay(3000);
        IsRefreshing = false;
    }

    private async void ProductsViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SelectedProduct))
        {
            var uri = $"{nameof(ProductDetailsPage)}?id={SelectedProduct.Id}";
            await navigationService.GoToAsync(uri);
        }
    }

    private void LoadProducts()
    {
        var dbContext = new WpmDbContext();
        Products = new ObservableCollection<Product>(dbContext.Products);
        dbContext.Dispose();
    }
}