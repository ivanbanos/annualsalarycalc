﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;


namespace ISicom_BDLocal.DataAccess
{
    class ApiDataConnectionPost : IDataConection
    {
        public Datos executeRequest(string name, List<Parameter> parameters, string connectionString, int tipoRespuesta)
        {
            string parametros = "";
            foreach (Parameter p in parameters)
            {
                if (p.localizacion == 2)
                {
                    parametros += p.valor + ",";
                }
            }

            Uri uri = new Uri(connectionString + name + "/" + (parametros.Length > 0 ? parametros.Substring(0, parametros.Length - 1) : ""));
            

            HttpWebRequest http = (HttpWebRequest)HttpWebRequest.Create(uri);
            var byteArray = new UTF8Encoding().GetBytes(ConfigurationManager.AppSettings["UserSICOM"] + ":" + ConfigurationManager.AppSettings["PasswordSICOM"]);
            http.Method = "POST";
            if (ConfigurationManager.AppSettings["ApiCredentials"] == "True")
            {
                System.Net.CredentialCache credentialCache = new System.Net.CredentialCache();
                credentialCache.Add(
                    uri,
                    "Basic",
                    new System.Net.NetworkCredential(ConfigurationManager.AppSettings["User"], ConfigurationManager.AppSettings["Password"])
                );
                http.Credentials = credentialCache;
            }
            


            
            http.ContentType = "application/json; charset=utf-8";
            foreach (Parameter p in parameters)
            {
                if (p.localizacion == 1)
                {
                    http.Headers.Add(p.nombre, p.valor);
                }
                if (p.localizacion == 3)
                {
                    using (var streamWriter = new StreamWriter(http.GetRequestStream()))
                    {

                        streamWriter.Write(p.valor);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }

                }
            }
            try
            {
                HttpWebResponse response = (HttpWebResponse)http.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                {
                    Datos datos = new Datos();
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        string responseJson = sr.ReadToEnd();

                        JObject jObj = JObject.Parse(responseJson);
                        return DatosBuilder.getDatos(jObj);
                    }

                }
                else
                {

                    JObject jObj = JObject.Parse("{\"estado\":\""+ response.StatusDescription + "\"}");
                    return DatosBuilder.getDatos(jObj);
                }
            }
            catch (Exception e)
            {
                

                JObject jObj = JObject.Parse("{\"estado\":\"error\"}");
                return DatosBuilder.getDatos(jObj);
            }

            

            
        }
    }
}