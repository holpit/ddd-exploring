using System;

namespace ddd_datalayer
{
    public class Patient
    {
      
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public DateTime DataNascita { get; set; }
        public DateTime? DataIngresso { get; set; }
        public DateTime? DataUscita { get; set; }

    }
}
