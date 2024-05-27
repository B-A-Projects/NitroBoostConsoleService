using NitroBoostConsoleService.Shared.Dto;
using NitroBoostConsoleService.Shared.Interface.Repository;
using NitroBoostConsoleService.Shared.Interface.Service;

namespace NitroBoostConsoleService.Core;

public class DeviceService : IDeviceService
{
    private IDeviceRepository _repository;

    public DeviceService(IDeviceRepository repository) => _repository = repository;
    
    public async Task<DeviceDto?> GetDeviceById(long deviceId, long userId)
    {
        if (deviceId < 1)
            return null;
        
        DeviceDto? device = await _repository.GetDeviceById(deviceId);
        if (device?.UserId == null)
            return null;
        if (device.UserId != userId)
            return null;
        return device;
    }

    public async Task<DeviceDto[]> GetUserLinkedDevices(long userId)
    {
        if (userId < 1)
            return [];
        return await _repository.GetUserLinkedDevices(userId);
    }

    public async Task<DeviceDto?> AddDevice(DeviceDto device, long userId) => await _repository.AddDevice(device);

    public async Task<DeviceDto?> UpdateDevice(DeviceDto device, long userId) => await _repository.UpdateDeviceInfo(device);

    public async Task<DeviceDto?> LinkDevice(long deviceId, long userId)
    {
        if (deviceId < 1 || userId < 1)
            return null;

        DeviceDto? device = await _repository.GetDeviceByConsoleId(deviceId);
        if (device == null || device?.UserId != null)
            return null;
        device.UserId = userId;
        return await _repository.UpdateLinkedUser(device);
    }

    // public async Task<DeviceDto?> UnlinkDevice(long deviceId, long userId)
    // {
    //     
    // }

    public async Task DeleteDevice(long deviceId, long userId) => await _repository.DeleteDevice(deviceId);
}