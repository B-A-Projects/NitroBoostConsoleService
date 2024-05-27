using NitroBoostConsoleService.Shared.Dto;

namespace NitroBoostConsoleService.Shared.Interface.Repository;

public interface IDeviceRepository
{
    Task<DeviceDto?> GetDeviceById(long deviceId);
    Task<DeviceDto?> GetDeviceByConsoleId(long deviceId);
    Task<DeviceDto[]> GetUserLinkedDevices(long userId);
    Task<DeviceDto?> AddDevice(DeviceDto device);
    Task<DeviceDto?> UpdateLinkedUser(DeviceDto device);
    Task<DeviceDto?> UpdateDeviceInfo(DeviceDto device);
    Task DeleteDevice(long deviceId);
}