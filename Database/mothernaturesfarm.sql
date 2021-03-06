SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mnf_Coupon](
	[CouponId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] [nvarchar](64) NOT NULL DEFAULT (''),
	[Description] [nvarchar](512) NOT NULL DEFAULT (''),
	[IsEnabled] [bit] NOT NULL DEFAULT ((0)),
	[DateCreated] [datetime] NOT NULL DEFAULT (getdate())
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mnf_CouponMemberUsage](
	[CouponMemberUsageId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[CouponId] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
	[DateUsed] [datetime] NOT NULL DEFAULT (getdate())
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mnf_Member](
	[MemberId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[EmailAddress] [nvarchar](255) NOT NULL DEFAULT (''),
	[Password] [nvarchar](32) NOT NULL DEFAULT (''),
	[FirstName] [nvarchar](64) NOT NULL DEFAULT (''),
	[LastName] [nvarchar](64) NOT NULL DEFAULT (''),
	[Address1] [nvarchar](128) NOT NULL DEFAULT (''),
	[Address2] [nvarchar](128) NOT NULL DEFAULT (''),
	[City] [nvarchar](64) NOT NULL DEFAULT (''),
	[State] [nvarchar](2) NOT NULL DEFAULT (''),
	[PostalCode] [nvarchar](16) NOT NULL DEFAULT (''),
	[IsEnabled] [bit] NOT NULL DEFAULT ((1)),
	[NewsletterSubscriber] [bit] NOT NULL DEFAULT ((0)),
	[RecommendedBy] [nvarchar](256) NOT NULL DEFAULT (''),
	[DateCreated] [datetime] NOT NULL DEFAULT (getdate())
) ON [PRIMARY]
GO
