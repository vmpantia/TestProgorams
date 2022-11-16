CREATE TABLE [dbo].[Employee_TRN]
(
	--Identifier
	[RequestID]			   VARCHAR(15)		NOT NULL PRIMARY KEY,
	[InternalID]	       UNIQUEIDENTIFIER NOT NULL,
	[EmployeeID]	       VARCHAR(15)		NOT NULL,
	--Personal Details
	[FirstName] 	       VARCHAR(20)		NOT NULL,
	[MiddleName] 	       VARCHAR(20)		NULL,
	[LastName] 	           VARCHAR(20)		NOT NULL,
	[Gender] 	           VARCHAR(6)		NOT NULL,
	[Birthdate] 	       DATE		        NOT NULL,
	[Birthplace] 	       VARCHAR(100)	    NOT NULL,
	[CivilStatus] 	       VARCHAR(10)	    NOT NULL,
	[Citizenship] 	       VARCHAR(20)	    NOT NULL,
	--Contact Details
	[ContactNo] 	       VARCHAR(15)	    NOT NULL,
	[EmailAddress] 	       VARCHAR(50)	    NULL,
	--Address Details
	[HomeDetails] 	       VARCHAR(50)	    NOT NULL,
	[Street] 	           VARCHAR(50)	    NOT NULL,
	[Village] 	           VARCHAR(50)	    NOT NULL,
	[Barangay] 	           VARCHAR(50)	    NOT NULL,
	[City] 	               VARCHAR(50)	    NOT NULL,
	[ZipCode] 	           VARCHAR(50)	    NOT NULL,
	[Province] 	           VARCHAR(50)	    NOT NULL,
	[Country] 	           VARCHAR(50)	    NOT NULL,
	--Spouce Details
	[SpouseName] 	       VARCHAR(60)	    NULL,
	[SpouseContactNo] 	   VARCHAR(15)	    NULL,
	[SpouseEmailAddress]   VARCHAR(50)	    NULL,
	[SpouseAddress] 	   VARCHAR(100)	    NULL,
	--Emergency POC Details				    
	[EPOCName] 	           VARCHAR(60)	    NOT NULL,
	[EPOCContactNo] 	   VARCHAR(15)	    NOT NULL,
	[EPOCEmailAddress] 	   VARCHAR(50)	    NOT NULL,
	[EPOCRelation] 	       VARCHAR(20)	    NOT NULL,
	[EPOCAddress] 	       VARCHAR(100)	    NOT NULL,
	--Employement Details
	[PositionInternalID]   UNIQUEIDENTIFIER NOT NULL,
	[Type]			       VARCHAR(10)      NOT NULL,
	--Common Columns
	[Status] 			   INT				NOT NULL,
	[CreatedDate]		   DATETIME		    NOT NULL,
	[ModifiedDate]		   DATETIME		    NULL
)
