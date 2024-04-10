DROP TABLE IF EXISTS [Drone]
DROP TABLE IF EXISTS [Depot]
DROP TABLE IF EXISTS [Order]
DROP TABLE IF EXISTS [User]
DROP TABLE IF EXISTS [Account]
DROP TABLE IF EXISTS [Address]

CREATE TABLE [Address] (
  [addressId] int PRIMARY KEY,
  [city] nvarchar(255),
  [state] nvarchar(255),
  [zip] nvarchar(255),
  [address_line] nvarchar(255)
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
  
CREATE TABLE [User] (
  [userId] int PRIMARY KEY,
  [isAdmin] bit, -- Changed boolean to bit
  [accountId] int
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
  
CREATE TABLE [Depot] (
  [depotId] int PRIMARY KEY,
  [addressId] int
)
GO
  
CREATE TABLE [Drone] (
  [droneId] int PRIMARY KEY,
  [transit_status] nvarchar(255),
  [orderId] int,
  [depotId] int
)
GO

-- Corrected Foreign Key Constraints
-- Ensure foreign keys reference the correct primary key columns and respect logical order

-- Users may be linked to Accounts, but the original attempt to link them directly via accountId was incorrect because there's no accountId in User to link to Account's accountId
-- If intending to link Users to Accounts, you might need an additional column in Users for that or redesign how these relationships are established
ALTER TABLE [Account] ADD CONSTRAINT account_to_address FOREIGN KEY ([addressId]) REFERENCES [Address] ([addressId])
GO
  
ALTER TABLE [User] ADD CONSTRAINT user_to_account FOREIGN KEY ([accountId]) REFERENCES [Account] ([accountId])
GO

-- Orders link to Users, shipped_from, and shipped_to might require additional tables or columns to represent locations or addresses correctly
ALTER TABLE [Order] ADD CONSTRAINT order_to_user FOREIGN KEY ([userId]) REFERENCES [User] ([userId])
GO

ALTER TABLE [Order] ADD CONSTRAINT order_to_start_address FOREIGN KEY ([shipped_from]) REFERENCES [Address] ([addressId])
GO

ALTER TABLE [Order] ADD CONSTRAINT order_to_end_address FOREIGN KEY ([shipped_to]) REFERENCES [Address] ([addressId])
GO
  
-- Addresses may belong to a Depot, linking via addressId
ALTER TABLE [Depot] ADD CONSTRAINT depot_to_address FOREIGN KEY ([addressId]) REFERENCES [Address] ([addressId])
GO
  
-- Drones are linked to Orders and Depots
ALTER TABLE [Drone] ADD CONSTRAINT drone_to_order FOREIGN KEY ([orderId]) REFERENCES [Order] ([orderId])
GO

ALTER TABLE [Drone] ADD CONSTRAINT drone_to_depot FOREIGN KEY ([depotId]) REFERENCES [Depot] ([depotId])
GO
