{\rtf1\ansi\ansicpg1252\cocoartf2867
\cocoatextscaling0\cocoaplatform0{\fonttbl\f0\fswiss\fcharset0 Helvetica;}
{\colortbl;\red255\green255\blue255;}
{\*\expandedcolortbl;;}
\margl1440\margr1440\vieww11520\viewh8400\viewkind0
\pard\tx566\tx1133\tx1700\tx2267\tx2834\tx3401\tx3968\tx4535\tx5102\tx5669\tx6236\tx6803\pardirnatural\partightenfactor0

\f0\fs24 \cf0 create database Steam;\
use Steam;\
\
-- 1. \uc0\u1057 \u1085 \u1072 \u1095 \u1072 \u1083 \u1072  \u1089 \u1086 \u1079 \u1076 \u1072 \u1077 \u1084  \u1085 \u1077 \u1079 \u1072 \u1074 \u1080 \u1089 \u1080 \u1084 \u1099 \u1077  \u1090 \u1072 \u1073 \u1083 \u1080 \u1094 \u1099  (\u1085 \u1072  \u1082 \u1086 \u1090 \u1086 \u1088 \u1099 \u1077  \u1073 \u1091 \u1076 \u1091 \u1090  \u1089 \u1089 \u1099 \u1083 \u1072 \u1090 \u1100 \u1089 \u1103  \u1076 \u1088 \u1091 \u1075 \u1080 \u1077 )\
create table AccountP (\
    account_id INT PRIMARY KEY AUTO_INCREMENT,\
    username VARCHAR(50) UNIQUE NOT NULL,\
    email VARCHAR(100) UNIQUE NOT NULL,\
    password_hash VARCHAR(255) NOT NULL,\
    created_date DATE NOT NULL,\
    country VARCHAR(10),\
    level INT DEFAULT 0\
);\
\
-- \uc0\u1055 \u1077 \u1088 \u1077 \u1085 \u1077 \u1089 \u1083 \u1080  \u1090 \u1072 \u1073 \u1083 \u1080 \u1094 \u1091  Game \u1085 \u1072 \u1074 \u1077 \u1088 \u1093 , \u1090 \u1072 \u1082  \u1082 \u1072 \u1082  \u1086 \u1085 \u1072  \u1085 \u1091 \u1078 \u1085 \u1072  \u1076 \u1083 \u1103  Library \u1080  Reviews\
create table Game (\
    game_id INT PRIMARY KEY AUTO_INCREMENT,\
    name VARCHAR(200) NOT NULL,\
    developer VARCHAR(100),\
    publisher VARCHAR(100),\
    release_date DATE,\
    price DECIMAL(10,2) DEFAULT 0,\
    genre VARCHAR(50),\
    system_requirements TEXT\
);\
\
create table support (\
    support_id INT PRIMARY KEY AUTO_INCREMENT,\
    category_name VARCHAR(100) NOT NULL UNIQUE,\
    description TEXT\
);\
\
-- 2. \uc0\u1058 \u1077 \u1087 \u1077 \u1088 \u1100  \u1089 \u1086 \u1079 \u1076 \u1072 \u1077 \u1084  \u1090 \u1072 \u1073 \u1083 \u1080 \u1094 \u1099 , \u1082 \u1086 \u1090 \u1086 \u1088 \u1099 \u1077  \u1080 \u1084 \u1077 \u1102 \u1090  \u1074 \u1085 \u1077 \u1096 \u1085 \u1080 \u1077  \u1082 \u1083 \u1102 \u1095 \u1080  (Foreign Keys)\
\
create table Library (\
    library_id INT PRIMARY KEY AUTO_INCREMENT,\
    account_id INT,\
    game_id INT,\
    purchase_date DATE,\
    playtime_hours DECIMAL(10,2) DEFAULT 0,\
    FOREIGN KEY (account_id) REFERENCES AccountP(account_id),\
    FOREIGN KEY (game_id) REFERENCES Game(game_id),\
    UNIQUE(account_id, game_id) -- \uc0\u1061 \u1086 \u1088 \u1086 \u1096 \u1077 \u1077  \u1086 \u1075 \u1088 \u1072 \u1085 \u1080 \u1095 \u1077 \u1085 \u1080 \u1077 , \u1095 \u1090 \u1086 \u1073 \u1099  \u1080 \u1075 \u1088 \u1091  \u1085 \u1077 \u1083 \u1100 \u1079 \u1103  \u1073 \u1099 \u1083 \u1086  \u1082 \u1091 \u1087 \u1080 \u1090 \u1100  \u1076 \u1074 \u1072 \u1078 \u1076 \u1099 \
);\
\
create table Reviews (\
    review_id INT PRIMARY KEY AUTO_INCREMENT,\
    account_id INT,\
    game_id INT,\
    rating INT CHECK (rating >= 1 AND rating <= 10),\
    review_text TEXT,\
    review_date DATETIME DEFAULT CURRENT_TIMESTAMP,\
    helpful_count INT DEFAULT 0,\
    FOREIGN KEY (account_id) REFERENCES AccountP(account_id),\
    FOREIGN KEY (game_id) REFERENCES Game(game_id)\
);\
\
create table Awards (\
    award_id INT PRIMARY KEY AUTO_INCREMENT,\
    game_id INT,\
    account_id INT, -- \uc0\u1044 \u1054 \u1041 \u1040 \u1042 \u1051 \u1045 \u1053 \u1054 : \u1085 \u1091 \u1078 \u1085 \u1086  \u1079 \u1085 \u1072 \u1090 \u1100 , \u1082 \u1090 \u1086  \u1087 \u1086 \u1083 \u1091 \u1095 \u1080 \u1083  \u1076 \u1086 \u1089 \u1090 \u1080 \u1078 \u1077 \u1085 \u1080 \u1077 \
    award_name VARCHAR(200) NOT NULL,\
    awarded_date DATE,\
    FOREIGN KEY (game_id) REFERENCES Game(game_id),\
    FOREIGN KEY (account_id) REFERENCES AccountP(account_id) -- \uc0\u1044 \u1054 \u1041 \u1040 \u1042 \u1051 \u1045 \u1053 \u1054 : \u1089 \u1074 \u1103 \u1079 \u1100  \u1089  \u1080 \u1075 \u1088 \u1086 \u1082 \u1086 \u1084 \
);\
\
create table Wallet (\
    wallet_id INT PRIMARY KEY AUTO_INCREMENT,\
    account_id INT UNIQUE,\
    balance DECIMAL(10,2) DEFAULT 0,\
    currency VARCHAR(3) DEFAULT 'USD',\
    FOREIGN KEY (account_id) REFERENCES AccountP(account_id)\
);\
\
create table tickets (\
    ticket_id INT PRIMARY KEY AUTO_INCREMENT,\
    account_id INT,\
    support_id INT,\
    subject VARCHAR(200) NOT NULL,\
    description TEXT NOT NULL,\
    status ENUM('open', 'in_progress', 'closed') DEFAULT 'open',\
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,\
    resolved_date DATETIME NULL,\
    FOREIGN KEY (account_id) REFERENCES AccountP(account_id),\
    FOREIGN KEY (support_id) REFERENCES support(support_id)\
);}