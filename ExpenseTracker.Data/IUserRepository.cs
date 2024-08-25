using ExpenseTracker.Core.Entities;

namespace ExpenseTracker.Data
{
    public interface IUserRepository
    {
        Task<UserProfile> GetUserByIdAsync(int userId); //asynchronous method returning a task of UserProfile
    }
}
