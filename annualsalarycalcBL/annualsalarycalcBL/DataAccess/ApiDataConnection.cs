﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;


namespace IBDLocal.DataAccess
{
    class ApiDataConnection : IDataConection
    {
        public Data executeRequest(string name, List<Parameter> parameters, string connectionString)
        {
            var parametros = "";
            foreach (var p in parameters) {
                if (p.localizacion == 2)
                {
                    parametros += p.valor + ",";
                }
            }

            var uri = new Uri(connectionString  + name + "/" + (parametros.Length > 0 ? parametros.Substring(0, parametros.Length - 1) : ""));


            var http = (HttpWebRequest)HttpWebRequest.Create(uri);
            var byteArray = new UTF8Encoding().GetBytes(ConfigurationManager.AppSettings["UserSICOM"]+":"+ ConfigurationManager.AppSettings["PasswordSICOM"]);

            if (ConfigurationManager.AppSettings["ApiCredentials"] == "True")
            {
                var credentialCache = new System.Net.CredentialCache();
                credentialCache.Add(
                    uri,
                    "Basic",
                    new System.Net.NetworkCredential(ConfigurationManager.AppSettings["User"], ConfigurationManager.AppSettings["Password"])
                );
                http.Credentials = credentialCache;
            }


            
            http.ContentType = "application/json; charset=utf-8";
            foreach (var p in parameters)
            {
                if (p.localizacion==1)
                {
                    http.Headers.Add(p.nombre, p.valor);
                }
            }


            try
            {
                HttpWebResponse response = (HttpWebResponse)http.GetResponse();
                
                    var Data = new Data();
                    using (var sr = new StreamReader(response.GetResponseStream()))
                    {
                        var responseJson = sr.ReadToEnd();
                    try
                    {
                        var jObj = JObject.Parse(responseJson);
                        return DataBuilder.getData(jObj);
                    }
                    catch (Exception) {
                        var jObj = JArray.Parse(responseJson);
                        return DataBuilder.getData(jObj);
                    }
                    }

                
            }
            catch (Exception e)
            {


                var jObj = JObject.Parse("{\"estado\":\"error\"}");
                return DataBuilder.getData(jObj);
            }
        }
    }
}
