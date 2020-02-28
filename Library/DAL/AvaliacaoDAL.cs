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
    public class AvaliacaoDAL
    {
        public static int Insert(Avaliacao a)
        {

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO TAVALIACAO ");
                sql.AppendLine("(AVNOTAAVA, AVDATAAVA, AVFEEDBACKAVA) ");
                sql.AppendLine("VALUES (@AVNOTAAVA, @AVDATAAVA, @AVFEEDBACKAVA) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@AVNOTAAVA", a.NotaAvaliacao);
                    cmd.Parameters.AddWithValue("@AVDATAAVA", a.DtAvaliacao);
                    cmd.Parameters.AddWithValue("@AVFEEDBACKAVA", a.Feedback);

                    con.Open();
                    a.IdAvaliacao = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            return a.IdAvaliacao;
        }

        public static int Update(Avaliacao a)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE TAVALIACAO SET ");
                sql.AppendLine("AVNOTAAVA = @AVNOTAAVA, ");
                sql.AppendLine("AVDATAAVA = @AVDATAAVA, ");
                sql.AppendLine("AVFEEDBACKAVA = @AVFEEDBACKAVA, ");
                sql.AppendLine("WHERE AVIDVISI = @AVIDVISI ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@AVNOTAAVA", a.NotaAvaliacao);
                    cmd.Parameters.AddWithValue("@AVDATAAVA", a.DtAvaliacao);
                    cmd.Parameters.AddWithValue("@AVFEEDBACKAVA", a.Feedback);
                    cmd.Parameters.AddWithValue("@AVIDVISI", a.IdAvaliacao);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return linhasAfetadas;
        }
        public static int Delete(int idAvaliacao)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                string sql = "DELETE FROM TAVALIACAO WHERE AVIDVISI = @AVIDVISI";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@AVIDVISI", idAvaliacao);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public static List<Avaliacao> GetAll()
        {
            List<Avaliacao> listaAvaliacao= new List<Avaliacao>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.AVIDVISI, a.AVNOTAAVA, a.AVDATAAVA, a.AVFEEDBACKAVA");
                sql.AppendLine("FROM TAVALIACAO a ");
                /*sql.AppendLine("WHERE a.FL_ATIVO = 1 ");*/
                sql.AppendLine("ORDER BY a.AVIDVISI ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Avaliacao a = new Avaliacao();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                a.IdAvaliacao = Convert.ToInt32(dr["AVIDVISI"]);
                                a.NotaAvaliacao = Convert.ToInt32(dr["AVNOTAAVA"]);
                                a.DtAvaliacao = Convert.ToDateTime(dr["AVDATAAVA"]);
                                a.Feedback = dr["AVFEEDBACKAVA"].ToString();

                                listaAvaliacao.Add(a);//Adicionando o objeto para a lista
                            }
                        }
                    }
                }
            }
            return listaAvaliacao;
        }

        public static Avaliacao GetById(int idAvaliacao)
        {
            Avaliacao a = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.AVIDVISI, a.AVNOTAAVA, a.AVDATAAVA, a.AVFEEDBACKAVA");
                sql.AppendLine("FROM TAVALIACAO a ");
                sql.AppendLine("WHERE a.AVIDVISI = @AVIDVISI ");
                sql.AppendLine("ORDER BY a.AVIDVISI ");


                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@AVIDVISI", idAvaliacao); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.Read())
                            {
                                a = new Avaliacao();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                a.IdAvaliacao = Convert.ToInt32(dr["AVIDVISI"]);
                                a.NotaAvaliacao = Convert.ToInt32(dr["AVNOTAAVA"]);
                                a.DtAvaliacao = Convert.ToDateTime(dr["AVDATAAVA"]);
                                a.Feedback = dr["AVFEEDBACKAVA"].ToString();

                            }
                        }
                    }
                }
            }
            return a;
        }
    }
}
