﻿namespace Smarty.Net.Core.USAutocompleteApi
{
	using System.Runtime.Serialization;

	[DataContract]
	public class Result
	{
		[DataMember(Name = "suggestions")]
		public Suggestion[] Suggestions { get; set; }
	}
}