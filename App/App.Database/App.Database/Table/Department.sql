CREATE TABLE [dbo].[Department]
(
	--Identifier
	[InternalID]	    UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[DepartmentID]	    VARCHAR(15)		 NOT NULL,
	--Department Details
	[Name] 			    VARCHAR(20)		 NOT NULL,
	[ManagerInternalID] UNIQUEIDENTIFIER NOT NULL,
	--Common Columns
	[Status] 			INT				 NOT NULL,
	[CreatedDate]		DATETIME		 NOT NULL,
	[ModifiedDate]		DATETIME		 NULL
)
