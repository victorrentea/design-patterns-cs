using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Template
{
    public static void Main(string[] args)
    {        
        new EmailSender().SendOrderPlacedEmail("a@b.com");
        Console.ReadLine();
    }
}

class EmailSender
{
    public void SendOrderPlacedEmail(String emailAddress)
    {
        EmailContext context = new EmailContext(/*smtpConfig,etc*/);
        int MAX_RETRIES = 3;
        for (int i = 0; i < MAX_RETRIES; i++)
        {
            Email email = new Email(); // constructor generates new unique 
            email.sender = "noreply@corp.com";
            email.replyTo = "/dev/null";
            email.to = emailAddress;
            email.subject = "Order Received";
            email.body = "Thank you for your order";
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