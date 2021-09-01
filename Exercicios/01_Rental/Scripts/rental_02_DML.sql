USE LOCADORA;
GO

INSERT INTO EMPRESA (nomeEmpresa)
VALUES ('UNIDAS'), ('MOTORS');
GO

INSERT INTO CLIENTE (nomeCliente, sobrenomeCliente)
VALUES ('LUCAS','MENDES'),('SAULO','SANTOS');
GO

INSERT INTO MARCA (nomeMarca)
VALUES ('VW'), ('GM');
GO

INSERT INTO MODELO (idMarca, nomeModelo)
VALUES (1, 'CELTA'), (2, 'POLO');
GO

INSERT INTO VEICULO (idModelo, idEmpresa, placa)
VALUES (1, 1, 'EEE-888'), (2, 2, 'TTT-999');
GO

INSERT INTO ALUGUEL (idVeiculo, idCliente, dataAluguel, dataDevolucao)
VALUES (2, 6, '03/08/2021', '06/08/2021'),
(1, 5, '05/08/2021', '10/08/2021');
GO


DELETE FROM EMPRESA
WHERE idEmpresa IN (4,5)

DELETE FROM CLIENTE
WHERE idCliente IN (1,2)

DELETE FROM MARCA
WHERE idMarca IN (3,4)

DELETE FROM MODELO
WHERE idModelo IN (3,4)

DELETE FROM VEICULO
WHERE idVeiculo IN (3,4)

DELETE FROM ALUGUEL
WHERE idAluguel IN (3,4)