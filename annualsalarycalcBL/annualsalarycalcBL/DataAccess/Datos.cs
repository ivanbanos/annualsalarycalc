using System;
using System.Collections.Generic;

using System.Text;


namespace ISicom_BDLocal.DataAccess
{
    public class Datos
    {
        public Datos() {
            datos = new List<Registro>();
        }

        private List<Registro> datos;

        public void addDato(Registro registro) {
            datos.Add(registro);
        }

        public Registro getDato(int pos) {
            try
            {
                return datos[pos];
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal int Count()
        {
            return datos.Count;
        }
    }
}
