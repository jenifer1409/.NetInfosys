

-- create clustered index 

select * from vehicle

insert into vehicle(vehicleid,LicensePlate,Make,Model,DriverName,DriverLicense,ServiceDate,ServiceDescription,ServiceCharge)
values
(100,'abc','kia',2012,'steve','dwer12','09-08-2023','regular',0),
(98,'abc','kia',2012,'steve','dwer12','09-08-2023','regular',0)

create clustered index cx_vehicle
on vehicle(vehicleid)

-- non clustered index

create nonclustered index nci_licence
on vehicle (driverlicense)


-- Triggers 


-- virtual tables

select * from inserted

select * from deleted

-- create dmllogger 

create table vehiclelog(logid uniqueidentifier default newid(),vehicleid int,operation varchar(10),modifieddate datetime)

-- create the dml trigger

create trigger trg_insertVehicle
on Vehicle
for insert
as
insert into vehiclelog(vehicleid,operation,modifieddate)
select vehicleid,'INSERT',GETDATE() from inserted


insert into vehicle(vehicleid,LicensePlate,Make,Model,DriverName,DriverLicense,ServiceDate,ServiceDescription,ServiceCharge)
values
(8,'abc','kia',2012,'steve','dwer12','09-08-2023','regular',0),
(9,'abc','kia',2012,'steve','dwer12','09-08-2023','regular',0)

select * from vehiclelog

select * from vehicle

alter trigger trg_insertVehicle
on Vehicle
INSTEAD OF insert
as
insert into vehiclelog(vehicleid,operation,modifieddate)
select vehicleid,'INSERT',GETDATE() from inserted


create trigger trg_updateVehicle
on Vehicle
after update
as
insert into vehiclelog(vehicleid,operation,modifieddate)
select vehicleid,'UPDATE',GETDATE() from inserted

update vehicle set LicensePlate='rxtcp' where VehicleId=10

-- DDL 

create table databaselog(logid uniqueidentifier default newid(),eventval xml,eventdate datetime,changedBy SYSNAME)

create trigger trg_databasechange
on database
for 
CREATE_TABLE,
ALTER_TABLE,
DROP_TABLE
as 
begin
insert into databaselog(eventval,eventdate,changedBy)
values
(EVENTDATA(),GETDATE(),USER)
end

select * from databaselog

create table checktrigger(id int)

drop table checktrigger

-- Logon trigger 

create trigger trg_logon
on all server with execute as 'DESKTOP-PL0KJBQ'
for logon
as
begin
if ORIGINAL_LOGIN()='DESKTOP-PL0KJBQ' and
(select COUNT(*) from sys.dm_exec_sessions
where is_user_process=1 and 
original_login_name='DESKTOP-PL0KJBQ')>2
rollback
end


-- Transaction 

-- Implicit transaction

set implicit_transactions on
--insert into vehicle values (106,'abc','kia',2012,2009,'steve','dwer12','09-08-2023','regular',0)
delete from vehicle where vehicleid=12
select @@TRANCOUNT as TransactionCount
commit transaction

select * from vehicle

-- explicit transaction

begin transaction
delete from vehicle where vehicleid=10
commit transaction 


select * from test1

begin transaction
insert into test1 values('azure',100)
commit transaction 


set implicit_transactions on
insert into test1 values('aws',90)
commit transaction 



-- savepoint 

begin transaction 

save transaction t1

insert into test1 values('go',90)
insert into test1 values('linux',90)

save transaction t2

insert into test1 values('unix',90)
insert into test1 values('react',90)

save transaction t3

insert into test1 values('ios',90)
insert into test1 values('android',90)

--rollback transaction t3 
--rollback transaction t2


rollback transaction t1

select * from test1
