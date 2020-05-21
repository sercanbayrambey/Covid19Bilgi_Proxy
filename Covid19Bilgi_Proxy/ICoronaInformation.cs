using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Bilgi_Proxy
{
    interface ICoronaInformation
    {

        CovidStats GetCoronaInformation();
    }
}
