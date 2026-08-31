using AqaTest.Interfaces;
using NUnit.Framework;

namespace AqaTest.Repositories;

public class EmailSender : IEmailSender
{
    public void Send(string to, string text)
    {
        TestContext.WriteLine($"Sending mail to {to}: {text}");
    }
}