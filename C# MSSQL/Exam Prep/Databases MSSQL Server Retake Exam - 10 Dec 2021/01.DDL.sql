CREATE DATABASE Airport

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FullName VARCHAR(100) UNIQUE NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL,
)

CREATE TABLE Pilots
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(30) UNIQUE NOT NULL,
	LastName VARCHAR(30) UNIQUE NOT NULL,
	Age TINYINT NOT NULL CHECK (Age>=21 AND Age<=62),
	Rating FLOAT CHECK (Rating>=0.0 AND Rating<=10.0)
)

CREATE TABLE AircraftTypes
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	TypeName VARCHAR(30) UNIQUE NOT NULL,
)

CREATE TABLE Aircraft
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition CHAR NOT NULL,
	TypeId INT NOT NULL FOREIGN KEY REFERENCES AircraftTypes(Id)
)

CREATE TABLE PilotsAircraft
(
	AircraftId INT NOT NULL FOREIGN KEY REFERENCES Aircraft(Id),
	PilotId INT NOT NULL FOREIGN KEY REFERENCES Pilots(Id)

	CONSTRAINT PK_PilotsAircraft PRIMARY KEY (AircraftId,PilotId)
)


CREATE TABLE Airports
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	AirportName VARCHAR(70) UNIQUE NOT NULL,
	Country VARCHAR(100) UNIQUE NOT NULL,
)

CREATE TABLE FlightDestinations
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	AirportId INT NOT NULL FOREIGN KEY REFERENCES Airports(Id),
	[Start] DATETIME NOT NULL,
	AircraftId INT NOT NULL FOREIGN KEY REFERENCES Aircraft(Id),
	PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
	TicketPrice DECIMAL(18,2) NOT NULL DEFAULT 15
)