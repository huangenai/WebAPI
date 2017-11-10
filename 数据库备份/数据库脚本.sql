if exists (select * from sysobjects where id = OBJECT_ID('[UserDevice]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [UserDevice]

CREATE TABLE [UserDevice] (
[UserDeviceID] [int]  IDENTITY (1, 1)  NOT NULL,
[UserId] [int]  NULL,
[IP] [nvarchar]  (100) NULL,
[ActiveTime] [datetime]  NULL,
[ExpiredTime] [datetime]  NULL,
[CreateTime] [datetime]  NULL,
[DeviceType] [int]  NULL,
[SessionKey] [nvarchar]  (200) NULL)

ALTER TABLE [UserDevice] WITH NOCHECK ADD  CONSTRAINT [PK_UserDevice] PRIMARY KEY  NONCLUSTERED ( [UserDeviceID] )
SET IDENTITY_INSERT [UserDevice] ON

INSERT [UserDevice] ([UserDeviceID],[UserId],[ActiveTime],[ExpiredTime],[CreateTime],[DeviceType],[SessionKey]) VALUES ( 1,1,N'2016/3/6 7:25:40',N'2016/3/6 8:25:40',N'2016/3/6 6:55:04',0,N'eae81fd848c1c3d541c2998b2a277c71')
INSERT [UserDevice] ([UserDeviceID],[UserId],[ActiveTime],[ExpiredTime],[CreateTime],[DeviceType],[SessionKey]) VALUES ( 2,1,N'2016/3/6 8:31:48',N'2016/3/6 9:31:48',N'2016/3/6 8:31:40',0,N'6ecb47f03a635d7f7cf1e1a0034d1984')
INSERT [UserDevice] ([UserDeviceID],[UserId],[IP],[ActiveTime],[ExpiredTime],[CreateTime],[DeviceType],[SessionKey]) VALUES ( 3,0,N'219.136.94.126',N'2016/3/6 9:39:20',N'2016/3/6 10:39:20',N'2016/3/6 9:36:50',0,N'c8f75fe01a9aabb01fa29da9df9e8f5d')
INSERT [UserDevice] ([UserDeviceID],[UserId],[ActiveTime],[ExpiredTime],[CreateTime],[DeviceType],[SessionKey]) VALUES ( 4,1,N'2016/3/6 14:00:12',N'2016/3/6 15:00:12',N'2016/3/6 12:49:26',0,N'ed8a670075710d2ae74b6830e089fa0d')
INSERT [UserDevice] ([UserDeviceID],[UserId],[IP],[ActiveTime],[ExpiredTime],[CreateTime],[DeviceType],[SessionKey]) VALUES ( 5,0,N'219.136.94.126',N'2016/3/6 13:14:12',N'2016/3/6 14:14:12',N'2016/3/6 13:10:44',0,N'e2f40a762d1e44448a5208db1652bedc')
INSERT [UserDevice] ([UserDeviceID],[UserId],[ActiveTime],[ExpiredTime],[CreateTime],[DeviceType],[SessionKey]) VALUES ( 6,1,N'2016/3/7 8:55:15',N'2016/3/7 9:55:15',N'2016/3/7 8:08:24',0,N'aae9415afb1165f85688e39d7279a4a3')
INSERT [UserDevice] ([UserDeviceID],[UserId],[IP],[ActiveTime],[ExpiredTime],[CreateTime],[DeviceType],[SessionKey]) VALUES ( 7,0,N'12.96.64.144',N'2016/3/7 8:34:03',N'2016/3/7 9:34:03',N'2016/3/7 8:31:49',0,N'5b8ff4c1f74810a430eebe86f2aefa82')
INSERT [UserDevice] ([UserDeviceID],[UserId],[ActiveTime],[ExpiredTime],[CreateTime],[DeviceType],[SessionKey]) VALUES ( 8,4,N'2016/3/7 8:34:09',N'2016/3/7 9:34:09',N'2016/3/7 8:33:16',0,N'd0f896cd711cb881ebb8741d27aee54c')
INSERT [UserDevice] ([UserDeviceID],[UserId],[IP],[ActiveTime],[ExpiredTime],[CreateTime],[DeviceType],[SessionKey]) VALUES ( 9,0,N'219.136.75.189',N'2016/3/8 3:33:48',N'2016/3/8 4:33:48',N'2016/3/8 3:15:05',0,N'd07c8ec4ff429a80fc374e727b7c7e70')
INSERT [UserDevice] ([UserDeviceID],[UserId],[ActiveTime],[ExpiredTime],[CreateTime],[DeviceType],[SessionKey]) VALUES ( 10,6,N'2016/3/8 3:16:53',N'2016/3/8 4:16:53',N'2016/3/8 3:16:53',0,N'c9974eff3987a381b45da5e2982b1aaf')
INSERT [UserDevice] ([UserDeviceID],[UserId],[ActiveTime],[ExpiredTime],[CreateTime],[DeviceType],[SessionKey]) VALUES ( 11,1,N'2016/3/8 3:27:45',N'2016/3/8 4:27:45',N'2016/3/8 3:17:18',0,N'a5c4593072af792021f40e4aee35ecc5')
INSERT [UserDevice] ([UserDeviceID],[UserId],[ActiveTime],[ExpiredTime],[CreateTime],[DeviceType],[SessionKey]) VALUES ( 12,1,N'2016/3/8 4:33:39',N'2016/3/8 5:33:39',N'2016/3/8 4:33:39',0,N'4e8677cc91a71a50a5fff4045d1e5eaf')
INSERT [UserDevice] ([UserDeviceID],[UserId],[IP],[ActiveTime],[ExpiredTime],[CreateTime],[DeviceType],[SessionKey]) VALUES ( 13,0,N'219.136.75.189',N'2016/3/8 4:58:24',N'2016/3/8 5:58:24',N'2016/3/8 4:40:07',0,N'05721aa761b393e6fbf4c6f3868bf76e')
INSERT [UserDevice] ([UserDeviceID],[UserId],[IP],[ActiveTime],[ExpiredTime],[CreateTime],[DeviceType],[SessionKey]) VALUES ( 14,0,N'219.136.75.189',N'2016/3/8 7:19:23',N'2016/3/8 8:19:23',N'2016/3/8 7:18:33',0,N'd5e8ed726297029e2038d310afb019c6')
INSERT [UserDevice] ([UserDeviceID],[UserId],[ActiveTime],[ExpiredTime],[CreateTime],[DeviceType],[SessionKey]) VALUES ( 15,9,N'2016/3/8 7:19:56',N'2016/3/8 8:19:56',N'2016/3/8 7:19:41',0,N'01c3265ca1403d3df017901baefff4ab')

SET IDENTITY_INSERT [UserDevice] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[Users]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Users]

CREATE TABLE [Users] (
[UserId] [int]  IDENTITY (1, 1)  NOT NULL,
[UserName] [nvarchar]  (100) NOT NULL,
[Password] [nvarchar]  (200) NOT NULL,
[TrueName] [nvarchar]  (50) NULL,
[Sex] [nvarchar]  (10) NULL,
[Phone] [nvarchar]  (50) NULL,
[IsActive] [bit]  NULL,
[Permissions] [int]  NULL)

ALTER TABLE [Users] WITH NOCHECK ADD  CONSTRAINT [PK_Users] PRIMARY KEY  NONCLUSTERED ( [UserId],[Phone] )
SET IDENTITY_INSERT [Users] ON

INSERT [Users] ([UserId],[UserName],[Password],[TrueName],[Sex],[Phone],[IsActive],[Permissions]) VALUES ( 1,N'huangenai',N'123456',N'»Æ¶÷°®',N'Å®',N'13242760783',1,1)
INSERT [Users] ([UserId],[UserName],[Password],[TrueName],[Sex],[Phone],[IsActive],[Permissions]) VALUES ( 8,N'enai',N'123456',N'¶÷°®',N'Å®',N'18888888888',1,2)
INSERT [Users] ([UserId],[UserName],[Password],[TrueName],[Sex],[Phone],[IsActive],[Permissions]) VALUES ( 9,N'¶÷°®',N'123456',N'¶÷°®',N'Å®',N'13242760789',1,2)

SET IDENTITY_INSERT [Users] OFF
