using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApp.Models.SBIEncryptDecryptKey
{
    public interface IsbiIncriptDecript
    {
        string GetSHA256(string name);
        string EncryptWithKey(String messageToEncrypt, byte[] nonSecretPayload = null);
        string DecryptWithKey(string encryptedMessage, int nonSecretPayloadLength = 0);
    }
}
