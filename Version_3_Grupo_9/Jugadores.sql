DROP DATABASE IF EXISTS ;
CREATE DATABASE Jugadores;
USE Jugadores;

CREATE TABLE Jugador (
    id VARCHAR(60),
    Nickname VARCHAR(60),
    Usuario VARCHAR(60),
    Password VARCHAR(60),
    PuntuacionMaxima INT,
    PartidasJugadas INT,
    PartidasGanadas INT,
    PartidasPerdidas INT,
    TiempoJugado INT
)ENGINE=InnoDB;

INSERT INTO Jugador VALUES ('1','Toni99','ToniTur','123',70,200,3,2,40);
INSERT INTO Jugador VALUES ('2','Ulises20','UlisesOrtega','234',30,100,87,87,99);
INSERT INTO Jugador VALUES ('3','Victor15','VictorMoreno','345',80,300,87,89,60);
INSERT INTO Jugador VALUES ('4','Pedro7','PedroLedesma','456',99,400,98,56,56);


CREATE TABLE Relacion (
    idJugador VARCHAR(60),
    idPartida VARCHAR(60),
    Puntos INT,
    TiempoIndividual INT	  
)ENGINE=InnoDB;

INSERT INTO Relacion VALUES ('3','2',4,5);
INSERT INTO Relacion VALUES ('4','4',6,7);
INSERT INTO Relacion VALUES ('3','3',7,8);
INSERT INTO Relacion VALUES ('2','1',3,2);


CREATE TABLE Partida (
    id VARCHAR(60),
    NumPartida INT,
    TiempoPartida INT,
    Ganador VARCHAR(60),
    Perdedor VARCHAR(60),
    Fecha INT
)ENGINE=InnoDB;

INSERT INTO Partida VALUES ('1',1,45,'Toni99','Ulises20',31122019);
INSERT INTO Partida VALUES ('2',2,20,'Ulises20','Victor15',21102019);
INSERT INTO Partida VALUES ('3',3,32,'Toni99','Pedro7',15112019);
INSERT INTO Partida VALUES ('4',4,40,'Pedro7','Toni99',05062019);

