﻿CREATE TABLE [dbo].[Drivers]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL, 
    [Surname] VARCHAR(50) NOT NULL, 
    [CarId] INT NULL DEFAULT NULL, 
    CONSTRAINT [FK_Driver_Has_Car] FOREIGN KEY ([CarId]) REFERENCES [Cars]([Id])
)