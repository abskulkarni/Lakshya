--ALTER TABLE dbo.Bus_Master Add Is_Visible bit default 1;
--GO
--Update dbo.Bus_Master set Is_Visible = 1;
--GO

ALTER TABLE dbo.Route_ID_Navratri_Date_Mapping Add Is_Visible bit default 1;
GO
Update dbo.Route_ID_Navratri_Date_Mapping set Is_Visible = 1;
GO

Create Procedure dbo.GetRouteAndDateVisibility
(@Navratri_Date date, @Route_ID int)
as
BEGIN
	SET NOCOUNT ON;
	select Is_Visible from dbo.Route_ID_Navratri_Date_Mapping where Convert(date, Navratri_Date) = @Navratri_Date and Route_ID = @Route_ID
END
GO

ALTER PROCEDURE [dbo].[UpdateBusRegistration]
		(@Bus_Name varchar(50)
           ,@Navratri_Date datetime
           ,@Seat_No varchar(300)
           ,@Seat_Count int
		   ,@Bus_Fees int
		   ,@Route_ID int
		   ,@Bus_Time time(2) = null
		   ,@Is_Visible bit = true
		   ,@UserName varchar(50))
		   

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
	
	if not exists(select 1 from dbo.Route_ID_Navratri_Date_Mapping where 
					CONVERT(date,@Navratri_Date) = CONVERT(date, Navratri_Date) and Route_ID = @Route_ID)
	begin
		INSERT INTO dbo.Route_ID_Navratri_Date_Mapping (Navratri_Date, Route_ID, Is_Active, Is_Visible, Created_By, Created_Date)
			select @Navratri_Date, @Route_ID , 1, @Is_Visible, @UserName,getdate()
	end
	else
	begin
		Update dbo.Route_ID_Navratri_Date_Mapping set Is_Visible = @Is_Visible, Updated_By = @UserName, Updated_Date = getdate() 
		where Route_ID = @Route_ID and CONVERT(date, Navratri_Date) = CONVERT(date,@Navratri_Date)
	end
	if not exists(select 1 from [dbo].[Bus_Master] where Route_ID = @Route_ID 
					and CONVERT(date, Navratri_Date) = CONVERT(date,@Navratri_Date) 
					and Is_Seat_Available = 1 and Is_Seat_Available is not null)
	BEGIN
		Update dbo.Route_ID_Navratri_Date_Mapping set Is_Active = 0, Updated_By = @UserName, Updated_Date = getdate() 
		where Route_ID = @Route_ID and CONVERT(date, Navratri_Date) = CONVERT(date,@Navratri_Date)
	END

	if exists(select 1 from [dbo].[Bus_Master] where Route_ID = @Route_ID 
					and CONVERT(date, Navratri_Date) = CONVERT(date,@Navratri_Date) 
					and Is_Seat_Available = 1 and Is_Seat_Available is not null)
	BEGIN
		Update dbo.Route_ID_Navratri_Date_Mapping set Is_Active = 1, Updated_By = @UserName, Updated_Date = getdate() 
		where Route_ID = @Route_ID and CONVERT(date, Navratri_Date) = CONVERT(date,@Navratri_Date)
	END
	

	--if not exists(select 1 from [dbo].[Bus_Master] where Route_ID = @Route_ID 
	--				and CONVERT(date, Navratri_Date) = CONVERT(date,@Navratri_Date) 
	--				and Is_Visible = 1 and Is_Seat_Available = 1 and Is_Seat_Available is not null)
	--BEGIN
	--	Update dbo.Route_ID_Navratri_Date_Mapping set Is_Visible = 0, Updated_By = @UserName, Updated_Date = getdate() 
	--	where Route_ID = @Route_ID and CONVERT(date, Navratri_Date) = CONVERT(date,@Navratri_Date)
	--END
	--ELSE
	--BEGIN
	--	Update dbo.Route_ID_Navratri_Date_Mapping set Is_Visible = 1, Updated_By = @UserName, Updated_Date = getdate() 
	--	where Route_ID = @Route_ID and CONVERT(date, Navratri_Date) = CONVERT(date,@Navratri_Date)
	--END

	select 1;
END

GO

ALTER PROCEDURE [dbo].[DeleteBus]
		@Bus_Name varchar(50)
           ,@Navratri_Date date

AS
BEGIN 
     SET NOCOUNT ON 
     
     if exists (select distinct 1 from dbo.Bus_Master where
				Bus_Name = @Bus_Name and Navratri_Date = @Navratri_Date
				and isnull(Is_Seat_Available,1) = 0)
		begin
			select 1;
			return
		end

	delete from dbo.Bus_Master where Bus_Name = @Bus_Name and Navratri_Date = @Navratri_Date

	if not exists(select 1 from [dbo].[Bus_Master] where CONVERT(date, Navratri_Date) = CONVERT(date,@Navratri_Date))
	BEGIN
		delete from dbo.Route_ID_Navratri_Date_Mapping  
		where CONVERT(date, Navratri_Date) = CONVERT(date,@Navratri_Date)
	END

	select 0;

END 
GO

--ALTER PROCEDURE [dbo].[getBusRegistrationInfo]

--AS
--BEGIN 
--     SET NOCOUNT ON 
--/****** Script for SelectTopNRows command from SSMS  ******/
--SELECT brm.Route_ID, brm.Bus_Route, masterT.Navratri_Date,--masterT.Is_Visible
--			masterT.Bus_Name,masterT.Bus_Time , masterT.Seat_No, masterT.Is_Seat_Available, masterT.Bus_Fees
--  FROM 
--  Bus_Master masterT
--  inner join
--  dbo.Bus_Route_Master brm
--  on masterT.Route_ID = brm.Route_ID
--END 
--GO

ALTER Procedure [dbo].[GetRouteAndDates]
as
BEGIN
	
	select rnm.Navratri_Date, convert(varchar, rnm.Navratri_Date) + '|' + convert(varchar, rnm.Route_ID) ValueMember, 
			convert(varchar, format(rnm.Navratri_Date, 'dd/MMM/yyyy')) + ' | ' +  convert(varchar,brm.Bus_Route) DisplayMember,
			rnm.Is_Active 
			from dbo.Route_ID_Navratri_Date_Mapping rnm inner join dbo.Bus_Route_Master brm
			on brm.Route_ID = rnm.Route_ID where rnm.Is_Visible = 1 order by rnm.Navratri_Date
END
GO

ALTER PROCEDURE [dbo].[UpdateCustomerAndTravel]
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
    Update rnm
	set Is_Active = 1, Updated_By = @Updated_By, Updated_Date = getdate() 
	--select *
	from dbo.Route_ID_Navratri_Date_Mapping rnm
	where exists (select 1 from [dbo].[Bus_Master] bMaster inner join dbo.Route_ID_Navratri_Date_Mapping nrm
					on CONVERT(date, bMaster.Navratri_Date) = CONVERT(date,rnm.Navratri_Date) and isnull(bMaster.Route_ID,0) = isnull(rnm.Route_ID,0)
						where Is_Seat_Available = 1 and Is_Seat_Available is not null)


    select @bus_master_id = bus_master_id from bus_master where 
								Bus_Name = @bus_name and CONVERT(date, navratri_date) = @yatra_date
								and Seat_No = @Seat_No;
	update Bus_Master set Is_Seat_Available = 0 where Bus_Master_ID = @bus_master_id -- Marked seat as blocked
    
	Update rnm
	set Is_Active = 0, Updated_By = @Updated_By, Updated_Date = getdate() 
	--select *
	from dbo.Route_ID_Navratri_Date_Mapping rnm
	where not exists (select 1 from [dbo].[Bus_Master] bMaster inner join dbo.Route_ID_Navratri_Date_Mapping nrm
					on CONVERT(date, bMaster.Navratri_Date) = CONVERT(date,rnm.Navratri_Date) and isnull(bMaster.Route_ID,0) = isnull(rnm.Route_ID,0)
						where Is_Seat_Available = 1 and Is_Seat_Available is not null)

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

--ALTER PROCEDURE [dbo].[getAvailableBusName]
		
--       @Yatra_Date    date, @Route_ID int

--AS
--BEGIN 
--     SET NOCOUNT ON 

--	select distinct Bus_Name from 
--	dbo.Bus_Master bMaster
--	inner join dbo.Bus_Route_Master brm
--	on bMaster.Route_ID = brm.Route_ID where 
--	CONVERT(date, navratri_date) = @Yatra_Date
--	and brm.Route_ID = @Route_ID
--	and Is_Seat_Available = 1 and Is_Visible = 1
--	order by Bus_Name

--END 
--GO