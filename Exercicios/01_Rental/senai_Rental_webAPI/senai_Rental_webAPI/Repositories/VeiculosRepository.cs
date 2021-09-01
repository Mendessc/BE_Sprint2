using senai_Rental_webAPI.Domain;
using senai_Rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Rental_webAPI.Repositories
{
    public class VeiculosRepository : IVeiculosRepository
    {
        private string stringConexao = @"Data Source = DESKTOP-KINHA\SQLEXPRESS; initial catalog=LOCADORA; user Id=sa; pwd=151917";
        public void AtualizarIdCorpo(VeiculosDomain VeiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUptadeBody = "UPDATE VEICULO SET idEmpresa = @idEmpresa, idModelo = @idModelo, placa = @placa WHERE idVeiculo = @idVeiculo";

                using (SqlCommand cmd = new SqlCommand(queryUptadeBody, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", VeiculoAtualizado.idVeiculo);
                    cmd.Parameters.AddWithValue("@idEmpresa", VeiculoAtualizado.idEmpresa);
                    cmd.Parameters.AddWithValue("@idModelo", VeiculoAtualizado.idModelo);
                    cmd.Parameters.AddWithValue("@placa", VeiculoAtualizado.placa);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculosDomain BuscarPorId(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idVeiculo, ISNULL(EMPRESA.idEmpresa,0)AS idEmpresa, nomeEmpresa AS EMPRESA, ISNULL(MODELO.idModelo,0)AS idModelo , idMarca, nomeModelo AS MODELO, placa AS PLACA FROM VEICULO RIGHT JOIN EMPRESA ON EMPRESA.idEmpresa = VEICULO.idEmpresa RIGHT JOIN MODELO ON VEICULO.idModelo = MODELO.idModelo WHERE idVeiculo = @idVeiculo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("idVeiculo", idVeiculo);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        VeiculosDomain veiculoBuscado = new VeiculosDomain
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),
                            idEmpresa = Convert.ToInt32(rdr[1]),
                            idModelo = Convert.ToInt32(rdr[3]),
                            placa = rdr[6].ToString(),
                            empresa = new EmpresaDomain()
                            {
                                idEmpresa = Convert.ToInt32(rdr[1]),
                                nomeEmpresa = rdr[2].ToString()
                            },
                            modelo = new ModeloDomain()
                            {
                                idModelo = Convert.ToInt32(rdr[3]),
                                idMarca = Convert.ToInt32(rdr[4]),
                                nomeModelo = rdr[5].ToString()
                            }
                        };
                        return veiculoBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(VeiculosDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO VEICULO (idModelo, idEmpresa, placa) VALUES (@idModelo,@idEmpresa, @placa)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.idModelo);
                    cmd.Parameters.AddWithValue("@idEmpresa", novoVeiculo.idEmpresa);
                    cmd.Parameters.AddWithValue("@placa", novoVeiculo.placa);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM VEICULO WHERE idVeiculo = @idVeiculo";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculosDomain> ListarTodos()
        {
            List<VeiculosDomain> listaVeiculos = new List<VeiculosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT ISNULL (VEICULO.idVeiculo,0) AS idVeiculo, ISNULL(EMPRESA.idEmpresa,0)AS idEmpresa, nomeEmpresa AS EMPRESA, ISNULL(MODELO.idModelo,0)AS idModelo , ISNULL(MODELO.idMarca,0) AS idMarca, nomeModelo AS MODELO, ISNULL(VEICULO.placa,0) AS PLACA FROM VEICULO RIGHT JOIN EMPRESA ON EMPRESA.idEmpresa = VEICULO.idEmpresa RIGHT JOIN MODELO ON VEICULO.idModelo = MODELO.idModelo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        VeiculosDomain veiculo = new VeiculosDomain()
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),
                            idEmpresa = Convert.ToInt32(rdr[1]),
                            idModelo = Convert.ToInt32(rdr[3]),
                            placa = rdr[6].ToString(),
                            empresa = new EmpresaDomain()
                            {
                                idEmpresa = Convert.ToInt32(rdr[1]),
                                nomeEmpresa = rdr[2].ToString()
                            },
                            modelo = new ModeloDomain()
                            {
                                idModelo = Convert.ToInt32(rdr[3]),
                                idMarca = Convert.ToInt32(rdr[4]),
                                nomeModelo = rdr[5].ToString()
                            }
                        };
                        listaVeiculos.Add(veiculo);
                    }
                }
            }
            return listaVeiculos;
        }
    }
}
