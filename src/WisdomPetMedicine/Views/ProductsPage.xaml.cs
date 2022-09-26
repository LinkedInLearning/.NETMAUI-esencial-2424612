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
			var btn = new Button() { Text = item.Name };
			btn.Clicked += async (s, a) =>
			{
				var uri = $"{nameof(ProductDetailsPage)}?id={item.Id}";
                await Shell.Current.GoToAsync(uri);
			};
            data.Children.Add(btn);
		} 
	}
}