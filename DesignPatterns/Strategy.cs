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
        TaxComputer computer;
        switch (originCountry)
        {
            case "UK":
                computer = new UKTaxComputer(); break;
            case "CN":
                computer = new ChinaTaxComputer(); break;
            case "RO":
            case "ES":
            case "FR":
                computer = new EUTaxComputer(); break;
            default: throw new Exception("JDD: unexpected value: " + originCountry);
        }
        return computer.compute(tobaccoValue, regularValue);
    }
}
interface TaxComputer
{
    double compute(double tobaccoValue, double regularValue);
}
class EUTaxComputer : TaxComputer
{
    public double compute(double tobaccoValue, double regularValueUnused)
    {
        return tobaccoValue / 3;
    }
}
class ChinaTaxComputer : TaxComputer
{
    public double compute(double tobaccoValue, double regularValue)
    {
        return tobaccoValue + regularValue;
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

}