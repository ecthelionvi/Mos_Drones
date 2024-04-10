CREATE TABLE [User] (
  [userId] int PRIMARY KEY,
  [isAdmin] bit, -- Changed boolean to bit
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

-- Corrected Foreign Key Constraints
-- Ensure foreign keys reference the correct primary key columns and respect logical order

-- Users may be linked to Accounts, but the original attempt to link them directly via accountId was incorrect because there's no accountId in User to link to Account's accountId
-- If intending to link Users to Accounts, you might need an additional column in Users for that or redesign how these relationships are established

-- Addresses may belong to a Depot, linking via addressId
ALTER TABLE [Depot] ADD FOREIGN KEY ([addressId]) REFERENCES [Address] ([addressId])
GO

-- Orders link to Users, shipped_from, and shipped_to might require additional tables or columns to represent locations or addresses correctly
ALTER TABLE [Order] ADD FOREIGN KEY ([userId]) REFERENCES [User] ([userId])
GO

-- Drones are linked to Orders and Depots
ALTER TABLE [Drone] ADD FOREIGN KEY ([orderId]) REFERENCES [Order] ([orderId])
ALTER TABLE [Drone] ADD FOREIGN KEY ([depotId]) REFERENCES [Depot] ([depotId])
GO
