CREATE DATABASE  IF NOT EXISTS `prototype_sad` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `prototype_sad`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: prototype_sad
-- ------------------------------------------------------
-- Server version	5.6.36

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
-- Table structure for table `attendance`
--

DROP TABLE IF EXISTS `attendance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `attendance` (
  `attendanceID` int(11) NOT NULL AUTO_INCREMENT,
  `eventID` int(11) DEFAULT NULL,
  `caseID` int(11) DEFAULT NULL,
  `attendee` varchar(45) DEFAULT NULL,
  `role` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`attendanceID`)
) ENGINE=InnoDB AUTO_INCREMENT=59 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attendance`
--

LOCK TABLES `attendance` WRITE;
/*!40000 ALTER TABLE `attendance` DISABLE KEYS */;
INSERT INTO `attendance` VALUES (51,46,1,'ok','child','Present'),(52,46,2,'chick','child','Absent'),(53,46,3,'wally','child','none'),(54,47,1,'ok','child','Present'),(55,47,2,'chick','child','Absent'),(56,47,3,'wally','child','none'),(57,46,NULL,'Mark Superstar','Social Worker','none'),(58,46,NULL,'asdasd','Guest','none');
/*!40000 ALTER TABLE `attendance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `casestudyprofile`
--

DROP TABLE IF EXISTS `casestudyprofile`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `casestudyprofile` (
  `caseID` int(11) NOT NULL AUTO_INCREMENT,
  `caseAge` int(11) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `lastName` varchar(50) DEFAULT NULL,
  `firstName` varchar(50) DEFAULT NULL,
  `program` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `dateJoined` datetime DEFAULT NULL,
  `familyID` int(11) DEFAULT NULL,
  `HiD` int(11) DEFAULT NULL,
  `picture` blob,
  `documentPath` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`caseID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `casestudyprofile`
--

LOCK TABLES `casestudyprofile` WRITE;
/*!40000 ALTER TABLE `casestudyprofile` DISABLE KEYS */;
/*!40000 ALTER TABLE `casestudyprofile` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `education`
--

DROP TABLE IF EXISTS `education`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `education` (
  `ideducation` int(11) NOT NULL AUTO_INCREMENT,
  `caseID` int(11) DEFAULT NULL,
  `school` varchar(50) DEFAULT NULL,
  `eduType` int(11) DEFAULT NULL,
  `level` varchar(45) DEFAULT NULL,
  `section` varchar(45) DEFAULT NULL,
  `adviser` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ideducation`),
  KEY `edtocase_idx` (`caseID`),
  CONSTRAINT `edtocase` FOREIGN KEY (`caseID`) REFERENCES `casestudyprofile` (`caseID`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `education`
--

LOCK TABLES `education` WRITE;
/*!40000 ALTER TABLE `education` DISABLE KEYS */;
/*!40000 ALTER TABLE `education` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event`
--

DROP TABLE IF EXISTS `event`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `event` (
  `eventID` int(11) NOT NULL AUTO_INCREMENT,
  `evName` varchar(200) DEFAULT NULL,
  `evDesc` varchar(250) DEFAULT NULL,
  `evTime` varchar(45) DEFAULT NULL,
  `evVenue` varchar(150) DEFAULT NULL,
  `evProgress` varchar(45) DEFAULT NULL,
  `evType` varchar(45) DEFAULT NULL,
  `attendance` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `reminderDate` varchar(45) DEFAULT NULL,
  `reminderTime` varchar(45) DEFAULT NULL,
  `evMonth` varchar(45) DEFAULT NULL,
  `evDay` varchar(45) DEFAULT NULL,
  `evYear` varchar(45) DEFAULT NULL,
  `requestedBy` varchar(50) DEFAULT NULL,
  `budget` varchar(45) DEFAULT NULL,
  `reminder` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`eventID`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event`
--

LOCK TABLES `event` WRITE;
/*!40000 ALTER TABLE `event` DISABLE KEYS */;
INSERT INTO `event` VALUES (46,'Fiesta','Fiesta Celebration','18 : 00','St. Paul','','Spiritual Mass','True','Approved',NULL,NULL,'03','07','2017','Sam',NULL,NULL),(47,'Mass for the Dead','Deadsky','03 : 00','St. Paul','','Spiritual Mass','True','Approved',NULL,NULL,'03','10','2017','Jasper',NULL,NULL),(48,'Ubisoft E3','Presentation of Ubisoft Games','01 : 23','Somewhere In Time','Pending','Spiritual Mass','False','Pending',NULL,NULL,'06','27','2017','Bayek',NULL,NULL);
/*!40000 ALTER TABLE `event` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `family`
--

DROP TABLE IF EXISTS `family`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `family` (
  `familyID` int(11) NOT NULL AUTO_INCREMENT,
  `caseID` int(11) DEFAULT NULL,
  `famType` int(11) DEFAULT NULL,
  PRIMARY KEY (`familyID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `family`
--

LOCK TABLES `family` WRITE;
/*!40000 ALTER TABLE `family` DISABLE KEYS */;
/*!40000 ALTER TABLE `family` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `healthoverview`
--

DROP TABLE IF EXISTS `healthoverview`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `healthoverview` (
  `HID` int(11) NOT NULL AUTO_INCREMENT,
  `height` double DEFAULT NULL,
  `weight` double DEFAULT NULL,
  `reportType` int(11) DEFAULT NULL,
  `FilePath` varchar(100) DEFAULT NULL,
  `reportedBY` varchar(50) DEFAULT NULL,
  `dateReported` datetime DEFAULT NULL,
  PRIMARY KEY (`HID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `healthoverview`
--

LOCK TABLES `healthoverview` WRITE;
/*!40000 ALTER TABLE `healthoverview` DISABLE KEYS */;
/*!40000 ALTER TABLE `healthoverview` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_accounts`
--

DROP TABLE IF EXISTS `tbl_accounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_accounts` (
  `account_id` int(11) NOT NULL AUTO_INCREMENT,
  `fullname` varchar(45) DEFAULT NULL,
  `username` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `account_type` varchar(45) DEFAULT NULL,
  `account_status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`account_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_accounts`
--

LOCK TABLES `tbl_accounts` WRITE;
/*!40000 ALTER TABLE `tbl_accounts` DISABLE KEYS */;
INSERT INTO `tbl_accounts` VALUES (1,'Bahay Pasilungan Administration','admin','admin','Admin','Active'),(2,'Bahay Pasilungan Social Worker','social','social','Social Worker','Active');
/*!40000 ALTER TABLE `tbl_accounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'prototype_sad'
--

--
-- Dumping routines for database 'prototype_sad'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-07-18 11:53:39
