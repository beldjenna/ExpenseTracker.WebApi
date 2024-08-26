using ExpenseTracker.Core.Entities;
using ExpenseTracker.Core.Models;
using ExpenseTracker.Data;

namespace ExpenseTracker.Service
{

    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<UserProfileModel> GetUserByIdAsync(int userId)
        {
            var user = await userRepository.GetUserByIdAsync(userId);
            return user != null ? MapToUserProfileModel(user) : null;
        }

        // Mapping methods

        private UserProfileModel MapToUserProfileModel(UserProfile user)
        {
            return new UserProfileModel
            {
                UserId = user.UserId,
                DisplayName = user.DisplayName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                AdObjId = user.AdObjId,
                FamilyId = user.FamilyId,
            };
        }
}   }
