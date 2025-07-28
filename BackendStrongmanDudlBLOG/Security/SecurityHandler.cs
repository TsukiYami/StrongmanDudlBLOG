namespace BackendStrongmanDudlBLOG.Security;

public class SecurityHandler
{
    private static SecurityHandler _instance;

    private SecurityHandler() { }

    public static SecurityHandler Instance
    {
        get
        {
            if (_instance == null)
                _instance = new();
            return _instance;
        }
    }
    
    public string Hash(string sPassword)
    {
        return new Hashing().Hash(sPassword);
    }
}