using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Text;


namespace IBDLocal.DataAccess
{
    public class DataBuilder
    {
        public static Data getData(object response) {
            Data Data = new Data();
            try
            {
                if (response.GetType().Equals(typeof(JObject)))
                {
                    
                        Record record = new Record();
                        foreach (var x in (JObject)response)
                        {
                            record.addData(x.Key, ((JObject)response)[x.Key].ToString());
                        }
                        Data.addData(record);
                    
                    return Data;
                }
                if (response.GetType().Equals(typeof(JArray)))
                {
                    foreach(JObject jobject in (JArray)response) {
                        Record record = new Record();
                        foreach (var x in jobject)
                        {
                            record.addData(x.Key, (jobject)[x.Key].ToString());
                        }
                        Data.addData(record);

                    }

                    return Data;
                }
                if (response.GetType().Equals(typeof(string)))
                {
                    Record record = new Record();
                    record.addData("respuesta", response);
                    Data.addData(record);
                    return Data;
                }
                if (response.GetType().Equals(typeof(SqlDataReader)))
                {
                    DataTable tabla = new DataTable();
                    tabla.Load((SqlDataReader)response);

                    foreach (DataRow row in tabla.Rows)
                    {
                        Record Record = new Record();
                        foreach (DataColumn column in row.Table.Columns)
                        {
                            Record.addData(column.ColumnName, row[column] is DBNull ? "" : row[column]);
                        }
                        Data.addData(Record);
                    }
                    return Data;
                }
            }
            catch (Exception e) {

            }
            return Data;

        }
    }
}
