{\rtf1\ansi\ansicpg1252\cocoartf2867
\cocoatextscaling0\cocoaplatform0{\fonttbl\f0\fswiss\fcharset0 Helvetica;}
{\colortbl;\red255\green255\blue255;}
{\*\expandedcolortbl;;}
\margl1440\margr1440\vieww11520\viewh8400\viewkind0
\pard\tx566\tx1133\tx1700\tx2267\tx2834\tx3401\tx3968\tx4535\tx5102\tx5669\tx6236\tx6803\pardirnatural\partightenfactor0

\f0\fs24 \cf0 CREATE DATABASE SchoolDB;\
\
CREATE TABLE Students (\
    student_id INT PRIMARY KEY,\
    first_name VARCHAR(50),\
    last_name VARCHAR(50),\
    birth_date DATE,\
    email VARCHAR(100)\
);\
\
CREATE TABLE Teachers (\
    teacher_id INT PRIMARY KEY,\
    first_name VARCHAR(50) NOT NULL,\
    last_name VARCHAR(50) NOT NULL,\
    hire_date DATE,\
    department VARCHAR(50)\
);\
\
CREATE TABLE Subjects (\
    subject_id INT PRIMARY KEY,\
    subject_name VARCHAR(100) NOT NULL,\
    description TEXT,\
    credits INT\
);\
\
CREATE TABLE Classes (\
    class_id INT PRIMARY KEY,\
    class_name VARCHAR(50) NOT NULL,\
    teacher_id INT,\
    subject_id INT,\
    room_number VARCHAR(10),\
    FOREIGN KEY (teacher_id) REFERENCES Teachers(teacher_id),\
    FOREIGN KEY (subject_id) REFERENCES Subjects(subject_id)\
);\
\
CREATE TABLE Enrollments (\
    enrollment_id INT PRIMARY KEY,\
    student_id INT, -- \uc0\u1048 \u1089 \u1087 \u1088 \u1072 \u1074 \u1083 \u1077 \u1085 \u1086 : \u1090 \u1080 \u1087  \u1076 \u1072 \u1085 \u1085 \u1099 \u1093  \u1076 \u1086 \u1083 \u1078 \u1077 \u1085  \u1089 \u1086 \u1074 \u1087 \u1072 \u1076 \u1072 \u1090 \u1100  \u1089  Students.student_id\
    class_id INT,\
    enrollment_date DATE,\
    FOREIGN KEY (student_id) REFERENCES Students(student_id),\
    FOREIGN KEY (class_id) REFERENCES Classes(class_id)\
);\
\
CREATE TABLE Grades (\
    grade_id INT PRIMARY KEY,\
    enrollment_id INT,\
    grade_value DECIMAL(3,2),\
    grade_date DATE,\
    FOREIGN KEY (enrollment_id) REFERENCES Enrollments(enrollment_id)\
);\
\
CREATE TABLE Attendance (\
    attendance_id INT PRIMARY KEY,\
    enrollment_id INT,\
    date DATE,\
    status VARCHAR(20),\
    FOREIGN KEY (enrollment_id) REFERENCES Enrollments(enrollment_id)\
);\
\
CREATE TABLE Departments (\
    department_id INT PRIMARY KEY,\
    department_name VARCHAR(100) NOT NULL,\
    head_teacher_id INT,\
    FOREIGN KEY (head_teacher_id) REFERENCES Teachers(teacher_id)\
);\
\
CREATE TABLE SchoolEvents (\
    event_id INT PRIMARY KEY,\
    event_name VARCHAR(100) NOT NULL,\
    event_date DATE,\
    organizer_teacher_id INT,\
    location VARCHAR(100), -- \uc0\u1044 \u1086 \u1073 \u1072 \u1074 \u1083 \u1077 \u1085 \u1072  \u1079 \u1072 \u1087 \u1103 \u1090 \u1072 \u1103  \u1080  \u1076 \u1083 \u1080 \u1085 \u1072  VARCHAR\
    FOREIGN KEY (organizer_teacher_id) REFERENCES Teachers(teacher_id)\
);\
\
CREATE TABLE ParentContacts (\
    contact_id INT PRIMARY KEY,\
    student_id INT,\
    parent_name VARCHAR(100),\
    phone VARCHAR(20),\
    email VARCHAR(100),\
    relationship VARCHAR(50),\
    FOREIGN KEY (student_id) REFERENCES Students(student_id)\
);}