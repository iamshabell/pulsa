using System.Xml.Serialization;

namespace Application.DTOs
{
    [XmlRoot("BalanceRequest", Namespace = "http://www.google.com")]
    public class BalanceRequestDto
    {
        [XmlElement("AccountNumber")]
        public string AccountNumber { get; set; }

        [XmlElement("AccountType")]
        public string AccountType { get; set; }

        [XmlElement("AccountProvider")]
        public string AccountProvider { get; set; }
    }
}
