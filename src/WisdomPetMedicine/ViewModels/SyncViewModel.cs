using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Identity.Client;
using WisdomPetMedicine.DataAccess;
using WisdomPetMedicine.Models;
using WisdomPetMedicine.Services;

namespace WisdomPetMedicine.ViewModels;
public partial class SyncViewModel : ViewModelBase
{
    private string accessToken;

    [ObservableProperty]
    bool isAuthenticated;

    [ObservableProperty]
    string message;

    private readonly AuthService authService;
    private readonly SyncService syncService;
    private readonly WpmOutDbContext outDbContext;

    public SyncViewModel(AuthService authService,
                         SyncService syncService,
                         WpmOutDbContext outDbContext)
    {
        this.authService = authService;
        this.syncService = syncService;
        this.outDbContext = outDbContext;
    }

    [RelayCommand]
    private async Task Sync()
    {
        var allSales = outDbContext.Sales
                .ToList()
                .Select(s => new Sale(s.ClientId, s.ProductId, 
                null, s.Price, s.Quantity, default));

        try
        {
            var syncResult = await syncService.SendDataAsync(allSales, accessToken);
            Message = syncResult ? "Proceso finalizado correctamente" : "Ha ocurrido un error durante el envío de datos";
        }
        catch (Exception)
        {
            Message = "Error en la sincronización";
        }
    }
    
    [RelayCommand]
    private async Task Login()
    {
        try
        {
            var result = await authService
                                .AcquireTokenSilentAsync()
                                .ConfigureAwait(false);
            IsAuthenticated = true;
            accessToken = result.AccessToken;
        }
        catch (MsalUiRequiredException)
        {
            var result = await authService
                                .AcquireTokenInteractiveAsync()
                                .ConfigureAwait(false);
            IsAuthenticated = true;
            accessToken = result.AccessToken;
        }
        catch
        {
            IsAuthenticated = false;
        }
    }
}