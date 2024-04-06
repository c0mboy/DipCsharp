namespace ConsoleApp1;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public class programXML
{
    
    public static async Task ConvertXml()
    {
        // Define the namespaces
        XNamespace soapenv = "http://schemas.xmlsoap.org/soap/envelope/";
        XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
        XNamespace xsd = "http://www.w3.org/2001/XMLSchema";
        XNamespace ndf = "https://graphical.weather.gov/xml/DWMLgen/wsdl/ndfdXML.wsdl";

        // Construct the SOAP envelope
        XElement soapEnvelope = new XElement(soapenv + "Envelope",
            new XAttribute(XNamespace.Xmlns + "soapenv", soapenv),
            new XAttribute(XNamespace.Xmlns + "xsi", xsi),
            new XAttribute(XNamespace.Xmlns + "xsd", xsd),
            new XAttribute(XNamespace.Xmlns + "ndf", ndf),
            new XElement(soapenv + "Header"),
            new XElement(soapenv + "Body", 
                new XElement(ndf + "LatLonListCityNames",
                    new XAttribute("encodingStyle", "http://schemas.xmlsoap.org/soap/encoding/"),
                    new XElement("displayLevel", new XAttribute(xsi + "type", "xsd:integer"), 12)
                )
            )
        );

        // Convert the SOAP envelope to a string
        string soapString = soapEnvelope.ToString();

        // Create HttpClient
        using HttpClient client = new HttpClient();

        // Set headers
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
        var content = new StringContent(soapString, Encoding.UTF8, "text/xml");
        content.Headers.ContentType = new MediaTypeHeaderValue("text/xml");

        // Define the URL (Replace with actual URL)
        string url = "https://graphical.weather.gov/xml/DWMLgen/wsdl/ndfdXML.wsdl";

        try
        {
        // Send the request and get response
        HttpResponseMessage response = await client.PostAsync(url, content);
        // Read and output the response
        string responseString = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseString);
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}

