using Academy.ServiceLocatorPattern.BL.Entities;
using Academy.ServiceLocatorPattern.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.ServiceLocatorPattern.BL.Services
{
    public class TxtDataService : IDataService
    {
        private readonly string _filePath = @"C:\Users\destr\source\repos\Academy.ServiceLocatorPattern.Solution";
        public Persona GetData(int id)
        {
            Persona rc = null;

            if (File.Exists(_filePath))
            {
                var lines = File.ReadAllLines(_filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 3 && int.Parse(parts[0]) == id)
                    {
                        rc = new Persona
                        {
                            Id = int.Parse(parts[0]),
                            Nome = parts[1],
                            Eta = int.Parse(parts[2])
                        };
                    }
                }
            }
            return rc;
        }

        public void SaveData(Persona persona)
        {
            string data = $"{persona.Id}|{persona.Nome}|{persona.Eta}";
            File.AppendAllTextAsync(_filePath, data + Environment.NewLine);
        }
    }
}
