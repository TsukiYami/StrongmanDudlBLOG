using StrongmanDudlBLOG.Security.Encryption;

namespace StrongmanDudlBLOG.Security;

public class SecurityHandler
{
    private static SecurityHandler _instance;
    private static readonly Lock _lock = new();

    private SecurityHandler() { }

    public static SecurityHandler Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SecurityHandler();
                    }
                }
            }
            return _instance;
        }
    }
    
    public (string, string) Hash(string sEMail, string sPassword)
    {
        return new Hashing().Hash(sEMail, sPassword);
    }

    //public (string, string) RSAEncrypt(string sEMail, string sPassword) { }

    public (string, string) AESEncrypt(string sEMail, string sPassword)
    {
        return new AES().Encrypt_AES(sEMail, sPassword);
    }
}