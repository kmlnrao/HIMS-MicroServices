public interface IServiceMasterService
{
    Task<List<ServiceMaster>> GetAllAsync();
    Task<ServiceMaster> CreateAsync(ServiceMaster service);
    Task<ServiceMaster> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
}