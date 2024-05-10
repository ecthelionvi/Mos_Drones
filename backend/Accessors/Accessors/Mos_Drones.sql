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
  [shipped_to] int,
  [status] nvarchar(255)
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

--Depot Addresses
insert into [Address] (city, state, zip, address_line, latitude, longitude) values ('Seward', 'Nebraska', '68434', '434 North 8th Street', 40.911152, -97.101418);
insert into [Address] (city, state, zip, address_line, latitude, longitude) values ('Pleasant Dale', 'Nebraska', '68423', '1438 Alvo Road', 40.8864233, -96.9189836);
insert into [Address] (city, state, zip, address_line, latitude, longitude) values ('Lincoln', 'Nebraska', '68521', '2513 West Highway 34', 40.8743983, -96.7304361);
insert into [Address] (city, state, zip, address_line, latitude, longitude) values ('Lincoln', 'Nebraska', '68528', '201 Northwest 27th Street', 40.8138, -96.75889);
insert into [Address] (city, state, zip, address_line, latitude, longitude) values ('Lincoln', 'Nebraska', '68516', '7321 Nebraska Parkway', 40.73582, -96.60636);
insert into [Address] (city, state, zip, address_line, latitude, longitude) values ('Lincoln', 'Nebraska', '68505', '100 North 84th Street', 40.8135, -96.60594);
insert into [Address] (city, state, zip, address_line, latitude, longitude) values ('Lincoln', 'Nebraska', '68517', 'I-80 East', 40.897247, -96.5727986);
insert into [Address] (city, state, zip, address_line, latitude, longitude) values ('Greenwood', 'Nebraska', '68366', '22712 Church Road', 40.9575287, -96.4078043);
insert into [Address] (city, state, zip, address_line, latitude, longitude) values ('Gretna', 'Nebraska', '68028', '18208 Fishery Road', 41.0570905, -96.2939217);
insert into [Address] (city, state, zip, address_line, latitude, longitude) values ('Omaha', 'Nebraska', '68138', 'I-80 East', 41.1520287, -96.1537872);
insert into [Address] (city, state, zip, address_line, latitude, longitude) values ('Omaha', 'Nebraska', '68106', '6907 B Street', 41.224722, -96.01937);

insert into [Account] (first_name, last_name, email, password, addressId, isAdmin) values ('Alfred', 'Van Arsdall', 'avanarsdall0@cocolog-nifty.com', 'uI7lq}{e0WU', 1, 1);
insert into [Account] (first_name, last_name, email, password, addressId, isAdmin) values ('Beltran', 'Lillie', 'blillie1@imdb.com', 'hC7S>lx+N7a(?2>k', 2, 0);

insert into [Order] (packageId, ship_date, deliveryDate, accountId, shipped_from, shipped_to, status) values ('4829170638572946', '2024-04-14 10:30:00', '2024-04-17 15:44:00', 1, 1, 2, 'Delivered');
insert into [Order] (packageId, ship_date, deliveryDate, accountId, shipped_from, shipped_to, status) values ('7294061538206194', '2024-04-01 17:12:00', '2024-04-05 08:15:00', 2, 2, 1, 'Delivered');
insert into [Order] (packageId, ship_date, deliveryDate, accountId, shipped_from, shipped_to, status) values ('7632987401568235', '2024-04-15 19:33:00', '2024-04-18 09:17:00', 1, 1, 2, 'Delivered');

insert into Depot (addressId) values (6);
insert into Depot (addressId) values (7);
insert into Depot (addressId) values (8);
insert into Depot (addressId) values (9);
insert into Depot (addressId) values (10);
insert into Depot (addressId) values (11);
insert into Depot (addressId) values (12);
insert into Depot (addressId) values (13);
insert into Depot (addressId) values (14);
insert into Depot (addressId) values (15);
insert into Depot (addressId) values (16);

insert into Drone (transit_status, orderId, depotId) values ('Free', null, 1);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 1);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 1);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 1);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 1);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 1);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 1);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 1);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 1);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 1);

insert into Drone (transit_status, orderId, depotId) values ('Free', null, 2);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 2);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 2);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 2);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 2);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 2);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 2);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 2);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 2);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 2);

insert into Drone (transit_status, orderId, depotId) values ('Free', null, 3);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 3);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 3);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 3);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 3);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 3);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 3);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 3);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 3);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 3);

insert into Drone (transit_status, orderId, depotId) values ('Free', null, 4);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 4);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 4);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 4);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 4);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 4);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 4);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 4);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 4);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 4);

insert into Drone (transit_status, orderId, depotId) values ('Free', null, 5);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 5);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 5);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 5);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 5);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 5);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 5);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 5);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 5);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 5);

insert into Drone (transit_status, orderId, depotId) values ('Free', null, 6);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 6);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 6);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 6);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 6);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 6);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 6);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 6);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 6);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 6);

insert into Drone (transit_status, orderId, depotId) values ('Free', null, 7);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 7);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 7);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 7);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 7);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 7);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 7);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 7);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 7);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 7);

insert into Drone (transit_status, orderId, depotId) values ('Free', null, 8);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 8);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 8);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 8);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 8);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 8);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 8);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 8);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 8);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 8);

insert into Drone (transit_status, orderId, depotId) values ('Free', null, 9);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 9);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 9);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 9);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 9);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 9);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 9);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 9);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 9);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 9);

insert into Drone (transit_status, orderId, depotId) values ('Free', null, 10);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 10);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 10);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 10);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 10);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 10);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 10);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 10);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 10);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 10);

insert into Drone (transit_status, orderId, depotId) values ('Free', null, 11);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 11);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 11);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 11);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 11);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 11);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 11);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 11);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 11);
insert into Drone (transit_status, orderId, depotId) values ('Free', null, 11);

select * from Account;
SELECT * FROM Account WHERE email = null;
select * from Address;
SELECT * FROM Address WHERE addressId = -1;
SELECT Account.*, Address.city, Address.state, Address.zip, Address.address_line FROM Account JOIN Address ON Account.addressId = Address.addressId;
select * from Address where Address.addressId = 1;

SELECT * FROM Account WHERE email = 'avanarsdall0@cocolog-nifty.com';

select * from [Order];
select * from [Order] o JOIN [Address] a ON o.shipped_from = a.addressId JOIN [Address] b ON o.shipped_to = b.addressId;
SELECT * FROM [Order] WHERE orderId = 3;
SELECT * FROM [Order] WHERE packageId = '4829170638572946';
SELECT o.* FROM [Order] o JOIN [Account] a ON o.accountId = a.accountId WHERE o.accountId = 2;

SELECT o.* FROM [Order] o JOIN [Account] a ON o.accountId = a.accountId WHERE a.email = 'avanarsdall0@cocolog-nifty.com';

select * from Depot;
select * from Depot d JOIN [Address] a ON d.addressId = a.addressId;
SELECT * FROM Depot WHERE depotId = 1;
select * from Drone;
Select * from [Drone] where droneId = 1;