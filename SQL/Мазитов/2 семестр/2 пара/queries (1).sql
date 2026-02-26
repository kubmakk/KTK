create table client (
id int auto_increment primary key,
phone varchar(45),
balance decimal(10,2),
reg_date datetime,
login varchar(45),
clientcol varchar(45),

CreatedAt DATETIME,
CreatedBy VARCHAR(50),
UpdatedAt DATETIME,
UpdatedBy VARCHAR(50),
IsActive BOOLEAN default TRUE
);

create table employee (
id int auto_increment primary key,
position varchar(45),
rights varchar(45),
login varchar(45),
full_name varchar(255),
full_lastname varchar(255),
full_patronymic varchar(45),
CreatedAt DATETIME,
CreatedBy VARCHAR(50),
UpdatedAt DATETIME,
UpdatedBy VARCHAR(50),
IsActive BOOLEAN default TRUE
);

create table pc (
id int auto_increment primary key,
number int,
status varchar(45),
zone varchar(45),
configure text,
CreatedAt DATETIME,
CreatedBy VARCHAR(50),
UpdatedAt DATETIME,
UpdatedBy VARCHAR(50),
IsActive BOOLEAN default TRUE
);

create table service (
id int auto_increment primary key,
name varchar(255),
price decimal(10,2),
type varchar(45),
CreatedAt DATETIME,
CreatedBy VARCHAR(50),
UpdatedAt DATETIME,
UpdatedBy VARCHAR(50),
IsActive BOOLEAN default TRUE
);

create table sessie (
id int auto_increment primary key,
start_time datetime,
end_time datetime,
cost decimal(10,2),
client_id int,
pc_id int,
employee_id int,
foreign key (client_id) references client(id),
foreign key (pc_id) references pc(id),
foreign key (employee_id) references employee(id),
CreatedAt DATETIME,
CreatedBy VARCHAR(50),
UpdatedAt DATETIME,
UpdatedBy VARCHAR(50),
IsActive BOOLEAN default TRUE
);

create table purshes (
id int auto_increment primary key,
description varchar(255),
service_id int,
client_id int,
employee_id int,
foreign key (service_id) references service(id),
foreign key (client_id) references client(id),
foreign key (employee_id) references employee(id),
CreatedAt DATETIME,
CreatedBy VARCHAR(50),
UpdatedAt DATETIME,
UpdatedBy VARCHAR(50),
IsActive BOOLEAN default TRUE
);

insert into client(phone, balance, reg_date, login, clientcol, createdat, createdby) values
('89001234567', 500.00, '2025-02-11', 'kubmakk', 'note', '2026-02-10', 'admin_alex'),
('89112223344', 1500.00, '2026-02-05', 'pro_gamer77', 'vip', '2026-02-10', 'admin_alex'),
('89223334455', 0.00, '2026-02-06', 'cyber_cat', 'regular', '2026-02-10', 'kate_manager'),
('89334445566', 320.50, '2026-02-07', 'noob_master', 'regular', '2026-02-10', 'kate_manager'),
('89445556677', 10000.00, '2026-02-08', 'whale_player', 'premium', '2026-02-10', 'director');

insert into employee(position, rights, login, full_name, full_lastname, full_patronymic, createdat, createdby) values
('administrator', 'full', 'admin_alex', 'Алексей', 'Смирнов', 'Иванович', '2024-12-01', 'director'),
('junior_admin', 'limited', 'kate_manager', 'Екатерина', 'Петрова', 'Сергеевна', '2026-01-20', 'director'),
('cleaner', 'none', 'clean_clara', 'Клара', 'Захаровна', 'Петровна', '2026-01-15', 'admin_alex'),
('technician', 'edit', 'tech_support', 'Дмитрий', 'Иванов', 'Олегович', '2026-01-10', 'director'),
('manager', 'full', 'boss_vlad', 'Владислав', 'Токарев', 'Андреевич', '2023-05-05', 'owner');

insert into pc (number, status, zone, configure, createdat, createdby) values
(10, 'free', 'vip', 'RTX 4090, 32GB RAM', '2023-02-10', 'admin'),
(11, 'busy', 'standard', 'RTX 3060, 16GB RAM', '2026-02-10', 'admin_alex'),
(12, 'free', 'standard', 'RTX 3060, 16GB RAM', '2026-02-10', 'admin_alex'),
(13, 'maintenance', 'vip', 'RTX 4090, 64GB RAM', '2026-02-10', 'tech_support'),
(14, 'free', 'bootcamp', 'RTX 4070Ti, 32GB RAM', '2026-02-10', 'admin_alex');

insert into service(name, price, type, createdat, createdby) values
('Night Tariff', 1000.00, 'gaming', '2023-02-10', 'admin'),
('VIP Hour', 300.00, 'rent', '2026-02-10', 'admin_alex'),
('Energy Drink', 150.00, 'food', '2026-02-10', 'kate_manager'),
('Coffee Large', 200.00, 'food', '2026-02-10', 'kate_manager'),
('Sandwich', 250.00, 'food', '2026-02-10', 'kate_manager');

insert into sessie(start_time, cost, client_id, pc_id, employee_id, createdat, createdby) values
('2026-02-10 10:00:00', 250.50, 1, 1, 1, '2026-02-10', 'admin_alex'),
('2026-02-10 12:00:00', 600.00, 2, 2, 2, '2026-02-10', 'kate_manager'),
('2026-02-10 14:30:00', 300.00, 3, 3, 1, '2026-02-10', 'admin_alex'),
('2026-02-10 18:00:00', 1000.00, 5, 1, 1, '2026-02-10', 'admin_alex'),
('2026-02-10 20:00:00', 450.00, 4, 5, 2, '2026-02-10', 'kate_manager');

insert into purshes(description, service_id, client_id, employee_id, createdat, createdby) values
('Extra energy drink', 3, 1, 1, '2026-02-10', 'admin_alex'),
('Утренеее экспрессо', 4, 2, 2, '2026-02-10', 'kate_manager'),
('Lays с крабом', 5, 3, 1, '2026-02-10', 'admin_alex'),
('Обновление до ВИП', 2, 5, 1, '2026-02-10', 'admin_alex'),
('Орешки кешью', 3, 4, 2, '2026-02-10', 'kate_manager');


-- select * from client;
-- select login, balance from client where balance > 1000;
-- select full_name, position from employee where isactive = true;
-- select * from purshes order by createdat desc limit 10;


select * from client where clientcol in ('vip', 'premium') order by id desc;
select * from client where balance between 100.00 and 1500.00 order by balance desc;
select * from client where login like '%gamer%' order by id desc;
select * from client where phone regexp '^(8900|8911)' order by id desc;
select * from client where updatedat is null order by id desc;

select * from employee where position in ('administrator', 'manager') order by id desc;
select * from employee where createdat between '2024-01-01 00:00:00' and '2026-12-31 23:59:59' order by createdat desc;
select * from employee where full_lastname like 'смирн%' order by id desc;
select * from employee where rights regexp '^full$|^edit$' order by id desc;
select * from employee where full_patronymic is null order by id desc;

select * from pc where zone in ('vip', 'bootcamp') order by number desc;
select * from pc where number between 11 and 13 order by number desc;
select * from pc where configure like '%rtx 4090%' order by number desc;
select * from pc where status regexp 'free|maintenance' order by number desc;
select * from pc where updatedby is null order by number desc;

select * from service where type in ('food', 'rent') order by price desc;
select * from service where price between 150.00 and 300.00 order by price desc;
select * from service where name like '%coffee%' order by id desc;
select * from service where name regexp 'tariff|hour' order by id desc;
select * from service where createdat is null order by id desc;

select * from sessie where employee_id in (1, 2) order by start_time desc;
select * from sessie where cost between 300.00 and 600.00 order by cost desc;
select * from sessie where createdby like 'admin%' order by id desc;
select * from sessie where start_time regexp '10:00:00|12:00:00' order by start_time desc;
select * from sessie where end_time is null order by id desc;

select * from purshes where service_id in (3, 4, 5) order by id desc;
select * from purshes where client_id between 1 and 3 order by id desc;
select * from purshes where description like '%energy%' order by id desc;
select * from purshes where description regexp 'вип|экспрессо' order by id desc;
select * from purshes where employee_id is null order by id desc;