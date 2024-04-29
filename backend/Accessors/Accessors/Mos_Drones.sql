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
  [address_line] nvarchar(255),
  [latitude] float,
  [longitude] float
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

--Creating dummy data
insert into [Address] (city, state, zip, address_line, latitude, longitude) values ('Lincoln', 'Nebraska', '68510', '4321 O Street', 40.813380, -96.659490);
insert into [Address] (city, state, zip, address_line, latitude, longitude) values ('Lincoln', 'Nebraska', '68521', '2468 North 27th Street', 40.837620, -96.682030);
insert into [Address] (city, state, zip, address_line, latitude, longitude) values ('Lincoln', 'Nebraska', '68516', '9876 Pine Lake Road', 40.740760, -96.584900);
insert into [Address] (city, state, zip, address_line, latitude, longitude) values ('Lincoln', 'Nebraska', '68505', '8020 Holdrege Street', 40.828020, -96.611440);
insert into [Address] (city, state, zip, address_line, latitude, longitude) values ('Lincoln', 'Nebraska', '68506', '1357 South 84th Street', 40.799240, -96.606210);

insert into [Account] (first_name, last_name, email, password, addressId, isAdmin) values ('Alfred', 'Van Arsdall', 'avanarsdall0@cocolog-nifty.com', 'uI7lq}{e0WU', 1, 1);
insert into [Account] (first_name, last_name, email, password, addressId, isAdmin) values ('Beltran', 'Lillie', 'blillie1@imdb.com', 'hC7S>lx+N7a(?2>k', 2, 0);

insert into [Order] (packageId, ship_date, deliveryDate, accountId, shipped_from, shipped_to) values ('4829170638572946', '2024-04-14 10:30:00', '2024-04-17 15:44:00', 1, 1, 2);
insert into [Order] (packageId, ship_date, deliveryDate, accountId, shipped_from, shipped_to) values ('7294061538206194', '2024-04-01 17:12:00', '2024-04-05 08:15:00', 2, 2, 1);
insert into [Order] (packageId, ship_date, deliveryDate, accountId, shipped_from, shipped_to) values ('7632987401568235', '2024-04-15 19:33:00', '2024-04-18 09:17:00', 1, 1, 2);

insert into Depot (addressId) values (3);
insert into Depot (addressId) values (4);

insert into Drone (transit_status, orderId, depotId) values ('At Depot', 1, 1);
insert into Drone (transit_status, orderId, depotId) values ('Delivered', 2, null);

select * from Account;
SELECT * FROM Account WHERE email = null;
select * from Address;
SELECT * FROM Address WHERE addressId = -1;
SELECT Account.*, Address.city, Address.state, Address.zip, Address.address_line FROM Account JOIN Address ON Account.addressId = Address.addressId;
select * from Address where Address.addressId = 1;

SELECT * FROM Account WHERE email = 'avanarsdall0@cocolog-nifty.com';

select * from [Order];
SELECT * FROM [Order] WHERE orderId = 3;
SELECT * FROM [Order] WHERE packageId = '4829170638572946';
SELECT o.* FROM [Order] o JOIN [Account] a ON o.accountId = a.accountId WHERE o.accountId = 1;

SELECT o.* FROM [Order] o JOIN [Account] a ON o.accountId = a.accountId WHERE a.email = 'avanarsdall0@cocolog-nifty.com';

select * from Depot;
SELECT * FROM Depot WHERE depotId = 1;
select * from Drone;
Select * from [Drone] where droneId = 2;