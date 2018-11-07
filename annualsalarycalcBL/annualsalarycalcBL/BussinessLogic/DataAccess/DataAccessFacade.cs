using System;
using System.Collections.Generic;

using System.Text;


namespace IBDLocal.DataAccess
{
    public class DataAccessFacade
    {
        public Data executeRequest(int tipo, string name, List<Parameter> parameters, string connectionString) {
            switch (tipo) {
                
                case 2:
                    return new SQLServerDataBaseConection().executeRequest(name, parameters, connectionString);

                case 1:
                    return new ApiDataConnection().executeRequest(name, parameters, connectionString);

                case 3:
                    return new ApiDataConnectionPost().executeRequest(name, parameters, connectionString);

                default:
                    throw new Exception();
            }

        }
    }
}
