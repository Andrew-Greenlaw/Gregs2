-- Active: 1669828541873@@localhost@3306
CREATE TABLE IF NOT EXISTS houses(
  id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  bedrooms int NOT NULL CHECK(bedrooms >= 0),
  bathrooms int NOT NULL CHECK(bathrooms >= 0),
  levels int NOT NULL CHECK(levels >= 0),
  imgUrl VARCHAR(255) NOT NULL,
  price int NOT NULL CHECK(price >= 0),
  description VARCHAR(255),
  isSold TINYINT DEFAULT 0,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';