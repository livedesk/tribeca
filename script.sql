
USE [Clients]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 25/10/2023 17:03:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[ClientName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 25/10/2023 17:03:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[EmployeeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblEmployee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Offices]    Script Date: 25/10/2023 17:03:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offices](
	[OfficeId] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[OfficeAddress] [nvarchar](50) NOT NULL,
	[IsHeadOffice] [bit] NOT NULL,
 CONSTRAINT [PK_Offices] PRIMARY KEY CLUSTERED 
(
	[OfficeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([ClientId], [ClientName]) VALUES (1, N'Client A')
INSERT [dbo].[Clients] ([ClientId], [ClientName]) VALUES (2, N'Client B')
INSERT [dbo].[Clients] ([ClientId], [ClientName]) VALUES (3, N'Client C')
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeId], [ClientId], [EmployeeName]) VALUES (1, 1, N'Sam Fisher')
INSERT [dbo].[Employees] ([EmployeeId], [ClientId], [EmployeeName]) VALUES (2, 1, N'John Fisher')
INSERT [dbo].[Employees] ([EmployeeId], [ClientId], [EmployeeName]) VALUES (3, 1, N'Peter Fisher')
INSERT [dbo].[Employees] ([EmployeeId], [ClientId], [EmployeeName]) VALUES (4, 2, N'Sam Kemp')
INSERT [dbo].[Employees] ([EmployeeId], [ClientId], [EmployeeName]) VALUES (5, 2, N'John Kemp')
INSERT [dbo].[Employees] ([EmployeeId], [ClientId], [EmployeeName]) VALUES (6, 2, N'Peter Kemp')
INSERT [dbo].[Employees] ([EmployeeId], [ClientId], [EmployeeName]) VALUES (7, 3, N'John Doe')
INSERT [dbo].[Employees] ([EmployeeId], [ClientId], [EmployeeName]) VALUES (8, 3, N'Jane Doe')
INSERT [dbo].[Employees] ([EmployeeId], [ClientId], [EmployeeName]) VALUES (9, 3, N'Peter Doe')
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Offices] ON 

INSERT [dbo].[Offices] ([OfficeId], [ClientId], [OfficeAddress], [IsHeadOffice]) VALUES (1, 1, N'123 Street', 0)
INSERT [dbo].[Offices] ([OfficeId], [ClientId], [OfficeAddress], [IsHeadOffice]) VALUES (2, 1, N'66 Road', 0)
INSERT [dbo].[Offices] ([OfficeId], [ClientId], [OfficeAddress], [IsHeadOffice]) VALUES (3, 1, N'11 Spooner Road', 1)
INSERT [dbo].[Offices] ([OfficeId], [ClientId], [OfficeAddress], [IsHeadOffice]) VALUES (4, 2, N'123 Flight Street', 0)
INSERT [dbo].[Offices] ([OfficeId], [ClientId], [OfficeAddress], [IsHeadOffice]) VALUES (5, 2, N'64 Zoo Lane', 1)
INSERT [dbo].[Offices] ([OfficeId], [ClientId], [OfficeAddress], [IsHeadOffice]) VALUES (6, 2, N'22 Round Tree Road', 0)
INSERT [dbo].[Offices] ([OfficeId], [ClientId], [OfficeAddress], [IsHeadOffice]) VALUES (7, 3, N'33 Mile Street', 1)
INSERT [dbo].[Offices] ([OfficeId], [ClientId], [OfficeAddress], [IsHeadOffice]) VALUES (8, 3, N'66 Road', 0)
INSERT [dbo].[Offices] ([OfficeId], [ClientId], [OfficeAddress], [IsHeadOffice]) VALUES (9, 3, N'44 Sprinkle Road', 0)
SET IDENTITY_INSERT [dbo].[Offices] OFF
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Clients]
GO
ALTER TABLE [dbo].[Offices]  WITH CHECK ADD  CONSTRAINT [FK_Offices_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO
ALTER TABLE [dbo].[Offices] CHECK CONSTRAINT [FK_Offices_Clients]
GO
USE [master]
GO
ALTER DATABASE [Clients] SET  READ_WRITE 
GO
