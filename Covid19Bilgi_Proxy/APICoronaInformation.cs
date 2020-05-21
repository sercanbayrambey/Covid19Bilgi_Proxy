using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Bilgi_Proxy
{
    class APICoronaInformation : ICoronaInformation
    {
        public CovidStats GetCoronaInformation()
        {
            var client = new RestClient("https://api.collectapi.com/corona/countriesData");
            var request = new RestRequest(Method.GET).AddParameter("country", "Turkey");
            request.AddHeader("authorization", "apikey 6L6crjOSv7ARGetMUth1nf:0FxCOOpzVG5VpIGpLhkiDK");
            request.AddHeader("content-type", "application/json");
            IRestResponse data = client.Execute(request);
            string response = data.Content.ToString();

            JToken token = JObject.Parse(response);
            var result = token.SelectToken("result");
            CovidStats covidStats = JsonConvert.DeserializeObject<CovidStats>(result.ToString());

            return covidStats;
        }
    }
}
