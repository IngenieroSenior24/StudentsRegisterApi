CREATE TABLE IF NOT EXISTS `_MigrationHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK__MigrationHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `_MigrationHistory` WHERE `MigrationId` = '20240614002038_Initial') THEN

    ALTER DATABASE CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `_MigrationHistory` WHERE `MigrationId` = '20240614002038_Initial') THEN

    CREATE TABLE `Professor` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
        `DeletedOn` datetime(6) NULL,
        `CreatedOn` datetime(6) NOT NULL,
        `LastModifiedOn` datetime(6) NOT NULL,
        CONSTRAINT `PK_Professor` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `_MigrationHistory` WHERE `MigrationId` = '20240614002038_Initial') THEN

    CREATE TABLE `Student` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
        `Identification` longtext CHARACTER SET utf8mb4 NOT NULL,
        `DeletedOn` datetime(6) NULL,
        `CreatedOn` datetime(6) NOT NULL,
        `LastModifiedOn` datetime(6) NOT NULL,
        CONSTRAINT `PK_Student` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `_MigrationHistory` WHERE `MigrationId` = '20240614002038_Initial') THEN

    CREATE TABLE `Subjects` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
        `Credits` int NOT NULL,
        `DeletedOn` datetime(6) NULL,
        `CreatedOn` datetime(6) NOT NULL,
        `LastModifiedOn` datetime(6) NOT NULL,
        CONSTRAINT `PK_Subjects` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `_MigrationHistory` WHERE `MigrationId` = '20240614002038_Initial') THEN

    CREATE TABLE `ProfessorSubject` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `ProfessorId` char(36) COLLATE ascii_general_ci NOT NULL,
        `SubjectId` char(36) COLLATE ascii_general_ci NOT NULL,
        `DeletedOn` datetime(6) NULL,
        `CreatedOn` datetime(6) NOT NULL,
        `LastModifiedOn` datetime(6) NOT NULL,
        CONSTRAINT `PK_ProfessorSubject` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_ProfessorSubject_Professor_ProfessorId` FOREIGN KEY (`ProfessorId`) REFERENCES `Professor` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_ProfessorSubject_Subjects_SubjectId` FOREIGN KEY (`SubjectId`) REFERENCES `Subjects` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `_MigrationHistory` WHERE `MigrationId` = '20240614002038_Initial') THEN

    CREATE TABLE `StudentSubject` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `StudentId` char(36) COLLATE ascii_general_ci NOT NULL,
        `SubjectId` char(36) COLLATE ascii_general_ci NOT NULL,
        `ProfessorId` char(36) COLLATE ascii_general_ci NOT NULL,
        `DeletedOn` datetime(6) NULL,
        `CreatedOn` datetime(6) NOT NULL,
        `LastModifiedOn` datetime(6) NOT NULL,
        CONSTRAINT `PK_StudentSubject` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_StudentSubject_Professor_ProfessorId` FOREIGN KEY (`ProfessorId`) REFERENCES `Professor` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_StudentSubject_Student_StudentId` FOREIGN KEY (`StudentId`) REFERENCES `Student` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_StudentSubject_Subjects_SubjectId` FOREIGN KEY (`SubjectId`) REFERENCES `Subjects` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `_MigrationHistory` WHERE `MigrationId` = '20240614002038_Initial') THEN

    CREATE INDEX `IX_ProfessorSubject_ProfessorId` ON `ProfessorSubject` (`ProfessorId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `_MigrationHistory` WHERE `MigrationId` = '20240614002038_Initial') THEN

    CREATE INDEX `IX_ProfessorSubject_SubjectId` ON `ProfessorSubject` (`SubjectId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `_MigrationHistory` WHERE `MigrationId` = '20240614002038_Initial') THEN

    CREATE INDEX `IX_StudentSubject_ProfessorId` ON `StudentSubject` (`ProfessorId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `_MigrationHistory` WHERE `MigrationId` = '20240614002038_Initial') THEN

    CREATE INDEX `IX_StudentSubject_StudentId` ON `StudentSubject` (`StudentId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `_MigrationHistory` WHERE `MigrationId` = '20240614002038_Initial') THEN

    CREATE INDEX `IX_StudentSubject_SubjectId` ON `StudentSubject` (`SubjectId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `_MigrationHistory` WHERE `MigrationId` = '20240614002038_Initial') THEN

    INSERT INTO `_MigrationHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20240614002038_Initial', '8.0.30');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

