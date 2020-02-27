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
    public class EventoDAL
    {
        public static int Insert(Evento e)
        {

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO TEVENTO ");
                sql.AppendLine("(EVIDEVENTO, EVNMEVENTO, EVENDEVENTO, EVDTEVENTO, EVDESCEVENTO, EVCAPAMAXEVENTO) ");
                sql.AppendLine("VALUES (@EVIDEVENTO, @EVNMEVENTO, @EVENDEVENTO, @EVDTEVENTO, @EVDESCEVENTO, @EVCAPAMAXEVENTO) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@EVNMEVENTO", e.NomeEvento);
                    cmd.Parameters.AddWithValue("@EVENDEVENTO", e.EnderecoEvento);
                    cmd.Parameters.AddWithValue("@EVDTEVENTO", e.DtEvento);
                    cmd.Parameters.AddWithValue("@EVDESCEVENTO", e.DescEvento);
                    cmd.Parameters.AddWithValue("@EVCAPAMAXEVENTO", e.CapaciMaxEvento);

                    con.Open();
                    e.IdEvento = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            return e.IdEvento;
        }

        public static int Update(Evento e)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE TEVENTO SET ");
                sql.AppendLine("EVNMEVENTO = @EVNMEVENTO, ");
                sql.AppendLine("EVENDEVENTO = @EVENDEVENTO, ");
                sql.AppendLine("EVDTEVENTO = @EVDTEVENTO, ");
                sql.AppendLine("EVDESCEVENTO = @EVDESCEVENTO, ");
                sql.AppendLine("EVCAPAMAXEVENTO = @EVCAPAMAXEVENTO ");
                sql.AppendLine("WHERE EVIDEVENTO = @EVIDEVENTO ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@EVNMEVENTO", e.NomeEvento);
                    cmd.Parameters.AddWithValue("@EVENDEVENTO", e.EnderecoEvento);
                    cmd.Parameters.AddWithValue("@EVDTEVENTO", e.DtEvento);
                    cmd.Parameters.AddWithValue("@EVDESCEVENTO", e.DescEvento);
                    cmd.Parameters.AddWithValue("@EVCAPAMAXEVENTO", e.CapaciMaxEvento);
                    cmd.Parameters.AddWithValue("@EVIDEVENTO", e.IdEvento);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return linhasAfetadas;
        }

        public static int Delete(int idEvento)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                string sql = "DELETE FROM TEVENTO WHERE EVIDEVENTO = @EVIDEVENTO";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@EVIDEVENTO", idEvento);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public static List<Evento> GetAll()
        {
            List<Evento> listaEventos = new List<Evento>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.EVIDEVENTO, a.EVNMEVENTO, a.EVENDEVENTO, a.EVDTEVENTO, a.EVDESCEVENTO, a.EVCAPAMAXEVENTO");
                sql.AppendLine("FROM TEVENTO a ");
                /*sql.AppendLine("WHERE a.FL_ATIVO = 1 ");*/
                sql.AppendLine("ORDER BY a.EVNMEVENTO ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Evento e = new Evento();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                e.IdEvento = Convert.ToInt32(dr["EVIDEVENTO"]);
                                e.NomeEvento = dr["EVNMEVENTO"].ToString();
                                e.EnderecoEvento = dr["EVENDEVENTO"].ToString();
                                e.DtEvento = Convert.ToDateTime(dr["EVDTEVENTO"]);
                                e.DescEvento = dr["EVDESCEVENTO"].ToString();
                                e.CapaciMaxEvento = Convert.ToInt32(dr["EVCAPAMAXEVENTO"]);

                                listaEventos.Add(e);//Adicionando o objeto para a lista
                            }
                        }
                    }
                }
            }
            return listaEventos;
        }

        public static Evento GetById(int idEvento)
        {
            Evento e = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.EVIDEVENTO, a.EVNMEVENTO, a.EVENDEVENTO, a.EVDTEVENTO, a.EVDESCEVENTO, a.EVCAPAMAXEVENTO");
                sql.AppendLine("FROM TEVENTO a ");
                sql.AppendLine("WHERE a.EVIDEVENTO = @EVIDEVENTO ");
                sql.AppendLine("ORDER BY a.EVNMEVENTO ");


                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@EVIDEVENTO", idEvento); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.Read())
                            {
                                e = new Evento();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                e.IdEvento = Convert.ToInt32(dr["EVIDEVENTO"]);
                                e.NomeEvento = dr["EVNMEVENTO"].ToString();
                                e.EnderecoEvento = dr["EVENDEVENTO"].ToString();
                                e.DtEvento = Convert.ToDateTime(dr["EVDTEVENTO"]);
                                e.DescEvento = dr["EVDESCEVENTO"].ToString();
                                e.CapaciMaxEvento = Convert.ToInt32(dr["EVCAPAMAXEVENTO"]);

                            }
                        }
                    }
                }
            }
            return e;
        }
    }
}
