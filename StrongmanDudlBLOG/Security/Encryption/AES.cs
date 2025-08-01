using System.Security.Cryptography;

namespace StrongmanDudlBLOG.Security.Encryption;

public class AES
{
    internal (string, string) Encrypt_AES(string EMail, string sPassword)
    {
        if(EMail == null && sPassword == null || EMail.Length <= 0 && sPassword.Length <= 8)
            throw new ArgumentNullException("sText");

        byte[] nEncryptedEMail, nEncryptedPassword;
        using (Aes oAES = Aes.Create())
        {
            byte[] nKey = oAES.Key;
            byte[] nIV = oAES.IV;
            
            ICryptoTransform oEncryptor = oAES.CreateEncryptor(nKey, nIV);

            using (MemoryStream oMSEncrypt = new())
            {
                using (CryptoStream oCSEncrypt = new(oMSEncrypt, oEncryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter oSWEncrypt = new(oCSEncrypt))
                    {
                        oSWEncrypt.Write(EMail);
                    }
                    nEncryptedEMail = oMSEncrypt.ToArray();
                }
            }
        }

        using (Aes oAES = Aes.Create())
        {
            byte[] nKey = oAES.Key;
            byte[] nIV = oAES.IV;
            
            ICryptoTransform oEncryptor = oAES.CreateEncryptor(nKey, nIV);
            
            using (MemoryStream oMSEncrypt = new())
            {
                using (CryptoStream oCSEncrypt = new(oMSEncrypt, oEncryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter oSWEncrypt = new(oCSEncrypt))
                    {
                        oSWEncrypt.Write(sPassword);
                    }
                    nEncryptedPassword = oMSEncrypt.ToArray();
                }
            }
        }
        return (nEncryptedEMail.ToString(), nEncryptedPassword.ToString());
    }
}