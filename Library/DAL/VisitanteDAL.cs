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
    public class VisitanteDAL
    {
        public static int Insert(Visitante v)
        {

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO TVISITANTE ");
                sql.AppendLine("(VIIDVISI, VINMVISI, VICPFVISI, VICIDAVISI, VIEMAILVISI, VINASCVISI) ");
                sql.AppendLine("VALUES (@VIIDVISI, @VINMVISI, @VICPFVISI, @VICIDAVISI, @VIEMAILVISI, @VINASCVISI) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@VINMVISI", v.NomeVisitante);
                    cmd.Parameters.AddWithValue("@VICPFVISI", v.CpfVisitante);
                    cmd.Parameters.AddWithValue("@VICIDAVISI", v.EndVisitante);
                    cmd.Parameters.AddWithValue("@VIEMAILVISI", v.EmailVisitante);
                    cmd.Parameters.AddWithValue("@VINASCVISI", v.DtNascVisitante);

                    con.Open();
                    v.IdVisitante = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            return v.IdVisitante;
        }

        public static int Update(Visitante v)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE TVISITANTE SET ");
                sql.AppendLine("VINMVISI = @VINMVISI, ");
                sql.AppendLine("VICPFVISI = @VICPFVISI, ");
                sql.AppendLine("VICIDAVISI = @VICIDAVISI, ");
                sql.AppendLine("VIEMAILVISI = @VIEMAILVISI, ");
                sql.AppendLine("VINASCVISI = @VINASCVISI ");
                sql.AppendLine("WHERE VIIDVISI = @VIIDVISI ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@VINMVISI", v.NomeVisitante);
                    cmd.Parameters.AddWithValue("@VICPFVISI", v.CpfVisitante);
                    cmd.Parameters.AddWithValue("@VICIDAVISI", v.EndVisitante);
                    cmd.Parameters.AddWithValue("@VIEMAILVISI", v.EmailVisitante);
                    cmd.Parameters.AddWithValue("@VINASCVISI", v.DtNascVisitante);
                    cmd.Parameters.AddWithValue("@VIIDVISI", v.IdVisitante);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return linhasAfetadas;
        }

        public static int Delete(int idVisitante)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                string sql = "DELETE FROM TVISITANTE WHERE idVisitante = @idVisitante";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idVisitante", idVisitante);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public static List<Visitante> GetAll()
        {
            List<Visitante> listaVisitantes = new List<Visitante>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.VIIDVISI, a.VINMVISI, a.VICPFVISI, a.VICIDAVISI, a.VIEMAILVISI, a.VINASCVISI");
                sql.AppendLine("FROM TVISITANTE a ");
                /*sql.AppendLine("WHERE a.FL_ATIVO = 1 ");*/
                sql.AppendLine("ORDER BY a.VINMVISI ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Visitante v = new Visitante();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                v.IdVisitante = Convert.ToInt32(dr["VIIDVISI"]);
                                v.NomeVisitante = dr["VINMVISI"].ToString();
                                v.CpfVisitante = dr["VICPFVISI"].ToString();
                                v.EndVisitante = dr["VICIDAVISI"].ToString();
                                v.EmailVisitante = dr["VIEMAILVISI"].ToString();
                                v.DtNascVisitante = Convert.ToDateTime(dr["VINASCVISI"]);

                                listaVisitantes.Add(v);//Adicionando o objeto para a lista
                            }
                        }
                    }
                }
            }
            return listaVisitantes;
        }

        public static Visitante GetById(int idVisitante)
        {
            Visitante v = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.VIIDVISI, a.VINMVISI, a.VICPFVISI, a.VICIDAVISI, a.VIEMAILVISI, a.VINASCVISI");
                sql.AppendLine("FROM TVISITANTE a ");
                sql.AppendLine("WHERE a.VIIDVISI = @VIIDVISI ");
                sql.AppendLine("ORDER BY a.VINMVISI ");


                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@VIIDVISI", idVisitante); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.Read())
                            {
                                v = new Visitante();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                v.IdVisitante = Convert.ToInt32(dr["VIIDVISI"]);
                                v.NomeVisitante = dr["VINMVISI"].ToString();
                                v.CpfVisitante = dr["VICPFVISI"].ToString();
                                v.EndVisitante = dr["VICIDAVISI"].ToString();
                                v.EmailVisitante = dr["VIEMAILVISI"].ToString();
                                v.DtNascVisitante = Convert.ToDateTime(dr["VINASCVISI"]);

                            }
                        }
                    }
                }
            }
            return v;
        }
    }
}
