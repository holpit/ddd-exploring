using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ddd_datalayer.Repository;

namespace ddd_datalayer.Infrastruttura
{
    public class DependencyFactory
    {
        public static PazienteRepository GetPazienteRepository()
        {
            return  new PazienteRepository();
        }
    }

}
