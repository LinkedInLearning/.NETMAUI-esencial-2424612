namespace WisdomPetMedicine.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WisdomPetMedicine.DataAccess;

public partial class VisitDetailsPage : ContentPage, IQueryAttributable
{
	public VisitDetailsPage()
	{
		InitializeComponent();
	}

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		Title = $"Cliente: {query["id"]}";
	}
}

public class VisitDetailsData : BindableObject
{
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

    public VisitDetailsData()
    {
        var db = new WpmDbContext();
        Products = new ObservableCollection<Product>(db.Products);
    }
}