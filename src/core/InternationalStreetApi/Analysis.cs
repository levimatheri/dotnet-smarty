namespace Smarty.Net.Core.InternationalStreetApi
{
    using System.Runtime.Serialization;

    /// <summary>
    ///     See "https://smartystreets.com/docs/cloud/international-street-api#analysis"
    /// </summary>
    [DataContract]
    public class Analysis
    {
        [DataMember(Name = "verification_status")]
        public VerificationStatusType VerificationStatus { get; set; }

        [DataMember(Name = "address_precision")]
        public AddressPrecisionType AddressPrecision { get; set; }

        [DataMember(Name = "max_address_precision")]
        public AddressPrecisionType MaxAddressPrecision { get; set; }

        [DataMember(Name = "changes")]
        public Changes Changes { get; set; }

        public enum VerificationStatusType
        {
            None = 0,
            Partial = 1,
            Ambiguous = 2,
            Verified = 3
        }

        public enum AddressPrecisionType
        {
            None = 0,
            AdministrativeArea = 1,
            Locality = 2,
            Thoroughfare = 3,
            Premise = 4,
            DeliveryPoint = 5
        }
    }
}