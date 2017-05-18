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

        DataTable buscar(int id);

        
    }
}
