using System;
using ddd_datalayer.Core;
using ddd_datalayer.Infrastruttura;

namespace ddd_exploring
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                //var ospitiService = new OspitiService();
                //Console.WriteLine("*** CREAZIONE OSPITI ***");
                //ospitiService.IngressoNuovoOspite("Rossi");
                //ospitiService.IngressoNuovoOspite("Bianchi");
                //ospitiService.ListaOspiti();


                var pazientiRepository = DependencyFactory.GetPazienteRepository();
                var nominativo = new Nominativo("Mario", "Rossi");
                var indirizzo = new Indirizzo("Via del corso", "12", "Padova", "35100");
                var paziente = Paziente.CreaPaziente(nominativo, indirizzo, new DateTime(1970, 3, 17));
                var nuovoPaziente = pazientiRepository.Create(paziente);
             
                var pazienteSalvato = pazientiRepository.Get(nuovoPaziente.Id);
                pazienteSalvato.CambiaIndirizzo(new Indirizzo("Via cambiata","numero","citta","cap"));
               pazientiRepository.Update(pazienteSalvato);

                pazienteSalvato = pazientiRepository.Get(nuovoPaziente.Id);
                Console.WriteLine(pazienteSalvato.Indirizzo.Via);

                //Console.WriteLine("*** USCITA OSPITI ***");
                //ospitiService.UscitaOspite(1,DateTime.Now);
                //ospitiService.UscitaOspite(2,new DateTime(2018,6,5));
                //ospitiService.ListaOspiti();

                //Console.WriteLine("*** CAMBIO INDIRIZZO OSPITI ***");
                //ospitiService.CambioIndirizzo(1, "Nuovo indirizzo del Sig. Rossi");
                //ospitiService.CambioIndirizzo(2, null);

                //ospitiService.ListaOspiti();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                Console.WriteLine("Done.");
                Console.ReadLine();
            }
        }


    }
}
