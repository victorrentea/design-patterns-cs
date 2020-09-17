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
        switch (originCountry)
        {
            case "UK":
                return new UKTaxComputer().compute(tobaccoValue, regularValue);
            case "CN":
                return new ChinaTaxComputer().compute(tobaccoValue, regularValue);
            case "RO":
            case "ES":
            case "FR": 
                return new EUTaxComputer().compute(tobaccoValue);
            default: throw new Exception("JDD: unexpected value: " + originCountry);
        }
    }


   

}
class EUTaxComputer
{
    public double compute(double tobaccoValue)
    {
        return tobaccoValue / 3;
    }
}
class ChinaTaxComputer
{
    public double compute(double tobaccoValue, double regularValue)
    {
        return tobaccoValue + regularValue;
    }

}

class UKTaxComputer
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