CREATE TABLE `usdot_number` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `usdot_number` varchar(45) NOT NULL,
  `sequence_number` varchar(45) NOT NULL,
  `manual_entered` tinyint(1) DEFAULT '0',
  `user_id` varchar(45) DEFAULT NULL,
  `site_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
