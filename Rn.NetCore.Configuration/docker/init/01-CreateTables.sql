CREATE TABLE `Configuration` (
	`ConfigId` INT(11) NOT NULL AUTO_INCREMENT,
	`Deleted` BIT(1) NOT NULL DEFAULT b'0',
	`IsCollection` BIT(1) NOT NULL DEFAULT b'0',
	`DateAddedUtc` DATETIME NOT NULL DEFAULT utc_timestamp(6),
	`DateUpdatedUtc` DATETIME NOT NULL DEFAULT utc_timestamp(6),
	`ConfigType` VARCHAR(16) NOT NULL DEFAULT 'string' COLLATE 'utf8mb4_general_ci',
	`ConfigCategory` VARCHAR(256) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
	`ConfigKey` VARCHAR(128) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
	`ConfigValue` TEXT NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
	PRIMARY KEY (`ConfigId`) USING BTREE,
	INDEX `Deleted` (`Deleted`) USING BTREE,
	INDEX `IsCollection` (`IsCollection`) USING BTREE,
	INDEX `ConfigCategory` (`ConfigCategory`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB;
