namespace WisdomPetMedicine.Services;
public class AuthConfig
{
    public object ParentActivity { get; private set; }
    public string RedirectUri { get; init; }
    public string ClientId { get; init; }
    public string TenantId { get; init; }
    public string Authority { get; init; }
    public string[] Scopes { get; init; }

    public static AuthConfig Instance { get; } = new AuthConfig();

    private AuthConfig()
    {
        
    }

    public void SetParentActivity(object activity)
    {
        ParentActivity = activity;
    }
}