select name, isnull(Color, 'NoColor')Color
, isnull(cast(ProductModelID as nvarchar),'titi')ModelID,
ListPrice Price from Production.Product



select * from Person.PersonPhone
where PhoneNumber like '___-___-____'
union all
select* from Person.PersonPhone
where PhoneNumber like '%-%-%'



select * from Person.PersonPhone
where PhoneNumber like '%-%-%'
except
select* from Person.PersonPhone
where PhoneNumber like '___-___-____'




select Name , Color ,ListPrice,
rank() over(order by ListPrice desc) as sira,
dense_rank() over(order by ListPrice desc) as siraNo,
row_number() over(order by ListPrice desc) as rowNo
from Production.Product
order by ListPrice desc

-- her rengin en pahali ilk 3 fiyatli urunleri
select * from 
		(
		select Name , Color ,ListPrice,
		rank() over(partition by color order by ListPrice desc) as sira,
		dense_rank() over(partition by color order by ListPrice desc) as siraNo,
		row_number() over(partition by color order by ListPrice desc) as rowNo
		from Production.Product
		) as t
	where siraNo <= 3



create function fnSum
(
@num1 int, 
@num2 int
)

returns bigint 
as
begin
return @num1 + @num2
end

select dbo.fnSum(5,6)


-- Drop the function if it already exists
  IF OBJECT_ID('dbo.InitCap') IS NOT NULL
	DROP FUNCTION dbo.InitCap;
  GO
 
 -- Implementing Oracle INITCAP function
 CREATE FUNCTION dbo.InitCap (@inStr VARCHAR(8000))
  RETURNS VARCHAR(8000)
  AS
  BEGIN
    DECLARE @outStr VARCHAR(8000) = LOWER(@inStr),
		 @char CHAR(1),	
		 @alphanum BIT = 0,
		 @len INT = LEN(@inStr),
                 @pos INT = 1;		  
 
    -- Iterate through all characters in the input string
    WHILE @pos <= @len BEGIN
 
      -- Get the next character
      SET @char = SUBSTRING(@inStr, @pos, 1);
 
      -- If the position is first, or the previous characater is not alphanumeric
      -- convert the current character to upper case
      IF @pos = 1 OR @alphanum = 0
        SET @outStr = STUFF(@outStr, @pos, 1, UPPER(@char));
 
      SET @pos = @pos + 1;
 
      -- Define if the current character is non-alphanumeric
      IF ASCII(@char) <= 47 OR (ASCII(@char) BETWEEN 58 AND 64) OR
	  (ASCII(@char) BETWEEN 91 AND 96) OR (ASCII(@char) BETWEEN 123 AND 126)
	  SET @alphanum = 0;
      ELSE
	  SET @alphanum = 1;
 
    END
 
   RETURN @outStr;		   
  END
  GO



  select dbo.InitCap('muhammad akkad ')

  -- girilen musterinin girilen adet kadar son siparislerini gitiern fonksyon

 create function fMusteri(@MusteriID int, @Adet int)
 returns table
 as 
	 return
		 select top (@Adet) CustomerID, OrderDate, SubTotal
		 from Sales.SalesOrderHeader
		 where CustomerID = @MusteriID
		 order by OrderDate desc




select * from fMusteri(11019,5)




select *
from Sales.Customer as c
cross apply dbo.fMusteri(c.CustomerID, 3)

--~`'" HOME WORK

--normalization rules english turkish