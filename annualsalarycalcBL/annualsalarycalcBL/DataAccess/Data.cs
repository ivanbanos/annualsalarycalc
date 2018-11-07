using System;
using System.Collections.Generic;

using System.Text;


namespace IBDLocal.DataAccess
{
    public class Data
    {
        public Data() {
            data = new List<Record>();
        }

        private List<Record> data;

        public void addData(Record Record) {
            data.Add(Record);
        }

        public Record getDato(int pos) {
            try
            {
                return data[pos];
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal int Count()
        {
            return data.Count;
        }
    }
}
