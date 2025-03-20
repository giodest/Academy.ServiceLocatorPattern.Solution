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

            var dataService = GetServiceProvider();
            int currentId = dataService.GetLastIdFromFile();

            Console.WriteLine("Inserisci Nome:");
            var nome = Console.ReadLine();
            Console.WriteLine("Inserisci Età:");
            var eta = int.Parse(Console.ReadLine());
            var persona = new Persona(currentId, nome, eta);



            dataService.SaveData(persona);
            Console.WriteLine("Dati salvati con successo");

            var personaRecuperato = dataService.GetData(currentId);

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
            return new TxtDataService();
        }
    }
}
