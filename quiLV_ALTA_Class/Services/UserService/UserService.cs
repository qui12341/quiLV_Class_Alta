using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using quiLV_ALTA_Class.Data;
using quiLV_ALTA_Class.Model;
using System.Data;

namespace quiLV_ALTA_Class.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDBContext _context;
        private readonly IMemoryCache _memoryCache;
        private readonly IEmailService _emailService;


        public UserService(IMemoryCache memoryCache, AppDBContext context, IEmailService emailService)
        {
            _memoryCache = memoryCache;
            _context = context;
            _emailService = emailService;
        }
        public async Task CreateUserAsync(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            await _context.user.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.user.FindAsync(id);
            if (user != null)
            {
                _context.user.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _context.user.ToListAsync();

        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.user.FindAsync(id);

        }

        public async Task UpdateUserAsync(User user)
        {
            _context.user.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task<User> AuthenticateAsync(string userName, string password)
        {
            var account = await _context.user
                .FirstOrDefaultAsync(a => a.User_Name == userName);

            if (account != null && BCrypt.Net.BCrypt.Verify(password, account.Password))
            {
                return account;
            }

            return null;
        }
        public async Task<User> RegisterAsync(string username, string password, string email)
        {
            if (await _context.user.AnyAsync(u => u.User_Name == username))
            {
                return null; 
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var newUser = new User
            {
                User_Name = username,
                Password = hashedPassword,
                Email = email,
                User_Image = null,
                Role_ID = 1
                
            };

            _context.user.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<bool> ForgotPasswordAsync(string email)
        {
            var user = await _context.user.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return false; 
            var otp = new Random().Next(100000, 999999).ToString();

            _memoryCache.Set(otp, email, TimeSpan.FromMinutes(10));

            await _emailService.SendPasswordResetEmailAsync(email, otp);

            return true;
        }

        public async Task<bool> ResetPasswordAsync(string otp, string newPassword)
        {
            if (!_memoryCache.TryGetValue(otp, out string email))
            {
                return false; 
            }

            var user = await _context.user.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return false;

            user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);

            _context.user.Update(user);
            await _context.SaveChangesAsync();

            _memoryCache.Remove(otp);

            return true;
        }

        public async Task<User> RegisterTeacherAsync(string username, string password, string email)
        {
            if (await _context.user.AnyAsync(u => u.User_Name == username))
            {
                return null;
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var teacher = new User
            {
                User_Name = username,
                Password = hashedPassword,
                Email = email,
                User_Image = null,
                Role_ID = 2 
            };

            _context.user.Add(teacher);
            await _context.SaveChangesAsync();

            return teacher;
        }

        public async Task<User> RegisterStudentAsync(string username, string password, string email)
        {
            if (await _context.user.AnyAsync(u => u.User_Name == username))
            {
                return null;
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var student = new User
            {
                User_Name = username,
                Password = hashedPassword,
                Email = email,
                User_Image = null,
                Role_ID = 3
            };

            _context.user.Add(student);
            await _context.SaveChangesAsync();

            return student;
        }


    }
}
