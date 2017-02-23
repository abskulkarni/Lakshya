
ALTER PROCEDURE dbo.SearchCustomer(@First_Name varchar(50) = NULL
           ,@Last_Name varchar(50) = NULL
           ,@Mobile_No varchar(50) = NULL)
as
BEGIN
	SET NOCOUNT ON;
	select 	cMaster.Customer_ID, cMaster.First_Name, 
			cMaster.Last_Name, cMaster.Address, 
			cMaster.Mobile_No, cMaster.Blood_Group, cMaster.Alternate_Mobile, Birth_Date,
			cMaster.Area_ID
	from
	Customer_Master cMaster
	left join dbo.Area_Master aMaster on cMaster.Area_ID = aMaster.Area_ID
	where First_Name like (case when @First_Name is null then First_Name else @First_Name + '%' end)
	AND Last_Name like (case when @Last_Name is null then Last_Name else @Last_Name + '%' end)
	AND Mobile_No like (case when @Mobile_No is null then Mobile_No else @Mobile_No + '%' end)
	--AND IS_DLT = 0
END
GO

ALTER PROCEDURE [dbo].[GetCustomerTickets] --5268
(@Cust_ID int = NULL, @showTodayTickets bit)
AS
BEGIN
	SET NOCOUNT ON;
	if @showTodayTickets = 1
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
		and year(busMapping.Created_Date) = year(getdate())
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
		where cMaster.Customer_ID = isnull(@Cust_ID,cMaster.Customer_ID) --and cMaster.IS_DLT = 0
		and convert(date,busMapping.Created_Date) < convert(date, getdate())
		and year(busMapping.Created_Date) < year(getdate())
		order by busMapping.Created_Date
	end
END
GO

ALTER PROCEDURE [dbo].[getCustomerDetails]
		
     (  @Customer_ID int, @Bus_Master_ID int)

AS
BEGIN 
     SET NOCOUNT ON 

	select 
	cMaster.Customer_ID, busMapping.Bus_Master_ID ,busMapping.Created_Date as Registration_Date, cMaster.First_Name, 
			cMaster.Last_Name, cMaster.Address, cMaster.Area_ID, cMaster.Age, cMaster.Birth_Date , cMaster.Blood_Group ,
			cMaster.Mobile_No, bMaster.Bus_Fees , cMaster.Alternate_Mobile ,
			busMapping.Discount, busMapping.Discount_Given_By,busMapping.DiscountReason ,busMapping.Actual_Fees,
			bMaster.Navratri_Date as yatra_date, bMaster.Bus_Name, bMaster.Seat_No, bMaster.Auto_Time,
			brm.Route_ID
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