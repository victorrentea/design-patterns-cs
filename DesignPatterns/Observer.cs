using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Joaca
{
    public static void Main(string[] args)
    {
        OldLady oldLady = new OldLady();

        oldLady.AddSubscriber(new Person());
        oldLady.AddSubscriber(new Person());

        oldLady.FindOut("Rita came with a Rocker");
        Console.ReadLine();
    }
}

class Person : InterestedObserver
{
    public void NotifyEvent(string gossip)
    {
        Console.WriteLine("Aflu si eu de " + gossip);
    }
}

interface InterestedObserver
{
    void NotifyEvent(string gossip);
}

class OldLady
{
    private List<InterestedObserver> observers = new List<InterestedObserver>();
        
    public void AddSubscriber(InterestedObserver observer)
    {
        observers.Add(observer);
    }
    public void FindOut(string gossip)
    {
        foreach (var observer in observers)
        {
            observer.NotifyEvent(gossip);
        }
    }
}

    

