;WITH CTE AS(
   SELECT customer_id, mobile_no,first_name,last_name,created_date,
       RN = ROW_NUMBER() OVER(PARTITION BY convert(bigint, mobile_no) ORDER BY created_date)
   FROM dbo.Customer_Master
   where Created_Date is not null
)
--select * from CTE where RN > 1 and Mobile_No = '9767809661'
delete cMaster
--select
--CTE.Created_Date, CTE.RN, cMaster.*
from
Customer_Master cMaster
inner join
CTE
on cMaster.Customer_ID = CTE.Customer_ID
where RN > 1 
--order by CTE.Created_Date, CTE.RN
GO
delete from dbo.Customer_Master where Created_By is null
GO