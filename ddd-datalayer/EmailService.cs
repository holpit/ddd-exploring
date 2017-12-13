using System;

namespace ddd_datalayer
{
    public class EmailService
    {

        public void InvioMessaggio(string email, string messaggio)
        {
            Console.WriteLine($"Inviato messaggio: {messaggio}");
        }
    }
}
