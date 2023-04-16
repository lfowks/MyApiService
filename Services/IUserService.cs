using DataAccess.Entities;

namespace Services
{
    public interface IUserService
    {
        public Task<List<User>> GetAll();
        public Task<User> Create(User user);
    }
}
