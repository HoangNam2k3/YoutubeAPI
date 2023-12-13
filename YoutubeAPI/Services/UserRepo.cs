using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using YoutubeAPI.Data;
using YoutubeAPI.Models;

namespace YoutubeAPI.Services
{
    public class UserRepo : IRepoUser
    {
        private readonly MyDbContext _dbContext;

        public UserRepo(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserVM> CreateAsync(UserMD userMD)
        {
            var hashedPassword = HassPassword(userMD.password);
            var user = new User
            {
                username = userMD.username, 
                email = userMD.email,
                password = hashedPassword
            };
            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();
            return new UserVM
            {
                user_id = user.user_id,
                username = user.username,
                email = user.email,
                password = user.password,
                join_date = user.join_date
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(us => us.user_id == id);
            if (user == null) return false;
            _dbContext.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserVM>> GetAllAsync()
        {
            var users = await _dbContext.Users.Select(user => new UserVM
            {
                user_id = user.user_id,
                username = user.username,
                email = user.email,
                password = user.password,
                join_date = user.join_date
            }).ToListAsync();
            return users;
        }

        public async Task<UserVM> GetByIdAsync(int id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(us => us.user_id == id);
            if (user == null) return null!;
            return new UserVM
            {
                user_id = user.user_id,
                username = user.username,
                email = user.email,
                password = user.password,
                join_date = user.join_date
            };
        }
        public async Task<UserVM> CheckCredentialsAsync(string email, string password)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(us => us.email == email );
            if (user == null | !VerifyPassword(password, user!.password)) return null!;
            return new UserVM
            {
                user_id = user.user_id,
                username = user.username,
                email = user.email,
                password = user.password,
                join_date = user.join_date
            };
        }
        public async Task<bool> CheckEmailExistAsync(string email)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(us => us.email == email);
            if (user == null) return false;
            return true;
        }

        public Task<bool> UpdateAsync(UserVM userVM)
        {
            throw new NotImplementedException();
        }

        private string HassPassword(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    strBuilder.Append(hashBytes[i].ToString("x2"));
                }

                return strBuilder.ToString();
            }
        }
        private bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            string hashedEnteredPassword = HassPassword(enteredPassword);
            return string.Equals(hashedEnteredPassword, hashedPassword);
        }
    }
}
