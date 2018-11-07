using System;
using System.Collections.Generic;

using System.Text;


namespace ISicom_BDLocal.DataAccess
{
    interface IDataConection
    {
        Datos executeRequest(string name, List<Parameter> parameters, string connectionString, int tipoRespuesta);
    }
}
