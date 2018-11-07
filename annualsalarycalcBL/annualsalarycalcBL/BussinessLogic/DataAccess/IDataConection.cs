using System;
using System.Collections.Generic;

using System.Text;


namespace IBDLocal.DataAccess
{
    interface IDataConection
    {
        Data executeRequest(string name, List<Parameter> parameters, string connectionString, int tipoRespuesta);
    }
}
