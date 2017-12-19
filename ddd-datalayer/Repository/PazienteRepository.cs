using ddd_datalayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd_datalayer.Repository
{
    public class PazienteRepository
    {

        public Paziente Create(Paziente paziente)
        {
            using (var ctx = new Sw1Context())
            {
                var patient = new Patient
                {
                    Nome = paziente.Nominativo.Nome,
                    Cognome = paziente.Nominativo.Cognome,
                    DataNascita = paziente.DataNascita,
                    Indirizzo = paziente.Indirizzo.Via
                };
                ctx.Patients.Add(patient);
                ctx.SaveChanges();
                return Paziente.CreaDaRepository(
                    patient.Id,
                    patient.Nome,
                    patient.Cognome,
                    patient.Indirizzo,
                    patient.DataNascita);
                

            }
        }

        public Paziente Get(int id)
        {
            using (var ctx = new Sw1Context())
            {
                var pazienteData = ctx.Patients.Single(x => x.Id == id);
                return Paziente.CreaDaRepository(
                    pazienteData.Id,
                    pazienteData.Nome,
                    pazienteData.Cognome,
                    pazienteData.Indirizzo,
                    pazienteData.DataNascita);
            }
        }

        public void Update(IAggregate paziente)
        {
            using (var ctx = new Sw1Context())
            {
                var aggregate = (Paziente)paziente;
                var pazienteData = ctx.Patients.Single(x => x.Id == aggregate.Id);
                pazienteData.Nome = aggregate.Nominativo.Nome;
                pazienteData.Cognome = aggregate.Nominativo.Cognome;
                pazienteData.Indirizzo = aggregate.Indirizzo.Via;
                pazienteData.DataNascita = aggregate.DataNascita;
                ctx.SaveChanges();
            }
        }
    }
}
