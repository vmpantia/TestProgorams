CREATE TABLE [dbo].[Request]
(
	--Identifier
	[RequestID]			VARCHAR(15)		 NOT NULL PRIMARY KEY,
	[FunctionID]		VARCHAR(5)		 NOT NULL,
	[Status]		    VARCHAR(2)		 NOT NULL,
	[CreatedBy]			UNIQUEIDENTIFIER NOT NULL,
	[CreatedDate]		DATETIME		 NOT NULL,
	[ApprovedBy]		UNIQUEIDENTIFIER NULL,
	[ApprovedDate]		DATETIME		 NULL,
	[ModifiedBy]		UNIQUEIDENTIFIER NULL,
	[ModifiedDate]		DATETIME		 NULL,
)
