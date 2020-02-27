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
    public class TurmaDAL
    {
        public static int Insert(Turma t)
        {

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO TTURMA ");
                sql.AppendLine("(TUNMTURMA) ");
                sql.AppendLine("VALUES (@TUNMTURMA) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@TUNMTURMA", t.NomeCurso);

                    con.Open();
                    t.IdTurma = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            return t.IdTurma;
        }

        public static int Update(Turma t)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE TTURMA SET ");
                sql.AppendLine("TUNMTURMA = @TUNMTURMA, ");
                sql.AppendLine("WHERE TUIDTURMA = @TUIDTURMA ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@TUNMTURMA", t.NomeCurso);
                    cmd.Parameters.AddWithValue("@TUIDTURMA", t.IdTurma);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return linhasAfetadas;
        }

        public static int Delete(int idTurma)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                string sql = "DELETE FROM TTURMA WHERE TUIDTURMA = @TUIDTURMA";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@TUIDTURMA", idTurma);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public static List<Turma> GetAll()
        {
            List<Turma> listaTurma = new List<Turma>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.TUIDTURMA, a.TUNMTURMA");
                sql.AppendLine("FROM TTURMA a ");
                /*sql.AppendLine("WHERE a.FL_ATIVO = 1 ");*/
                sql.AppendLine("ORDER BY a.TUNMTURMA ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Turma t = new Turma();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                t.IdTurma = Convert.ToInt32(dr["TUIDTURMA"]);
                                t.NomeCurso = dr["TUNMTURMA"].ToString();

                                listaTurma.Add(t);//Adicionando o objeto para a lista
                            }
                        }
                    }
                }
            }
            return listaTurma;
        }

        public static Turma GetById(int idTurma)
        {
            Turma t = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.TUIDTURMA, a.TUNMTURMA");
                sql.AppendLine("FROM TTURMA a ");
                sql.AppendLine("WHERE a.TUIDTURMA = @TUIDTURMA ");
                sql.AppendLine("ORDER BY a.TUNMTURMA ");


                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@TUIDTURMA", idTurma); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.Read())
                            {
                                t = new Turma();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                t.IdTurma = Convert.ToInt32(dr["TUIDTURMA"]);
                                t.NomeCurso = dr["TUNMTURMA"].ToString();
                            }
                        }
                    }
                }
            }
            return t;
        }
    }
}
