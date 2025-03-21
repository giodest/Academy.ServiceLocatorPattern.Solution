using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.ServiceLocatorPattern.BL.Interfaces;
using Academy.ServiceLocatorPattern.BL.Manager;
using Academy.ServiceLocatorPattern.BL.Services;

namespace Academy.ServiceLocatorPattern.BL.DIContainer
{
    public class DIContainer

    {

        public static IDataService GetDataService()

        {
            //if configurazione > istanzia Json
            return new JsonDataService();
            //else configurazione > istanzia Txt
            // return new TxtDataService();
        }



        public static DataManager GetDataManager()

        {

            return new DataManager(GetDataService());

        }

    }
}
