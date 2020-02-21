using Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class GestorDAL
    {
        public static int Insert(Gestor g)
        {

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Gestor ");
                sql.AppendLine("(idGestor, nomeGestor, dtNascGestor) ");
                sql.AppendLine("VALUES (@idGestor, @nomeGestor, @dtNascGestor) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nomeGestor", g.NomeGestor);
                    cmd.Parameters.AddWithValue("@dtNascGestor", g.DtNascGestor);

                    con.Open();
                    g.IdGestor = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            return g.IdGestor;
        }

        public static int Update(Gestor g)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE Gestor SET ");
                sql.AppendLine("nomeGestor = @nomeGestor, ");
                sql.AppendLine("dtNascGestor = @dtNascGestor, ");
                sql.AppendLine("WHERE idGestor = @idGestor ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nomeGestor", g.NomeGestor);
                    cmd.Parameters.AddWithValue("@dtNascGestor", g.DtNascGestor);
                    cmd.Parameters.AddWithValue("@idGestor", g.IdGestor);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return linhasAfetadas;
        }
        public static int Delete(int idGestor)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                string sql = "DELETE FROM Projeto WHERE idGestor = @idGestor";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idGestor", idGestor);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public static List<Gestor> GetAll()
        {
            List<Gestor> listaEventos = new List<Gestor>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.idGestor, a.nomeGestor, a.dtNascGestor");
                sql.AppendLine("FROM Gestor a ");
                /*sql.AppendLine("WHERE a.FL_ATIVO = 1 ");*/
                sql.AppendLine("ORDER BY a.nomeGestor ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Gestor g = new Gestor();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                g.IdGestor = Convert.ToInt32(dr["idGestor"]);
                                g.NomeGestor = dr["nomeGestor"].ToString();
                                g.DtNascGestor = Convert.ToDateTime(dr["dtNascGestor"]);
                                
                                listaEventos.Add(g);//Adicionando o objeto para a lista
                            }
                        }
                    }
                }
            }
            return listaEventos;
        }

        public static Gestor GetById(int idGestor)
        {
            Gestor g = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.idGestor, a.nomeGestor, a.dtNascGestor");
                sql.AppendLine("FROM Gestor g ");
                sql.AppendLine("WHERE a.idGestor = @idGestor ");
                sql.AppendLine("ORDER BY a.nomeGestor ");


                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@idGestor", idGestor); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.Read())
                            {
                                g = new Gestor();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                g.IdGestor = Convert.ToInt32(dr["idGestor"]);
                                g.NomeGestor = dr["nomeGestor"].ToString();
                                g.DtNascGestor = Convert.ToDateTime(dr["dtNascGestor"]);
                            }
                        }
                    }
                }
            }
            return g;
        }
    }
}
