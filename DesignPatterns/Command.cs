using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Drinker
{
    private readonly Barman barman;

    public static void Main(string[] args)
    {


        Console.WriteLine("Stuff");

        Barman barman = new Barman();
        Drinker drinker = new Drinker(barman);
        Stopwatch stopwatch = Stopwatch.StartNew();
        drinker.Drink();
        stopwatch.Stop();
        Console.WriteLine($"Took {stopwatch.ElapsedMilliseconds}");
        Console.ReadLine();
    }
    public Drinker(Barman barman)
    {
        this.barman = barman;
        Console.WriteLine("Stuff");
    }

    public void Drink() 
    {
        Beer beer = barman.PourBeer();
        Vodka vodka = barman.PourVodka();
        Console.WriteLine("Got my order! Enjoying: " + beer + " and " + vodka);
    }
}

class Barman
{
    public Beer PourBeer()
    {
        Console.WriteLine("Pouring Beer");
        Thread.Sleep(1000);
        return new Beer();
    }   
    public Vodka PourVodka()
    {
        Console.WriteLine("Pouring Vodka");
        Thread.Sleep(1000);
        return new Vodka();
    }
}
class Beer { }
class Vodka { }


// Cheat sheet:
//  M().GetAwaiter().GetResult();
// await Task.Delay(1000); not Thread.sleep
// await Task.WhenAll(comandaDeBere, comandaDeTzuica);