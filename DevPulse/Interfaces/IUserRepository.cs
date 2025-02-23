using DevPulse.Entities;

namespace DevPulse;
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser?> GetUserByIdAsync(int id);
        Task<AppUser?> GetUserByUsernameAsync(string username);

        Task<IEnumerable<DTOs.MemberDto>> GetMembersAsync();
        Task<DTOs.MemberDto?> GetMemberAsync(string username);
    }
    