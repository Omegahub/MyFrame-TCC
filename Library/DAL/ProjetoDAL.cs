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
                sql.AppendLine("INSERT INTO TPROJETO ");
                sql.AppendLine("(PROIDPROJ, PRONMPROJ, PROLOCPROJ, PRODTPROJ, PRODESCPROJ) ");
                sql.AppendLine("VALUES (@PROIDPROJ, @PRONMPROJ, @PROLOCPROJ, @PRODTPROJ, @PRODESCPROJ) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@PRONMPROJ", p.NomeProjeto);
                    cmd.Parameters.AddWithValue("@PROLOCPROJ", p.LocalProjeto);
                    cmd.Parameters.AddWithValue("@PRODTPROJ", p.DtProjeto);
                    cmd.Parameters.AddWithValue("@PRODESCPROJ", p.DescProjeto);
                    
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
                sql.AppendLine("UPDATE TPROJETO SET ");
                sql.AppendLine("PRONMPROJ = @PRONMPROJ, ");
                sql.AppendLine("PROLOCPROJ = @PROLOCPROJ, ");
                sql.AppendLine("PRODTPROJ = @PRODTPROJ, ");
                sql.AppendLine("PRODESCPROJ = @PRODESCPROJ, ");
                sql.AppendLine("WHERE PROIDPROJ = @PROIDPROJ ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@PRONMPROJ", p.NomeProjeto);
                    cmd.Parameters.AddWithValue("@PROLOCPROJ", p.LocalProjeto);
                    cmd.Parameters.AddWithValue("@PRODTPROJ", p.DtProjeto);
                    cmd.Parameters.AddWithValue("@PRODESCPROJ", p.DescProjeto);
                    cmd.Parameters.AddWithValue("@PROIDPROJ", p.IdProjeto);

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
                string sql = "DELETE FROM TPROJETO WHERE PROIDPROJ = @PROIDPROJ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@PROIDPROJ", idProjeto);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public static List<Projeto> GetAll()
        {
            List<Projeto> listaProjetos = new List<Projeto>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.PROIDPROJ, a.PRONMPROJ, a.PROLOCPROJ, a.PRODTPROJ, a.PRODESCPROJ");
                sql.AppendLine("FROM TPROJETO a ");
                /*sql.AppendLine("WHERE a.FL_ATIVO = 1 ");*/
                sql.AppendLine("ORDER BY a.PRONMPROJ ");

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
                                p.IdProjeto = Convert.ToInt32(dr["PROIDPROJ"]);
                                p.NomeProjeto = dr["PRONMPROJ"].ToString();
                                p.LocalProjeto = dr["PROLOCPROJ"].ToString();
                                p.DtProjeto = Convert.ToDateTime(dr["PRODTPROJ"]);
                                p.DescProjeto = dr["PRODESCPROJ"].ToString();

                                listaProjetos.Add(p);//Adicionando o objeto para a lista
                            }
                        }
                    }
                }
            }
            return listaProjetos;
        }

        public static Projeto GetById(int idProjeto)
        {
            Projeto p = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.PROIDPROJ, a.PRONMPROJ, a.PROLOCPROJ, a.PRODTPROJ, a.PRODESCPROJ");
                sql.AppendLine("FROM TPROJETO a ");
                sql.AppendLine("WHERE a.PROIDPROJ = @PROIDPROJ ");
                sql.AppendLine("ORDER BY a.PRONMPROJ ");


                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@PROIDPROJ", idProjeto); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.Read())
                            {
                                p = new Projeto();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                p.IdProjeto = Convert.ToInt32(dr["PROIDPROJ"]);
                                p.NomeProjeto = dr["PRONMPROJ"].ToString();
                                p.LocalProjeto = dr["PROLOCPROJ"].ToString();
                                p.DtProjeto = Convert.ToDateTime(dr["PRODTPROJ"]);
                                p.DescProjeto = dr["PRODESCPROJ"].ToString();
                            }
                        }
                    }
                }
            }
            return p;
        }
    }
}
