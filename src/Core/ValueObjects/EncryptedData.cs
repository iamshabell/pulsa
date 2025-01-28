namespace Core.ValueObjects
{
    public class EncryptedData
    {
        public EncryptedData(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}