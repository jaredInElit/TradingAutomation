using System;
using MailKit.Net.Smtp;
using MimeKit;

namespace TradingAutomation.Reports
{
    public class EmailReports
    {
        public void SendDailyReport(string performanceSummary)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Trading Bot", "your-email@example.com"));
            message.To.Add(new MailboxAddress("Jared", "jaredboschmann@gmail.com.com"));
            message.Subject = "Daily Trading Performance Report";

            message.Body = new TextPart("plain")
            {
                Text = performanceSummary
            };

            using (var client = new SmtpClient())
            {
                // Replace with your SMTP settings
                client.Connect("smtp.example.com", 587, false);
                client.Authenticate("your-email@example.com", "your-password");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}