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
    public class AvaliacaoCriterioDAL
    {
        public static int Insert(AvaliacaoCriterio ac)
        {

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO AvaliacaoCriterio ");
                sql.AppendLine("(dsCriterioAv) ");
                sql.AppendLine("VALUES (@dsCriterioAv) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@dsCriterioAv", ac.CriterioAvaliacao);

                    con.Open();
                    ac.IdCriterioAvaliacao = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            return ac.IdCriterioAvaliacao;
        }

        public static int Update(AvaliacaoCriterio ac)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE AvaliacaoCriterio SET ");
                sql.AppendLine("dsCriterioAv = @dsCriterioAv, ");
                sql.AppendLine("WHERE idCriterioAv = @idCriterioAv ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@dsCriterioAv", ac.CriterioAvaliacao);
                    cmd.Parameters.AddWithValue("@idCriterioAv", ac.IdCriterioAvaliacao);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return linhasAfetadas;
        }
        public static int Delete(int idAvaliacaoCriterio)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                string sql = "DELETE FROM Projeto WHERE idCriterioAv = @idCriterioAv";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idCriterioAv", idAvaliacaoCriterio);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public static List<AvaliacaoCriterio> GetAll()
        {
            List<AvaliacaoCriterio> listaAvCriterios = new List<AvaliacaoCriterio>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.idCriterioAv, a.dsCriterioAv");
                sql.AppendLine("FROM AvaliacaoCriterio a ");
                /*sql.AppendLine("WHERE a.FL_ATIVO = 1 ");*/
                sql.AppendLine("ORDER BY a.dsCriterioAv ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                AvaliacaoCriterio ac = new AvaliacaoCriterio();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                ac.IdCriterioAvaliacao = Convert.ToInt32(dr["idCriterioAv"]);
                                ac.CriterioAvaliacao = dr["dsCriterioAv"].ToString();

                                listaAvCriterios.Add(ac);//Adicionando o objeto para a lista
                            }
                        }
                    }
                }
            }
            return listaAvCriterios;
        }

        public static AvaliacaoCriterio GetById(int idCriterioAvaliacao)
        {
            AvaliacaoCriterio ac = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.idCriterioAv, a.dsCriterioAv");
                sql.AppendLine("FROM AvaliacaoCriterio a ");
                sql.AppendLine("WHERE a.idCriterioAv = @idCriterioAv ");
                sql.AppendLine("ORDER BY a.dsCriterioAv ");


                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@idCriterioAv", idCriterioAvaliacao); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.Read())
                            {
                                ac = new AvaliacaoCriterio();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                ac.IdCriterioAvaliacao = Convert.ToInt32(dr["idCriterioAv"]);
                                ac.CriterioAvaliacao = dr["dsCriterioAv"].ToString();

                            }
                        }
                    }
                }
            }
            return ac;
        }
    }
}
