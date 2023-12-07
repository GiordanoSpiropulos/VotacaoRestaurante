CREATE TABLE Profissional (
    ProfissionalID INT PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL
);

CREATE TABLE Restaurante (
    RestauranteID INT PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL
);

CREATE TABLE Votacao (
    VotacaoID INT PRIMARY KEY,
    ProfissionalID INT,
    RestauranteID INT,
    DataVotacao DATE,
    FOREIGN KEY (ProfissionalID) REFERENCES Profissional(ProfissionalID),
    FOREIGN KEY (RestauranteID) REFERENCES Restaurante(RestauranteID)
);

CREATE TABLE RestauranteVencedor (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    RestauranteID INT,
    DataVotacao DATETIME,
    FOREIGN KEY (RestauranteID) REFERENCES Restaurante(RestauranteID)
);

INSERT INTO Profissional (ProfissionalID, Nome)
VALUES
    (1, 'José Silva'),
    (2, 'Ana Oliveira'),
    (3, 'Carlos Pereira'),
    (4, 'Mariana Santos'),
    (5, 'Pedro Rocha'),
    (6, 'Amanda Lima'),
    (7, 'Rafael Oliveira'),
    (8, 'Camila Silva'),
    (9, 'Diego Pereira'),
    (10, 'Fernanda Costa');

INSERT INTO Restaurante (RestauranteID, Nome)
VALUES
    (1, 'Restaurante do Zé'),
    (2, 'Cantinho da Ana'),
    (3, 'Sabor do Carlos'),
    (4, 'Cupim do Paulin'),
    (5, 'Sabores do Interior'),
    (6, 'Amanda Gourmet'),
    (7, 'Dona Benta'),
    (8, 'Zebu'),
    (9, 'Sabor e Aroma'),
    (10, 'Terraço Gastronômico');


 