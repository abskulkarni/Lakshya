/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Customer_ID]
      ,[Registration_Date]
      ,[First_Name]
      ,[Last_Name]
      
      ,[Fees]
      
      ,[Discount]
      ,[Discount_Given_By]
      ,[DiscountReason]
      ,[Actual_Fees]
      
  FROM [Lakshya].[dbo].[Customer_Master]
  where Customer_ID = 6272