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
            private readonly string _filePath = @"C:\Users\destr\source\repos\Academy.ServiceLocatorPattern.Solution\Dati.txt";
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
        }
    
}

