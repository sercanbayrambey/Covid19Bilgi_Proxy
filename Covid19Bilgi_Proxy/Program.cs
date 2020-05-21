using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Covid19Bilgi_Proxy
{
    class Program
    {
        static void Main()
        {

             ICoronaInformation proxy = new ProxyCoronaInformation();
            do
            {
                Console.Clear();


                CovidStats covidStats = proxy.GetCoronaInformation();
                covidStats = proxy.GetCoronaInformation();

                string outputString = String.Format("###########################################\n" +
                    "Toplam Vaka Sayısı: {0}\n" +
                    "Bugünkü Vaka Sayısı: {1}\n" +
                    "Bugünkü Vefat Sayısı: {2}\n" +
                    "Toplam Vefat Sayısı: {3}\n" +
                    "Toplam İyileşen Sayısı: {4}\n" +
                    "Aktif Vaka Sayısı: {5}\n" +
                    "###########################################", covidStats.TotalCases, covidStats.NewCases, covidStats.NewDeaths, covidStats.TotalDeaths, covidStats.TotalRecovered, covidStats.ActiveCases.Replace("99999999999", ""));
                Console.WriteLine(outputString);
            }
            while (Console.ReadKey().Key != ConsoleKey.Enter);
               
            

        }
    }
}
