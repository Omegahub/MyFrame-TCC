using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class ConnectionFactory
    {
        //public static string nomeConexao = "ConexaoSomee";
        public static string nomeConexao = "ConexaoHoracio";
        

        //Método retornará o caminho da conexão utilizando a variável declarada anteriormente.        
        public static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings[nomeConexao].ConnectionString;
        }

        public bool TestarConexao()
        {
            bool conectado = false;

            try
            {
                using (SqlConnection con = new SqlConnection(GetStringConexao()))
                {
                    con.Open();
                    conectado = (con.State == System.Data.ConnectionState.Open);
                    con.Close();
                    return conectado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao estabelecer conexão: " + ex.Message);
            }
        }
    }
}
