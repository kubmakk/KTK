-- MySQL dump 10.13  Distrib 8.0.45, for macos15 (arm64)
--
-- Host: 176.32.33.54    Database: Kuznetzov
-- ------------------------------------------------------
-- Server version	8.0.45-0ubuntu0.22.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `client` (
  `id` int NOT NULL AUTO_INCREMENT,
  `phone` varchar(45) DEFAULT NULL,
  `balance` decimal(10,2) DEFAULT NULL,
  `reg_date` datetime DEFAULT NULL,
  `login` varchar(45) DEFAULT NULL,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `UpdatedBy` varchar(50) DEFAULT NULL,
  `IsActive` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` VALUES (1,'89001234567',500.00,'2025-02-11 00:00:00','kubmakk','2026-03-12 09:32:34','admin_alex','2026-03-12 09:32:34',NULL,1),(2,'89112223344',1500.50,'2026-01-15 00:00:00','gamer_pro','2026-03-12 09:33:36','admin_alex','2026-03-12 09:33:36',NULL,1),(3,'89225556677',0.00,'2026-02-01 00:00:00','casual_user','2026-03-12 09:33:36','admin_alex','2026-03-12 09:33:36',NULL,1),(4,'89990001122',5000.00,'2026-03-10 00:00:00','whale_donator','2026-03-12 09:33:36','director','2026-03-12 09:33:36',NULL,1),(5,'89112223344',1500.50,'2026-01-15 00:00:00','gamer_pro','2026-03-12 09:33:56','admin_alex','2026-03-12 09:33:56',NULL,1),(6,'89225556677',0.00,'2026-02-01 00:00:00','casual_user','2026-03-12 09:33:56','admin_alex','2026-03-12 09:33:56',NULL,1),(7,'89990001122',5000.00,'2026-03-10 00:00:00','whale_donator','2026-03-12 09:33:56','director','2026-03-12 09:33:56',NULL,1);
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employee` (
  `id` int NOT NULL AUTO_INCREMENT,
  `position` varchar(45) DEFAULT NULL,
  `rights` varchar(45) DEFAULT NULL,
  `login` varchar(45) DEFAULT NULL,
  `full_name` varchar(255) DEFAULT NULL,
  `full_lastname` varchar(255) DEFAULT NULL,
  `full_patronymic` varchar(45) DEFAULT NULL,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `UpdatedBy` varchar(50) DEFAULT NULL,
  `IsActive` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (1,'administrator','full','admin_alex','Алексей','Смирнов','Иванович','2026-03-12 09:32:37','director','2026-03-12 09:32:37',NULL,1),(2,'operator','limited','ivan_op','Иван','Петров','Сергеевич','2026-03-12 09:33:58','director','2026-03-12 09:33:58',NULL,1),(3,'administrator','full','olga_adm','Ольга','Сидорова','Александровна','2026-03-12 09:33:58','director','2026-03-12 09:33:58',NULL,1),(4,'cleaner','none','babushka_nadya','Надежда','Васильевна','Терешкова','2026-03-12 09:33:58','admin_alex','2026-03-12 09:33:58',NULL,1);
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pc`
--

DROP TABLE IF EXISTS `pc`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pc` (
  `id` int NOT NULL AUTO_INCREMENT,
  `number` int DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `zone` varchar(45) DEFAULT NULL,
  `configure` text,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `UpdatedBy` varchar(50) DEFAULT NULL,
  `IsActive` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pc`
--

LOCK TABLES `pc` WRITE;
/*!40000 ALTER TABLE `pc` DISABLE KEYS */;
INSERT INTO `pc` VALUES (1,10,'free','vip','RTX 4090, 32GB RAM','2026-03-12 09:32:39','admin','2026-03-12 09:32:39',NULL,1),(2,1,'occupied','standard','RTX 3060, 16GB RAM','2026-03-12 09:34:00','admin_alex','2026-03-12 09:34:00',NULL,1),(3,2,'free','standard','RTX 3060, 16GB RAM','2026-03-12 09:34:00','admin_alex','2026-03-12 09:34:00',NULL,1),(4,11,'maintenance','vip','RTX 4090, 64GB RAM','2026-03-12 09:34:00','olga_adm','2026-03-12 09:34:00',NULL,1);
/*!40000 ALTER TABLE `pc` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchase`
--

DROP TABLE IF EXISTS `purchase`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `purchase` (
  `id` int NOT NULL AUTO_INCREMENT,
  `description` varchar(255) DEFAULT NULL,
  `service_id` int DEFAULT NULL,
  `client_id` int DEFAULT NULL,
  `employee_id` int DEFAULT NULL,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `UpdatedBy` varchar(50) DEFAULT NULL,
  `IsActive` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `service_id` (`service_id`),
  KEY `client_id` (`client_id`),
  KEY `employee_id` (`employee_id`),
  CONSTRAINT `purchase_ibfk_1` FOREIGN KEY (`service_id`) REFERENCES `service` (`id`),
  CONSTRAINT `purchase_ibfk_2` FOREIGN KEY (`client_id`) REFERENCES `client` (`id`),
  CONSTRAINT `purchase_ibfk_3` FOREIGN KEY (`employee_id`) REFERENCES `employee` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase`
--

LOCK TABLES `purchase` WRITE;
/*!40000 ALTER TABLE `purchase` DISABLE KEYS */;
INSERT INTO `purchase` VALUES (1,'extra energy drink',1,1,1,'2026-03-12 09:32:44','admin_alex','2026-03-12 09:32:44',NULL,1),(2,'2 cans of coke',3,2,2,'2026-03-12 09:34:05','ivan_op','2026-03-12 09:34:05',NULL,1),(3,'Day pass for weekend',4,4,3,'2026-03-12 09:34:05','olga_adm','2026-03-12 09:34:05',NULL,1),(4,'Pizza slice',2,3,2,'2026-03-12 09:34:05','ivan_op','2026-03-12 09:34:05',NULL,1);
/*!40000 ALTER TABLE `purchase` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `service`
--

DROP TABLE IF EXISTS `service`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `service` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `UpdatedBy` varchar(50) DEFAULT NULL,
  `IsActive` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `service`
--

LOCK TABLES `service` WRITE;
/*!40000 ALTER TABLE `service` DISABLE KEYS */;
INSERT INTO `service` VALUES (1,'night tariff',1000.00,'gaming','2026-03-12 09:32:41','admin','2026-03-12 09:32:41',NULL,1),(2,'1 hour gaming',150.00,'time','2026-03-12 09:34:02','admin_alex','2026-03-12 09:34:02',NULL,1),(3,'Coca-Cola 0.5',120.00,'food','2026-03-12 09:34:02','olga_adm','2026-03-12 09:34:02',NULL,1),(4,'VIP Day Pass',2500.00,'gaming','2026-03-12 09:34:02','director','2026-03-12 09:34:02',NULL,1);
/*!40000 ALTER TABLE `service` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `session`
--

DROP TABLE IF EXISTS `session`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `session` (
  `id` int NOT NULL AUTO_INCREMENT,
  `start_time` datetime DEFAULT NULL,
  `end_time` datetime DEFAULT NULL,
  `cost` decimal(10,2) DEFAULT NULL,
  `client_id` int DEFAULT NULL,
  `pc_id` int DEFAULT NULL,
  `employee_id` int DEFAULT NULL,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `UpdatedBy` varchar(50) DEFAULT NULL,
  `IsActive` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `client_id` (`client_id`),
  KEY `pc_id` (`pc_id`),
  KEY `employee_id` (`employee_id`),
  CONSTRAINT `session_ibfk_1` FOREIGN KEY (`client_id`) REFERENCES `client` (`id`),
  CONSTRAINT `session_ibfk_2` FOREIGN KEY (`pc_id`) REFERENCES `pc` (`id`),
  CONSTRAINT `session_ibfk_3` FOREIGN KEY (`employee_id`) REFERENCES `employee` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `session`
--

LOCK TABLES `session` WRITE;
/*!40000 ALTER TABLE `session` DISABLE KEYS */;
INSERT INTO `session` VALUES (1,'2026-02-10 20:00:00',NULL,250.50,1,1,1,'2026-03-12 09:32:42','admin_alex','2026-03-12 09:32:42',NULL,1),(2,'2026-03-12 10:00:00','2026-03-12 12:00:00',300.00,2,2,2,'2026-03-12 09:34:04','ivan_op','2026-03-12 09:34:04',NULL,1),(3,'2026-03-12 11:30:00',NULL,150.00,3,3,2,'2026-03-12 09:34:04','ivan_op','2026-03-12 09:34:04',NULL,1),(4,'2026-03-11 22:00:00','2026-03-12 08:00:00',1000.00,4,1,3,'2026-03-12 09:34:04','olga_adm','2026-03-12 09:34:04',NULL,1);
/*!40000 ALTER TABLE `session` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-03-12 12:35:22
