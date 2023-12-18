using AutoMapper;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using YoutubeAPI.Context;
using YoutubeAPI.DTOs;
using YoutubeAPI.Models;
using YoutubeAPI.Services.Interfaces;

namespace YoutubeAPI.Services.Repositories
{
    public class UserRepo : IRepoUser
    {
        private readonly MyDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepo(MyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<UserDto> CreateAsync(UserMD userMD)
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
            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(us => us.user_id == id);
            if (user == null) return false;
            _dbContext.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _dbContext.Users.Select(user => _mapper.Map<UserDto>(user))
                .ToListAsync();
            return users;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(us => us.user_id == id);
            if (user == null) return null!;
            return _mapper.Map<UserDto>(user);
        }
        public async Task<UserDto> CheckCredentialsAsync(string email, string password)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(us => us.email == email);
            if (user == null | !VerifyPassword(password, user!.password)) return null!;
            return _mapper.Map<UserDto>(user);
        }
        public async Task<bool> CheckEmailExistAsync(string email)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(us => us.email == email);
            if (user == null) return false;
            return true;
        }

        public Task<bool> UpdateAsync(UserDto userVM)
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
