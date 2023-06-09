CREATE TABLE SPORTS (
SportsId int PRIMARY KEY,
Sports nchar(13) NOT NULL UNIQUE);

SELECT * FROM dbo.SPORTS;

GO

CREATE TABLE TOURNAMENTLIST(
TournamentId int PRIMARY KEY,
Tournament nchar(25));

SELECT * FROM dbo.TOURNAMENTLIST;

GO
Drop table TOURNAMENT;
CREATE TABLE TOURNAMENT(
TournamentId int ,
Tournament nchar(25),
SportsId int FOREIGN KEY REFERENCES dbo.SPORTS(SportsId) ON DELETE CASCADE);

SELECT * FROM dbo.TOURNAMENT;

GO

Create table PLAYER(
PlayerId int Primary key,
TournamentID INT,
SportId int FOREIGN KEY REFERENCES dbo.SPORTS(SportsId) ON DELETE CASCADE);
GO
DROP TABLE SCOREBOARD;


CREATE TABLE SCOREBOARD(
TournamentId int ,
SportsId int FOREIGN KEY REFERENCES dbo.SPORTS(SportsId) ON DELETE CASCADE,
Player1ID int FOREIGN KEY REFERENCES dbo.PLAYER(PlayerID),
Player1Score int ,
Player2ID int FOREIGN KEY REFERENCES dbo.PLAYER(PlayerID),
Player2Score int);
SELECT * FROM dbo.SCOREBOARD;
SELECT * FROM dbo.PLAYER;
GO