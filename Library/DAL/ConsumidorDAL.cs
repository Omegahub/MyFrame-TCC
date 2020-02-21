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
    public class ConsumidorDAL
    {
        public static int Insert(Consumidor c)
        {

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO TB_CONSUMIDOR ");
                sql.AppendLine("(TX_NOME, TX_CPF, TX_ENDERECO, TX_TELEFONE, TX_EMAIL) ");
                sql.AppendLine("VALUES (@TX_NOME, @TX_CPF, @TX_ENDERECO, @TX_TELEFONE, @TX_EMAIL) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@TX_NOME", c.Nome);
                    cmd.Parameters.AddWithValue("@TX_CPF", c.Cpf);
                    cmd.Parameters.AddWithValue("@TX_ENDERECO", c.Endereco);
                    cmd.Parameters.AddWithValue("@TX_TELEFONE", c.Telefone);
                    cmd.Parameters.AddWithValue("@TX_EMAIL", c.Email);

                    con.Open();
                    c.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            return c.Id;
        }

        public static int Update(Consumidor c)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE TB_CONSUMIDOR SET ");
                sql.AppendLine("TX_NOME = @TX_NOME, ");
                sql.AppendLine("TX_CPF = @TX_CPF, ");
                sql.AppendLine("TX_ENDERECO = @TX_ENDERECO, ");
                sql.AppendLine("TX_TELEFONE = @TX_TELEFONE, ");
                sql.AppendLine("TX_EMAIL = @TX_EMAIL ");
                sql.AppendLine("WHERE ID = @ID ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@TX_NOME", c.Nome);
                    cmd.Parameters.AddWithValue("@TX_CPF", c.Cpf);
                    cmd.Parameters.AddWithValue("@TX_ENDERECO", c.Endereco);
                    cmd.Parameters.AddWithValue("@TX_TELEFONE", c.Telefone);
                    cmd.Parameters.AddWithValue("@TX_EMAIL", c.Email);
                    cmd.Parameters.AddWithValue("@ID", c.Id);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return linhasAfetadas;
        }

        public static int Delete(int id)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                string sql = "DELETE FROM TB_CONSUMIDOR WHERE ID = @ID";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public static List<Consumidor> GetAll()
        {
            List<Consumidor> listaProjetos = new List<Consumidor>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.ID, a.TX_NOME, a.TX_CPF, a.TX_ENDERECO, a.TX_TELEFONE, a.TX_EMAIL");
                sql.AppendLine("FROM TB_CONSUMIDOR a ");
                /*sql.AppendLine("WHERE a.FL_ATIVO = 1 ");*/
                sql.AppendLine("ORDER BY a.TX_NOME ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Consumidor c = new Consumidor();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                c.Id = Convert.ToInt32(dr["ID"]);
                                c.Nome = dr["TX_NOME"].ToString();
                                c.Cpf = dr["TX_CPF"].ToString();
                                c.Endereco = dr["TX_ENDERECO"].ToString();
                                c.Telefone = dr["TX_TELEFONE"].ToString();
                                c.Email = dr["TX_EMAIL"].ToString();

                                listaProjetos.Add(c);//Adicionando o objeto para a lista
                            }
                        }
                    }
                }
            }
            return listaProjetos;
        }

        public static Consumidor GetById(int id)
        {
            Consumidor c = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.ID, a.TX_NOME, a.TX_CPF, a.TX_ENDERECO, a.TX_TELEFONE, a.TX_EMAIL");
                sql.AppendLine("FROM TB_CONSUMIDOR a ");
                sql.AppendLine("WHERE a.ID = @ID ");
                sql.AppendLine("ORDER BY a.TX_NOME ");


                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@ID", id); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.Read())
                            {
                                c = new Consumidor();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                c.Id = Convert.ToInt32(dr["ID"]);
                                c.Nome = dr["TX_NOME"].ToString();
                                c.Cpf = dr["TX_CPF"].ToString();
                                c.Endereco = dr["TX_ENDERECO"].ToString();
                                c.Telefone = dr["TX_TELEFONE"].ToString();
                                c.Email = dr["TX_EMAIL"].ToString();

                            }
                        }
                    }
                }
            }
            return c;
        }
    }
}
