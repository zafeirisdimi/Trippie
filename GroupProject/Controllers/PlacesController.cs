using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GroupProject.Helpers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;
using System.Collections.Concurrent;
using System.Web.Http.Cors;
using System.Threading;

namespace GroupProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [RoutePrefix("")]
    public class PlacesController : ApiController
    {
        private static readonly HttpClient _client = new HttpClient();
        private string apiKey = "5ae2e3f221c38a28845f05b6068096737a6bd1b9a215367ca1d1bd33";

        [HttpGet]
        public async Task<PlaceDto[]> GetPlaces(/*List<Coordinates> pathOverview*/)
        {
            //var reducedPath = PointReductionHelper.ReducePoints(pathOverview);

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            Uri placesRadiusAPI = RadiusEndpoint(5000, 23.72784, 37.98376, 3);

            var response = await _client.GetFromJsonAsync<PlaceDto[]>(placesRadiusAPI);

            return response;
        }

        [HttpPost]
        public async Task<IEnumerable<PlaceDto>> GetPlacesAlongPath(List<Coordinates> pathOverview)
        {
            //var reducedPath = PointReductionHelper.ReducePoints(pathOverview);

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            ConcurrentBag<PlaceDto> placesConcur = new ConcurrentBag<PlaceDto>();
            List<PlaceDto> places = new List<PlaceDto>();

            var tasks = new List<Task>();
            var tasksTest = new List<Task<PlaceDto[]>>();

            int batchSize = 10;
            int numberOfBatches = (int)Math.Ceiling((double)pathOverview.Count / batchSize);

            Uri placesRadiusAPI;

            for (int i = 0; i < numberOfBatches; i++)
            {
                var currentCoordinates = pathOverview.Skip(i * batchSize).Take(batchSize);

                System.Diagnostics.Debug.WriteLine($"OuterLoop_{i}");

                for (int j = 0; j < batchSize; j++)
                {
                    placesRadiusAPI = RadiusEndpoint(5000, pathOverview[j].Longitude, pathOverview[j].Latitude, 3);
                    System.Diagnostics.Debug.WriteLine($"InnerLoop_{j}");
                    tasksTest.Add(_client.GetFromJsonAsync<PlaceDto[]>(placesRadiusAPI));
                    //tasks.Add(AddPlacesAsync(currentCoordinates, placesRadiusAPI, placesConcur));
                }

                var currentPlaces = await Task.WhenAll(tasksTest);

                var tester = currentPlaces.SelectMany(placeArray => placeArray);

                foreach (var item in tester)
                {
                    placesConcur.Add(item);
                }

                System.Diagnostics.Debug.WriteLine($"{placesConcur.ToList().Count}");

                await Task.Delay(2000);
                tasksTest.Clear();
            }

            var ok = placesConcur.GroupBy(p => p.xid);

            var okd = ok.Select(g => g.FirstOrDefault());

            return okd;
        }

        [NonAction]
        public Uri RadiusEndpoint(int radius, double lon, double lat, int rate = 2, int limit = 50, string format = "json")
        {
            StringBuilder sb = new StringBuilder();

            var baseUri = "https://api.opentripmap.com/0.1/en/places/radius?";

            sb.Append(baseUri)
              .Append($"radius={radius}")
              .Append($"&lon={lon}")
              .Append($"&lat={lat}")
              .Append($"&rate={rate}")
              .Append($"&limit={limit}")
              .Append($"&format={format}")
              .Append($"&apikey={apiKey}");

            return new Uri(sb.ToString());
        }

        [NonAction]
        public async Task AddPlacesAsync(IEnumerable<Coordinates> coordinates, Uri endpoint, ConcurrentBag<PlaceDto> placeDtos)
        {
            var response = await _client.GetFromJsonAsync<PlaceDto[]>(endpoint);

            foreach (var item in placeDtos)
            {
                placeDtos.Add(item);
            }
        }
    }
}
