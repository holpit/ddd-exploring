using System;
using System.Linq;
using ddd_datalayer;

namespace ddd_exploring
{
    public class OspitiService
    {
        public Patient IngressoNuovoOspite(string cognome)
        {
            using (var ctx = new Sw1Context())
            {
                var esiste = ctx.Patients.FirstOrDefault(x => x.Cognome == cognome);
                if (esiste == null)
                {
                    Patient patient = new Patient();
                    patient.Nome = "Mario";
                    patient.Cognome = cognome;
                    patient.DataNascita = new DateTime(1950, 4, 6);
                    patient.Indirizzo = "Via del piffero 45, 10100 Paperopoli";
                    patient.DataIngresso = DateTime.Today;

                    ctx.Patients.Add(patient);
                    ctx.SaveChanges();

                    var emailService = new EmailService();
                    emailService.InvioMessaggio("amministrazione@mail.it", $"Ospite entrato id {patient.Id}, {patient.Cognome}");
                    return patient;
                }
                return null;

            }

        }

        public void ListaOspiti()
        {

            using (var ctx = new Sw1Context())
            {
                var totale = ctx.Patients.Count();
                Console.WriteLine($"Nella struttura ci sono {totale} ospiti");

                foreach (var ospite in ctx.Patients)
                {
                    Console.WriteLine($"Id {ospite.Id}, Cognome: {ospite.Cognome}. Ingresso: {ospite.DataIngresso}. Uscita {ospite.DataUscita}. Indirizzo: {ospite.Indirizzo}");
                }
                ctx.SaveChanges();
            }
        }

        public Patient CambioIndirizzo(int id, string indirizzo)
        {

            using (var ctx = new Sw1Context())
            {
                var ospite = ctx.Patients.Single(x => x.Id == id);

                ospite.Indirizzo = indirizzo;
                ctx.SaveChanges();
                return ospite;
            }

        }

        public void UscitaOspite(int id, DateTime data)
        {
            using (var ctx = new Sw1Context())
            {
                var ospite = ctx.Patients.FirstOrDefault(x => x.Id == id);
                if (ospite != null)
                {
                    ospite.DataUscita = data;
                    ctx.SaveChanges();

                    var emailService = new EmailService();
                    emailService.InvioMessaggio("amministrazione@mail.it", $"Ospite dimesso id {ospite.Id}, {ospite.Cognome}");
                }


            }
        }

        public Patient GetOspite(int id)
        {
            using (var ctx = new Sw1Context())
            {
                var ospite = ctx.Patients.FirstOrDefault(x => x.Id == id);
                return ospite;


            }

        }
    }
}
