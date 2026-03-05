Конечно, без проблем! Текстовые данные (названия книг, имена) я оставил в исходном регистре, чтобы они корректно отображались в базе, а все SQL-команды, названия таблиц и столбцов перевел в строчные буквы.
Задание 1: Создание базы данных и таблиц
-- создание базы данных (если она еще не создана)
create database if not exists library_db;
use library_db;

-- 1. таблица жанров (справочник, на который будет ссылаться books)
create table genres (
    genre_id int primary key auto_increment,
    name varchar(50),
    description text
);

-- 2. таблица издательств (справочник, на который будет ссылаться books)
create table publishers (
    publisher_id int primary key auto_increment,
    name varchar(100),
    city varchar(50)
);

-- 3. таблица книг (ссылается на genres и publishers)
create table books (
    book_id int primary key auto_increment,
    title varchar(200),
    author varchar(100),
    publish_year int,
    genre_id int,
    publisher_id int,
    foreign key (genre_id) references genres(genre_id),
    foreign key (publisher_id) references publishers(publisher_id)
);

-- 4. таблица читателей (на нее будут ссылаться bookloans и reviews)
create table readers (
    reader_id int primary key auto_increment,
    first_name varchar(50),
    last_name varchar(50),
    birth_year int
);

-- 5. таблица выдачи книг (ссылается на readers и books)
create table bookloans (
    loan_id int primary key auto_increment,
    reader_id int,
    book_id int,
    loan_date date,
    return_date date,
    foreign key (reader_id) references readers(reader_id),
    foreign key (book_id) references books(book_id)
);

-- 6. таблица отзывов (ссылается на readers и books)
create table reviews (
    review_id int primary key auto_increment,
    reader_id int,
    book_id int,
    rating int,
    comment text,
    foreign key (reader_id) references readers(reader_id),
    foreign key (book_id) references books(book_id)
);

-- 7. таблица старого каталога без связей с другими таблицами
create table oldcatalog (
    old_book_id int primary key auto_increment,
    old_title varchar(200),
    old_code varchar(50)
);

Задание 2: Заполнение таблиц данными
-- добавление жанров
insert into genres (name, description) values
('Фантастика', 'Книги о вымышленных мирах и технологиях'),
('Детектив', 'Художественные произведения о расследованиях'),
('Роман', 'Истории о человеческих судьбах и отношениях'),
('Научпоп', 'Научно-популярная литература'),
('История', 'Книги об исторических эпохах и событиях');

-- добавление издательств
insert into publishers (name, city) values
('Эксмо', 'Москва'),
('АСТ', 'Москва'),
('Питер', 'Санкт-Петербург'),
('МИФ', 'Москва'),
('Альпина', 'Москва');

-- добавление книг
insert into books (title, author, publish_year, genre_id, publisher_id) values
('Дюна', 'Фрэнк Герберт', 1965, 1, 2),
('Убийство в Восточном экспрессе', 'Агата Кристи', 1934, 2, 1),
('Мастер и Маргарита', 'Михаил Булгаков', 1967, 3, 2),
('Краткая история времени', 'Стивен Хокинг', 1988, 4, 3),
('Sapiens', 'Юваль Ной Харари', 2011, 5, 4);

-- добавление читателей
insert into readers (first_name, last_name, birth_year) values
('Иван', 'Иванов', 1990),
('Петр', 'Петров', 1985),
('Анна', 'Смирнова', 1995),
('Елена', 'Соколова', 1992),
('Алексей', 'Попов', 1988);

-- добавление записей о выдаче книг 
insert into bookloans (reader_id, book_id, loan_date, return_date) values
(1, 1, '2023-10-01', '2023-10-15'),
(2, 2, '2023-10-05', '2023-10-20'),
(3, 3, '2023-10-10', '2023-10-25'),
(4, 4, '2023-11-01', '2023-11-15'),
(5, 5, '2023-11-02', '2023-11-16');

-- добавление отзывов
insert into reviews (reader_id, book_id, rating, comment) values
(1, 1, 5, 'Потрясающая вселенная!'),
(2, 2, 4, 'Очень запутанно, но интересно.'),
(3, 3, 5, 'Классика на все времена.'),
(4, 4, 5, 'Сложные вещи простым языком.'),
(5, 5, 4, 'Отличный обзор истории человечества.');

-- добавление старых книг
insert into oldcatalog (old_title, old_code) values
('Старая книга 1', 'OLD-001'),
('Старая книга 2', 'OLD-002'),
('Старая книга 3', 'OLD-003'),
('Старая книга 4', 'OLD-004'),
('Старая книга 5', 'OLD-005');

Задание 3: Изменение структуры таблиц (alter table)
-- 1. добавление новых столбцов
alter table readers add email varchar(100);
alter table books add pages_count int;
alter table publishers add website varchar(100);

-- 2. переименование существующего столбца 
alter table books rename column author to main_author;

-- 3. удаление ненужных столбцов
alter table genres drop column description;
alter table reviews drop column comment;

-- 4. полное удаление таблицы oldcatalog
drop table oldcatalog;

Хочешь, я подготовлю для тебя запросы select, чтобы ты мог(ла) проверить, как выглядят данные в таблицах после всех изменений?
