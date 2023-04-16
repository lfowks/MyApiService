using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly MyDbContext _myDbContext;

        public UserService(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public Task<List<User>> GetAll()
        {
            return _myDbContext.Users.ToListAsync();
        }

        public async Task<User> Create(User user)
        {
            _myDbContext.Users.Add(user);
            await _myDbContext.SaveChangesAsync();

            return user;
        }
    }
}