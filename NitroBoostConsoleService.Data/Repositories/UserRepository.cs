using Microsoft.EntityFrameworkCore;
using NitroBoostConsoleService.Data.Entities;
using NitroBoostConsoleService.Shared.Dto;
using NitroBoostConsoleService.Shared.Interface.Repository;

namespace NitroBoostConsoleService.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(NitroboostConsoleContext context) : base(context) {}
    
    public async Task<UserDto?> GetUserById(long userId) => 
        (await Find(x => x.Id == userId)).FirstOrDefault()?.ToDto();

    public async Task<UserDto?> GetUserByEmail(string email) =>
        (await Find(x => x.Email == email)).FirstOrDefault()?.ToDto();

    public async Task<UserDto?> AddUser(UserDto user, string email)
    {
        User? entity = (await Find(x => x.Email == email)).FirstOrDefault();
        if (entity != null)
            return entity.ToDto();
        
        entity = new User(user);
        await Add(entity);
        await _context.SaveChangesAsync();
        return entity.ToDto();
    }

    public async Task<UserDto?> UpdateNickname(string email, string nickname)
    {
        User? entity = (await Find(x => x.Email == email)).FirstOrDefault();
        if (entity == null)
            return null;
        
        entity.Nickname = nickname;
        Update(entity);
        await _context.SaveChangesAsync();
        return entity.ToDto();
    }
    
    public async Task DeleteUser(string email)
    {
        User? entity = (await Find(x => x.Email == email)).FirstOrDefault();
        if (entity != null)
        {
            Delete(entity!);
            await _context.SaveChangesAsync();
        }
    }
}