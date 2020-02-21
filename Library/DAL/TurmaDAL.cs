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
                sql.AppendLine("INSERT INTO Turma ");
                sql.AppendLine("(nomeCurso) ");
                sql.AppendLine("VALUES (@nomeCurso) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nomeCurso", t.NomeCurso);

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
                sql.AppendLine("UPDATE Turma SET ");
                sql.AppendLine("nomeCurso = @nomeCurso, ");
                sql.AppendLine("WHERE idTurma = @idTurma ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nomeCurso", t.NomeCurso);
                    cmd.Parameters.AddWithValue("@idTurma", t.IdTurma);

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
                string sql = "DELETE FROM Evento WHERE idTurma = @idTurma";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idTurma", idTurma);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public static List<Turma> GetAll()
        {
            List<Turma> listaEventos = new List<Turma>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.idTurma, a.nomeCurso");
                sql.AppendLine("FROM Turma a ");
                /*sql.AppendLine("WHERE a.FL_ATIVO = 1 ");*/
                sql.AppendLine("ORDER BY a.nomeCurso ");

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
                                t.IdTurma = Convert.ToInt32(dr["idTurma"]);
                                t.NomeCurso = dr["nomeCurso"].ToString();

                                listaEventos.Add(t);//Adicionando o objeto para a lista
                            }
                        }
                    }
                }
            }
            return listaEventos;
        }

        public static Turma GetById(int idTurma)
        {
            Turma t = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.idTurma, a.nomeCurso");
                sql.AppendLine("FROM Turma a ");
                sql.AppendLine("WHERE a.idTurma = @idTurma ");
                sql.AppendLine("ORDER BY a.nomeCurso ");


                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@idTurma", idTurma); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.Read())
                            {
                                t = new Turma();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                t.IdTurma = Convert.ToInt32(dr["idTurma"]);
                                t.NomeCurso = dr["nomeCurso"].ToString();
                            }
                        }
                    }
                }
            }
            return t;
        }
    }
}
