USE [LoggingDatabase]
GO

/****** Object:  Table [dbo].[pgi_app_log]    Script Date: 11/12/2013 7:33:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[pgi_app_log](
	[log_id] [int] IDENTITY(1,1) NOT NULL,
	[log_guid] [varchar](255) NULL,
	[log_dt] [datetime] NOT NULL,
	[log_thrd] [varchar](255) NULL,
	[log_lvl] [varchar](50) NULL,
	[log_logger] [varchar](255) NULL,
	[log_msg] [varchar](max) NULL,
	[log_excpt] [varchar](2000) NULL,
	[log_mchn_nm] [varchar](255) NULL,
	[log_app_nm] [varchar](255) NULL,
	[log_usr] [varchar](255) NULL,
	[log_dtl] [varchar](max) NULL,
	[log_sys_usr] [varchar](255) NULL,
 CONSTRAINT [pgi_app_log_PK] PRIMARY KEY CLUSTERED 
(
	[log_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


