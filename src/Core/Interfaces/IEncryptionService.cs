using Core.ValueObjects;

namespace Core.Interfaces 
{
    public interface IEncryptionService
    {
        EncryptedData Encrypt(string data);
        string Decrypt(EncryptedData data);
    }
}