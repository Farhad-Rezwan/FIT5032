
CREATE TABLE [dbo].[Res_Owner] (
  [Id] int IDENTITY(1,1) NOT NULL,
  [O_Email] nvarchar(max) NOT NULL,
  [O_Password] nvarchar(max) NOT NULL,
  [OF_Name] nvarchar(max) NOT NULL,
  [OL_Name] nvarchar(max) NOT NULL,
  [O_Phone] int NOT NULL,
  PRIMARY KEY (Id),
);
GO

CREATE TABLE [dbo].[Restaurant] (
  [Id] int IDENTITY(1,1) NOT NULL,
  [R_Name] nvarchar(max) NOT NULL,
  [Descrip] nvarchar(max) NOT NULL,
  [Latitude] numeric (10,8) NOT NULL,
  [Longitude] numeric (11, 8) NOT NULL,
  [RT_Service] nvarchar(max) NOT NULL,
  [RO_Email] nvarchar(max) NOT NULL,
  [ROPhone] int NOT NULL,
  [Res_O_id] int NOT NULL,
  PRIMARY KEY (Id),
  FOREIGN KEY (Res_O_id) REFERENCES Res_Owner(Id),
  CONSTRAINT Chk_Lat CHECK (Latitude >= -90 AND Latitude <=90),
  CONSTRAINT Chk_Lon CHECK (Longitude >= -180 AND Longitude <= 180)
);
GO




CREATE TABLE [dbo].[Reg_Customer] (
  [Id] int IDENTITY(1,1) NOT NULL,
  [C_Email] nvarchar(max) NOT NULL,
  [C_Password] nvarchar(max) NOT NULL,
  [CF_Name] nvarchar(max) NOT NULL,
  [CL_Name] nvarchar(max) NOT NULL,
  [C_Phone] int NOT NULL,
  PRIMARY KEY (Id),
);

GO

CREATE TABLE [dbo].[Booking] (
  [Id] int IDENTITY(1,1) NOT NULL,
  [Resturent_id] int NOT NULL,
  [Customer_id] int NOT NULL,
  PRIMARY KEY (Id),
  FOREIGN KEY (Resturent_id) REFERENCES Restaurant(Id),
  FOREIGN KEY (Customer_id) REFERENCES Reg_Customer(Id)


);
GO