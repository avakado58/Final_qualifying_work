USE [master]
GO
/****** Object:  Database [Personel_accounting]    Script Date: 19.04.2021 9:45:21 ******/
CREATE DATABASE [Personel_accounting]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Personel_accounting', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Personel_accounting.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Personel_accounting_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Personel_accounting_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Personel_accounting] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Personel_accounting].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Personel_accounting] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Personel_accounting] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Personel_accounting] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Personel_accounting] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Personel_accounting] SET ARITHABORT OFF 
GO
ALTER DATABASE [Personel_accounting] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Personel_accounting] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Personel_accounting] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Personel_accounting] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Personel_accounting] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Personel_accounting] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Personel_accounting] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Personel_accounting] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Personel_accounting] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Personel_accounting] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Personel_accounting] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Personel_accounting] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Personel_accounting] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Personel_accounting] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Personel_accounting] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Personel_accounting] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Personel_accounting] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Personel_accounting] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Personel_accounting] SET  MULTI_USER 
GO
ALTER DATABASE [Personel_accounting] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Personel_accounting] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Personel_accounting] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Personel_accounting] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Personel_accounting] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Personel_accounting] SET QUERY_STORE = OFF
GO
USE [Personel_accounting]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Personel_accounting]
GO
/****** Object:  Table [dbo].[Вакансия]    Script Date: 19.04.2021 9:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Вакансия](
	[Код вакансии] [int] IDENTITY(1,1) NOT NULL,
	[Код должности] [int] NOT NULL,
	[Дата объявления] [date] NOT NULL,
 CONSTRAINT [PK_Вакансия] PRIMARY KEY CLUSTERED 
(
	[Код вакансии] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Вид отпуска]    Script Date: 19.04.2021 9:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Вид отпуска](
	[Код вида отпуска] [int] IDENTITY(1,1) NOT NULL,
	[Вид отпуска] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Вид отпуска] PRIMARY KEY CLUSTERED 
(
	[Код вида отпуска] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Должность]    Script Date: 19.04.2021 9:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Должность](
	[Код должности] [int] IDENTITY(1,1) NOT NULL,
	[Должность] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Должность] PRIMARY KEY CLUSTERED 
(
	[Код должности] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Квалификация]    Script Date: 19.04.2021 9:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Квалификация](
	[Код квалификации] [int] IDENTITY(1,1) NOT NULL,
	[Код сотрудника] [int] NOT NULL,
	[Дата] [date] NOT NULL,
	[Вид квалификации] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Квалификация] PRIMARY KEY CLUSTERED 
(
	[Код квалификации] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Образование]    Script Date: 19.04.2021 9:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Образование](
	[Код образования] [int] IDENTITY(1,1) NOT NULL,
	[Учебное заведение] [nvarchar](200) NULL,
	[Диплом] [nvarchar](50) NULL,
	[Год окончания] [int] NULL,
	[Квалификация] [nvarchar](30) NULL,
	[Код сотрудника] [int] NULL,
 CONSTRAINT [PK_Образование] PRIMARY KEY CLUSTERED 
(
	[Код образования] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Отпуск]    Script Date: 19.04.2021 9:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Отпуск](
	[Код отпуска] [int] IDENTITY(1,1) NOT NULL,
	[Код сотрудника] [int] NOT NULL,
	[Код вида отпуска] [int] NOT NULL,
	[Дата начала] [date] NOT NULL,
	[Дата окончания] [date] NOT NULL,
 CONSTRAINT [PK_Отпуск] PRIMARY KEY CLUSTERED 
(
	[Код отпуска] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Семейное положение]    Script Date: 19.04.2021 9:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Семейное положение](
	[Код положения] [int] IDENTITY(1,1) NOT NULL,
	[Семейное положение] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Семейное положение] PRIMARY KEY CLUSTERED 
(
	[Код положения] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Семья]    Script Date: 19.04.2021 9:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Семья](
	[Код семьи] [int] IDENTITY(1,1) NOT NULL,
	[ФИО] [nvarchar](100) NULL,
	[Дата рождения] [date] NULL,
	[Количество детей] [nvarchar](50) NULL,
	[Код сотрудника] [int] NULL,
 CONSTRAINT [PK_Семья] PRIMARY KEY CLUSTERED 
(
	[Код семьи] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Сотрудник]    Script Date: 19.04.2021 9:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Сотрудник](
	[Код сотрудника] [int] IDENTITY(1,1) NOT NULL,
	[ФИО] [nvarchar](100) NOT NULL,
	[Дата рождения] [date] NOT NULL,
	[Адрес] [nvarchar](200) NOT NULL,
	[Номер телефона] [nvarchar](20) NOT NULL,
	[Код должности] [int] NOT NULL,
	[Код положения] [int] NOT NULL,
 CONSTRAINT [PK_Сотрудник] PRIMARY KEY CLUSTERED 
(
	[Код сотрудника] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Увольнение]    Script Date: 19.04.2021 9:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Увольнение](
	[Код увольнения] [int] IDENTITY(1,1) NOT NULL,
	[ФИО] [nvarchar](50) NULL,
	[Дата увольнения] [date] NULL,
	[Причина] [nvarchar](50) NULL,
	[Номер приказа] [nvarchar](10) NULL,
 CONSTRAINT [PK_Увольнение] PRIMARY KEY CLUSTERED 
(
	[Код увольнения] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Вакансия] ON 

INSERT [dbo].[Вакансия] ([Код вакансии], [Код должности], [Дата объявления]) VALUES (1, 8, CAST(N'2021-04-22' AS Date))
INSERT [dbo].[Вакансия] ([Код вакансии], [Код должности], [Дата объявления]) VALUES (2, 9, CAST(N'2021-04-22' AS Date))
INSERT [dbo].[Вакансия] ([Код вакансии], [Код должности], [Дата объявления]) VALUES (3, 10, CAST(N'2021-04-24' AS Date))
INSERT [dbo].[Вакансия] ([Код вакансии], [Код должности], [Дата объявления]) VALUES (4, 11, CAST(N'2021-04-26' AS Date))
INSERT [dbo].[Вакансия] ([Код вакансии], [Код должности], [Дата объявления]) VALUES (5, 11, CAST(N'2021-04-30' AS Date))
INSERT [dbo].[Вакансия] ([Код вакансии], [Код должности], [Дата объявления]) VALUES (6, 12, CAST(N'2021-04-19' AS Date))
INSERT [dbo].[Вакансия] ([Код вакансии], [Код должности], [Дата объявления]) VALUES (7, 12, CAST(N'2021-04-22' AS Date))
INSERT [dbo].[Вакансия] ([Код вакансии], [Код должности], [Дата объявления]) VALUES (8, 13, CAST(N'2021-04-24' AS Date))
INSERT [dbo].[Вакансия] ([Код вакансии], [Код должности], [Дата объявления]) VALUES (9, 8, CAST(N'2021-04-29' AS Date))
SET IDENTITY_INSERT [dbo].[Вакансия] OFF
SET IDENTITY_INSERT [dbo].[Вид отпуска] ON 

INSERT [dbo].[Вид отпуска] ([Код вида отпуска], [Вид отпуска]) VALUES (1, N'Основной отпуск')
INSERT [dbo].[Вид отпуска] ([Код вида отпуска], [Вид отпуска]) VALUES (2, N'Дополнительный отпуск')
INSERT [dbo].[Вид отпуска] ([Код вида отпуска], [Вид отпуска]) VALUES (3, N'Отпуск без сохранения з/п')
SET IDENTITY_INSERT [dbo].[Вид отпуска] OFF
SET IDENTITY_INSERT [dbo].[Должность] ON 

INSERT [dbo].[Должность] ([Код должности], [Должность]) VALUES (1, N'Генеральный директор')
INSERT [dbo].[Должность] ([Код должности], [Должность]) VALUES (2, N'Секретарь')
INSERT [dbo].[Должность] ([Код должности], [Должность]) VALUES (3, N'Начальник склада')
INSERT [dbo].[Должность] ([Код должности], [Должность]) VALUES (4, N'Начальник логистики')
INSERT [dbo].[Должность] ([Код должности], [Должность]) VALUES (5, N'Начальник транспортного отдела')
INSERT [dbo].[Должность] ([Код должности], [Должность]) VALUES (6, N'Начальник отдела кадров')
INSERT [dbo].[Должность] ([Код должности], [Должность]) VALUES (7, N'Главный бухгалтер')
INSERT [dbo].[Должность] ([Код должности], [Должность]) VALUES (8, N'Грузчик')
INSERT [dbo].[Должность] ([Код должности], [Должность]) VALUES (9, N'Складской рабочий')
INSERT [dbo].[Должность] ([Код должности], [Должность]) VALUES (10, N'Менеджер по логистике')
INSERT [dbo].[Должность] ([Код должности], [Должность]) VALUES (11, N'Диспетчер')
INSERT [dbo].[Должность] ([Код должности], [Должность]) VALUES (12, N'Водитель')
INSERT [dbo].[Должность] ([Код должности], [Должность]) VALUES (13, N'Кассир')
SET IDENTITY_INSERT [dbo].[Должность] OFF
SET IDENTITY_INSERT [dbo].[Квалификация] ON 

INSERT [dbo].[Квалификация] ([Код квалификации], [Код сотрудника], [Дата], [Вид квалификации]) VALUES (1, 2, CAST(N'2021-04-13' AS Date), N'Повышение квалификации в должности начальника отдела продаж ООО "Рекон"')
INSERT [dbo].[Квалификация] ([Код квалификации], [Код сотрудника], [Дата], [Вид квалификации]) VALUES (2, 3, CAST(N'2021-04-15' AS Date), N'Повышение квалификации в должности заместителя начальника директора')
INSERT [dbo].[Квалификация] ([Код квалификации], [Код сотрудника], [Дата], [Вид квалификации]) VALUES (3, 4, CAST(N'2021-04-30' AS Date), N'Повышение квалификации в должности начальника склада')
INSERT [dbo].[Квалификация] ([Код квалификации], [Код сотрудника], [Дата], [Вид квалификации]) VALUES (4, 5, CAST(N'2021-04-27' AS Date), N'Повышение квалификации в должности начальника логистики')
INSERT [dbo].[Квалификация] ([Код квалификации], [Код сотрудника], [Дата], [Вид квалификации]) VALUES (5, 6, CAST(N'2021-04-15' AS Date), N'Повышение квалификации в должности главного бухгалтера')
INSERT [dbo].[Квалификация] ([Код квалификации], [Код сотрудника], [Дата], [Вид квалификации]) VALUES (6, 7, CAST(N'2021-05-07' AS Date), N'Повышение квалификации в должности начальника отдела кадров')
INSERT [dbo].[Квалификация] ([Код квалификации], [Код сотрудника], [Дата], [Вид квалификации]) VALUES (7, 8, CAST(N'2021-05-05' AS Date), N'Повышение квалификации в должности диспетчера')
INSERT [dbo].[Квалификация] ([Код квалификации], [Код сотрудника], [Дата], [Вид квалификации]) VALUES (8, 9, CAST(N'2021-04-22' AS Date), N'Повышение квалификации в должности старшего диспетчера')
SET IDENTITY_INSERT [dbo].[Квалификация] OFF
SET IDENTITY_INSERT [dbo].[Образование] ON 

INSERT [dbo].[Образование] ([Код образования], [Учебное заведение], [Диплом], [Год окончания], [Квалификация], [Код сотрудника]) VALUES (1, N'Северо-Кавказский федеральный университет', N'ЕН 897845', 2003, N'Строительство', 1)
INSERT [dbo].[Образование] ([Код образования], [Учебное заведение], [Диплом], [Год окончания], [Квалификация], [Код сотрудника]) VALUES (2, N'Северо-Кавказский федеральный университет', N'ДС 363636', 2008, N'Химическая технология', 2)
INSERT [dbo].[Образование] ([Код образования], [Учебное заведение], [Диплом], [Год окончания], [Квалификация], [Код сотрудника]) VALUES (3, N'Ставропольский государственный университет', N'ЕН 343423', 2006, N'Машиностроение', 3)
INSERT [dbo].[Образование] ([Код образования], [Учебное заведение], [Диплом], [Год окончания], [Квалификация], [Код сотрудника]) VALUES (4, N'Ставропольский государственный аграрный университет', N'ПЕ 562314', 1998, N'Землеустройство', 4)
INSERT [dbo].[Образование] ([Код образования], [Учебное заведение], [Диплом], [Год окончания], [Квалификация], [Код сотрудника]) VALUES (5, N'Северо-Кавказкий гуманитарный институт', N'АС 232345', 2008, N'Экономика', 5)
INSERT [dbo].[Образование] ([Код образования], [Учебное заведение], [Диплом], [Год окончания], [Квалификация], [Код сотрудника]) VALUES (6, N'Ставропольский государственный университет', N'АП 343421', 2012, N'Менеджмент', 6)
INSERT [dbo].[Образование] ([Код образования], [Учебное заведение], [Диплом], [Год окончания], [Квалификация], [Код сотрудника]) VALUES (7, N'Ставропольский государственный аграрный университет', N'НЕ 383281', 2010, N'Строительство', 7)
INSERT [dbo].[Образование] ([Код образования], [Учебное заведение], [Диплом], [Год окончания], [Квалификация], [Код сотрудника]) VALUES (8, N'Ставропольский государственный университет', N'АК 234563', 2002, N'Строительство', 8)
INSERT [dbo].[Образование] ([Код образования], [Учебное заведение], [Диплом], [Год окончания], [Квалификация], [Код сотрудника]) VALUES (9, N'Донской государственный технический университет', N'РН 435453', 2013, N'Радиотехника', 9)
INSERT [dbo].[Образование] ([Код образования], [Учебное заведение], [Диплом], [Год окончания], [Квалификация], [Код сотрудника]) VALUES (10, N'Ставропольский техникум', N'АР 345634', 2009, N'Инженер', 10)
INSERT [dbo].[Образование] ([Код образования], [Учебное заведение], [Диплом], [Год окончания], [Квалификация], [Код сотрудника]) VALUES (11, N'Ставропольский техникум', N'АК 230967', 2014, N'Инженер', 11)
SET IDENTITY_INSERT [dbo].[Образование] OFF
SET IDENTITY_INSERT [dbo].[Отпуск] ON 

INSERT [dbo].[Отпуск] ([Код отпуска], [Код сотрудника], [Код вида отпуска], [Дата начала], [Дата окончания]) VALUES (1, 1, 1, CAST(N'2021-06-01' AS Date), CAST(N'2021-06-28' AS Date))
INSERT [dbo].[Отпуск] ([Код отпуска], [Код сотрудника], [Код вида отпуска], [Дата начала], [Дата окончания]) VALUES (2, 2, 1, CAST(N'2021-06-22' AS Date), CAST(N'2021-07-14' AS Date))
INSERT [dbo].[Отпуск] ([Код отпуска], [Код сотрудника], [Код вида отпуска], [Дата начала], [Дата окончания]) VALUES (3, 3, 1, CAST(N'2021-04-15' AS Date), CAST(N'2021-04-29' AS Date))
INSERT [dbo].[Отпуск] ([Код отпуска], [Код сотрудника], [Код вида отпуска], [Дата начала], [Дата окончания]) VALUES (4, 4, 2, CAST(N'2021-04-30' AS Date), CAST(N'2021-05-07' AS Date))
INSERT [dbo].[Отпуск] ([Код отпуска], [Код сотрудника], [Код вида отпуска], [Дата начала], [Дата окончания]) VALUES (5, 5, 1, CAST(N'2021-05-08' AS Date), CAST(N'2021-05-12' AS Date))
INSERT [dbo].[Отпуск] ([Код отпуска], [Код сотрудника], [Код вида отпуска], [Дата начала], [Дата окончания]) VALUES (6, 6, 1, CAST(N'2021-05-27' AS Date), CAST(N'2021-06-24' AS Date))
INSERT [dbo].[Отпуск] ([Код отпуска], [Код сотрудника], [Код вида отпуска], [Дата начала], [Дата окончания]) VALUES (7, 7, 1, CAST(N'2021-06-24' AS Date), CAST(N'2021-07-16' AS Date))
INSERT [dbo].[Отпуск] ([Код отпуска], [Код сотрудника], [Код вида отпуска], [Дата начала], [Дата окончания]) VALUES (8, 8, 2, CAST(N'2021-04-15' AS Date), CAST(N'2021-04-18' AS Date))
INSERT [dbo].[Отпуск] ([Код отпуска], [Код сотрудника], [Код вида отпуска], [Дата начала], [Дата окончания]) VALUES (9, 9, 1, CAST(N'2021-04-15' AS Date), CAST(N'2021-05-08' AS Date))
INSERT [dbo].[Отпуск] ([Код отпуска], [Код сотрудника], [Код вида отпуска], [Дата начала], [Дата окончания]) VALUES (10, 10, 1, CAST(N'2021-05-20' AS Date), CAST(N'2021-05-29' AS Date))
INSERT [dbo].[Отпуск] ([Код отпуска], [Код сотрудника], [Код вида отпуска], [Дата начала], [Дата окончания]) VALUES (11, 11, 3, CAST(N'2021-04-16' AS Date), CAST(N'2021-04-22' AS Date))
INSERT [dbo].[Отпуск] ([Код отпуска], [Код сотрудника], [Код вида отпуска], [Дата начала], [Дата окончания]) VALUES (12, 1, 1, CAST(N'2021-07-07' AS Date), CAST(N'2021-07-16' AS Date))
SET IDENTITY_INSERT [dbo].[Отпуск] OFF
SET IDENTITY_INSERT [dbo].[Семейное положение] ON 

INSERT [dbo].[Семейное положение] ([Код положения], [Семейное положение]) VALUES (1, N'Не замужем / Не женат')
INSERT [dbo].[Семейное положение] ([Код положения], [Семейное положение]) VALUES (2, N'Разведен / Разведена')
INSERT [dbo].[Семейное положение] ([Код положения], [Семейное положение]) VALUES (3, N'Замужем / Женат')
SET IDENTITY_INSERT [dbo].[Семейное положение] OFF
SET IDENTITY_INSERT [dbo].[Семья] ON 

INSERT [dbo].[Семья] ([Код семьи], [ФИО], [Дата рождения], [Количество детей], [Код сотрудника]) VALUES (1, N'Жбанова Светлана Николаевна', CAST(N'1964-06-11' AS Date), N'2', 1)
INSERT [dbo].[Семья] ([Код семьи], [ФИО], [Дата рождения], [Количество детей], [Код сотрудника]) VALUES (2, N'Панфилов Сергей Васильевич', CAST(N'1985-12-25' AS Date), N'1', 2)
INSERT [dbo].[Семья] ([Код семьи], [ФИО], [Дата рождения], [Количество детей], [Код сотрудника]) VALUES (3, N'Зорин Владимир Николаевич', CAST(N'1978-10-26' AS Date), N'1', 4)
INSERT [dbo].[Семья] ([Код семьи], [ФИО], [Дата рождения], [Количество детей], [Код сотрудника]) VALUES (4, N'Семенова Олеся Игоревна', CAST(N'1989-10-19' AS Date), N'1', 5)
INSERT [dbo].[Семья] ([Код семьи], [ФИО], [Дата рождения], [Количество детей], [Код сотрудника]) VALUES (5, N'Соколов Василий Иосифович', CAST(N'1989-01-03' AS Date), N'2', 6)
INSERT [dbo].[Семья] ([Код семьи], [ФИО], [Дата рождения], [Количество детей], [Код сотрудника]) VALUES (6, N'Коротков Михаил петрович', CAST(N'1993-05-03' AS Date), N'1', 7)
INSERT [dbo].[Семья] ([Код семьи], [ФИО], [Дата рождения], [Количество детей], [Код сотрудника]) VALUES (7, N'Мещерякова Светлана Игоревна', CAST(N'1978-10-25' AS Date), N'2', 8)
INSERT [dbo].[Семья] ([Код семьи], [ФИО], [Дата рождения], [Количество детей], [Код сотрудника]) VALUES (8, N'Ефимова Тамара Николаевна', CAST(N'1993-05-04' AS Date), N'1', 9)
INSERT [dbo].[Семья] ([Код семьи], [ФИО], [Дата рождения], [Количество детей], [Код сотрудника]) VALUES (9, N'Алешина Ева Максимовна', CAST(N'1989-05-16' AS Date), N'0', 11)
SET IDENTITY_INSERT [dbo].[Семья] OFF
SET IDENTITY_INSERT [dbo].[Сотрудник] ON 

INSERT [dbo].[Сотрудник] ([Код сотрудника], [ФИО], [Дата рождения], [Адрес], [Номер телефона], [Код должности], [Код положения]) VALUES (1, N'Жбанов Анатолий Сергеевич', CAST(N'1965-07-12' AS Date), N'г. Ставрополь, ул. Вялова д.5 кв.35', N'8 956 454 78 12', 1, 3)
INSERT [dbo].[Сотрудник] ([Код сотрудника], [ФИО], [Дата рождения], [Адрес], [Номер телефона], [Код должности], [Код положения]) VALUES (2, N'Панфилова София Андреевна', CAST(N'1985-12-05' AS Date), N'г. Ставрополь, ул. Тирина д. 3 кв. 57', N'8 999 202 45 06', 2, 3)
INSERT [dbo].[Сотрудник] ([Код сотрудника], [ФИО], [Дата рождения], [Адрес], [Номер телефона], [Код должности], [Код положения]) VALUES (3, N'Захаров Матвей Михайлович', CAST(N'1984-06-13' AS Date), N'г. Ставрополь, ул. Гирина д.3 кв.45', N'8-988-987-56-56', 3, 1)
INSERT [dbo].[Сотрудник] ([Код сотрудника], [ФИО], [Дата рождения], [Адрес], [Номер телефона], [Код должности], [Код положения]) VALUES (4, N'Зорина Диана Максимовна', CAST(N'1977-09-20' AS Date), N'г. Ставрополь, ул. Вялова д.5 кв.34', N'8-965-652-65-98', 4, 3)
INSERT [dbo].[Сотрудник] ([Код сотрудника], [ФИО], [Дата рождения], [Адрес], [Номер телефона], [Код должности], [Код положения]) VALUES (5, N'Семенов Владимир Львович', CAST(N'1984-06-14' AS Date), N'г. Ставрополь, ул. Вязова д.3 кв.1', N'8-945-656-23-12', 5, 3)
INSERT [dbo].[Сотрудник] ([Код сотрудника], [ФИО], [Дата рождения], [Адрес], [Номер телефона], [Код должности], [Код положения]) VALUES (6, N'Соколова Дарья Демьяновна', CAST(N'2021-04-15' AS Date), N'г. Ставрополь, ул. Долгова д.2 кв.3', N'8-987-365-56-98', 6, 3)
INSERT [dbo].[Сотрудник] ([Код сотрудника], [ФИО], [Дата рождения], [Адрес], [Номер телефона], [Код должности], [Код положения]) VALUES (7, N'Короткова Надежда Михайловна', CAST(N'1988-06-15' AS Date), N'г. Ставрополь, ул. Васина д.6 кв.5', N'8-965-321-65-98', 7, 3)
INSERT [dbo].[Сотрудник] ([Код сотрудника], [ФИО], [Дата рождения], [Адрес], [Номер телефона], [Код должности], [Код положения]) VALUES (8, N'Мещеряков Егор Алексеевич', CAST(N'1977-09-20' AS Date), N'г. Ставрополь, ул. Жекина д.7 кв.3', N'8-989-456-92-98', 10, 3)
INSERT [dbo].[Сотрудник] ([Код сотрудника], [ФИО], [Дата рождения], [Адрес], [Номер телефона], [Код должности], [Код положения]) VALUES (9, N'Ефимов Павел Ярославович', CAST(N'1989-01-05' AS Date), N'г. Ставрополь, ул. Лесная д.6 кв. 65', N'8-972-985-36-65', 11, 3)
INSERT [dbo].[Сотрудник] ([Код сотрудника], [ФИО], [Дата рождения], [Адрес], [Номер телефона], [Код должности], [Код положения]) VALUES (10, N'Соловьев Тимофей Константинович', CAST(N'1991-01-30' AS Date), N'г. Ставрополь, ул. Летова д.4 кв. 5', N'8-989-565-65-56', 8, 2)
INSERT [dbo].[Сотрудник] ([Код сотрудника], [ФИО], [Дата рождения], [Адрес], [Номер телефона], [Код должности], [Код положения]) VALUES (11, N'Алешин Владимир Владимирович', CAST(N'1993-05-11' AS Date), N'г. Ставрополь, ул. Жекина д.12 кв.23', N'8-902-565-89-02', 12, 3)
SET IDENTITY_INSERT [dbo].[Сотрудник] OFF
SET IDENTITY_INSERT [dbo].[Увольнение] ON 

INSERT [dbo].[Увольнение] ([Код увольнения], [ФИО], [Дата увольнения], [Причина], [Номер приказа]) VALUES (5, N'Маслова Таисия Александровна', CAST(N'2021-04-17' AS Date), N'По собственному желанию', N'12Б')
INSERT [dbo].[Увольнение] ([Код увольнения], [ФИО], [Дата увольнения], [Причина], [Номер приказа]) VALUES (6, N'Тихонов Степан Павлович', CAST(N'2021-04-17' AS Date), N'По собственному желанию', N'12Б')
INSERT [dbo].[Увольнение] ([Код увольнения], [ФИО], [Дата увольнения], [Причина], [Номер приказа]) VALUES (7, N'Прокофьева Дарья Ярославовна', CAST(N'2021-04-17' AS Date), N'Не соответствие условиям договора', N'23Б')
INSERT [dbo].[Увольнение] ([Код увольнения], [ФИО], [Дата увольнения], [Причина], [Номер приказа]) VALUES (8, N'Дегтярева Алиса Артёмовна', CAST(N'2021-04-18' AS Date), N'Не соответствие условиям договора', N'23Б')
SET IDENTITY_INSERT [dbo].[Увольнение] OFF
ALTER TABLE [dbo].[Вакансия]  WITH CHECK ADD  CONSTRAINT [FK_Вакансия_Должность] FOREIGN KEY([Код должности])
REFERENCES [dbo].[Должность] ([Код должности])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Вакансия] CHECK CONSTRAINT [FK_Вакансия_Должность]
GO
ALTER TABLE [dbo].[Квалификация]  WITH CHECK ADD  CONSTRAINT [FK_Квалификация_Сотрудник1] FOREIGN KEY([Код сотрудника])
REFERENCES [dbo].[Сотрудник] ([Код сотрудника])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Квалификация] CHECK CONSTRAINT [FK_Квалификация_Сотрудник1]
GO
ALTER TABLE [dbo].[Образование]  WITH CHECK ADD  CONSTRAINT [FK_Образование_Сотрудник1] FOREIGN KEY([Код сотрудника])
REFERENCES [dbo].[Сотрудник] ([Код сотрудника])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Образование] CHECK CONSTRAINT [FK_Образование_Сотрудник1]
GO
ALTER TABLE [dbo].[Отпуск]  WITH CHECK ADD  CONSTRAINT [FK_Отпуск_Вид отпуска] FOREIGN KEY([Код вида отпуска])
REFERENCES [dbo].[Вид отпуска] ([Код вида отпуска])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Отпуск] CHECK CONSTRAINT [FK_Отпуск_Вид отпуска]
GO
ALTER TABLE [dbo].[Отпуск]  WITH CHECK ADD  CONSTRAINT [FK_Отпуск_Сотрудник1] FOREIGN KEY([Код сотрудника])
REFERENCES [dbo].[Сотрудник] ([Код сотрудника])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Отпуск] CHECK CONSTRAINT [FK_Отпуск_Сотрудник1]
GO
ALTER TABLE [dbo].[Семья]  WITH CHECK ADD  CONSTRAINT [FK_Семья_Сотрудник1] FOREIGN KEY([Код сотрудника])
REFERENCES [dbo].[Сотрудник] ([Код сотрудника])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Семья] CHECK CONSTRAINT [FK_Семья_Сотрудник1]
GO
ALTER TABLE [dbo].[Сотрудник]  WITH CHECK ADD  CONSTRAINT [FK_Сотрудник_Должность] FOREIGN KEY([Код должности])
REFERENCES [dbo].[Должность] ([Код должности])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Сотрудник] CHECK CONSTRAINT [FK_Сотрудник_Должность]
GO
ALTER TABLE [dbo].[Сотрудник]  WITH CHECK ADD  CONSTRAINT [FK_Сотрудник_Семейное положение] FOREIGN KEY([Код положения])
REFERENCES [dbo].[Семейное положение] ([Код положения])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Сотрудник] CHECK CONSTRAINT [FK_Сотрудник_Семейное положение]
GO
USE [master]
GO
ALTER DATABASE [Personel_accounting] SET  READ_WRITE 
GO
