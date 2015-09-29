CREATE DATABASE  IF NOT EXISTS `sri` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `sri`;
-- MySQL dump 10.13  Distrib 5.6.19, for Win32 (x86)
--
-- Host: localhost    Database: sri
-- ------------------------------------------------------
-- Server version	5.6.21-log

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
-- Table structure for table `inspection_data`
--

DROP TABLE IF EXISTS `inspection_data`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inspection_data` (
  `us_dot_number` varchar(10) NOT NULL,
  `country` varchar(3) NOT NULL,
  `type` int(11) NOT NULL,
  `driver` varchar(10) DEFAULT NULL,
  `hazmat` varchar(10) DEFAULT NULL,
  `iep` varchar(10) DEFAULT NULL,
  `vehicle` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`us_dot_number`,`country`,`type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `safety_rating`
--

DROP TABLE IF EXISTS `safety_rating`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `safety_rating` (
  `us_dot_number` varchar(10) NOT NULL,
  `rating` varchar(45) DEFAULT NULL,
  `rating_date` varchar(10) DEFAULT NULL,
  `review_date` varchar(10) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`us_dot_number`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `company_data`
--

DROP TABLE IF EXISTS `company_data`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `company_data` (
  `us_dot_number` varchar(10) NOT NULL,
  `dba_name` varchar(100) DEFAULT NULL,
  `drivers` varchar(10) DEFAULT NULL,
  `duns_number` varchar(45) DEFAULT NULL,
  `entity_type` varchar(20) DEFAULT NULL,
  `legal_name` varchar(100) DEFAULT NULL,
  `mailing_address` varchar(100) DEFAULT NULL,
  `mcmxff_number` varchar(20) DEFAULT NULL,
  `mcs150` varchar(10) DEFAULT NULL,
  `mcs150_mileage` varchar(20) DEFAULT NULL,
  `operating_status` varchar(45) DEFAULT NULL,
  `out_of_service_date` varchar(10) DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `physical_address` varchar(100) DEFAULT NULL,
  `power_units` varchar(5) DEFAULT NULL,
  `state_carrier_id` varchar(10) DEFAULT NULL,
  `company_datacol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`us_dot_number`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `crash_data`
--

DROP TABLE IF EXISTS `crash_data`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `crash_data` (
  `us_dot_number` varchar(10) NOT NULL,
  `country` varchar(3) NOT NULL,
  `fatal` varchar(5) DEFAULT NULL,
  `injury` varchar(5) DEFAULT NULL,
  `total` varchar(5) DEFAULT NULL,
  `tow` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`us_dot_number`,`country`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-05-01 12:52:26
