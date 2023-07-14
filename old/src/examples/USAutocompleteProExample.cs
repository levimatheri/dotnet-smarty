﻿namespace Examples
{
	using System;
	using System.Collections.Generic;
	using SmartyStreets;
	using SmartyStreets.USAutocompleteProApi;

	internal static class USAutocompleteProExample
	{
		public static void Run()
		{
			// We recommend storing your secret keys in environment variables.
			var key = Environment.GetEnvironmentVariable("SMARTY_AUTH_WEB");
			var hostname = Environment.GetEnvironmentVariable("SMARTY_WEBSITE_DOMAIN");
			var credentials = new SharedCredentials(key, hostname);

			// var id = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			// var token = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			// var credentials = new StaticCredentials(id, token);

            // The appropriate license values to be used for your subscriptions
            // can be found on the Subscriptions page the account dashboard.
            // https://www.smartystreets.com/docs/cloud/licensing
			var client = new ClientBuilder(credentials).WithLicense(new List<string>{"us-autocomplete-pro-cloud"})
			    .BuildUsAutocompleteProApiClient();

			var lookup = new Lookup("1042 W Center");
			lookup.PreferGeolocation = "none";

			client.Send(lookup);

			Console.WriteLine("*** Result with no filter ***");
			Console.WriteLine();
			foreach (var suggestion in lookup.Result)
				Console.WriteLine(suggestion.Street, suggestion.City, ", ", suggestion.State);
				
				
			
			// Documentation for input fields can be found at:
			// https://smartystreets.com/docs/cloud/us-autocomplete-api#http-request-input-fields

			lookup.AddStateFilter("CO");
			lookup.AddStateFilter("UT");
			lookup.AddCityFilter("Denver");
			lookup.AddCityFilter("Orem");
			lookup.AddPreferState("CO");
			lookup.AddPreferState("UT");
			//lookup.Selected = "1042 W Center St Apt A (24) Orem UT 84057";
			lookup.MaxResults = 5;
			lookup.PreferGeolocation = GeolocateType.NONE;
			lookup.PreferRatio = 4;
			lookup.Source = "all";

			client.Send(lookup);

			var suggestions = lookup.Result;

			Console.WriteLine();
			Console.WriteLine("*** Result with some filters ***");
			foreach (var suggestion in suggestions)
				Console.WriteLine(suggestion.Street, suggestion.City, ", ", suggestion.State);
		}
	}
}