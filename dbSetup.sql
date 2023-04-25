CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8mb4 COMMENT '';

CREATE TABLE
    IF NOT EXISTS cars(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'primary key',
        make VARCHAR(255) NOT NULL,
        model VARCHAR(255) NOT NULL,
        price MEDIUMINT NOT NULL,
        year SMALLINT NOT NULL DEFAULT 1990,
        hasTires BOOLEAN NOT NULL DEFAULT true,
        createdAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
        updatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
        color VARCHAR(8) DEFAULT '#FFFFFF'
    ) default charset utf8mb4 COMMENT 'emojis enabled 🦞';

INSERT INTO
    cars(
        make,
        model,
        price,
        year,
        hasTires,
        color
    )
values (
        'mazda',
        'miata',
        5000,
        2005,
        true,
        DEFAULT
    );

INSERT INTO
    cars(
        make,
        model,
        price,
        year,
        hasTires
    )
values (
        'mazda',
        'miata',
        5000,
        2005,
        true
    ), (
        'subaru',
        'impreza',
        13000,
        2013,
        true
    );

SELECT * FROM cars ORDER BY price DESC LIMIT 1;

SELECT * FROM cars WHERE make = 'mazda' AND model = 'miata';

SELECT * FROM cars WHERE id = 4;

UPDATE cars SET model = 'rx-7', color = '#000000' WHERE id = 4;

DELETE FROM cars WHERE id = 1 ;

CREATE TABLE
    IF NOT EXISTS houses(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'primary key',
        bathrooms SMALLINT NOT NULL,
        bedrooms SMALLINT NOT NULL,
        imgUrl VARCHAR(255) NOT NULL,
        levels SMALLINT NOT NULL,
        price MEDIUMINT NOT NULL
    ) default charset utf8mb4 COMMENT 'emojis enabled 🦞';

INSERT INTO
    houses (
        bathrooms,
        bedrooms,
        imgUrl,
        levels,
        price
    )
VALUES (
        2,
        4,
        "https://www.rocketmortgage.com/resources-cmsassets/RocketMortgage.com/Article_Images/Large_Images/TypesOfHomes/types-of-homes-hero.jpg",
        2,
        300000
    ), (
        4,
        8,
        "https://img.staticmb.com/mbcontent//images/uploads/2022/12/Most-Beautiful-House-in-the-World.jpg",
        4,
        1600000
    ), (
        1,
        2,
        "https://town-n-country-living.com/wp-content/uploads/2015/01/farmhouse-exterior.jpg",
        1,
        150000
    );

SELECT * FROM houses ORDER BY price DESC LIMIT 1;

SELECT * FROM houses WHERE bathrooms = 2 AND bedrooms = 4;

SELECT * FROM houses WHERE id = 2 ;

UPDATE houses
SET
    bathrooms = 3,
    bedrooms = 5,
    levels = 3
WHERE id = 1;

-- DELETE FROM cars WHERE id = 1 ;

DELETE FROM houses WHERE id = 3;

DROP TABLE cars;