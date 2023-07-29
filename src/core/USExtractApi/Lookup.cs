using Refit;
using System.Runtime.Serialization;

namespace Smarty.Net.Core.USExtractApi
{
    /// <summary>
    ///     In addition to holding all of the input data for this lookup, this class also
    ///     will contain the result of the lookup after it comes back from the API.
    /// </summary>
    /// <remarks>See "https://smartystreets.com/docs/cloud/us-extract-api#http-request-input-fields"</remarks>
    public class Lookup
    {
        [AliasAs("aggressive")]
        public bool? IsAggressive { get; set; } = false;

        [AliasAs("addr_line_breaks")]
        public bool? AddressesHaveLineBreaks { get; set; } = true;

        [AliasAs("addr_per_line")]
        public int? AddressesPerLine { get; set; } = 0;

        [AliasAs("html")]
        public bool? IsHtml { get; set; }

        [AliasAs("match")]
        public MatchStrategy? Match { get; set; } = MatchStrategy.Strict;

        public enum MatchStrategy
        {
            [EnumMember(Value = "strict")]
            Strict = 1,

            [EnumMember(Value = "enhanced")]
            Enhanced = 2,

            [EnumMember(Value = "invalid")]
            Invalid = 3
        }

    }
}