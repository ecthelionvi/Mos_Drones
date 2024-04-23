DROP TABLE IF EXISTS [Drone]
DROP TABLE IF EXISTS [Depot]
DROP TABLE IF EXISTS [Order]
DROP TABLE IF EXISTS [Account]
DROP TABLE IF EXISTS [Address]

CREATE TABLE [Address] (
  [addressId] int IDENTITY(1,1) PRIMARY KEY,
  [city] nvarchar(255),
  [state] nvarchar(255),
  [zip] nvarchar(255),
  [address_line] nvarchar(255)
)
GO

CREATE TABLE [Account] (
  [accountId] int IDENTITY(1,1) PRIMARY KEY,
  [first_name] nvarchar(255),
  [last_name] nvarchar(255),
  [email] nvarchar(255),
  [password] nvarchar(255),
  [addressId] int,
  [isAdmin] bit
)
GO

CREATE TABLE [Order] (
  [orderId] int IDENTITY(1,1) PRIMARY KEY,
  [packageId] nvarchar(255),
  [ship_date] datetime,
  [deliveryDate] datetime,
  [accountId] int,
  [shipped_from] int,
  [shipped_to] int
)
GO

CREATE TABLE [Depot] (
  [depotId] int IDENTITY(1,1) PRIMARY KEY,
  [addressId] int
)
GO

CREATE TABLE [Drone] (
  [droneId] int IDENTITY(1,1) PRIMARY KEY,
  [transit_status] nvarchar(255),
  [orderId] int,
  [depotId] int
)
GO

ALTER TABLE [Account] ADD CONSTRAINT account_to_address FOREIGN KEY ([addressId]) REFERENCES [Address] ([addressId])
GO

ALTER TABLE [Order] ADD CONSTRAINT order_to_account FOREIGN KEY ([accountId]) REFERENCES [Account] ([accountId])
GO

ALTER TABLE [Order] ADD CONSTRAINT order_to_start_address FOREIGN KEY ([shipped_from]) REFERENCES [Address] ([addressId])
GO

ALTER TABLE [Order] ADD CONSTRAINT order_to_end_address FOREIGN KEY ([shipped_to]) REFERENCES [Address] ([addressId])
GO

ALTER TABLE [Depot] ADD CONSTRAINT depot_to_address FOREIGN KEY ([addressId]) REFERENCES [Address] ([addressId])
GO

ALTER TABLE [Drone] ADD CONSTRAINT drone_to_order FOREIGN KEY ([orderId]) REFERENCES [Order] ([orderId])
GO

ALTER TABLE [Drone] ADD CONSTRAINT drone_to_depot FOREIGN KEY ([depotId]) REFERENCES [Depot] ([depotId])
GO