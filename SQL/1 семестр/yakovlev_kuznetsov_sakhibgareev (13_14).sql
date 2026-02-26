Create database mebel132;
Use mebel132;

CREATE TABLE IF NOT EXISTS sampling (
  id_measurements INT NOT NULL AUTO_INCREMENT,
  designer VARCHAR(45) NULL,
  client VARCHAR(45) NULL,
  adress VARCHAR(45) NULL,
  measurements VARCHAR(45) NULL,
  estimate_cost INT NULL,
  status TINYINT(1) NULL,
  PRIMARY KEY (id_measurements)
);

CREATE TABLE IF NOT EXISTS designer (
  id_designer INT NOT NULL AUTO_INCREMENT,
  name VARCHAR(45) NULL,
  surname VARCHAR(45) NULL,
  patronymic VARCHAR(45) NULL,
  number INT NULL,
  order_id_measurements INT NOT NULL,
  PRIMARY KEY (id_designer),
    FOREIGN KEY (order_id_measurements)
    REFERENCES sampling (id_measurements)
);
CREATE TABLE IF NOT EXISTS client (
  id_client INT NOT NULL AUTO_INCREMENT,
  name VARCHAR(45) NULL,
  surname VARCHAR(45) NULL,
  patronymic VARCHAR(45) NULL,
  number INT NULL,
  adress VARCHAR(45) NULL,
  order_id_measurements INT NOT NULL,
  PRIMARY KEY (id_client),
    FOREIGN KEY (order_id_measurements)
    REFERENCES sampling (id_measurements)
    );

CREATE TABLE IF NOT EXISTS prepayment (
  id_prepayment INT NOT NULL AUTO_INCREMENT,
  sampling_id_measurements INT NOT NULL,
  amount INT NULL,
  date DATE NULL,
  PRIMARY KEY (id_prepayment),
    FOREIGN KEY (sampling_id_measurements)
    REFERENCES sampling (id_measurements)
);

CREATE TABLE IF NOT EXISTS production (
  id_production INT NOT NULL,
  materials VARCHAR(255) NULL,
  start DATE NULL,
  end DATE NULL,
  prepayment_id_prepayment INT NOT NULL,
  PRIMARY KEY (id_production),
    FOREIGN KEY (prepayment_id_prepayment)
    REFERENCES prepayment (id_prepayment)
);
CREATE TABLE IF NOT EXISTS delivery (
  id_delivery INT NOT NULL AUTO_INCREMENT,
  delivery_date DATE NULL,
  assembled TINYINT(1) NULL,
  deliverycol VARCHAR(45) NULL,
  sampling_id_measurements INT NOT NULL,
  PRIMARY KEY (id_delivery),
    FOREIGN KEY (sampling_id_measurements)
    REFERENCES sampling (id_measurements)
    );

CREATE TABLE IF NOT EXISTS finalpayment (
  id_finalpayment INT NOT NULL,
  amount INT NULL,
  date DATE NULL,
  sampling_id_measurements INT NOT NULL,
  PRIMARY KEY (id_finalpayment),
    FOREIGN KEY (sampling_id_measurements)
    REFERENCES sampling (id_measurements)
);

