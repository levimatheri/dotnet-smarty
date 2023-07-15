using System;

namespace Smarty.Net.Core.USReverseGeoApi
{
	using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    ///     In addition to holding all of the input data for this lookup, this class also
    ///     will contain the result of the lookup after it comes back from the API.
    /// </summary>
    public class Lookup
	{
		public double Latitude { get; set; }
		public double Longitude { get; set; }
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