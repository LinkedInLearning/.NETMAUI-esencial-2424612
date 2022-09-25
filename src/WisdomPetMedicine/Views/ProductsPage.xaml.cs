using WisdomPetMedicine.DataAccess;

namespace WisdomPetMedicine.Views;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
	{
		InitializeComponent();
		var dbContext = new WpmDbContext();
		foreach (var item in dbContext.Products)
		{
			data.Children.Add(new Label() { Text = item.Name });
		} 
	}
}