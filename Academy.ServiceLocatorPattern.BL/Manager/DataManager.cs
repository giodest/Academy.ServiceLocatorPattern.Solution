using Academy.ServiceLocatorPattern.BL.Interfaces;
using Academy.ServiceLocatorPattern.BL.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.ServiceLocatorPattern.BL.Entities;

namespace Academy.ServiceLocatorPattern.BL.Manager
{
    public class DataManager
    {
        private readonly IDataService _dataService;

        public DataManager (string serviceType)
        {
            _dataService = DataServiceFactory.GetService(serviceType);
        }

        public void Saving(Persona persona)
        {
            _dataService.SaveData(persona);
        }

        public int GetId() => _dataService.GetLastId();

        public Persona GetInformations(int id) => _dataService.GetData(id);
    }
}
