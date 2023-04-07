Create table team(
TeamId Int Primary Key,
TournamentId int Foreign key references	TOURNAMENTLIST(TournamentId) ON DELETE CASCADE);

CREATE TABLE PaymentDetails 
(
paymentId nchar(20) PRIMARY KEY,
PlayerId int FOREIGN KEY REFERENCES PLAYER(PlayerId)		ON DELETE CASCADE);

SELECT * FROM SPORTS	ORDER BY SportsId Asc;
SELECT * FROM TOURNAMENT;
SELECT * FROM TOURNAMENTLIST;
SELECT * FROM SCOREBOARD;
SELECT * FROM PLAYER;
SELECT * FROM PaymentDetails;
SELECT * FROM team;

INSERT INTO SPORTS VALUES (3,'Swimming'), (4,'Table Tennis'), (5,'Badminton'),(6,'Football'),(7,'Hockey');
INSERT INTO	TOURNAMENTLIST VALUES (2,'Tennis tournament') ,(3,'Swimming Tournament'), (4,'Table Tennis Tournament'), (5,'Badminton Tournament'),(6,'Football Tournament'),(7,'Hockey Tournament');
INSERT INTO	TOURNAMENT VALUES (2,'Tennis tournament',2) ,(3,'Swimming Tournament',3), (4,'Table Tennis Tournament',4), (5,'Badminton Tournament',5),(6,'Football Tournament',6),(7,'Hockey Tournament',7);

INSERT INTO PLAYER VALUES (1,4,4), (2,5,5),(3,1,1), (4,4,4), (5,1,1), (6,5,5);

INSERT INTO SCOREBOARD VALUES (1,1,3,23,5,34);
INSERT INTO SCOREBOARD VALUES (4,4,1,13,4,11);
INSERT INTO SCOREBOARD VALUES (5,5,2,3,6,4);

INSERT INTO team VALUES (101,7);
INSERT INTO team VALUES (111,3);
INSERT INTO team VALUES (102,6);

INSERT INTO PaymentDetails VALUES ('BFGYB12',1);
