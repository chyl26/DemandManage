/*
Navicat MySQL Data Transfer

Source Server         : ed
Source Server Version : 50718
Source Host           : localhost:3306
Source Database       : reqmdb

Target Server Type    : MYSQL
Target Server Version : 50718
File Encoding         : 65001

Date: 2017-05-29 15:50:53
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for helpdocs
-- ----------------------------
DROP TABLE IF EXISTS `helpdocs`;
CREATE TABLE `helpdocs` (
  `ProductId` char(36) DEFAULT NULL,
  `HelpDocId` char(36) DEFAULT NULL,
  `HelpDocName` varchar(255) DEFAULT NULL,
  `Content` mediumtext,
  `CreateAt` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Reviser` varchar(255) DEFAULT NULL,
  `UpdateAt` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Revision` varchar(255) DEFAULT NULL,
  `UserId` char(36) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for operatingdocs
-- ----------------------------
DROP TABLE IF EXISTS `operatingdocs`;
CREATE TABLE `operatingdocs` (
  `OperatingId` char(35) NOT NULL,
  `OperatingName` varchar(0) DEFAULT NULL,
  `Content` mediumtext,
  `CreateAt` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Reviser` varchar(255) DEFAULT NULL,
  `UpdateAt` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `UserId` char(255) NOT NULL,
  `ProductId` mediumtext NOT NULL,
  PRIMARY KEY (`OperatingId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Table structure for productinfos
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
-- Table structure for products
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
-- Table structure for repdatas
-- ----------------------------
DROP TABLE IF EXISTS `repdatas`;
CREATE TABLE `repdatas` (
  `DataId` char(35) NOT NULL,
  `DataName` varchar(0) DEFAULT NULL,
  `DataDescribe` mediumtext,
  `CreateAt` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Reviser` varchar(255) DEFAULT NULL,
  `UpdateAt` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `UserId` char(255) NOT NULL,
  `ProductId` mediumtext NOT NULL,
  PRIMARY KEY (`DataId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Table structure for repdetaileds
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
-- Table structure for repinteractives
-- ----------------------------
DROP TABLE IF EXISTS `repinteractives`;
CREATE TABLE `repinteractives` (
  `InteractiveId` char(35) NOT NULL,
  `InteractiveName` varchar(0) DEFAULT NULL,
  `InteractiveDescribe` mediumtext,
  `CreateAt` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Reviser` varchar(255) DEFAULT NULL,
  `UpdateAt` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `UserId` char(255) NOT NULL,
  `ProductId` mediumtext NOT NULL,
  PRIMARY KEY (`InteractiveId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Table structure for users
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
