USE master
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'FACTURAS')
BEGIN
    ALTER DATABASE FACTURAS SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE FACTURAS;
END
GO

CREATE DATABASE FACTURAS 
GO

USE [FACTURAS]
GO
/****** Object:  Table [dbo].[CLIENTE]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTE](
	[IDCLIENTE] [bigint] IDENTITY(1,1) NOT NULL,
	[CEDULA] [char](10) NULL,
	[NOMBRE] [char](30) NULL,
	[APELLIDOS] [char](30) NULL,
	[FECHA_NACIMIENTO] [date] NULL,
	[ESTADO] [bit] NULL,
 CONSTRAINT [PK_CLIENTE] PRIMARY KEY CLUSTERED 
(
	[IDCLIENTE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DETALLE_FACTURA]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE_FACTURA](
	[IDDETALLEFACTURA] [bigint] IDENTITY(1,1) NOT NULL,
	[IDFACTURA] [int] NOT NULL,
	[IDPRODUCTO] [bigint] NOT NULL,
	[CANTIDAD] [decimal](10, 2) NULL,
	[PRECIO_UNITARIO] [decimal](10, 2) NULL,
	[SUBTOTAL] [decimal](12, 4) NULL,
 CONSTRAINT [PK_DETALLE_FACTURA_1] PRIMARY KEY CLUSTERED 
(
	[IDDETALLEFACTURA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FACTURA]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FACTURA](
	[IDFACTURA] [int] IDENTITY(1,1) NOT NULL,
	[IDCLIENTE] [bigint] NULL,
	[FECHA] [datetime] NULL,
	[SUBTOTAL] [decimal](12, 4) NULL,
	[IVA] [decimal](5, 2) NULL,
	[TOTAL] [decimal](12, 4) NULL,
 CONSTRAINT [PK_FACTURA] PRIMARY KEY CLUSTERED 
(
	[IDFACTURA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IVA]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IVA](
	[ID_IVA] [int] IDENTITY(1,1) NOT NULL,
	[ValorIVA] [decimal](5, 2) NOT NULL,
	[FechaInicio] [date] NOT NULL,
	[FechaFinal] [date] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK__IVA__718900A39B713930] PRIMARY KEY CLUSTERED 
(
	[ID_IVA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTO]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTO](
	[IDPRODUCTO] [bigint] IDENTITY(1,1) NOT NULL,
	[PRODUCTO] [nchar](30) NULL,
	[PRECIO_UNITARIO] [decimal](10, 2) NULL,
	[STOCK] [decimal](10, 2) NULL,
	[ESTADO] [bit] NULL,
 CONSTRAINT [PK_PRODUCTO] PRIMARY KEY CLUSTERED 
(
	[IDPRODUCTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CLIENTE] ON 
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (1, N'9999999999', N'Consumidor                    ', N'Final                         ', CAST(N'2023-12-02' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (2, N'2123322222', N'Eduardo                       ', N'Perez                         ', CAST(N'2023-12-14' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (3, N'1207454172', N'Elvis Luis                    ', N'Gonzales Acosta               ', CAST(N'1994-08-09' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (4, N'1250400089', N'Karla                         ', N'Almea                         ', CAST(N'2001-11-20' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (5, N'1232131232', N'asda                          ', N'asd                           ', CAST(N'2023-12-23' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (6, N'1208024081', N'sebastian                     ', N'Perez                         ', CAST(N'2023-12-30' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (7, N'1207454172', N'elvis                         ', N'gonzales                      ', CAST(N'1991-07-18' AS Date), 0)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (8, N'5291020218', N'Jeniffer De Rechter           ', N'Celia Vatini                  ', CAST(N'2006-06-23' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (9, N'4049558060', N'Ulrick Dwelley                ', N'Byram Parcall                 ', CAST(N'2010-03-24' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (10, N'9740321214', N'Lydia Campey                  ', N'Carmencita Dittson            ', CAST(N'2002-02-26' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (11, N'7321684870', N'Skye Edmondson                ', N'Hal Brennan                   ', CAST(N'2023-01-21' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (12, N'5456291079', N'Ellary Devenny                ', N'Crystal Miell                 ', CAST(N'1997-06-17' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (13, N'3722908728', N'Cully Warne                   ', N'Wait Riggeard                 ', CAST(N'2022-10-22' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (14, N'7834966824', N'Christophe Hardan             ', N'Allsun Wheelhouse             ', CAST(N'1991-05-20' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (15, N'5481911267', N'Dede Northwood                ', N'Filberto Wickett              ', CAST(N'2016-01-11' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (16, N'6947367216', N'Nicola Demead                 ', N'Benni Honnan                  ', CAST(N'2002-06-11' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (17, N'0559539432', N'Dionysus Cannavan             ', N'Giusto Humpage                ', CAST(N'2019-12-22' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (18, N'0221259429', N'Hilary Skayman                ', N'Aurore Spargo                 ', CAST(N'1995-03-19' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (19, N'4102636449', N'Giordano Inkpen               ', N'Sibel Ziemke                  ', CAST(N'2007-09-10' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (20, N'4549311569', N'Roi McIlwrick                 ', N'Cristian Cockaday             ', CAST(N'2023-09-02' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (21, N'2460372709', N'Helyn Bees                    ', N'Arther De Bischop             ', CAST(N'2008-05-03' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (22, N'3677441301', N'North Jost                    ', N'Nicoline MacAughtrie          ', CAST(N'1989-08-29' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (23, N'9717837012', N'Felicity Kamiyama             ', N'Archie Wooton                 ', CAST(N'2009-01-12' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (24, N'3632591821', N'Fred Bridal                   ', N'Pedro Brakewell               ', CAST(N'2003-06-10' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (25, N'6286955526', N'Tobye Campany                 ', N'Jilleen Driver                ', CAST(N'2013-09-18' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (26, N'4732357337', N'Patton Seaking                ', N'Madison Farndon               ', CAST(N'2022-06-04' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (27, N'3416992742', N'Ardyce Antonomoli             ', N'Billye Teek                   ', CAST(N'1987-12-01' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (28, N'4440627052', N'Sonni Cloutt                  ', N'Doreen Serman                 ', CAST(N'2007-11-30' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (29, N'9302828768', N'Ingram Takis                  ', N'Alano Aitken                  ', CAST(N'2008-05-23' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (30, N'7987973094', N'Jethro Housego                ', N'Kliment Bygott                ', CAST(N'2007-02-03' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (31, N'1928345516', N'Base Dymocke                  ', N'Hervey Busby                  ', CAST(N'2001-09-09' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (32, N'6407504806', N'Electra Hartle                ', N'Brittaney Decourcy            ', CAST(N'2017-03-19' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (33, N'1076622940', N'Ollie Du Hamel                ', N'Cyndi Merkel                  ', CAST(N'2008-05-01' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (34, N'3428631673', N'Brunhilde Commuzzo            ', N'Lorene Jorgensen              ', CAST(N'2006-05-07' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (35, N'5254234879', N'Merna Boriston                ', N'Lorri Landre                  ', CAST(N'1982-07-03' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (36, N'4302970561', N'Rodney Davsley                ', N'Yasmin Dillestone             ', CAST(N'1992-07-31' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (37, N'3974065195', N'Magdalena Kightly             ', N'Tyrone Rope                   ', CAST(N'2018-06-02' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (38, N'7257333185', N'Beltran Yurygyn               ', N'Wald Spinas                   ', CAST(N'2004-06-18' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (39, N'2993484557', N'Ashbey Marioneau              ', N'Tim Phipard-Shears            ', CAST(N'2022-04-11' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (40, N'6573061703', N'Raphael Tackett               ', N'Steward Spickett              ', CAST(N'1992-11-29' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (41, N'6742301491', N'Janenna Cuttler               ', N'Zebadiah Comsty               ', CAST(N'1983-11-03' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (42, N'3643188472', N'Karlie Mussilli               ', N'Henri Nulty                   ', CAST(N'2009-08-18' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (43, N'9088544499', N'Brook Beel                    ', N'Bram Hallock                  ', CAST(N'2005-12-23' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (44, N'8060945432', N'Nessa Joubert                 ', N'Edgardo Calcutt               ', CAST(N'1994-04-01' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (45, N'3785890808', N'Mason Chennells               ', N'Tully Bassford                ', CAST(N'2000-09-12' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (46, N'6138771143', N'Cesare Lambshine              ', N'Delphine Jonin                ', CAST(N'2008-05-01' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (47, N'6051070835', N'Karl Offord                   ', N'Wenda Salvatore               ', CAST(N'2014-09-29' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (48, N'8794975472', N'Garek Deason                  ', N'Lisha Charnley                ', CAST(N'1987-09-12' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (49, N'5040791738', N'Abel Dabes                    ', N'Monika Koeppe                 ', CAST(N'1998-02-11' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (50, N'6945322472', N'Nadine Foyle                  ', N'Christoforo Darlington        ', CAST(N'2000-01-21' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (51, N'7004311463', N'Heinrick Giacoppo             ', N'Holt Ahrens                   ', CAST(N'2009-01-07' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (52, N'4609271437', N'Luise Bauser                  ', N'Ripley Bellas                 ', CAST(N'1997-03-02' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (53, N'3616203439', N'Millisent Aubry               ', N'Gertrudis Mazonowicz          ', CAST(N'2017-08-19' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (54, N'8650892113', N'Tommy Rootes                  ', N'Sonja Klulik                  ', CAST(N'2010-11-11' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (55, N'2501991664', N'Katie Ambrosio                ', N'Yelena Yurlov                 ', CAST(N'1987-07-13' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (56, N'7611935306', N'Ennis Givens                  ', N'Clayborne Jackes              ', CAST(N'2011-03-18' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (57, N'3675002579', N'Hiram Toope                   ', N'Yetta Shambroke               ', CAST(N'2015-12-16' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (58, N'2234115818', N'Dennie Whittlesea             ', N'Janel Kneesha                 ', CAST(N'1990-04-09' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (59, N'2956877061', N'Meggie Sidwell                ', N'Erich Enoch                   ', CAST(N'1980-07-06' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (60, N'2633648010', N'Jami McKilroe                 ', N'Rakel Lenard                  ', CAST(N'1988-10-11' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (61, N'6025741216', N'Philipa MacGovern             ', N'Issi Cockney                  ', CAST(N'1988-01-02' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (62, N'4480880017', N'Audy Portchmouth              ', N'Grove Karsh                   ', CAST(N'2019-12-17' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (63, N'6672314011', N'Lief Giacoppo                 ', N'Homer Pressnell               ', CAST(N'1987-04-17' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (64, N'0628131564', N'Sorcha Whapple                ', N'Norby Godding                 ', CAST(N'1994-03-25' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (65, N'0298029541', N'Shannon Newling               ', N'Claiborne Lawry               ', CAST(N'2013-12-06' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (66, N'7079533426', N'Katee Samter                  ', N'Liesa Yukhnevich              ', CAST(N'1982-07-06' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (67, N'7712886465', N'Christine Nabarro             ', N'Noak Frere                    ', CAST(N'2005-01-07' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (68, N'0310991334', N'Patty Connors                 ', N'Ebonee Martensen              ', CAST(N'1986-07-03' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (69, N'2804474464', N'Bonni Kneafsey                ', N'Andromache Gowen              ', CAST(N'2016-12-18' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (70, N'2838109486', N'Brandea Laughlin              ', N'Margret Skarman               ', CAST(N'2015-09-14' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (71, N'8839886469', N'Kele Twidle                   ', N'Elia Rozec                    ', CAST(N'2000-06-06' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (72, N'0109003861', N'Brockie Huckle                ', N'Hagen Holberry                ', CAST(N'2022-01-28' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (73, N'9523063357', N'Livvyy Thinn                  ', N'Emmey McGenn                  ', CAST(N'1993-06-09' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (74, N'7925536411', N'Joyann Bengle                 ', N'Tiebout Gudyer                ', CAST(N'2002-04-17' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (75, N'1253655587', N'Chev Stallard                 ', N'Kleon Johnes                  ', CAST(N'2023-10-08' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (76, N'0244437458', N'Zulema Glencros               ', N'Roosevelt Vernazza            ', CAST(N'2004-06-03' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (77, N'0729692401', N'Bili Geraud                   ', N'Moira Sahlstrom               ', CAST(N'1980-09-17' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (78, N'4006043464', N'Aili Duckerin                 ', N'Rita Mauditt                  ', CAST(N'2014-10-12' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (79, N'4720861082', N'Karie Blackesland             ', N'Ivan Charlotte                ', CAST(N'2019-01-14' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (80, N'2716733313', N'Rowen Roussel                 ', N'Meris Ferraron                ', CAST(N'1983-07-21' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (81, N'4975553165', N'Isadore Giraudot              ', N'Jessie Redd                   ', CAST(N'1997-06-29' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (82, N'8842947475', N'Batsheva Fidoe                ', N'Una Stainson                  ', CAST(N'1982-09-27' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (83, N'1668108403', N'Randal Coppo                  ', N'Louise Samways                ', CAST(N'1985-06-30' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (84, N'0707878952', N'Junia Agar                    ', N'Shannon Dreng                 ', CAST(N'1990-06-19' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (85, N'6022241871', N'Emmy Djurevic                 ', N'Alick Casel                   ', CAST(N'2008-11-13' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (86, N'3243451132', N'Cristian Corby                ', N'Randy Drinkel                 ', CAST(N'1993-02-01' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (87, N'8008752152', N'Lynn Ferneyhough              ', N'Gilemette Wintersgill         ', CAST(N'2018-02-15' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (88, N'4698928227', N'Talya Gristock                ', N'Duane Simonard                ', CAST(N'2020-10-10' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (89, N'1916323120', N'Celinda Cant                  ', N'Hal Girvin                    ', CAST(N'2005-05-14' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (90, N'9584942033', N'Trina Malcolmson              ', N'Carina Gascar                 ', CAST(N'2007-10-23' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (91, N'1147221022', N'Robinson Minker               ', N'Ronni McBrearty               ', CAST(N'1999-02-08' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (92, N'0687581801', N'Pepito Manass                 ', N'Kerri Deeny                   ', CAST(N'1990-12-10' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (93, N'8069856240', N'Rikki Vasiltsov               ', N'Onfre McMenemy                ', CAST(N'2000-05-25' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (94, N'0040315144', N'Clarie Rome                   ', N'Marleen Alekseicik            ', CAST(N'1997-07-04' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (95, N'1200859279', N'Luis Royall                   ', N'Ashleigh Dymick               ', CAST(N'2022-01-24' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (96, N'7085772536', N'Aridatha Westoll              ', N'Joellen Sixsmith              ', CAST(N'2010-12-02' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (97, N'9943478236', N'Corbet Revan                  ', N'Lydie Baumler                 ', CAST(N'1993-12-19' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (98, N'9277082072', N'Bibbye Veitch                 ', N'Lance Calabry                 ', CAST(N'1983-12-09' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (99, N'6665751571', N'Hinze Abram                   ', N'Minnaminnie Couldwell         ', CAST(N'1990-02-05' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (100, N'8488664867', N'Franciskus Van der Hoeven     ', N'Cleo Lys                      ', CAST(N'2015-04-09' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (101, N'1646726378', N'Pip Renneke                   ', N'Ely Streetley                 ', CAST(N'2022-08-01' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (102, N'2428443626', N'Tina Santori                  ', N'Olly Basini-Gazzi             ', CAST(N'1987-05-20' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (103, N'2030345288', N'Feodora English               ', N'Upton Janous                  ', CAST(N'2017-06-24' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (104, N'1676143108', N'Marrilee Stanes               ', N'Dotti Ritson                  ', CAST(N'1988-02-03' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (105, N'2315342006', N'Tully Yanyushkin              ', N'Pavla Beachamp                ', CAST(N'2017-10-31' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (106, N'4434012142', N'Arney Grieger                 ', N'Izaak Foster                  ', CAST(N'1980-12-11' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (107, N'0964143187', N'Philbert Primmer              ', N'Nance Spafford                ', CAST(N'1980-08-25' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (108, N'2361680524', N'Parke Buckley                 ', N'Dennie Oglethorpe             ', CAST(N'2013-12-20' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (109, N'3628736380', N'Janeen Gorges                 ', N'Clotilda Mugglestone          ', CAST(N'1992-11-10' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (110, N'4017020643', N'Lennard Morena                ', N'Kerr Drysdall                 ', CAST(N'2019-12-29' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (111, N'6871256923', N'Bartholomew Rubinovitch       ', N'Rozamond Surgey               ', CAST(N'1980-11-14' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (112, N'5140403267', N'Crichton Rudeyeard            ', N'Chrotoem Rennard              ', CAST(N'1987-01-10' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (113, N'5067368922', N'Brennen Barber                ', N'Artemus Vouls                 ', CAST(N'1983-12-01' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (114, N'1492102609', N'Rani Laurand                  ', N'Christiano Kliemke            ', CAST(N'2004-02-25' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (115, N'0098611432', N'Sheffie Hartopp               ', N'Fleur Tatteshall              ', CAST(N'2019-01-16' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (116, N'9718835715', N'Andros Hanhardt               ', N'Lyn Hollingshead              ', CAST(N'1981-08-03' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (117, N'5893618561', N'Bernie Barber                 ', N'Trina Klima                   ', CAST(N'2002-11-05' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (118, N'5134894780', N'Marcellina Elvey              ', N'Broddy Neilly                 ', CAST(N'1981-06-28' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (119, N'4347324308', N'Phyllys Bridden               ', N'Beitris Pulfer                ', CAST(N'1989-03-22' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (120, N'0688635568', N'Alasteir Crofthwaite          ', N'Ferrel McCoughan              ', CAST(N'1991-12-12' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (121, N'0209197465', N'Marge Tumielli                ', N'Elie Lethem                   ', CAST(N'2007-03-14' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (122, N'9746440021', N'Micaela Piel                  ', N'Patience Wimpey               ', CAST(N'2014-07-15' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (123, N'3454426795', N'Cleopatra Schwant             ', N'Brody Audenis                 ', CAST(N'1995-01-09' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (124, N'1048230036', N'Parrnell Voelker              ', N'Tobe Naden                    ', CAST(N'2001-03-25' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (125, N'4743643297', N'Muhammad Bisterfeld           ', N'Briant Grenfell               ', CAST(N'2003-03-22' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (126, N'6522450011', N'Rodger Rushby                 ', N'Bobbie Schankel               ', CAST(N'2014-11-15' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (127, N'8388308229', N'Gregorius Kieff               ', N'Charissa Jamary               ', CAST(N'1986-01-06' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (128, N'3665809142', N'Fonz Jowsey                   ', N'Larisa Batter                 ', CAST(N'1985-05-20' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (129, N'3880140510', N'Crystal Clayden               ', N'Ikey Crompton                 ', CAST(N'2022-05-28' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (130, N'3717218145', N'Izzy Uzelli                   ', N'Mignonne Edinborough          ', CAST(N'1999-03-16' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (131, N'8723306714', N'Guillema Coe                  ', N'Aliza Ilyinski                ', CAST(N'2000-09-25' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (132, N'6237559626', N'Addison Sitford               ', N'Darleen Bondley               ', CAST(N'2018-07-13' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (133, N'2592246229', N'Broderick Dalgardno           ', N'Ranique Redhills              ', CAST(N'1986-11-14' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (134, N'3203122470', N'Annnora Gladman               ', N'Donia Nancarrow               ', CAST(N'2023-01-21' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (135, N'7502891241', N'Candide Goodridge             ', N'Alisun Elie                   ', CAST(N'2021-05-24' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (136, N'4042650705', N'Linea Rubinsohn               ', N'Lemmy Januszewicz             ', CAST(N'2004-10-06' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (137, N'0966757221', N'Claiborne Hubery              ', N'Carlye Bainton                ', CAST(N'1980-04-04' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (138, N'5806452311', N'Leonanie Richardin            ', N'Jere Groombridge              ', CAST(N'1999-12-26' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (139, N'1155340650', N'Rahel Brandli                 ', N'Karola Beeton                 ', CAST(N'1991-06-11' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (140, N'8513023761', N'Noll Aleksandrov              ', N'Alisa Hargrave                ', CAST(N'2022-09-21' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (141, N'2933153581', N'Wayland Mobley                ', N'Gayle Slym                    ', CAST(N'1991-08-25' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (142, N'5179292640', N'Maurita Southerden            ', N'Arthur Kalinsky               ', CAST(N'1996-04-07' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (143, N'7811187557', N'Mureil Treece                 ', N'Arlene Loveard                ', CAST(N'2003-12-03' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (144, N'7028128077', N'Wiley Elvish                  ', N'Elka Della                    ', CAST(N'1988-06-28' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (145, N'9440178864', N'Fern Feld                     ', N'Gabbi Maylott                 ', CAST(N'1984-04-13' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (146, N'9255492975', N'Archer Glazyer                ', N'Daniela Pettyfer              ', CAST(N'1987-08-20' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (147, N'8981088879', N'Maighdiln Omrod               ', N'Balduin Sherwood              ', CAST(N'1998-12-31' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (148, N'6113040320', N'Cordie Pegrum                 ', N'Claudius Smalles              ', CAST(N'1983-07-26' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (149, N'6832777383', N'Gale Nore                     ', N'Bo Laraway                    ', CAST(N'2001-12-12' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (150, N'7754668610', N'Amble Espadate                ', N'Maddie Hayer                  ', CAST(N'2017-11-08' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (151, N'0864603237', N'Giffy Grishkov                ', N'Kattie Wilfing                ', CAST(N'1999-04-09' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (152, N'9499743983', N'Spencer Godbald               ', N'Davide Edgeson                ', CAST(N'2020-03-15' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (153, N'4046437670', N'Mufi Grubey                   ', N'Obadias McPhaden              ', CAST(N'2011-03-11' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (154, N'3015446537', N'Kermit O''Donoghue             ', N'Enid Davis                    ', CAST(N'2005-01-04' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (155, N'6549391542', N'Jorie Cannan                  ', N'Hildegaard Worsnap            ', CAST(N'2003-01-25' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (156, N'3192923239', N'Marlene Scambler              ', N'Allistir Ewbank               ', CAST(N'1986-05-14' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (157, N'3437849276', N'Lyndsey Bedder                ', N'Brenden O''Spellissey          ', CAST(N'2000-02-29' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (158, N'2781995662', N'Kendra Snelling               ', N'Rodolfo Rodenborch            ', CAST(N'1989-08-25' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (159, N'2906618444', N'Delcine Hankey                ', N'Ally Jiggle                   ', CAST(N'1981-10-24' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (160, N'5673533470', N'Chicky Edgeller               ', N'Hillery Malham                ', CAST(N'2013-10-27' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (161, N'5129178843', N'Koralle Brandi                ', N'Diane-marie Furtado           ', CAST(N'1987-06-16' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (162, N'5795447820', N'Packston Jenner               ', N'Velma Egentan                 ', CAST(N'2014-09-30' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (163, N'4918574019', N'Gabbie McCahill               ', N'Kinny Bog                     ', CAST(N'1989-07-14' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (164, N'0234198125', N'Wesley Brodhead               ', N'Blancha Astley                ', CAST(N'1990-02-21' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (165, N'8131582739', N'Karleen Rosone                ', N'Holt Glackin                  ', CAST(N'1986-04-15' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (166, N'1596854116', N'Trula Crame                   ', N'Cecile Freen                  ', CAST(N'1986-03-14' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (167, N'0034462358', N'Thomasin Everil               ', N'Albertine Sarath              ', CAST(N'1990-01-25' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (168, N'2555849279', N'Zulema Beecroft               ', N'Geri Cazalet                  ', CAST(N'2014-04-01' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (169, N'8254142136', N'Judon Berthelet               ', N'Melody Boutcher               ', CAST(N'2019-02-04' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (170, N'9491451409', N'Bron Oldham                   ', N'Jeanne Tresler                ', CAST(N'1989-12-14' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (171, N'5438628249', N'Jillana Ballingal             ', N'Abie Edland                   ', CAST(N'1995-06-08' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (172, N'4515806589', N'Audie Dunrige                 ', N'Anna-diana Rustman            ', CAST(N'1989-11-11' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (173, N'5988583822', N'Rupert Pollett                ', N'Albie Kohtler                 ', CAST(N'2023-12-30' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (174, N'5318468779', N'Rosemary Lembcke              ', N'Anett Worswick                ', CAST(N'2005-02-10' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (175, N'7977885982', N'Tarra Force                   ', N'Xymenes Tweedy                ', CAST(N'1981-09-16' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (176, N'7832395362', N'Mattias Constant              ', N'Chen Meardon                  ', CAST(N'2004-09-23' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (177, N'8492713144', N'Darb Langran                  ', N'Cliff Marwick                 ', CAST(N'2011-12-26' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (178, N'3461104033', N'Omar Dominique                ', N'Jacquenette Marguerite        ', CAST(N'2009-07-20' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (179, N'0103910192', N'Beauregard Rapps              ', N'Emera Pike                    ', CAST(N'2015-01-03' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (180, N'1126797099', N'Jamil Anstiss                 ', N'Martin Minney                 ', CAST(N'1994-11-16' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (181, N'7198563398', N'Catherina Hugo                ', N'Lia Schindler                 ', CAST(N'2024-02-06' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (182, N'7281911062', N'Zabrina Dyers                 ', N'Brit MacTrustey               ', CAST(N'1997-12-08' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (183, N'1103821622', N'Hillier Olenikov              ', N'Peta Berzen                   ', CAST(N'1982-11-10' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (184, N'7350277296', N'Leonidas Peyro                ', N'Shela Denton                  ', CAST(N'1980-12-22' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (185, N'7367987007', N'Margot Duffill                ', N'Chryste Balk                  ', CAST(N'2024-01-17' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (186, N'6411920280', N'Astrid Glisenan               ', N'Merrile Greenrde              ', CAST(N'1991-09-17' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (187, N'9198901091', N'Nahum Luckhurst               ', N'Wilton Ormesher               ', CAST(N'1992-01-24' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (188, N'6690806326', N'Cass MacPaik                  ', N'Isa Bernat                    ', CAST(N'2022-01-15' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (189, N'1542253685', N'Caresa Scardifeild            ', N'Sallie Kenchington            ', CAST(N'2007-09-04' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (190, N'2486364169', N'Coletta Lacoste               ', N'Issie Meece                   ', CAST(N'2021-09-25' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (191, N'3856595372', N'Amie Curtin                   ', N'Faun Midden                   ', CAST(N'1997-08-10' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (192, N'4785904095', N'Cris Ianitti                  ', N'Uriah Robinson                ', CAST(N'2006-06-27' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (193, N'2795045429', N'Luz Please                    ', N'Astra Zamora                  ', CAST(N'1981-08-21' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (194, N'9937989079', N'Jens Spottswood               ', N'Wilfred Mathan                ', CAST(N'2018-04-04' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (195, N'7226667111', N'Dew Gaucher                   ', N'Linet Gosnell                 ', CAST(N'2015-02-05' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (196, N'5736446301', N'Xenia Bunting                 ', N'Betta Silburn                 ', CAST(N'2011-11-26' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (197, N'6258940811', N'Sheeree Andrysiak             ', N'Ema Van Der Straaten          ', CAST(N'1997-09-04' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (198, N'0400603136', N'Kristal Picknett              ', N'Miriam Houndson               ', CAST(N'2009-09-06' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (199, N'3646641774', N'Keene Godden                  ', N'Benoite Ricarde               ', CAST(N'2019-04-24' AS Date), 1)
GO
INSERT [dbo].[CLIENTE] ([IDCLIENTE], [CEDULA], [NOMBRE], [APELLIDOS], [FECHA_NACIMIENTO], [ESTADO]) VALUES (200, N'0800137611', N'Baily Cherryman               ', N'Bartolemo Danet               ', CAST(N'2023-07-22' AS Date), 1)
GO
SET IDENTITY_INSERT [dbo].[CLIENTE] OFF
GO
SET IDENTITY_INSERT [dbo].[DETALLE_FACTURA] ON 
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (1, 1, 1, CAST(12.00 AS Decimal(10, 2)), CAST(1.10 AS Decimal(10, 2)), CAST(13.2000 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (2, 1, 3, CAST(1.00 AS Decimal(10, 2)), CAST(1.20 AS Decimal(10, 2)), CAST(1.2000 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (3, 1, 2, CAST(10.00 AS Decimal(10, 2)), CAST(0.80 AS Decimal(10, 2)), CAST(8.0000 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (4, 2, 1, CAST(2.00 AS Decimal(10, 2)), CAST(1.10 AS Decimal(10, 2)), CAST(2.2000 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (5, 2, 3, CAST(3.00 AS Decimal(10, 2)), CAST(1.20 AS Decimal(10, 2)), CAST(3.6000 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (6, 3, 1, CAST(1.00 AS Decimal(10, 2)), CAST(1.10 AS Decimal(10, 2)), CAST(1.1000 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (7, 4, 1, CAST(2.00 AS Decimal(10, 2)), CAST(1.10 AS Decimal(10, 2)), CAST(2.2000 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (8, 4, 3, CAST(3.00 AS Decimal(10, 2)), CAST(1.20 AS Decimal(10, 2)), CAST(3.6000 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (9, 5, 1, CAST(12.00 AS Decimal(10, 2)), CAST(110.00 AS Decimal(10, 2)), CAST(1320.0000 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (10, 6, 1, CAST(2.00 AS Decimal(10, 2)), CAST(110.00 AS Decimal(10, 2)), CAST(220.0000 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (11, 7, 2, CAST(2.00 AS Decimal(10, 2)), CAST(0.80 AS Decimal(10, 2)), CAST(1.6000 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (12, 8, 5, CAST(20.00 AS Decimal(10, 2)), CAST(1.25 AS Decimal(10, 2)), CAST(25.0000 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (13, 9, 6, CAST(5.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(5.0000 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (14, 9, 1, CAST(6.00 AS Decimal(10, 2)), CAST(1.10 AS Decimal(10, 2)), CAST(6.6000 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (15, 10, 7, CAST(1.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(1.0000 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (16, 11, 2, CAST(1.00 AS Decimal(10, 2)), CAST(0.80 AS Decimal(10, 2)), CAST(0.8000 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (17, 11, 7, CAST(1.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(1.0000 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (18, 11, 1, CAST(5.00 AS Decimal(10, 2)), CAST(1.10 AS Decimal(10, 2)), CAST(5.5000 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (29, 24, 4, CAST(1.00 AS Decimal(10, 2)), CAST(1.10 AS Decimal(10, 2)), CAST(1.1000 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (32, 35, 27, CAST(2.00 AS Decimal(10, 2)), CAST(809.23 AS Decimal(10, 2)), CAST(1618.4600 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (33, 35, 19, CAST(2.00 AS Decimal(10, 2)), CAST(619.53 AS Decimal(10, 2)), CAST(1239.0600 AS Decimal(12, 4)))
GO
INSERT [dbo].[DETALLE_FACTURA] ([IDDETALLEFACTURA], [IDFACTURA], [IDPRODUCTO], [CANTIDAD], [PRECIO_UNITARIO], [SUBTOTAL]) VALUES (34, 35, 17, CAST(5.00 AS Decimal(10, 2)), CAST(998.54 AS Decimal(10, 2)), CAST(4992.7000 AS Decimal(12, 4)))
GO
SET IDENTITY_INSERT [dbo].[DETALLE_FACTURA] OFF
GO
SET IDENTITY_INSERT [dbo].[FACTURA] ON 
GO
INSERT [dbo].[FACTURA] ([IDFACTURA], [IDCLIENTE], [FECHA], [SUBTOTAL], [IVA], [TOTAL]) VALUES (1, 1, CAST(N'2023-12-16T00:00:00.000' AS DateTime), CAST(22.4000 AS Decimal(12, 4)), CAST(12.00 AS Decimal(5, 2)), CAST(25.0900 AS Decimal(12, 4)))
GO
INSERT [dbo].[FACTURA] ([IDFACTURA], [IDCLIENTE], [FECHA], [SUBTOTAL], [IVA], [TOTAL]) VALUES (2, 1, CAST(N'2023-12-16T00:00:00.000' AS DateTime), CAST(5.8000 AS Decimal(12, 4)), CAST(12.00 AS Decimal(5, 2)), CAST(6.5000 AS Decimal(12, 4)))
GO
INSERT [dbo].[FACTURA] ([IDFACTURA], [IDCLIENTE], [FECHA], [SUBTOTAL], [IVA], [TOTAL]) VALUES (3, 1, CAST(N'2023-12-16T00:00:00.000' AS DateTime), CAST(1.1000 AS Decimal(12, 4)), CAST(12.00 AS Decimal(5, 2)), CAST(1.2300 AS Decimal(12, 4)))
GO
INSERT [dbo].[FACTURA] ([IDFACTURA], [IDCLIENTE], [FECHA], [SUBTOTAL], [IVA], [TOTAL]) VALUES (4, 2, CAST(N'2023-12-16T00:00:00.000' AS DateTime), CAST(5.8000 AS Decimal(12, 4)), CAST(12.00 AS Decimal(5, 2)), CAST(6.5000 AS Decimal(12, 4)))
GO
INSERT [dbo].[FACTURA] ([IDFACTURA], [IDCLIENTE], [FECHA], [SUBTOTAL], [IVA], [TOTAL]) VALUES (5, 1, CAST(N'2024-01-03T00:00:00.000' AS DateTime), CAST(1320.0000 AS Decimal(12, 4)), CAST(12.00 AS Decimal(5, 2)), CAST(1478.4000 AS Decimal(12, 4)))
GO
INSERT [dbo].[FACTURA] ([IDFACTURA], [IDCLIENTE], [FECHA], [SUBTOTAL], [IVA], [TOTAL]) VALUES (6, 1, CAST(N'2024-01-09T00:00:00.000' AS DateTime), CAST(220.0000 AS Decimal(12, 4)), CAST(12.00 AS Decimal(5, 2)), CAST(246.4000 AS Decimal(12, 4)))
GO
INSERT [dbo].[FACTURA] ([IDFACTURA], [IDCLIENTE], [FECHA], [SUBTOTAL], [IVA], [TOTAL]) VALUES (7, 1, CAST(N'2024-01-11T00:00:00.000' AS DateTime), CAST(1.6000 AS Decimal(12, 4)), CAST(12.00 AS Decimal(5, 2)), CAST(1.7900 AS Decimal(12, 4)))
GO
INSERT [dbo].[FACTURA] ([IDFACTURA], [IDCLIENTE], [FECHA], [SUBTOTAL], [IVA], [TOTAL]) VALUES (8, 3, CAST(N'2024-01-30T00:00:00.000' AS DateTime), CAST(25.0000 AS Decimal(12, 4)), CAST(12.00 AS Decimal(5, 2)), CAST(28.0000 AS Decimal(12, 4)))
GO
INSERT [dbo].[FACTURA] ([IDFACTURA], [IDCLIENTE], [FECHA], [SUBTOTAL], [IVA], [TOTAL]) VALUES (9, 4, CAST(N'2024-02-05T00:00:00.000' AS DateTime), CAST(11.6000 AS Decimal(12, 4)), CAST(12.00 AS Decimal(5, 2)), CAST(12.9900 AS Decimal(12, 4)))
GO
INSERT [dbo].[FACTURA] ([IDFACTURA], [IDCLIENTE], [FECHA], [SUBTOTAL], [IVA], [TOTAL]) VALUES (10, 6, CAST(N'2024-02-05T00:00:00.000' AS DateTime), CAST(1.0000 AS Decimal(12, 4)), CAST(12.00 AS Decimal(5, 2)), CAST(1.1200 AS Decimal(12, 4)))
GO
INSERT [dbo].[FACTURA] ([IDFACTURA], [IDCLIENTE], [FECHA], [SUBTOTAL], [IVA], [TOTAL]) VALUES (11, 1, CAST(N'2024-02-07T00:00:00.000' AS DateTime), CAST(7.3000 AS Decimal(12, 4)), CAST(12.00 AS Decimal(5, 2)), CAST(8.1800 AS Decimal(12, 4)))
GO
INSERT [dbo].[FACTURA] ([IDFACTURA], [IDCLIENTE], [FECHA], [SUBTOTAL], [IVA], [TOTAL]) VALUES (21, 5, CAST(N'2024-03-10T00:00:00.000' AS DateTime), CAST(3.3000 AS Decimal(12, 4)), CAST(18.00 AS Decimal(5, 2)), CAST(3.8900 AS Decimal(12, 4)))
GO
INSERT [dbo].[FACTURA] ([IDFACTURA], [IDCLIENTE], [FECHA], [SUBTOTAL], [IVA], [TOTAL]) VALUES (24, 2, CAST(N'2024-03-10T00:00:00.000' AS DateTime), CAST(1.1000 AS Decimal(12, 4)), CAST(18.00 AS Decimal(5, 2)), CAST(1.3000 AS Decimal(12, 4)))
GO
INSERT [dbo].[FACTURA] ([IDFACTURA], [IDCLIENTE], [FECHA], [SUBTOTAL], [IVA], [TOTAL]) VALUES (35, 2, CAST(N'2024-03-10T00:00:00.000' AS DateTime), CAST(7850.2200 AS Decimal(12, 4)), CAST(14.00 AS Decimal(5, 2)), CAST(8949.2500 AS Decimal(12, 4)))
GO
SET IDENTITY_INSERT [dbo].[FACTURA] OFF
GO
SET IDENTITY_INSERT [dbo].[IVA] ON 
GO
INSERT [dbo].[IVA] ([ID_IVA], [ValorIVA], [FechaInicio], [FechaFinal], [Estado]) VALUES (1, CAST(12.00 AS Decimal(5, 2)), CAST(N'2024-03-03' AS Date), CAST(N'2024-03-04' AS Date), 0)
GO
INSERT [dbo].[IVA] ([ID_IVA], [ValorIVA], [FechaInicio], [FechaFinal], [Estado]) VALUES (2, CAST(16.10 AS Decimal(5, 2)), CAST(N'2024-03-03' AS Date), CAST(N'2024-03-04' AS Date), 0)
GO
INSERT [dbo].[IVA] ([ID_IVA], [ValorIVA], [FechaInicio], [FechaFinal], [Estado]) VALUES (3, CAST(16.00 AS Decimal(5, 2)), CAST(N'2024-03-03' AS Date), CAST(N'2024-03-14' AS Date), 0)
GO
INSERT [dbo].[IVA] ([ID_IVA], [ValorIVA], [FechaInicio], [FechaFinal], [Estado]) VALUES (4, CAST(20.00 AS Decimal(5, 2)), CAST(N'2024-03-03' AS Date), CAST(N'2024-03-06' AS Date), 0)
GO
INSERT [dbo].[IVA] ([ID_IVA], [ValorIVA], [FechaInicio], [FechaFinal], [Estado]) VALUES (5, CAST(18.00 AS Decimal(5, 2)), CAST(N'2024-03-06' AS Date), CAST(N'2024-03-10' AS Date), 0)
GO
INSERT [dbo].[IVA] ([ID_IVA], [ValorIVA], [FechaInicio], [FechaFinal], [Estado]) VALUES (6, CAST(25.00 AS Decimal(5, 2)), CAST(N'2024-03-07' AS Date), CAST(N'2024-03-07' AS Date), 0)
GO
INSERT [dbo].[IVA] ([ID_IVA], [ValorIVA], [FechaInicio], [FechaFinal], [Estado]) VALUES (7, CAST(55.00 AS Decimal(5, 2)), CAST(N'2024-03-10' AS Date), CAST(N'2024-03-11' AS Date), 0)
GO
INSERT [dbo].[IVA] ([ID_IVA], [ValorIVA], [FechaInicio], [FechaFinal], [Estado]) VALUES (8, CAST(25.00 AS Decimal(5, 2)), CAST(N'2024-03-10' AS Date), CAST(N'2024-03-11' AS Date), 0)
GO
INSERT [dbo].[IVA] ([ID_IVA], [ValorIVA], [FechaInicio], [FechaFinal], [Estado]) VALUES (9, CAST(25.00 AS Decimal(5, 2)), CAST(N'2024-03-10' AS Date), CAST(N'2024-03-10' AS Date), 0)
GO
INSERT [dbo].[IVA] ([ID_IVA], [ValorIVA], [FechaInicio], [FechaFinal], [Estado]) VALUES (10, CAST(14.00 AS Decimal(5, 2)), CAST(N'2024-03-10' AS Date), CAST(N'2024-03-10' AS Date), 1)
GO
INSERT [dbo].[IVA] ([ID_IVA], [ValorIVA], [FechaInicio], [FechaFinal], [Estado]) VALUES (11, CAST(25.00 AS Decimal(5, 2)), CAST(N'2024-03-11' AS Date), CAST(N'2024-03-12' AS Date), 0)
GO
SET IDENTITY_INSERT [dbo].[IVA] OFF
GO
SET IDENTITY_INSERT [dbo].[PRODUCTO] ON 
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (1, N'Aceite Favorita               ', CAST(1.10 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (2, N'Jabon de Lavar Plato Lavatodo ', CAST(0.80 AS Decimal(10, 2)), CAST(136.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (3, N'coca cola                     ', CAST(1.20 AS Decimal(10, 2)), CAST(98.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (4, N'Cola                          ', CAST(1.10 AS Decimal(10, 2)), CAST(29.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (5, N'Leche                         ', CAST(1.25 AS Decimal(10, 2)), CAST(99.25 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (6, N'Deja                          ', CAST(1.00 AS Decimal(10, 2)), CAST(10.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (7, N'atun                          ', CAST(1.00 AS Decimal(10, 2)), CAST(10.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (8, N'Pork - Backs - Boneless       ', CAST(317.72 AS Decimal(10, 2)), CAST(268.25 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (9, N'Wine - Placido Pinot Grigo    ', CAST(372.13 AS Decimal(10, 2)), CAST(758.44 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (10, N'Cheese - Gouda                ', CAST(487.86 AS Decimal(10, 2)), CAST(357.50 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (11, N'Chicken - Leg, Fresh          ', CAST(832.56 AS Decimal(10, 2)), CAST(781.62 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (12, N'Pastrami                      ', CAST(752.65 AS Decimal(10, 2)), CAST(618.28 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (13, N'Ginger - Fresh                ', CAST(664.92 AS Decimal(10, 2)), CAST(973.28 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (14, N'Pasta - Penne, Rigate, Dry    ', CAST(270.90 AS Decimal(10, 2)), CAST(743.36 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (15, N'Nori Sea Weed - Gold Label    ', CAST(545.52 AS Decimal(10, 2)), CAST(502.77 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (16, N'Chutney Sauce                 ', CAST(568.84 AS Decimal(10, 2)), CAST(794.49 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (17, N'Plasticknivesblack            ', CAST(998.54 AS Decimal(10, 2)), CAST(859.78 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (18, N'Sauce - Chili                 ', CAST(701.96 AS Decimal(10, 2)), CAST(419.28 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (19, N'Guava                         ', CAST(619.53 AS Decimal(10, 2)), CAST(503.53 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (20, N'Wine - Red, Gallo, Merlot     ', CAST(195.83 AS Decimal(10, 2)), CAST(597.62 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (21, N'Tomato - Green                ', CAST(836.43 AS Decimal(10, 2)), CAST(973.16 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (22, N'Sugar - Palm                  ', CAST(794.77 AS Decimal(10, 2)), CAST(342.07 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (23, N'Marjoram - Fresh              ', CAST(654.40 AS Decimal(10, 2)), CAST(830.83 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (24, N'Oats Large Flake              ', CAST(115.57 AS Decimal(10, 2)), CAST(815.11 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (25, N'Shrimp - 150 - 250            ', CAST(812.35 AS Decimal(10, 2)), CAST(956.90 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (26, N'Pumpkin - Seed                ', CAST(856.24 AS Decimal(10, 2)), CAST(77.01 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (27, N'Tea - Herbal - 6 Asst         ', CAST(809.23 AS Decimal(10, 2)), CAST(466.72 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (28, N'Mix - Cappucino Cocktail      ', CAST(666.55 AS Decimal(10, 2)), CAST(904.45 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (29, N'Nut - Almond, Blanched, Ground', CAST(925.26 AS Decimal(10, 2)), CAST(37.77 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (30, N'Gatorade - Lemon Lime         ', CAST(167.77 AS Decimal(10, 2)), CAST(46.73 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (32, N'Beef - Ground Medium          ', CAST(202.67 AS Decimal(10, 2)), CAST(987.78 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (33, N'Puff Pastry - Slab            ', CAST(807.26 AS Decimal(10, 2)), CAST(823.90 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (34, N'Soup - Campbells, Beef Barley ', CAST(338.12 AS Decimal(10, 2)), CAST(665.92 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (35, N'Bagel - 12 Grain Preslice     ', CAST(520.45 AS Decimal(10, 2)), CAST(808.48 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (36, N'Lemonade - Natural, 591 Ml    ', CAST(16.51 AS Decimal(10, 2)), CAST(205.28 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (37, N'Glycerine                     ', CAST(449.79 AS Decimal(10, 2)), CAST(430.23 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (38, N'Shrimp - Black Tiger 16/20    ', CAST(266.34 AS Decimal(10, 2)), CAST(251.24 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (39, N'Bread Cranberry Foccacia      ', CAST(109.57 AS Decimal(10, 2)), CAST(145.40 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (40, N'Bread - Granary Small Pull    ', CAST(439.07 AS Decimal(10, 2)), CAST(775.46 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (41, N'Chicken - Whole Fryers        ', CAST(324.32 AS Decimal(10, 2)), CAST(672.40 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (42, N'Walkers Special Old Whiskey   ', CAST(992.42 AS Decimal(10, 2)), CAST(414.76 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (44, N'Tomatoes Tear Drop Yellow     ', CAST(433.38 AS Decimal(10, 2)), CAST(290.18 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (45, N'Shrimp - Prawn                ', CAST(374.12 AS Decimal(10, 2)), CAST(439.20 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (46, N'Mushroom - Lg - Cello         ', CAST(33.28 AS Decimal(10, 2)), CAST(230.25 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (47, N'Cookie - Oatmeal              ', CAST(298.38 AS Decimal(10, 2)), CAST(594.72 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (48, N'Soup - Campbells Pasta Fagioli', CAST(57.09 AS Decimal(10, 2)), CAST(663.24 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (49, N'Beef - Kobe Striploin         ', CAST(870.03 AS Decimal(10, 2)), CAST(553.29 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (50, N'Bar Mix - Lime                ', CAST(883.59 AS Decimal(10, 2)), CAST(811.68 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (51, N'Smirnoff Green Apple Twist    ', CAST(924.32 AS Decimal(10, 2)), CAST(165.73 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (52, N'Cheese Cloth No 60            ', CAST(611.48 AS Decimal(10, 2)), CAST(472.92 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (53, N'Spice - Peppercorn Melange    ', CAST(663.60 AS Decimal(10, 2)), CAST(546.08 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (54, N'Wine - Marlbourough Sauv Blanc', CAST(812.18 AS Decimal(10, 2)), CAST(947.21 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (55, N'Tamarind Paste                ', CAST(335.36 AS Decimal(10, 2)), CAST(690.84 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (56, N'Butter - Pod                  ', CAST(945.59 AS Decimal(10, 2)), CAST(776.75 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (57, N'Ketchup - Tomato              ', CAST(767.53 AS Decimal(10, 2)), CAST(759.04 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (58, N'Scallops - U - 10             ', CAST(400.12 AS Decimal(10, 2)), CAST(300.62 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (59, N'Raspberries - Fresh           ', CAST(940.10 AS Decimal(10, 2)), CAST(448.85 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (60, N'Shopper Bag - S - 4           ', CAST(400.62 AS Decimal(10, 2)), CAST(861.57 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (61, N'Cookies Almond Hazelnut       ', CAST(55.63 AS Decimal(10, 2)), CAST(551.50 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (62, N'Veal - Shank, Pieces          ', CAST(964.86 AS Decimal(10, 2)), CAST(348.09 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (63, N'Coconut - Shredded, Unsweet   ', CAST(476.48 AS Decimal(10, 2)), CAST(70.62 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (64, N'Vol Au Vents                  ', CAST(478.34 AS Decimal(10, 2)), CAST(857.51 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (65, N'Bread - Raisin                ', CAST(534.77 AS Decimal(10, 2)), CAST(435.25 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (66, N'Tuna - Sushi Grade            ', CAST(417.03 AS Decimal(10, 2)), CAST(466.90 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (67, N'Mop Head - Cotton, 24 Oz      ', CAST(288.75 AS Decimal(10, 2)), CAST(190.48 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (69, N'Puree - Kiwi                  ', CAST(806.26 AS Decimal(10, 2)), CAST(53.59 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (70, N'Coke - Diet, 355 Ml           ', CAST(326.20 AS Decimal(10, 2)), CAST(878.20 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (71, N'Pie Filling - Pumpkin         ', CAST(181.50 AS Decimal(10, 2)), CAST(667.66 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (72, N'Tea - Decaf Lipton            ', CAST(31.53 AS Decimal(10, 2)), CAST(678.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (73, N'Buttons                       ', CAST(84.73 AS Decimal(10, 2)), CAST(762.32 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (74, N'Pork Casing                   ', CAST(927.58 AS Decimal(10, 2)), CAST(154.03 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (75, N'Wine - Black Tower Qr         ', CAST(84.00 AS Decimal(10, 2)), CAST(971.68 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (76, N'Table Cloth 90x90 Colour      ', CAST(14.72 AS Decimal(10, 2)), CAST(720.26 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (77, N'Orange Roughy 4/6 Oz          ', CAST(892.64 AS Decimal(10, 2)), CAST(712.79 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (78, N'Petite Baguette               ', CAST(605.38 AS Decimal(10, 2)), CAST(505.79 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (79, N'Appetizer - Southwestern      ', CAST(219.76 AS Decimal(10, 2)), CAST(167.51 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (80, N'Beer - Pilsner Urquell        ', CAST(755.56 AS Decimal(10, 2)), CAST(416.76 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (81, N'Eggplant - Baby               ', CAST(56.17 AS Decimal(10, 2)), CAST(509.41 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (83, N'Muffin Mix - Carrot           ', CAST(898.54 AS Decimal(10, 2)), CAST(688.82 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (84, N'Banana                        ', CAST(288.45 AS Decimal(10, 2)), CAST(490.97 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (85, N'Chicken - Bones               ', CAST(566.68 AS Decimal(10, 2)), CAST(120.75 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (86, N'Cherries - Maraschino,jar     ', CAST(685.58 AS Decimal(10, 2)), CAST(121.95 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (87, N'Wine - Redchard Merritt       ', CAST(156.83 AS Decimal(10, 2)), CAST(603.31 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (88, N'Rice - Brown                  ', CAST(446.38 AS Decimal(10, 2)), CAST(389.01 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (90, N'Sunflower Seed Raw            ', CAST(425.83 AS Decimal(10, 2)), CAST(473.99 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (92, N'Cheese - Blue                 ', CAST(208.36 AS Decimal(10, 2)), CAST(201.89 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (93, N'Pastry - Lemon Danish - Mini  ', CAST(128.98 AS Decimal(10, 2)), CAST(493.96 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (94, N'Lamb Rack - Ontario           ', CAST(635.67 AS Decimal(10, 2)), CAST(401.23 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (95, N'Soup - Cream Of Broccoli, Dry ', CAST(847.31 AS Decimal(10, 2)), CAST(233.31 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (96, N'Piping - Bags Quizna          ', CAST(546.52 AS Decimal(10, 2)), CAST(908.83 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (97, N'Island Oasis - Ice Cream Mix  ', CAST(612.41 AS Decimal(10, 2)), CAST(352.32 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (98, N'Apple - Granny Smith          ', CAST(882.42 AS Decimal(10, 2)), CAST(257.82 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (99, N'Bread - Pita, Mini            ', CAST(300.99 AS Decimal(10, 2)), CAST(447.68 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (100, N'Beer - Molson Excel           ', CAST(284.02 AS Decimal(10, 2)), CAST(86.90 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (101, N'Loquat                        ', CAST(132.18 AS Decimal(10, 2)), CAST(231.87 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (102, N'Whmis - Spray Bottle Trigger  ', CAST(912.78 AS Decimal(10, 2)), CAST(553.75 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (103, N'Pastry - Banana Tea Loaf      ', CAST(196.31 AS Decimal(10, 2)), CAST(358.40 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (104, N'Beans - Fava, Canned          ', CAST(557.87 AS Decimal(10, 2)), CAST(752.35 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (105, N'Soup Campbells Beef With Veg  ', CAST(279.60 AS Decimal(10, 2)), CAST(799.96 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (106, N'Sweet Pea Sprouts             ', CAST(806.29 AS Decimal(10, 2)), CAST(646.50 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (107, N'Sage Ground Wiberg            ', CAST(172.74 AS Decimal(10, 2)), CAST(472.30 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (108, N'Pumpkin - Seed                ', CAST(705.68 AS Decimal(10, 2)), CAST(656.38 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (109, N'Muffin Puck Ww Carrot         ', CAST(169.90 AS Decimal(10, 2)), CAST(126.31 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (111, N'Wine - White, Colubia Cresh   ', CAST(27.07 AS Decimal(10, 2)), CAST(664.52 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (112, N'Loaf Pan - 2 Lb, Foil         ', CAST(31.76 AS Decimal(10, 2)), CAST(228.91 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (113, N'Pumpkin                       ', CAST(345.97 AS Decimal(10, 2)), CAST(221.29 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (114, N'Guava                         ', CAST(422.36 AS Decimal(10, 2)), CAST(810.05 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (115, N'Cup - 3.5oz, Foam             ', CAST(627.64 AS Decimal(10, 2)), CAST(861.04 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (116, N'Canadian Emmenthal            ', CAST(221.39 AS Decimal(10, 2)), CAST(857.19 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (117, N'Stock - Veal, Brown           ', CAST(655.94 AS Decimal(10, 2)), CAST(701.15 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (118, N'Beans - Wax                   ', CAST(340.24 AS Decimal(10, 2)), CAST(247.05 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (119, N'Creme De Menth - White        ', CAST(643.22 AS Decimal(10, 2)), CAST(706.34 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (120, N'Lamb - Leg, Diced             ', CAST(234.98 AS Decimal(10, 2)), CAST(239.89 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (121, N'Flour - Semolina              ', CAST(15.76 AS Decimal(10, 2)), CAST(360.21 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (122, N'Trueblue - Blueberry          ', CAST(61.88 AS Decimal(10, 2)), CAST(692.36 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (123, N'Broom Handle                  ', CAST(549.62 AS Decimal(10, 2)), CAST(509.87 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (124, N'Apple - Granny Smith          ', CAST(210.44 AS Decimal(10, 2)), CAST(553.99 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (125, N'Yokaline                      ', CAST(366.89 AS Decimal(10, 2)), CAST(346.30 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (126, N'Kahlua                        ', CAST(935.95 AS Decimal(10, 2)), CAST(108.86 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (127, N'Water - Evian 355 Ml          ', CAST(146.90 AS Decimal(10, 2)), CAST(937.93 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (128, N'Vacuum Bags 12x16             ', CAST(526.01 AS Decimal(10, 2)), CAST(116.51 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (129, N'Muffin Puck Ww Carrot         ', CAST(307.57 AS Decimal(10, 2)), CAST(523.84 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (130, N'Apple - Delicious, Red        ', CAST(974.73 AS Decimal(10, 2)), CAST(734.74 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (131, N'Nut - Pistachio, Shelled      ', CAST(178.89 AS Decimal(10, 2)), CAST(999.81 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (132, N'Flower - Daisies              ', CAST(544.70 AS Decimal(10, 2)), CAST(688.53 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (133, N'Foam Cup 6 Oz                 ', CAST(335.18 AS Decimal(10, 2)), CAST(232.56 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (134, N'Wine - Two Oceans Sauvignon   ', CAST(780.56 AS Decimal(10, 2)), CAST(499.71 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (135, N'Carbonated Water - Strawberry ', CAST(318.83 AS Decimal(10, 2)), CAST(171.43 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (136, N'Bacardi Raspberry             ', CAST(434.11 AS Decimal(10, 2)), CAST(653.98 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (137, N'Mace                          ', CAST(67.95 AS Decimal(10, 2)), CAST(836.76 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (138, N'Beans - Black Bean, Dry       ', CAST(797.38 AS Decimal(10, 2)), CAST(788.09 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (139, N'Cheese - Brick With Pepper    ', CAST(267.19 AS Decimal(10, 2)), CAST(109.27 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (140, N'Mints - Striped Red           ', CAST(471.25 AS Decimal(10, 2)), CAST(334.57 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (141, N'Fennel - Seeds                ', CAST(617.44 AS Decimal(10, 2)), CAST(910.14 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (142, N'Beer - Pilsner Urquell        ', CAST(979.22 AS Decimal(10, 2)), CAST(973.74 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (143, N'Pear - Asian                  ', CAST(823.30 AS Decimal(10, 2)), CAST(429.35 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (144, N'Veal Inside - Provimi         ', CAST(895.31 AS Decimal(10, 2)), CAST(700.73 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (145, N'Spring Roll Wrappers          ', CAST(763.95 AS Decimal(10, 2)), CAST(702.08 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (146, N'Pepper - Green                ', CAST(957.47 AS Decimal(10, 2)), CAST(526.48 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (147, N'Pasta - Penne, Lisce, Dry     ', CAST(749.61 AS Decimal(10, 2)), CAST(48.27 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (148, N'Icecream - Dibs               ', CAST(767.85 AS Decimal(10, 2)), CAST(567.68 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (149, N'Coffee Caramel Biscotti       ', CAST(726.09 AS Decimal(10, 2)), CAST(371.33 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (150, N'Pork - Bacon Cooked Slcd      ', CAST(631.13 AS Decimal(10, 2)), CAST(176.41 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (151, N'Lettuce Romaine Chopped       ', CAST(411.01 AS Decimal(10, 2)), CAST(712.86 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (152, N'Muffin Puck Ww Carrot         ', CAST(767.57 AS Decimal(10, 2)), CAST(778.68 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (153, N'Asparagus - White, Fresh      ', CAST(777.85 AS Decimal(10, 2)), CAST(340.57 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (154, N'Papayas                       ', CAST(88.79 AS Decimal(10, 2)), CAST(393.61 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (155, N'Gelatine Leaves - Envelopes   ', CAST(946.74 AS Decimal(10, 2)), CAST(910.34 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (156, N'Tequila Rose Cream Liquor     ', CAST(69.91 AS Decimal(10, 2)), CAST(243.08 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (157, N'Daikon Radish                 ', CAST(737.61 AS Decimal(10, 2)), CAST(870.41 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (158, N'Flower - Carnations           ', CAST(756.98 AS Decimal(10, 2)), CAST(726.83 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (159, N'Shrimp - 100 / 200 Cold Water ', CAST(302.83 AS Decimal(10, 2)), CAST(9.56 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (160, N'Foil - Round Foil             ', CAST(310.82 AS Decimal(10, 2)), CAST(245.08 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (161, N'Tomato - Peeled Italian Canned', CAST(138.85 AS Decimal(10, 2)), CAST(553.24 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (162, N'Crab Brie In Phyllo           ', CAST(563.97 AS Decimal(10, 2)), CAST(67.93 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (163, N'Dawn Professionl Pot And Pan  ', CAST(606.02 AS Decimal(10, 2)), CAST(538.93 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (164, N'Cleaner - Pine Sol            ', CAST(80.77 AS Decimal(10, 2)), CAST(950.22 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (165, N'Napkin - Dinner, White        ', CAST(333.58 AS Decimal(10, 2)), CAST(492.28 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (166, N'Mace Ground                   ', CAST(843.87 AS Decimal(10, 2)), CAST(423.54 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (167, N'Carroway Seed                 ', CAST(652.51 AS Decimal(10, 2)), CAST(921.25 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (168, N'Sauce - Fish 25 Ozf Bottle    ', CAST(749.54 AS Decimal(10, 2)), CAST(95.39 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (169, N'Soup - French Onion, Dry      ', CAST(459.51 AS Decimal(10, 2)), CAST(27.12 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (170, N'Bagel - Everything Presliced  ', CAST(543.23 AS Decimal(10, 2)), CAST(952.17 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (171, N'Wine - Balbach Riverside      ', CAST(735.33 AS Decimal(10, 2)), CAST(409.49 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (172, N'Wine - Peller Estates Late    ', CAST(12.64 AS Decimal(10, 2)), CAST(305.87 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (173, N'Bread Country Roll            ', CAST(149.09 AS Decimal(10, 2)), CAST(325.96 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (174, N'Milk - Skim                   ', CAST(9.82 AS Decimal(10, 2)), CAST(204.96 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (175, N'Salt - Seasoned               ', CAST(905.49 AS Decimal(10, 2)), CAST(422.68 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (176, N'Soup - Base Broth Chix        ', CAST(840.11 AS Decimal(10, 2)), CAST(37.51 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (177, N'Oysters - Smoked              ', CAST(553.20 AS Decimal(10, 2)), CAST(402.37 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (178, N'Sole - Dover, Whole, Fresh    ', CAST(109.60 AS Decimal(10, 2)), CAST(718.59 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (179, N'Daves Island Stinger          ', CAST(52.85 AS Decimal(10, 2)), CAST(611.42 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (180, N'Snapple - Iced Tea Peach      ', CAST(709.73 AS Decimal(10, 2)), CAST(761.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (181, N'Danishes - Mini Raspberry     ', CAST(895.70 AS Decimal(10, 2)), CAST(538.71 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (182, N'Sole - Dover, Whole, Fresh    ', CAST(726.58 AS Decimal(10, 2)), CAST(681.50 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (183, N'Island Oasis - Peach Daiquiri ', CAST(604.56 AS Decimal(10, 2)), CAST(657.99 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (184, N'Squash - Butternut            ', CAST(259.37 AS Decimal(10, 2)), CAST(804.15 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (185, N'Spice - Greek 1 Step          ', CAST(344.94 AS Decimal(10, 2)), CAST(233.85 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (186, N'Juice - Orange, Concentrate   ', CAST(657.12 AS Decimal(10, 2)), CAST(4.24 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (187, N'Chambord Royal                ', CAST(104.05 AS Decimal(10, 2)), CAST(517.01 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (188, N'Pepsi - 600ml                 ', CAST(348.73 AS Decimal(10, 2)), CAST(547.66 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (189, N'Truffle Paste                 ', CAST(219.84 AS Decimal(10, 2)), CAST(879.45 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (190, N'Persimmons                    ', CAST(896.74 AS Decimal(10, 2)), CAST(818.35 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (191, N'Tart Shells - Savory, 4       ', CAST(708.49 AS Decimal(10, 2)), CAST(456.84 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (192, N'Asparagus - Frozen            ', CAST(508.29 AS Decimal(10, 2)), CAST(521.11 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (193, N'Turnip - Wax                  ', CAST(89.20 AS Decimal(10, 2)), CAST(822.63 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (194, N'Butter - Pod                  ', CAST(33.19 AS Decimal(10, 2)), CAST(678.72 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (195, N'Cloves - Ground               ', CAST(637.26 AS Decimal(10, 2)), CAST(999.19 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (196, N'Chocolate - Unsweetened       ', CAST(328.66 AS Decimal(10, 2)), CAST(358.20 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (197, N'Food Colouring - Red          ', CAST(763.24 AS Decimal(10, 2)), CAST(990.93 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (198, N'Crab - Meat                   ', CAST(590.06 AS Decimal(10, 2)), CAST(611.40 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (199, N'Chinese Foods - Chicken       ', CAST(441.38 AS Decimal(10, 2)), CAST(463.64 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[PRODUCTO] ([IDPRODUCTO], [PRODUCTO], [PRECIO_UNITARIO], [STOCK], [ESTADO]) VALUES (200, N'Cheese - Manchego, Spanish    ', CAST(886.33 AS Decimal(10, 2)), CAST(16.05 AS Decimal(10, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[PRODUCTO] OFF
GO
ALTER TABLE [dbo].[DETALLE_FACTURA]  WITH CHECK ADD  CONSTRAINT [FK_DETALLE__RELATIONS_FACTURA] FOREIGN KEY([IDFACTURA])
REFERENCES [dbo].[FACTURA] ([IDFACTURA])
GO
ALTER TABLE [dbo].[DETALLE_FACTURA] CHECK CONSTRAINT [FK_DETALLE__RELATIONS_FACTURA]
GO
ALTER TABLE [dbo].[DETALLE_FACTURA]  WITH CHECK ADD  CONSTRAINT [FK_DETALLE__RELATIONS_PRODUCTO] FOREIGN KEY([IDPRODUCTO])
REFERENCES [dbo].[PRODUCTO] ([IDPRODUCTO])
GO
ALTER TABLE [dbo].[DETALLE_FACTURA] CHECK CONSTRAINT [FK_DETALLE__RELATIONS_PRODUCTO]
GO
ALTER TABLE [dbo].[FACTURA]  WITH CHECK ADD  CONSTRAINT [FK_FACTURA_RELATIONS_CLIENTE] FOREIGN KEY([IDCLIENTE])
REFERENCES [dbo].[CLIENTE] ([IDCLIENTE])
GO
ALTER TABLE [dbo].[FACTURA] CHECK CONSTRAINT [FK_FACTURA_RELATIONS_CLIENTE]
GO
ALTER TABLE [dbo].[IVA]  WITH CHECK ADD  CONSTRAINT [CHK_FechaValida] CHECK  (([FechaInicio]<=[FechaFinal]))
GO
ALTER TABLE [dbo].[IVA] CHECK CONSTRAINT [CHK_FechaValida]
GO
/****** Object:  StoredProcedure [dbo].[BuscarClientes]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BuscarClientes]
	-- Add the parameters for the stored procedure here
	-- Add the parameters for the stored procedure here
    @Campo VARCHAR(20), -- Nombre del campo por el cual buscar
    @Buscar VARCHAR(20) -- Valor a buscar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @sql NVARCHAR(MAX);
    SET @sql = N'SELECT IDCLIENTE AS ID, RTRIM(CEDULA) AS Cedula, RTRIM(NOMBRE) AS Nombre, 
	RTRIM(APELLIDOS) AS Apellido, FECHA_NACIMIENTO AS ''Fecha Nacimiento''
	FROM CLIENTE 
	WHERE Estado = 1 AND' + QUOTENAME(@Campo) + ' LIKE @Valor + ''%''';

    EXEC sp_executesql @sql, N'@Valor NVARCHAR(20)', @Buscar;
END
GO
/****** Object:  StoredProcedure [dbo].[BuscarProductos]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BuscarProductos]
	-- Add the parameters for the stored procedure here
	-- Add the parameters for the stored procedure here
    @Campo VARCHAR(20), -- Nombre del campo por el cual buscar
    @Buscar VARCHAR(20) -- Valor a buscar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @sql NVARCHAR(MAX);
    SET @sql = N'select IDPRODUCTO, RTRIM(PRODUCTO) as PRODUCTO, RTRIM(PRECIO_UNITARIO) AS PRECIO_UNITARIO, RTRIM(STOCK) AS STOCK 
	FROM PRODUCTO 
	WHERE Estado = 1 AND' + QUOTENAME(@Campo) + ' LIKE @Valor + ''%''';

    EXEC sp_executesql @sql, N'@Valor NVARCHAR(20)', @Buscar;
END
GO
/****** Object:  StoredProcedure [dbo].[EditarIVA]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditarIVA]
    @ID_IVA INT,
    @ValorIVA DECIMAL(5,2),
    @FechaInicio DATE,
    @FechaFinal DATE
AS
BEGIN
    UPDATE IVA
    SET
        ValorIVA = @ValorIVA,
        FechaInicio = @FechaInicio,
        FechaFinal = @FechaFinal, Estado=1
    WHERE ID_IVA = @ID_IVA;
END;
GO
/****** Object:  StoredProcedure [dbo].[InactivarIVA]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InactivarIVA]
    @ID_IVA INT
AS
BEGIN
    UPDATE IVA
    SET Estado = 0
    WHERE ID_IVA = @ID_IVA;
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarIVA]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarIVA]
    @ValorIVA DECIMAL(5,2),
    @FechaInicio DATE,
    @FechaFinal DATE
AS
BEGIN
    INSERT INTO IVA (ValorIVA, FechaInicio, FechaFinal, Estado)
    VALUES (@ValorIVA, @FechaInicio, @FechaFinal, 1);
END;
GO
/****** Object:  StoredProcedure [dbo].[LeerProductoVacio]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LeerProductoVacio]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select IDPRODUCTO, RTRIM(PRODUCTO) as PRODUCTO,RTRIM(PRECIO_UNITARIO) AS PRECIO_UNITARIO, RTRIM(STOCK) AS STOCK 
	from PRODUCTO WHERE Estado = 1 and IDPRODUCTO ='00000000000'
END
GO
/****** Object:  StoredProcedure [dbo].[SeleccionarIVAActual]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SeleccionarIVAActual]
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @FechaActual DATE = GETDATE(); -- Obtener la fecha actual

    -- Seleccionar el valor del IVA correspondiente a la fecha actual
    SELECT ValorIVA
    FROM IVA
    WHERE FechaInicio <= @FechaActual AND (FechaInicio IS NULL OR FechaFinal >= @FechaActual) and Estado=1;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_actualizar_CLIENTE]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------actualizar------------------------------
CREATE PROCEDURE [dbo].[sp_actualizar_CLIENTE]
@IDCLIENTE varchar(10), @Cedula varchar(10), @Nombre varchar(50), @Apellido varchar(20), @Fecha_Nac varchar(20)
AS
BEGIN
BEGIN TRY		
	UPDATE CLIENTE SET CEDULA = @Cedula, NOMBRE = @Nombre, APELLIDOS = @Apellido, FECHA_NACIMIENTO = @Fecha_Nac WHERE IDCLIENTE = @IDCLIENTE
	END TRY
	BEGIN CATCH
		PRINT 'Error ' + ERROR_MESSAGE();
	END CATCH
END
------------------------------------------------------------------------------------------------------------------------------------------------------------
/****** Object:  StoredProcedure [dbo].[sp_Eliminar_CLIENTE]    Script Date: 26/12/2023 20:15:13 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_actualizar_PRODUCTO]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_actualizar_PRODUCTO]
@idproducto int, @producto char(30), @precio_unitario decimal(10,2), @stock decimal(10,2)
AS
BEGIN
BEGIN TRY		
	UPDATE PRODUCTO SET PRODUCTO = @producto, PRECIO_UNITARIO=@precio_unitario, STOCK=@stock
	WHERE IDPRODUCTO = @idproducto
	END TRY
	BEGIN CATCH
		PRINT 'Error ' + ERROR_MESSAGE();
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Buscar_Clientes]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----------------------------------------------------------

CREATE PROCEDURE [dbo].[sp_Buscar_Clientes]
@Buscar varchar(20)
AS
BEGIN
BEGIN TRY		
	SELECT IDCLIENTE AS ID,
       RTRIM(CEDULA) AS Cedula,
       RTRIM(NOMBRE) AS Nombre,
       RTRIM(APELLIDOS) AS Apellido,
       FECHA_NACIMIENTO AS 'Fecha Nacimiento',
       CASE Estado WHEN 0 THEN 'Eliminado' WHEN 1 THEN 'Activo' END AS Estado
	FROM CLIENTE
	WHERE Estado = 1 AND (
            CEDULA LIKE '%' + @Buscar + '%' OR
            NOMBRE LIKE '%' + @Buscar + '%' OR
            APELLIDOS LIKE '%' + @Buscar + '%'
        );
	END TRY
	BEGIN CATCH
		PRINT 'Error ' + ERROR_MESSAGE();
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarFacturas]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sp_BuscarFacturas]
    @Cedula CHAR(10) = NULL,
    @NumeroFactura INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT F.IDFACTURA, C.CEDULA, C.NOMBRE, C.APELLIDOS, F.FECHA
    FROM FACTURA F
    INNER JOIN CLIENTE C ON F.IDCLIENTE = C.IDCLIENTE
    WHERE
        (@Cedula IS NULL OR C.CEDULA = @Cedula)
        AND
        (@NumeroFactura IS NULL OR F.IDFACTURA = @NumeroFactura);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarIVA]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_BuscarIVA]
	-- Add the parameters for the stored procedure here
	-- Add the parameters for the stored procedure here
    @Campo VARCHAR(20), -- Nombre del campo por el cual buscar
    @Buscar VARCHAR(20) -- Valor a buscar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @sql NVARCHAR(MAX);
    SET @sql = N'select ID_IVA as ''ID IVA'', RTRIM(ValorIVA) as ''Valor IVA'', FechaInicio as ''Fecha Inicio'', 
	FechaFinal as ''Fecha Final'' 
	from IVA
	WHERE Estado = 1 AND' + QUOTENAME(@Campo) + ' LIKE @Valor + ''%''';

    EXEC sp_executesql @sql, N'@Valor NVARCHAR(20)', @Buscar;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarIVAxFecha]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_BuscarIVAxFecha]
	-- Add the parameters for the stored procedure here
	@Fecha_Inicio date, -- fecha de inicio a buscar
    @Fecha_Fin date -- fecha de final a buscar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    DECLARE @sql NVARCHAR(MAX);
    SET @sql = N'select ID_IVA as ''ID IVA'', RTRIM(ValorIVA) as ''Valor IVA'', FechaInicio as ''Fecha Inicio'', 
	FechaFinal as ''Fecha Final'' 
	from IVA
	WHERE Estado = 1 AND FechaInicio = @Fecha_Inicio AND FechaFinal = @Fecha_Fin';

    EXEC sp_executesql @sql, N'@Fecha_Inicio DATE, @Fecha_Fin DATE', @Fecha_Inicio, @Fecha_Fin;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Delete_Client]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Delete_Client]
	-- Add the parameters for the stored procedure here
@idcliente int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE CLIENTE SET ESTADO = '0'
WHERE IDCLIENTE = @idcliente
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DetalladoVentasFechas]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DetalladoVentasFechas]
	-- Add the parameters for the stored procedure here
	@Fecha_Inicio date, -- fecha de inicio a buscar
    @Fecha_Fin date -- fecha de final a buscar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    DECLARE @sql NVARCHAR(MAX);
    SET @sql = N'select DF.IDFACTURA, CONVERT(varchar(10),F.FECHA,103) AS FECHA, C.CEDULA as Cédula, RTRIM(C.NOMBRE) + '' '' + RTRIM(C.APELLIDOS) as Nombres,
				RTRIM(P.PRODUCTO) AS ''NOMBRE PRODUCTO'', RTRIM(DF.CANTIDAD) AS CANTIDAD, RTRIM(DF.PRECIO_UNITARIO) AS PRECIO_UNITARIO, RTRIM(DF.SUBTOTAL) AS SUBTOTAL
                FROM CLIENTE AS C
                INNER JOIN FACTURA AS F ON C.IDCLIENTE = F.IDCLIENTE
                INNER JOIN DETALLE_FACTURA AS DF ON F.IDFACTURA = DF.IDFACTURA
                INNER JOIN PRODUCTO AS P ON DF.IDPRODUCTO = P.IDPRODUCTO
                WHERE  F.FECHA BETWEEN @Fecha_Inicio AND @Fecha_Fin
                GROUP BY DF.IDFACTURA, C.CEDULA, C.NOMBRE, C.APELLIDOS, F.FECHA, P.PRODUCTO,DF.CANTIDAD, DF.PRECIO_UNITARIO, DF.SUBTOTAL;';

    EXEC sp_executesql @sql, N'@Fecha_Inicio DATE, @Fecha_Fin DATE', @Fecha_Inicio, @Fecha_Fin;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DetalladoVentasFechasClientes]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DetalladoVentasFechasClientes]
	-- Add the parameters for the stored procedure here
	@Fecha_Inicio date, -- fecha de inicio a buscar
    @Fecha_Fin date, -- fecha de final a buscar
	@Campo VARCHAR(20), -- Nombre del campo por el cual buscar
    @Valor VARCHAR(20) -- Valor a buscar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    DECLARE @sql NVARCHAR(MAX);
    SET @sql = N'select DF.IDFACTURA, CONVERT(varchar(10),F.FECHA,103) AS FECHA, C.CEDULA as Cédula, RTRIM(C.NOMBRE) + '' '' + RTRIM(C.APELLIDOS) as Nombres,
				RTRIM(P.PRODUCTO) AS ''NOMBRE PRODUCTO'', RTRIM(DF.CANTIDAD) AS CANTIDAD, RTRIM(DF.PRECIO_UNITARIO) AS PRECIO_UNITARIO, RTRIM(DF.SUBTOTAL) AS SUBTOTAL
                FROM CLIENTE AS C
                INNER JOIN FACTURA AS F ON C.IDCLIENTE = F.IDCLIENTE
                INNER JOIN DETALLE_FACTURA AS DF ON F.IDFACTURA = DF.IDFACTURA
                INNER JOIN PRODUCTO AS P ON DF.IDPRODUCTO = P.IDPRODUCTO
                WHERE C.' + QUOTENAME(@Campo) + ' LIKE @Valor + ''%'' AND F.FECHA BETWEEN @Fecha_Inicio AND @Fecha_Fin
                GROUP BY DF.IDFACTURA, C.CEDULA, C.NOMBRE, C.APELLIDOS, F.FECHA, P.PRODUCTO,DF.CANTIDAD, DF.PRECIO_UNITARIO, DF.SUBTOTAL;';

    EXEC sp_executesql @sql, N'@Valor VARCHAR(20), @Fecha_Inicio DATE, @Fecha_Fin DATE', @Valor, @Fecha_Inicio, @Fecha_Fin;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DetalladoVentasFechasClientesProductos]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DetalladoVentasFechasClientesProductos]
	-- Add the parameters for the stored procedure here
	@Fecha_Inicio date, -- fecha de inicio a buscar
    @Fecha_Fin date, -- fecha de final a buscar
	@Campo VARCHAR(20), -- Nombre del campo por el cual buscar
	@Campo2 VARCHAR(20), -- Nombre del campo por el cual buscar
    @Valor VARCHAR(20), -- Valor a buscar
	@Valor2 VARCHAR(20) -- Valor a buscar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    DECLARE @sql NVARCHAR(MAX);
    SET @sql = N'select DF.IDFACTURA, CONVERT(varchar(10),F.FECHA,103) AS FECHA, C.CEDULA as Cédula, RTRIM(C.NOMBRE) + '' '' + RTRIM(C.APELLIDOS) as Nombres,
				RTRIM(P.PRODUCTO) AS ''NOMBRE PRODUCTO'', RTRIM(DF.CANTIDAD) AS CANTIDAD, RTRIM(DF.PRECIO_UNITARIO) AS PRECIO_UNITARIO, RTRIM(DF.SUBTOTAL) AS SUBTOTAL
                FROM CLIENTE AS C
                INNER JOIN FACTURA AS F ON C.IDCLIENTE = F.IDCLIENTE
                INNER JOIN DETALLE_FACTURA AS DF ON F.IDFACTURA = DF.IDFACTURA
                INNER JOIN PRODUCTO AS P ON DF.IDPRODUCTO = P.IDPRODUCTO
                WHERE C.' + QUOTENAME(@Campo) + ' LIKE @Valor + ''%'' AND P.' + QUOTENAME(@Campo2) + ' LIKE @Valor + ''%'' AND F.FECHA BETWEEN @Fecha_Inicio AND @Fecha_Fin
                GROUP BY DF.IDFACTURA, C.CEDULA, C.NOMBRE, C.APELLIDOS, F.FECHA, P.PRODUCTO,DF.CANTIDAD, DF.PRECIO_UNITARIO, DF.SUBTOTAL;';

    EXEC sp_executesql @sql, N'@Valor VARCHAR(20), @Valor2 VARCHAR(20),@Fecha_Inicio DATE, @Fecha_Fin DATE', @Valor, @Valor2, @Fecha_Inicio, @Fecha_Fin;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DetalladoVentasFechasProductos]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DetalladoVentasFechasProductos]
	-- Add the parameters for the stored procedure here
	@Fecha_Inicio date, -- fecha de inicio a buscar
    @Fecha_Fin date, -- fecha de final a buscar
	@Campo VARCHAR(20), -- Nombre del campo por el cual buscar
    @Valor VARCHAR(20) -- Valor a buscar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    DECLARE @sql NVARCHAR(MAX);
    SET @sql = N'select DF.IDFACTURA, CONVERT(varchar(10),F.FECHA,103) AS FECHA, C.CEDULA as Cédula, RTRIM(C.NOMBRE) + '' '' + RTRIM(C.APELLIDOS) as Nombres,
				RTRIM(P.PRODUCTO) AS ''NOMBRE PRODUCTO'', RTRIM(DF.CANTIDAD) AS CANTIDAD, RTRIM(DF.PRECIO_UNITARIO) AS PRECIO_UNITARIO, RTRIM(DF.SUBTOTAL) AS SUBTOTAL
                FROM CLIENTE AS C
                INNER JOIN FACTURA AS F ON C.IDCLIENTE = F.IDCLIENTE
                INNER JOIN DETALLE_FACTURA AS DF ON F.IDFACTURA = DF.IDFACTURA
                INNER JOIN PRODUCTO AS P ON DF.IDPRODUCTO = P.IDPRODUCTO
                WHERE P.' + QUOTENAME(@Campo) + ' LIKE @Valor + ''%'' AND F.FECHA BETWEEN @Fecha_Inicio AND @Fecha_Fin
                GROUP BY DF.IDFACTURA, C.CEDULA, C.NOMBRE, C.APELLIDOS, F.FECHA, P.PRODUCTO,DF.CANTIDAD, DF.PRECIO_UNITARIO, DF.SUBTOTAL;';

    EXEC sp_executesql @sql, N'@Valor VARCHAR(20), @Fecha_Inicio DATE, @Fecha_Fin DATE', @Valor, @Fecha_Inicio, @Fecha_Fin;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DetalladoVentasVacio]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DetalladoVentasVacio]
	-- Add the parameters for the stored procedure here
	@Fecha_Inicio date, -- fecha de inicio a buscar
    @Fecha_Fin date -- fecha de final a buscar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    select DF.IDFACTURA, CONVERT(varchar(10),F.FECHA,103) AS FECHA, C.CEDULA as Cédula, RTRIM(C.NOMBRE) + ' ' + RTRIM(C.APELLIDOS) as Nombres,
				RTRIM(P.PRODUCTO) AS 'NOMBRE PRODUCTO', RTRIM(DF.CANTIDAD) AS CANTIDAD, RTRIM(DF.PRECIO_UNITARIO) AS PRECIO_UNITARIO, RTRIM(DF.SUBTOTAL) AS SUBTOTAL
                FROM CLIENTE AS C
                INNER JOIN FACTURA AS F ON C.IDCLIENTE = F.IDCLIENTE
                INNER JOIN DETALLE_FACTURA AS DF ON F.IDFACTURA = DF.IDFACTURA
                INNER JOIN PRODUCTO AS P ON DF.IDPRODUCTO = P.IDPRODUCTO
				WHERE F.FECHA BETWEEN '28-01-2023' AND '28-01-2023'
                GROUP BY DF.IDFACTURA, C.CEDULA, C.NOMBRE, C.APELLIDOS, F.FECHA, P.PRODUCTO,DF.CANTIDAD, DF.PRECIO_UNITARIO, DF.SUBTOTAL

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Eliminar_CLIENTE]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------eliminar------------------------------
CREATE PROCEDURE [dbo].[sp_Eliminar_CLIENTE]
@IDcliente int, @Estado bit
AS
BEGIN
BEGIN TRY		
	UPDATE CLIENTE SET ESTADO = @Estado WHERE IDCLIENTE = @IDcliente
	END TRY
	BEGIN CATCH
		PRINT 'Error ' + ERROR_MESSAGE();
	END CATCH
END
------------------------------------------------------------------------------------------------------------------------------------------------------------
/****** Object:  StoredProcedure [dbo].[sp_Buscar_Clientes]    Script Date: 26/12/2023 20:15:40 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_PRODUCTO]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_eliminar_PRODUCTO]
(
    @idproducto bigint
)
AS
BEGIN

	UPDATE PRODUCTO SET ESTADO = '0'
	WHERE IDPRODUCTO = @idproducto
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarFactura]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_EliminarFactura]
    @IDFactura INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Iniciar una transacciÃ³n para garantizar la integridad referencial
        BEGIN TRANSACTION;

        -- Eliminar registros de DETALLE_FACTURA asociados a la factura
        DELETE FROM DETALLE_FACTURA
        WHERE IDFACTURA = @IDFactura;

        -- Eliminar la factura
        DELETE FROM FACTURA
        WHERE IDFACTURA = @IDFactura;

        -- Confirmar la transacciÃ³n si todo fue exitoso
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Revertir la transacciÃ³n en caso de error
        ROLLBACK TRANSACTION;

        -- Propagar el error
        THROW;
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_FullObtenerIVA]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_FullObtenerIVA]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select ID_IVA,RTRIM(ValorIVA) AS ValorIVA, FechaInicio AS 'Fecha Inicio', FechaFinal AS 'Fecha Final',
	CASE Estado WHEN 0 THEN 'Inactivo' WHEN 1 THEN 'Activo' END AS Estado
	from IVA
END

GO
/****** Object:  StoredProcedure [dbo].[sp_Insertar_CLIENTE]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------agregar------------------------------
CREATE PROCEDURE [dbo].[sp_Insertar_CLIENTE]
@Cedula char(10), @Nombre_Cliente char(30), @Apellido char(30), 
@Fecha_Nac date
AS
DECLARE @identificador integer;
BEGIN
	BEGIN TRY	
		DEclare @Estado bit = 1
		INSERT INTO CLIENTE VALUES (@Cedula, @Nombre_Cliente, @Apellido, @Fecha_Nac, @Estado);
	END TRY
	BEGIN CATCH
		PRINT 'Error ' + ERROR_MESSAGE();
	END CATCH
END
------------------------------------------------------------------------------------------------------------------------------------------------------------
/****** Object:  StoredProcedure [dbo].[sp_actualizar_CLIENTE]    Script Date: 26/12/2023 20:14:32 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_Insertar_PRODUCTO]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_Insertar_PRODUCTO]
@producto char(30), @precio_unitario decimal(10,2), @stock decimal(10,2)
AS
DECLARE @identificador integer;
BEGIN
	BEGIN TRY	
		DEclare @Estado bit = 1
		INSERT INTO PRODUCTO VALUES (@producto, @precio_unitario, @stock, @Estado);
	END TRY
	BEGIN CATCH
		PRINT 'Error ' + ERROR_MESSAGE();
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_IVAvacio]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_IVAvacio]
	-- Add the parameters for the stored procedure here	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from IVA where ID_IVA = '00000'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Listado_Clientes]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_Listado_Clientes]
AS
	BEGIN
		BEGIN TRY	
			select IDCLIENTE as ID, RTRIM(CEDULA) as Cedula, RTRIM(NOMBRE) as Nombre, RTRIM(APELLIDOS) as Apellido, FECHA_NACIMIENTO as 'Fecha Nacimiento'
				from CLIENTE WHERE NOMBRE = '00000000000'
		END TRY
	BEGIN CATCH
		PRINT 'Error ' + ERROR_MESSAGE();
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[sp_Mostrar_PRODUCTOS]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_Mostrar_PRODUCTOS]
AS
BEGIN

	select RTRIM(IDPRODUCTO) AS IDPRODUCTO, RTRIM(PRODUCTO) AS PRODUCTO, RTRIM(PRECIO_UNITARIO) AS PRECIO_UNITARIO,
		RTRIM(STOCK) AS STOCK from PRODUCTO WHERE ESTADO = 1
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ResumenVentasFechas]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ResumenVentasFechas]
	-- Add the parameters for the stored procedure here
	@Fecha_Inicio date, @Fecha_Fin date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT DF.IDFACTURA, 
       C.CEDULA AS CEDULA, 
       RTRIM(C.NOMBRE) + ' ' + RTRIM(C.APELLIDOS) AS NOMBRES, 
       CONVERT(varchar(10), F.FECHA, 103) AS FECHA, 
	   RTRIM(CAST(ROUND(SUM(DF.SUBTOTAL * (1 + (F.IVA / 100))), 4, 1) AS DECIMAL(20,4))) AS TOTAL
FROM CLIENTE AS C
INNER JOIN FACTURA AS F ON C.IDCLIENTE = F.IDCLIENTE
INNER JOIN DETALLE_FACTURA AS DF ON F.IDFACTURA = DF.IDFACTURA
INNER JOIN PRODUCTO AS P ON DF.IDPRODUCTO = P.IDPRODUCTO
where F.FECHA BETWEEN @Fecha_Inicio AND @Fecha_Fin
GROUP BY DF.IDFACTURA, C.CEDULA, C.NOMBRE, C.APELLIDOS, F.FECHA;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ResumenVentasFechasCliente]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ResumenVentasFechasCliente]
    @Fecha_Inicio date, -- fecha de inicio a buscar
    @Fecha_Fin date, -- fecha de final a buscar
    @Campo VARCHAR(20), -- Nombre del campo por el cual buscar
    @Valor VARCHAR(20) -- Valor a buscar
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    DECLARE @sql NVARCHAR(MAX);
    SET @sql = N'SELECT DF.IDFACTURA, C.CEDULA AS CEDULA, RTRIM(C.NOMBRE) + '' '' + RTRIM(C.APELLIDOS) AS NOMBRES, 
                        CONVERT(varchar(10), F.FECHA, 103) AS FECHA, 
                        RTRIM(CAST(ROUND(SUM(DF.SUBTOTAL * (1 + (F.IVA / 100))), 4, 1) AS DECIMAL(20,4))) AS TOTAL
                FROM CLIENTE AS C
                INNER JOIN FACTURA AS F ON C.IDCLIENTE = F.IDCLIENTE
                INNER JOIN DETALLE_FACTURA AS DF ON F.IDFACTURA = DF.IDFACTURA
                INNER JOIN PRODUCTO AS P ON DF.IDPRODUCTO = P.IDPRODUCTO
                WHERE C.' + QUOTENAME(@Campo) + ' LIKE @Valor + ''%'' AND F.FECHA BETWEEN @Fecha_Inicio AND @Fecha_Fin
                GROUP BY DF.IDFACTURA, C.CEDULA, C.NOMBRE, C.APELLIDOS, F.FECHA;';

    EXEC sp_executesql @sql, N'@Valor VARCHAR(20), @Fecha_Inicio DATE, @Fecha_Fin DATE', @Valor, @Fecha_Inicio, @Fecha_Fin;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ResumenVentasFechasClienteProducto]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ResumenVentasFechasClienteProducto]
    @Fecha_Inicio date, -- fecha de inicio a buscar
    @Fecha_Fin date, -- fecha de final a buscar
    @Campo VARCHAR(20), -- Nombre del campo por el cual buscar
	@Campo2 VARCHAR(20), -- Nombre del campo por el cual buscar
    @Valor VARCHAR(20), -- Valor a buscar
	@Valor2 VARCHAR(20) -- Valor a buscar
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    DECLARE @sql NVARCHAR(MAX);
    SET @sql = N'SELECT DF.IDFACTURA, C.CEDULA AS CEDULA, RTRIM(C.NOMBRE) + '' '' + RTRIM(C.APELLIDOS) AS NOMBRES, 
                        CONVERT(varchar(10), F.FECHA, 103) AS FECHA, 
                        RTRIM(CAST(ROUND(SUM(DF.SUBTOTAL * (1 + (F.IVA / 100))), 4, 1) AS DECIMAL(20,4))) AS TOTAL
                FROM CLIENTE AS C
                INNER JOIN FACTURA AS F ON C.IDCLIENTE = F.IDCLIENTE
                INNER JOIN DETALLE_FACTURA AS DF ON F.IDFACTURA = DF.IDFACTURA
                INNER JOIN PRODUCTO AS P ON DF.IDPRODUCTO = P.IDPRODUCTO
                WHERE C.' + QUOTENAME(@Campo) + ' LIKE @Valor + ''%'' AND P.' + QUOTENAME(@Campo2) + ' LIKE @Valor2 + ''%'' AND F.FECHA BETWEEN @Fecha_Inicio AND @Fecha_Fin
                GROUP BY DF.IDFACTURA, C.CEDULA, C.NOMBRE, C.APELLIDOS, F.FECHA;';

    EXEC sp_executesql @sql, N'@Valor VARCHAR(20), @Valor2 VARCHAR(20), @Fecha_Inicio DATE, @Fecha_Fin DATE', @Valor, @Valor2,@Fecha_Inicio, @Fecha_Fin;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ResumenVentasFechasProductoS]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ResumenVentasFechasProductoS]
    @Fecha_Inicio date, -- fecha de inicio a buscar
    @Fecha_Fin date, -- fecha de final a buscar
    @Campo VARCHAR(20), -- Nombre del campo por el cual buscar
    @Valor VARCHAR(20) -- Valor a buscar
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    DECLARE @sql NVARCHAR(MAX);
    SET @sql = N'SELECT DF.IDFACTURA, C.CEDULA AS CEDULA, RTRIM(C.NOMBRE) + '' '' + RTRIM(C.APELLIDOS) AS NOMBRES, 
                        CONVERT(varchar(10), F.FECHA, 103) AS FECHA, 
                        RTRIM(CAST(ROUND(SUM(DF.SUBTOTAL * (1 + (F.IVA / 100))), 4, 1) AS DECIMAL(20,4))) AS TOTAL
                FROM CLIENTE AS C
                INNER JOIN FACTURA AS F ON C.IDCLIENTE = F.IDCLIENTE
                INNER JOIN DETALLE_FACTURA AS DF ON F.IDFACTURA = DF.IDFACTURA
                INNER JOIN PRODUCTO AS P ON DF.IDPRODUCTO = P.IDPRODUCTO
                WHERE P.' + QUOTENAME(@Campo) + ' LIKE @Valor + ''%'' AND F.FECHA BETWEEN @Fecha_Inicio AND @Fecha_Fin
                GROUP BY DF.IDFACTURA, C.CEDULA, C.NOMBRE, C.APELLIDOS, F.FECHA;';

    EXEC sp_executesql @sql, N'@Valor VARCHAR(20), @Fecha_Inicio DATE, @Fecha_Fin DATE', @Valor, @Fecha_Inicio, @Fecha_Fin;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ResumenVentasVacio]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ResumenVentasVacio]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DF.IDFACTURA, 
       C.CEDULA AS CEDULA, 
       RTRIM(C.NOMBRE) + ' ' + RTRIM(C.APELLIDOS) AS NOMBRES, 
       CONVERT(varchar(10), F.FECHA, 103) AS FECHA, 
	   CAST(ROUND(SUM(DF.SUBTOTAL * (1 + (F.IVA / 100))), 4, 1) AS DECIMAL(20,4)) AS TOTAL
FROM CLIENTE AS C
INNER JOIN FACTURA AS F ON C.IDCLIENTE = F.IDCLIENTE
INNER JOIN DETALLE_FACTURA AS DF ON F.IDFACTURA = DF.IDFACTURA
INNER JOIN PRODUCTO AS P ON DF.IDPRODUCTO = P.IDPRODUCTO
WHERE F.FECHA BETWEEN '28-01-2023' AND '28-01-2023'
GROUP BY DF.IDFACTURA, C.CEDULA, C.NOMBRE, C.APELLIDOS, F.FECHA;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_VentaProducto]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_VentaProducto]
@StringXML varchar(MAX)
AS
BEGIN
	BEGIN TRANSACTION 
		SET NOCOUNT ON;
		Declare @XML XML
		declare @Venta integer;

		---------------------
		BEGIN TRY
		set @XML = @StringXML	
		---insertar datos compra 
		
		INSERT INTO [dbo].[FACTURA]
		(IDCLIENTE,FECHA,SUBTOTAL,IVA,TOTAL)
		select 
		R.Item.query('./IDCLIENTE').value('.','bigint') 
		,R.Item.query('./FECHA').value('.','datetime') 
		,R.Item.query('./SUBTOTAL').value('.','decimal(12, 4)')
		,R.Item.query('./IVA').value('.','decimal(5, 2)') 
		,R.Item.query('./TOTAL').value('.','decimal(12, 4)') 
		from @XML.nodes('./FACTURA/item') as R(Item)
		-----extraigo id
		SET @Venta = SCOPE_IDENTITY();

		-------------venta -producto
		insert into [dbo].[DETALLE_FACTURA]
		(IDFACTURA, IDPRODUCTO, CANTIDAD, PRECIO_UNITARIO, SUBTOTAL)							
		select 
			@Venta,
			R.Item.query('./IDPRODUCTO').value('.','bigint'),
			R.Item.query('./CANTIDAD').value('.','decimal(10, 2)'),
			R.Item.query('./PRECIO_UNITARIO').value('.','decimal(10, 2)'),
			R.Item.query('./SUBTOTAL').value('.','decimal(12, 4)')
		from @XML.nodes('./DETALLE_FACTURA/item') as R(Item)


			COMMIT TRANSACTION 
		END TRY
		BEGIN CATCH
			ROLLBACK TRAN
			
			END CATCH;
		
END
GO
/****** Object:  StoredProcedure [dbo].[VerificarExistenciaCedula]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerificarExistenciaCedula]
    @Cedula VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
	
    IF EXISTS (SELECT 1 FROM CLIENTE WHERE CEDULA = @Cedula)
        SELECT 'True' AS Resultado;
    ELSE
        SELECT 'False' AS Resultado;
END
GO
/****** Object:  StoredProcedure [dbo].[VerificarRangoFechaIVA]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[VerificarRangoFechaIVA]
    @FechaInicio date,
    @FechaFinal date
AS
BEGIN
    

    IF EXISTS ( select 1 from IVA WHERE Estado = 1 AND FechaInicio BETWEEN @FechaInicio AND @FechaFinal or FechaFinal BETWEEN @FechaFinal and @FechaInicio)
        SELECT 'True' AS ExisteRango;
    ELSE
        SELECT 'False' AS Resultado;
    
END
GO
/****** Object:  Trigger [dbo].[tr_ActualizarStock]    Script Date: 10/03/2024 23:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tr_ActualizarStock]
ON [dbo].[DETALLE_FACTURA]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Crear tabla temporal para almacenar los datos necesarios
    CREATE TABLE #TempDetalleFactura (
        IDPRODUCTO BIGINT,
        CANTIDAD DECIMAL(10, 2)
    );

    -- Insertar datos de la factura reciÃ©n insertada en la tabla temporal
    INSERT INTO #TempDetalleFactura (IDPRODUCTO, CANTIDAD)
    SELECT IDPRODUCTO, CANTIDAD
    FROM inserted;

    -- Actualizar el stock en la tabla [dbo].[PRODUCTO]
    DECLARE @IDProducto BIGINT;
    DECLARE @Cantidad DECIMAL(10, 2);

    DECLARE cursorActualizarStock CURSOR FOR
    SELECT IDPRODUCTO, CANTIDAD
    FROM #TempDetalleFactura;

    OPEN cursorActualizarStock;

    FETCH NEXT FROM cursorActualizarStock INTO @IDProducto, @Cantidad;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        UPDATE [dbo].[PRODUCTO]
        SET STOCK = STOCK - @Cantidad
        WHERE IDPRODUCTO = @IDProducto;

        FETCH NEXT FROM cursorActualizarStock INTO @IDProducto, @Cantidad;
    END

    CLOSE cursorActualizarStock;
    DEALLOCATE cursorActualizarStock;

    -- Eliminar la tabla temporal
    DROP TABLE #TempDetalleFactura;
END;
GO
ALTER TABLE [dbo].[DETALLE_FACTURA] ENABLE TRIGGER [tr_ActualizarStock]
GO
