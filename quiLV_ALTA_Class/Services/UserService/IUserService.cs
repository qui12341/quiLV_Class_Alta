using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<User> AuthenticateAsync(string userName, string password);
        Task<User> RegisterAsync(string username, string password, string email);
        Task<bool> ForgotPasswordAsync(string email);
        Task<bool> ResetPasswordAsync(string token, string newPassword);
        Task<User> RegisterTeacherAsync(string username, string password, string email);
        Task<User> RegisterStudentAsync(string username, string password, string email);



    }
}
