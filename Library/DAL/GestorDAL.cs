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
                sql.AppendLine("INSERT INTO TGESTOR ");
                sql.AppendLine("(GEIDGESTOR, GENMGESTOR, GEDTNASCGESTOR) ");
                sql.AppendLine("VALUES (@GEIDGESTOR, @GENMGESTOR, @GEDTNASCGESTOR) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@GENMGESTOR", g.NomeGestor);
                    cmd.Parameters.AddWithValue("@GEDTNASCGESTOR", g.DtNascGestor);

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
                sql.AppendLine("UPDATE TGESTOR SET ");
                sql.AppendLine("GENMGESTOR = @GENMGESTOR, ");
                sql.AppendLine("GEDTNASCGESTOR = @GEDTNASCGESTOR, ");
                sql.AppendLine("WHERE GEIDGESTOR = @GEIDGESTOR ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@GENMGESTOR", g.NomeGestor);
                    cmd.Parameters.AddWithValue("@GEDTNASCGESTOR", g.DtNascGestor);
                    cmd.Parameters.AddWithValue("@GEIDGESTOR", g.IdGestor);

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
                string sql = "DELETE FROM TGESTOR WHERE GEIDGESTOR = @GEIDGESTOR";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@GEIDGESTOR", idGestor);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public static List<Gestor> GetAll()
        {
            List<Gestor> listaGestor = new List<Gestor>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.GEIDGESTOR, a.GENMGESTOR, a.GEDTNASCGESTOR");
                sql.AppendLine("FROM TGESTOR a ");
                /*sql.AppendLine("WHERE a.FL_ATIVO = 1 ");*/
                sql.AppendLine("ORDER BY a.GENMGESTOR ");

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
                                g.IdGestor = Convert.ToInt32(dr["GEIDGESTOR"]);
                                g.NomeGestor = dr["GENMGESTOR"].ToString();
                                g.DtNascGestor = Convert.ToDateTime(dr["GEDTNASCGESTOR"]);
                                
                                listaGestor.Add(g);//Adicionando o objeto para a lista
                            }
                        }
                    }
                }
            }
            return listaGestor;
        }

        public static Gestor GetById(int idGestor)
        {
            Gestor g = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.GEIDGESTOR, a.GENMGESTOR, a.GEDTNASCGESTOR");
                sql.AppendLine("FROM TGESTOR g ");
                sql.AppendLine("WHERE a.GEIDGESTOR = @GEIDGESTOR ");
                sql.AppendLine("ORDER BY a.GENMGESTOR ");


                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@GEIDGESTOR", idGestor); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.Read())
                            {
                                g = new Gestor();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                g.IdGestor = Convert.ToInt32(dr["GEIDGESTOR"]);
                                g.NomeGestor = dr["GENMGESTOR"].ToString();
                                g.DtNascGestor = Convert.ToDateTime(dr["GEDTNASCGESTOR"]);
                            }
                        }
                    }
                }
            }
            return g;
        }
    }
}
