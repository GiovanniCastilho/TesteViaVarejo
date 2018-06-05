CREATE TABLE TB_USUARIO (
    ID_USUARIO INT IDENTITY(1,1) PRIMARY KEY,
    USUARIO VARCHAR(100),
	SENHA VARCHAR(100),
	ATIVO INT
);

CREATE TABLE TB_AMIGO (
    ID_AMIGO INT IDENTITY(1,1) PRIMARY KEY,
    NOME VARCHAR(100),
	IDADE INT,
	LATITUDE DECIMAL(9,6),
	LONGITUDE DECIMAL(9,6)
);

CREATE TABLE TB_CALCULO_HISTORICO_LOG (
    ID_CALCULO_HISTORICO_LOG INT IDENTITY(1,1) PRIMARY KEY,	
	LATITUDE_ATUAL DECIMAL(9,6),
	LONGITUDE_ATUAL DECIMAL(9,6),
	RESULTADO VARCHAR(MAX)
);

INSERT INTO TB_USUARIO (USUARIO,SENHA,ATIVO) VALUES ('USUARIO','SENHA',1);

INSERT INTO TB_AMIGO (NOME, IDADE, LATITUDE, LONGITUDE)  VALUES ('AMIGO 1',18,10,151);
INSERT INTO TB_AMIGO (NOME, IDADE, LATITUDE, LONGITUDE)  VALUES ('AMIGO 2',19,100,185);
INSERT INTO TB_AMIGO (NOME, IDADE, LATITUDE, LONGITUDE)  VALUES ('AMIGO 3',20,20,195);
INSERT INTO TB_AMIGO (NOME, IDADE, LATITUDE, LONGITUDE)  VALUES ('AMIGO 4',22,223,145);
INSERT INTO TB_AMIGO (NOME, IDADE, LATITUDE, LONGITUDE)  VALUES ('AMIGO 5',25,558,135);
INSERT INTO TB_AMIGO (NOME, IDADE, LATITUDE, LONGITUDE)  VALUES ('AMIGO 6',34,447,115);
INSERT INTO TB_AMIGO (NOME, IDADE, LATITUDE, LONGITUDE)  VALUES ('AMIGO 7',38,338,185);
INSERT INTO TB_AMIGO (NOME, IDADE, LATITUDE, LONGITUDE)  VALUES ('AMIGO 8',87,226,155);

--SELECT * FROM TB_CALCULO_HISTORICO_LOG