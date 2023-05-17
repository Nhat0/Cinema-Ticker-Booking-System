-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: btc-database
-- ------------------------------------------------------
-- Server version	8.0.30

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
-- Table structure for table `bookings`
--

DROP TABLE IF EXISTS `bookings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bookings` (
  `id` int NOT NULL AUTO_INCREMENT,
  `screening_id` int NOT NULL,
  `seat_id` int NOT NULL,
  `user_id` int NOT NULL,
  `booking_time` datetime NOT NULL,
  `status` enum('pending','confirmed','cancelled') NOT NULL DEFAULT 'pending',
  PRIMARY KEY (`id`),
  KEY `screening_id` (`screening_id`),
  KEY `seat_id` (`seat_id`),
  KEY `booking_ibfk_3_idx` (`user_id`),
  CONSTRAINT `bookings_ibfk_1` FOREIGN KEY (`screening_id`) REFERENCES `screening` (`id`),
  CONSTRAINT `bookings_ibfk_2` FOREIGN KEY (`seat_id`) REFERENCES `seats` (`id`),
  CONSTRAINT `bookings_ibfk_3` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bookings`
--

LOCK TABLES `bookings` WRITE;
/*!40000 ALTER TABLE `bookings` DISABLE KEYS */;
/*!40000 ALTER TABLE `bookings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `genres`
--

DROP TABLE IF EXISTS `genres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `genres` (
  `id` int NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genres`
--

LOCK TABLES `genres` WRITE;
/*!40000 ALTER TABLE `genres` DISABLE KEYS */;
INSERT INTO `genres` VALUES (12,'Adventure'),(14,'Fantasy'),(16,'Animation'),(18,'Drama'),(27,'Horror'),(28,'Action'),(35,'Comedy'),(36,'History'),(37,'Western'),(53,'Thriller'),(80,'Crime'),(99,'Documentary'),(878,'Science Fiction'),(9648,'Mystery'),(10402,'Music'),(10749,'Romance'),(10751,'Family'),(10752,'War'),(10770,'TV Movie');
/*!40000 ALTER TABLE `genres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movie_genre`
--

DROP TABLE IF EXISTS `movie_genre`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `movie_genre` (
  `movieId` int NOT NULL,
  `genreId` int NOT NULL,
  PRIMARY KEY (`movieId`,`genreId`),
  KEY `genreId` (`genreId`),
  CONSTRAINT `movie_genre_ibfk_1` FOREIGN KEY (`movieId`) REFERENCES `movies` (`id`),
  CONSTRAINT `movie_genre_ibfk_2` FOREIGN KEY (`genreId`) REFERENCES `genres` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movie_genre`
--

LOCK TABLES `movie_genre` WRITE;
/*!40000 ALTER TABLE `movie_genre` DISABLE KEYS */;
/*!40000 ALTER TABLE `movie_genre` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movies`
--

DROP TABLE IF EXISTS `movies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `movies` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(250) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `release_date` date DEFAULT NULL,
  `overView` varchar(1000) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `runtime` int DEFAULT NULL,
  `vote_average` float DEFAULT NULL,
  `vote_count` int DEFAULT NULL,
  `genres` varchar(100) DEFAULT NULL,
  `backdrop_path` varchar(250) DEFAULT NULL,
  `poster_path` varchar(250) DEFAULT NULL,
  `trailer_path` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1100691 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movies`
--

LOCK TABLES `movies` WRITE;
/*!40000 ALTER TABLE `movies` DISABLE KEYS */;
INSERT INTO `movies` VALUES (502356,'The Super Mario Bros. Movie','2023-04-07','While working underground to fix a water main, Brooklyn plumbers—and brothers—Mario and Luigi are transported down a mysterious pipe and wander into a magical new world. But when the brothers are separated, Mario embarks on an epic quest to find Luigi.',92,7.5,2058,NULL,'https://image.tmdb.org/t/p/w500/9n2tJBplPbgR2ca05hS5CKXwP2c.jpg','https://image.tmdb.org/t/p/w500/qNBAXBIQlnOThrVvA6mA2B5ggV6.jpg','https://www.youtube.com/watch?v=RjNcTBXTk4I'),(783675,'The First Slam Dunk','2023-04-14','Shohoku\'s “speedster” and point guard, Ryota Miyagi, always plays with brains and lightning speed, running circles around his opponents while feigning composure. In his second year of high school, Ryota plays with the Shohoku High School basketball team along with Sakuragi, Rukawa, Akagi, and Mitsui as they take the stage at the Inter-High School National Championship. And now, they are on the brink of challenging the reigning champions, Sannoh Kogyo High School.',124,8.1,69,NULL,'https://image.tmdb.org/t/p/w500/zjpYDQlhvrAaohKRShu522sKJ87.jpg','https://image.tmdb.org/t/p/w500/kmYuPvMz927oAqU7MUxhCeXsLjI.jpg',NULL),(949701,'Inhuman Kiss 2','2023-04-28','The romantic horror centres on a man born with abnormal genes and a half-demon woman, who both long to be loved.',123,5.5,2,NULL,'https://image.tmdb.org/t/p/w500/y5FnpKxnKXiMt7zoyc0fzBnTa3W.jpg','https://image.tmdb.org/t/p/w500/1nG0NyRIJgDVlKHqrsJFWHMnyKo.jpg','https://www.youtube.com/watch?v=L1FOtqlJ-QY'),(977179,'You & Me & Me','2023-04-07','A nostalgic, coming-of-age story of identical twin sisters who share every aspect of their lives with one another, until one day a boy walks into their lives and puts their strong bond to the test.',122,5,6,NULL,'https://image.tmdb.org/t/p/w500/lGL6HNc2h0VmdEtjQ2bZfWX8qn1.jpg','https://image.tmdb.org/t/p/w500/nPBo5HZN2yubtHyfFkLy1c7RmCY.jpg','https://www.youtube.com/watch?v=s7H5JV9wfdQ'),(983883,'Marry My Dead Body','2023-04-07','A traditional same sex marriage between a human and a ghost.  One day a police officer finds a red wedding envelope, only to find out that the owner of the red envelope is in fact a ghost from the other side asking for the officers hand in marriage before reincarnation. What will happen when a human and a ghost form a special bond?',130,6.4,8,NULL,'https://image.tmdb.org/t/p/w500/qHurP5rHZk63ZIcjegKy1M57oC7.jpg','https://image.tmdb.org/t/p/w500/nb9sB3D1AwfrAGffq1ql2RNldHm.jpg','https://www.youtube.com/watch?v=01x0ciUX0y4'),(1072077,'Face Off 6: The Ticket Of Destiny','2023-04-28','A group of longtime friends suddenly received a chance to change their lives when they found out that the group\'s ticket won a jackpot of 136.8 billion. Suddenly, An, the ticket holder, had an accident and did not survive. Faced with the dream winning money that should have been easily available, the group of friends embarked on a journey to find the lottery ticket. But that was only the beginning of countless unexpected events. Where will this quest to find and share the lucrative dream money really lead the group?',132,10,1,NULL,'https://image.tmdb.org/t/p/w500','https://image.tmdb.org/t/p/w500/9F0L1Ksfe2pqCRIvCdaA7Uvnr9W.jpg',NULL),(1073070,'The Island','2023-03-31','The vacation of a group of youngsters turns into an endless horrifying nightmare after a losing bet forces them to spend a night on a deserted island.  As they stumble upon a mysterious abandoned village there, they accidentally break an old spell that was placed to restrain an antagonizing spirit trapped in the island. One by one, they are made to suffer the gripping and gruesome consequences of their mistakes,  infuriating an evil creature that needs human blood to stay alive. The only way out is in the hands of a girl who desperately needs to use her supernatural gift to untangle an unsettling history connected to a tainted cross-cultural love story.',111,6,1,NULL,'https://image.tmdb.org/t/p/w500/uqBUqfbZwi8y2nmPdnnZkIvmRTs.jpg','https://image.tmdb.org/t/p/w500/qv3GjKNh4noyCmp4ysTDcT8yDlW.jpg','https://www.youtube.com/watch?v=pQ_mbrY11So'),(1075228,'Chuyện Xóm Tui: Con Nhót Mót Chồng','2023-04-28','The film is the story of Nhot - a woman who is \"not yet old\" who is about to go through menopause, and rushes to find her husband. But deep inside her, is the desire to have a child and always want to make up with her drunk father.',112,0,0,NULL,'https://image.tmdb.org/t/p/w500','https://image.tmdb.org/t/p/w500/6WeBK3ivG5fBAt0RMrJrH0GhBrT.jpg','https://www.youtube.com/watch?v=zi1V9sEblCM'),(1084384,'The Ideal Squad','2023-03-31','The Ideal Squad is a Comedy, revolving around the duo Khue (Hoang Oanh) and Phong (Hua Vi Van). After a chance encounter, the duo drags Bay Cuc (Vo Tan Phat), Bay Suc (Nguyen Thao), Quau (Ngoc Phuoc), Quo (Ngoc Hoa) to participate in a special mission: Swapping the attached bracelet. kiss with precious diamonds and reveal the true face of Tuan (Quang Tuan) - Khue\'s ex-husband at the wedding between him and Tu Xoan (Le Khanh) - a female giant in the West who owns a million dollar fortune. The reluctant combination of The Ideal Squad - Phong, Khue and the Family Cuc Suc aimed at the eyes of the \"bride and groom\" at the luxurious resort promises to be extremely thrilling, suspenseful but no less humorous, emotional.',0,0,0,NULL,'https://image.tmdb.org/t/p/w500','https://image.tmdb.org/t/p/w500/A9tJJOGOwE2SBYvcPjujbg1zJv8.jpg',NULL),(1100690,'Tri Âm: Người Giữ Thời Gian','2023-04-08','My Tam will realistically depict all the psychological and emotional developments of joy and sorrow, difficulties and sublimation during the performance of the historic Tri Am Liveshow with precious footage filmed in 2 years.',0,0,0,NULL,'https://image.tmdb.org/t/p/w500','https://image.tmdb.org/t/p/w500/wqkG2fVbbcpEBpx9sPuA87hXp1l.jpg',NULL);
/*!40000 ALTER TABLE `movies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'admin'),(2,'customer');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rooms`
--

DROP TABLE IF EXISTS `rooms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rooms` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL,
  `capacity` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rooms`
--

LOCK TABLES `rooms` WRITE;
/*!40000 ALTER TABLE `rooms` DISABLE KEYS */;
INSERT INTO `rooms` VALUES (1,'Room 1',50),(2,'Room 2',40);
/*!40000 ALTER TABLE `rooms` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `screening`
--

DROP TABLE IF EXISTS `screening`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `screening` (
  `id` int NOT NULL AUTO_INCREMENT,
  `movie_id` int NOT NULL,
  `room_id` int NOT NULL,
  `start_time` datetime NOT NULL,
  `end_time` datetime NOT NULL,
  `price` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `movie_id` (`movie_id`),
  KEY `room_id` (`room_id`),
  CONSTRAINT `screening_ibfk_1` FOREIGN KEY (`movie_id`) REFERENCES `movies` (`id`),
  CONSTRAINT `screening_ibfk_2` FOREIGN KEY (`room_id`) REFERENCES `rooms` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `screening`
--

LOCK TABLES `screening` WRITE;
/*!40000 ALTER TABLE `screening` DISABLE KEYS */;
INSERT INTO `screening` VALUES (3,502356,1,'2023-05-17 09:49:47','2023-05-17 11:49:47',45000.00);
/*!40000 ALTER TABLE `screening` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `seats`
--

DROP TABLE IF EXISTS `seats`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `seats` (
  `id` int NOT NULL AUTO_INCREMENT,
  `room_id` int NOT NULL,
  `rowSeat` varchar(50) NOT NULL,
  `number` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `room_id` (`room_id`),
  CONSTRAINT `seats_ibfk_1` FOREIGN KEY (`room_id`) REFERENCES `rooms` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=91 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `seats`
--

LOCK TABLES `seats` WRITE;
/*!40000 ALTER TABLE `seats` DISABLE KEYS */;
INSERT INTO `seats` VALUES (1,1,'A',1),(2,1,'A',2),(3,1,'A',3),(4,1,'A',4),(5,1,'A',5),(6,1,'A',6),(7,1,'A',7),(8,1,'A',8),(9,1,'A',9),(10,1,'A',10),(11,1,'B',1),(12,1,'B',2),(13,1,'B',3),(14,1,'B',4),(15,1,'B',5),(16,1,'B',6),(17,1,'B',7),(18,1,'B',8),(19,1,'B',9),(20,1,'B',10),(21,1,'C',1),(22,1,'C',2),(23,1,'C',3),(24,1,'C',4),(25,1,'C',5),(26,1,'C',6),(27,1,'C',7),(28,1,'C',8),(29,1,'C',9),(30,1,'C',10),(31,1,'D',1),(32,1,'D',2),(33,1,'D',3),(34,1,'D',4),(35,1,'D',5),(36,1,'D',6),(37,1,'D',7),(38,1,'D',8),(39,1,'D',9),(40,1,'D',10),(41,1,'D',1),(42,1,'D',2),(43,1,'D',3),(44,1,'D',4),(45,1,'D',5),(46,1,'D',6),(47,1,'D',7),(48,1,'D',8),(49,1,'D',9),(50,1,'D',10),(51,2,'A',1),(52,2,'A',2),(53,2,'A',3),(54,2,'A',4),(55,2,'A',5),(56,2,'A',6),(57,2,'A',7),(58,2,'A',8),(59,2,'A',9),(60,2,'A',10),(61,2,'B',1),(62,2,'B',2),(63,2,'B',3),(64,2,'B',4),(65,2,'B',5),(66,2,'B',6),(67,2,'B',7),(68,2,'B',8),(69,2,'B',9),(70,2,'B',10),(71,2,'C',1),(72,2,'C',2),(73,2,'C',3),(74,2,'C',4),(75,2,'C',5),(76,2,'C',6),(77,2,'C',7),(78,2,'C',8),(79,2,'C',9),(80,2,'C',10),(81,2,'D',1),(82,2,'D',2),(83,2,'D',3),(84,2,'D',4),(85,2,'D',5),(86,2,'D',6),(87,2,'D',7),(88,2,'D',8),(89,2,'D',9),(90,2,'D',10);
/*!40000 ALTER TABLE `seats` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_role`
--

DROP TABLE IF EXISTS `user_role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_role` (
  `user_id` int NOT NULL,
  `role_id` int NOT NULL,
  PRIMARY KEY (`user_id`,`role_id`),
  KEY `role_id` (`role_id`),
  CONSTRAINT `user_role_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`),
  CONSTRAINT `user_role_ibfk_2` FOREIGN KEY (`role_id`) REFERENCES `roles` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_role`
--

LOCK TABLES `user_role` WRITE;
/*!40000 ALTER TABLE `user_role` DISABLE KEYS */;
INSERT INTO `user_role` VALUES (1,1),(2,2);
/*!40000 ALTER TABLE `user_role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `email` varchar(255) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `userphonenum` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email` (`email`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'bebu123@gmail.com','bebu','bebu@123',NULL),(2,'benho123@gmail.com','benho','benho@123',NULL);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-17 11:20:39
