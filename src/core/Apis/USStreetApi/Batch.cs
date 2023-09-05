using Smarty.Net.Core.Apis.Shared;

namespace Smarty.Net.Core.Apis.USStreetApi;

public class Batch : Batch<Lookup>
{
    private const int MaxBatchSize = 100;
    public Batch() : base(MaxBatchSize)
    {
    }
}