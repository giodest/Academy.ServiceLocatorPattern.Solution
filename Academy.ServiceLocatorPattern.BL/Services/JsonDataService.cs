using Academy.ServiceLocatorPattern.BL.Entities;
using Academy.ServiceLocatorPattern.BL.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.ServiceLocatorPattern.BL.Services
{    
        public class JsonDataService : IDataService
        {
            private readonly string _filePath = @"C:\Users\destr\source\repos\Academy.ServiceLocatorPattern.Solution\Dati.json";
                
        public Persona GetData(int id)
            {
                if (!File.Exists(_filePath)) return null;

                var json = File.ReadAllText(_filePath);
                var persons = JsonConvert.DeserializeObject<Persona[]>(json);
                return persons.FirstOrDefault(p => p.Id == id);
            }

            public void SaveData(Persona persona)
            {
                var persons = File.Exists(_filePath)
                 ? JsonConvert.DeserializeObject<Persona[]>(File.ReadAllText(_filePath))
                 : Array.Empty<Persona>();

                var list = persons.ToList();
                list.Add(persona);

                string json = JsonConvert.SerializeObject(list.ToArray(), Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(_filePath, json);
            }


        public int GetLastId()
        {
            return GetLastIdFromFile(_filePath);
        }

        public int GetLastIdFromFile(string _filePath)
        {
            if (File.Exists(_filePath))
            {
                var jsonContent = File.ReadAllText(_filePath);

                var persone = JsonConvert.DeserializeObject<List<Persona>>(jsonContent);

                if (persone != null && persone.Count > 0)
                {
                    var lastPerson = persone.Last();
                    return lastPerson.Id + 1;
                }
            }

            return 1;
        }
    }
    
}

