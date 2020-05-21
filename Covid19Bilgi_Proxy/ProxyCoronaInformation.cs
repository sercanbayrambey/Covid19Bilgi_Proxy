using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Bilgi_Proxy
{
    class ProxyCoronaInformation : ICoronaInformation
    {
        private APICoronaInformation _apiCoronaObject;
        private bool LoadRealObject = false;
        private CovidStats covidStatsCached = null;
        private DateTime APILastCallDate;

        private CovidStats GetCovidStatsFromAPI()
        {
            try
            {

                if (APILastCallDate.Equals(DateTime.MinValue))
                    APILastCallDate = DateTime.Now;
                _apiCoronaObject = new APICoronaInformation();
                covidStatsCached = _apiCoronaObject.GetCoronaInformation();
                LoadRealObject = true;
                APILastCallDate = DateTime.Now;
                return covidStatsCached;
            }

            catch
            {
                LoadRealObject = false;
                return null;
            }
        }
        public CovidStats GetCoronaInformation()
        {
            LoadRealObject = false;
            CovidStats covidStats = null;
            TimeSpan span = DateTime.Now.Subtract(APILastCallDate);


            if (_apiCoronaObject == null || span.TotalMinutes > 1)
            {
                covidStats = GetCovidStatsFromAPI();
            }


            if (!LoadRealObject) // uzak nesne oluştu mu?
                return covidStatsCached;
            else
                return covidStats;

        }
    }
}
