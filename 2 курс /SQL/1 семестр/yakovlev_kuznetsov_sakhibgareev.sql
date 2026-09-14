CREATE DATABASE IF NOT EXISTS mebel55;
USE mebel55;

CREATE TABLE designers (
  id_designer INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(45),
  surname VARCHAR(45),
  patronymic VARCHAR(45),
  phone VARCHAR(20)
);

INSERT INTO designers(name, surname, patronymic, phone)
VALUES 
('Ilya', 'Yakovlev', 'Urevich', '234987'),
('Olya', 'Yakovleva', 'Olegovna', '233124987'),
('Artem', 'Nikolaev', 'Alexandrovich', '2349874332');  

CREATE TABLE clients (
  id_client INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(45),
  surname VARCHAR(45),
  patronymic VARCHAR(45),
  phone VARCHAR(20),
  address VARCHAR(200)
);

INSERT INTO clients(name, surname, patronymic, phone, address)
VALUES 
('Ilya', 'Yakovlev', 'Urevich', '89278234897', 'Kazan, Shamula Usmanova 25a'),
('Nikita', 'Kuznetsov', 'Andreevich', '83427862332', 'Kazan'),
('Andrew', 'Semenov', 'Yuryevich', '848761234892', 'Naberezhnye Chelny, Rasolnikova 23'); 

CREATE TABLE sampling (
  id_measurements INT AUTO_INCREMENT PRIMARY KEY,
  designer_id INT,
  client_id INT,
  measurements TEXT,
  estimate_cost INT,
  status TINYINT(1),
  FOREIGN KEY (designer_id) REFERENCES designers(id_designer),
  FOREIGN KEY (client_id) REFERENCES clients(id_client)
);

INSERT INTO sampling(designer_id, client_id, measurements, estimate_cost, status)
VALUES 
(1, 1, 'Overall dimensions: 200x90x85 cm, client height 180 cm, chest 105 cm', 150000, 1),
(2, 2, 'Overall dimensions: 180x85x80 cm, client height 175 cm, chest 98 cm', 120000, 1),
(3, 3, 'Overall dimensions: 210x95x90 cm, client height 185 cm, chest 110 cm', 180000, 0); 

CREATE TABLE prepayment (
  id_prepayment INT AUTO_INCREMENT PRIMARY KEY,
  sampling_id INT NOT NULL,
  amount INT,
  date DATE,
  FOREIGN KEY (sampling_id) REFERENCES sampling(id_measurements)
);

INSERT INTO prepayment(sampling_id, amount, date)
VALUES 
(1, 50000, '2025-01-15'),
(2, 40000, '2025-01-20'),
(3, 60000, '2025-01-25'); 

CREATE TABLE production (
  id_production INT AUTO_INCREMENT PRIMARY KEY,
  materials VARCHAR(255),
  start_date DATE,
  end_date DATE,
  prepayment_id INT NOT NULL,
  FOREIGN KEY (prepayment_id) REFERENCES prepayment(id_prepayment)
);

INSERT INTO production(materials, start_date, end_date, prepayment_id)
VALUES 
('Oak solid wood, velvet fabric, spring block', '2025-01-20', '2025-02-10', 1),
('Beech wood, eco-leather, independent springs', '2025-01-25', '2025-02-15', 2),
('Ash wood, latex, pocket springs', '2025-02-01', '2025-02-25', 3);  

CREATE TABLE delivery (
  id_delivery INT AUTO_INCREMENT PRIMARY KEY,
  delivery_date DATE,
  assembled TINYINT(1),
  delivery_cost VARCHAR(45),
  sampling_id INT NOT NULL,
  FOREIGN KEY (sampling_id) REFERENCES sampling(id_measurements)
);

INSERT INTO delivery(delivery_date, assembled, delivery_cost, sampling_id)
VALUES 
('2025-02-15', 1, '5000', 1),
('2025-02-20', 1, '4000', 2),
('2025-03-05', 0, '7000', 3); 

CREATE TABLE finalpayment (
  id_finalpayment INT AUTO_INCREMENT PRIMARY KEY,
  amount INT,
  date DATE,
  sampling_id INT NOT NULL,
  FOREIGN KEY (sampling_id) REFERENCES sampling(id_measurements)
);

INSERT INTO finalpayment(amount, date, sampling_id)
VALUES 
(100000, '2025-02-16', 1),
(80000, '2025-02-21', 2),
(120000, '2025-03-06', 3); 