using System;
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

    }
}
