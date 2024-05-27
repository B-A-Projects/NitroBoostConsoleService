using Microsoft.EntityFrameworkCore;
using NitroBoostConsoleService.Data.Entities;
using NitroBoostConsoleService.Shared.Dto;
using NitroBoostConsoleService.Shared.Interface.Repository;

namespace NitroBoostConsoleService.Data.Repositories;

public class DeviceRepository(NitroboostConsoleContext context) : BaseRepository<Device>(context), IDeviceRepository
{
    public async Task<DeviceDto?> GetDeviceById(long deviceId) => 
        (await Find(x => x.Id == deviceId)).FirstOrDefault()?.ToDeviceDto();

    public async Task<DeviceDto?> GetDeviceByConsoleId(long deviceId) =>
        (await Find(x => x.DeviceId == deviceId)).FirstOrDefault()?.ToDeviceDto();
    
    public async Task<DeviceDto[]> GetUserLinkedDevices(long userId)
    {
        List<Device> devices = (await Find(x => x.UserId == userId)).ToList();
        DeviceDto[] returnArray = new DeviceDto[devices.Count];
        for (int i = 0; i < returnArray.Length; i++)
        {
            returnArray[i] = devices[i].ToDeviceDto();
        }
        return returnArray;
    }


    public async Task<DeviceDto?> AddDevice(DeviceDto device)
    {
        Device? entity = (await Find(x => x.DeviceId == device.DeviceId)).FirstOrDefault();
        if (entity != null)
            return null;
        entity = new Device(device);
        await Add(entity);
        return entity.ToDeviceDto();
    }

    public async Task<DeviceDto?> UpdateDeviceInfo(DeviceDto device)
    {
        if (device.Id < 1)
            return null;

        Device? entity = (await Find(x => x.Id == device.Id)).FirstOrDefault();
        if (entity == null)
            return null;
        
        entity.DeviceName = device.DeviceName ?? entity.DeviceName;
        entity.MacAddress = device.MacAddress ?? entity.MacAddress;
        Update(entity);
        return entity.ToDeviceDto();
    }

    public async Task<DeviceDto?> UpdateLinkedUser(DeviceDto dto)
    {
        if (!dto.UserId.HasValue)
            return null;

        Device? entity = (await Find(x => x.Id == dto.Id)).FirstOrDefault();
        if (entity == null)
            return null;
        
        if (!await _context.Set<User>().AnyAsync(x => x.Id == dto.UserId))
            return null;

        entity.UserId = dto.UserId.Value;
        Update(entity);
        return entity.ToDeviceDto();
    }

    public async Task DeleteDevice(long deviceId)
    {
        Device? entity = (await Find(x => x.DeviceId == deviceId)).FirstOrDefault();
        if (entity != null)
            Delete(entity!);
    }

    public async Task DeleteDevices(long[] deviceIds)
    {
        IEnumerable<Device> entities = await Find(x => deviceIds.Contains(x.DeviceId));
        if (entities.Any())
            DeleteMany(entities);
    }
}