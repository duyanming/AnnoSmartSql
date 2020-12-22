/*
 Navicat Premium Data Transfer

 Source Server         : localHaoSqlMyql
 Source Server Type    : MySQL
 Source Server Version : 50719
 Source Host           : localhost:3306
 Source Schema         : viper

 Target Server Type    : MySQL
 Target Server Version : 50719
 File Encoding         : 65001

 Date: 22/12/2020 15:12:05
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for t_user
-- ----------------------------
DROP TABLE IF EXISTS `t_user`;
CREATE TABLE `t_user`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Status` int(255) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 10 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of t_user
-- ----------------------------
INSERT INTO `t_user` VALUES (1, 'sad', 1);
INSERT INTO `t_user` VALUES (2, '张三', 1);
INSERT INTO `t_user` VALUES (3, '李四', 1);
INSERT INTO `t_user` VALUES (4, '王五', 1);
INSERT INTO `t_user` VALUES (5, '王六', 1);
INSERT INTO `t_user` VALUES (6, '天天', 1);
INSERT INTO `t_user` VALUES (7, '语言', 0);
INSERT INTO `t_user` VALUES (8, '哈哈', 0);
INSERT INTO `t_user` VALUES (9, '我的id是51', 1);

SET FOREIGN_KEY_CHECKS = 1;
