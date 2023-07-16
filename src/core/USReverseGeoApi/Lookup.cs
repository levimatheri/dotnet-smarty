using System;

namespace Smarty.Net.Core.USReverseGeoApi
{
	using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Refit;

    /// <summary>
    ///     In addition to holding all of the input data for this lookup, this class also
    ///     will contain the result of the lookup after it comes back from the API.
    /// </summary>
    public class Lookup
	{
		[AliasAs("latitude")]
		public double Latitude { get; set; }

		[AliasAs("longitude")]
		public double Longitude { get; set; }

		[AliasAs("source")]
		public DataSource? Source { get; set; } = DataSource.Postal;

		public enum DataSource
		{
			[EnumMember(Value = "all")]
			All = 1,
			
			[EnumMember(Value = "postal")]
			Postal = 2
		}
	}
}