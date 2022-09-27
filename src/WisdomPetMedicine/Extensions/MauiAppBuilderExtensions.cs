using WisdomPetMedicine.DataAccess;
using WisdomPetMedicine.Services;
using WisdomPetMedicine.ViewModels;
using WisdomPetMedicine.Views;

namespace WisdomPetMedicine.Extensions;
public static class MauiAppBuilderExtensions
{
    public static void ConfigureWisdomPetMedicine(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddTransient<VisitsViewModel>();
        builder.Services.AddTransient<VisitsPage>();
        builder.Services.AddTransient<VisitDetailsPage>();
        builder.Services.AddTransient<VisitDetailsViewModel>();
        builder.Services.AddTransient<ClientsPage>();
        builder.Services.AddTransient<ClientsViewModel>();
        builder.Services.AddTransient<ProductsPage>();
        builder.Services.AddTransient<ProductsViewModel>();
        builder.Services.AddTransient<ProductDetailsPage>();
        builder.Services.AddTransient<ProductDetailsViewModel>();
        builder.Services.AddSingleton(Connectivity.Current);

        var dbContext = new WpmDbContext();
        dbContext.Database.EnsureCreated();
        dbContext.Dispose();

        Routing.RegisterRoute(nameof(ProductDetailsPage),
            typeof(ProductDetailsPage));
        Routing.RegisterRoute(nameof(VisitDetailsPage),
            typeof(VisitDetailsPage));
    }
}