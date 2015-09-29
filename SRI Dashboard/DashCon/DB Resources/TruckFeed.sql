CREATE TABLE `truck_feed` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date_created` datetime DEFAULT CURRENT_TIMESTAMP,
  `timestamp` datetime NOT NULL,
  `approach_entered` datetime DEFAULT NULL,
  `wim_entered` datetime DEFAULT NULL,
  `wim_left` datetime DEFAULT NULL,
  `site_id` int(11) NOT NULL,
  `sequence_number` int(11) DEFAULT NULL,
  `license_plate` varchar(45) NOT NULL,
  `image_url` varchar(100) DEFAULT NULL,
  `drivers_license` varchar(45) DEFAULT NULL,
  `commercial_drivers_license` varchar(45) DEFAULT NULL,
  `vin` varchar(45) NOT NULL,
  `usdot_number` varchar(45) NOT NULL,
  `latitude` decimal(10,8) NOT NULL,
  `longitude` decimal(11,8) NOT NULL,
  `mobile_app_version` varchar(10) DEFAULT NULL,
  `status` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;

