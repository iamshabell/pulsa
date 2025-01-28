using System.Xml;
using System.Xml.Schema;

namespace Infrastructure.Utilities
{
    public static class XmlValidator
    {
        public static bool Validate(string xml, string xsdFilePath)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            xmlDoc.Schemas.Add(null, xsdFilePath);
            xmlDoc.Validate((sender, args) =>
            {
                if (args.Severity == XmlSeverityType.Error)
                {
                    throw new Exception($"XML validation error: {args.Message}");
                }
            });

            return true;
        }
    }
}