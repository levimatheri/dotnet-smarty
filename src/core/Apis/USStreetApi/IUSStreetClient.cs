using Refit;

namespace Smarty.Net.Core.Apis.USStreetApi;

public interface IUSStreetClient
{
    [Get("/street-address")]
    Task<IReadOnlyList<Candidate>> GetCandidatesAsync(Lookup lookup, CancellationToken cancellationToken = default);

    [Post("/street-address")]
    Task<IReadOnlyList<Candidate>> GetCandidatesBatchAsync([Body] Batch lookup, CancellationToken cancellationToken = default);
}
