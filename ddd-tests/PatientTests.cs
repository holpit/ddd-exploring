using System;
using ddd_datalayer.Core;
using ddd_exploring;
using Xunit;

namespace ddd_tests
{
    public class PatientTests
    {
        [Fact]
        public void Nuovo_Paziente_Viene_Registrato_Con_Tutti_I_Dati()
        {
            var ospitiService = new OspitiService();
            var sut = ospitiService.IngressoNuovoOspite("Verdi");
            //E' stata spedita la mail?
            Assert.Equal("Verdi", sut.Cognome);
        }

        [Fact]
        public void La_Dimissione_Imposta_La_Data_Uscita()
        {
            var ospitiService = new OspitiService();
            var dataUscita = new DateTime(2017, 10, 5, 23, 45, 00);
            var ospite = ospitiService.IngressoNuovoOspite("Neri");
            ospitiService.UscitaOspite(ospite.Id, dataUscita);
            var sut = ospitiService.GetOspite(ospite.Id);
            Assert.Equal(dataUscita, sut.DataUscita);
        }

        [Fact]
        public void Nuovo_Paziente_Viene_Registrato_Con_Tutti_I_Dati_DDD()
        {

            var sut = Paziente.CreaPaziente(
                new Nominativo("Mario", "Rossi"),
                new Indirizzo("Via", "10", "Citta", "CAP"),
                new DateTime(1970, 2, 4));
            //E' stata spedita la mail?
            Assert.Equal("Rossi", sut.Nominativo.Cognome);
            Assert.Equal("10",sut.Indirizzo.Numero);
        }
    }
}
