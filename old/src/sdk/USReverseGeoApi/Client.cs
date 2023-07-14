﻿namespace SmartyStreets.USReverseGeoApi
{
	using System;
	using System.IO;

	public class Client : IUSReverseGeoClient
	{
		private readonly ISender sender;
		private readonly ISerializer serializer;

		public Client(ISender sender, ISerializer serializer)
		{
			this.sender = sender;
			this.serializer = serializer;
		}

		public void Send(Lookup lookup)
		{
			if (lookup == null)
				throw new ArgumentNullException("lookup");

			var request = BuildRequest(lookup);

			var response = this.sender.Send(request);

			using (var payloadStream = new MemoryStream(response.Payload))
			{
				var smartyResponse = this.serializer.Deserialize<SmartyResponse>(payloadStream) ?? new SmartyResponse();
				lookup.SmartyResponse = smartyResponse;
			}
		}

		private static Request BuildRequest(Lookup lookup)
		{
			var request = new Request();

			request.SetParameter("latitude", lookup.Latitude);
			request.SetParameter("longitude", lookup.Longitude);
			request.SetParameter("source", lookup.Source);

			return request;
		}
	}
}