-- Active: 1670981605080@@localhost@3306@local_schema
CREATE TABLE IF NOT EXISTS jobs(
  id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  company VARCHAR(255) NOT NULL,
  jobTitle VARCHAR(255)NOT NULL,
  hours int CHECK(hours >= 0),
  rate int CHECK(rate >= 0) NOT NULL,
  description VARCHAR(255) NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';