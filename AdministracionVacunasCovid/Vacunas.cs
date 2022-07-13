using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionVacunasCovid
{
    public class Vacunas
    {
        public Vacunas()
        {

        }
        public Vacunas(string nombreCompania, int cantidadAdministrada, int cantidadDisponible)
        {
            NombreCompania = nombreCompania;
            CantidadAdministrada = cantidadAdministrada;
            CantidadDisponible = cantidadDisponible;
        }

        public string NombreCompania { get; set; }
        public int CantidadAdministrada { get; set; }
        public int CantidadDisponible { get; set; }

    }

}
