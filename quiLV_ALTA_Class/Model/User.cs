using System.ComponentModel.DataAnnotations;

namespace quiLV_ALTA_Class.Model
{
    public class User
    {
        [Key]
        public int User_ID {  get; set; }
        public string User_Name { get; set;}
        public string? Email { get; set;}
        public string Password { get; set;}
        public string? User_Image {  get; set;}
        public int Role_ID {  get; set; }
    }
    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Subject { get; set; }
        public string Audience { get; set; }
    }

    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class RegisterModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class ForgotPasswordRequest
    {
        public string Email { get; set; }
    }

    public class ResetPasswordRequest
    {
        public string Otp { get; set; }
        public string NewPassword { get; set; }
    }


}
