USE LineyschikovCoreContext
GO

SET IDENTITY_INSERT [dbo].[Customers] ON
INSERT INTO [dbo].[Customers] ([Id], [Name], [Address], [Vip]) VALUES (1, N'����� �������������', N'���������', 0)
INSERT INTO [dbo].[Customers] ([Id], [Name], [Address], [Vip]) VALUES (2, N'��������� ���������', N'�������������', 0)
INSERT INTO [dbo].[Customers] ([Id], [Name], [Address], [Vip]) VALUES (3, N'������� ������������', N'������ ����', 1)
INSERT INTO [dbo].[Customers] ([Id], [Name], [Address], [Vip]) VALUES (4, N'������� ������������', N'���������', 0)
INSERT INTO [dbo].[Customers] ([Id], [Name], [Address], [Vip]) VALUES (5, N'������� ����������', N'�������', 1)
INSERT INTO [dbo].[Customers] ([Id], [Name], [Address], [Vip]) VALUES (6, N'�������� ����������', N'���������', 0)
INSERT INTO [dbo].[Customers] ([Id], [Name], [Address], [Vip]) VALUES (7, N'������ ��������������', N'��������� ����', 1)
INSERT INTO [dbo].[Customers] ([Id], [Name], [Address], [Vip]) VALUES (8, N'��������� ���������', N'������� ���', 0)
INSERT INTO [dbo].[Customers] ([Id], [Name], [Address], [Vip]) VALUES (9, N'���� �����������', N'����������', 0)
SET IDENTITY_INSERT [dbo].[Customers] OFF

SET IDENTITY_INSERT [dbo].[Orders] ON
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (1, N'��������� �����', 1)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (2, N'������ �����', 1)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (3, N'����� �����', 1)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (4, N'���������� ����� 1', 1)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (5, N'���������� ����� 2', 1)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (6, N'������� �����', 2)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (7, N'������������ �����', 2)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (8, N'���������� ����� 1', 2)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (9, N'���������� ����� 2', 2)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (10, N'���������� ����� 3', 2)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (11, N'������� �����', 3)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (12, N'����������� �����', 3)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (13, N'�������� ����� 1', 3)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (14, N'�������� ����� 2', 3)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (15, N'�������� ����� 3', 3)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (16, N'������ �����', 4)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (17, N'����� ����� �', 4)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (18, N'����� ����� �', 4)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (19, N'����� ����� �', 4)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (20, N'��������� �����', 4)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (21, N'������� �����', 5)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (22, N'����������� �����', 5)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (23, N'������� �����', 6)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (24, N'������� ����� �', 6)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (25, N'������� ����� �', 6)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (26, N'�������� �����', 7)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (27, N'������������ ����� 1', 7)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (28, N'������������ ����� 2', 7)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (29, N'���������� �����', 8)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (30, N'�������� �����', 8)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (31, N'������� �����', 8)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (32, N'������� ����� 1', 9)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (33, N'������� ����� 2', 9)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (34, N'������� ����� 3', 9)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (35, N'����������� ����� 1', 9)
INSERT INTO [dbo].[Orders] ([Id], [Description], [CustomerId]) VALUES (36, N'����������� ����� 2', 9)
SET IDENTITY_INSERT [dbo].[Orders] OFF
