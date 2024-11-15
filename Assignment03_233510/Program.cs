using System;
using System.Xml;

class Program
{
    static void Main()
    {
        // Step 1: Configure settings for the XML writer
        XmlWriterSettings settings = new XmlWriterSettings
        {
            Indent = true, // Makes the XML readable
            IndentChars = "\t" // Use tab character for indentation
        };

        // Step 2: Create and write to an XML file
        using (XmlWriter writer = XmlWriter.Create("GPS.xml", settings))
        {
            writer.WriteStartDocument(); // Start XML document
            writer.WriteStartElement("GPS_Log"); // Root element <GPS_Log>

            // Add <Position> element with attributes and child elements
            writer.WriteStartElement("Position");
            writer.WriteAttributeString("DateTime", "1/26/2017 5:08:59 PM");
            writer.WriteElementString("x", "65.8973342");
            writer.WriteElementString("y", "72.3452346");

            // Add nested <SatteliteInfo> element
            writer.WriteStartElement("SatteliteInfo");
            writer.WriteElementString("Speed", "40");
            writer.WriteElementString("NoSatt", "7");
            writer.WriteEndElement(); // End <SatteliteInfo>

            writer.WriteEndElement(); // End <Position>

            // Add <Image> element with attributes and child elements
            writer.WriteStartElement("Image");
            writer.WriteAttributeString("Resolution", "1024x800");
            writer.WriteElementString("Path", @"\images\1.jpg");
            writer.WriteEndElement(); // End <Image>

            writer.WriteEndElement(); // End <GPS_Log>
            writer.WriteEndDocument(); // Close the document
        }

        Console.WriteLine("XML file created successfully!");
    }
}
