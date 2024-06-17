using NitroBoostConsoleService.Data.Entities;
using NitroBoostConsoleService.Shared.Dto;

namespace NitroBoostConsoleService.Data.Repositories;

public class FriendRepository : BaseRepository<Friend>
{
    public FriendRepository(NitroboostConsoleContext context) : base(context) {}
    
    public async Task<IEnumerable<FriendDto>> GetFriends(long senderId)
    {
        List<FriendDto> dto = new List<FriendDto>();
        List<Friend> friends = (await Find(x => x.SenderId == senderId && x.Status == 2)).ToList();
        friends.ForEach(x => dto.Add(ToDto(x)));
        return dto;
    }

    public async Task<IEnumerable<FriendDto>> GetIncomingRequests(long recipientId)
    {
        List<FriendDto> dto = new List<FriendDto>();
        List<Friend> friends = (await Find(x => x.RecipientId == recipientId && x.Status == 0)).ToList();
        friends.ForEach(x => dto.Add(ToDto(x)));
        return dto;
    }

    public async Task<FriendDto?> GetRequest(long senderId, long recipientId)
    {
        Friend? entity = (await Find(x => x.SenderId == senderId && x.RecipientId == recipientId)).FirstOrDefault();
        if (entity == null)
            return null;
        return ToDto(entity);
    }

    public async Task<FriendDto?> AddRequest(long senderId, long recipientId)
    {
        if (senderId == recipientId)
            return null;

        FriendDto? dto = await GetRequest(senderId, recipientId);
        if (dto != null)
            return dto;

        Friend entity = await Add(new Friend()
        {
            CreatedDate = DateTime.Now,
            SenderId = senderId,
            RecipientId = recipientId,
            Status = 0
        });
        return ToDto(entity);
    }
    
    public async Task<FriendDto?> AcceptRequest(long senderId, long recipientId)
    {
        if (senderId == recipientId)
            return null;

        Friend? entity = (await Find(x => x.SenderId == senderId && x.RecipientId == recipientId && x.Status == 0)).FirstOrDefault();
        if (entity == null)
            return null;

        entity.Status = 1;
        Update(entity);
        return ToDto(entity);
    }

    public async Task<FriendDto?> FinalizeRequest(long senderId, long recipientId)
    {
        if (senderId == recipientId)
            return null;

        Friend? entity = (await Find(x => x.SenderId == senderId && x.RecipientId == recipientId && x.Status == 1)).FirstOrDefault();
        if (entity == null)
            return null;

        entity.Status = 2;
        Update(entity);
        return ToDto(entity);
    }

    public async Task DeleteFriend(int senderId, int recipientId)
    {
        if (senderId == recipientId)
            return;

        Friend? entity = (await Find(x => x.SenderId == senderId && x.RecipientId == recipientId)).FirstOrDefault();
        if (entity == null)
            return;
        Delete(entity);
    }
    
    private FriendDto ToDto(Friend entity) => new FriendDto()
    {
        CreatedDate = entity.CreatedDate,
        SenderId = entity.SenderId,
        RecipientId = entity.RecipientId,
        Status = entity.Status
    };

    private FriendDto ToDto(DateTime createdDate, long senderId, long recipientId, int status) => new FriendDto()
    {
        CreatedDate = createdDate,
        SenderId = senderId,
        RecipientId = recipientId,
        Status = status
    };
}