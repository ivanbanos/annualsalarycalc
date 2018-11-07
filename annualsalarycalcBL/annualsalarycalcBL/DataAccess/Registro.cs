using System;
using System.Collections.Generic;

using System.Text;


namespace ISicom_BDLocal.DataAccess
{
    public class Registro
    {
        public Registro() {
            campos = new Dictionary<string, object>();
        }

        private Dictionary<string, object> campos;

        public bool addDato(string campo, object valor)
        {
            try
            {
                campos.Add(campo, valor);
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        public object getCampo(string campo) {
            try {
                return campos[campo];
            }
            catch (Exception) {
                return null;
            }
        }
    }
}
