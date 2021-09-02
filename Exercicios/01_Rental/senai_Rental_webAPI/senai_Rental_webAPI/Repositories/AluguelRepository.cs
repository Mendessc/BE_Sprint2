using senai_Rental_webAPI.Domain;
using senai_Rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Rental_webAPI.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private string stringConexao = @"Data Source = DESKTOP-KINHA\SQLEXPRESS; initial catalog=LOCADORA; user Id=sa; pwd=151917";
        public void AtualizarIdCorpo(AluguelDomain aluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUptadeBody = "UPDATE ALUGUEL SET idCliente = @idCliente, idVeiculo = @idVeiculo, dataAluguel = @dataAluguel, dataDevolucao = @datadevolucao WHERE idAluguel = @idAluguel";

                using (SqlCommand cmd = new SqlCommand(queryUptadeBody, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", aluguelAtualizado.idAluguel);
                    cmd.Parameters.AddWithValue("@idCliente", aluguelAtualizado.idCliente);
                    cmd.Parameters.AddWithValue("@idVeiculo", aluguelAtualizado.idVeiculo);
                    cmd.Parameters.AddWithValue("@dataAluguel", aluguelAtualizado.dataAluguel);
                    cmd.Parameters.AddWithValue("@dataDevolucao", aluguelAtualizado.dataDevolucao);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarPorId(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT ISNULL(ALUGUEL.idAluguel,0)AS idAluguel, ISNULL(CLIENTE.idCliente,0)AS idCliente, ISNULL(VEICULO.idVeiculo,0)AS idVeiculo, ISNULL(ALUGUEL.dataAluguel, null) AS DataRetirada, ISNULL(ALUGUEL.dataDevolucao, null) AS DataDevolução FROM ALUGUEL INNER JOIN CLIENTE ON CLIENTE.idCliente = ALUGUEL.idCliente INNER JOIN VEICULO ON ALUGUEL.idVeiculo = VEICULO.idVeiculo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("idAluguel", idAluguel);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        AluguelDomain aluguelBuscado = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),
                            idCliente = Convert.ToInt32(rdr[1]),
                            idVeiculo = Convert.ToInt32(rdr[2]),
                            dataAluguel = Convert.ToDateTime(rdr[3]),
                            dataDevolucao = Convert.ToDateTime(rdr[4])

                        };
                        return aluguelBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO ALUGUEL (idCliente, idVeiculo, dataAluguel, dataDevolucao) VALUES (@idCliente,@idVeiculo, @dataAluguel, @dataDevolucao)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", novoAluguel.idCliente);
                    cmd.Parameters.AddWithValue("@idVeiculo", novoAluguel.idVeiculo);
                    cmd.Parameters.AddWithValue("@dataAluguel", novoAluguel.dataAluguel);
                    cmd.Parameters.AddWithValue("@dataDevolucao", novoAluguel.dataDevolucao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM ALUGUEL WHERE idAluguel = @idAluguel";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listaAlugueis = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT ISNULL(ALUGUEL.idAluguel,0)AS idAluguel, ISNULL(CLIENTE.idCliente,0)AS idCliente, ISNULL(VEICULO.idVeiculo,0)AS idVeiculo , dataAluguel, dataDevolucao FROM ALUGUEL INNER JOIN CLIENTE ON CLIENTE.idCliente = ALUGUEL.idCliente INNER JOIN VEICULO ON ALUGUEL.idVeiculo = VEICULO.idVeiculo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        AluguelDomain aluguel = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),
                            idCliente = Convert.ToInt32(rdr[1]),
                            idVeiculo = Convert.ToInt32(rdr[2]),
                            dataAluguel = Convert.ToDateTime(rdr[3]),
                            dataDevolucao = Convert.ToDateTime(rdr[4])
                   
                        };
                        listaAlugueis.Add(aluguel);
                    }
                }
            }
            return listaAlugueis;
        }
    }
}
