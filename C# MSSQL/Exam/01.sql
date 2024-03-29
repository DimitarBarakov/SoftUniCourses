CREATE DATABASE Boardgames

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	StreetName VARCHAR(100) NOT NULL,
	StreetNumber INT NOT NULL,
	Town VARCHAR(30) NOT NULL,
	Country VARCHAR(50) NOT NULL,
	ZIP INT NOT NULL,
)

CREATE TABLE Publishers
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(100) UNIQUE NOT NULL,
	AddressId INT NOT NULL FOREIGN KEY REFERENCES Addresses(Id),
	Website VARCHAR(40),
	Phone VARCHAR(20)
)

CREATE TABLE PlayersRanges
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	PlayersMin INT NOT NULL,
	PlayersMax INT NOT NULL
)

CREATE TABLE Boardgames
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(30) UNIQUE NOT NULL,
	YearPublished INT NOT NULL,
	Rating DECIMAL(18,2) NOT NULL,
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	PublisherId INT NOT NULL FOREIGN KEY REFERENCES Publishers(Id),
	PlayersRangeId INT NOT NULL FOREIGN KEY REFERENCES PlayersRanges(Id),
)

CREATE TABLE Creators
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL,
)

CREATE TABLE CreatorsBoardgames
(
	CreatorId INT NOT NULL FOREIGN KEY REFERENCES Creators(Id),
	BoardgameId INT NOT NULL FOREIGN KEY REFERENCES Boardgames(Id),

	CONSTRAINT PK_CB PRIMARY KEY (CreatorId,BoardgameId)
)