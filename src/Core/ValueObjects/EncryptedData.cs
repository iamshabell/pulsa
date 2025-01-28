namespace Core.ValueObjects
{
    public class EncryptedData
    {
        public EncryptedData(string data)
        {
            this.Data = data;
        }

        public string Data { get; private set; }
    }
}