drop database library_db;
create database library_db;
use library_db;

create table genres (
    genre_id int primary key auto_increment,
    name varchar(50),
    description text
);

create table publishers (
    publisher_id int primary key auto_increment,
    name varchar(100),
    city varchar(50)
);

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

create table readers (
    reader_id int primary key auto_increment,
    first_name varchar(50),
    last_name varchar(50),
    birth_year int
);

create table bookloans (
    loan_id int primary key auto_increment,
    reader_id int,
    book_id int,
    loan_date date,
    return_date date,
    foreign key (reader_id) references readers(reader_id),
    foreign key (book_id) references books(book_id)
);

create table reviews (
    review_id int primary key auto_increment,
    reader_id int,
    book_id int,
    rating int,
    comment text,
    foreign key (reader_id) references readers(reader_id),
    foreign key (book_id) references books(book_id)
);

create table oldcatalog (
    old_book_id int primary key auto_increment,
    old_title varchar(200),
    old_code varchar(50)
);


----

insert into genres (name, description) values
('Фантастика', 'Книги о вымышленных мирах и технологиях'),
('Детектив', 'Художественные произведения о расследованиях'),
('Роман', 'Истории о человеческих судьбах и отношениях'),
('Научпоп', 'Научно-популярная литература'),
('История', 'Книги об исторических эпохах и событиях');

insert into publishers (name, city) values
('Эксмо', 'Москва'),
('АСТ', 'Москва'),
('Питер', 'Санкт-Петербург'),
('МИФ', 'Москва'),
('Альпина', 'Москва');

insert into books (title, author, publish_year, genre_id, publisher_id) values
('Дюна', 'Фрэнк Герберт', 1965, 1, 2),
('Убийство в Восточном экспрессе', 'Агата Кристи', 1934, 2, 1),
('Мастер и Маргарита', 'Михаил Булгаков', 1967, 3, 2),
('Краткая история времени', 'Стивен Хокинг', 1988, 4, 3),
('Sapiens', 'Юваль Ной Харари', 2011, 5, 4);

insert into readers (first_name, last_name, birth_year) values
('Иван', 'Иванов', 1990),
('Петр', 'Петров', 1985),
('Анна', 'Смирнова', 1995),
('Елена', 'Соколова', 1992),
('Алексей', 'Попов', 1988);

insert into bookloans (reader_id, book_id, loan_date, return_date) values
(1, 1, '2023-10-01', '2023-10-15'),
(2, 2, '2023-10-05', '2023-10-20'),
(3, 3, '2023-10-10', '2023-10-25'),
(4, 4, '2023-11-01', '2023-11-15'),
(5, 5, '2023-11-02', '2023-11-16');

insert into reviews (reader_id, book_id, rating, comment) values
(1, 1, 5, 'Потрясающая вселенная!'),
(2, 2, 4, 'Очень запутанно, но интересно.'),
(3, 3, 5, 'Классика на все времена.'),
(4, 4, 5, 'Сложные вещи простым языком.'),
(5, 5, 4, 'Отличный обзор истории человечества.');

insert into oldcatalog (old_title, old_code) values
('Старая книга 1', 'OLD-001'),
('Старая книга 2', 'OLD-002'),
('Старая книга 3', 'OLD-003'),
('Старая книга 4', 'OLD-004'),
('Старая книга 5', 'OLD-005');

---
describe readers;
alter table readers add email varchar(100);
describe readers;

describe books;
alter table books add pages_count int;
describe books;

describe publishers;
alter table publishers add website varchar(100);
describe publishers;

describe books;
alter table books rename column author to main_author;
describe books;

describe genres;
alter table genres drop column description;
describe genres;

describe reviews;
alter table reviews drop column comment;
describe reviews;

describe oldcatalog;
drop table oldcatalog;

