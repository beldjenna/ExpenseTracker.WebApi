using ExpenseTracker.Core.Entities;

namespace ExpenseTracker.Data
{
    public interface IUserRepository
    {
        Task<UserProfile> GetUserByIdAsync(int userId); //asynchronous method returning a task of UserProfile
        Task<IEnumerable<UserProfile>> GetUserByFamilyIdAsync(int familyId);
        Task AddUserAsync (UserProfile user);
        Task UpdateUserAsync (UserProfile user);
        Task DeleteUserAsync (int userId);

        Task<Family> GetFamilyByIdAsync (int familyId);
        Task<IEnumerable<Family>> GetAllFamiliesByIdAsync ();
        Task AddFamilyAsync(Family family);
        Task UpdateFamilyAsync (Family family);
        Task DeleteFamilyAsync (int familyId);

    }
}

