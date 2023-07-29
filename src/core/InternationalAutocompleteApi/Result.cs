namespace Smarty.Net.Core.InternationalAutocompleteApi
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Result
    {
        [DataMember(Name = "candidates")]
        public IEnumerable<Candidate> Candidates { get; set; } = Enumerable.Empty<Candidate>();
    }
}