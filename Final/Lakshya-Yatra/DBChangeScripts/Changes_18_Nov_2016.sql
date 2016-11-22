--ALTER TABLE dbo.bus_Master add Is_Visible bit default 1;
--GO
--Update dbo.Bus_Master set Is_Visible = 1
--GO

Create Procedure dbo.GetRouteAndDates
as
BEGIN
	select distinct bMaster.Navratri_Date, convert(varchar, bMaster.Navratri_Date) + '|' + convert(varchar, bMaster.Route_ID) ValueMember, 
			convert(varchar, format(bMaster.Navratri_Date, 'dd/MMM/yyyy')) + ' | ' +  convert(varchar,brm.Bus_Route) DisplayMember,
			(case when year(bMaster.Navratri_Date) = year(getdate()) then 1 else 0 end) IsVisible
			from dbo.Bus_Master bMaster inner join dbo.Bus_Route_Master brm
	on brm.Route_ID = bMaster.Route_ID where bMaster.Is_Seat_Available = 1 order by bMaster.Navratri_Date

END
GO