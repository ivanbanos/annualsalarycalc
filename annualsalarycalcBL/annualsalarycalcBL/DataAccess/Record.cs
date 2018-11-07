using System;
using System.Collections.Generic;

using System.Text;


namespace IBDLocal.DataAccess
{
    public class Record
    {
        public Record() {
            fields = new Dictionary<string, object>();
        }

        private Dictionary<string, object> fields;

        public bool addData(string Field, object valor)
        {
            try
            {
                fields.Add(Field, valor);
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        internal int getIntField(string field)
        {
            try
            {
                return Int32.Parse((string)fields[field]);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        internal float getFloatField(string field)
        {
            try
            {
                return float.Parse((string)fields[field]);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public object getField(string field)
        {
            try
            {
                return fields[field];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string getStringField(string field)
        {
            try
            {
                return (string)fields[field];
            }
            catch (Exception)
            {
                return null;
            }
        }
        
    }
}
