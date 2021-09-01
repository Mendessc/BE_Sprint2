USE LOCADORA;
GO

SELECT * FROM EMPRESA
SELECT * FROM CLIENTE
SELECT * FROM MARCA
SELECT * FROM MODELO
SELECT * FROM VEICULO
SELECT * FROM ALUGUEL

/*
 listar todos os alugueis mostrando as datas de início e fim,
 o nome do cliente que alugou e nome do modelo do carro
*/

SELECT nomeCliente, nomeModelo, dataDevolucao FROM ALUGUEL
LEFT JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
LEFT JOIN VEICULO
ON VEICULO.idVeiculo = ALUGUEL.idVeiculo
LEFT JOIN MODELO
ON MODELO.idModelo = VEICULO.idModelo
GO

/*
listar os alugueis de um determinado cliente mostrando seu nome,
as datas de início e fim e o nome do modelo do carro
*/

SELECT nomeCliente, nomeModelo, dataAluguel, dataDevolucao FROM ALUGUEL
RIGHT JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
LEFT JOIN VEICULO
ON VEICULO.idVeiculo = ALUGUEL.idVeiculo
LEFT JOIN MODELO
ON MODELO.idModelo = VEICULO.idModelo
GO


SELECT idVeiculo, ISNULL(EMPRESA.idEmpresa,0)AS idEmpresa, nomeEmpresa AS EMPRESA, ISNULL(MODELO.idModelo,0)AS idModelo , idMarca, nomeModelo AS MODELO, placa AS PLACA FROM VEICULO RIGHT JOIN EMPRESA ON EMPRESA.idEmpresa = VEICULO.idEmpresa RIGHT JOIN MODELO ON VEICULO.idModelo = MODELO.idModelo WHERE idVeiculo = @idVeiculo

SELECT ISNULL (VEICULO.idVeiculo,0) AS idVeiculo, ISNULL(EMPRESA.idEmpresa,0)AS idEmpresa, nomeEmpresa AS EMPRESA, ISNULL(MODELO.idModelo,0)AS idModelo , ISNULL(MODELO.idMarca,0) AS idMarca, nomeModelo AS MODELO, ISNULL(VEICULO.placa,0) AS PLACA FROM VEICULO RIGHT JOIN EMPRESA ON EMPRESA.idEmpresa = VEICULO.idEmpresa RIGHT JOIN MODELO ON VEICULO.idModelo = MODELO.idModelo

DELETE FROM VEICULO WHERE idVeiculo = 0