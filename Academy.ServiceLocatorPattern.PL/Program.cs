using Academy.ServiceLocatorPattern.BL;
using Academy.ServiceLocatorPattern.BL.Services;
using Academy.ServiceLocatorPattern.BL.Entities;
using Academy.ServiceLocatorPattern.BL.Interfaces;
using Academy.ServiceLocatorPattern.BL.Manager;
using Academy.ServiceLocatorPattern.BL.DIContainer;

namespace Academy.ServiceLocatorPattern.PL
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DataManager manager = DIContainer.GetDataManager();
            int currentId = manager.GetId();

            Console.WriteLine("Inserisci Nome:");
            var nome = Console.ReadLine();
            Console.WriteLine("Inserisci Età:");
            var eta = int.Parse(Console.ReadLine());
            var persona = new Persona(currentId, nome, eta);



            manager.Saving(persona);
            Console.WriteLine("Dati salvati con successo");

            var personaRecuperato = manager.GetInformations(currentId);

            if(personaRecuperato != null)
            {
                Console.WriteLine($"Persona Recuperata: \nId: {personaRecuperato.Id}\nNome: {personaRecuperato.Nome}\nEta: {personaRecuperato.Eta}");
            }
            else
            {
                Console.WriteLine("La persona non è stata trovata");
            }

        }        
    }
}
