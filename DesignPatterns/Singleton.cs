using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Singleton
{
    public static void Main(string[] args)
    {
        LabelService labelService = new LabelService(new CountryRepo());
        OrderExporter orderExporter = new OrderExporter(new InvoiceExporter(labelService), labelService);
        orderExporter.Export("en");
        // orderExporter.Export("fr");
        Console.ReadLine();
    }
}


class OrderExporter
{
    private readonly InvoiceExporter invoiceExporter;
    private readonly LabelService labelService;

    public OrderExporter(InvoiceExporter invoiceExporter, LabelService labelService)
    {
        this.invoiceExporter = invoiceExporter;
        this.labelService = labelService;
    }

    public void Export(string locale)
    {
        Console.WriteLine("Running export in " + locale);
        Console.WriteLine("Origin Country: " + labelService.getCountryName("rO"));
        invoiceExporter.ExportInvoice();
    }
}

class InvoiceExporter
{
    private readonly LabelService labelService;
    
    public InvoiceExporter(LabelService labelService)
    {
        this.labelService = labelService;
    }

    public void ExportInvoice()
    {
        Console.WriteLine("Invoice Country: " + labelService.getCountryName("ES"));
    }
}

class LabelService
{
    private readonly CountryRepo countryRepo;
    public LabelService(CountryRepo countryRepo)
    {
        Console.WriteLine("load() in instance: " + this.GetHashCode());
        countryNames = countryRepo.LoadCountryNamesAsMap("en");
        this.countryRepo = countryRepo;
    }

    private readonly Dictionary<String, String> countryNames;

    public String getCountryName(String iso2Code)
    {
        Console.WriteLine("getCountryName() in instance: " + this.GetHashCode());
        return countryNames[iso2Code.ToUpper()];
    }
}




public class CountryRepo
{
    public Dictionary<String, String> LoadCountryNamesAsMap(string locale)
    {
        // connect to database, get data. fake some latency
        Console.WriteLine("Loading country names for language: " + locale);
        Thread.Sleep(2000);
        Console.WriteLine("done");

        Dictionary<String, String> map = new Dictionary<String, String>();
        switch (locale)
        {
            case "en":
                map["RO"] = "Romania";
                map["ES"] = "Spain";
                break;
            case "fr":
                map["RO"] = "Roumanie";
                map["ES"] = "Espagne";
                break;
            default: throw new Exception("best practice");
        }
        return map;
    }

}

