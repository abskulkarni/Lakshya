create table dbo.CustomersForReport 
(
Customer_ID	int	,
First_Name	varchar(50)	,
Last_Name	varchar(50)	,
Address	varchar(500)	,
Mobile_No	varchar(50),
Alternate_Mobile	varchar(50),
RowNum int
)

;WITH CTE AS(
   SELECT customer_id, first_name,last_name,Address,mobile_no,Alternate_Mobile,created_date,
       RN = ROW_NUMBER() OVER(PARTITION BY first_name,last_name ORDER BY created_date)
   FROM dbo.Customer_Master
)
insert into dbo.CustomersForReport(
Customer_ID,
First_Name,
Last_Name,
Address,
Mobile_No,
Alternate_Mobile,
RowNum
) select Customer_ID,
First_Name,
Last_Name,
Address,
Mobile_No,
Alternate_Mobile,
RN from CTE

GO

create procedure sp_GetElectionReport
as
begin
	SET NOCOUNT ON
	select Customer_ID,
	First_Name,
	Last_Name,
	Address,
	Mobile_No,
	Alternate_Mobile,
	RowNum
	from dbo.CustomersForReport
end
GO

delete from dbo.CustomersForReport where First_Name = 'test' or First_Name = 'w'
GO