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

        public object getField(string field) {
            try {
                return fields[field];
            }
            catch (Exception) {
                return null;
            }
        }
    }
}
