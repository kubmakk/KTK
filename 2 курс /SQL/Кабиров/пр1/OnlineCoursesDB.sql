{\rtf1\ansi\ansicpg1252\cocoartf2867
\cocoatextscaling0\cocoaplatform0{\fonttbl\f0\fswiss\fcharset0 Helvetica;}
{\colortbl;\red255\green255\blue255;}
{\*\expandedcolortbl;;}
\margl1440\margr1440\vieww11520\viewh8400\viewkind0
\pard\tx566\tx1133\tx1700\tx2267\tx2834\tx3401\tx3968\tx4535\tx5102\tx5669\tx6236\tx6803\pardirnatural\partightenfactor0

\f0\fs24 \cf0 CREATE DATABASE OnlineCoursesDB;\
\
-- 1. \uc0\u1050 \u1072 \u1090 \u1077 \u1075 \u1086 \u1088 \u1080 \u1080  \u1082 \u1091 \u1088 \u1089 \u1086 \u1074 \
CREATE TABLE Categories (\
    category_id INT PRIMARY KEY AUTO_INCREMENT,\
    category_name VARCHAR(100) NOT NULL\
);\
\
-- 2. \uc0\u1048 \u1085 \u1089 \u1090 \u1088 \u1091 \u1082 \u1090 \u1086 \u1088 \u1099 \
CREATE TABLE Instructors (\
    instructor_id INT PRIMARY KEY AUTO_INCREMENT,\
    full_name VARCHAR(100) NOT NULL,\
    email VARCHAR(100) UNIQUE,\
    bio TEXT\
);\
\
-- 3. \uc0\u1055 \u1086 \u1083 \u1100 \u1079 \u1086 \u1074 \u1072 \u1090 \u1077 \u1083 \u1080  (\u1057 \u1090 \u1091 \u1076 \u1077 \u1085 \u1090 \u1099 )\
CREATE TABLE Users (\
    user_id INT PRIMARY KEY AUTO_INCREMENT,\
    username VARCHAR(50) NOT NULL,\
    email VARCHAR(100) UNIQUE NOT NULL,\
    created_at DATE\
);\
\
-- 4. \uc0\u1050 \u1091 \u1088 \u1089 \u1099  (\u1057 \u1074 \u1103 \u1079 \u1100  \u1089  \u1048 \u1085 \u1089 \u1090 \u1088 \u1091 \u1082 \u1090 \u1086 \u1088 \u1086 \u1084  \u1080  \u1050 \u1072 \u1090 \u1077 \u1075 \u1086 \u1088 \u1080 \u1077 \u1081 )\
CREATE TABLE Courses (\
    course_id INT PRIMARY KEY AUTO_INCREMENT,\
    title VARCHAR(150) NOT NULL,\
    price DECIMAL(10, 2),\
    instructor_id INT,\
    category_id INT,\
    FOREIGN KEY (instructor_id) REFERENCES Instructors(instructor_id),\
    FOREIGN KEY (category_id) REFERENCES Categories(category_id)\
);\
\
-- 5. \uc0\u1047 \u1072 \u1087 \u1080 \u1089 \u1080  \u1085 \u1072  \u1082 \u1091 \u1088 \u1089  (\u1057 \u1074 \u1103 \u1079 \u1100  \u1057 \u1090 \u1091 \u1076 \u1077 \u1085 \u1090 -\u1050 \u1091 \u1088 \u1089 )\
CREATE TABLE Enrollments (\
    enrollment_id INT PRIMARY KEY AUTO_INCREMENT,\
    user_id INT,\
    course_id INT,\
    enrollment_date DATE,\
    FOREIGN KEY (user_id) REFERENCES Users(user_id),\
    FOREIGN KEY (course_id) REFERENCES Courses(course_id)\
);\
\
-- 6. \uc0\u1054 \u1090 \u1079 \u1099 \u1074 \u1099 \
CREATE TABLE Reviews (\
    review_id INT PRIMARY KEY AUTO_INCREMENT,\
    course_id INT,\
    user_id INT,\
    rating INT CHECK (rating >= 1 AND rating <= 5),\
    comment TEXT,\
    FOREIGN KEY (course_id) REFERENCES Courses(course_id),\
    FOREIGN KEY (user_id) REFERENCES Users(user_id)\
);}