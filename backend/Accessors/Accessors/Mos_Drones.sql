CREATE TABLE [User] (
  [userId] int PRIMARY KEY,
  [isAdmin] boolean,
  [accountId] int
)
GO

CREATE TABLE [Account] (
  [accountId] int PRIMARY KEY,
  [first_name] nvarchar(255),
  [last_name] nvarchar(255),
  [email] nvarchar(255),
  [password] nvarchar(255),
  [addressId] int
)
GO

CREATE TABLE [Address] (
  [addressId] int PRIMARY KEY,
  [city] nvarchar(255),
  [state] nvarchar(255),
  [zip] nvarchar(255),
  [address_line] nvarchar(255)
)
GO

CREATE TABLE [Order] (
  [orderId] int PRIMARY KEY,
  [packageId] nvarchar(255),
  [ship_date] datetime,
  [userId] int,
  [shipped_from] int,
  [shipped_to] int
)
GO

CREATE TABLE [Drone] (
  [droneId] int PRIMARY KEY,
  [transit_status] nvarchar(255),
  [orderId] int,
  [depotId] int
)
GO

CREATE TABLE [Depot] (
  [depotId] int PRIMARY KEY,
  [addressId] int
)
GO

ALTER TABLE [Account] ADD FOREIGN KEY ([accountId]) REFERENCES [User] ([accountId])
GO

ALTER TABLE [Address] ADD FOREIGN KEY ([addressId]) REFERENCES [Account] ([addressId])
GO

ALTER TABLE [User] ADD FOREIGN KEY ([userId]) REFERENCES [Order] ([userId])
GO

ALTER TABLE [Address] ADD FOREIGN KEY ([addressId]) REFERENCES [Order] ([shipped_from])
GO

ALTER TABLE [Address] ADD FOREIGN KEY ([addressId]) REFERENCES [Order] ([shipped_to])
GO

ALTER TABLE [Order] ADD FOREIGN KEY ([orderId]) REFERENCES [Drone] ([orderId])
GO

ALTER TABLE [Depot] ADD FOREIGN KEY ([depotId]) REFERENCES [Drone] ([depotId])
GO

ALTER TABLE [Address] ADD FOREIGN KEY ([addressId]) REFERENCES [Depot] ([addressId])
GO
