namespace quiLV_ALTA_Class.Services.UserService
{
    public interface IEmailService
    {
        Task SendPasswordResetEmailAsync(string email, string resetLink);
    }
}
