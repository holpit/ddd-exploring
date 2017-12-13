using System.Data.Entity;

namespace ddd_datalayer
{
   public class Sw1Context: DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public Sw1Context():base("PatientsConnectionString")
        {
            
        }
    }
}
