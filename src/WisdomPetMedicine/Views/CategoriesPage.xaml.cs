using WisdomPetMedicine.DataAccess;

namespace WisdomPetMedicine.Views;

public partial class CategoriesPage : ContentPage
{
	public CategoriesPage()
	{
		InitializeComponent();
        var dbContext = new WpmDbContext();
        foreach (var item in dbContext.Categories)
        {
            data.Children.Add(new Label() { Text = item.Name });
        }
    }
}