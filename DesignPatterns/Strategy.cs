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
            case "UK": return tobaccoValue / 2 + regularValue;
            case "CN": return tobaccoValue + regularValue;
            case "RO":
            case "ES":
            case "FR":
                return tobaccoValue / 3;
            default: throw new Exception("JDD: unexpected value: " + originCountry);
        }
    }


}