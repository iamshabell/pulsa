using System.Xml.Serialization;

namespace Application.DTOs
{
    [XmlRoot("BalanceResponse")]
    public class BalanceResponseDto
    {
        [XmlElement("EncryptedAccountNumber")]
        public string EncryptedAccountNumber { get; set; }

        [XmlElement("EncryptedBalance")]
        public string EncryptedBalance { get; set; }

        [XmlElement("EncryptedAccountProvider")]
        public string EncryptedAccountProvider { get; set; }

        [XmlElement("Status")]
        public string Status { get; set; }
    }
}