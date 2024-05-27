using NitroBoostConsoleService.Shared.Dto;

namespace NitroBoostConsoleService.Shared.Interface.Service;

public interface IDeviceService
{
    Task<DeviceDto?> GetDeviceById(long deviceId, long userId);
    Task<DeviceDto[]> GetUserLinkedDevices(long userId);
    Task<DeviceDto?> AddDevice(DeviceDto device, long userId);
    Task<DeviceDto?> UpdateDevice(DeviceDto device, long userId);
    Task DeleteDevice(long deviceId, long userId);
}