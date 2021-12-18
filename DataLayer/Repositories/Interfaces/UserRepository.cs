using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories.Interfaces
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<User>> GetAll()
        {
            return await _appDbContext.Set<User>().ToListAsync();
        }

        public async Task<User> GetByUserName(string username)
        {
            return await _appDbContext.Set<User>().FirstOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<int> GetUserIdByUserName(string username)
        {
            var user = await _appDbContext.Set<User>().FirstOrDefaultAsync(x => x.UserName == username);
            var id = user?.Id ?? 0;
            return id;
        }

        public async Task<User> Update(User user)
        {
            var userCurrent = await _appDbContext.Set<User>().FirstOrDefaultAsync(x => x.Id == user.Id);

            if (userCurrent == null)
                return null;

            userCurrent.Address = user.Address;
            userCurrent.UserName = user.UserName;
            userCurrent.Email = user.Email;
            userCurrent.Name = user.Name;
            userCurrent.Phone = user.Phone;

            _appDbContext.Set<User>().Attach(userCurrent);
            _appDbContext.Entry(userCurrent).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();

            return userCurrent;
        }
    }
}
