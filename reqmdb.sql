/*
Navicat MySQL Data Transfer

Source Server         : ed
Source Server Version : 50718
Source Host           : localhost:3306
Source Database       : reqmdb

Target Server Type    : MYSQL
Target Server Version : 50718
File Encoding         : 65001

Date: 2017-05-27 19:25:57
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
-- Records of helpdocs
-- ----------------------------

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
-- Records of operatingdocs
-- ----------------------------

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
-- Records of productinfos
-- ----------------------------
INSERT INTO `productinfos` VALUES ('9aec8bc1-1692-4222-953c-313a40e39899', '南非世界杯fsd', 'dsfads 吉格斯魂牵梦萦在花木成畦手自栽基本面魂牵梦萦地', '魂牵梦萦 ', '2017-05-26 17:08:48', null);
INSERT INTO `productinfos` VALUES ('3c108c1e-0e18-4829-9c49-f19814c1e256', '产品经理人助手', '载百花村工东走西顾栽', '魂牵梦萦南塔顶载非世界杯', '2017-05-27 11:00:00', '46af4ae1-beca-4715-b5e5-0b8d576f0bc1');

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
-- Records of products
-- ----------------------------
INSERT INTO `products` VALUES ('0c0d13c0-2877-4753-954f-a7424844f616', '塔顶霸', '<p><br></p><table class=\"table table-bordered\"><tbody><tr><td>顾不上老板在<br></td><td>栽植大柳塔<br></td></tr><tr><td>魂牵梦萦地<br></td><td><br></td></tr><tr><td><br></td><td>夺古斯塔夫森压顶工<br></td></tr><tr><td>运营成本魂牵梦萦 <br></td><td>魂牵梦萦地基石无人机<br></td></tr></tbody></table><p><br></p>', null, '琦一', '堪', '太极鞋 ', '2017-05-26 13:53:50', '2017-05-26 13:53:50', '46af4ae1-beca-4715-b5e5-0b8d576f0bc1');
INSERT INTO `products` VALUES ('608840ba-f68c-49d4-bcc5-fc13452191ca', '静态方法的使用', '<p><br></p><div style=\"line-height: 1.875; font-size: 14px; white-space: pre-wrap;\" yne-bulb-block=\"paragraph\">关键知道点</div><p><br></p><div style=\"line-height: 1.875; font-size: 14px; white-space: pre-wrap;\" yne-bulb-block=\"paragraph\"><br></div><p><br></p><div style=\"line-height: 1.875; font-size: 14px; white-space: pre-wrap;\" yne-bulb-block=\"paragraph\">常见错误解析</div><p><br></p><ol yne-block-type=\"list\"><li style=\"line-height: 1.875; font-size: 14px; list-style-type: decimal; list-style-position: inside; white-space: pre-wrap;\">静态方法调用实例方法（编译器错误提示：非静态的字段、方法或属性“方法名”要求对象引用 ）</li></ol><p><br></p><div style=\"line-height: 1.875; font-size: 14px; white-space: pre-wrap;\" yne-bulb-block=\"paragraph\">解决方法：检查静态方法是否调用中是否调用一个实例方法，并且实例方法是否在本方法中创建对象，原因是静态方法一启用时就存在，而实例方法是在new后才存在，所以不能在静态方法中调用实例方法。</div><p><br></p><ol start=\"2\" yne-block-type=\"list\"><li style=\"line-height: 1.875; font-size: 14px; list-style-type: decimal; list-style-position: inside; white-space: pre-wrap;\"><br></li></ol><p><br></p><div style=\"line-height: 1.875; font-size: 14px; white-space: pre-wrap;\" yne-bulb-block=\"paragraph\"><br></div><p><br></p><div style=\"line-height: 1.875; font-size: 14px; white-space: pre-wrap;\" yne-bulb-block=\"paragraph\">注意事项</div><p><br></p><ol yne-block-type=\"list\"><li style=\"line-height: 1.875; font-size: 14px; list-style-type: decimal; list-style-position: inside; white-space: pre-wrap;\"><br></li></ol><p><br></p><div style=\"line-height: 1.875; font-size: 14px; white-space: pre-wrap;\" yne-bulb-block=\"paragraph\"><br></div><p><br></p><div style=\"line-height: 1.875; font-size: 14px; white-space: pre-wrap;\" yne-bulb-block=\"paragraph\">基本概念</div><p><br></p><ol yne-block-type=\"list\"><li style=\"line-height: 1.875; font-size: 14px; list-style-type: decimal; list-style-position: inside; white-space: pre-wrap;\">以static访问修饰符修饰的方法叫静态方法</li><li style=\"line-height: 1.875; font-size: 14px; list-style-type: decimal; list-style-position: inside; white-space: pre-wrap;\">静态方法使用技巧</li></ol><p><br></p><ul yne-block-type=\"list\"><li style=\"line-height: 1.875; font-size: 14px; list-style-type: disc; list-style-position: inside; white-space: pre-wrap;\">直接通过\"类名.方法名\"方式调用</li><li style=\"line-height: 1.875; font-size: 14px; list-style-type: disc; list-style-position: inside; white-space: pre-wrap;\">一般在开发中，使用特别频繁的方法，可以使用静态方法，避免对象频繁创建耗费时间</li><li style=\"line-height: 1.875; font-size: 14px; list-style-type: disc; list-style-position: inside; white-space: pre-wrap;\">静态方法在项目启动的时候就存在了，一直到项目关闭为上，不受GC（垃圾回收机制）的管控</li></ul><p><br></p><ol start=\"3\" yne-block-type=\"list\"><li style=\"line-height: 1.875; font-size: 14px; list-style-type: decimal; list-style-position: inside; white-space: pre-wrap;\"><br></li></ol><p><br></p><div style=\"line-height: 1.875; font-size: 14px; white-space: pre-wrap;\" yne-bulb-block=\"paragraph\"><br></div><p><br></p><div style=\"line-height: 1.875; font-size: 14px; white-space: pre-wrap;\" yne-bulb-block=\"paragraph\">基本语句</div><p><br></p><div style=\"line-height: 1.875; font-size: 14px; white-space: pre-wrap;\" yne-bulb-block=\"paragraph\"><br></div><p><br></p><div style=\"line-height: 1.875; font-size: 14px; white-space: pre-wrap;\" yne-bulb-block=\"paragraph\">语句表达式</div><p>\r\n\r\n</p>', null, null, null, null, '2017-05-25 15:30:54', '2017-05-25 15:30:53', '46af4ae1-beca-4715-b5e5-0b8d576f0bc1');
INSERT INTO `products` VALUES ('8310b56c-389f-4bb9-9d6f-cf50f9fc7175', '塔顶f', '塔顶花木成畦手自栽a', null, '栽', '堪', '塔顶', '2017-05-26 11:06:08', '0001-01-01 00:00:00', '46af4ae1-beca-4715-b5e5-0b8d576f0bc1');
INSERT INTO `products` VALUES ('d42b51b5-dbaa-4be6-a420-f96e4dfd68e4', '运营成本地', '魂牵梦萦塔顶垃圾东西在 柑工', null, '塔顶㠭魂牵梦萦', '吉格斯', '塔顶压顶革', '2017-05-26 11:25:09', '2017-05-26 11:25:03', '46af4ae1-beca-4715-b5e5-0b8d576f0bc1');

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
-- Records of repdatas
-- ----------------------------

-- ----------------------------
-- Table structure for repdetaileds
-- ----------------------------
DROP TABLE IF EXISTS `repdetaileds`;
CREATE TABLE `repdetaileds` (
  `ProductId` char(36) NOT NULL,
  `ReqDetailedId` char(36) NOT NULL,
  `RepName` varchar(255) DEFAULT NULL,
  `Priority` varchar(255) DEFAULT NULL,
  `RepDescribe` mediumtext,
  `CreateAt` datetime NOT NULL,
  `Reviser` varchar(255) DEFAULT NULL,
  `UpdateAt` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Revision` varchar(255) DEFAULT NULL,
  `UserId` char(36) NOT NULL,
  PRIMARY KEY (`ReqDetailedId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of repdetaileds
-- ----------------------------

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
-- Records of repinteractives
-- ----------------------------

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

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES ('46af4ae1-beca-4715-b5e5-0b8d576f0bc1', 'chyl26', '陈永亮', '57:686', 'chyl26@live.cn', '13616053507', '2017-05-24 17:45:03');
