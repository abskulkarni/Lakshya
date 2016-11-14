
/****** Object:  StoredProcedure [dbo].[sp_InsertCustomerAndTravel]    Script Date: 10/5/2016 11:54:13 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER TABLE dbo.Customer_Master ADD IS_DLT int default 0;
GO

update dbo.Customer_Master set IS_DLT = 0
GO

update dbo.Customer_Master set IS_DLT = 1 where Created_By is null
GO

delete from dbo.Customer_Master where first_name = 'test' or Alternate_Mobile = '1111111111' or First_Name = 'abhirahul'
go

;WITH CTE AS(
   SELECT customer_id, mobile_no,first_name,last_name,created_date,
       RN = ROW_NUMBER() OVER(PARTITION BY convert(bigint, mobile_no) ORDER BY created_date)
   FROM dbo.Customer_Master
   where Created_Date is not null and updated_date is null
)
--select * from CTE where RN > 1 and Mobile_No = '9767809661'
update cMaster
--select
--CTE.Created_Date, CTE.RN, cMaster.*
set IS_DLT = 1
from
Customer_Master cMaster
inner join
CTE
on cMaster.Customer_ID = CTE.Customer_ID
where RN > 1 
--order by CTE.Created_Date, CTE.RN
GO

;WITH CTE AS(
   SELECT customer_id, mobile_no,first_name,last_name,created_date,
       RN = ROW_NUMBER() OVER(PARTITION BY convert(bigint, mobile_no) ORDER BY updated_date desc)
   FROM dbo.Customer_Master
   where Created_Date is not null and updated_date is not null
)
--select * from CTE where RN > 1 and Mobile_No = '9767809661'
update cMaster
--select
--CTE.Created_Date, CTE.RN, cMaster.*
set IS_DLT = 1
from
Customer_Master cMaster
inner join
CTE
on cMaster.Customer_ID = CTE.Customer_ID
where RN > 1 
--order by CTE.Created_Date, CTE.RN

GO

update cMasterNullUpdates
SET IS_DLT = 1
from
dbo.Customer_Master cMasterNotNullUpdates
inner join
dbo.Customer_Master cMasterNullUpdates
on cMasterNotNullUpdates.Mobile_No = cMasterNullUpdates.Mobile_No
where cMasterNullUpdates.Updated_Date is null and cMasterNotNullUpdates.Updated_Date is not null
GO

CREATE TABLE [dbo].[Area_Master]([Area_ID] [int] IDENTITY(1,1) NOT NULL,
	[Area] [varchar](100) NULL,
	[Is_Visible] bit default 1,
	[Created_By] [varchar](30) NULL,
	[Created_Date] [datetime] NULL,
	[Updated_By] [varchar](50) NULL,
	[Updated_Date] [datetime] NULL,
 CONSTRAINT [PK_Area_Master] PRIMARY KEY CLUSTERED 
(
	[Area_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


Alter TABLE dbo.bus_Mapping ADD
Discount	int,
Discount_Given_By	varchar(50),
DiscountReason	varchar(50),
Actual_Fees	int,
Created_By	varchar(50),
Created_Date	datetime,
Updated_By	varchar(50),
Updated_Date	datetime
GO

Alter TABLE dbo.Bus_Master ADD
Created_By	varchar(50),
Created_Date	datetime,
Updated_By	varchar(50),
Updated_Date	datetime
GO

update busMapping
set Discount = isnull(cMaster.Discount,0),
Discount_Given_By = cMaster.Discount_Given_By,
DiscountReason = cMaster.DiscountReason,
Actual_Fees = bMaster.Bus_Fees - isnull(cMaster.Discount,0),
Created_By = cMaster.Created_By,
Created_Date = cMaster.Registration_Date
from
dbo.Customer_Master cMaster
inner join
dbo.bus_Mapping busMapping
on cMaster.Customer_ID = busMapping.Customer_ID
inner join
Bus_Master bMaster
on bMaster.Bus_Master_ID = busMapping.Bus_Master_ID

GO

ALTER TABLE dbo.Customer_Master DROP COLUMN Fees;
ALTER TABLE dbo.Customer_Master DROP COLUMN Discount;
ALTER TABLE dbo.Customer_Master DROP COLUMN Discount_Given_By;
ALTER TABLE dbo.Customer_Master DROP COLUMN DiscountReason;
ALTER TABLE dbo.Customer_Master DROP COLUMN Actual_Fees;

ALTER TABLE dbo.Customer_Master ADD Area_ID int default 0;
GO


create procedure dbo.GetAreas
as
begin
	set nocount on;
	select area_ID, Area, Is_Visible from dbo.Area_Master order by area
end
GO

create procedure dbo.InsertUpdateArea
@Area_ID int, @Area varchar(30), @IsVisible bit = 1, @UserName varchar(30)
as
begin
	set nocount on;

	if @Area_ID = 0
	begin
		insert into dbo.Area_Master (Area, Is_Visible, Created_By, Created_Date) values (@Area,@IsVisible, @UserName, GETDATE())
		select SCOPE_IDENTITY();
	end
	else
	begin
		update dbo.Area_Master set Area = @Area, Is_Visible = @IsVisible,
									Updated_By = @UserName, Updated_Date = GETDATE()
		
		 where Area_ID = @Area_ID
		select @Area_ID;
	end
end
GO

create procedure dbo.DeleteArea
@Area_ID int
as
begin
	if exists (select 1 from dbo.Customer_Master where isnull(Area_ID,0) = @Area_ID)
	begin
		select -1;
		return
	end

	delete from dbo.Area_Master where Area_ID = @Area_ID
	select @Area_ID;
end
GO

CREATE TABLE [dbo].[Bus_Route_Master](
	[Route_ID] [int] IDENTITY(1,1) NOT NULL,
	[Bus_Route] [varchar](100) NULL,
	[Created_By] [varchar](50) NULL,
	[Created_Date] [datetime] NULL,
	[Updated_By] [varchar](50) NULL,
	[Updated_Date] [datetime] NULL,
	Auto_Time timestamp
 CONSTRAINT [PK_Bus_Route_Master] PRIMARY KEY CLUSTERED 
(
	[Route_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


GO

INSERT INTO DBO.Bus_Route_Master (Bus_Route,Created_By)
values('9 DEVI Darshan, Pune','admin'), 
('Mahalaxmi, Kolhapur','admin'),('Ekvira Devi, Lonavla','admin'),('Mandhar Devi, Wai','admin')
GO

update dbo.bus_master set bus_Route = 'Mandhar Devi, Wai'  where bus_route = 'MANDHARDEVI WAI'
update dbo.bus_master set bus_Route = '9 DEVI Darshan, Pune'  where bus_route = '9 DEVI PUNE'
update dbo.bus_master set bus_Route = 'Mahalaxmi, Kolhapur'  where bus_route = 'MAHALAXMI,KOLHAPUR'
update dbo.bus_master set bus_Route = 'Mandhar Devi, Wai'  where bus_route = 'MANDHAR DEVI,WAI'
update dbo.bus_master set bus_Route = 'Ekvira Devi, Lonavla'  where bus_route = 'EKVIRA DEVI LONAWALA'
update dbo.bus_master set bus_Route = 'Ekvira Devi, Lonavla'  where bus_route = 'EKVIRA DEVI LONAVALA'
update dbo.bus_master set bus_Route = '9 DEVI Darshan, Pune'  where bus_route = '9 DEVI DHARSHAN'
update dbo.bus_master set bus_Route = 'Mahalaxmi, Kolhapur'  where bus_route = 'MAHALAXIMI KOLHAPUR'
update dbo.bus_master set bus_Route = '9 DEVI Darshan, Pune'  where bus_route = '9 DEVI DARSHAN'
update dbo.bus_master set bus_Route = 'Mandhar Devi, Wai'  where bus_route = 'MANDHAR DEVI WAI'
update dbo.bus_master set bus_Route = 'Mahalaxmi, Kolhapur'  where bus_route = 'MAHALXMI KOLHAPUR'
update dbo.bus_master set bus_Route = 'Ekvira Devi, Lonavla'  where bus_route = 'EKVIRADEVI LONAVALA'
update dbo.bus_master set bus_Route = '9 DEVI Darshan, Pune'  where bus_route = '9 DEVI PUNE DARSHAN'
update dbo.bus_master set bus_Route = 'Mahalaxmi, Kolhapur' where bus_route = 'KOLHAPUR MAHALAXMI'
update dbo.bus_master set bus_Route = '9 DEVI Darshan, Pune'  where bus_route = '9 DEVI DARSHAN PUNE'
GO

ALTER TABLE dbo.Bus_Master ADD Route_ID int
GO

Update bMaster
Set Route_ID = brm.Route_ID
from
dbo.Bus_Master bMaster
inner join
dbo.Bus_Route_Master brm
on bMaster.Bus_Route = brm.Bus_Route
GO

ALTER TABLE dbo.Bus_Master DROP COLUMN Bus_Route;
GO
--SPs

DROP PROCEDURE [dbo].[sp_InsertCustomer]
DROP PROCEDURE [dbo].[sp_UpdateCustomer]
DROP PROCEDURE dbo.sp_CustomerReport
DROP PROCEDURE [dbo].[sp_DeleteCustomer]
GO


create NONCLUSTERED INDEX IX_Customer_ID ON dbo.bus_Mapping(Customer_ID);
create NONCLUSTERED INDEX IX_Bus_Master_ID ON dbo.bus_Mapping(Bus_Master_ID);
create NONCLUSTERED INDEX IX_Created_By ON dbo.bus_Mapping(Created_By);
create NONCLUSTERED INDEX IX_Created_Date ON dbo.bus_Mapping(Created_Date);

create NONCLUSTERED INDEX IX_Mobile_No ON dbo.customer_Master(Mobile_No);
GO

ALTER PROCEDURE [dbo].[sp_getAvailableBusName]
		
       @Yatra_Date    date, @Route_ID int

AS
BEGIN 
     SET NOCOUNT ON 

	select distinct Bus_Name from 
	dbo.Bus_Master bMaster
	inner join dbo.Bus_Route_Master brm
	on bMaster.Route_ID = brm.Route_ID where 
	CONVERT(date, navratri_date) = @Yatra_Date
	and brm.Route_ID = @Route_ID
	and Is_Seat_Available = 1
	order by Bus_Name


--    select * from bus_master where navratri_date = @Yatra_Date
--and Bus_Master_ID NOT IN (select bm.Bus_Master_ID from 
--(select bus_master_id ,COUNT(Customer_id) as booked_seats from bus_Mapping where yatra_date = @Yatra_Date group by bus_master_id ) tt inner join 
--Bus_Master bm on tt.Bus_Master_ID = bm.Bus_Master_ID
--where
--(bm.No_Of_Seats-tt.booked_seats) <= 0) 

END 
GO
ALTER PROCEDURE [dbo].[sp_GetAllCustomers]

AS
BEGIN 
     SET NOCOUNT ON 

	select 	cMaster.Customer_ID, cMaster.First_Name, 
			cMaster.Last_Name, cMaster.Address, cMaster.Area_ID,
			cMaster.Mobile_No, cMaster.Blood_Group,cMaster.Alternate_Mobile, format(cMaster.Birth_Date,'dd/MMM/yyyy') Birth_Date
	from
	dbo.Customer_Master cMaster
	where IS_DLT = 0
END
GO

ALTER PROCEDURE [dbo].[sp_getCustomerDetails]
		
     (  @Customer_ID int, @Bus_Master_ID int)

AS
BEGIN 
     SET NOCOUNT ON 

	select 
	cMaster.Customer_ID, busMapping.Bus_Master_ID ,busMapping.Created_Date as Registration_Date, cMaster.First_Name, 
			cMaster.Last_Name, cMaster.Address, cMaster.Area_ID, cMaster.Age, cMaster.Birth_Date , cMaster.Blood_Group ,
			cMaster.Mobile_No, bMaster.Bus_Fees , cMaster.Alternate_Mobile ,
			busMapping.Discount, busMapping.Discount_Given_By,busMapping.DiscountReason ,busMapping.Actual_Fees,
			bMaster.Navratri_Date as yatra_date, bMaster.Bus_Name, bMaster.Seat_No, bMaster.Auto_Time
	from
	Customer_Master cMaster
	inner join
	bus_Mapping busMapping
	on cMaster.Customer_ID = busMapping.Customer_ID
	inner join
	Bus_Master bMaster
	on bMaster.Bus_Master_ID = busMapping.Bus_Master_ID
	inner join
	dbo.bus_route_master brm
	on brm.Route_ID = bMaster.Route_ID
	left join dbo.Area_Master tArea on cMaster.Area_ID = tArea.Area_ID
	where cMaster.Customer_ID = @Customer_ID and bMaster.Bus_Master_ID = @Bus_Master_ID

END 
GO

create PROCEDURE [dbo].[sp_DeleteData]
		@DeleteBusRoutes bit = 0
           ,@DeleteBuses bit = 0
		   ,@DeleteCustomers bit = 0
		   ,@FromDate date
		   ,@ToDate date

AS
BEGIN 
     SET NOCOUNT ON 
     if @DeleteBusRoutes = 1
	 BEGIN
		
		-- DELETE TICKETS
		delete bMapping
		from
		dbo.bus_Mapping bMapping
		inner join
		dbo.Bus_Master bMaster
		on bMapping.Bus_Master_ID = bMaster.Bus_Master_ID
		inner join
		dbo.Bus_Route_Master brm
		on brm.Route_ID = bMaster.Route_ID
		where convert(date, brm.Created_Date) between @FromDate and @ToDate

		-- DELETE BUSES
		delete bMaster
		from		
		dbo.Bus_Master bMaster
		inner join
		dbo.Bus_Route_Master brm
		on brm.Route_ID = bMaster.Route_ID
		where convert(date, brm.Created_Date) between @FromDate and @ToDate

		-- DELETE ROUTES
		delete from	dbo.Bus_Route_Master
		where convert(date, Created_Date) between @FromDate and @ToDate

	 END

	 if @DeleteBuses = 1
	 BEGIN
		-- DELETE TICKETS
		delete bMapping
		from
		dbo.bus_Mapping bMapping
		inner join
		dbo.Bus_Master bMaster
		on bMapping.Bus_Master_ID = bMaster.Bus_Master_ID
		where convert(date, bMaster.Created_Date) between @FromDate and @ToDate

		-- DELETE BUSES
		delete from	dbo.Bus_Master
		where convert(date, Created_Date) between @FromDate and @ToDate
	 END

	 if @DeleteCustomers = 1
	 BEGIN
		-- DELETE TICKETS
		delete bMapping
		from
		dbo.bus_Mapping bMapping
		inner join
		dbo.Customer_Master cMaster
		on bMapping.Customer_ID = cMaster.Customer_ID
		where convert(date, cMaster.Created_Date) between @FromDate and @ToDate

		-- DELETE CUSTOMERS
		delete from	dbo.Customer_Master
		where convert(date, Created_Date) between @FromDate and @ToDate

	 END

	select 0;

END 
GO

CREATE PROCEDURE [dbo].[sp_DeleteTicket]
		@Customer_ID int,
		@old_Bus_Master_ID int

AS
BEGIN 
     SET NOCOUNT ON 
     
     update Bus_Master
     set Is_Seat_Available = 1 where Bus_Master_ID = @old_Bus_Master_ID
     
     delete from bus_Mapping where Customer_ID = @Customer_ID and Bus_Master_ID = @old_Bus_Master_ID
     
     select @Customer_ID

END 
GO

CREATE PROCEDURE [dbo].[sp_GetCustomerTickets] --5268
(@Cust_ID int = NULL, @showThisYearTickets bit)
AS
BEGIN
	SET NOCOUNT ON;
	if @showThisYearTickets = 1
	begin
		select 
		cMaster.Customer_ID as CustomerID, busMapping.Bus_Master_ID as BusMasterID, 
				format(bMaster.Navratri_Date, 'dd-MMM-yyyy') as yatra_date, 
				bMaster.Bus_Name, bMaster.Seat_No, brm.Route_ID, brm.Bus_Route,
				cMaster.[Address], cMaster.First_Name, cMaster.Last_Name
		from
		dbo.Customer_Master cMaster
		inner join
		dbo.bus_Mapping busMapping
		on cMaster.Customer_ID = busMapping.Customer_ID
		inner join
		dbo.Bus_Master bMaster
		on bMaster.Bus_Master_ID = busMapping.Bus_Master_ID
		inner join
		dbo.Bus_Route_Master brm
		on bMaster.Route_ID = brm.Route_ID
		where cMaster.Customer_ID = isnull(@Cust_ID,cMaster.Customer_ID) and cMaster.IS_DLT = 0
		and convert(date,busMapping.Created_Date) = convert(date, getdate())
		and year(busMapping.Created_Date) < year(getdate())
		order by busMapping.Created_Date
	end
	else
	begin
		select 
		cMaster.Customer_ID as CustomerID, busMapping.Bus_Master_ID as BusMasterID, 
				format(bMaster.Navratri_Date, 'dd-MMM-yyyy') as yatra_date, 
				bMaster.Bus_Name, bMaster.Seat_No, brm.Route_ID, brm.Bus_Route,
				cMaster.[Address], cMaster.First_Name, cMaster.Last_Name
		from
		dbo.Customer_Master cMaster
		inner join
		dbo.bus_Mapping busMapping
		on cMaster.Customer_ID = busMapping.Customer_ID
		inner join
		dbo.Bus_Master bMaster
		on bMaster.Bus_Master_ID = busMapping.Bus_Master_ID
		inner join
		dbo.Bus_Route_Master brm
		on bMaster.Route_ID = brm.Route_ID
		where cMaster.Customer_ID = isnull(@Cust_ID,cMaster.Customer_ID) and cMaster.IS_DLT = 0
		and convert(date,busMapping.Created_Date) < convert(date, getdate())
		and year(busMapping.Created_Date) < year(getdate())
		order by busMapping.Created_Date
	end
END
GO

create PROCEDURE [dbo].[sp_InsertCustomerAndTravel] 
		(  @Registration_Date date
           ,@First_Name varchar(50)
           ,@Last_Name varchar(50)
           ,@Address varchar(500)
		   ,@Area_ID int = null
           ,@Age  numeric(6, 2)
           ,@Birth_Date date = null
           ,@Blood_Group varchar(50) = null
		   ,@DiscountChanged bit = false
		   ,@Discount int = 0
		   ,@Discount_Given_By varchar(50) = null
		   ,@DiscountReason varchar(50) = null
		   ,@Seat_No int
           ,@Mobile_No varchar(50)
           ,@Fees int = null
		   ,@bus_name varchar(500)
		   ,@yatra_date date
		   ,@Alternate_Mobile varchar(50) = null
		   ,@Auto_Time timestamp = null,
		   @Created_By varchar(100),
		   @Created_Date datetime = null)
		   

AS
BEGIN 
DECLARE @custID int;
DECLARE @bus_master_id int;
     SET NOCOUNT ON ;
	if @Created_Date is null
		set @Created_Date = GETDATE()
	select @bus_master_id = bus_master_id from bus_master where 
								Bus_Name = @bus_name and CONVERT(date, navratri_date) = @yatra_date
								and Seat_No = @Seat_No;


	if @Auto_Time is not null
	begin
		if not exists(select 1 from bus_master where 
								Bus_Name = @bus_name and CONVERT(date, navratri_date) = @yatra_date
								and Seat_No = @Seat_No and Auto_Time = @Auto_Time)
		begin
			select 'Seat Availability Changed'
			return;
		end
	end

	if exists(select 1 from dbo.Customer_Master where Mobile_No = @Mobile_No and IS_DLT = 0)
	BEGIN
		SET @custID = (select Customer_ID from dbo.Customer_Master where Mobile_No = @Mobile_No and IS_DLT = 0);

		UPDATE [dbo].[Customer_Master]
		SET [First_Name] = @First_Name
		  ,[Last_Name] = @Last_Name
		  ,[Address] = @Address
		  ,[Area_ID] = @Area_ID
		  ,[Age] = @Age
		  ,[Birth_Date] = @Birth_Date
		  ,[Blood_Group] = @Blood_Group
		  ,[Mobile_No] = @Mobile_No
		  ,Alternate_Mobile = @Alternate_Mobile		  
		  ,Updated_By = @Created_By
		  ,Updated_Date = @Created_Date
		 WHERE Customer_ID = @custID
	END
	ELSE
	BEGIN
		 INSERT INTO [dbo].[Customer_Master]
			   ([Registration_Date] 
			   ,[First_Name] 
			   ,[Last_Name] 
			   ,[Address] 
			   ,[Area_ID]
			   ,[Age] 
			   ,[Birth_Date]
			   ,[Blood_Group]
			   ,[Mobile_No]
			   ,[Alternate_Mobile]
			   ,Created_By
			   ,Created_Date
			   )
		 VALUES
			   (@Registration_Date
			   ,@First_Name
			   ,@Last_Name
			   ,@Address
			   ,@Area_ID
			   ,@Age
			   ,@Birth_Date
			   ,@Blood_Group
			   ,@Mobile_No
			   ,@Alternate_Mobile
			   ,@Created_By
			   ,@Created_Date);

				select @custID = SCOPE_IDENTITY() ;
	END

	update Bus_Master set Is_Seat_Available = 0 where Bus_Master_ID = @bus_master_id -- Marked seat as blocked


	INSERT INTO [dbo].[bus_Mapping]
           ([Customer_ID]
           ,[Bus_Master_ID]
		   ,Discount
		   ,Discount_Given_By
		   ,DiscountReason
		   ,Actual_Fees
		   ,Created_By
		   ,Created_Date)
     VALUES
           (@custID,
			@bus_master_id
			,@Discount
		   ,@Discount_Given_By
		   ,@DiscountReason
		   ,@Fees - @Discount
		   ,@Created_By
		   ,@Created_Date);

	select Convert(varchar, @custID) + '|' + Convert(varchar, @bus_master_id) ;
END 


GO

CREATE PROCEDURE [dbo].[sp_UpdateCustomerAndTravel]
		@Customer_ID int,
       @Registration_Date date,
	   @Yatra_Date date,
	   @First_Name varchar(50),
	   @Last_Name varchar(50), 
	   @Address varchar(500),
	   @Area_ID int = null,
	   @Mobile_No varchar(50),
	   @Age numeric(6, 2),
	   @Birth_Date date = null, 
	   @Blood_Group varchar(50) = null,
			@DiscountChanged bit = false,
		   @Discount int = 0,
		   @Discount_Given_By varchar(50) = null,
		   @DiscountReason varchar(50) = null,
	   @Bus_Name varchar(50),
	   @Seat_No int,
	   @Fees int = null,
	   @Alternate_Mobile varchar(50) = null,
		@old_Bus_Master_ID int,
		@Auto_Time timestamp = null,
		@Updated_By	 varchar(100),
		@Updated_Date datetime = null
	   

AS
BEGIN 
     SET NOCOUNT ON 
     DECLARE @bus_master_id int;

	 if @Updated_Date is null
		set @Updated_Date = GETDATE()

	 if @Auto_Time is not null
	begin
		if not exists(select 1 from bus_master where 
								Bus_Name = @bus_name and CONVERT(date, navratri_date) = @yatra_date
								and Seat_No = @Seat_No and Auto_Time = @Auto_Time)
		begin
			select 'Seat Availability Changed'
			return;
		end
	end


    update Bus_Master set Is_Seat_Available = 1 where Bus_Master_ID = @old_Bus_Master_ID;
     
    delete from bus_Mapping where Customer_ID = @Customer_ID and Bus_Master_ID = @old_Bus_Master_ID
     
    select @bus_master_id = bus_master_id from bus_master where 
								Bus_Name = @bus_name and CONVERT(date, navratri_date) = @yatra_date
								and Seat_No = @Seat_No;
	update Bus_Master set Is_Seat_Available = 0 where Bus_Master_ID = @bus_master_id -- Marked seat as blocked
    
	-- Below Update is added so that there will be only one customer with given mobile number
	UPDATE [dbo].[Customer_Master]
	SET Mobile_No = NULL where [Mobile_No] = @Mobile_No and IS_DLT = 0


    UPDATE [dbo].[Customer_Master]
	SET [First_Name] = @First_Name
      ,[Last_Name] = @Last_Name
      ,[Address] = @Address
	  ,[Area_ID] = @Area_ID
      ,[Age] = @Age
      ,[Birth_Date] = @Birth_Date
      ,[Blood_Group] = @Blood_Group
      ,[Mobile_No] = @Mobile_No      
	  ,Alternate_Mobile = @Alternate_Mobile	  
	  ,Updated_By = @Updated_By
	  ,Updated_Date = @Updated_Date
	 WHERE Customer_ID = @Customer_ID and IS_DLT = 0
	 
	 insert into bus_Mapping (Customer_ID,Bus_Master_ID,Discount
		   ,Discount_Given_By
		   ,DiscountReason
		   ,Actual_Fees
		   ,Created_By
		   ,Created_Date) 
		   select @Customer_ID, @bus_master_id,@Discount
		   ,@Discount_Given_By
		   ,@DiscountReason
		   ,@Fees - @Discount
		   ,@Updated_By
		   ,@Updated_Date

		select Convert(varchar, @Customer_ID) + '|' + Convert(varchar, @bus_master_id) ;
    

END 


GO

CREATE PROCEDURE [dbo].[sp_getCustomerDetailsForMobileNumber]
		
     (  @Mobile_No varchar(50))

AS
BEGIN 
     SET NOCOUNT ON 

	select 	cMaster.Customer_ID, cMaster.First_Name, 
			cMaster.Last_Name, cMaster.Address, isnull(cMaster.Area_ID,0) Area_ID,
			cMaster.Mobile_No, cMaster.Blood_Group,cMaster.Alternate_Mobile, format(cMaster.Birth_Date,'dd/MMM/yyyy') Birth_Date
	from
	dbo.Customer_Master cMaster
	left join
	dbo.Area_Master tArea on tArea.Area_ID = cMaster.Area_ID
	where Mobile_No = @Mobile_No and IS_DLT = 0

END 


GO

ALTER PROCEDURE [dbo].[sp_AllYatraDateAllBusesCashReport] --'2016-10-02','2016-10-05'
		
       @Yatra_Date_From    date, @Yatra_Date_To date

AS
BEGIN 
     SET NOCOUNT ON 

	Select format( bmp.Created_Date,'dd-MMM-yyyy') as Registration_Date,format(bm.Navratri_Date,'dd-MMM-yyyy') as Yatra_Date,
	bm.Bus_Name,brm.Bus_Route, count(bm.Seat_No) as Total_Booked_Seats, avg(bm.Bus_Fees) as Bus_Fees, sum(bm.Bus_Fees) as Total_Bus_Fees,
	sum(isnull(bmp.Actual_Fees,0)) as Total_Collected_Fees,
	 -- Changed Field
	 sum(isnull(bmp.Discount,0)) 
	from
	DBO.Customer_Master cm
	inner join
	DBO.bus_Mapping bmp
	on cm.Customer_ID = bmp.Customer_ID
	inner join
	DBO.Bus_Master bm
	on bmp.Bus_Master_ID = bm.Bus_Master_ID
	inner join
	dbo.Bus_Route_Master brm
	on brm.Route_ID = bm.Route_ID
	where bm.Is_Seat_Available = 0 and bm.Navratri_Date between @Yatra_Date_From and @Yatra_Date_To --'2015-10-08'
	group by format( bmp.Created_Date,'dd-MMM-yyyy'),format(bm.Navratri_Date,'dd-MMM-yyyy'),bm.Bus_Name,brm.Bus_Route
	--having count(bm.Seat_No) > 0 and sum(isnull(bmp.Actual_Fees,0)) > 0
	order by format( bmp.Created_Date,'dd-MMM-yyyy'),format(bm.Navratri_Date,'dd-MMM-yyyy'),bm.Bus_Name

END
GO

ALTER PROCEDURE [dbo].[sp_DailyCashReport] --'2016-10-5'
		
       @Registration_Date    date

AS
BEGIN 
     SET NOCOUNT ON 

	Select format(bmp.Created_Date,'dd-MMM-yyyy') as Registration_Date,format(bm.Navratri_Date,'dd-MMM-yyyy') as Yatra_Date,
	bm.Bus_Name,brm.Bus_Route, count(bm.Seat_No) as Total_Booked_Seats, avg(bm.Bus_Fees) as Bus_Fees, sum(bm.Bus_Fees) as Total_Bus_Fees,
	sum(isnull(bmp.Actual_Fees,0)) as Total_Collected_Fees, -- Changed Field
	sum(isnull(bmp.Discount,0)) as Total_Discount
	from
	Customer_Master cm
	inner join
	bus_Mapping bmp
	on cm.Customer_ID = bmp.Customer_ID
	inner join
	Bus_Master bm
	on bmp.Bus_Master_ID = bm.Bus_Master_ID
	inner join
	dbo.Bus_Route_Master brm
	on bm.Route_ID = brm.Route_ID
	where bm.Is_Seat_Available = 0 and convert(date, bmp.Created_Date) = @Registration_Date --'2015-10-08'
	group by format(bmp.Created_Date,'dd-MMM-yyyy'),format(bm.Navratri_Date,'dd-MMM-yyyy'),bm.Bus_Name,brm.Bus_Route
	--having sum(isnull(bmp.Actual_Fees,0)) > 0 and sum(isnull(bmp.Discount,0)) > 0
	order by format(bmp.Created_Date,'dd-MMM-yyyy'),format(bm.Navratri_Date,'dd-MMM-yyyy'),bm.Bus_Name

END
GO

ALTER PROCEDURE [dbo].[sp_DailyCashReport_Yearly] --'2015-10-8'
		
       @FromDate    date, @ToDate date

AS
BEGIN 
     SET NOCOUNT ON 

	Select format(bmp.Created_Date,'dd-MMM-yyyy') as Registration_Date,format(bm.Navratri_Date,'dd-MMM-yyyy') as Yatra_Date,
	bm.Bus_Name,brm.Bus_Route, count(bm.Seat_No) as Total_Booked_Seats, avg(bm.Bus_Fees) as Bus_Fees, sum(bm.Bus_Fees) as Total_Bus_Fees,
	sum(isnull(bmp.Actual_Fees,0)) as Total_Collected_Fees, -- Changed Field
	sum(isnull(bmp.Discount,0)) as Total_Discount
	from
	Customer_Master cm
	inner join
	bus_Mapping bmp
	on cm.Customer_ID = bmp.Customer_ID
	inner join
	Bus_Master bm
	on bmp.Bus_Master_ID = bm.Bus_Master_ID
	inner join
	dbo.Bus_Route_Master brm
	on bm.Route_ID = brm.Route_ID
	where bm.Is_Seat_Available = 0 and convert(date, bmp.Created_Date) between @FromDate and @ToDate
	group by format(bmp.Created_Date,'dd-MMM-yyyy'),format(bm.Navratri_Date,'dd-MMM-yyyy'),bm.Bus_Name,brm.Bus_Route
	order by format(bmp.Created_Date,'dd-MMM-yyyy'),format(bm.Navratri_Date,'dd-MMM-yyyy'),bm.Bus_Name

END

GO

ALTER PROCEDURE [dbo].[sp_CashReport_Userwise] --null,2016
	@UserName varchar(15) = null,
       @YatraYear int

AS
BEGIN 
     SET NOCOUNT ON 

	 declare @tbl table
	 ([User_Name] varchar(15), Full_Name varchar(40), Registration_date date, Yatra_Date date, Bus_Name varchar(50), 
	 TotalCustomers int, TotalDiscount int, Bus_Fees int, Fees int)

	insert into @tbl
	([User_Name], Full_Name, Yatra_Date, Bus_Name, Registration_date ,TotalCustomers, TotalDiscount, Bus_Fees, Fees)
	select uMaster.User_Name, uMaster.First_Name + ' ' + uMaster.Last_Name, 
	format(bMaster.Navratri_Date, 'dd-MMM-yyyy') as yatra_date ,bMaster.Bus_Name, format(busMapping.Created_Date, 'dd-MMM-yyyy') as Registration_Date, count(cMaster.Customer_ID) TotalCustomers, 	
	sum(busMapping.Discount) TotalDiscount, avg(bMaster.Bus_Fees) Bus_Fees, sum(busMapping.Actual_Fees) Fees -- Changed field
	from
	Bus_Master bMaster
	inner join
	bus_Mapping busMapping
	on busMapping.Bus_Master_ID = bMaster.Bus_Master_ID
	inner join
	Customer_Master cMaster
	on cMaster.Customer_ID = busMapping.Customer_ID
	inner join
	dbo.User_Master uMaster
	on uMaster.User_Name = cMaster.Created_By
	where year(bMaster.Navratri_Date) = @YatraYear
	and isnull(@UserName, [User_Name]) = cMaster.Created_By
	and cMaster.Created_By is not null
	group by
	uMaster.User_Name, uMaster.First_Name + ' ' + uMaster.Last_Name, 
	format(bMaster.Navratri_Date, 'dd-MMM-yyyy'),format(busMapping.Created_Date, 'dd-MMM-yyyy'),bMaster.Bus_Name

	select [User_Name], full_Name, Yatra_Date, Registration_date,Bus_Name, TotalCustomers, TotalDiscount, Bus_Fees, Fees from @tbl
END 

GO

ALTER PROCEDURE [dbo].[sp_CashReport_UserwiseYearly] --2016



       @YatraYear int

AS
BEGIN 
     SET NOCOUNT ON 

	 declare @tbl table
	 ([User_Name] varchar(15), Full_Name varchar(40), Yatra_Date date, 
	 TotalCustomers int, TotalDiscount int, Fees int)

	insert into @tbl
	([User_Name], Full_Name, Yatra_Date, TotalCustomers, TotalDiscount, Fees)
	select uMaster.User_Name, uMaster.First_Name + ' ' + uMaster.Last_Name, 
	format(bMaster.Navratri_Date, 'dd-MMM-yyyy') as yatra_date ,count(cMaster.Customer_ID) TotalCustomers, 	
	sum(isnull(busMapping.Discount,0)) TotalDiscount, sum(isnull(busMapping.Actual_Fees,0)) Fees -- Changed field
	from
	Bus_Master bMaster
	inner join
	bus_Mapping busMapping
	on busMapping.Bus_Master_ID = bMaster.Bus_Master_ID
	inner join
	Customer_Master cMaster
	on cMaster.Customer_ID = busMapping.Customer_ID
	inner join
	dbo.User_Master uMaster
	on uMaster.User_Name = cMaster.Created_By
	where year(bMaster.Navratri_Date) = @YatraYear
	and cMaster.Created_By is not null
	group by
	uMaster.User_Name, uMaster.First_Name + ' ' + uMaster.Last_Name, 
	format(bMaster.Navratri_Date, 'dd-MMM-yyyy')

	select [User_Name], full_Name, Yatra_Date, TotalCustomers, TotalDiscount, Fees from @tbl
END 

GO

ALTER PROCEDURE [dbo].[sp_CashReport]
		
       @Yatra_Date    date,
	   @Bus_Name varchar(50) = null

AS
BEGIN 
     SET NOCOUNT ON 

	 declare @tbl table
	 (Yatra_Date date, Bus_Name varchar(50), Seat_No int, Customer_ID int, First_Name varchar(50), Last_Name varchar(50),
		Mobile_No varchar(50), Alternate_Mobile varchar(50), Registration_Date date, Bus_Fees int, Fees int)

	insert into @tbl
	(Yatra_Date, Bus_Name, Seat_No, Customer_ID, First_Name, Last_Name,
		Mobile_No, Alternate_Mobile, Registration_Date, Bus_Fees, Fees)
	select format(bMaster.Navratri_Date, 'dd-MMM-yyyy') as yatra_date ,bMaster.Bus_Name, bMaster.Seat_No, cMaster.Customer_ID, 
	cMaster.First_Name, cMaster.Last_Name, cMaster.Mobile_No, cMaster.Alternate_Mobile, busMapping.Created_Date,
	(case when cMaster.First_Name is not null then bMaster.Bus_Fees else '' end) Bus_Fees, isnull(busMapping.Actual_Fees,0) Fees -- Changed field
	from
	Bus_Master bMaster
	inner join
	bus_Mapping busMapping
	on busMapping.Bus_Master_ID = bMaster.Bus_Master_ID
	inner join
	Customer_Master cMaster
	on cMaster.Customer_ID = busMapping.Customer_ID
	where bMaster.Navratri_Date = @Yatra_Date
	and bMaster.Bus_Name = isnull(@Bus_Name,bMaster.Bus_Name)
	--order by bMaster.Navratri_Date ,bMaster.Bus_Name, bMaster.Seat_No

	select format(yatra_date, 'dd-MMM-yyyy') as yatra_date, Bus_Name, Seat_No, Customer_ID, First_Name, Last_Name,
		Mobile_No, Alternate_Mobile, Registration_Date, Bus_Fees, Fees from @tbl
		order by yatra_date,Bus_Name,Seat_No

	select Yatra_Date, Bus_Name, sum(isnull(Bus_Fees,0)) Expected_Income, sum(isnull(Fees,0)) Actual_Income from @tbl group by Yatra_Date, Bus_Name

END 
GO

ALTER PROCEDURE [dbo].[sp_CashReport_Yearly]
		
       @FromDate    date,
	   @ToDate    date

AS
BEGIN 
     SET NOCOUNT ON 

	 declare @tbl table
	 (Yatra_Date date, Bus_Name varchar(50), Seat_No int, Customer_ID int, First_Name varchar(50), Last_Name varchar(50),
		Mobile_No varchar(50), Alternate_Mobile varchar(50), Registration_Date date, Bus_Fees int, Fees int)

	insert into @tbl
	(Yatra_Date, Bus_Name, Seat_No, Customer_ID, First_Name, Last_Name,
		Mobile_No, Alternate_Mobile, Registration_Date, Bus_Fees, Fees)
	select format(bMaster.Navratri_Date, 'dd-MMM-yyyy') as yatra_date ,bMaster.Bus_Name, bMaster.Seat_No, cMaster.Customer_ID, 
	cMaster.First_Name, cMaster.Last_Name, cMaster.Mobile_No, cMaster.Alternate_Mobile, busMapping.Created_Date,
	(case when cMaster.First_Name is not null then bMaster.Bus_Fees else '' end) Bus_Fees, isnull(busMapping.Actual_Fees,0) Fees -- Changed field
	from
	Bus_Master bMaster
	inner join
	bus_Mapping busMapping
	on busMapping.Bus_Master_ID = bMaster.Bus_Master_ID
	inner join
	Customer_Master cMaster
	on cMaster.Customer_ID = busMapping.Customer_ID
	where bMaster.Navratri_Date between @FromDate and @ToDate
	--and bMaster.Bus_Name = isnull(@Bus_Name,bMaster.Bus_Name)
	--order by bMaster.Navratri_Date ,bMaster.Bus_Name, bMaster.Seat_No

	select format(yatra_date, 'dd-MMM-yyyy') as yatra_date, Bus_Name, Seat_No, Customer_ID, First_Name, Last_Name,
		Mobile_No, Alternate_Mobile, Registration_Date, Bus_Fees, Fees from @tbl
		order by yatra_date,Bus_Name,Seat_No

	select Yatra_Date, Bus_Name, sum(isnull(Bus_Fees,0)) Expected_Income, sum(isnull(Fees,0)) Actual_Income from @tbl group by Yatra_Date, Bus_Name

END 

GO

ALTER PROCEDURE [dbo].[sp_DiscountReport_Yearly]
		
       @FromDate    date, @ToDate date

AS
BEGIN 
     SET NOCOUNT ON 

	Select format(bmp.Created_Date,'dd-MMM-yyyy') as Registration_Date,format(bm.Navratri_Date,'dd-MMM-yyyy') as Yatra_Date,
	bm.Bus_Name,cm.First_Name as customer_First_Name,cm.Last_Name as customer_Last_Name,
	isnull(bmp.Discount,0) Discount,um.First_Name as Discount_First_Name,um.Last_Name as discount_Last_Name,
	bmp.DiscountReason
	from
	Customer_Master cm
	inner join
	bus_Mapping bmp
	on cm.Customer_ID = bmp.Customer_ID
	inner join
	Bus_Master bm
	on bmp.Bus_Master_ID = bm.Bus_Master_ID
	inner join
	User_Master um
	on bmp.Discount_Given_By = um.[User_Name]
	where bm.Is_Seat_Available = 0 and convert(date, bmp.Created_Date) between @FromDate and @ToDate
	and isnull(bmp.Discount,0) <> 0
	order by bmp.Created_Date,bm.Navratri_Date,bm.Bus_Name

END


GO

ALTER PROCEDURE [dbo].[sp_BirthDateReport] --null, '2016-10-05', 1
@BirthMonth int = NULL,
@BirthDate date =NULL,
@ForReport bit = 0
AS
BEGIN 
     SET NOCOUNT ON 
	 --declare @BloodGroup	 varchar(5); set @BloodGroup = null
SELECT distinct 1 as Checked, format(Birth_Date,'dd-MMM-yyyy') Birth_Date
      ,[First_Name]
      ,[Last_Name]
      ,(case when @ForReport = 0 then '' else Address end) [Address]
	  ,Mobile_No
  FROM [dbo].[Customer_Master]
  where month(Birth_Date) = isnull(@BirthMonth,month(Birth_Date))
  and year(Birth_Date) = IIF( @BirthMonth is null,year(Birth_Date),year(getdate()))
  and Birth_Date = isnull(@BirthDate, Birth_Date)
  and Birth_Date is not null
  and year(Created_Date) > 2015



END 

GO

ALTER PROCEDURE [dbo].[sp_getBusRegistrationInfo]

AS
BEGIN 
     SET NOCOUNT ON 
/****** Script for SelectTopNRows command from SSMS  ******/
SELECT brm.Route_ID, brm.Bus_Route, masterT.Navratri_Date, masterT.Bus_Name,masterT.Bus_Time , masterT.Seat_No, masterT.Is_Seat_Available, masterT.Bus_Fees
  FROM 
  Bus_Master masterT
  inner join
  dbo.Bus_Route_Master brm
  on masterT.Route_ID = brm.Route_ID

  

END 

GO

ALTER PROCEDURE [dbo].[sp_getBusRegistrationInfo]

AS
BEGIN 
     SET NOCOUNT ON 
/****** Script for SelectTopNRows command from SSMS  ******/
SELECT brm.Route_ID, brm.Bus_Route, masterT.Navratri_Date, masterT.Bus_Name,masterT.Bus_Time , masterT.Seat_No, masterT.Is_Seat_Available, masterT.Bus_Fees
  FROM 
  Bus_Master masterT
  inner join
  dbo.Bus_Route_Master brm
  on masterT.Route_ID = brm.Route_ID
END 
GO

Create procedure dbo.sp_getBusRoutes
as
begin
SET NOCOUNT ON;
SELECT brm.Route_ID, brm.Bus_Route
  FROM 
  dbo.Bus_Route_Master brm order by brm.Bus_Route
end
GO

create procedure dbo.sp_InsertBusRoute
(@Bus_Route varchar(50), @Created_By varchar(50))
AS
BEGIN
	SET NOCOUNT ON;
	Insert into dbo.Bus_Route_Master(Bus_Route,Created_By,Created_Date)
	values(@Bus_Route, @Created_By,getdate())  
	select SCOPE_IDENTITY();
END
GO

create procedure dbo.sp_UpdateBusRoute
(@Route_ID int, @Bus_Route varchar(50), @Updated_By varchar(50))
AS
BEGIN
	SET NOCOUNT ON;
	Update dbo.Bus_Route_Master
	set Bus_Route = @Bus_Route, Updated_By = @Updated_By, Updated_Date = GETDATE()
	where Route_ID = @Route_ID

	select @Route_ID
END
GO

CREATE procedure [dbo].[sp_getNavratriDatesForBusRoute]
@Route_ID int = NULL
as
begin
SET NOCOUNT ON;
SELECT distinct Navratri_Date from dbo.Bus_Master where Route_ID = isnull(@Route_ID,Route_ID)
and year(Navratri_Date) = year(getdate())
order by Navratri_Date
end
GO

create procedure dbo.sp_getUserwiseTickets --null
@userName varchar(50) = null
as
BEGIN
	SET NOCOUNT ON;
	select bMapping.Created_Date as Registration_Date,brm.Route_ID, brm.Bus_Route, bMaster.Bus_Fees,
	bMaster.Bus_Name, bMaster.Navratri_Date as Yatra_Date, bMaster.Seat_No,
	cMaster.First_Name, cMaster.Last_Name, uMaster.First_Name + ' ' + uMaster.Last_Name [User_Name]
	from dbo.Bus_Route_Master brm
	inner join
	dbo.Bus_Master bMaster
	on brm.Route_ID = bMaster.Route_ID
	inner join dbo.bus_Mapping bMapping
	on bMapping.Bus_Master_ID = bMaster.Bus_Master_ID
	inner join
	dbo.Customer_Master cMaster
	on cMaster.Customer_ID = bMapping.Customer_ID
	inner join
	dbo.User_Master uMaster
	on uMaster.User_Name = bMapping.Created_By
	where bMapping.Created_By is not null
	and uMaster.User_Name = isnull(@userName, uMaster.User_Name)

END
GO
-- ***** Bus Route ID Impacted SPs START ******

ALTER PROCEDURE [dbo].[sp_AllYatraDateAllBusesCashReport] --'2016-10-02','2016-10-05'
		
       @Yatra_Date_From    date, @Yatra_Date_To date

AS
BEGIN 
     SET NOCOUNT ON 

	Select format(bmp.Created_Date,'dd-MMM-yyyy') as Registration_Date,format(bm.Navratri_Date,'dd-MMM-yyyy') as Yatra_Date,
	bm.Bus_Name,brm.Bus_Route, count(bm.Seat_No) as Total_Booked_Seats, avg(bm.Bus_Fees) as Bus_Fees, sum(bm.Bus_Fees) as Total_Bus_Fees,
	sum(isnull(bmp.Actual_Fees,0)) as Total_Collected_Fees,
	 -- Changed Field
	 sum(isnull(bmp.Discount,0)) 
	from
	DBO.Customer_Master cm
	inner join
	DBO.bus_Mapping bmp
	on cm.Customer_ID = bmp.Customer_ID
	inner join
	DBO.Bus_Master bm
	on bmp.Bus_Master_ID = bm.Bus_Master_ID
	inner join
	dbo.Bus_Route_Master brm
	on brm.Route_ID = bm.Route_ID
	where bm.Is_Seat_Available = 0 and bm.Navratri_Date between @Yatra_Date_From and @Yatra_Date_To --'2015-10-08'
	group by format(bmp.Created_Date,'dd-MMM-yyyy'),format(bm.Navratri_Date,'dd-MMM-yyyy'),bm.Bus_Name,brm.Bus_Route
	--having count(bm.Seat_No) > 0 and sum(isnull(bmp.Actual_Fees,0)) > 0
	order by format(bmp.Created_Date,'dd-MMM-yyyy'),format(bm.Navratri_Date,'dd-MMM-yyyy'),bm.Bus_Name

END
GO

ALTER PROCEDURE [dbo].[sp_getAvailableSeatNo]
		
     (  @Yatra_Date    date,
	   @Bus_Name varchar(50),
	   @Route_ID int)

AS
BEGIN 
     SET NOCOUNT ON 

select bMaster.Seat_No, bMaster.Bus_Fees, brm.Route_ID, brm.Bus_Route, bMaster.Bus_Time, bMaster.Auto_Time 
from 
dbo.Bus_Master bMaster
inner join
dbo.Bus_Route_Master brm
on bMaster.Route_ID = brm.Route_ID where 
CONVERT(date, Navratri_Date) = @Yatra_Date and Bus_Name = @Bus_Name and brm.Route_ID = @Route_ID
and Is_Seat_Available = 1
order by bMaster.Seat_No

END

GO

ALTER PROCEDURE [dbo].[sp_SearchReport] --@First_Name = 'tobedeleted'
		(@Cust_ID int = NULL,
		@Blood_Group varchar(50) = NULL,
		@Mobile_No varchar(50) = NULL,
		@Alternate_Mobile_No varchar(50) = NULL,
       @Yatra_Date    date = NULL,
	   @Yatra_Year int = NULL,
	   @First_Name varchar(50) = NULL,
	   @Last_Name varchar(50) = NULL,
	   @Bus_Name varchar(50) = NULL)

AS
BEGIN 
     SET NOCOUNT ON 

	select 
	cMaster.Customer_ID, busMapping.Bus_Master_ID , format(busMapping.Created_Date,'dd-MMM-yyyy') as Registration_Date, cMaster.First_Name, 
			cMaster.Last_Name, cMaster.[Address], 
			cMaster.Mobile_No, cMaster.Alternate_Mobile, format(bMaster.Navratri_Date, 'dd-MMM-yyyy') as yatra_date, 
			bMaster.Navratri_Date, bMaster.Bus_Name, bMaster.Seat_No, bMaster.Bus_Time, brm.Route_ID, brm.Bus_Route
	from
	dbo.Customer_Master cMaster
	inner join
	dbo.bus_Mapping busMapping
	on cMaster.Customer_ID = busMapping.Customer_ID
	inner join
	dbo.Bus_Master bMaster
	on bMaster.Bus_Master_ID = busMapping.Bus_Master_ID
	inner join
	dbo.Bus_Route_Master brm
	on bMaster.Route_ID = brm.Route_ID
	where cMaster.Customer_ID = isnull(@Cust_ID,cMaster.Customer_ID)
	and isnull(cMaster.Blood_Group,'') like isnull(@Blood_Group+'%',isnull(cMaster.Blood_Group,''))
	and cMaster.Mobile_No like isnull(@Mobile_No+'%',cMaster.Mobile_No)
	and isnull(cMaster.Alternate_Mobile,'') like isnull(@Alternate_Mobile_No+'%',isnull(cMaster.Alternate_Mobile,''))
	and Convert(date, bMaster.Navratri_Date) = isnull(Convert(date, @Yatra_date), Convert(date, bMaster.Navratri_Date))
	and year(bMaster.Navratri_Date) = isnull(@Yatra_Year, year(bMaster.Navratri_Date))
	and cMaster.First_Name like isnull(@First_Name+'%',cMaster.First_Name)
	and cMaster.Last_Name like isnull(@Last_Name+'%',cMaster.Last_Name)
	and bMaster.Bus_Name like ISNULL(@Bus_Name+'%',bMaster.Bus_Name)
	order by bMaster.Navratri_Date, bMaster.Bus_Name, bMaster.Seat_No

END 
GO
ALTER PROCEDURE [dbo].[sp_DailyCashReport] --'2016-10-5'
		
       @Registration_Date    date

AS
BEGIN 
     SET NOCOUNT ON 

	Select format(bmp.Created_Date,'dd-MMM-yyyy') as Registration_Date,format(bm.Navratri_Date,'dd-MMM-yyyy') as Yatra_Date,
	bm.Bus_Name,brm.Bus_Route, count(bm.Seat_No) as Total_Booked_Seats, avg(bm.Bus_Fees) as Bus_Fees, sum(bm.Bus_Fees) as Total_Bus_Fees,
	sum(isnull(bmp.Actual_Fees,0)) as Total_Collected_Fees, -- Changed Field
	sum(isnull(bmp.Discount,0)) as Total_Discount
	from
	Customer_Master cm
	inner join
	bus_Mapping bmp
	on cm.Customer_ID = bmp.Customer_ID
	inner join
	Bus_Master bm
	on bmp.Bus_Master_ID = bm.Bus_Master_ID
	inner join
	dbo.Bus_Route_Master brm
	on bm.Route_ID = brm.Route_ID
	where bm.Is_Seat_Available = 0 and convert(date, bmp.Created_Date) = @Registration_Date --'2015-10-08'
	group by format(bmp.Created_Date,'dd-MMM-yyyy'),format(bm.Navratri_Date,'dd-MMM-yyyy'),bm.Bus_Name,brm.Bus_Route
	--having sum(isnull(bmp.Actual_Fees,0)) > 0 and sum(isnull(bmp.Discount,0)) > 0
	order by format(bmp.Created_Date,'dd-MMM-yyyy'),format(bm.Navratri_Date,'dd-MMM-yyyy'),bm.Bus_Name

END
GO

ALTER PROCEDURE [dbo].[sp_DailyCashReport_Yearly] --'2015-10-8'
		
       @FromDate    date, @ToDate date

AS
BEGIN 
     SET NOCOUNT ON 

	Select format(bmp.Created_Date,'dd-MMM-yyyy') as Registration_Date,format(bm.Navratri_Date,'dd-MMM-yyyy') as Yatra_Date,
	bm.Bus_Name,brm.Bus_Route, count(bm.Seat_No) as Total_Booked_Seats, avg(bm.Bus_Fees) as Bus_Fees, sum(bm.Bus_Fees) as Total_Bus_Fees,
	sum(isnull(bmp.Actual_Fees,0)) as Total_Collected_Fees, -- Changed Field
	sum(isnull(bmp.Discount,0)) as Total_Discount
	from
	Customer_Master cm
	inner join
	bus_Mapping bmp
	on cm.Customer_ID = bmp.Customer_ID
	inner join
	Bus_Master bm
	on bmp.Bus_Master_ID = bm.Bus_Master_ID
	inner join
	dbo.Bus_Route_Master brm
	on bm.Route_ID = brm.Route_ID
	where bm.Is_Seat_Available = 0 and CONVERT(date, bmp.Created_Date) between @FromDate and @ToDate
	group by format(bmp.Created_Date,'dd-MMM-yyyy'),format(bm.Navratri_Date,'dd-MMM-yyyy'),bm.Bus_Name,brm.Bus_Route
	order by format(bmp.Created_Date,'dd-MMM-yyyy'),format(bm.Navratri_Date,'dd-MMM-yyyy'),bm.Bus_Name

END
GO


ALTER PROCEDURE [dbo].[sp_UpdateBusRegistration]
		(@Bus_Name varchar(50)
           ,@Navratri_Date datetime
           ,@Seat_No varchar(300)
           ,@Seat_Count int
		   ,@Bus_Fees int
		   ,@Route_ID int
		   ,@Bus_Time time(2) = null,
		   @UserName varchar(50))
		   

AS
BEGIN 
DECLARE @custID int;
DECLARE @bus_master_id int;
     SET NOCOUNT ON ;
	 
	 if not exists(select 1 from [dbo].[Bus_Master] where Bus_Name = @Bus_Name 
			and CONVERT(date, Navratri_Date) = CONVERT(date,@Navratri_Date) )
		begin
			DECLARE @id INT
			SET @id = 1
			WHILE (@id <= @Seat_Count)
			BEGIN
				INSERT INTO [dbo].[Bus_Master]
			   ([Bus_Name]
			   ,[Navratri_Date]
			   ,[Is_Seat_Available]
			   ,[Seat_No]
			   ,[Bus_Fees]
			   ,[Route_ID]
			   ,[Bus_Time]
			   ,Created_By
			   ,Created_Date
			   )
				select @Bus_Name, @Navratri_Date, NULL, @id, @Bus_Fees, @Route_ID, @Bus_Time, @UserName, GETDATE();
				SELECT @id = @id + 1
			END			
		end
	else
		begin
			update [dbo].[Bus_Master] 
			set Bus_Fees = @Bus_Fees, Route_ID = @Route_ID, Bus_Time = @Bus_Time,
			Updated_By = @UserName, Updated_Date = GETDATE()
			where Bus_Name = @Bus_Name 
					and CONVERT(date, Navratri_Date) = CONVERT(date,@Navratri_Date)
		end
	update [dbo].[Bus_Master] 
	set Is_Seat_Available = NULL,
	Updated_By = @UserName, Updated_Date = GETDATE()
	where Bus_Name = @Bus_Name 
			and CONVERT(date, Navratri_Date) = CONVERT(date,@Navratri_Date) and Is_Seat_Available = 1
			
	update masterT
	set masterT.Is_Seat_Available = 1,
	masterT.Updated_By = @UserName, masterT.Updated_Date = GETDATE()
	from
	dbo.Bus_Master masterT
	inner join
	dbo.SplitString(@Seat_No, ',') fn
	on masterT.Seat_No = CONVERT(int, fn.Name)
	where 
	Bus_Name = @Bus_Name 
			and CONVERT(date, Navratri_Date) = CONVERT(date,@Navratri_Date) and Is_Seat_Available is null
	
	select 1;
END
GO

-- ***** Bus Route ID Impacted SPs END ******

create procedure [dbo].[GetElectionReport] --null

@Area_ID int = null
as
begin
	SET NOCOUNT ON

	declare @tbl table (Customer_ID int,
	First_Name varchar(50),
	Last_Name  varchar(50),
	Address  varchar(300),
	Mobile_No  varchar(50),
	Alternate_Mobile  varchar(50),
	area  varchar(50),area_id int)

	insert into @tbl(Customer_ID,
	First_Name,
	Last_Name,
	Address,
	Mobile_No,
	Alternate_Mobile, area_id)
	select Customer_ID,
	First_Name,
	Last_Name,
	Address,
	Mobile_No,
	Alternate_Mobile,
	Area_ID
	from dbo.Customer_Master cMaster
	where isnull(cMaster.Area_ID,'') = ISNULL(@Area_ID, isnull(cMaster.Area_ID,''))

	update t set area = am.Area
	from
	dbo.Area_Master am
	join
	@tbl t
	on am.Area_ID = t.area_id

	select Customer_ID,
	First_Name,
	Last_Name,
	Address,
	Mobile_No,
	Alternate_Mobile,
	Area_ID, area from @tbl

end
GO

-- ***** Customer Manegement SPs START ******
CREATE procedure [dbo].[InsertCustomer](@First_Name varchar(50)
           ,@Last_Name varchar(50)
           ,@Address varchar(500)
		   ,@Area_ID int = null
           ,@Birth_Date date = NULL
           ,@Blood_Group varchar(50) = NULL
           ,@Mobile_No varchar(50)
           ,@Alternate_Mobile varchar(50) = NULL
           ,@UserName varchar(100))
as
begin
SET NOCOUNT ON

if exists(select 1 from dbo.Customer_Master where Mobile_No = @Mobile_No and IS_DLT = 0)
begin
	select 0;
	return;
end

INSERT INTO [dbo].[Customer_Master]
           (Registration_Date
           ,First_Name
           ,Last_Name
           ,Address
		   ,Area_ID
           ,Birth_Date
           ,Blood_Group
           ,Mobile_No
           ,Alternate_Mobile
           ,Created_By
		   ,Created_Date)
     VALUES
           (GETDATE()
           ,@First_Name
           ,@Last_Name
           ,@Address
		   ,@Area_ID
           ,@Birth_Date
           ,@Blood_Group
           ,@Mobile_No
           ,@Alternate_Mobile
           ,@UserName
		   ,GETDATE())

	select SCOPE_IDENTITY();

END
GO

CREATE procedure [dbo].[UpdateCustomer](@Customer_ID int
			,@First_Name varchar(50)
           ,@Last_Name varchar(50)
           ,@Address varchar(500)
		   ,@Area_ID int = null
           ,@Birth_Date date = NULL
           ,@Blood_Group varchar(50) = NULL
           ,@Mobile_No varchar(50)
           ,@Alternate_Mobile varchar(50) = NULL
           ,@UserName varchar(100))
as
begin
SET NOCOUNT ON

if exists(select 1 from dbo.Customer_Master where Mobile_No = @Mobile_No and Customer_ID <> @Customer_ID and IS_DLT = 0)
begin
	select 0;
	return;
end

update [dbo].[Customer_Master]
          set Registration_Date = GETDATE()
           ,First_Name = @First_Name
           ,Last_Name = @Last_Name
           ,Address = @Address
		   ,Area_ID = @Area_ID
           ,Birth_Date = @Birth_Date
           ,Blood_Group = @Blood_Group
           ,Mobile_No = @Mobile_No
           ,Alternate_Mobile = @Alternate_Mobile
           ,Updated_By = @UserName
		   ,Updated_Date = GETDATE()
	where Customer_ID = @Customer_ID and IS_DLT = 0

	select @Customer_ID;

END

GO

CREATE PROCEDURE dbo.DeleteCustomer(@Customer_ID int)
AS
begin
	if exists(select 1 from dbo.bus_Mapping bm inner join dbo.Customer_Master cm on bm.Customer_ID = cm.Customer_ID
				where cm.Customer_ID = @Customer_ID and cm.IS_DLT = 0)
	begin
		select 0;
		return;
	end

	DELETE FROM dbo.Customer_Master where Customer_ID = @Customer_ID and IS_DLT = 0;

	Select @Customer_ID;
end

GO

CREATE PROCEDURE dbo.SearchCustomer(@First_Name varchar(50) = NULL
           ,@Last_Name varchar(50) = NULL
           ,@Mobile_No varchar(50) = NULL)
as
BEGIN
	SET NOCOUNT ON;
	select 	cMaster.Customer_ID, cMaster.First_Name, 
			cMaster.Last_Name, cMaster.Address, 
			cMaster.Mobile_No, cMaster.Blood_Group, cMaster.Alternate_Mobile, Birth_Date
	from
	Customer_Master cMaster
	where First_Name like (case when @First_Name is null then First_Name else @First_Name + '%' end)
	AND Last_Name like (case when @Last_Name is null then Last_Name else @Last_Name + '%' end)
	AND Mobile_No like (case when @Mobile_No is null then Mobile_No else @Mobile_No + '%' end)
	AND IS_DLT = 0
END


GO
-- ***** Customer Manegement SPs END ******



exec sp_rename 'sp_BirthDateReport',	'BirthDateReport'
exec sp_rename 'sp_BusReport',	'BusReport'
exec sp_rename 'sp_CashReport',	'CashReport'
exec sp_rename 'sp_getAvailableBusName',	'getAvailableBusName'
exec sp_rename 'sp_getAvailableSeatNo',	'getAvailableSeatNo'
exec sp_rename 'sp_getBusRegistrationInfo',	'getBusRegistrationInfo'
exec sp_rename 'sp_getCustomerDetails',	'getCustomerDetails'
exec sp_rename 'sp_getLatestUpdatedTimeStamp',	'getLatestUpdatedTimeStamp'
exec sp_rename 'sp_PrintID',	'PrintID'
exec sp_rename 'sp_SearchCustomerRegistration',	'SearchCustomerRegistration'
exec sp_rename 'sp_SearchReport',	'SearchReport'
exec sp_rename 'sp_UpdateBusRegistration',	'UpdateBusRegistration'
exec sp_rename 'sp_zzz_ClearData',	'zzz_ClearData'
exec sp_rename 'sp_GetMobileNumbers',	'GetMobileNumbers'
exec sp_rename 'sp_EmptySeats',	'EmptySeats'
exec sp_rename 'sp_DailyCashReport',	'DailyCashReport'
exec sp_rename 'sp_DeleteBus',	'DeleteBus'
exec sp_rename 'sp_getAllCashExpenseTransactions',	'getAllCashExpenseTransactions'
exec sp_rename 'sp_DeleteExpenseType',	'DeleteExpenseType'
exec sp_rename 'sp_DeleteCashExpenseTransaction',	'DeleteCashExpenseTransaction'
exec sp_rename 'sp_InsertUpdateExpenseType',	'InsertUpdateExpenseType'
exec sp_rename 'sp_InsertUpdateCashExpenseTransaction',	'InsertUpdateCashExpenseTransaction'
exec sp_rename 'sp_getCashExpenseReport',	'getCashExpenseReport'
exec sp_rename 'sp_getAllExpenseTypes',	'getAllExpenseTypes'
exec sp_rename 'sp_AllYatraDateAllBusesCashReport',	'AllYatraDateAllBusesCashReport'
exec sp_rename 'sp_GetAllCustomers',	'GetAllCustomers'
exec sp_rename 'sp_DailyCashReport_Yearly',	'DailyCashReport_Yearly'
exec sp_rename 'sp_DiscountReport_Yearly',	'DiscountReport_Yearly'
exec sp_rename 'sp_getBusByYatraDate',	'getBusByYatraDate'
exec sp_rename 'sp_CashReport_Yearly',	'CashReport_Yearly'
exec sp_rename 'sp_CreateUser',	'CreateUser'
exec sp_rename 'sp_UpdateUser',	'UpdateUser'
exec sp_rename 'sp_DeleteUser',	'DeleteUser'
exec sp_rename 'sp_GetUserDetails',	'GetUserDetails'
exec sp_rename 'sp_AuthenticateUser',	'AuthenticateUser'
exec sp_rename 'sp_ChangePassword',	'ChangePassword'
exec sp_rename 'sp_BloodGroupReport',	'BloodGroupReport'
exec sp_rename 'sp_DeleteData',	'DeleteData'
exec sp_rename 'sp_DeleteTicket',	'DeleteTicket'
exec sp_rename 'sp_GetCustomerTickets',	'GetCustomerTickets'
exec sp_rename 'sp_InsertCustomerAndTravel',	'InsertCustomerAndTravel'
exec sp_rename 'sp_UpdateCustomerAndTravel',	'UpdateCustomerAndTravel'
exec sp_rename 'sp_getCustomerDetailsForMobileNumber',	'getCustomerDetailsForMobileNumber'
exec sp_rename 'sp_getBusRoutes',	'getBusRoutes'
exec sp_rename 'sp_InsertBusRoute',	'InsertBusRoute'
exec sp_rename 'sp_UpdateBusRoute',	'UpdateBusRoute'
exec sp_rename 'sp_getNavratriDatesForBusRoute',	'getNavratriDatesForBusRoute'
exec sp_rename 'sp_getUserwiseTickets',	'getUserwiseTickets'
exec sp_rename 'sp_GetUserNames',	'GetUserNames'
exec sp_rename 'sp_CashReport_Userwise',	'CashReport_Userwise'
exec sp_rename 'sp_BusReport_Yearly',	'BusReport_Yearly'
exec sp_rename 'sp_CashReport_UserwiseYearly',	'CashReport_UserwiseYearly'
GO