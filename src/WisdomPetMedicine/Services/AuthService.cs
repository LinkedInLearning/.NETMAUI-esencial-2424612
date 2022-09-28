using Microsoft.Identity.Client;

namespace WisdomPetMedicine.Services;
public class AuthService
{
    private readonly IPublicClientApplication clientApp;

    public AuthService()
    {
        clientApp = PublicClientApplicationBuilder
            .Create(AuthConfig.Instance.ClientId)
            .WithRedirectUri(AuthConfig.Instance.RedirectUri)
            .Build();
    }
    public async Task<AuthenticationResult> AcquireTokenInteractiveAsync()
    {
        return await clientApp.AcquireTokenInteractive(AuthConfig.Instance.Scopes)
            .WithParentActivityOrWindow(AuthConfig.Instance.ParentActivity)
            .WithAuthority(AuthConfig.Instance.Authority)
            .WithTenantId(AuthConfig.Instance.TenantId)
            .WithUseEmbeddedWebView(true)
            .ExecuteAsync()
            .ConfigureAwait(false);
    }

    public async Task<AuthenticationResult> AcquireTokenSilentAsync()
    {
        var allAccounts = await clientApp.GetAccountsAsync()
                                         .ConfigureAwait(false);
        var firstAccount = allAccounts.FirstOrDefault();

        var authResult = await clientApp.AcquireTokenSilent(AuthConfig.Instance.Scopes, firstAccount)
                                    .ExecuteAsync()
                                    .ConfigureAwait(false);
        return authResult;

    }

    public async Task SignOutAsync()
    {
        var allAccounts = await clientApp.GetAccountsAsync().ConfigureAwait(false);
        foreach (var account in allAccounts)
        {
            await clientApp.RemoveAsync(account)
                .ConfigureAwait(false);
        }
    }
}