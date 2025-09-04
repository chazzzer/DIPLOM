CREATE DATABASE  IF NOT EXISTS `raykhert_korund` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `raykhert_korund`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: raykhert_korund
-- ------------------------------------------------------
-- Server version	8.0.37

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `группы`
--

DROP TABLE IF EXISTS `группы`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `группы` (
  `id_группы` int NOT NULL AUTO_INCREMENT,
  `название_группы` varchar(45) DEFAULT NULL,
  `id_курса` int DEFAULT NULL,
  `id_преподавателя` int DEFAULT NULL,
  `осталось_часов` int DEFAULT NULL,
  `старт_обучения` date DEFAULT NULL,
  `окончание_обучения` date DEFAULT NULL,
  PRIMARY KEY (`id_группы`),
  KEY `fk_группы_учителя1_idx` (`id_преподавателя`),
  KEY `fk_kurssss_idx` (`id_курса`),
  CONSTRAINT `fk_kurssss` FOREIGN KEY (`id_курса`) REFERENCES `курсы` (`id_курса`),
  CONSTRAINT `fk_группы_учителя1` FOREIGN KEY (`id_преподавателя`) REFERENCES `преподаватели` (`id_преподавателя`)
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `группы`
--

LOCK TABLES `группы` WRITE;
/*!40000 ALTER TABLE `группы` DISABLE KEYS */;
INSERT INTO `группы` VALUES (18,'JОП-1',2,2,0,'2024-01-01','2024-07-29'),(19,'ИИРП-1',6,9,180,'2025-04-07','2026-02-16'),(20,'CРРП-1',4,4,0,'2025-04-07','2025-04-07'),(29,'СТУБ-1',9,9,100,'2025-04-12','2025-10-04'),(30,'JОП-2',2,2,92,'2025-04-13','2025-11-09'),(32,'PНООП-1',3,8,100,'2025-06-01','2025-11-23'),(33,'СТУБ-2',10,2,140,'2025-06-01','2026-02-01'),(34,'СТУБ-3',10,1,140,'2025-06-01','2026-02-01'),(35,'ВРHTMLCJSF-1',5,5,220,'2025-05-01','2026-06-25'),(36,'UНОГ-1',9,9,80,'2025-05-01','2025-10-23'),(37,'ВРHTMLCJSF-2',5,9,204,'2025-04-01','2026-05-26'),(38,'ИИРП-2',6,3,180,'2025-04-01','2026-02-10'),(39,'CРРП-2',4,9,64,'2025-03-01','2025-09-27'),(40,'JSВРАЯ-1',1,8,0,'2024-10-01','2025-06-03'),(41,'JSВРАЯ-2',1,18,0,'2024-10-01','2025-06-03'),(42,'РИPP-1',7,19,20,'2025-04-01','2025-07-15'),(43,'СDИC-1',8,10,60,'2025-05-01','2025-09-18'),(44,'СDИC-2',8,16,42,'2025-04-01','2025-08-19'),(51,'КЗАР-1',37,26,118,'2025-07-01','2026-01-27'),(52,'-1',38,26,222,'2025-06-23','2026-07-20');
/*!40000 ALTER TABLE `группы` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `договоры`
--

DROP TABLE IF EXISTS `договоры`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `договоры` (
  `id_договора` int NOT NULL AUTO_INCREMENT,
  `номер_договора` int DEFAULT NULL,
  `id_заявки_на_обучение` int DEFAULT NULL,
  `дата_заключения` date DEFAULT NULL,
  `id_пользователя` int DEFAULT NULL,
  `сумма_к_оплате` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`id_договора`),
  KEY `fk_договоры_пользователи1_idx` (`id_пользователя`),
  KEY `fk_zayavka_idx` (`id_заявки_на_обучение`),
  CONSTRAINT `fk_zayavka` FOREIGN KEY (`id_заявки_на_обучение`) REFERENCES `заявка_на_обучение` (`id_заявки_на_обучение`),
  CONSTRAINT `fk_договоры_пользователи1` FOREIGN KEY (`id_пользователя`) REFERENCES `пользователи` (`id_пользователя`)
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `договоры`
--

LOCK TABLES `договоры` WRITE;
/*!40000 ALTER TABLE `договоры` DISABLE KEYS */;
INSERT INTO `договоры` VALUES (24,101,38,'2024-07-29',2,35000.11),(25,102,43,'2024-09-01',9,35000.11),(26,103,56,'2024-04-16',12,35000.11),(27,104,83,'2025-03-05',11,35000.11),(28,105,103,'2025-04-15',1,35000.11),(29,106,32,'2024-03-07',10,26700.12),(30,107,97,'2025-03-12',1,26700.12),(31,108,31,'2025-01-20',12,15000.00),(32,109,39,'2025-01-21',12,15000.00),(33,110,58,'2024-11-12',10,15000.00),(34,111,65,'2024-09-10',1,15000.00),(35,112,85,'2025-05-01',1,15000.00),(36,115,66,'2024-05-30',9,27500.00),(37,116,91,'2025-01-10',1,27500.00),(38,117,46,'2024-02-07',9,40000.00),(39,118,76,'2024-09-25',1,40000.00),(47,119,116,'2025-06-23',2,22000.00);
/*!40000 ALTER TABLE `договоры` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `заявка_на_обучение`
--

DROP TABLE IF EXISTS `заявка_на_обучение`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `заявка_на_обучение` (
  `id_заявки_на_обучение` int NOT NULL AUTO_INCREMENT,
  `id_обучающегося` int DEFAULT NULL,
  `id_курса` int DEFAULT NULL,
  `дата_заявки` date DEFAULT NULL,
  `id_статус` int DEFAULT NULL,
  `id_пользователя` int DEFAULT NULL,
  PRIMARY KEY (`id_заявки_на_обучение`),
  KEY `fk_заявка_на_курс_обучающиеся1_idx` (`id_обучающегося`),
  KEY `fk_заявка_на_курс_курсы1_idx` (`id_курса`),
  KEY `fk_заявка_на_курс_с_статусы1_idx` (`id_статус`),
  KEY `fk_заявка_на_курс_пользователи1_idx` (`id_пользователя`),
  CONSTRAINT `fk_заявка_на_курс_курсы1` FOREIGN KEY (`id_курса`) REFERENCES `курсы` (`id_курса`),
  CONSTRAINT `fk_заявка_на_курс_обучающиеся1` FOREIGN KEY (`id_обучающегося`) REFERENCES `обучающиеся` (`id_обучающегося`),
  CONSTRAINT `fk_заявка_на_обучение_обучающиеся1` FOREIGN KEY (`id_обучающегося`) REFERENCES `обучающиеся` (`id_обучающегося`),
  CONSTRAINT `fk_заявка_на_обучение_пользователи1` FOREIGN KEY (`id_пользователя`) REFERENCES `пользователи` (`id_пользователя`),
  CONSTRAINT `fk_заявка_на_обучение_с_статусы1` FOREIGN KEY (`id_статус`) REFERENCES `с_статусы` (`id_статуса`)
) ENGINE=InnoDB AUTO_INCREMENT=117 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `заявка_на_обучение`
--

LOCK TABLES `заявка_на_обучение` WRITE;
/*!40000 ALTER TABLE `заявка_на_обучение` DISABLE KEYS */;
INSERT INTO `заявка_на_обучение` VALUES (31,84,3,'2025-01-20',2,12),(32,70,2,'2024-03-07',2,10),(33,21,1,'2024-11-27',1,1),(34,22,6,'2024-02-27',2,10),(35,79,1,'2024-04-06',3,11),(36,82,5,'2024-09-14',3,1),(38,68,1,'2024-07-29',2,2),(39,21,3,'2025-01-21',2,12),(40,83,6,'2024-02-03',2,11),(41,66,3,'2024-07-23',1,1),(42,75,4,'2024-12-07',3,11),(43,46,1,'2024-09-01',2,9),(44,92,7,'2024-11-03',2,10),(45,93,10,'2024-09-06',3,11),(46,55,5,'2024-02-07',2,9),(47,64,9,'2025-04-22',2,10),(48,91,4,'2024-08-09',1,1),(49,78,5,'2024-10-05',1,10),(50,53,3,'2024-04-13',1,11),(51,90,7,'2024-11-29',1,9),(52,16,3,'2024-06-03',1,9),(53,45,7,'2025-03-22',1,9),(54,3,10,'2024-08-31',2,11),(55,63,10,'2024-12-22',1,12),(56,17,1,'2024-04-16',2,12),(57,21,9,'2025-02-06',1,11),(58,86,3,'2024-11-12',2,10),(59,94,3,'2024-02-28',3,12),(60,44,7,'2025-04-06',1,12),(61,18,10,'2025-02-10',3,12),(62,48,9,'2024-09-21',3,9),(63,79,5,'2024-01-24',3,9),(64,84,1,'2024-10-23',1,9),(65,73,3,'2024-09-10',2,1),(66,1,4,'2024-05-30',2,9),(67,80,10,'2024-07-22',2,1),(68,17,5,'2025-04-19',3,2),(69,82,4,'2024-03-25',1,1),(70,50,7,'2024-03-03',3,10),(71,3,4,'2024-07-16',3,9),(72,3,7,'2024-11-20',3,9),(73,15,8,'2024-07-12',3,1),(74,68,4,'2024-09-30',3,11),(75,5,7,'2024-10-20',1,2),(76,58,5,'2024-09-25',2,1),(77,54,6,'2024-03-11',3,10),(78,47,6,'2025-01-01',1,11),(79,91,7,'2024-09-19',2,12),(80,21,9,'2025-01-02',2,11),(81,13,4,'2025-01-15',1,9),(82,42,7,'2025-02-20',3,10),(83,22,1,'2025-03-05',2,11),(84,96,10,'2025-04-10',1,12),(85,5,3,'2025-05-01',2,1),(86,18,6,'2025-01-25',3,2),(87,44,2,'2025-03-15',1,9),(88,70,5,'2025-04-22',2,10),(89,21,8,'2025-05-05',3,11),(90,53,9,'2025-02-28',1,12),(91,15,4,'2025-01-10',2,1),(92,84,7,'2025-03-30',3,2),(93,91,1,'2025-04-18',1,9),(94,63,6,'2025-05-04',2,10),(95,3,3,'2025-02-14',3,11),(96,22,10,'2025-01-22',1,12),(97,42,2,'2025-03-12',2,1),(98,13,5,'2025-04-25',3,2),(99,79,8,'2025-05-03',1,9),(100,18,9,'2025-02-07',2,10),(101,44,4,'2025-01-28',3,11),(102,70,7,'2025-03-22',1,12),(103,21,1,'2025-04-15',2,1),(104,53,6,'2025-05-02',3,2),(105,15,3,'2025-02-19',1,9),(106,84,10,'2025-01-18',2,10),(107,91,2,'2025-03-28',3,11),(108,63,5,'2025-04-20',1,12),(109,3,8,'2025-05-01',2,1),(116,101,37,'2025-06-23',2,2);
/*!40000 ALTER TABLE `заявка_на_обучение` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `кабинеты`
--

DROP TABLE IF EXISTS `кабинеты`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `кабинеты` (
  `id_кабинета` int NOT NULL AUTO_INCREMENT,
  `номер_кабинета` int DEFAULT NULL,
  `id_тип_кабинета` int DEFAULT NULL,
  PRIMARY KEY (`id_кабинета`),
  KEY `fk_кабинеты_с_тип_кабинета_idx` (`id_тип_кабинета`),
  CONSTRAINT `fk_кабинеты_с_тип_кабинета1` FOREIGN KEY (`id_тип_кабинета`) REFERENCES `с_тип_кабинета` (`id_тип_кабинета`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `кабинеты`
--

LOCK TABLES `кабинеты` WRITE;
/*!40000 ALTER TABLE `кабинеты` DISABLE KEYS */;
INSERT INTO `кабинеты` VALUES (2,201,2),(3,200,1),(5,202,2),(10,203,2),(11,204,2),(12,205,1);
/*!40000 ALTER TABLE `кабинеты` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `курсы`
--

DROP TABLE IF EXISTS `курсы`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `курсы` (
  `id_курса` int NOT NULL AUTO_INCREMENT,
  `изображение` varchar(1000) DEFAULT NULL,
  `название` varchar(200) DEFAULT NULL,
  `длительность_ч` int DEFAULT NULL,
  PRIMARY KEY (`id_курса`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `курсы`
--

LOCK TABLES `курсы` WRITE;
/*!40000 ALTER TABLE `курсы` DISABLE KEYS */;
INSERT INTO `курсы` VALUES (1,'Pics/programmer.png','JavaScript: Веб-Разработка от А до Я',140),(2,'Pics/programmer2.png','Java: Основы и Приложения',120),(3,'Pics/programmer3.png','Python для Начинающих: От Основ до Проектов',100),(4,'Pics/programmer4.png','C#: Руководство по Разработке Приложений',120),(5,'Pics/programmer5.png','Веб-Разработка на HTML, CSS и JavaScript: Fullstack',240),(6,'Pics/programmer6.png','Искусственный Интеллект в Реальных Проектах',180),(7,'Pics/programmer7.png','Разработка Игр на Python с Pygame',60),(8,'Pics/programmer8.png','Создание 2D Игр на C#',80),(9,'Pics/programmer5.png','Unity для Начинающих: Основы Геймдева',100),(10,'Pics/programmer10.png','Сетевые Технологии: Управление и Безопасность',140),(37,'Pics/programmer3.png','Кибербезопасность: Защита, Анализ и Реагирование',120),(38,'','джава питон веб',222);
/*!40000 ALTER TABLE `курсы` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `обучающиеся`
--

DROP TABLE IF EXISTS `обучающиеся`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `обучающиеся` (
  `id_обучающегося` int NOT NULL AUTO_INCREMENT,
  `фамилия` varchar(45) DEFAULT NULL,
  `имя` varchar(45) DEFAULT NULL,
  `отчество` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `телефон` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_обучающегося`)
) ENGINE=InnoDB AUTO_INCREMENT=102 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `обучающиеся`
--

LOCK TABLES `обучающиеся` WRITE;
/*!40000 ALTER TABLE `обучающиеся` DISABLE KEYS */;
INSERT INTO `обучающиеся` VALUES (1,'Спиридонов','Максим','Егорович','spiridonov1337@gmail.com','+7 (960) 260-55-22'),(2,'Сиванцов','Андрей','Игоревич','sivancov@ya.ru','+7 (921) 301-17-22'),(3,'Горячев','Артур','Игоревич','goryachev@mail.ru','+7 (921) 155-34-90'),(5,'Райхерт','Тихон','Евгеньевич','tikhon@gmail.com','+7 (960) 028-67-52'),(13,'Волков','Семён','Алексеевич','volkov.sa@gmail.com','+7 (960) 260-55-22'),(14,'Богданова','Таисия','Марковна','bogdanova.tm@gmail.com','+7 (960) 260-55-23'),(15,'Жукова','Ксения','Гордеевна','zhukova.kg@gmail.com','+7 (960) 260-55-24'),(16,'Степанова','Алиса','Романовна','stepanova.ar@gmail.com','+7 (960) 260-55-25'),(17,'Платонова','Виктория','Леонидовна','platonova.vl@gmail.com','+7 (960) 260-55-26'),(18,'Грачев','Максим','Георгиевич','grachev.mg@gmail.com','+7 (960) 260-55-27'),(19,'Егоров','Алексей','Иванович','egorov.ai@gmail.com','+7 (960) 260-55-28'),(20,'Иванов','Даниэль','Матвеевич','ivanov.dm@gmail.com','+7 (960) 260-55-29'),(21,'Савина','Екатерина','Дмитриевна','savina.ed@gmail.com','+7 (960) 260-55-30'),(22,'Калинина','Софья','Владиславовна','kalinina.sv@gmail.com','+7 (960) 260-55-31'),(42,'Иванов','Алексей','Петрович','ivanov.a23@gmail.com','+7 (912) 345-67-23'),(43,'Петрова','Марина','Викторовна','petrova.m24@mail.ru','+7 (913) 456-78-24'),(44,'Сидоров','Дмитрий','Алексеевич','sidorov.d25@yandex.ru','+7 (914) 567-89-25'),(45,'Кузнецова','Елена','Игоревна','kuznetsova.e26@gmail.com','+7 (915) 678-90-26'),(46,'Морозов','Николай','Владимирович','morozov.n27@mail.ru','+7 (916) 789-01-27'),(47,'Новикова','Ольга','Сергеевна','novikova.o28@yandex.ru','+7 (917) 890-12-28'),(48,'Федоров','Виктор','Анатольевич','fedorov.v29@gmail.com','+7 (918) 901-23-29'),(49,'Соколова','Татьяна','Юрьевна','sokolova.t30@mail.ru','+7 (919) 012-34-30'),(50,'Васильев','Иван','Михайлович','vasiliev.i31@yandex.ru','+7 (920) 123-45-31'),(51,'Михайлова','Анна','Павловна','mikhailova.a32@gmail.com','+7 (921) 234-56-32'),(52,'Козлов','Андрей','Владимирович','kozlov.a33@gmail.com','+7 (922) 345-67-33'),(53,'Смирнова','Екатерина','Александровна','smirnova.e34@mail.ru','+7 (923) 456-78-34'),(54,'Воробьев','Максим','Игоревич','vorobiev.m35@yandex.ru','+7 (924) 567-89-35'),(55,'Зайцева','Ольга','Николаевна','zaitseva.o36@gmail.com','+7 (925) 678-90-36'),(56,'Мельников','Денис','Петрович','melnikov.d37@mail.ru','+7 (926) 789-01-37'),(57,'Лебедева','Анна','Викторовна','lebedeva.a38@yandex.ru','+7 (927) 890-12-38'),(58,'Тихонов','Илья','Сергеевич','tikhonov.i39@gmail.com','+7 (928) 901-23-39'),(59,'Фролова','Мария','Андреевна','frolova.m40@mail.ru','+7 (929) 012-34-40'),(60,'Никитин','Роман','Вячеславович','nikitin.r41@yandex.ru','+7 (930) 123-45-41'),(61,'Крылова','Юлия','Дмитриевна','krylova.y42@gmail.com','+7 (931) 234-56-42'),(62,'Гусев','Владимир','Алексеевич','gusev.v43@mail.ru','+7 (932) 345-67-43'),(63,'Соколова','Нина','Павловна','sokolova.n44@yandex.ru','+7 (933) 456-78-44'),(64,'Белов','Константин','Юрьевич','belov.k45@gmail.com','+7 (934) 567-89-45'),(65,'Зайцева','Елена','Владимировна','zaitseva.e46@mail.ru','+7 (935) 678-90-46'),(66,'Орлов','Артём','Михайлович','orlov.a47@yandex.ru','+7 (936) 789-01-47'),(67,'Фролов','Денис','Вячеславович','frolova.d48@gmail.com','+7 (929) 304-15-48'),(68,'Зайцев','Игорь','Ильинич','zaitseva.i49@yandex.ru','+7 (917) 681-69-49'),(69,'Чернов','Виктор','Вячеславович','chernov.v50@yandex.ru','+7 (934) 238-30-50'),(70,'Данилов','Сергей','Павлович','danilova.s51@gmail.com','+7 (938) 812-58-51'),(71,'Панфилов','Виктор','Юрьевич','panfilov.v52@mail.ru','+7 (934) 423-82-52'),(72,'Зайцева','Галина','Петровна','zaitseva.g53@mail.ru','+7 (918) 808-46-53'),(73,'Романова','Ольга','Алексеевна','romanova.o54@mail.ru','+7 (935) 761-25-54'),(74,'Никитин','Дмитрий','Александрович','nikitin.d55@mail.ru','+7 (912) 984-13-55'),(75,'Козлова','Татьяна','Юрьевна','kozlov.t56@gmail.com','+7 (932) 107-34-56'),(76,'Козлов','Илья','Вячеславович','kozlov.i57@yandex.ru','+7 (912) 821-94-57'),(77,'Тихонов','Олег','Михайлович','tikhonov.o58@yandex.ru','+7 (915) 221-44-58'),(78,'Шестакова','Ольга','Андреевна','shestakova.o59@mail.ru','+7 (918) 896-41-59'),(79,'Ершова','Екатерина','Юрьевна','ershov.e60@gmail.com','+7 (920) 289-15-60'),(80,'Савельев','Татьяна','Владимировна','savelev.t61@gmail.com','+7 (951) 349-12-61'),(81,'Соколова','Нина','Александровна','sokolova.n62@mail.ru','+7 (917) 529-22-62'),(82,'Киселев','Игорь','Владимирович','kiseleva.i63@mail.ru','+7 (935) 243-90-63'),(83,'Шестаков','Роман','Михайлович','shestakova.r64@mail.ru','+7 (931) 792-71-64'),(84,'Киселев','Виктор','Петрович','kiseleva.v65@mail.ru','+7 (932) 500-59-65'),(85,'Щербаков','Олег','Александрович','shcherbakov.o66@mail.ru','+7 (928) 101-20-66'),(86,'Фролова','Татьяна','Александровна','frolova.t67@gmail.com','+7 (931) 642-68-67'),(87,'Панфилова','Екатерина','Юрьевна','panfilov.e68@mail.ru','+7 (921) 560-66-68'),(88,'Федорова','Елена','Вячеславовна','fedorova.e69@mail.ru','+7 (929) 604-72-69'),(89,'Николаев','Дмитрий','Викторович','nikolaeva.d70@mail.ru','+7 (939) 590-79-70'),(90,'Павлов','Павел','Павлович','pavlov.p71@gmail.com','+7 (935) 184-97-71'),(91,'Зайцева','Анна','Владимировна','zaitseva.a72@mail.ru','+7 (912) 635-72-72'),(92,'Козлов','Виктор','Александрович','kozlov.v73@gmail.com','+7 (918) 924-80-73'),(93,'Киселева','Ирина','Викторовна','kiseleva.i74@gmail.com','+7 (935) 486-68-74'),(94,'Козлов','Павел','Сергеевич','kozlov.p75@yandex.ru','+7 (934) 274-53-75'),(95,'Николаев','Дмитрий','Владимирович','nikolaeva.d76@yandex.ru','+7 (936) 356-47-76'),(96,'Романов','Андрей','Владимирович','romanova.a77@gmail.com','+7 (915) 393-97-77'),(101,'Шнуров','Макар','Андреевич','makar1337@gmail.com','+7 (960) 133-44-93');
/*!40000 ALTER TABLE `обучающиеся` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `обучающиеся_в_группе`
--

DROP TABLE IF EXISTS `обучающиеся_в_группе`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `обучающиеся_в_группе` (
  `id_свг` int NOT NULL AUTO_INCREMENT,
  `id_группы` int DEFAULT NULL,
  `id_обучающегося` int DEFAULT NULL,
  PRIMARY KEY (`id_свг`),
  KEY `fk_студенты_в_группе_группы1_idx` (`id_группы`),
  KEY `fk_студенты_в_группе_обучающиеся1_idx` (`id_обучающегося`),
  CONSTRAINT `fk_обучающиеся_в_группе_группы1` FOREIGN KEY (`id_группы`) REFERENCES `группы` (`id_группы`),
  CONSTRAINT `fk_обучающиеся_в_группе_обучающие1` FOREIGN KEY (`id_обучающегося`) REFERENCES `обучающиеся` (`id_обучающегося`)
) ENGINE=InnoDB AUTO_INCREMENT=282 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `обучающиеся_в_группе`
--

LOCK TABLES `обучающиеся_в_группе` WRITE;
/*!40000 ALTER TABLE `обучающиеся_в_группе` DISABLE KEYS */;
INSERT INTO `обучающиеся_в_группе` VALUES (75,19,21),(76,19,22),(77,20,5),(78,20,1),(79,20,2),(80,20,3),(85,20,17),(90,18,13),(91,18,14),(92,18,15),(93,18,16),(94,18,20),(95,18,61),(96,18,62),(97,18,63),(98,18,57),(99,18,56),(100,18,54),(101,18,53),(102,19,92),(103,19,91),(104,19,90),(105,19,89),(106,19,88),(107,19,87),(108,19,86),(109,19,85),(110,20,59),(111,20,60),(112,20,63),(113,29,1),(114,29,2),(115,29,3),(116,29,5),(117,29,13),(118,29,14),(119,29,15),(120,29,16),(121,29,17),(122,30,73),(123,30,74),(124,30,72),(125,30,71),(126,30,70),(127,30,69),(128,30,68),(129,30,67),(130,30,79),(131,30,78),(132,30,77),(133,32,96),(134,32,95),(135,32,94),(136,32,93),(137,32,92),(138,32,91),(139,32,90),(140,32,89),(141,32,88),(142,32,87),(143,32,86),(144,33,51),(145,33,52),(146,33,53),(147,33,54),(148,33,55),(149,33,56),(150,33,57),(151,33,58),(152,33,49),(153,33,48),(154,34,84),(155,34,85),(156,34,86),(157,34,87),(158,34,83),(159,34,82),(160,34,81),(161,34,80),(162,34,79),(163,34,78),(164,34,77),(165,43,1),(167,35,86),(168,35,87),(169,35,88),(170,35,89),(171,35,90),(172,35,91),(173,35,83),(174,35,82),(175,35,81),(176,35,80),(177,35,84),(178,36,84),(179,36,83),(180,36,69),(181,36,68),(182,36,67),(183,36,66),(184,36,65),(185,36,64),(186,36,63),(187,36,73),(188,36,71),(189,37,90),(190,37,89),(191,37,88),(192,37,87),(193,37,86),(194,37,85),(195,37,84),(196,37,83),(197,37,82),(198,37,81),(199,37,80),(200,37,79),(201,38,1),(202,38,2),(203,38,3),(204,38,5),(205,38,13),(206,38,14),(207,38,15),(208,38,16),(209,38,17),(210,38,18),(211,38,19),(212,38,20),(213,39,56),(214,39,57),(215,39,58),(216,39,59),(217,39,60),(218,39,54),(219,39,55),(220,39,52),(221,39,63),(222,39,62),(223,39,61),(224,40,83),(225,40,82),(226,40,81),(227,40,67),(228,40,66),(229,40,65),(230,40,64),(231,40,73),(232,40,71),(233,40,69),(234,41,91),(235,41,86),(236,41,58),(237,41,55),(238,41,63),(239,41,19),(240,41,22),(241,41,17),(242,41,2),(243,41,5),(244,42,61),(245,42,60),(246,42,59),(247,42,57),(248,42,56),(249,42,54),(250,42,75),(251,42,74),(252,42,70),(253,42,68),(254,42,62),(255,43,89),(256,43,90),(257,43,88),(258,43,87),(259,43,84),(260,43,80),(261,43,79),(262,43,94),(263,43,93),(264,44,51),(265,44,50),(266,44,52),(267,44,53),(268,44,54),(269,44,56),(270,44,57),(271,44,59),(272,44,60),(273,44,49),(274,44,47),(281,51,101);
/*!40000 ALTER TABLE `обучающиеся_в_группе` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `по_в_кабинете`
--

DROP TABLE IF EXISTS `по_в_кабинете`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `по_в_кабинете` (
  `id_пвк` int NOT NULL AUTO_INCREMENT,
  `id_кабинета` int DEFAULT NULL,
  `id_по` int DEFAULT NULL,
  PRIMARY KEY (`id_пвк`),
  KEY `fk_по_в_кабинете_программное_обес_idx` (`id_по`),
  KEY `fk_по_в_кабинете_кабинеты1_idx` (`id_кабинета`),
  CONSTRAINT `fk_по_в_кабинете_кабинеты1` FOREIGN KEY (`id_кабинета`) REFERENCES `кабинеты` (`id_кабинета`),
  CONSTRAINT `fk_по_в_кабинете_программное_обесп1` FOREIGN KEY (`id_по`) REFERENCES `программное_обеспечение` (`id_по`)
) ENGINE=InnoDB AUTO_INCREMENT=92 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `по_в_кабинете`
--

LOCK TABLES `по_в_кабинете` WRITE;
/*!40000 ALTER TABLE `по_в_кабинете` DISABLE KEYS */;
INSERT INTO `по_в_кабинете` VALUES (16,3,1),(17,3,2),(18,3,3),(19,3,4),(20,3,5),(21,3,6),(22,3,7),(23,3,8),(24,3,9),(25,3,10),(26,3,14),(27,3,15),(28,3,16),(29,3,17),(30,3,18),(31,2,9),(32,5,9),(33,2,1),(34,2,2),(35,2,3),(36,2,4),(37,2,5),(38,5,6),(39,2,7),(40,5,8),(41,5,10),(42,5,14),(43,5,15),(44,5,16),(45,5,17),(46,2,18),(47,5,1),(48,10,9),(49,10,1),(50,10,2),(51,10,3),(52,10,4),(53,10,5),(54,10,7),(55,10,18),(56,11,1),(57,11,2),(58,11,3),(59,11,4),(60,11,5),(61,11,6),(62,11,7),(63,11,8),(64,11,9),(65,11,10),(66,11,14),(67,11,15),(68,11,16),(69,11,17),(70,11,18),(71,12,1),(72,12,2),(73,12,3),(74,12,4),(75,12,5),(76,12,6),(77,12,7),(78,12,8),(79,12,9),(80,12,10),(81,12,14),(82,12,15),(83,12,16),(84,12,17),(85,12,18),(86,2,19),(87,2,20),(88,2,21),(89,3,19),(90,3,20),(91,3,21);
/*!40000 ALTER TABLE `по_в_кабинете` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `по_для_курса`
--

DROP TABLE IF EXISTS `по_для_курса`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `по_для_курса` (
  `id_пдк` int NOT NULL AUTO_INCREMENT,
  `id_курса` int DEFAULT NULL,
  `id_по` int DEFAULT NULL,
  PRIMARY KEY (`id_пдк`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `по_для_курса`
--

LOCK TABLES `по_для_курса` WRITE;
/*!40000 ALTER TABLE `по_для_курса` DISABLE KEYS */;
INSERT INTO `по_для_курса` VALUES (1,1,1),(2,1,2),(3,1,3),(4,1,4),(5,1,5),(6,2,6),(7,3,7),(8,4,8),(9,5,1),(10,5,4),(11,5,9),(12,6,10),(13,6,14),(14,6,1),(15,7,7),(16,8,15),(17,8,16),(18,8,17),(19,9,15),(20,9,16),(21,9,17),(22,10,18),(39,37,19),(40,37,20),(41,37,21);
/*!40000 ALTER TABLE `по_для_курса` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `пользователи`
--

DROP TABLE IF EXISTS `пользователи`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `пользователи` (
  `id_пользователя` int NOT NULL AUTO_INCREMENT,
  `id_роли` int DEFAULT NULL,
  `фамилия` varchar(45) DEFAULT NULL,
  `имя` varchar(45) DEFAULT NULL,
  `отчество` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `телефон` varchar(45) DEFAULT NULL,
  `логин` varchar(45) DEFAULT NULL,
  `пароль` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_пользователя`),
  KEY `fk_пользователи_с_роли1_idx` (`id_роли`),
  CONSTRAINT `fk_пользователи_с_роли1` FOREIGN KEY (`id_роли`) REFERENCES `с_роли` (`id_роли`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `пользователи`
--

LOCK TABLES `пользователи` WRITE;
/*!40000 ALTER TABLE `пользователи` DISABLE KEYS */;
INSERT INTO `пользователи` VALUES (1,1,'Соколов','Семён','Никитич','sokolov@gmail.com','+7 (960) 310-87-22','sokolov_head','254de42a1fdf790c3fa82037b2c3e535'),(2,2,'Попова','Алеся','Фёдоровна','popova@ya.ru','+7 (921) 801-54-66','2','c81e728d9d4c2f636f067f89cc14862c'),(9,2,'Митрофанова','Александра','Михайловна','mitro@ya.ru','+7 (960) 901-55-45','3','eccbc87e4b5ce2fe28308fd9f2a7baf3'),(10,2,'Ермаков','Дмитрий','Матвеевич','ermak97@gmail.com','+7 (930) 137-11-90','4','a87ff679a2f3e71d9181a67b7542122c'),(11,2,'Сычева','Диана','Кирилловна','sicheva@bk.ru','+7 (960) 303-45-34','5','e4da3b7fbbce2345d7772b0674a318d5'),(12,2,'Иванова','Вера','Артемьевна','ivanova@gmail.com','+7 (960) 290-68-33','6','1679091c5a880faf6fb5e6087eb1b2dc');
/*!40000 ALTER TABLE `пользователи` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `прайс`
--

DROP TABLE IF EXISTS `прайс`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `прайс` (
  `id_прайс` int NOT NULL AUTO_INCREMENT,
  `id_курса` int DEFAULT NULL,
  `прайс_руб` decimal(10,2) DEFAULT NULL,
  `дата_установки_прайса` date DEFAULT NULL,
  PRIMARY KEY (`id_прайс`),
  KEY `fk_с_прайс_курсы1_idx` (`id_курса`),
  CONSTRAINT `fk_прайс_курсы1` FOREIGN KEY (`id_курса`) REFERENCES `курсы` (`id_курса`),
  CONSTRAINT `fk_с_прайс_курсы1` FOREIGN KEY (`id_курса`) REFERENCES `курсы` (`id_курса`)
) ENGINE=InnoDB AUTO_INCREMENT=62 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `прайс`
--

LOCK TABLES `прайс` WRITE;
/*!40000 ALTER TABLE `прайс` DISABLE KEYS */;
INSERT INTO `прайс` VALUES (1,1,35000.00,'2025-03-24'),(3,8,99990.00,'2025-04-11'),(4,4,27500.00,'2025-04-03'),(5,5,40000.00,'2025-04-03'),(6,6,60000.00,'2025-04-03'),(7,7,20000.00,'2025-04-03'),(8,8,24000.00,'2025-04-03'),(9,9,35000.00,'2025-04-03'),(16,10,39000.00,'2025-04-03'),(22,3,15000.00,'2025-04-03'),(23,7,22000.00,'2025-04-04'),(24,6,63378.00,'2025-04-04'),(28,8,37338.00,'2025-04-12'),(29,2,13337.99,'2025-04-12'),(30,10,44344.00,'2025-04-12'),(34,10,44670.00,'2025-04-12'),(45,9,35000.00,'2025-04-15'),(46,9,35000.11,'2025-04-15'),(50,1,35000.11,'2025-05-07'),(51,2,26700.12,'2025-05-18'),(58,2,25000.00,'2025-06-23'),(60,37,22000.00,'2025-06-23'),(61,38,222.00,'2025-06-23');
/*!40000 ALTER TABLE `прайс` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `преподаватели`
--

DROP TABLE IF EXISTS `преподаватели`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `преподаватели` (
  `id_преподавателя` int NOT NULL AUTO_INCREMENT,
  `фамилия` varchar(45) DEFAULT NULL,
  `имя` varchar(45) DEFAULT NULL,
  `отчество` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `телефон` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_преподавателя`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `преподаватели`
--

LOCK TABLES `преподаватели` WRITE;
/*!40000 ALTER TABLE `преподаватели` DISABLE KEYS */;
INSERT INTO `преподаватели` VALUES (1,'Зуев','Роман','Демидович','zuev@gmail.com','+7 (960) 301-15-22'),(2,'Дмитриев','Арсений','Максимович','dmitriev@ya.ru','+7 (921) 260-59-10'),(3,'Воронин','Георгий','Дмитриевич','voronin@mail.ru','+7 (900) 130-55-02'),(4,'Васильев','Георгий','Артемович','vasiliev@gmail.com','+7 (921) 264-30-00'),(5,'Гуров','Егор','Тимофеевич','gurov@ya.ru','+7 (930) 130-40-22'),(6,'Серов','Дмитрий','Владимирович','serov@bk.ru','+7 (921) 001-51-92'),(7,'Скворцов','Лев','Даниилович','skvorcov@mail.ru','+7 (921) 228-99-88'),(8,'Никитин','Федор','Иванович','nikitin@yandex.ru','+7 (960) 908-31-18'),(9,'Сафонов','Максим','Дмитриевич','mask_saint@mail.ru','+7 (903) 103-03-30'),(10,'Щукин','Владислав','Тимофеевич','shukin@ya.ru','+7 (918) 111-20-22'),(16,'Васильев','Дмитрий','Анатольевич','vasiliev@ya.ru','+7 (918) 666-77-88'),(17,'Морозова','Ольга','Николаевна','morozova@ya.ru','+7 (918) 777-88-99'),(18,'Зайцев','Константин','Владимирович','zaitsev@ya.ru','+7 (918) 888-99-00'),(19,'Соколова','Екатерина','Павловна','sokolova@ya.ru','+7 (918) 999-00-11'),(20,'Григорьев','Андрей','Юрьевич','grigoryev@ya.ru','+7 (918) 000-11-22'),(26,'Краснов','Александр','Иванович','krasnov@bk.ru','+7 (921) 209-20-19');
/*!40000 ALTER TABLE `преподаватели` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `преподаватели_курсы`
--

DROP TABLE IF EXISTS `преподаватели_курсы`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `преподаватели_курсы` (
  `id_пк` int NOT NULL AUTO_INCREMENT,
  `id_преподавателя` int DEFAULT NULL,
  `id_курса` int DEFAULT NULL,
  PRIMARY KEY (`id_пк`),
  KEY `fk_teach_idx` (`id_преподавателя`),
  KEY `fk_kurss_idx` (`id_курса`),
  CONSTRAINT `fk_kurss` FOREIGN KEY (`id_курса`) REFERENCES `курсы` (`id_курса`),
  CONSTRAINT `fk_teach` FOREIGN KEY (`id_преподавателя`) REFERENCES `преподаватели` (`id_преподавателя`)
) ENGINE=InnoDB AUTO_INCREMENT=67 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `преподаватели_курсы`
--

LOCK TABLES `преподаватели_курсы` WRITE;
/*!40000 ALTER TABLE `преподаватели_курсы` DISABLE KEYS */;
INSERT INTO `преподаватели_курсы` VALUES (2,2,2),(4,4,4),(5,5,5),(6,6,6),(7,7,7),(8,8,8),(9,9,9),(10,10,10),(24,1,1),(25,1,2),(26,1,3),(27,2,10),(28,2,1),(29,2,5),(30,3,7),(31,3,6),(32,3,4),(33,9,6),(34,9,5),(35,9,4),(36,10,8),(37,10,3),(38,10,5),(39,8,1),(40,8,3),(44,1,10),(45,16,5),(46,16,6),(47,16,7),(48,16,8),(49,17,10),(50,18,1),(51,18,3),(52,18,5),(53,18,10),(54,19,6),(55,19,7),(56,20,3),(57,20,4),(58,20,6),(59,20,7),(65,26,37),(66,26,38);
/*!40000 ALTER TABLE `преподаватели_курсы` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `программное_обеспечение`
--

DROP TABLE IF EXISTS `программное_обеспечение`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `программное_обеспечение` (
  `id_по` int NOT NULL AUTO_INCREMENT,
  `по` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id_по`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `программное_обеспечение`
--

LOCK TABLES `программное_обеспечение` WRITE;
/*!40000 ALTER TABLE `программное_обеспечение` DISABLE KEYS */;
INSERT INTO `программное_обеспечение` VALUES (1,'Visual Studio Code'),(2,'React.js'),(3,'Backbone.js'),(4,'Node.js'),(5,'CodePen'),(6,'Eclipse'),(7,'PyCharm Community Edition'),(8,'Visual Studio Community'),(9,'Google Chrome'),(10,'PyTorch'),(14,'OpenCV'),(15,'Unity Hub'),(16,'Unity Editor'),(17,'Adobe Photoshop '),(18,'VirtualBox'),(19,'NMap'),(20,'OSSEC'),(21,'Teramind');
/*!40000 ALTER TABLE `программное_обеспечение` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `продажи`
--

DROP TABLE IF EXISTS `продажи`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `продажи` (
  `id_продажи` int NOT NULL AUTO_INCREMENT,
  `id_курса` int DEFAULT NULL,
  `стоимость` decimal(10,2) DEFAULT NULL,
  `дата_продажи` date DEFAULT NULL,
  PRIMARY KEY (`id_продажи`),
  KEY `fk_продажи_курсы1_idx` (`id_курса`),
  CONSTRAINT `fk_продажи_курсы1` FOREIGN KEY (`id_курса`) REFERENCES `курсы` (`id_курса`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `продажи`
--

LOCK TABLES `продажи` WRITE;
/*!40000 ALTER TABLE `продажи` DISABLE KEYS */;
INSERT INTO `продажи` VALUES (1,10,40000.00,'2025-04-03'),(2,6,60000.00,'2025-04-03'),(3,5,40000.00,'2025-04-05'),(4,10,100.00,'2025-04-12'),(7,10,32555.00,'2025-04-12'),(9,3,36226.00,'2025-04-12'),(10,8,99990.00,'2025-04-12'),(11,6,500.22,'2025-04-15'),(12,1,35000.00,'2025-05-08'),(13,7,20000.00,'2025-06-05'),(14,1,35000.11,'2024-07-29'),(15,1,35000.11,'2024-09-01'),(16,1,35000.11,'2024-04-16'),(17,1,35000.11,'2025-04-15'),(18,2,26700.12,'2024-03-07'),(19,2,26700.12,'2025-03-12'),(20,3,15000.00,'2025-01-20'),(21,3,15000.00,'2025-01-21'),(22,3,15000.00,'2024-11-12'),(23,3,15000.00,'2024-09-10'),(24,3,15000.00,'2025-05-01'),(25,4,27500.00,'2024-05-30'),(26,4,27500.00,'2025-01-10'),(27,5,40000.00,'2024-02-07'),(28,5,40000.00,'2024-09-25'),(29,9,35000.00,'2025-06-06'),(30,3,15000.00,'2025-06-15'),(36,37,22000.00,'2025-06-23');
/*!40000 ALTER TABLE `продажи` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `расписание`
--

DROP TABLE IF EXISTS `расписание`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `расписание` (
  `id_расписание` int NOT NULL AUTO_INCREMENT,
  `id_группы` int DEFAULT NULL,
  `id_кабинета` int DEFAULT NULL,
  `дата_время_занятия` datetime DEFAULT NULL,
  PRIMARY KEY (`id_расписание`),
  KEY `fk_расписание_кабинеты1_idx` (`id_кабинета`),
  KEY `fk_расписание_группы1_idx` (`id_группы`),
  CONSTRAINT `fk_расписание_группы1` FOREIGN KEY (`id_группы`) REFERENCES `группы` (`id_группы`),
  CONSTRAINT `fk_расписание_кабинеты1` FOREIGN KEY (`id_кабинета`) REFERENCES `кабинеты` (`id_кабинета`)
) ENGINE=InnoDB AUTO_INCREMENT=103 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `расписание`
--

LOCK TABLES `расписание` WRITE;
/*!40000 ALTER TABLE `расписание` DISABLE KEYS */;
INSERT INTO `расписание` VALUES (75,18,2,'2025-06-09 18:00:00'),(76,18,2,'2025-06-09 20:00:00'),(77,19,3,'2025-06-09 18:00:00'),(78,19,3,'2025-06-09 20:00:00'),(79,20,5,'2025-06-09 18:00:00'),(80,20,5,'2025-06-09 20:00:00'),(81,29,10,'2025-06-09 18:00:00'),(82,29,10,'2025-06-09 20:00:00'),(83,30,11,'2025-06-09 18:00:00'),(84,30,11,'2025-06-09 20:00:00'),(85,18,2,'2025-06-16 18:00:00'),(86,18,2,'2025-06-16 20:00:00'),(87,19,3,'2025-06-16 18:00:00'),(88,19,3,'2025-06-16 20:00:00'),(89,20,5,'2025-06-16 18:00:00'),(90,20,5,'2025-06-16 20:00:00'),(91,29,10,'2025-06-16 18:00:00'),(92,29,10,'2025-06-16 20:00:00'),(93,30,11,'2025-06-16 18:00:00'),(94,30,11,'2025-06-16 20:00:00'),(95,18,2,'2025-06-23 18:00:00'),(96,18,2,'2025-06-23 20:00:00'),(102,51,2,'2025-06-24 18:00:00');
/*!40000 ALTER TABLE `расписание` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `с_роли`
--

DROP TABLE IF EXISTS `с_роли`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `с_роли` (
  `id_роли` int NOT NULL AUTO_INCREMENT,
  `роль` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_роли`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `с_роли`
--

LOCK TABLES `с_роли` WRITE;
/*!40000 ALTER TABLE `с_роли` DISABLE KEYS */;
INSERT INTO `с_роли` VALUES (1,'Управляющий'),(2,'Менеджер продаж');
/*!40000 ALTER TABLE `с_роли` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `с_статусы`
--

DROP TABLE IF EXISTS `с_статусы`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `с_статусы` (
  `id_статуса` int NOT NULL AUTO_INCREMENT,
  `статус` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_статуса`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `с_статусы`
--

LOCK TABLES `с_статусы` WRITE;
/*!40000 ALTER TABLE `с_статусы` DISABLE KEYS */;
INSERT INTO `с_статусы` VALUES (1,'Новая'),(2,'Одобрена'),(3,'Отклонена');
/*!40000 ALTER TABLE `с_статусы` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `с_тип_кабинета`
--

DROP TABLE IF EXISTS `с_тип_кабинета`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `с_тип_кабинета` (
  `id_тип_кабинета` int NOT NULL AUTO_INCREMENT,
  `тип_кабинета` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_тип_кабинета`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `с_тип_кабинета`
--

LOCK TABLES `с_тип_кабинета` WRITE;
/*!40000 ALTER TABLE `с_тип_кабинета` DISABLE KEYS */;
INSERT INTO `с_тип_кабинета` VALUES (1,'Конференц-зал'),(2,'Компьютерный класс');
/*!40000 ALTER TABLE `с_тип_кабинета` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `сертификаты`
--

DROP TABLE IF EXISTS `сертификаты`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `сертификаты` (
  `id_сертификата` int NOT NULL AUTO_INCREMENT,
  `id_обучающегося` int DEFAULT NULL,
  `id_курса` int DEFAULT NULL,
  `дата_выдачи` date DEFAULT NULL,
  PRIMARY KEY (`id_сертификата`),
  KEY `fk_сертификаты_обучающиеся1_idx` (`id_обучающегося`),
  KEY `fk_сертификаты_курсы1_idx` (`id_курса`),
  CONSTRAINT `fk_сертификаты_курсы1` FOREIGN KEY (`id_курса`) REFERENCES `курсы` (`id_курса`),
  CONSTRAINT `fk_сертификаты_обучающиеся1` FOREIGN KEY (`id_обучающегося`) REFERENCES `обучающиеся` (`id_обучающегося`)
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `сертификаты`
--

LOCK TABLES `сертификаты` WRITE;
/*!40000 ALTER TABLE `сертификаты` DISABLE KEYS */;
INSERT INTO `сертификаты` VALUES (20,83,1,'2025-06-03'),(21,82,1,'2025-06-03'),(22,81,1,'2025-06-03'),(23,67,1,'2025-06-03'),(24,66,1,'2025-06-03'),(25,65,1,'2025-06-03'),(26,64,1,'2025-06-03'),(27,73,1,'2025-06-03'),(28,71,1,'2025-06-03'),(29,69,1,'2025-06-03'),(30,91,1,'2025-06-03'),(31,86,1,'2025-06-03'),(32,58,1,'2025-06-03'),(33,55,1,'2025-06-03'),(34,63,1,'2025-06-03'),(35,19,1,'2025-06-03'),(36,22,1,'2025-06-03'),(37,17,1,'2025-06-03'),(38,2,1,'2025-06-03'),(39,5,1,'2025-06-03'),(40,5,4,'2025-04-07'),(41,1,4,'2025-04-07'),(42,2,4,'2025-04-07'),(43,3,4,'2025-04-07'),(44,17,4,'2025-04-07'),(45,59,4,'2025-04-07'),(46,60,4,'2025-04-07'),(47,63,4,'2025-04-07'),(48,13,2,'2024-07-29'),(49,14,2,'2024-07-29'),(50,15,2,'2024-07-29'),(51,16,2,'2024-07-29'),(52,20,2,'2024-07-29'),(53,61,2,'2024-07-29'),(54,62,2,'2024-07-29'),(55,63,2,'2024-07-29'),(56,57,2,'2024-07-29'),(57,56,2,'2024-07-29'),(58,54,2,'2024-07-29'),(59,53,2,'2024-07-29'),(60,91,1,'2025-06-15'),(61,1,4,'2025-06-17'),(62,3,4,'2025-06-23'),(63,14,2,'2025-06-23');
/*!40000 ALTER TABLE `сертификаты` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-09-04 15:34:43
