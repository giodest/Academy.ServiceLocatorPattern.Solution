using Academy.ServiceLocatorPattern.BL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.ServiceLocatorPattern.BL.Interfaces
{
    public interface IDataService
    {
        public Persona GetData(int id);
        public void SaveData(Persona persona);
        int GetLastIdFromFile(string _filepath);
        int GetLastIdFromFile();

    }
}
