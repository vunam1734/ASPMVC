using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Test.Models
{
    public class EmailSender : IEmailSender
    {
        Task IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
