-- Active: 1669828541873@@localhost@3306@local_schema

CREATE TABLE IF NOT EXISTS cars(
  id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
  make VARCHAR(255) NOT NULL,
  model VARCHAR(255) NOT NULL,
  year int NOT NULL CHECK(year >= 1886),
  imgUrl VARCHAR(255) NOT NULL DEFAULT "https://www.autolist.com/assets/listings/default_car.jpg",
  price DECIMAL(10,2) NOT NULL CHECK(price >= 0),
  description VARCHAR(255)
)