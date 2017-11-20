﻿CREATE TABLE Customers(
	CustomerID INT IDENTITY PRIMARY KEY NOT NULL,
	FirstName NVARCHAR(25) NOT NULL,
	LastName NVARCHAR(25) NOT NULL
);

CREATE TABLE Accounts(
	AccountID INT IDENTITY PRIMARY KEY NOT NULL,
	AccountNumber INT NOT NULL,
	Pin NVARCHAR(4) NOT NULL,
	AccountType NVARCHAR(10) NOT NULL,
	Balance BIGINT NOT NULL,
	CustomerID INT NOT NULL,
	CONSTRAINT [FK_dbo.Accounts_dbo.Customers_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerID]) ON DELETE CASCADE
);

CREATE TABLE Transactions(
	TransactionID INT IDENTITY PRIMARY KEY NOT NULL,
	TransactionType NVARCHAR(10) NOT NULL,
	AccountID INT NOT NULL
);

CREATE TABLE Withdrawls(
	WithdrawlID INT IDENTITY PRIMARY KEY NOT NULL,
	Amount BIGINT NOT NULL,
	TransactionID INT NOT NULL,
	CONSTRAINT [FK_dbo.Withdrawls_dbo.Transactions_TransactionID] FOREIGN KEY ([TransactionID]) REFERENCES [dbo].[Transactions] ([TransactionID]) ON DELETE CASCADE,
);

CREATE	TABLE Deposits(
	DepositID INT IDENTITY PRIMARY KEY NOT NULL,
	Amount BIGINT NOT NULL,
	TransactionID INT NOT NULL,
	CONSTRAINT [FK_dbo.Deposits_dbo.Transactions_TransactionID] FOREIGN KEY ([TransactionID]) REFERENCES [dbo].[Transactions] ([TransactionID]) ON DELETE CASCADE,
);