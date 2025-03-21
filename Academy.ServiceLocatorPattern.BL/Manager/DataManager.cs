using Academy.ServiceLocatorPattern.BL.Interfaces;
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

        public DataManager (IDataService dataService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        public void Saving(Persona persona)
        {
            _dataService.SaveData(persona);
        }

        public int GetId() => _dataService.GetLastId();

        public Persona GetInformations(int id) => _dataService.GetData(id);
    }
}
