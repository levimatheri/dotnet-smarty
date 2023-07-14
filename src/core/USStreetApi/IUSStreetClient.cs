using System.Collections.Generic;
using Refit;
using Smarty.Net.Core.Shared;

namespace Smarty.Net.Core.USStreetApi;

public interface IUSStreetClient
{
    [Get("/street-address")]
    Task<IReadOnlyList<Candidate>> GetCandidatesAsync(Lookup lookup);

    [Post("/street-address")]
    Task<IReadOnlyList<Candidate>> GetCandidatesBatchAsync([Body]Batch lookup);
}
