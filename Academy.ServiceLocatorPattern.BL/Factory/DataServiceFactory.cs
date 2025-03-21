using Academy.ServiceLocatorPattern.BL.Interfaces;
using Academy.ServiceLocatorPattern.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.ServiceLocatorPattern.BL.Factory
{
    public class DataServiceFactory
    {
        public static IDataService GetService(string type) 
        {
            switch (type.ToLower())
            {
                case "json":
                    return new JsonDataService();
                case "txt":
                    return new TxtDataService();
                default:
                    throw new ArgumentException($"Tipo di servizio non supportato: {type}");
            }
        }
    }
}
