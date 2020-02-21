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
    public class ProjetoDAL
    {
        public static int Insert(Projeto p)
        {

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Projeto ");
                sql.AppendLine("(idProjeto, nomeProjeto, localProjeto, dtProjeto, descProjeto) ");
                sql.AppendLine("VALUES (@idProjeto, @nomeProjeto, @localProjeto, @dtProjeto, @descProjeto) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nomeProjeto", p.NomeProjeto);
                    cmd.Parameters.AddWithValue("@localProjeto", p.LocalProjeto);
                    cmd.Parameters.AddWithValue("@dtProjeto", p.DtProjeto);
                    cmd.Parameters.AddWithValue("@descProjeto", p.DescProjeto);
                    
                    con.Open();
                    p.IdProjeto = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            return p.IdProjeto;
        }

        public static int Update(Projeto p)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE Projeto SET ");
                sql.AppendLine("nomeProjeto = @nomeProjeto, ");
                sql.AppendLine("localProjeto = @localProjeto, ");
                sql.AppendLine("dtProjeto = @dtProjeto, ");
                sql.AppendLine("descProjeto = @descProjeto, ");
                sql.AppendLine("WHERE idProjeto = @idProjeto ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nomeProjeto", p.NomeProjeto);
                    cmd.Parameters.AddWithValue("@localProjeto", p.LocalProjeto);
                    cmd.Parameters.AddWithValue("@dtProjeto", p.DtProjeto);
                    cmd.Parameters.AddWithValue("@descProjeto", p.DescProjeto);
                    cmd.Parameters.AddWithValue("@idProjeto", p.IdProjeto);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return linhasAfetadas;
        }

        public static int Delete(int idProjeto)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                string sql = "DELETE FROM Projeto WHERE idProjeto = @idProjeto";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idProjeto", idProjeto);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public static List<Projeto> GetAll()
        {
            List<Projeto> listaEventos = new List<Projeto>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.idProjeto, a.nomeProjeto, a.localProjeto, a.dtProjeto, a.descProjeto");
                sql.AppendLine("FROM Projeto a ");
                /*sql.AppendLine("WHERE a.FL_ATIVO = 1 ");*/
                sql.AppendLine("ORDER BY a.nomeProjeto ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Projeto p = new Projeto();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                p.IdProjeto = Convert.ToInt32(dr["idProjeto"]);
                                p.NomeProjeto = dr["nomeProjeto"].ToString();
                                p.LocalProjeto = dr["localProjeto"].ToString();
                                p.DtProjeto = Convert.ToDateTime(dr["dtProjeto"]);
                                p.DescProjeto = dr["descProjeto"].ToString();

                                listaEventos.Add(p);//Adicionando o objeto para a lista
                            }
                        }
                    }
                }
            }
            return listaEventos;
        }

        public static Projeto GetById(int idProjeto)
        {
            Projeto p = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.idProjeto, a.nomeProjeto, a.localProjeto, a.dtProjeto, a.descProjeto");
                sql.AppendLine("FROM Projeto a ");
                sql.AppendLine("WHERE a.idProjeto = @idProjeto ");
                sql.AppendLine("ORDER BY a.nomeProjeto ");


                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@idEvento", idProjeto); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.Read())
                            {
                                p = new Projeto();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                p.IdProjeto = Convert.ToInt32(dr["idProjeto"]);
                                p.NomeProjeto = dr["nomeProjeto"].ToString();
                                p.LocalProjeto = dr["localProjeto"].ToString();
                                p.DtProjeto = Convert.ToDateTime(dr["dtProjeto"]);
                                p.DescProjeto = dr["descProjeto"].ToString();
                            }
                        }
                    }
                }
            }
            return p;
        }
    }
}
