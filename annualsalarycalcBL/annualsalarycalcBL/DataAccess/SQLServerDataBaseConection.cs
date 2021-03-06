﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace IBDLocal.DataAccess
{
    public class SQLServerDataBaseConection : IDataConection
    {
        public static SqlConnection conexion = new SqlConnection();
        public Data executeRequest(string name, List<Parameter> parameters, string connectionString)
        {
            lock (conexion) {
                try
                {
                    conexion.ConnectionString = connectionString;
                    var cmd = new SqlCommand(name, conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (var p in parameters)
                    {
                        var p1 = new SqlParameter(string.Format("{0}{1}", "@", p.nombre)
                                                          , p.valor);
                        p1.Direction = ParameterDirection.Input;

                        cmd.Parameters.Add(p1);
                    }


                    conexion.Open();
                    var reader = cmd.ExecuteReader();

                    return DataBuilder.getData(reader);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conexion != null && conexion.State == ConnectionState.Open)
                    {
                        conexion.Close();
                    }
                }
            }
            
        }
    }
}
