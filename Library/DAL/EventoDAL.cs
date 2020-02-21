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
                sql.AppendLine("INSERT INTO Evento ");
                sql.AppendLine("(idEvento, nomeEvento, endEvento, dtEvento, descEvento, capaciMaxEvento) ");
                sql.AppendLine("VALUES (@idEvento, @nomeEvento, @endEvento, @dtEvento, @descEvento, @capaciMaxEvento) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nomeEvento", e.NomeEvento);
                    cmd.Parameters.AddWithValue("@endEvento", e.EnderecoEvento);
                    cmd.Parameters.AddWithValue("@dtEvento", e.DtEvento);
                    cmd.Parameters.AddWithValue("@descEvento", e.DescEvento);
                    cmd.Parameters.AddWithValue("@capaciMaxEvento", e.CapaciMaxEvento);

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
                sql.AppendLine("UPDATE Evento SET ");
                sql.AppendLine("nomeEvento = @nomeEvento, ");
                sql.AppendLine("endEvento = @endEvento, ");
                sql.AppendLine("dtEvento = @dtEvento, ");
                sql.AppendLine("descEvento = @descEvento, ");
                sql.AppendLine("capaciMaxEvento = @capaciMaxEvento ");
                sql.AppendLine("WHERE idEvento = @idEvento ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nomeEvento", e.NomeEvento);
                    cmd.Parameters.AddWithValue("@endEvento", e.EnderecoEvento);
                    cmd.Parameters.AddWithValue("@dtEvento", e.DtEvento);
                    cmd.Parameters.AddWithValue("@descEvento", e.DescEvento);
                    cmd.Parameters.AddWithValue("@capaciMaxEvento", e.CapaciMaxEvento);
                    cmd.Parameters.AddWithValue("@idEvento", e.IdEvento);

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
                string sql = "DELETE FROM Evento WHERE idEvento = @idEvento";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idEvento", idEvento);

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
                sql.AppendLine("SELECT a.idEvento, a.nomeEvento, a.endEvento, a.dtEvento, a.descEvento, a.capaciMaxEvento");
                sql.AppendLine("FROM Evento a ");
                /*sql.AppendLine("WHERE a.FL_ATIVO = 1 ");*/
                sql.AppendLine("ORDER BY a.nomeEvento ");

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
                                e.IdEvento = Convert.ToInt32(dr["idEvento"]);
                                e.NomeEvento = dr["nomeEvento"].ToString();
                                e.EnderecoEvento = dr["endEvento"].ToString();
                                e.DtEvento = Convert.ToDateTime(dr["dtEvento"]);
                                e.DescEvento = dr["descEvento"].ToString();
                                e.CapaciMaxEvento = Convert.ToInt32(dr["capaciMaxEvento"]);

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
                sql.AppendLine("SELECT a.idEvento, a.nomeEvento, a.endEvento, a.dtEvento, a.descEvento, a.capaciMaxEvento");
                sql.AppendLine("FROM Evento a ");
                sql.AppendLine("WHERE a.idEvento = @idEvento ");
                sql.AppendLine("ORDER BY a.nomeEvento ");


                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@idEvento", idEvento); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.Read())
                            {
                                e = new Evento();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                e.IdEvento = Convert.ToInt32(dr["idEvento"]);
                                e.NomeEvento = dr["nomeEvento"].ToString();
                                e.EnderecoEvento = dr["endEvento"].ToString();
                                e.DtEvento = Convert.ToDateTime(dr["dtEvento"]);
                                e.DescEvento = dr["descEvento"].ToString();
                                e.CapaciMaxEvento = Convert.ToInt32(dr["capaciMaxEvento"]);

                            }
                        }
                    }
                }
            }
            return e;
        }
    }
}
