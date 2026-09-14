Конечно! Вот код для первой части 4-го задания (создание БД стримингового сервиса на PostgreSQL), где все SQL-команды, типы данных и названия таблиц/столбцов переведены в нижний регистр.
Текстовые значения (имена артистов, названия песен) я оставил в исходном виде, чтобы данные в таблицах выглядели красиво.
-- 1. таблица жанров
create table genres (
    genre_id serial primary key,
    name varchar(50) unique not null
);

-- 2. таблица артистов
create table artists (
    artist_id serial primary key,
    name varchar(100) not null,
    country varchar(50) default 'Unknown',
    birth_year int check (birth_year > 1900 and birth_year <= extract(year from current_date))
);

-- 3. таблица пользователей
create table users (
    user_id serial primary key,
    username varchar(50) unique not null,
    email varchar(100) unique not null,
    registration_date date default current_date
);

-- 4. таблица альбомов (связь с артистами)
create table albums (
    album_id serial primary key,
    artist_id int not null,
    title varchar(150) not null,
    release_year int check (release_year >= 1900),
    foreign key (artist_id) references artists(artist_id) on delete cascade
);

-- 5. таблица треков (связи с альбомами и жанрами)
create table tracks (
    track_id serial primary key,
    album_id int not null,
    genre_id int not null,
    title varchar(200) not null,
    duration_seconds int not null check (duration_seconds > 0),
    foreign key (album_id) references albums(album_id) on delete cascade,
    foreign key (genre_id) references genres(genre_id) on delete set null
);

-- 6. таблица плейлистов (связь с пользователями)
create table playlists (
    playlist_id serial primary key,
    user_id int not null,
    name varchar(100) not null,
    is_public boolean default true,
    foreign key (user_id) references users(user_id) on delete cascade
);

-- 7. таблица связи многие-ко-многим: треки в плейлистах
create table playlist_tracks (
    playlist_id int not null,
    track_id int not null,
    added_at timestamp default current_timestamp,
    primary key (playlist_id, track_id),
    foreign key (playlist_id) references playlists(playlist_id) on delete cascade,
    foreign key (track_id) references tracks(track_id) on delete cascade
);

-- заполнение тестовыми данными (по 3-5 записей)
insert into genres (name) values 
('Rock'), ('Pop'), ('Hip-Hop'), ('Electronic');

insert into artists (name, country, birth_year) values 
('The Weeknd', 'Canada', 1990),
('Daft Punk', 'France', 1974),
('Arctic Monkeys', 'UK', 1986);

insert into users (username, email) values 
('music_fan99', 'fan@mail.com'),
('dj_alex', 'alex@dj.ru'),
('meloman_anna', 'anna@yandex.ru');

insert into albums (artist_id, title, release_year) values 
(1, 'After Hours', 2020),
(2, 'Discovery', 2001),
(3, 'AM', 2013);

insert into tracks (album_id, genre_id, title, duration_seconds) values 
(1, 2, 'Blinding Lights', 200),
(1, 2, 'Save Your Tears', 215),
(2, 4, 'Harder, Better, Faster, Stronger', 224),
(3, 1, 'Do I Wanna Know?', 272);

insert into playlists (user_id, name, is_public) values 
(1, 'My Workout', true),
(2, 'Party Mix', true),
(3, 'Sad Vibes', false);

insert into playlist_tracks (playlist_id, track_id) values 
(1, 3), (1, 1), 
(2, 3), (2, 4), 
(3, 2);

Если нужно перевести в нижний регистр и код из второго задания (с исправлением ошибок для магазина), дай знать!



задание2

CREATE DATABASE IF NOT EXISTS Shop; -[span_0](start_span)- Вместо IF EXISTS нужно IF NOT EXISTS, иначе база не создастся, если ее нет[span_0](end_span).

USE Shop; -[span_1](start_span)- Было USE ShopDB, хотя создаваемая база называется Shop[span_1](end_span).

-- 1. Сначала создаем таблицы-справочники (без внешних ключей)
[span_2](start_span)[span_3](start_span)CREATE TABLE categories ( -- Эта таблица создавалась ПОСЛЕ products, что вызывало ошибку связей[span_2](end_span)[span_3](end_span).
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50) UNIQUE NOT NULL,
    description VARCHAR(200)
);

CREATE TABLE customers (
    [span_4](start_span)[span_5](start_span)customer_id INT PRIMARY KEY, -- Был тип VARCHAR(20), который не совпадал с INT в таблице orders[span_4](end_span)[span_5](end_span).
    first_name VARCHAR(256) NOT NULL,
    last_name VARCHAR(256) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    phone VARCHAR(15) NOT NULL,
    birth_date DATE NOT NULL CHECK (birth_date <= CURDATE()),
    registration_date DATE DEFAULT (CURDATE())
);

-- 2. Затем создаем таблицы, которые ссылаются на справочники
CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100) NOT NULL,
    category_id INT NOT NULL,
    price DECIMAL(10,2) NOT NULL CHECK (price > 0),
    quantity INT NOT NULL DEFAULT 0 CHECK (quantity >= 0),
    [span_6](start_span)is_available BOOLEAN DEFAULT TRUE, -- Была опечатка: BO0LEAN (через ноль)[span_6](end_span).
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT NOT NULL,
    order_date DATE NOT NULL DEFAULT (CURDATE()),
    [span_7](start_span)total_amount DECIMAL(12,2) NOT NULL CHECK (total_amount >= 0), -- Была опечатка: DEMICAL[span_7](end_span).
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

-- 3. Заполнение данными (сначала справочники, потом зависимые)

INSERT INTO categories (category_id, category_name, description) VALUES
(1, 'Электроника', 'Смартфоны, ноутбуки, планшеты'),
(2, 'Одежда', 'Футболки, джинсы, куртки'),
(3, 'Книги', 'Художественная литература');

INSERT INTO customers (customer_id, first_name, last_name, email, phone, birth_date) VALUES
(1, 'Иван', 'Иванов', 'ivan@mail.ru', '89151234567', '1990-05-15'),
(2, 'Мария', 'Петрова', 'maria1@gmail.com', '89161234567', '1995-08-22')[span_8](start_span), -- Был "НУЛЛ" (нельзя в NOT NULL) и повторяющийся email[span_8](end_span).
(3, 'Алексей', 'Сидоров', 'alex@yandex.ru', '89171234567', '1988-11-10'),
(4, 'Дмитрий', 'Новиков', 'dmitry@mail.ru', '89181234567', '1992-03-25')[span_9](start_span), -- Дублировался первичный ключ 1[span_9](end_span).
(5, 'Ольга', 'Морозова', 'olga@mail.ru', '89191234567', '1998-07-18')[span_10](start_span), -- Был NULL в имени (нарушение NOT NULL)[span_10](end_span).
(6, 'Елена', 'Иванова', 'elena@mail.ru', '89191234567', '1995-01-01'); -[span_11](start_span)- Была дата 2030 год (нарушение CHECK <= CURDATE())[span_11](end_span).

[span_12](start_span)INSERT INTO products (product_id, product_name, category_id, price, quantity) VALUES -- Было пропущено ключевое слово VALUES[span_12](end_span).
(1, 'Смартфон Xiaomi', 1, 25000.00, 10)[span_13](start_span), -- Была пропущена запятая после ID 1[span_13](end_span).
(2, 'Футболка черная', 2, 1500.00, 50),
(3, 'Книга "Мастер и Маргарита"', 3, 800.00, 30)[span_14](start_span), -- Была пропущена запятая в конце строки[span_14](end_span).
(4, 'Ноутбук', 1, 50000.00, 5)[span_15](start_span), -- Была отрицательная цена (нарушение CHECK price > 0)[span_15](end_span).
(5, 'Ноутбук', 1, 50000.00, 5)[span_16](start_span), -- Было отрицательное количество (нарушение CHECK quantity >= 0)[span_16](end_span).
(6, 'Ноутбук', 1, 50000.00, 5); -[span_17](start_span)- Был указан несуществующий category_id 999 (ошибка внешнего ключа)[span_17](end_span).

[span_18](start_span)INSERT INTO orders (order_id, customer_id, total_amount, status) VALUES -- Было пропущено ключевое слово VALUES[span_18](end_span).
(1, 1, 25000.00, 'processing')[span_19](start_span), -- Пропущена запятая после 1 и статус 'waiting' нарушал CHECK[span_19](end_span).
(2, 1, 1000.00, 'delivered')[span_20](start_span), -- Была отрицательная сумма и статус 'old' (оба нарушали CHECK)[span_20](end_span).
(3, 2, 25000.00, 'new')[span_21](start_span), -- Был указан несуществующий customer_id 999 (ошибка внешнего ключа)[span_21](end_span).
(4, 1, 25000.00, 'new'); -[span_22](start_span)- Был указан недопустимый статус 'hello' (нарушение CHECK)[span_22](end_span).

[span_23](start_span)INSERT INTO order_items (order_item_id, order_id, product_id, quantity, price_at_order) VALUES -- Было пропущено ключевое слово VALUES[span_23](end_span).
(1, 4, 1, 1, 25000.00)[span_24](start_span), -- Были пропущены запятые, а количество 0 нарушало CHECK > 0[span_24](end_span).
(2, 4, 1, 1, 25000.00)[span_25](start_span), -- Была отрицательная цена (нарушение CHECK > 0)[span_25](end_span).
(3, 4, 1, 1, 25000.00)[span_26](start_span), -- Был указан несуществующий product_id 999 (ошибка внешнего ключа)[span_26](end_span).
(4, 1, 1, 1, 25000.00); -[span_27](start_span)- Был указан несуществующий order_id 999 (ошибка внешнего ключа)[span_27](end_span).

-- 4. Правильное удаление
DROP TABLE order_items, orders, products, customers, categories; -[span_28](start_span)- Удалять нужно в обратном порядке: сначала те, где есть внешние ключи, потом справочники[span_28](end_span).
DROP DATABASE Shop; -[span_29](start_span)- Было SHOP, регистр в некоторых СУБД имеет значение[span_29](end_span).
