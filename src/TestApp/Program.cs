using Serilog;
using Serilog.Formatting.Compact;
using Smarty.Net.Core.USStreetApi;
using Smarty.Net.Core.USZipCodeApi;
using TestApp;

Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(new CompactJsonFormatter())
                .MinimumLevel.Verbose()
                .CreateLogger();



string authId = "f7b6ef9b-8a3f-4f23-956d-788d714162c3";
string authToken = "YagchQwvTGhELfjdvXyz";

// ----- STREET API -----
// var api = new USStreetsApi(
//     new Uri("https://us-street.api.smartystreets.com"),
//     Log.Logger,
//     authId, authToken);
// var lookup = new Smarty.Net.Core.USStreetApi.Lookup 
// {
//     Street = "1600 Amphitheatre Pkwy",
//     City = "Mountain View",
//     State = "CA",
//     MaxCandidates = 10
// };
// var results = await api.GetCandidatesAsync(lookup);

// Log.Debug("{results}", results);


// ----- Batch STREET API -----
// var api = new USStreetsApi(
//     new Uri("https://us-street.api.smartystreets.com"), 
//     Log.Logger,
//     authId, authToken);
// var batch = new Smarty.Net.Core.USStreetApi.Batch
// {
//     new Smarty.Net.Core.USStreetApi.Lookup
//     {
//         Street = "1600 Amphitheatre Pkwy",
//         City = "Mountain View",
//         State = "CA",
//         MaxCandidates = 10
//     },
//     new Smarty.Net.Core.USStreetApi.Lookup
//     {
//         Street = "2600 Cleveland Ave",
//         City = "Canton",
//         State = "OH",
//         MaxCandidates = 10
//     }
// };

// var results = await api.GetCandidatesBatchAsync(batch);

//Log.Debug("{results}", results);

// ----- ZIPCODE API -----
var api = new USZipCodeApi(
    new Uri("https://us-zipcode.api.smartystreets.com"),
    Log.Logger,
    authId, authToken);
var lookup = new Smarty.Net.Core.USZipCodeApi.Lookup
{
    ZipCode = "44721"
};

var results = await api.GetResultsAsync(lookup);

// Log.Debug("{results}", results);