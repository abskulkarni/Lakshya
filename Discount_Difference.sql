/****** Script for SelectTopNRows command from SSMS  ******/
SELECT uMaster.First_Name,uMaster.Last_Name, cMaster.Customer_ID, cMaster.Registration_Date, bMaster.Navratri_Date, bMaster.Bus_Name	, cMaster.First_Name,cMaster.Last_Name,
		cMaster.Discount, cMaster.Actual_Fees,bMaster.Bus_Fees, cMaster.Created_By, cMaster.Updated_By
  FROM [Lakshya].[dbo].[Bus_Master] bMaster
  inner join
  bus_Mapping bm
  on bm.Bus_Master_ID = bMaster.Bus_Master_ID
  inner join
  Customer_Master cMaster 
  on cMaster.Customer_ID = bm.Customer_ID
  inner join
  User_Master uMaster
  on uMaster.User_Name = cMaster.Created_By
  where cMaster.Actual_Fees <> bMaster.Bus_Fees
  and cMaster.Discount = 0
  
  --bMAster.Navratri_Date = '2016-10-05'
  --and bMaster.Bus_Name = 'D'
  --and cMaster.Registration_Date = '2016-09-28'
  