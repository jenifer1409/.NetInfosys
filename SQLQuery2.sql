
use INFOSYSTEST

create table emp(eid int primary key,ename varchar(20),role varchar(20),salary int)

insert into emp(eid,ename,role,salary)
values
(300,'john','hr',25000),
(400,'adam','sales',35000)

-- subquery : query inside another query (inner query will be evaluated first whose output 
--will be the input/ criteria for the outer query)


-- who earns more than john

select ename from emp where salary > 
(select salary from emp where ename='john')


select * from emp

-- stored procedures  : set of sql statements that execute as single unit


-- select procedure

create procedure usp_selectEmployees1
as
begin
select * from emp
end


alter procedure usp_selectEmployees
(@eid int)
as
begin
select * from emp where eid=@eid
end


exec usp_selectEmployees @eid=100

-- insert records using sp

alter procedure usp_insertEmployee
(@eid int,
@ename varchar(20),
@role varchar(20),
@salary int)
as
begin
insert into emp(eid,ename,role,salary)
values(@eid,@ename,@role,@salary)
select * from emp
end

exec usp_insertEmployee @eid=800,@ename='jill',@role='analyst',@salary=1111

exec usp_selectEmployees1

-- update 

alter procedure usp_updateEmployee
(@eid int,
@salary int)
--with encryption
as
begin
update emp set salary=@salary where eid=@eid
end

exec usp_updateEmployee @eid=100,@salary=777777

sp_helptext usp_updateEmployee

-- exception handling in sp

alter procedure usp_deleteEmployee
(@eid int)
as 
begin
begin try
delete from emp where eid=@eid
raiserror('employee id is unavailable',1,@eid)
end try
begin catch
select ERROR_MESSAGE() as errormessage,
ERROR_SEVERITY() as severity
end catch
end


exec usp_deleteEmployee @eid=111

--if else & switch in sp

create procedure usp_updateEmployeeSalary
(@eid int,
@newsalary int,
@actiontype varchar(20))
as
begin
begin try
if exists (select * from emp where eid=@eid)
begin
begin
update emp
set salary = CASE
when @actiontype='increase' then salary+@newsalary
when @actiontype='decrease' then salary-@newsalary
else salary
end
where eid=@eid
end
end
else
begin
raiserror('employee id is unavailable',1,@eid)
end
end try
begin catch
select ERROR_MESSAGE() as errormessage,
ERROR_SEVERITY() as severity
end catch
end

select * from emp

exec usp_updateEmployeeSalary
@eid=300,
@newsalary=23456,
@actiontype='decrease'


-- functions : perform a task and it will return a values

-- diff stored procedure vs functions 
/*

sp                                   fn
executes set of sql stms   - executes set of sql stms
insert/update/delete/select - select
out parameter to return a value - returns the value
call a function from sp - but you cannot call a sp from function
exec keyword to execute sp - select keyword to execute the function
*/


-- create a function 


-- scalar function
create function udf_avgsalary()
returns int
as
begin
declare @avgsal int
select @avgsal=avg(salary) from emp
return @avgsal
end

select dbo.udf_avgsalary()


-- table valued functions 
alter function  udf_emptable(
@eid int)
returns table
as
return
(select * from emp where eid=@eid)

select * from dbo.udf_emptable(200)

-- Rank function / window functions
/* row number()
rank()
dense_rank()
ntile() */

select * from emp


select eid,ename,role,salary,ROW_NUMBER()over(order by salary desc) as rownum
from emp


select eid,ename,role,salary,DENSE_RANK() over(order by salary desc) as denserank
from emp


select eid,ename,role,salary,RANK() over(order by salary desc) as rank
from emp


select eid,ename,role,salary,ntile(3) over(order by salary desc) as ntile
from emp


-- to find the second highest salary in the table 

select ename,salary



-- CTE : common table expression
with salariesEmployee as
(
select eid,ename,role,salary,DENSE_RANK() over(order by salary desc) as denserank
from emp
)
select ename,salary from salariesEmployee where denserank=3


-- Views 

alter view empview
as
select top(2)* from emp

select * from empview

--C:\Users\Hp\Documents\SQL Server Management Studio\sqlscripts\SQLQuery2.sql