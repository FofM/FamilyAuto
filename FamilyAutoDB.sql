USE [master]
GO
/****** Object:  Database [FamilyAuto]    Script Date: 26-Mar-16 8:49:25 PM ******/
CREATE DATABASE [FamilyAuto]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FamilyAuto', FILENAME = N'C:\Users\Filip\FamilyAuto.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FamilyAuto_log', FILENAME = N'C:\Users\Filip\FamilyAuto_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FamilyAuto] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FamilyAuto].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FamilyAuto] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FamilyAuto] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FamilyAuto] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FamilyAuto] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FamilyAuto] SET ARITHABORT OFF 
GO
ALTER DATABASE [FamilyAuto] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FamilyAuto] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FamilyAuto] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FamilyAuto] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FamilyAuto] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FamilyAuto] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FamilyAuto] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FamilyAuto] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FamilyAuto] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FamilyAuto] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FamilyAuto] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FamilyAuto] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FamilyAuto] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FamilyAuto] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FamilyAuto] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FamilyAuto] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FamilyAuto] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FamilyAuto] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FamilyAuto] SET  MULTI_USER 
GO
ALTER DATABASE [FamilyAuto] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FamilyAuto] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FamilyAuto] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FamilyAuto] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [FamilyAuto] SET DELAYED_DURABILITY = DISABLED 
GO
USE [FamilyAuto]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 26-Mar-16 8:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 26-Mar-16 8:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticleTitle] [nvarchar](50) NOT NULL,
	[ArticleDescription] [nvarchar](max) NOT NULL,
	[ArticleType] [int] NOT NULL,
	[DateUploaded] [date] NOT NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 26-Mar-16 8:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Make] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Variant] [nvarchar](50) NOT NULL,
	[Condition] [nvarchar](50) NOT NULL,
	[Type] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Price] [int] NULL,
	[DateUploaded] [datetime] NOT NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VehicleEngine]    Script Date: 26-Mar-16 8:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleEngine](
	[Id] [int] NOT NULL,
	[FuelType] [nvarchar](50) NULL,
	[Transmission] [nvarchar](50) NULL,
	[CubicCapacity] [int] NULL,
	[Power] [int] NULL,
	[FuelConsumption] [nvarchar](50) NULL,
	[EmissionClass] [nvarchar](50) NULL,
	[EmissionSticker] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VehicleFeature]    Script Date: 26-Mar-16 8:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleFeature](
	[Id] [int] NOT NULL,
	[ExteriorColor] [nvarchar](50) NULL,
	[InteriorColor] [nvarchar](50) NULL,
	[AirConditioning] [bit] NULL,
	[InteriorFeatures] [nvarchar](100) NULL,
	[Security] [nvarchar](100) NULL,
	[Airbags] [bit] NULL,
	[ParkingSensor] [bit] NULL,
	[Sports] [bit] NULL,
	[InteriorMaterial] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VehicleHistory]    Script Date: 26-Mar-16 8:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleHistory](
	[Id] [int] NOT NULL,
	[Purpose] [nvarchar](50) NULL,
	[NoOfOwners] [int] NULL,
	[HUValidUntil] [date] NULL,
	[Warranty] [bit] NULL,
	[Mileage] [int] NULL,
	[FirstRegistration] [date] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VehiclePictures]    Script Date: 26-Mar-16 8:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehiclePictures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleID] [int] NOT NULL,
	[Description] [nvarchar](100) NULL,
	[ImageURL] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_VehiclePictures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201603061826464_Initial', N'FamilyAuto.Migrations.Configuration', 0x1F8B0800000000000400E55CDB6EDC36107D2FD07F10F4D402CECA7650A0357613381BBB351A5FE0B5D3BE055C89BB2622512A4939BB28FA657DE827F5174ADD2891945694AC559C147948CCCBE17038331C6A8EF3EFDFFF4C5F6F02DF7A8484A210CFECA3C9A16D41EC861EC2EB991DB3D58B1FEDD7AFBEFD667AE6051BEB7D31EE65328ECFC474663F30169D380E751F6000E824402E0969B86213370C1CE085CEF1E1E14FCED191033984CDB12C6B7A1B63860298FEC07F9C87D885118B817F197AD0A7793BEF59A4A8D61508208D800B67F6390890BF3D8D5938C906DBD6A98F00176401FD956D018C43061817F3E49EC20523215E2F22DE00FCBB6D04F9B815F029CCC53F29879BEEE4F038D989534E2CA0DC98B230E80878F432578DA34EEFA5605BA88E2BEF8C2B996D935DA70A9CD9EFE103727DBE7775AD93B94F927135EA9DE4930EACB2EB4058023798E4CF81358F7D161338C3306604F807D64DBCF491FB2BDCDE851F219EE1D8F7ABC271F1789FD4C09B6E481841C2B6B770958B7CE1D99623CF73D489625A654EB69B0BCC5E1EDBD6155F1C2C7D28CEBEB2F3050B09FC1962480083DE0D600C129C60C0547BDAEACA5A97E0232C56E3C6C6DDC6B62EC1E61DC46BF630B37FE07E728E36D02B1A7201EE31E24EC6E73012C31A015B164D4E66F455DF03820066A3AFCBA38387328F1879E564B9D1177D0BA94B50D4B261FECFBD2CCE9DE03EF243E041E14449DB1D8FD6ED6057E011AD53B7524D278B2167788D309F760BFD74147D405116B78B28F34119794EC2E036F44B0879C0874518133739A370D7A83B40D6907516F71C8224A6511381CBB18D221743DA8416E37A8AFD0BE2C19D6C4DA416431B85CE47B4C95C0CAB1379EA941791C9F5549C7D8F4B2A9BFA555D55BBFDF53C86FE3051AA251212806980281D240CB7C4FB7889DC39E0E95E7AFF4AEAD93DF326FC0449A71989FEF8FD42E3A02DE00EB2B5B35C85731F503AD6620B86DC8FA55E065BAE2D0E0D19E78BB8B23BCE1741EA29D1278FBEBDC24F3EF77F147FCE363C5D462199877E38BC85A9C2E211173B4544249EE902D9726F426E7F009B8A5AA6058DD21E1D0E21EE02BA31A9C4CBBD2DC4F5B2046BDA511F37807CE4F22C20A6E5D119CE5D4421615D172C0EE012247F83015E4B7B887E5D92C69608A825974F8981222DEC1103F3B9FFA31878139328A47B4FC1AEC2EBD5F527CC35D929C3F9E5FE3DF09177CF8FDAD75F74BBE7FE0608CFFBCAA062E87B97888F5AC36E89182294DDC235B71E02AAA958A3AC4338A0F9FBA7C5FDD4679289F79D521ABA289550965C498EE46D9F61CF327A1167C658D9343749EE7528E27EC6A5E1F781A6D2366CA1040DBBC8E3E4150E27137D11EEAC90241FD7409A79F3E34698E99E8DB08B22E09BEC55996C1818928311CBA83D6F610471F209D0441FFDD717CB2821AB4D4753A7623C9D6C4A5C398627AF7FB418D2AEF4DB4D4317F9F848A6A56E787CE35295F225995711500DCF5FFBBA34A47169A15B0317E17F24DB52B63BBE69292A794696955D917C0EE3332029B2029143263D70C36A52D27B0AF3AC94E689946A1F09F20232353D286F65D5E4340BAB4528EEBC269CA2DF0CAD7C0B34E189486806288CBB094F0C50F02A27A481AADF6D2A63777EE0510DC8348B117BAB9C9B668DA6698B0ED670448EAC82EEEA290FB35541F51772A72BF9694AD2EE601DAEDCCED08A1236D8AAA7DA9BA5CBDDF2342DA997898ED6E44ECD3A2A1E0622EA95BC0727233E140409A7812131BD0451C45F9B15C644DE622D32BAC4FCC5A23B9120C8301C97D6F00984B46225BE6DFEDC537A93BAAD07D3671D7FC28125481EBC732FD086E931BE21BC15EBC9615C3FC122DA15E3937FABD789F2D1A2E626CC679FF3AD05C97D9AF2046A6C489B99B256800F48CD678679E8C7016EBE589B67673C83EAFCACA50342461A9020B226730C4101A8A28846739C4A49BF8A546936C7CACA5F5598ACC51C41AAB85781A48E0E7852115D02947A74C4A9A3989D967869E6AD041BD55BBAF852E35DDDC3A3EAB1CCFDAA69FE7EBCAB2CA35631CAD60ED628154A25AB947A3AF88A5C0E95FC45EE32C7CC0BA555ACBCA99BCEA4D2A9AA3AA9D31C57A991565195AEEE98A2145A872A3A9F9B5FEE48117B7866F18CE8ED9A8D00FBF14DA5C4289D9CDC658EA9541225E1704F4CAD605845D53ABBCB5A26E175E236A5E8BB90CB9A6115B16CEDB4F7AC28A8EC396BEC1097E432A1149FE4AE0EBBCCCB87D21EF3B6EEA750D613EB4EA1EC7D6E31A4F9F9D4238434809987904680FD841051A1930CAA6834C7A996E0AA50D5767334B93257C5937BCC11CB7A5D15AD6CEDF058284A78D273A168EC9024E8653D294DD0BB47761CED0DAE0E11AB8BB7B8F2E69EE6EFDFF65F5DD01EC4D910DBE24A7B445EF2185E6C2983C124193059FCE1CF7D0493975531E01260B48294654572FBF8F0E858F9F587E7F3AB080EA59E6FF6FB08F2718D50E84789525B99FF5D59F9955F05C08F80B80F80683480A730FD87025588FC43C16A3CFDA180AB04D7A1306B58F605F47701D87C3F0873DEE36DAC9D39DF9320FD79BC46ABBF5C600F6E66F69FE9F013EBE2F70F17DE81754D78B83AB10EADBF9ECC693638F2BE14E681A06B19CBA9B6BAE148FCE51EF31BD8CC03EDB296BC3C30B6C255EE85DE97F1FBB5FA532D4777A073ABA5E40E84DDC0C05DA2CE7ED1C4C6AD1534A5C976C357C9B743E12A5CDB1E3BAFE5DDF6C09139B84F3802958F3B8A87D7B352BE1E0F5718A803F99F4E38ED7125D5D14F93B4A82B8E4A45ED61820A2DB5CFFDDA44526DDFD19E49A00351A70A3EC46723788EC8896AAC503D5F769D297973206B1084A3CFC7CA1CD11E9AEB22CFD7200CE99603D98360B87C3E26E588F6D0FC91FB999124759E4D4361C09C00997D98E4F7DA32E4A79DDD697B6247EE58AA1781D2803FB963C946A6DB9349963B167D5644CCBE4439F9BCBF589265DFED2BD657572FFF12C8937DB7AFF8C168BC48BDF6C2C36BE53F97E2C19DA2750991FC575318BA526015632EF02A2C62BB225131447D52400678EE0F4E09432BE032DEED424AD3AF15FCDD13A75FB696D0BBC0D7318B62C6B70C83A52F2923B92776AD9F923F6599A7D7E9F73D3AC416D2E7197FBE5CE33731F23D21F779CD77EA0688E402CAEB28E927BCA49EB2DE0AA4AB50F5FE26A05C7DE2DEBC8341E473307A8D17E011F691ED9EC277700DDC6D51426B06693F0859EDD3B708AC0908688E51CEE73F721BF682CDABFF00A9F81A06634D0000, N'6.1.3-40302')
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([Id], [ArticleTitle], [ArticleDescription], [ArticleType], [DateUploaded]) VALUES (3, N'Washington D.C. car owners pay most for repairs', N'This year''s CarMD repair cost survey puts Washington D.C. at the top of the list for the most expensive repairs in the country. On the opposite end, in just a few years, Wyoming has gone from the nation''s most costly to the cheapest.', 0, CAST(N'2016-03-10' AS Date))
INSERT [dbo].[Articles] ([Id], [ArticleTitle], [ArticleDescription], [ArticleType], [DateUploaded]) VALUES (1002, N'Oil Change', N'With regular car oil changes, your vital engine parts stay well-coated and protected against excess heat and friction. When you skip oil changes, the oil begins to thicken, break down, and is consequently less effective, resulting in damage and engine wear.', 1, CAST(N'2016-03-17' AS Date))
INSERT [dbo].[Articles] ([Id], [ArticleTitle], [ArticleDescription], [ArticleType], [DateUploaded]) VALUES (1003, N'Market keeps on truckin''', N'Owing to the incredible crossover craze, the mix between light trucks and cars is beginning to tilt rather dramatically away from cars.

In the first two months of 2016, sales of sedans, hatchbacks, sports cars and such slipped to 41.4 percent of the U.S. market. That was after dropping to 43.3 percent for all of 2015, which was down from 46.9 percent the year before.

In 2013, cars accounted for 50 percent of sales, and in 2009, as gas prices soared, they stood at 54.6 percent.

Of course, those fast-breeding crossovers have a lot to do with the light-truck surge. So far this year, CUVs (by another name) accounted for 30.7 percent of the market. That was up from 28.4 percent in the same period a year ago.', 0, CAST(N'2016-03-17' AS Date))
INSERT [dbo].[Articles] ([Id], [ArticleTitle], [ArticleDescription], [ArticleType], [DateUploaded]) VALUES (1004, N'Car discount of 20 000 to 60 000 CZK', N'In cooperation with credit company Homecredit, we have prepared a unique product concerning car purchases in instalments TOP CREDIT and in addition to that, a car discount of 20 000 to 60 000 CZK!
The price of any car you have selected from the MAMA CAR offer is transparent when paying in cash or in instalments, including VAT or prices exclusive of VAT if you are in business.
Choose a car at MAMA CAR and come to one of our car centres in Prague, where our consultants will prepare a car financing offer according to your needs and possibilities.', 0, CAST(N'2016-03-17' AS Date))
INSERT [dbo].[Articles] ([Id], [ArticleTitle], [ArticleDescription], [ArticleType], [DateUploaded]) VALUES (1005, N'Free transport to our car centres', N'We have prepared a new service FREE TRANSPORT just for you! Just do the following three steps:

    Call the free line 800 50 00 50.
    Book a car or cars that you like through our operator.
    Arrange a time and place where our corporate transportation will pick you up and take to any of our branches for free.

If the cars you are interested in are located in different branches, we will drive them to the branch of your choice or transport you between them', 0, CAST(N'2016-03-17' AS Date))
SET IDENTITY_INSERT [dbo].[Articles] OFF
SET IDENTITY_INSERT [dbo].[Vehicle] ON 

INSERT [dbo].[Vehicle] ([Id], [Make], [Model], [Variant], [Condition], [Type], [Description], [Price], [DateUploaded]) VALUES (5, N'BMW', N'Z1', N'GTI', N'Used', 3, N'A very modern and reliable car', 50000, CAST(N'2016-03-23 20:29:43.247' AS DateTime))
INSERT [dbo].[Vehicle] ([Id], [Make], [Model], [Variant], [Condition], [Type], [Description], [Price], [DateUploaded]) VALUES (6, N'BMW', N'X1', N'GTI', N'New', 3, N'A very modern and reliable car', 30000, CAST(N'2016-03-23 20:29:54.743' AS DateTime))
INSERT [dbo].[Vehicle] ([Id], [Make], [Model], [Variant], [Condition], [Type], [Description], [Price], [DateUploaded]) VALUES (1016, N'Opel', N'Astra', N'GTI', N'Used', 4, N'Der Wagen hat noch bis November 2017 Tüv und hat nur einen Kilometerstand von lediglich 58.000 KM ! Außerdem ist das Auto Scheckheftgepflegt und ist technisch in einem einwandfreien Zustand.', 5000, CAST(N'2016-03-23 20:29:59.317' AS DateTime))
INSERT [dbo].[Vehicle] ([Id], [Make], [Model], [Variant], [Condition], [Type], [Description], [Price], [DateUploaded]) VALUES (1017, N'Nissan', N'Pathfinder', N'Sitz', N'Used', 0, N'Wir haben bereits viele Fahrzeuge nach Western Europa verkauft, aufgrund der CZK Abwertung das bedeutet, dass unsere Preise sind viel niedriger, sagt Frau Karolina Topolova, CEO AAA Auto International', NULL, CAST(N'2016-03-07 21:30:59.620' AS DateTime))
INSERT [dbo].[Vehicle] ([Id], [Make], [Model], [Variant], [Condition], [Type], [Description], [Price], [DateUploaded]) VALUES (1018, N'Volvo', N'S60', N'FWD', N'New', 0, N'The S60 Cross Country conveys an imposing, muscular presence that echoes its capable nature. Integrated tailpipes reflect its sporty dark side, while the roomy, leather interior, with ergonomic sport seats, speaks of pure luxury.', NULL, CAST(N'2016-03-06 21:31:08.600' AS DateTime))
INSERT [dbo].[Vehicle] ([Id], [Make], [Model], [Variant], [Condition], [Type], [Description], [Price], [DateUploaded]) VALUES (1019, N'Volkswagen', N'Polo', N'N/A', N'Used', 0, N'The Volkswagen Polo is a supermini car produced by the German manufacturer Volkswagen since 1975. It is sold in Europe and other markets worldwide in hatchback, sedan and estate variants.', NULL, CAST(N'2016-03-09 21:31:18.010' AS DateTime))
INSERT [dbo].[Vehicle] ([Id], [Make], [Model], [Variant], [Condition], [Type], [Description], [Price], [DateUploaded]) VALUES (1020, N'Fiat', N'Punto', N'N/A', N'Used', 0, N'The Fiat Punto is a supermini car produced by the Italian manufacturer Fiat since 1993, spanning over three generations. The third generation of the car was marketed as the Grande Punto, between 2005 and 2009, and the Punto Evo, between 2009 and 2012, when the bare Punto name was re-introduced. As of February 2012, nearly 8.5 million units had been produced.', NULL, CAST(N'2016-02-17 21:31:37.270' AS DateTime))
INSERT [dbo].[Vehicle] ([Id], [Make], [Model], [Variant], [Condition], [Type], [Description], [Price], [DateUploaded]) VALUES (1022, N'TestCar', N'TestModel', N'TestVariant', N'TestCondition', 1, N'TestDescription', NULL, CAST(N'2016-03-12 20:43:47.427' AS DateTime))
SET IDENTITY_INSERT [dbo].[Vehicle] OFF
INSERT [dbo].[VehicleEngine] ([Id], [FuelType], [Transmission], [CubicCapacity], [Power], [FuelConsumption], [EmissionClass], [EmissionSticker]) VALUES (5, N'Disel', N'Manual', 500, 100, N'6 per 100 miles', N'C', N'YES')
INSERT [dbo].[VehicleEngine] ([Id], [FuelType], [Transmission], [CubicCapacity], [Power], [FuelConsumption], [EmissionClass], [EmissionSticker]) VALUES (6, N'Gasoline', N'Automatic', 600, 120, N'7 per 100 miles', N'B', N'YES')
INSERT [dbo].[VehicleEngine] ([Id], [FuelType], [Transmission], [CubicCapacity], [Power], [FuelConsumption], [EmissionClass], [EmissionSticker]) VALUES (1016, N'Petrol', N'Manual', 1600, 55, N'7 per 100 miles', N'Euro3', N'4')
INSERT [dbo].[VehicleEngine] ([Id], [FuelType], [Transmission], [CubicCapacity], [Power], [FuelConsumption], [EmissionClass], [EmissionSticker]) VALUES (1017, N'Disel', N'Manual', 2500, 140, N'9 per 100 miles', N'Euro4', N'3')
INSERT [dbo].[VehicleEngine] ([Id], [FuelType], [Transmission], [CubicCapacity], [Power], [FuelConsumption], [EmissionClass], [EmissionSticker]) VALUES (1018, N'Disel', N'Automatic', 2000, 140, N'4.6 per 100 miles', N'Euro6', N'4')
INSERT [dbo].[VehicleEngine] ([Id], [FuelType], [Transmission], [CubicCapacity], [Power], [FuelConsumption], [EmissionClass], [EmissionSticker]) VALUES (1019, N'Petrol', N'Manual', 1400, 55, N'9 per 100 miles', N'Euro4', N'4')
INSERT [dbo].[VehicleEngine] ([Id], [FuelType], [Transmission], [CubicCapacity], [Power], [FuelConsumption], [EmissionClass], [EmissionSticker]) VALUES (1020, N'Petrol', N'Manual', 1200, 44, N'5.7 per 100 miles', N'Euro3', N'4')
INSERT [dbo].[VehicleFeature] ([Id], [ExteriorColor], [InteriorColor], [AirConditioning], [InteriorFeatures], [Security], [Airbags], [ParkingSensor], [Sports], [InteriorMaterial]) VALUES (5, N'White', N'Black', 1, N'Some', N'Alarm', 1, 1, 0, N'Leather')
INSERT [dbo].[VehicleFeature] ([Id], [ExteriorColor], [InteriorColor], [AirConditioning], [InteriorFeatures], [Security], [Airbags], [ParkingSensor], [Sports], [InteriorMaterial]) VALUES (6, N'Violet', N'Orange', 0, N'Some', N'Alarm', 0, 1, 0, N'Leather')
INSERT [dbo].[VehicleFeature] ([Id], [ExteriorColor], [InteriorColor], [AirConditioning], [InteriorFeatures], [Security], [Airbags], [ParkingSensor], [Sports], [InteriorMaterial]) VALUES (1016, N'Blue metallic', N'Green', 0, N'Some', N'ABS', 0, 0, 0, N'Cotton')
INSERT [dbo].[VehicleFeature] ([Id], [ExteriorColor], [InteriorColor], [AirConditioning], [InteriorFeatures], [Security], [Airbags], [ParkingSensor], [Sports], [InteriorMaterial]) VALUES (1017, N'White', N'Grey', 0, N'None', N'Secure', 1, 1, 0, N'Synthetic')
INSERT [dbo].[VehicleFeature] ([Id], [ExteriorColor], [InteriorColor], [AirConditioning], [InteriorFeatures], [Security], [Airbags], [ParkingSensor], [Sports], [InteriorMaterial]) VALUES (1018, N'Black', N'Black', 0, N'Misc', N'ABS', 1, 1, 1, N'Leather')
INSERT [dbo].[VehicleFeature] ([Id], [ExteriorColor], [InteriorColor], [AirConditioning], [InteriorFeatures], [Security], [Airbags], [ParkingSensor], [Sports], [InteriorMaterial]) VALUES (1019, N'Gray', N'Black', 0, N'Some', N'Alarm', 0, 1, 0, N'Cloth')
INSERT [dbo].[VehicleFeature] ([Id], [ExteriorColor], [InteriorColor], [AirConditioning], [InteriorFeatures], [Security], [Airbags], [ParkingSensor], [Sports], [InteriorMaterial]) VALUES (1020, N'Black', N'Grey', 1, N'Misc', N'ABS', 1, 0, 0, N'Leather')
INSERT [dbo].[VehicleHistory] ([Id], [Purpose], [NoOfOwners], [HUValidUntil], [Warranty], [Mileage], [FirstRegistration]) VALUES (5, N'Personal', 1, CAST(N'2016-08-13' AS Date), 0, 150000, CAST(N'2013-06-10' AS Date))
INSERT [dbo].[VehicleHistory] ([Id], [Purpose], [NoOfOwners], [HUValidUntil], [Warranty], [Mileage], [FirstRegistration]) VALUES (6, N'Company', 1, CAST(N'2016-09-22' AS Date), 1, 210000, CAST(N'2013-08-29' AS Date))
INSERT [dbo].[VehicleHistory] ([Id], [Purpose], [NoOfOwners], [HUValidUntil], [Warranty], [Mileage], [FirstRegistration]) VALUES (1016, N'Personal', 2, CAST(N'2016-07-06' AS Date), 1, 58000, CAST(N'2009-05-04' AS Date))
INSERT [dbo].[VehicleHistory] ([Id], [Purpose], [NoOfOwners], [HUValidUntil], [Warranty], [Mileage], [FirstRegistration]) VALUES (1017, N'Personal', 1, CAST(N'2016-07-19' AS Date), 0, 61000, CAST(N'2013-03-04' AS Date))
INSERT [dbo].[VehicleHistory] ([Id], [Purpose], [NoOfOwners], [HUValidUntil], [Warranty], [Mileage], [FirstRegistration]) VALUES (1018, N'Personal', 0, CAST(N'2016-11-23' AS Date), 1, 0, CAST(N'2016-02-07' AS Date))
INSERT [dbo].[VehicleHistory] ([Id], [Purpose], [NoOfOwners], [HUValidUntil], [Warranty], [Mileage], [FirstRegistration]) VALUES (1019, N'Personal', 3, CAST(N'2016-03-18' AS Date), 0, 90000, CAST(N'2011-07-13' AS Date))
INSERT [dbo].[VehicleHistory] ([Id], [Purpose], [NoOfOwners], [HUValidUntil], [Warranty], [Mileage], [FirstRegistration]) VALUES (1020, N'Personal', 1, CAST(N'2016-08-15' AS Date), 0, 80000, CAST(N'2013-09-20' AS Date))
INSERT [dbo].[VehicleHistory] ([Id], [Purpose], [NoOfOwners], [HUValidUntil], [Warranty], [Mileage], [FirstRegistration]) VALUES (1022, NULL, NULL, NULL, NULL, 10000, NULL)
SET IDENTITY_INSERT [dbo].[VehiclePictures] ON 

INSERT [dbo].[VehiclePictures] ([Id], [VehicleID], [Description], [ImageURL]) VALUES (1, 5, NULL, N'https://i.kinja-img.com/gawker-media/image/upload/hwstze0cpmpzffhpqevi.png')
INSERT [dbo].[VehiclePictures] ([Id], [VehicleID], [Description], [ImageURL]) VALUES (2, 6, NULL, N'http://icdn3.digitaltrends.com/image/2016-bmw-x1-first-drive-front-angle-970x647-c.jpg')
INSERT [dbo].[VehiclePictures] ([Id], [VehicleID], [Description], [ImageURL]) VALUES (1002, 1016, NULL, N'http://s1.cdn.autoevolution.com/images/news/opel-astra-gets-new-16-sidi-turbo-engine-59530_1.jpg')
INSERT [dbo].[VehiclePictures] ([Id], [VehicleID], [Description], [ImageURL]) VALUES (1003, 1017, NULL, N'http://www.nissanusa.com/content/dam/nissan/vehicles/2016/pathfinder/colors-photos/360/exterior/k23/01.jpg')
INSERT [dbo].[VehiclePictures] ([Id], [VehicleID], [Description], [ImageURL]) VALUES (1004, 1018, NULL, N'http://pictures.topspeed.com/IMG/crop/201505/volvo-s60---driven-9_800x0w.jpg')
INSERT [dbo].[VehiclePictures] ([Id], [VehicleID], [Description], [ImageURL]) VALUES (1005, 1019, NULL, N'http://jfs24.com/data_images/reviews/volkswagen-polo/volkswagen-polo-06.jpg')
INSERT [dbo].[VehiclePictures] ([Id], [VehicleID], [Description], [ImageURL]) VALUES (1006, 1020, NULL, N'http://allfotocars.com/image.php?pic=/data_images/gallery/01/fiat-punto-grande/fiat-punto-grande-02.jpg')
INSERT [dbo].[VehiclePictures] ([Id], [VehicleID], [Description], [ImageURL]) VALUES (1007, 5, NULL, N'http://ag-spots-2012.o.auroraobjects.eu/2012/04/28/c201628042012045411_1.jpg')
SET IDENTITY_INSERT [dbo].[VehiclePictures] OFF
ALTER TABLE [dbo].[VehicleEngine]  WITH CHECK ADD  CONSTRAINT [FK_VehicleEngine_Vehicle] FOREIGN KEY([Id])
REFERENCES [dbo].[Vehicle] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VehicleEngine] CHECK CONSTRAINT [FK_VehicleEngine_Vehicle]
GO
ALTER TABLE [dbo].[VehicleFeature]  WITH CHECK ADD  CONSTRAINT [FK_VehicleFeature_Vehicle] FOREIGN KEY([Id])
REFERENCES [dbo].[Vehicle] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VehicleFeature] CHECK CONSTRAINT [FK_VehicleFeature_Vehicle]
GO
ALTER TABLE [dbo].[VehicleHistory]  WITH CHECK ADD  CONSTRAINT [FK_VehicleHistory_Vehicle] FOREIGN KEY([Id])
REFERENCES [dbo].[Vehicle] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VehicleHistory] CHECK CONSTRAINT [FK_VehicleHistory_Vehicle]
GO
ALTER TABLE [dbo].[VehiclePictures]  WITH CHECK ADD  CONSTRAINT [FK_VehiclePictures_Vehicle] FOREIGN KEY([VehicleID])
REFERENCES [dbo].[Vehicle] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VehiclePictures] CHECK CONSTRAINT [FK_VehiclePictures_Vehicle]
GO
USE [master]
GO
ALTER DATABASE [FamilyAuto] SET  READ_WRITE 
GO
