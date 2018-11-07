using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Text;


namespace ISicom_BDLocal.DataAccess
{
    public class DatosBuilder
    {
        public static Datos getDatos(object response) {
            Datos datos = new Datos();
            try
            {
                if (response.GetType().Equals(typeof(JObject)))
                {
                    
                        Registro registro = new Registro();
                        foreach (var x in (JObject)response)
                        {
                            registro.addDato(x.Key, ((JObject)response)[x.Key].ToString());
                        }
                        datos.addDato(registro);
                    
                    return datos;
                }
                if (response.GetType().Equals(typeof(string)))
                {
                    Registro registro = new Registro();
                    registro.addDato("respuesta", response);
                    datos.addDato(registro);
                    return datos;
                }
                if (response.GetType().Equals(typeof(SqlDataReader)))
                {
                    DataTable tabla = new DataTable();
                    tabla.Load((SqlDataReader)response);

                    foreach (DataRow row in tabla.Rows)
                    {
                        Registro registro = new Registro();
                        foreach (DataColumn column in row.Table.Columns)
                        {
                            registro.addDato(column.ColumnName, row[column] is DBNull ? "" : row[column]);
                        }
                        datos.addDato(registro);
                    }
                    return datos;
                }
            }
            catch (Exception) { }
            return datos;

        }
    }
}
