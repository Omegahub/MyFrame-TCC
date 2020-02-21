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
    public class TurmaItensDAL
    {
        public static int Insert(TurmaItens ti)
        {

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO ItensTurma ");
                sql.AppendLine("(idItemTurma, descItem) ");
                sql.AppendLine("VALUES (@idItemTurma, @descItem) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@descItem", ti.ItensNecessarios);
                    
                    con.Open();
                    ti.IdTurmaItem = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            return ti.IdTurmaItem;
        }

        public static int Update(TurmaItens ti)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE ItensTurma SET ");
                sql.AppendLine("descItem = @descItem, ");
                sql.AppendLine("WHERE idItemTurma = @idItemTurma ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@descItem", ti.ItensNecessarios);
                    cmd.Parameters.AddWithValue("@idItemTurma", ti.IdTurmaItem);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return linhasAfetadas;
        }

        public static int Delete(int idTurmaItens)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                string sql = "DELETE FROM ItensTurma WHERE idItemTurma = @idItemTurma";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idItemTurma", idTurmaItens);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public static List<TurmaItens> GetAll()
        {
            List<TurmaItens> listaEventos = new List<TurmaItens>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.idItemTurma, a.descItem");
                sql.AppendLine("FROM ItensTurma a ");
                /*sql.AppendLine("WHERE a.FL_ATIVO = 1 ");*/
                sql.AppendLine("ORDER BY a.descItem ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                TurmaItens ti = new TurmaItens();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                ti.IdTurmaItem = Convert.ToInt32(dr["idItemTurma"]);
                                ti.ItensNecessarios = dr["descItem"].ToString();
                                
                                listaEventos.Add(ti);//Adicionando o objeto para a lista
                            }
                        }
                    }
                }
            }
            return listaEventos;
        }

        public static TurmaItens GetById(int idTurmaItens)
        {
            TurmaItens ti = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.idItemTurma, a.descItem");
                sql.AppendLine("FROM ItensTurma a ");
                sql.AppendLine("WHERE a.idItemTurma = @idItemTurma ");
                sql.AppendLine("ORDER BY a.descItem ");


                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@idItemTurma", idTurmaItens); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.Read())
                            {
                                ti = new TurmaItens();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                ti.IdTurmaItem = Convert.ToInt32(dr["idItemTurma"]);
                                ti.ItensNecessarios = dr["descItem"].ToString();
                            }
                        }
                    }
                }
            }
            return ti;
        }
    }
}
