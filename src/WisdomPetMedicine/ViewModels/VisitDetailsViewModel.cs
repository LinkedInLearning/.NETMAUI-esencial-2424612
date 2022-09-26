namespace WisdomPetMedicine.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WisdomPetMedicine.DataAccess;
using WisdomPetMedicine.Models;

public class VisitDetailsViewModel : BindableObject
{
    public int ClientId { get; set; }

    private ObservableCollection<Product> products;

    public ObservableCollection<Product> Products
    {
        get { return products; }
        set
        {
            if (products != value)
            {
                products = value;
                RaisePropertyChanged();
            }
        }
    }

    private Product selectedProduct;

    public Product SelectedProduct
    {
        get { return selectedProduct; }
        set
        {
            if (selectedProduct != value)
            {
                selectedProduct = value;
                RaisePropertyChanged();
            }

        }
    }

    private int quantity;

    public int Quantity
    {
        get { return quantity; }
        set
        {
            if (quantity != value)
            {
                quantity = value;
                RaisePropertyChanged();
            }
        }
    }

    private ObservableCollection<Sale> sales = new ObservableCollection<Sale>();

    public ObservableCollection<Sale> Sales
    {
        get { return sales; }
        set
        {
            if (sales != value)
            {
                sales = value;
                RaisePropertyChanged();
            }
        }
    }


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