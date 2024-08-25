using ExpenseTracker.Core.Models;

namespace ExpenseTracker.Service
{
    public interface IUserService
    {
        Task<UserProfileModel> GetUserByIdAsync(int userId);
    }
}
