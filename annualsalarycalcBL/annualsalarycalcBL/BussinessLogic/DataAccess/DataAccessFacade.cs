using System;
using System.Collections.Generic;

using System.Text;


namespace IBDLocal.DataAccess
{
    public class DataAccessFacade
    {
        public Data executeRequest(int tipo, string name, List<Parameter> parameters, string connectionString, int tipoRespuesta) {
            switch (tipo) {
                
                case 2:
                    return new SQLServerDataBaseConection().executeRequest(name, parameters, connectionString, tipoRespuesta);

                case 1:
                    return new ApiDataConnection().executeRequest(name, parameters, connectionString, tipoRespuesta);

                case 3:
                    return new ApiDataConnectionPost().executeRequest(name, parameters, connectionString, tipoRespuesta);

                default:
                    throw new Exception();
            }

        }
    }
}
