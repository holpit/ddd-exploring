using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd_datalayer.Core
{
    public class Paziente : Entity, IAggregate
    {
        public Nominativo Nominativo { get; private set; }

        public Indirizzo Indirizzo { get; private set; }
        public DateTime DataNascita { get; private set; }
        private Paziente() { }
        public static Paziente CreaPaziente(Nominativo nominativo, Indirizzo indirizzo, DateTime dataNascita)
        {
            return new Paziente
            {
                Nominativo = nominativo,
                Indirizzo = indirizzo,
                DataNascita = dataNascita
            };
        }

        public void CambiaIndirizzo(Indirizzo indirizzo)
        {
            Indirizzo = indirizzo;
        }

        public void ModificaNominativo(Nominativo nominativo)
        {
            Nominativo = nominativo;
        }

        public static Paziente CreaDaRepository(int id,string nome, string cognome, string via, DateTime dataNascita)
        {
            return new Paziente
            {
                Id=id,
                Nominativo =  new Nominativo(nome, cognome),
                Indirizzo = new Indirizzo(via,"10","citta","cap"),
                DataNascita = dataNascita
                };
        }

    }
}
