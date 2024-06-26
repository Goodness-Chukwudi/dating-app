using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser appUser);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<string> GetUserGender(string username);
        // Task<IEnumerable<MemberDTO>> GetMembersAsync();
        Task<PagedList<MemberDTO>> GetMembersAsync(UserParams userParams);
        Task<PagedList<UserPhotoDTO>> GetPhotosAsync(PhotoParams photoParams);
        Task<MemberDTO> GetMemberByUsernameAsync(string username, bool ignoreFilters = false);
    }
}