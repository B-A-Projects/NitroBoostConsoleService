using System.Text.Json;
using NitroBoostConsoleService.Shared.Dto;
using NitroBoostConsoleService.Shared.Interface.Repository;
using NitroBoostConsoleService.Shared.Interface.Service;
using NitroBoostMessagingClient.Dtos;
using NitroBoostMessagingClient.Enums;
using NitroBoostMessagingClient.Interfaces;

namespace NitroBoostConsoleService.Core;

public class DeviceService : IDeviceService
{
    private IDeviceRepository _repository;
    private IBaseSender _sender;

    public DeviceService(IDeviceRepository repository, IBaseSender sender)
    {
        _repository = repository;
        _sender = sender;
    }

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
            return Array.Empty<DeviceDto>();
        return await _repository.GetUserLinkedDevices(userId);
    }

    public async Task<DeviceDto?> AddDevice(DeviceDto device, long userId)
    {
        var result = await _repository.AddDevice(device);
        if (result == null)
            return null;
        
        _sender.Send("hashing", new MessageDto()
        {
            Action = ActionType.Add,
            Body = result.Id.ToString()
        });
        return result;
    }

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

    public async Task UnlinkDevices(long userId)
    {
        
    }

    public async Task DeleteDevice(long deviceId, long userId) => await _repository.DeleteDevice(deviceId);
}