using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ServicioMedico.DAL
{
    interface CRUD<clase>
    {
        string insertar(clase objeto);

        void modificar(clase objeto);

        void borrar(clase objeto);

        clase buscar(clase objeto);

        List<clase> BuscarTodos();

        DataTable BusquedaGeneral();

        DataTable BusquedaGeneral(clase objeto);
    }
}
