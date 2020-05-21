using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Bilgi_Proxy
{
    class CovidStats
    {
        public string Country{ get; set; }

        public string TotalCases { get; set; }

        public string NewCases { get; set; }

        public string TotalDeaths { get; set; }
        public string TotalRecovered { get; set; }
        public string ActiveCases{ get; set; }
        public string NewDeaths { get; set; }


    }
}
