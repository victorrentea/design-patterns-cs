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
        oldLady.AddSubscriber(new Auditor());

        oldLady.FindOut("Rita came with a Rocker");
        Console.ReadLine();
    }
}

class Person : InterestedObserver
{
    public void NotifyEvent(string gossip)
    {
        Console.WriteLine("I also find out about " + gossip);
    }
}
class Auditor : InterestedObserver
{
    public void NotifyEvent(string gossip)
    {
        Console.WriteLine("Store this gossip into a file:" + gossip);
    }
}
// ------------ from here down, nothing changes when you define new subscriber.
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

    

