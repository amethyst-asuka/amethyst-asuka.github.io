CREATE DATABASE  IF NOT EXISTS `authorization_token` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `authorization_token`;
-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: authorization_token
-- ------------------------------------------------------
-- Server version	5.7.12-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `device_tree`
--

DROP TABLE IF EXISTS `device_tree`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `device_tree` (
  `uid` int(11) NOT NULL AUTO_INCREMENT COMMENT 'integer uid for token query',
  `token` char(32) NOT NULL COMMENT 'md5 hash value of the hardward signature info',
  `device_name` varchar(128) DEFAULT NULL,
  `register_time` datetime NOT NULL,
  `note` tinytext,
  `parent` int(11) NOT NULL COMMENT 'parent uid in this tree, root device is -1',
  PRIMARY KEY (`uid`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `device_tree`
--

LOCK TABLES `device_tree` WRITE;
/*!40000 ALTER TABLE `device_tree` DISABLE KEYS */;
INSERT INTO `device_tree` VALUES (3,'9d3331d090b87f01d0f167cf5591ef9c','DESKTOP-5L1QPEN','2016-07-22 23:10:50','Microsoft Windows NT 6.2.9200.0',-1),(4,'9d3331d090b87f01d0f167cf5591ef9c','DESKTOP-5L1QPEN','2016-07-22 23:12:50','Microsoft Windows NT 6.2.9200.0',-1),(5,'9d3331d090b87f01d0f167cf5591ef9c','DESKTOP-5L1QPEN','2016-07-22 23:15:19','Microsoft Windows NT 6.2.9200.0',-1),(6,'9d3331d090b87f01d0f167cf5591ef9c','DESKTOP-5L1QPEN','2016-07-22 23:18:58','Microsoft Windows NT 6.2.9200.0',-1),(7,'9d3331d090b87f01d0f167cf5591ef9c','DESKTOP-5L1QPEN','2016-07-22 23:20:06','Microsoft Windows NT 6.2.9200.0',-1);
/*!40000 ALTER TABLE `device_tree` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `neural_tokens`
--

DROP TABLE IF EXISTS `neural_tokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `neural_tokens` (
  `uid` int(11) NOT NULL AUTO_INCREMENT COMMENT 'integer uid for token query',
  `t1` int(11) NOT NULL,
  `t2` int(11) NOT NULL,
  `t3` int(11) NOT NULL,
  `t4` int(11) NOT NULL,
  `t5` int(11) NOT NULL,
  `key` int(11) NOT NULL COMMENT 'index of the t1 or t2 or t3 or t4 or t5, ann result',
  `user` int(11) NOT NULL COMMENT 'user id',
  PRIMARY KEY (`uid`),
  UNIQUE KEY `uid_UNIQUE` (`uid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `neural_tokens`
--

LOCK TABLES `neural_tokens` WRITE;
/*!40000 ALTER TABLE `neural_tokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `neural_tokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `uid` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(128) NOT NULL,
  `root_device` int(11) NOT NULL COMMENT 'The first device that user register on the platform, this property point to the device_tree table uid.',
  PRIMARY KEY (`uid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (2,'amethyst.asuka@gcmodeller.org',7);
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

-- Dump completed on 2016-07-22 23:20:59
