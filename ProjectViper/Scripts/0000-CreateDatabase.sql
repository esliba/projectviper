CREATE DATABASE ProyectoViper;
GO

USE ProyectoViper;
GO

CREATE TABLE dbo.Board
(  
    Id int PRIMARY KEY IDENTITY,
	ThemeId int NOT NULL
);
GO

CREATE TABLE dbo.Theme
(  
    Id int PRIMARY KEY IDENTITY,
	Name varchar(50) NOT NULL
);
GO

CREATE TABLE dbo.QContainer
(  
    Id int PRIMARY KEY IDENTITY,
	Name varchar(50) NOT NULL,
	ThemeId int NOT NULL
);
GO

CREATE TABLE dbo.Question
(  
    Id int PRIMARY KEY IDENTITY,
	Question varchar(100) NOT NULL,
	Level varchar(10) NOT NULL,
	Answer varchar(100) NOT NULL,
	QContainerId int NOT NULL,
	QOptionId int NULL
);
GO

CREATE TABLE dbo.QOption
(  
    Id int PRIMARY KEY IDENTITY,
	Option1 varchar(100) NOT NULL,
	Option2 varchar(100) NOT NULL,
	Option3 varchar(100) NOT NULL
);
GO