

/****** Object:  Table [dbo].[EZT_APPLIED_BLOCKDAYS]    Script Date: 6/30/2021 2:55:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EZT_APPLIED_BLOCKDAYS](
	[BD_APPLIED_GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[BLOCKDAY_GUID] [uniqueidentifier] NOT NULL,
	[RESOURCE_GUID] [uniqueidentifier] NOT NULL,
	[PRACTICE_VID] [smallint] NOT NULL,
	[APPLIED_DAY] [datetime] NOT NULL,
	[CREATE_DATE_TIME] [datetime] NOT NULL,
	[CREATE_USER_GUID] [uniqueidentifier] NOT NULL,
	[CREATE_WORKSTATION_GUID] [uniqueidentifier] NOT NULL,
	[WORK_FLAG] [smallint] NOT NULL,
 CONSTRAINT [PK_EZT_APPLIED_BLOCKDAYS] PRIMARY KEY NONCLUSTERED 
(
	[BD_APPLIED_GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EZT_APPLIED_BLOCKTIMES]    Script Date: 6/30/2021 2:55:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EZT_APPLIED_BLOCKTIMES](
	[BT_APPLIED_GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[BLOCKTIME_GUID] [uniqueidentifier] NOT NULL,
	[RESOURCE_GUID] [uniqueidentifier] NOT NULL,
	[PRACTICE_VID] [smallint] NOT NULL,
	[APPLIED_DAY] [datetime] NOT NULL,
	[START_TIME] [datetime] NOT NULL,
	[END_TIME] [datetime] NOT NULL,
	[CREATE_DATE_TIME] [datetime] NOT NULL,
	[CREATE_USER_GUID] [uniqueidentifier] NOT NULL,
	[CREATE_WORKSTATION_GUID] [uniqueidentifier] NOT NULL,
	[WORK_FLAG] [smallint] NOT NULL,
 CONSTRAINT [PK_EZT_APPLIED_BLOCKTIMES] PRIMARY KEY NONCLUSTERED 
(
	[BT_APPLIED_GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EZT_APPOINTMENT_TYPES]    Script Date: 6/30/2021 2:55:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EZT_APPOINTMENT_TYPES](
	[APPT_TYPE_GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[GROUP_GUID] [uniqueidentifier] NOT NULL,
	[PRACTICE_VID] [smallint] NOT NULL,
	[NAME] [varchar](50) NOT NULL,
	[DELETE_GUID] [uniqueidentifier] NOT NULL,
	[DESCRIPTION] [varchar](500) NOT NULL,
	[NUM_HOURS] [smallint] NOT NULL,
	[NUM_MINUTES] [smallint] NOT NULL,
	[ICON] [image] NULL,
	[CREATE_DATE_TIME] [datetime] NOT NULL,
	[CREATE_USER_GUID] [uniqueidentifier] NOT NULL,
	[CREATE_WORKSTATION_GUID] [uniqueidentifier] NOT NULL,
	[DELETED] [bit] NOT NULL,
	[POPUP_MESSAGE] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_EZT_APPOINTMENT_TYPES] PRIMARY KEY NONCLUSTERED 
(
	[APPT_TYPE_GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EZT_APPOINTMENTS]    Script Date: 6/30/2021 2:55:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EZT_APPOINTMENTS](
	[APPOINTMENT_GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[PRACTICE_VID] [smallint] NOT NULL,
	[RESOURCE_GUID] [uniqueidentifier] NOT NULL,
	[STATUS_TYPE_GUID] [uniqueidentifier] NOT NULL,
	[RECURRING_GUID] [uniqueidentifier] NULL,
	[GROUP_GUID] [uniqueidentifier] NULL,
	[APPOINTMENT_DATE] [datetime] NOT NULL,
	[START_TIME] [datetime] NOT NULL,
	[END_TIME] [datetime] NOT NULL,
	[ICON_GUID] [uniqueidentifier] NOT NULL,
	[COMMENTS] [varchar](2000) NOT NULL,
	[CREATED_BYOP] [char](5) NOT NULL,
	[LASTMOD_BYOP] [char](5) NOT NULL,
	[CREATE_PRACTICE_VID] [smallint] NOT NULL,
	[CREATE_DATE_TIME] [datetime] NOT NULL,
	[CREATE_USER_GUID] [uniqueidentifier] NOT NULL,
	[CREATE_WORKSTATION_GUID] [uniqueidentifier] NOT NULL,
	[DELETED] [bit] NOT NULL,
 CONSTRAINT [PK_EZT_APPOINTMENTS] PRIMARY KEY NONCLUSTERED 
(
	[APPOINTMENT_GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EZT_APPT_ACCOUNTS]    Script Date: 6/30/2021 2:55:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EZT_APPT_ACCOUNTS](
	[APPT_ACT_GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[APPOINTMENT_GUID] [uniqueidentifier] NOT NULL,
	[CLIENT_GUID] [uniqueidentifier] NOT NULL,
	[PATIENT_GUID] [uniqueidentifier] NOT NULL,
	[PRACTICE_VID] [smallint] NOT NULL,
	[CREATE_PRACTICE_VID] [smallint] NOT NULL,
	[CREATE_DATE_TIME] [datetime] NOT NULL,
	[CREATE_USER_GUID] [uniqueidentifier] NOT NULL,
	[CREATE_WORKSTATION_GUID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_EZT_APPT_ACCOUNTS] PRIMARY KEY NONCLUSTERED 
(
	[APPT_ACT_GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EZT_APPT_GROUPS]    Script Date: 6/30/2021 2:55:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EZT_APPT_GROUPS](
	[APT_GROUP_GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[PRACTICE_VID] [smallint] NOT NULL,
	[COMMENTS] [varchar](2000) NOT NULL,
	[CREATE_PRACTICE_VID] [smallint] NOT NULL,
	[CREATE_DATE_TIME] [datetime] NOT NULL,
	[CREATE_USER_GUID] [uniqueidentifier] NOT NULL,
	[CREATE_WORKSTATION_GUID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_EZT_APPT_GROUPS] PRIMARY KEY NONCLUSTERED 
(
	[APT_GROUP_GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EZT_APPT_ICONS]    Script Date: 6/30/2021 2:55:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EZT_APPT_ICONS](
	[ICON_GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[ICON] [image] NOT NULL,
	[CREATE_DATE_TIME] [datetime] NOT NULL,
	[CREATE_USER_GUID] [uniqueidentifier] NOT NULL,
	[CREATE_WORKSTATION_GUID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_EZT_APPT_ICONS] PRIMARY KEY NONCLUSTERED 
(
	[ICON_GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EZT_APPT_RECURRING]    Script Date: 6/30/2021 2:55:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EZT_APPT_RECURRING](
	[RECURRING_GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[PRACTICE_VID] [smallint] NOT NULL,
	[SEQ_TYPE] [smallint] NOT NULL,
	[HOW_OFTEN] [smallint] NOT NULL,
	[START_DATE] [datetime] NOT NULL,
	[END_DATE] [datetime] NOT NULL,
	[COMMENTS] [varchar](2000) NOT NULL,
	[CREATE_PRACTICE_VID] [smallint] NOT NULL,
	[CREATE_DATE_TIME] [datetime] NOT NULL,
	[CREATE_USER_GUID] [uniqueidentifier] NOT NULL,
	[CREATE_WORKSTATION_GUID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_EZT_APPT_RECURRING] PRIMARY KEY NONCLUSTERED 
(
	[RECURRING_GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EZT_BLOCK_DAYS]    Script Date: 6/30/2021 2:55:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EZT_BLOCK_DAYS](
	[BLOCKDAY_GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[NAME] [varchar](30) NOT NULL,
	[DELETE_GUID] [uniqueidentifier] NOT NULL,
	[COLOR] [int] NOT NULL,
	[DESCRIPTION] [varchar](500) NOT NULL,
	[PRACTICE_VID] [smallint] NOT NULL,
	[CREATE_DATE_TIME] [datetime] NOT NULL,
	[CREATE_USER_GUID] [uniqueidentifier] NOT NULL,
	[CREATE_WORKSTATION_GUID] [uniqueidentifier] NOT NULL,
	[DELETED] [bit] NOT NULL,
 CONSTRAINT [PK_EZT_BLOCK_DAYS] PRIMARY KEY NONCLUSTERED 
(
	[BLOCKDAY_GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EZT_BLOCK_TIMES]    Script Date: 6/30/2021 2:55:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EZT_BLOCK_TIMES](
	[BLOCKTIME_GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[NAME] [varchar](30) NOT NULL,
	[DELETE_GUID] [uniqueidentifier] NOT NULL,
	[PRACTICE_VID] [smallint] NOT NULL,
	[DESCRIPTION] [varchar](500) NOT NULL,
	[COLOR] [int] NOT NULL,
	[START_TIME] [datetime] NOT NULL,
	[END_TIME] [datetime] NOT NULL,
	[CREATE_DATE_TIME] [datetime] NOT NULL,
	[CREATE_USER_GUID] [uniqueidentifier] NOT NULL,
	[CREATE_WORKSTATION_GUID] [uniqueidentifier] NOT NULL,
	[DELETED] [bit] NOT NULL,
 CONSTRAINT [PK_EZT_BLOCK_TIMES] PRIMARY KEY NONCLUSTERED 
(
	[BLOCKTIME_GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EZT_COLOR_SCHEMES]    Script Date: 6/30/2021 2:55:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EZT_COLOR_SCHEMES](
	[COLOR_GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[NAME] [varchar](30) NOT NULL,
	[PRACTICE_VID] [smallint] NOT NULL,
	[BEVEL_FACE_COLOR] [int] NOT NULL,
	[BEVEL_FRAME_COLOR] [int] NOT NULL,
	[BEVEL_HIGHLIGHT_COLOR] [int] NOT NULL,
	[BACK_COLOR] [int] NOT NULL,
	[BACK_COLOR_SELECTED] [int] NOT NULL,
	[DURATION_FILL_COLOR] [int] NOT NULL,
	[EDIT_BACK_COLOR] [int] NOT NULL,
	[EDIT_FORE_COLOR] [int] NOT NULL,
	[FORE_COLOR] [int] NOT NULL,
	[FORE_COLOR_SELECTED] [int] NOT NULL,
	[DURATION_FILL_PATTERN] [smallint] NOT NULL,
	[CREATE_DATE_TIME] [datetime] NOT NULL,
	[CREATE_USER_GUID] [uniqueidentifier] NOT NULL,
	[CREATE_WORKSTATION_GUID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_EZT_COLOR_SCHEMES] PRIMARY KEY NONCLUSTERED 
(
	[COLOR_GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EZT_LABEL_COMMENTS]    Script Date: 6/30/2021 2:55:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EZT_LABEL_COMMENTS](
	[COMMENT_GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[PRACTICE_VID] [smallint] NOT NULL,
	[COMMENT] [varchar](50) NOT NULL,
	[CREATE_DATE_TIME] [datetime] NOT NULL,
	[CREATE_USER_GUID] [uniqueidentifier] NOT NULL,
	[CREATE_WORKSTATION_GUID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_EZT_LABEL_COMMENTS] PRIMARY KEY NONCLUSTERED 
(
	[COMMENT_GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EZT_OPTION_FIELDS]    Script Date: 6/30/2021 2:55:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EZT_OPTION_FIELDS](
	[EZ_OP_FLD_GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[PRACTICE_VID] [smallint] NOT NULL,
	[SOURCE_TABLE] [varchar](50) NOT NULL,
	[FIELD_NAME] [varchar](50) NOT NULL,
	[CREATE_DATE_TIME] [datetime] NOT NULL,
	[CREATE_USER_GUID] [uniqueidentifier] NOT NULL,
	[CREATE_WORKSTATION_GUID] [uniqueidentifier] NOT NULL,
	[INSERT_ORDER] [smallint] NOT NULL,
 CONSTRAINT [PK_EZT_OPTION_FIELDS] PRIMARY KEY NONCLUSTERED 
(
	[EZ_OP_FLD_GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EZT_OPTIONS]    Script Date: 6/30/2021 2:55:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EZT_OPTIONS](
	[EZT_OPT_GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[PRACTICE_VID] [smallint] NOT NULL,
	[FIRSTDAY] [smallint] NOT NULL,
	[OPID_REQ] [bit] NOT NULL,
	[OVERLAP_OK] [bit] NOT NULL,
	[ACCOUNT_REQ] [bit] NOT NULL,
	[CREATE_DATE_TIME] [datetime] NOT NULL,
	[CREATE_USER_GUID] [uniqueidentifier] NOT NULL,
	[CREATE_WORKSTATION_GUID] [uniqueidentifier] NOT NULL,
	[PRINT_SPEED] [smallint] NOT NULL,
	[PRINT_DENSITY] [smallint] NOT NULL,
	[NUMCOPIES] [smallint] NOT NULL,
	[HEADER1] [varchar](50) NOT NULL,
	[HEADER2] [varchar](50) NOT NULL,
	[HEADER3] [varchar](50) NOT NULL,
	[FOOTER] [varchar](50) NOT NULL,
	[DEFAULT_STATUS_TYPE] [uniqueidentifier] NOT NULL,
	[MOVE_STATUS_TYPE] [uniqueidentifier] NOT NULL,
	[DATE_OUTA_RANGE_WARN] [bit] NOT NULL,
	[HIDE_RESOURCES] [bit] NOT NULL,
	[APPT_BLOCKING_OPTION] [tinyint] NOT NULL,
	[CENSUS_CHECKIN_STATUS_TYPE] [uniqueidentifier] NOT NULL,
	[ENABLE_DRAG_DROP] [bit] NOT NULL,
 CONSTRAINT [PK_EZT_OPTIONS] PRIMARY KEY NONCLUSTERED 
(
	[EZT_OPT_GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EZT_RESOURCE_GROUPS]    Script Date: 6/30/2021 2:55:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EZT_RESOURCE_GROUPS](
	[GROUP_GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[NAME] [varchar](30) NOT NULL,
	[DELETE_GUID] [uniqueidentifier] NOT NULL,
	[DESCRIPTION] [varchar](500) NOT NULL,
	[PRACTICE_VID] [smallint] NOT NULL,
	[COLOR_GUID] [uniqueidentifier] NOT NULL,
	[TIME_INTERVAL] [smallint] NOT NULL,
	[START_TIME] [datetime] NOT NULL,
	[END_TIME] [datetime] NOT NULL,
	[CREATE_DATE_TIME] [datetime] NOT NULL,
	[CREATE_USER_GUID] [uniqueidentifier] NOT NULL,
	[CREATE_WORKSTATION_GUID] [uniqueidentifier] NOT NULL,
	[DELETED] [bit] NOT NULL,
	[SEQUENCE] [int] NOT NULL,
	[FRAME_BEVEL] [smallint] NOT NULL,
	[CAPTION_BEVEL] [smallint] NOT NULL,
 CONSTRAINT [PK_EZT_RESOURCE_GROUPS] PRIMARY KEY NONCLUSTERED 
(
	[GROUP_GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EZT_RESOURCES]    Script Date: 6/30/2021 2:55:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EZT_RESOURCES](
	[RESOURCE_GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[NAME] [varchar](30) NOT NULL,
	[PRACTICE_VID] [smallint] NOT NULL,
	[DELETE_GUID] [uniqueidentifier] NOT NULL,
	[DESCRIPTION] [varchar](500) NOT NULL,
	[GROUP_GUID] [uniqueidentifier] NOT NULL,
	[ICON] [image] NULL,
	[ALIGNMENT] [smallint] NOT NULL,
	[EMPLOYEE_GUID] [uniqueidentifier] NULL,
	[CREATE_DATE_TIME] [datetime] NOT NULL,
	[CREATE_USER_GUID] [uniqueidentifier] NOT NULL,
	[CREATE_WORKSTATION_GUID] [uniqueidentifier] NOT NULL,
	[DELETED] [bit] NOT NULL,
	[SEQUENCE] [int] NOT NULL,
 CONSTRAINT [PK_EZT_RESOURCES] PRIMARY KEY NONCLUSTERED 
(
	[RESOURCE_GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EZT_STATUS_TYPES]    Script Date: 6/30/2021 2:55:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EZT_STATUS_TYPES](
	[STATUS_GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[NAME] [varchar](30) NOT NULL,
	[DELETE_GUID] [uniqueidentifier] NOT NULL,
	[PRACTICE_VID] [smallint] NOT NULL,
	[DESCRIPTION] [varchar](500) NOT NULL,
	[COLOR] [int] NOT NULL,
	[RPT1] [bit] NOT NULL,
	[RPT2] [bit] NOT NULL,
	[RPT3] [bit] NOT NULL,
	[RPT4] [bit] NOT NULL,
	[RPT5] [bit] NOT NULL,
	[RPT6] [bit] NOT NULL,
	[RPT7] [bit] NOT NULL,
	[RPT8] [bit] NOT NULL,
	[RPT9] [bit] NOT NULL,
	[CREATE_DATE_TIME] [datetime] NOT NULL,
	[CREATE_USER_GUID] [uniqueidentifier] NOT NULL,
	[CREATE_WORKSTATION_GUID] [uniqueidentifier] NOT NULL,
	[DELETED] [bit] NOT NULL,
 CONSTRAINT [PK_EZT_STATUS_TYPES] PRIMARY KEY NONCLUSTERED 
(
	[STATUS_GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EZT_USER_PREFERENCES]    Script Date: 6/30/2021 2:55:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EZT_USER_PREFERENCES](
	[EZPREF_GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[PRACTICE_VID] [smallint] NOT NULL,
	[USER_GUID] [uniqueidentifier] NOT NULL,
	[CURRENTTAB] [int] NOT NULL,
	[CURRENT_GROUP_GUID] [uniqueidentifier] NOT NULL,
	[CURRENT_RESOURCE_GUID] [uniqueidentifier] NOT NULL,
	[SELBAR_SEQUENCE] [int] NOT NULL,
	[LAST_VISIT_DATE] [datetime] NOT NULL,
	[LAST_WORKSTATION_GUID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_EZT_USER_PREFERENCES] PRIMARY KEY NONCLUSTERED 
(
	[EZPREF_GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EZT_APPOINTMENT_TYPES] ADD  DEFAULT ('') FOR [POPUP_MESSAGE]
GO

ALTER TABLE [dbo].[EZT_OPTION_FIELDS] ADD  DEFAULT (0) FOR [INSERT_ORDER]
GO

ALTER TABLE [dbo].[EZT_OPTIONS] ADD  CONSTRAINT [DF__EZT_OPTIO__DATE___409A7F30]  DEFAULT (0) FOR [DATE_OUTA_RANGE_WARN]
GO

ALTER TABLE [dbo].[EZT_OPTIONS] ADD  DEFAULT (1) FOR [HIDE_RESOURCES]
GO

ALTER TABLE [dbo].[EZT_OPTIONS] ADD  DEFAULT (0) FOR [APPT_BLOCKING_OPTION]
GO

ALTER TABLE [dbo].[EZT_OPTIONS] ADD  DEFAULT ('{00000000-0000-0000-0000-000000000000}') FOR [CENSUS_CHECKIN_STATUS_TYPE]
GO

ALTER TABLE [dbo].[EZT_OPTIONS] ADD  DEFAULT (1) FOR [ENABLE_DRAG_DROP]
GO


