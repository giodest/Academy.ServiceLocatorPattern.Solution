using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.ServiceLocatorPattern.BL.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Eta { get; set; }

        public Persona(int id, string nome, int eta)
        {
            Id = id;
            Nome = nome;
            Eta = eta;
        }
    }
}
