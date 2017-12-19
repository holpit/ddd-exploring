using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd_datalayer.Core
{
    public class Nominativo : ValueObject
    {
        public string Nome { get; }
        public string Cognome { get; }

        public Nominativo(string nome, string cognome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new NominativoException();
            }

            if (string.IsNullOrWhiteSpace(cognome))
            {
                throw new NominativoException();
            }

            Nome = nome;
            Cognome = cognome;

        }


    }

    class NominativoException : Exception
    {

    }
}
