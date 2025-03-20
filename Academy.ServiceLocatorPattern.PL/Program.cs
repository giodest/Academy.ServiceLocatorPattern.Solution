using Academy.ServiceLocatorPattern.BL;
using Academy.ServiceLocatorPattern.BL.Services;
using Academy.ServiceLocatorPattern.BL.Entities;
using Academy.ServiceLocatorPattern.BL.Interfaces;

namespace Academy.ServiceLocatorPattern.PL
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var persona = new Persona()
            {
                Id = 1,
                Nome = "Giovanni",
                Eta = 26
            };



            var dataService = GetServiceProvider();

            dataService.SaveData(persona);
            Console.WriteLine("Dati salvati con successo");

            var personaRecuperato = dataService.GetData(1);

            if(personaRecuperato != null)
            {
                Console.WriteLine($"Persona Recuperata: \nId: {personaRecuperato.Id}\nNome: {personaRecuperato.Nome}\nEta: {personaRecuperato.Eta}");
            }
            else
            {
                Console.WriteLine("La persona non è stata trovata");
            }

        }

        private static IDataService GetServiceProvider() 
        {
            return new JsonDataService();
        }
    }
}
