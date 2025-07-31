using System.Security.Cryptography;

namespace StrongmanDudlBLOG.Security.Encryption;

public class RSA
{
    internal string EncryptStringToBytes_AES(string EMail, string sPassword)
    {
        if(EMail == null && sPassword == null || EMail.Length <= 0 && sPassword.Length <= 8)
            throw new ArgumentNullException("sText");

        byte[] nEncrypted;
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
                    nEncrypted = oMSEncrypt.ToArray();
                }
            }
        }
        return nEncrypted.ToString();
    }

    private string DecryptStringFromBytes_AES(byte[] nEncrypted, byte[] nKey, byte[] nIV)
    {
        string sText;

        using (Aes oAES = Aes.Create())
        {
            oAES.Key = nKey;
            oAES.IV = nIV;

            ICryptoTransform oDecryptor = oAES.CreateDecryptor(oAES.Key, oAES.IV);

            using (MemoryStream oMSDecrypt = new(nEncrypted))
            using (CryptoStream oCSDecrypt = new(oMSDecrypt, oDecryptor, CryptoStreamMode.Write))
            using (StreamReader oSRDecrypt = new(oCSDecrypt))
            { 
                sText = oSRDecrypt.ToString();
            }
        }
        return sText;
    }
}