using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Strategy
{
    public static void Main(string[] args)
    {
        CustomsService service = new CustomsService();
        Console.WriteLine("Tax for (RO,100,100) = " + service.ComputeCustomsTax("RO", 100, 100));
        Console.WriteLine("Tax for (CN,100,100) = " + service.ComputeCustomsTax("CN", 100, 100));
        Console.WriteLine("Tax for (UK,100,100) = " + service.ComputeCustomsTax("UK", 100, 100));
        Console.ReadLine();
    }

}

class CustomsService
{
    // UGLY API we CANNOT change
    public double ComputeCustomsTax(string originCountry, double tobaccoValue, double regularValue)
    {
        TaxComputer computer = SelectTaxComputer(originCountry);
        return computer.compute(tobaccoValue, regularValue);
    }

    private static TaxComputer SelectTaxComputer(string originCountry)
    {
        List<TaxComputer> computers = new List<TaxComputer>() 
            { new EUTaxComputer(), new ChinaTaxComputer(), new UKTaxComputer() };

        return computers.Where(c => c.GetSupportedCountries().Contains(originCountry))
            .First();
    }
}
interface TaxComputer
{
    List<string> GetSupportedCountries();

    double compute(double tobaccoValue, double regularValue);
}
class EUTaxComputer : TaxComputer
{
    //const string[] COUNTRY_CODE = ["RO", "ES", "FR"];
    public double compute(double tobaccoValue, double regularValueUnused)
    {
        return tobaccoValue / 3;
    }

    public List<string> GetSupportedCountries()
    {
        return new List<string>() { "ES", "FR", "RO" };
    }
}
class ChinaTaxComputer : TaxComputer
{
    public const string COUNTRY_CODE = "CN";
    public double compute(double tobaccoValue, double regularValue)
    {
        return tobaccoValue + regularValue;
    }

    public List<string> GetSupportedCountries()
    {
        return new List<string>() { "CN" };
    }
}

class UKTaxComputer : TaxComputer
{
    public double compute(double tobaccoValue, double regularValue)
    {
        // Dev1: + 10 lines of code
        // Dev2: + 20 lines
        // Dev1: chnage 5 lines
        // 50 lines of code.
        return tobaccoValue / 2 + regularValue;
    }
    public List<string> GetSupportedCountries()
    {
        return new List<string>() { "UK" };
    }
}