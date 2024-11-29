using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using quiLV_ALTA_Class.Services.UserService;
using static System.Net.WebRequestMethods;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendPasswordResetEmailAsync(string email, string otp)
    {
        var smtpServer = _configuration["EmailSettings:Server"];
        var smtpPort = int.Parse(_configuration["EmailSettings:Port"]);
        var smtpUsername = _configuration["EmailSettings:FromEmail"];
        var smtpPassword = _configuration["EmailSettings:FromPassword"];
        var fromEmail = smtpUsername;

        using (var client = new SmtpClient(smtpServer))
        {
            client.Port = smtpPort;
            client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            client.EnableSsl = true;

            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail, "Your Application Name"),
                Subject = "Password Reset Request",
                Body = $"Your OTP for resetting your password is: <b>{otp}</b>. It will expire in 10 minutes.",
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);

            try
            {
                await client.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw;
            }
        }
    }
}
