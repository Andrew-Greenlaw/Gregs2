-- Active: 1670981605080@@localhost@3306@local_schema

CREATE TABLE IF NOT EXISTS cars(
  id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  make VARCHAR(255) NOT NULL,
  model VARCHAR(255) NOT NULL,
  year int NOT NULL CHECK(year >= 1886),
  imgUrl VARCHAR(255) NOT NULL DEFAULT "https://www.autolist.com/assets/listings/default_car.jpg",
  price DECIMAL(10,2) NOT NULL CHECK(price >= 0),
  description VARCHAR(255),
  isSold TINYINT DEFAULT 0,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';