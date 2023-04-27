use SchoolDB;
go

drop table teaches;
drop table teacher;
drop table student;
drop table class;
drop table school;

create table school(
	id		int			identity(1,1)	primary key,
	"desc"	varchar(64)
);

create table class(
	id			int			identity(1,1),			
	id_school	int			references school,
	"desc"		varchar(64),
	primary key	(id, id_school)
);

create table student(
	id			int			identity(1,1),
	id_class	int,
	id_school	int,
	"name"		varchar(64),
	primary key	(id),
	foreign key (id_class, id_school) references class
);

create table teacher(
	id			int			identity(1,1)	primary key,
	id_school	int			references school,
	"name"		varchar(64)
);

create table teaches(
	id_teacher	int	references teacher,
	id_class	int,
	id_school	int,
	primary key	(id_teacher, id_class, id_school),
	foreign key	(id_class, id_school) references class
);



insert into school("desc") values('HTL');
insert into school("desc") values('AHS');
insert into school("desc") values('HAK');