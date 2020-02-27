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
                sql.AppendLine("INSERT INTO TITENSTURMA ");
                sql.AppendLine("(ITTUIDITTU, ITTUDESCITTU) ");
                sql.AppendLine("VALUES (@ITTUIDITTU, @ITTUDESCITTU) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ITTUDESCITTU", ti.ItensNecessarios);
                    
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
                sql.AppendLine("UPDATE TITENSTURMA SET ");
                sql.AppendLine("ITTUDESCITTU = @ITTUDESCITTU, ");
                sql.AppendLine("WHERE ITTUIDITTU = @ITTUIDITTU ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ITTUDESCITTU", ti.ItensNecessarios);
                    cmd.Parameters.AddWithValue("@ITTUIDITTU", ti.IdTurmaItem);

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
                string sql = "DELETE FROM TITENSTURMA WHERE ITTUIDITTU = @ITTUIDITTU";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ITTUIDITTU", idTurmaItens);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public static List<TurmaItens> GetAll()
        {
            List<TurmaItens> listaTurmaItens = new List<TurmaItens>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.ITTUIDITTU, a.ITTUDESCITTU");
                sql.AppendLine("FROM TITENSTURMA a ");
                /*sql.AppendLine("WHERE a.FL_ATIVO = 1 ");*/
                sql.AppendLine("ORDER BY a.ITTUDESCITTU ");

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
                                ti.IdTurmaItem = Convert.ToInt32(dr["ITTUIDITTU"]);
                                ti.ItensNecessarios = dr["ITTUDESCITTU"].ToString();
                                
                                listaTurmaItens.Add(ti);//Adicionando o objeto para a lista
                            }
                        }
                    }
                }
            }
            return listaTurmaItens;
        }

        public static TurmaItens GetById(int idTurmaItens)
        {
            TurmaItens ti = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.ITTUIDITTU, a.ITTUDESCITTU");
                sql.AppendLine("FROM TITENSTURMA a ");
                sql.AppendLine("WHERE a.ITTUIDITTU = @ITTUIDITTU ");
                sql.AppendLine("ORDER BY a.ITTUDESCITTU ");


                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@ITTUIDITTU", idTurmaItens); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.Read())
                            {
                                ti = new TurmaItens();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                ti.IdTurmaItem = Convert.ToInt32(dr["ITTUIDITTU"]);
                                ti.ItensNecessarios = dr["ITTUDESCITTU"].ToString();
                            }
                        }
                    }
                }
            }
            return ti;
        }
    }
}
