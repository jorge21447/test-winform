using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesoCRUD.Datos
{
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;

        private static Conexion Con = null;

        private Conexion()
        {
            this.Base = "BD_CRUD_1";
            this.Servidor = "DESKTOP-INIG34B\\SQLEXPRESS";
            this.Usuario = "user_test317";
            this.Clave = "123456";

        }
        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString="Server="+this.Servidor+
                                        ";Database="+this.Base+
                                        ";User Id="+this.Usuario+
                                        ";Password="+this.Clave;
            }
            catch(Exception e)
            {
                Cadena = null;
                throw e;
            }
            return Cadena;
        }

        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }

    }
}
