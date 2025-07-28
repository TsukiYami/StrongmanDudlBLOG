using System.Security.Cryptography;
using System.Text;

namespace BackendStrongmanDudlBLOG.Security;

public class Hashing
{
    internal string Hash(string sPassword)
    {
        string sHashedPassword = Convert.ToBase64String(SHA256.Create().ComputeHash(UTF8Encoding.UTF8.GetBytes(sPassword)));
        return sHashedPassword;
    }
}