using WisdomPetMedicine.DataAccess;

namespace WisdomPetMedicine.Views;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
	{
		InitializeComponent();
		var dbContext = new WpmDbContext();
		products.ItemsSource = dbContext.Products;
	}
}