using System.Security.Cryptography;
using System.Text;

namespace StrongmanDudlBLOG.Security;

public class Hashing
{
    internal (string, string) Hash(string sEMail, string sPassword)
    {
        string sHashedEMail = Convert.ToBase64String(SHA256.Create().ComputeHash(UTF8Encoding.UTF8.GetBytes(sEMail)));
        string sHashedPassword = Convert.ToBase64String(SHA256.Create().ComputeHash(UTF8Encoding.UTF8.GetBytes(sPassword)));
        return (sHashedEMail, sHashedPassword);
    }
}