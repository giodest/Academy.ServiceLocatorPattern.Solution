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
        private readonly string _filePath = @"C:\Users\destr\source\repos\Academy.ServiceLocatorPattern.Solution\Dati.txt";

        public int GetLastIdFromFile()
        {
            return GetLastIdFromFile(_filePath);
        }

        public int GetLastIdFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadLines(filePath).ToArray();
                if (lines.Length > 0)
                {
                    var lastLine = lines.Last();
                    var lastId = int.Parse(lastLine.Split('|')[0]);
                    return lastId + 1;
                }
            }
            return 1;
        }

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
                        rc = new Persona(int.Parse(parts[0]), parts[1], int.Parse(parts[2]));                        
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
