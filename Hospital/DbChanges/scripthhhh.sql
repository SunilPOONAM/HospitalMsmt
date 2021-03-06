USE [Hospital]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14-02-2022 17:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Allotments]    Script Date: 14-02-2022 17:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Allotments](
	[AllotmentId] [int] IDENTITY(1,1) NOT NULL,
	[Room] [nvarchar](max) NOT NULL,
	[RoomType] [nvarchar](max) NOT NULL,
	[PatientName] [nvarchar](max) NOT NULL,
	[AllotmentDate] [datetime2](7) NOT NULL,
	[DischargeDate] [datetime2](7) NOT NULL,
	[DoctorName] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Allotments] PRIMARY KEY CLUSTERED 
(
	[AllotmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppFeatures]    Script Date: 14-02-2022 17:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppFeatures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FeatureName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_AppFeatures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 14-02-2022 17:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[AppointmentId] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[DoctorName] [nvarchar](max) NOT NULL,
	[Department] [nvarchar](max) NOT NULL,
	[TokenNumber] [nvarchar](max) NOT NULL,
	[Problem] [nvarchar](max) NOT NULL,
	[AppointmentDate] [datetime2](7) NOT NULL,
	[TimeSlot] [datetime2](7) NOT NULL,
	[AppointmentStatus] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 14-02-2022 17:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 14-02-2022 17:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 14-02-2022 17:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 14-02-2022 17:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 14-02-2022 17:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 14-02-2022 17:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserRole] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 14-02-2022 17:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 14-02-2022 17:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[DepartmentStatus] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 14-02-2022 17:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[DoctorId] [int] IDENTITY(1,1) NOT NULL,
	[DoctorName] [nvarchar](max) NULL,
	[DOB] [nvarchar](max) NULL,
	[Specialization] [nvarchar](max) NULL,
	[Experience] [nvarchar](max) NULL,
	[Age] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PhoneNo] [nvarchar](max) NULL,
	[DoctorDetails] [nvarchar](max) NULL,
	[Availiablity] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[FaxNo] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[Street] [nvarchar](max) NULL,
	[ZipCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManageFAQ]    Script Date: 14-02-2022 17:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManageFAQ](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](max) NULL,
	[Answer] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_ManageFAQ] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nurses]    Script Date: 14-02-2022 17:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nurses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationUserId] [nvarchar](450) NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[EmailAddress] [nvarchar](max) NOT NULL,
	[MobileNo] [nvarchar](max) NOT NULL,
	[Gender] [nvarchar](max) NOT NULL,
	[BloodGroup] [nvarchar](max) NOT NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[Status] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[State] [nvarchar](max) NOT NULL,
	[Street] [nvarchar](max) NOT NULL,
	[ZipCode] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Nurses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 14-02-2022 17:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[PatientID] [int] IDENTITY(1,1) NOT NULL,
	[PatientName] [nvarchar](max) NOT NULL,
	[Age] [nvarchar](max) NOT NULL,
	[Gender] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[DOB] [nvarchar](max) NOT NULL,
	[IsActive] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[Street] [nvarchar](max) NULL,
	[ZipCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[PatientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PricingPack]    Script Date: 14-02-2022 17:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PricingPack](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PlanName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[BillingPeroid] [nvarchar](max) NULL,
	[Amount] [nvarchar](max) NULL,
	[CreateDate] [nvarchar](max) NULL,
 CONSTRAINT [PK_PricingPack] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedules]    Script Date: 14-02-2022 17:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Doctor] [nvarchar](max) NULL,
	[DoctorId] [int] NOT NULL,
	[AvailableStartDay] [nvarchar](max) NOT NULL,
	[AvailableEndDay] [nvarchar](max) NOT NULL,
	[AvailableStartTime] [datetime2](7) NOT NULL,
	[AvailableEndTime] [datetime2](7) NOT NULL,
	[TimePerPatient] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Schedules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210412123329_Hospital', N'3.1.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210414071620_Doctor', N'3.1.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210414093605_Patients', N'3.1.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210414104611_Nurse', N'3.1.13')
GO
SET IDENTITY_INSERT [dbo].[Allotments] ON 

INSERT [dbo].[Allotments] ([AllotmentId], [Room], [RoomType], [PatientName], [AllotmentDate], [DischargeDate], [DoctorName], [Status]) VALUES (1, N'1', N'A.C', N'Shivani Singh', CAST(N'2021-04-14T18:24:00.0000000' AS DateTime2), CAST(N'2021-04-17T18:25:00.0000000' AS DateTime2), N'Dr.Asha', N'Not Alloted')
INSERT [dbo].[Allotments] ([AllotmentId], [Room], [RoomType], [PatientName], [AllotmentDate], [DischargeDate], [DoctorName], [Status]) VALUES (2, N'2', N'General', N'Ladu Singh', CAST(N'2021-04-08T18:25:00.0000000' AS DateTime2), CAST(N'2021-04-10T18:25:00.0000000' AS DateTime2), N'Dr.Amit Kumar', N'Not Discharge')
INSERT [dbo].[Allotments] ([AllotmentId], [Room], [RoomType], [PatientName], [AllotmentDate], [DischargeDate], [DoctorName], [Status]) VALUES (3, N'3', N'ICU', N'Ankur Singh', CAST(N'2021-04-12T18:25:00.0000000' AS DateTime2), CAST(N'2021-04-14T18:25:00.0000000' AS DateTime2), N'Dr. Pooja Rai', N'Available')
SET IDENTITY_INSERT [dbo].[Allotments] OFF
GO
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([AppointmentId], [PatientId], [DoctorName], [Department], [TokenNumber], [Problem], [AppointmentDate], [TimeSlot], [AppointmentStatus]) VALUES (1, 1, N'Dr.Asha ', N'Dentists', N'1', N'Teeth pain for two days', CAST(N'2021-04-14T00:00:00.0000000' AS DateTime2), CAST(N'2021-04-13T12:00:00.0000000' AS DateTime2), N'Active')
SET IDENTITY_INSERT [dbo].[Appointments] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2b033280-2b49-4956-8b3a-c899b3725fd5', N'HospitalAdmin', N'HOSPITALADMIN', N'a2ef38e6-520e-4ddb-89dd-5bc4fa419fc8')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'4fe88c0c-d921-4124-a223-3e67267758d3', N'Nurse', N'NURSE', N'74b64857-f050-4acb-b8fa-10379d64392c')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'55b46f88-d3ed-482a-b887-bf849a983ae7', N'Admin', N'ADMIN', N'fbe07a50-97dc-4883-9d32-01563b7574e3')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'88bd2615-9633-4c6a-b24d-93f1246f2338', N'Doctor', N'DOCTOR', N'61b865d5-1e02-424e-b365-564a75cdcd38')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4dbaa800-d8e6-4b04-9cc7-ca419ea5baf6', N'2b033280-2b49-4956-8b3a-c899b3725fd5')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'eb4df45d-6cc8-4263-bf1a-1b1e634656ff', N'4fe88c0c-d921-4124-a223-3e67267758d3')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dea8da63-4b4b-4bb7-a736-844e6cb052a3', N'55b46f88-d3ed-482a-b887-bf849a983ae7')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7ac267b5-31e9-490d-a4e8-e1aad3b73aea', N'88bd2615-9633-4c6a-b24d-93f1246f2338')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserRole]) VALUES (N'4dbaa800-d8e6-4b04-9cc7-ca419ea5baf6', N'hadmin@gmail.com', N'HADMIN@GMAIL.COM', N'hadmin@gmail.com', N'HADMIN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEGlpJISjPJp0xUJ3d+6NcCEKMbHbjFqfJMbLlOzqjLZ9wT48otb7AimlSBhezLJ84g==', N'LVNLUO2UL57BUB4ECKKT3TTJE5UNGLEP', N'c040c6b1-f293-4c87-97e7-af1abab205ab', NULL, 0, 0, NULL, 1, 0, N'HospitalAdmin')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserRole]) VALUES (N'7ac267b5-31e9-490d-a4e8-e1aad3b73aea', N'dadmin@gmail.com', N'DADMIN@GMAIL.COM', N'dadmin@gmail.com', N'DADMIN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAENGZaCevPhVzO+FGdn2OB2w7hg0ioaeBUPl6FhHHh1709We6o3xFPqpgJuwRAAm/Ow==', N'MDFURNTHYJ452ZFRCPRWCZ433NVZCPEC', N'7193f8f4-4238-4aa2-8102-221dd308bc54', NULL, 0, 0, NULL, 1, 0, N'Doctor')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserRole]) VALUES (N'dea8da63-4b4b-4bb7-a736-844e6cb052a3', N'nextolive@gmail.com', N'NEXTOLIVE@GMAIL.COM', N'nextolive@gmail.com', N'NEXTOLIVE@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEK5Zm7aSlToMuwSmAUm+wgk9TTSrTkoCCik5fUx9BoaUbg4GFNSN1VLybOOXYJy3XA==', N'B6MN2PZ6RA6KNKT4LXSBMYKG5XX6T6HW', N'3246249f-1ba8-4c3c-ac52-4c99aa8c28f2', NULL, 0, 0, NULL, 1, 0, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserRole]) VALUES (N'eb4df45d-6cc8-4263-bf1a-1b1e634656ff', N'nadmin@gmail.com', N'NADMIN@GMAIL.COM', N'nadmin@gmail.com', N'NADMIN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEI3/TR5iHUqFSBKY3rZKdSV+IGwi0dlRXxAIMKAGg53//xbKYTLhZ3fJHvHsJTIVTQ==', N'QBBC2W7D7OYBLZ4B7QWJ5K7RIAFFIBMX', N'4cbed6e7-b2b4-465e-81ec-358954ba753d', NULL, 0, 0, NULL, 1, 0, N'Nurse')
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([DepartmentID], [DepartmentName], [Description], [DepartmentStatus]) VALUES (1, N'Other Department', N'Some problem', N'Active')
INSERT [dbo].[Departments] ([DepartmentID], [DepartmentName], [Description], [DepartmentStatus]) VALUES (2, N'Testing', N'All types testing', N'IsActive')
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[Doctor] ON 

INSERT [dbo].[Doctor] ([DoctorId], [DoctorName], [DOB], [Specialization], [Experience], [Age], [Email], [PhoneNo], [DoctorDetails], [Availiablity], [City], [Country], [FaxNo], [Password], [State], [Street], [ZipCode]) VALUES (1, N'Dr.Asha', N'1980-08-09', N'Sugar', N'12', N'40', N'pradeep@gmail.om', N'08776521063', N'Hardworking', N'Available', N'Ayodhya', N'India', N'7687574', NULL, N'up', N'90/1', N'224123')
INSERT [dbo].[Doctor] ([DoctorId], [DoctorName], [DOB], [Specialization], [Experience], [Age], [Email], [PhoneNo], [DoctorDetails], [Availiablity], [City], [Country], [FaxNo], [Password], [State], [Street], [ZipCode]) VALUES (2, N'Dr. Pooja Rai', N'1975-06-13', N'Blood Pressure', N'8', N'45', N'pooja@gmail.com', N'875654321', N'Honesty on own work', N'Not Available', N'Lucknow', N'India', N'56463623', NULL, N'Up', N'2/3', N'226001')
INSERT [dbo].[Doctor] ([DoctorId], [DoctorName], [DOB], [Specialization], [Experience], [Age], [Email], [PhoneNo], [DoctorDetails], [Availiablity], [City], [Country], [FaxNo], [Password], [State], [Street], [ZipCode]) VALUES (3, N'Dr.Rohit Kumar', N'1987-11-14', N'Liver', N'3', N'33', N'rohit@gmail.com', N'654554801', N'Welfare', N'On Leave', N'Knpur', N'U.s', N'3425265', NULL, N'Bihar', N'10', N'227001')
INSERT [dbo].[Doctor] ([DoctorId], [DoctorName], [DOB], [Specialization], [Experience], [Age], [Email], [PhoneNo], [DoctorDetails], [Availiablity], [City], [Country], [FaxNo], [Password], [State], [Street], [ZipCode]) VALUES (1004, N'Dr.Pradeep Kumar', N'1977-06-09', N'Brain', N'15', N'43', N'pradeep@gmail.om', N'8776521063', N'Honesty', N'Available', N'Ayodhya', N'AT', N'54646456', NULL, N'up', N'90/1', N'224123')
INSERT [dbo].[Doctor] ([DoctorId], [DoctorName], [DOB], [Specialization], [Experience], [Age], [Email], [PhoneNo], [DoctorDetails], [Availiablity], [City], [Country], [FaxNo], [Password], [State], [Street], [ZipCode]) VALUES (1005, N'Ashish', N'1979-05-15', N'Cancer', N'10', N'41', N'Ashish@gmail.com', N'675745712', N'Welfare', N'On Leave', N'Delhi', N'IT', N'09875663', NULL, N'Delhi', N'12', N'23421')
INSERT [dbo].[Doctor] ([DoctorId], [DoctorName], [DOB], [Specialization], [Experience], [Age], [Email], [PhoneNo], [DoctorDetails], [Availiablity], [City], [Country], [FaxNo], [Password], [State], [Street], [ZipCode]) VALUES (1007, N'Dr.Pradeep Kumar', N'1975-12-12', N'Heart', N'12', N'45', N'praddep@gmail.com', N'08776521063', N'Honesty', N'Available', N'Ayodhya', N'IN', N'076757474', NULL, N'up', N'90/1', N'224123')
INSERT [dbo].[Doctor] ([DoctorId], [DoctorName], [DOB], [Specialization], [Experience], [Age], [Email], [PhoneNo], [DoctorDetails], [Availiablity], [City], [Country], [FaxNo], [Password], [State], [Street], [ZipCode]) VALUES (1008, N'Dr.Pradeep Kumar', N'1999-02-22', N'Sugar', N'12', N'22', N'hadmin@gmail.com', N'675745712', N'ryhryfhnrfy', N'Available', N'Delhi', N'IT', N'27545278', NULL, N'Delhi', N'12', N'23421')
SET IDENTITY_INSERT [dbo].[Doctor] OFF
GO
SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([PatientID], [PatientName], [Age], [Gender], [Email], [Phone], [DOB], [IsActive], [City], [Country], [State], [Street], [ZipCode]) VALUES (1, N'Nidhi Patel', N'10', N'Female', N'pradeep@gmail.om', N'08776521063', N'2010-05-06', N'IsActive', N'Lucknow', N'IN', N'Up', N'2/3', N'226001')
INSERT [dbo].[Patients] ([PatientID], [PatientName], [Age], [Gender], [Email], [Phone], [DOB], [IsActive], [City], [Country], [State], [Street], [ZipCode]) VALUES (2, N'Ladu Singh', N'3', N'Male', N'pradeep@gmail.om', N'08776521063', N'2018-01-20', N'Active', N'Ayodhya', N'IN', N'up', N'90/1', N'224123')
SET IDENTITY_INSERT [dbo].[Patients] OFF
GO
SET IDENTITY_INSERT [dbo].[PricingPack] ON 

INSERT [dbo].[PricingPack] ([id], [PlanName], [Description], [BillingPeroid], [Amount], [CreateDate]) VALUES (1, N'Testing', N'Low working', N'1 year', N'1000', N'2021-04-14')
INSERT [dbo].[PricingPack] ([id], [PlanName], [Description], [BillingPeroid], [Amount], [CreateDate]) VALUES (2, N'Free Checkup', N'Feeling proud', N'15 days', N'150', N'2021-04-23')
SET IDENTITY_INSERT [dbo].[PricingPack] OFF
GO
SET IDENTITY_INSERT [dbo].[Schedules] ON 

INSERT [dbo].[Schedules] ([Id], [Doctor], [DoctorId], [AvailableStartDay], [AvailableEndDay], [AvailableStartTime], [AvailableEndTime], [TimePerPatient], [Status]) VALUES (1, N'Dr. Pooja Rai', 0, N'Monday', N'Tuesday', CAST(N'2021-04-13T17:30:00.0000000' AS DateTime2), CAST(N'2021-04-13T21:30:00.0000000' AS DateTime2), N'5', N'IsActive')
INSERT [dbo].[Schedules] ([Id], [Doctor], [DoctorId], [AvailableStartDay], [AvailableEndDay], [AvailableStartTime], [AvailableEndTime], [TimePerPatient], [Status]) VALUES (2, N'Dr.Asha ', 0, N'Wednesday', N'Friday', CAST(N'2021-04-13T10:30:00.0000000' AS DateTime2), CAST(N'2021-04-13T01:30:00.0000000' AS DateTime2), N'2', N'Active')
SET IDENTITY_INSERT [dbo].[Schedules] OFF
GO
ALTER TABLE [dbo].[Nurses] ADD  DEFAULT (N'') FOR [City]
GO
ALTER TABLE [dbo].[Nurses] ADD  DEFAULT (N'') FOR [Country]
GO
ALTER TABLE [dbo].[Nurses] ADD  DEFAULT (N'') FOR [Password]
GO
ALTER TABLE [dbo].[Nurses] ADD  DEFAULT (N'') FOR [State]
GO
ALTER TABLE [dbo].[Nurses] ADD  DEFAULT (N'') FOR [Street]
GO
ALTER TABLE [dbo].[Nurses] ADD  DEFAULT (N'') FOR [ZipCode]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Nurses]  WITH CHECK ADD  CONSTRAINT [FK_Nurses_AspNetUsers_ApplicationUserId] FOREIGN KEY([ApplicationUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Nurses] CHECK CONSTRAINT [FK_Nurses_AspNetUsers_ApplicationUserId]
GO
