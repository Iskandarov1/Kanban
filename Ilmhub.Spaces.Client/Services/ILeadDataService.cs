using Ilmhub.Spaces.Client.Models;

namespace Ilmhub.Spaces.Client.Services;

public interface ILeadDataService
{
    Task<List<Lead>> GetAllLeadsAsync(CancellationToken cancellationToken = default);
    Task<Lead?> GetLeadByIdOrDefaultAsync(int id, CancellationToken cancellationToken = default);
    Task<Lead> CreateLeadAsync(Lead lead, CancellationToken cancellationToken = default);
    Task<Lead?> UpdateLeadOrDefaultAsync(Lead lead, CancellationToken cancellationToken = default);
    Task<bool> DeleteLeadAsync(int id, CancellationToken cancellationToken = default);
}
