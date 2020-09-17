using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Template
{
    public static void Main(string[] args)
    {        
        // in many places in code:
        new EmailSender().SendOrderPlacedEmail("a@b.com", false);
        new EmailSender().SendOrderPlacedEmail("a@b.com", false);
        new EmailSender().SendOrderPlacedEmail("a@b.com", false);
        new EmailSender().SendOrderPlacedEmail("a@b.com", false);
        new EmailSender().SendOrderPlacedEmail("a@b.com", false);

        // CR323: send an email also when the order is shipped. In a similar way as the orderPlaced email.
        new EmailSender().SendOrderPlacedEmail("a@b.com", true);
        Console.ReadLine();
    }
}

class EmailSender
{
    public void SendOrderPlacedEmail(string emailAddress, bool cr323)
    {
        EmailContext context = new EmailContext(/*smtpConfig,etc*/);
        int MAX_RETRIES = 3;
        for (int i = 0; i < MAX_RETRIES; i++)
        {
            Email email = new Email(); // constructor generates new unique 
            email.sender = "noreply@corp.com";
            email.replyTo = "/dev/null";
            email.to = emailAddress;
            if (!cr323)
            {
                email.subject = "Order Received";
                email.body = "Thank you for your order";
            }
            else
            {
                email.subject = "Order Shipped";
                email.body = "We shipped you your order. Hope it gets to you this time in one piece.";
            }
            bool success = context.Send(email);
            if (success) break;
        }
    }
    
}
   
class EmailContext
{
    private readonly Random rand = new Random();

    public bool Send(Email email)
    {
        Console.Out.WriteLine("Trying to send " + email.AsText());
        return rand.Next() % 2 == 0;
    }
}

class Email
{
    private readonly int id = new Random().Next();
    public String subject;
    public String body;
    public String sender;
    public String replyTo;
    public String to;

    public string AsText()
    {
        return $"Email({subject}, {body}, {id})";
    }

}