drop database yandex;
create database yandex;
use yandex;

create table genres (
    genre_id int primary key,
    name varchar(50) unique not null
);

create table artists (
    artist_id int primary key,
    name varchar(100) not null,
    country varchar(50) default 'Unknown',
    birth_year int check (birth_year > 1900)
);

create table users (
    user_id int primary key,
    username varchar(50) unique not null,
    email varchar(100) unique not null,
    registration_date date
);

create table albums (
    album_id int primary key,
    artist_id int not null,
    title varchar(150) not null,
    release_year int check (release_year >= 1900),
    foreign key (artist_id) references artists(artist_id)
);

create table tracks (
    track_id int primary key,
    album_id int not null,
    genre_id int,
    title varchar(200) not null,
    duration_seconds int not null check (duration_seconds > 0),
    foreign key (album_id) references albums(album_id),
    foreign key (genre_id) references genres(genre_id) on delete set null
);

create table playlists (
    playlist_id int primary key,
    user_id int not null,
    name varchar(100) not null,
    is_public boolean default true,
    foreign key (user_id) references users(user_id)
);

create table playlist_tracks (
    playlist_id int not null,
    track_id int not null,
    added_at timestamp default current_timestamp,
    primary key (playlist_id, track_id),
    foreign key (playlist_id) references playlists(playlist_id),
    foreign key (track_id) references tracks(track_id)
);

INSERT INTO genres (genre_id, name) VALUES 
(1, 'Rock'), (2, 'Pop'), (3, 'Hip-Hop'), (4, 'Electronic');

INSERT INTO artists (artist_id, name, country, birth_year) VALUES 
(1, 'The Weeknd', 'Canada', 1990),
(2, 'Daft Punk', 'France', 1974),
(3, 'Arctic Monkeys', 'UK', 1986);

INSERT INTO users (user_id, username, email, registration_date) VALUES 
(1, 'music_fan99', 'fan@mail.com', CURDATE()),
(2, 'dj_alex', 'alex@dj.ru', CURDATE()),
(3, 'meloman_anna', 'anna@yandex.ru', CURDATE());

INSERT INTO albums (album_id, artist_id, title, release_year) VALUES 
(1, 1, 'After Hours', 2020),
(2, 2, 'Discovery', 2001),
(3, 3, 'AM', 2013);

INSERT INTO tracks (track_id, album_id, genre_id, title, duration_seconds) VALUES 
(1, 1, 2, 'Blinding Lights', 200),
(2, 1, 2, 'Save Your Tears', 215),
(3, 2, 4, 'Harder, Better, Faster, Stronger', 224),
(4, 3, 1, 'Do I Wanna Know?', 272);

INSERT INTO playlists (playlist_id, user_id, name, is_public) VALUES 
(1, 1, 'My Workout', true),
(2, 2, 'Party Mix', true),
(3, 3, 'Sad Vibes', false);

INSERT INTO playlist_tracks (playlist_id, track_id) VALUES 
(1, 3), (1, 1), 
(2, 3), (2, 4), 
(3, 2);



CREATE DATABASE IF NOT EXISTS Shop; -- Вместо IF EXISTS нужно IF NOT EXISTS, иначе база не создастся, если ее нет.

USE Shop; -- Было USE ShopDB, хотя создаваемая база называется Shop_1].

-- 1. Сначала создаем таблицы-справочники (без внешних ключей)
CREATE TABLE categories ( -- Эта таблица создавалась ПОСЛЕ products, что вызывало ошибку связей_2]_3].
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50) UNIQUE NOT NULL,
    description VARCHAR(200)
);

CREATE TABLE customers (
    customer_id INT PRIMARY KEY, -- Был тип VARCHAR(20), который не совпадал с INT в таблице orders_4]_5].
    first_name VARCHAR(256) NOT NULL,
    last_name VARCHAR(256) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    phone VARCHAR(15) NOT NULL,
    birth_date DATE NOT NULL CHECK (birth_date <= CURDATE()),
    registration_date DATE DEFAULT (CURDATE())
);

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100) NOT NULL,
    category_id INT NOT NULL,
    price DECIMAL(10,2) NOT NULL CHECK (price > 0),
    quantity INT NOT NULL DEFAULT 0 CHECK (quantity >= 0),
    is_available BOOLEAN DEFAULT TRUE, -- Была опечатка: BO0LEAN (через ноль)_6].
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT NOT NULL,
    order_date DATE NOT NULL DEFAULT (CURDATE()),
    total_amount DECIMAL(12,2) NOT NULL CHECK (total_amount >= 0), -- Была опечатка: DEMICAL_7].
    status VARCHAR(20) NOT NULL CHECK (status IN ('new', 'processing', 'shipped', 'delivered', 'cancelled')),
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);

CREATE TABLE order_items (
    order_item_id INT PRIMARY KEY,
    order_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL CHECK (quantity > 0),
    price_at_order DECIMAL(10,2) NOT NULL CHECK (price_at_order > 0),
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);


INSERT INTO categories (category_id, category_name, description) VALUES
(1, 'Электроника', 'Смартфоны, ноутбуки, планшеты'),
(2, 'Одежда', 'Футболки, джинсы, куртки'),
(3, 'Книги', 'Художественная литература');

INSERT INTO customers (customer_id, first_name, last_name, email, phone, birth_date) VALUES
(1, 'Иван', 'Иванов', 'ivan@mail.ru', '89151234567', '1990-05-15'),
(2, 'Мария', 'Петрова', 'maria1@gmail.com', '89161234567', '1995-08-22'), -- Был "НУЛЛ" (нельзя в NOT NULL) и повторяющийся email.
(3, 'Алексей', 'Сидоров', 'alex@yandex.ru', '89171234567', '1988-11-10'),
(4, 'Дмитрий', 'Новиков', 'dmitry@mail.ru', '89181234567', '1992-03-25'), -- Дублировался первичный ключ.
(5, 'Ольга', 'Морозова', 'olga@mail.ru', '89191234567', '1998-07-18'), -- Был NULL в имени (нарушение NOT NULL).
(6, 'Елена', 'Иванова', 'elena@mail.ru', '89191234567', '1995-01-01'); -- Была дата 2030 год (нарушение CHECK <= CURDATE()).

INSERT INTO products (product_id, product_name, category_id, price, quantity) VALUES -- Было пропущено ключевое слово VALUES.
(1, 'Смартфон Xiaomi', 1, 25000.00, 10), -- Была пропущена запятая после ID .
(2, 'Футболка черная', 2, 1500.00, 50),
(3, 'Книга "Мастер и Маргарита"', 3, 800.00, 30), -- Была пропущена запятая в конце строки.
(4, 'Ноутбук', 1, 50000.00, 5), -- Была отрицательная цена (нарушение CHECK price > 0).
(5, 'Ноутбук', 1, 50000.00, 5), -- Было отрицательное количество (нарушение CHECK quantity >= 0).
(6, 'Ноутбук', 1, 50000.00, 5); -- Был указан несуществующий category_id 999 (ошибка внешнего ключа)

INSERT INTO orders (order_id, customer_id, total_amount, status) VALUES -- Было пропущено ключевое слово VALUES
(1, 1, 25000.00, 'processing'), -- Пропущена запятая после 1 и статус 'waiting' нарушал CHECK
(2, 1, 1000.00, 'delivered'), -- Была отрицательная сумма и статус 'old' (оба нарушали CHECK)
(3, 2, 25000.00, 'new'), -- Был указан несуществующий customer_id 999 (ошибка внешнего ключа)
(4, 1, 25000.00, 'new'); -- Был указан недопустимый статус 'hello' (нарушение CHECK)

INSERT INTO order_items (order_item_id, order_id, product_id, quantity, price_at_order) VALUES -- Было пропущено ключевое слово VALUES
(1, 4, 1, 1, 25000.00)], -- Были пропущены запятые, а количество 0 нарушало CHECK > 0
(2, 4, 1, 1, 25000.00), -- Была отрицательная цена (нарушение CHECK > 0)
(3, 4, 1, 1, 25000.00), -- Был указан несуществующий product_id 999 (ошибка внешнего ключа)
(4, 1, 1, 1, 25000.00); -- Был указан несуществующий order_id 999 (ошибка внешнего ключа)


DROP TABLE order_items, orders, products, customers, categories; -- Удалять нужно в обратном порядке: сначала те, где есть внешние ключи, потом справочники
DROP DATABASE Shop; -- Было SHOP, регистр в некоторых СУБД имеет значение
