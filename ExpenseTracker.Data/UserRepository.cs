using ExpenseTracker.Core.Entities;


namespace ExpenseTracker.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ExpenseTrackerDbContext context;

        public UserRepository(ExpenseTrackerDbContext context)
        {
            this.context = context;
        }
        public async Task<UserProfile> GetUserByIdAsync(int userId)
        {
            return await context.UserProfiles.FindAsync(userId);
        }
    }
}
