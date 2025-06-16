using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ServiceMasterService : IServiceMasterService
{
    private readonly ServicesDbContext _context;
    public ServiceMasterService(ServicesDbContext context) => _context = context;

    public async Task<List<ServiceMaster>> GetAllAsync() => await _context.ServiceMasters.ToListAsync();

    public async Task<ServiceMaster> CreateAsync(ServiceMaster service)
    {
        _context.ServiceMasters.Add(service);
        await _context.SaveChangesAsync();
        return service;
    }

    public async Task<ServiceMaster> GetByIdAsync(int id)
        => await _context.ServiceMasters.FindAsync(id);

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.ServiceMasters.FindAsync(id);
        if (entity == null) return false;
        _context.ServiceMasters.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}