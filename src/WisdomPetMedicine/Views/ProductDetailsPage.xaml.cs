using WisdomPetMedicine.DataAccess;

namespace WisdomPetMedicine.Views;

public partial class ProductDetailsPage : ContentPage, IQueryAttributable
{
	public ProductDetailsPage()
	{
		InitializeComponent();
	}

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
        var dbContext = new WpmDbContext();
        var product = dbContext.Products.First(p => p.Id == int.Parse(query["id"].ToString()));
        data.Children.Add(new Label() { Text = product.Name });
        data.Children.Add(new Label() { Text = product.Description });
        data.Children.Add(new Label() { Text = $"{product.Price}" });
    }
}