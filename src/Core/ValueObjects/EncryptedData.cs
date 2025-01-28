namespace Core.ValueObjects
{
    public class EncryptedData
    {
        public EncryptedData(string Data)
        {
            Data = Data;
        }

        public string Data { get; private set; }
    }
}