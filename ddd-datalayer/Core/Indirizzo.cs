using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd_datalayer.Core
{
    public class Indirizzo : ValueObject
    {
        public string Via { get; }
        public string Numero { get; }
        public string Citta { get;  }
        public string Cap { get;  }

        public Indirizzo(string via, string numero, string citta, string cap)
        {

            Via = via;
            Numero = numero;
            Citta = citta;
            Cap = cap;


        }

    }
}
