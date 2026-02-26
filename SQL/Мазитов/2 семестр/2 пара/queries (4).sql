create table students_group (
id int auto_increment primary key,
specialization varchar(100),
number varchar(20),
course int,
CreatedAt DATETIME,
CreatedBy VARCHAR(50),
UpdatedAt DATETIME,
UpdatedBy VARCHAR(50),
IsActive BOOLEAN default TRUE
);

create table students (
id int auto_increment primary key,
first_name varchar(50),
last_name varchar(50),
group_id int,
CreatedAt DATETIME,
CreatedBy VARCHAR(50),
UpdatedAt DATETIME,
UpdatedBy VARCHAR(50),
IsActive BOOLEAN default TRUE,
foreign key (group_id) references students_group(id)
);

create table products (
id int auto_increment primary key,
name varchar(100),
price decimal(10, 2),
CreatedAt DATETIME,
CreatedBy VARCHAR(50),
UpdatedAt DATETIME,
UpdatedBy VARCHAR(50),
IsActive BOOLEAN default TRUE
);

create table orders (
id int auto_increment primary key,
when_by date,
student_id int,
CreatedAt DATETIME,
CreatedBy VARCHAR(50),
UpdatedAt DATETIME,
UpdatedBy VARCHAR(50),
IsActive BOOLEAN default TRUE,
foreign key (student_id) references students(id)
);

create table order_details (
order_id int,
product_id int,
review varchar(300),
CreatedAt DATETIME,
CreatedBy VARCHAR(50),
UpdatedAt DATETIME,
UpdatedBy VARCHAR(50),
IsActive BOOLEAN default TRUE,
foreign key (order_id) references orders(id),
foreign key (product_id) references products(id)
);

INSERT INTO students_group (specialization, number, course, CreatedAt, CreatedBy) VALUES 
('Информационные системы', 'ИС-21', 2, NOW(), 'admin'),
('Прикладная математика', 'ПМ-11', 1, NOW(), 'admin'),
('Дизайн', 'Д-31', 3, NOW(), 'admin'),
('Экономика', 'ЭК-12', 1, NOW(), 'admin'),
('Юриспруденция', 'Ю-41', 4, NOW(), 'admin'),
('Архитектура', 'АРХ-22', 2, NOW(), 'admin'),
('Психология', 'ПС-32', 3, NOW(), 'admin'),
('Журналистика', 'Ж-11', 1, NOW(), 'admin'),
('Маркетинг', 'МКТ-21', 2, NOW(), 'admin'),
('Лингвистика', 'ЛИН-42', 4, NOW(), 'admin');

INSERT INTO students (first_name, last_name, group_id, CreatedAt, CreatedBy) VALUES 
('Иван', 'Иванов', 1, NOW(), 'admin'),
('Анна', 'Смирнова', 1, NOW(), 'admin'),
('Петр', 'Петров', 2, NOW(), 'admin'),
('Елена', 'Кузнецова', 3, NOW(), 'admin'),
('Алексей', 'Попов', 4, NOW(), 'admin'),
('Мария', 'Васильева', 5, NOW(), 'admin'),
('Дмитрий', 'Соколов', 6, NOW(), 'admin'),
('Ольга', 'Михайлова', 7, NOW(), 'admin'),
('Никита', 'Новиков', 8, NOW(), 'admin'),
('Софья', 'Федорова', 9, NOW(), 'admin');


INSERT INTO products (name, price, CreatedAt, CreatedBy) VALUES
('Кофе латте', 150.00, NOW(), 'system'),
('Бизнес-ланч №1', 350.50, NOW(), 'system'),
('Тетрадь 48 листов', 85.00, NOW(), 'system'),
('Ручка шариковая', 25.00, NOW(), 'system'),
('Сэндвич с курицей', 180.00, NOW(), 'system'),
('Чай зеленый', 100.00, NOW(), 'system'),
('Энергетик', 120.00, NOW(), 'system'),
('Маркер текстовый', 60.00, NOW(), 'system'),
('Пицца', 110.00, NOW(), 'system'),
('Шоколадный батончик', 75.00, NOW(), 'system');

INSERT INTO orders (when_by, student_id, CreatedAt, CreatedBy) VALUES
('2024-05-15', 1, NOW(), 'web_app'),
('2024-05-16', 2, NOW(), 'web_app'),
('2024-05-16', 1, NOW(), 'web_app'),
('2024-05-17', 3, NOW(), 'web_app'),
('2024-05-17', 4, NOW(), 'web_app'),
('2024-05-18', 5, NOW(), 'web_app'),
('2024-05-18', 6, NOW(), 'web_app'),
('2024-05-19', 7, NOW(), 'web_app'),
('2024-05-19', 8, NOW(), 'web_app'),
('2024-05-20', 9, NOW(), 'web_app');


INSERT INTO order_details (order_id, product_id, review, CreatedAt, CreatedBy) VALUES
(1, 1, 'Очень вкусный кофе, взбодрил перед парой', NOW(), 'admin'),
(1, 3, 'Хорошая бумага, чернила не просвечивают', NOW(), 'admin'),

(2, 2, 'Вкусный ланч!', NOW(), 'admin'),
(2, 4, 'Пишет мягко', NOW(), 'admin'),

(3, 2, 'Не наелся кароче', NOW(), 'admin'),
(3, 1, 'УУУУУУУУУУУ', NOW(), 'admin'),

(4, 5, 'Сэндвич свежий, много соуса', NOW(), 'admin'),
(5, 6, 'Обычный чай', NOW(), 'admin'),
(6, 7, 'Помог пережить ночную подготовку', NOW(), 'admin'),
(7, 9, 'Горячая и сырная!', NOW(), 'admin'),
(8, 10, 'Слишком сладко, но пойдет', NOW(), 'admin');

select sum(products.price) from order_details, products where products.id = order_details.product_id and order_details.order_id = 1;


select count(*) from students where group_id = 1;

select min(price), max(price) from products;

select avg(price) from products;