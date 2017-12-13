using System;

namespace ddd_exploring
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var ospitiService = new OspitiService();
                Console.WriteLine("*** CREAZIONE OSPITI ***");
                ospitiService.IngressoNuovoOspite("Rossi");
                ospitiService.IngressoNuovoOspite("Bianchi");
                ospitiService.ListaOspiti();

                Console.WriteLine("*** USCITA OSPITI ***");
                ospitiService.UscitaOspite(1,DateTime.Now);
                ospitiService.UscitaOspite(2,new DateTime(2018,6,5));
                ospitiService.ListaOspiti();

                Console.WriteLine("*** CAMBIO INDIRIZZO OSPITI ***");
                ospitiService.CambioIndirizzo(1, "Nuovo indirizzo del Sig. Rossi");
                ospitiService.CambioIndirizzo(2, null);

                ospitiService.ListaOspiti();


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
