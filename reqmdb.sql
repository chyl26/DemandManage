/*
Navicat MySQL Data Transfer

Source Server         : ed
Source Server Version : 50718
Source Host           : localhost:3306
Source Database       : reqmdb

Target Server Type    : MYSQL
Target Server Version : 50718
File Encoding         : 65001

Date: 2017-06-24 16:55:53
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `helpdocs`
-- ----------------------------
DROP TABLE IF EXISTS `helpdocs`;
CREATE TABLE `helpdocs` (
  `HelpDocId` char(36) NOT NULL,
  `HelpDocName` varchar(255) DEFAULT NULL,
  `Content` mediumtext,
  `CreateAt` datetime NOT NULL,
  `Reviser` varchar(255) DEFAULT NULL,
  `UpdateAt` datetime DEFAULT NULL,
  `Revision` mediumtext,
  `UserId` char(36) NOT NULL,
  `ProductId` char(36) NOT NULL,
  PRIMARY KEY (`HelpDocId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of helpdocs
-- ----------------------------

-- ----------------------------
-- Table structure for `logics`
-- ----------------------------
DROP TABLE IF EXISTS `logics`;
CREATE TABLE `logics` (
  `LogicId` char(36) NOT NULL,
  `LogicName` varchar(255) DEFAULT NULL,
  `LogicDescribe` mediumtext,
  `CreateAt` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Reviser` varchar(255) DEFAULT NULL,
  `UpdateAt` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Revision` varchar(255) DEFAULT NULL,
  `UserId` char(36) NOT NULL,
  `ProductId` char(36) NOT NULL,
  PRIMARY KEY (`LogicId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of logics
-- ----------------------------
INSERT INTO `logics` VALUES ('db58ef6e-1804-493a-88f7-aab8f34c948f', '这是第一个非功能需求', '这是一个非功能性需求模块测试内容<br>', '0001-01-01 00:00:00', 'e082dd28-c9fc-44bc-964e-cc49bee63512', '2017-06-18 21:38:04', null, 'e082dd28-c9fc-44bc-964e-cc49bee63512', '09b90699-187a-4998-bbb1-362e18b33505');
INSERT INTO `logics` VALUES ('e3567103-17d4-4463-9d45-a46c9e3faeb5', '这是第二个非功能需求', '这是第二个功能性需求模板', '0001-01-01 00:00:00', 'e082dd28-c9fc-44bc-964e-cc49bee63512', '2017-06-18 21:43:28', null, 'e082dd28-c9fc-44bc-964e-cc49bee63512', '09b90699-187a-4998-bbb1-362e18b33505');

-- ----------------------------
-- Table structure for `operatingdocs`
-- ----------------------------
DROP TABLE IF EXISTS `operatingdocs`;
CREATE TABLE `operatingdocs` (
  `OperatingId` char(36) NOT NULL,
  `OperatingName` varchar(255) DEFAULT NULL,
  `Content` mediumtext,
  `CreateAt` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Reviser` varchar(255) DEFAULT NULL,
  `UpdateAt` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Revision` mediumtext,
  `UserId` char(36) NOT NULL,
  `ProductId` char(36) NOT NULL,
  PRIMARY KEY (`OperatingId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of operatingdocs
-- ----------------------------
INSERT INTO `operatingdocs` VALUES ('f68c1055-9181-4b36-93f7-7663ccc1ee95', '这是一个产品运营方案', '<p>Error executing query \'InsertOperatingDoc\' for insert.&nbsp; Cause: Data too long for column \'OperatingId\' at row 1</p><p>Error executing query \'InsertOperatingDoc\' for insert.&nbsp; Cause: Data too long for column \'OperatingId\' at row 1<br></p>', '0001-01-01 00:00:00', null, '2017-06-24 15:32:33', '        public User user { get; set; }\r\n            <li><a href=\"~/Home/Index\"><i class=\"fa fa-dashboard\"></i> Home</a></li>\r\n            <li class=\"active\">产品运营方案</li>', 'e082dd28-c9fc-44bc-964e-cc49bee63512', '09b90699-187a-4998-bbb1-362e18b33505');
INSERT INTO `operatingdocs` VALUES ('fc242628-ce1c-4345-89f7-b798f0e4670c', '这是一个产品运营方案', '<p>Error executing query \'InsertOperatingDoc\' for insert.&nbsp; Cause: Data too long for column \'OperatingId\' at row 1<br></p>', '0001-01-01 00:00:00', 'chyl26', '2017-06-24 15:43:33', '魂牵梦萦地地李斐莉雪 ', 'e082dd28-c9fc-44bc-964e-cc49bee63512', '09b90699-187a-4998-bbb1-362e18b33505');

-- ----------------------------
-- Table structure for `productinfos`
-- ----------------------------
DROP TABLE IF EXISTS `productinfos`;
CREATE TABLE `productinfos` (
  `ProductId` char(36) NOT NULL,
  `ProductName` varchar(255) DEFAULT NULL,
  `ProductIntro` mediumtext,
  `Explains` mediumtext,
  `CreateAt` datetime DEFAULT NULL,
  `UserId` char(36) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of productinfos
-- ----------------------------
INSERT INTO `productinfos` VALUES ('09b90699-187a-4998-bbb1-362e18b33505', '这是第一个测试模板', '魂牵梦萦 地', '南非世界杯', '2017-06-15 22:06:20', 'e082dd28-c9fc-44bc-964e-cc49bee63512');

-- ----------------------------
-- Table structure for `products`
-- ----------------------------
DROP TABLE IF EXISTS `products`;
CREATE TABLE `products` (
  `ProductId` char(255) NOT NULL,
  `ProductName` varchar(255) NOT NULL,
  `Productlogic` mediumtext,
  `Characteristic` mediumtext,
  `Interactive` mediumtext,
  `DateRep` mediumtext,
  `OtherRep` mediumtext,
  `CreateAt` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  `UpdateAt` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `UserId` char(36) NOT NULL,
  PRIMARY KEY (`ProductId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of products
-- ----------------------------

-- ----------------------------
-- Table structure for `repdatas`
-- ----------------------------
DROP TABLE IF EXISTS `repdatas`;
CREATE TABLE `repdatas` (
  `DataId` char(36) NOT NULL,
  `DataName` varchar(255) DEFAULT NULL,
  `Priority` varchar(255) DEFAULT NULL,
  `DataDescribe` mediumtext,
  `CreateAt` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Reviser` varchar(255) DEFAULT NULL,
  `UpdateAt` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Revision` varchar(255) DEFAULT NULL,
  `UserId` char(36) NOT NULL,
  `ProductId` char(36) NOT NULL,
  PRIMARY KEY (`DataId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of repdatas
-- ----------------------------
INSERT INTO `repdatas` VALUES ('8c57422e-0eae-40ef-8d29-146606ab003a', '这是一个数据需求模板', '0', '<p><br></p><p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public string UserId { get; set; }</p><p><br></p><p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public string DisplayName { get; set; }</p><p><br></p>', '2017-06-18 17:34:14', null, '0001-01-01 00:00:00', null, 'e082dd28-c9fc-44bc-964e-cc49bee63512', '09b90699-187a-4998-bbb1-362e18b33505');

-- ----------------------------
-- Table structure for `repdetaileds`
-- ----------------------------
DROP TABLE IF EXISTS `repdetaileds`;
CREATE TABLE `repdetaileds` (
  `ProductId` char(36) NOT NULL,
  `RepDetailedId` char(36) NOT NULL,
  `RepName` varchar(255) DEFAULT NULL,
  `Priority` varchar(255) DEFAULT NULL,
  `RepDescribe` mediumtext,
  `CreateAt` datetime NOT NULL,
  `Reviser` varchar(255) DEFAULT NULL,
  `UpdateAt` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Revision` varchar(255) DEFAULT NULL,
  `UserId` char(36) NOT NULL,
  PRIMARY KEY (`RepDetailedId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of repdetaileds
-- ----------------------------
INSERT INTO `repdetaileds` VALUES ('09b90699-187a-4998-bbb1-362e18b33505', '0f3f39cf-cc39-40d0-95fe-0278ee996e7b', '塔顶下城', '1', '栽苛魂牵梦萦魂牵梦萦吉格斯', '2017-06-15 22:44:14', null, '0001-01-01 00:00:00', null, 'e082dd28-c9fc-44bc-964e-cc49bee63512');
INSERT INTO `repdetaileds` VALUES ('09b90699-187a-4998-bbb1-362e18b33505', '5752549d-48fd-42d9-95f3-465743b2b7b5', '塔顶f', '0', '塔顶地塔顶载载', '2017-06-15 22:43:44', null, '0001-01-01 00:00:00', null, 'e082dd28-c9fc-44bc-964e-cc49bee63512');
INSERT INTO `repdetaileds` VALUES ('09b90699-187a-4998-bbb1-362e18b33505', 'febb5313-36ff-44dd-a2bd-8b6869947449', '克格勃', '0', '塔顶地', '2017-06-15 22:43:23', null, '0001-01-01 00:00:00', null, 'e082dd28-c9fc-44bc-964e-cc49bee63512');

-- ----------------------------
-- Table structure for `repinteractives`
-- ----------------------------
DROP TABLE IF EXISTS `repinteractives`;
CREATE TABLE `repinteractives` (
  `InteractiveId` char(36) NOT NULL,
  `InteractiveName` varchar(255) DEFAULT NULL,
  `Priority` varchar(255) DEFAULT NULL,
  `InteractiveDescribe` mediumtext,
  `CreateAt` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Reviser` varchar(255) DEFAULT NULL,
  `UpdateAt` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Revision` varchar(255) DEFAULT NULL,
  `UserId` char(255) NOT NULL,
  `ProductId` char(36) NOT NULL,
  PRIMARY KEY (`InteractiveId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of repinteractives
-- ----------------------------
INSERT INTO `repinteractives` VALUES ('fc7242ff-d615-4ec2-ac6c-7267c03ddb04', '地板革', '0', '塔顶载吉格斯地', '2017-06-15 22:44:38', null, '0001-01-01 00:00:00', null, 'e082dd28-c9fc-44bc-964e-cc49bee63512', '09b90699-187a-4998-bbb1-362e18b33505');

-- ----------------------------
-- Table structure for `repothers`
-- ----------------------------
DROP TABLE IF EXISTS `repothers`;
CREATE TABLE `repothers` (
  `RepOtherId` char(36) NOT NULL,
  `RepOtherName` varchar(255) DEFAULT NULL,
  `Priority` varchar(255) DEFAULT NULL,
  `RepOtherDescribe` mediumtext,
  `CreateAt` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Reviser` varchar(255) DEFAULT NULL,
  `UpdateAt` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Revision` varchar(255) DEFAULT NULL,
  `UserId` char(36) NOT NULL,
  `ProductId` char(36) NOT NULL,
  PRIMARY KEY (`RepOtherId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of repothers
-- ----------------------------
INSERT INTO `repothers` VALUES ('db58ef6e-1804-493a-88f7-aab8f34c948f', '这是第一个非功能需求', '0', '这是一个非功能性需求模块测试内容<br>', '0001-01-01 00:00:00', 'e082dd28-c9fc-44bc-964e-cc49bee63512', '2017-06-18 21:38:04', null, 'e082dd28-c9fc-44bc-964e-cc49bee63512', '09b90699-187a-4998-bbb1-362e18b33505');
INSERT INTO `repothers` VALUES ('e3567103-17d4-4463-9d45-a46c9e3faeb5', '这是第二个非功能需求', '0', '这是第二个功能性需求模板', '0001-01-01 00:00:00', 'e082dd28-c9fc-44bc-964e-cc49bee63512', '2017-06-18 21:43:28', null, 'e082dd28-c9fc-44bc-964e-cc49bee63512', '09b90699-187a-4998-bbb1-362e18b33505');

-- ----------------------------
-- Table structure for `users`
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `UserId` char(36) NOT NULL,
  `UserName` varchar(45) DEFAULT NULL,
  `DisplayName` varchar(45) DEFAULT NULL,
  `PasswordHash` varchar(45) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `MobilePhone` varchar(45) DEFAULT NULL,
  `CreateAt` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES ('e082dd28-c9fc-44bc-964e-cc49bee63512', 'chyl26', null, '57:686', null, null, '2017-06-15 18:38:44');
