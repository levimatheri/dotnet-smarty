using Smarty.Net.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace core.Shared;
internal static class Utilities
{
    public static void AddQueryParams(HttpRequestMessage request, IDictionary<string, string> parameters)
    {
        if (request.RequestUri is null) return;
        var requestQuery = request.RequestUri.Query;
        var paramParts = requestQuery.TrimStart('?').Split("&");
        var existingParams = new Dictionary<string, string>();

        foreach (var paramPart in paramParts)
        {
            if (!string.IsNullOrEmpty(paramPart))
            {
                var paramVals = paramPart.Split('=');
                if (paramVals.Length == 0)
                {
                    throw new MalformedRequestParametersException(
                        $"Request params not well-formed. Request: {request.RequestUri}");
                    

                }

                existingParams[paramVals[0]] = paramVals[1];
            }
        }

        foreach (var kvp in parameters)
        {
            existingParams[kvp.Key] = kvp.Value;
        }

        var newQueryParamString = string.Join("&", existingParams.Select(x => $"{x.Key}={x.Value}"));
        var newRequestQuery = $"?{newQueryParamString}";

        var uriBuilder = new UriBuilder(request.RequestUri)
        {
            Query = newRequestQuery
        };

        request.RequestUri = uriBuilder.Uri;
    }
}
