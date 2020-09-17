using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Template
{
    public static void Main(string[] args)
    {
        //new EmailSender.send(factory.creatEmail(RECEIVE_ORDER))
        // in many places in code:

        //EmailSender sender = ServiceLocator.getEmailSender("OrderShipped"); //new EmailSender();
        //EmailSender sender = ServiceLocator.getEmailSender("OrderReceived"); //new EmailSender()
        var sender = new EmailSender();
        //Temporal coupling
        sender.SendEmail("a@b.com", AllEmails.ComposeOrderReceivedEmail);
        sender.SendEmail("a@b.com", AllEmails.ComposeOrderReceivedEmail);
        sender.SendEmail("a@b.com", AllEmails.ComposeOrderReceivedEmail);
        sender.SendEmail("a@b.com", AllEmails.ComposeOrderReceivedEmail);

        //EmailSender<>
        // CR323: send an email also when the order is shipped. In a similar way as the orderPlaced email.
        sender.SendEmail("a@b.com", AllEmails.ComposeOrderShippedEmail);
        Console.ReadLine();
    }
}

class EmailSender
{
    public void SendEmail(string emailAddress, Action<Email> composer)
    {
        EmailContext context = new EmailContext(/*smtpConfig,etc*/);
        int MAX_RETRIES = 3;
        for (int i = 0; i < MAX_RETRIES; i++)
        {
            Email email = new Email(); // constructor generates new unique 
            email.sender = "noreply@corp.com";
            email.replyTo = "/dev/null";
            email.to = emailAddress;
            composer(email);
            bool success = context.Send(email);
            if (success) break;
        }
    }

}


class AllEmails
{
    public static void ComposeOrderShippedEmail(Email email)
    {
        email.subject = "Order Shipped";
        email.body = "We shipped you your order. Hope it gets to you this time in one piece.";
    }
    public static void ComposeOrderReceivedEmail(Email email)
    {
        email.subject = "Order Received";
        email.body = "Thank you for your order";
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
//class EmailFactory
//{
//    public Email create(string emailAddress, enum kind)
//    {
//        Email email = new Email(); // constructor generates new unique 
//        email.sender = "noreply@corp.com";
//        email.replyTo = "/dev/null";
//        email.to = emailAddress;
//        if / switch
//        ComposeEmail(email);
//    }
//}