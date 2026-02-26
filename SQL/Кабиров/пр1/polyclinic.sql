drop database PolyclinicDB;
create database PolyclinicDB;
use PolyclinicDB;

create table Specializations (
    specialization_id int primary key auto_increment,
    spec_name varchar(100) NOT NULL
);

create table Doctors (
    doctor_id int primary key auto_increment,
    first_name varchar(50) NOT NULL,
    last_name varchar(50) NOT NULL,
    specialization_id int,
    phone varchar(20),
    foreign key (specialization_id) references Specializations(specialization_id)
);

create table Patients (
    patient_id int primary key auto_increment,
    first_name varchar(50) NOT NULL,
    last_name varchar(50) NOT NULL,
    birth_date DATE NOT NULL,
    insurance_policy_num varchar(50),
    address TEXT
);

create table Appointments (
    appointment_id int primary key auto_increment,
    doctor_id int,
    patient_id int,
    appointment_date DATETIME NOT NULL,
    office_number varchar(10),
    foreign key (doctor_id) references Doctors(doctor_id),
    foreign key (patient_id) references Patients(patient_id)
);

create table DiagnosesList (
    diagnosis_code varchar(10) primary key,
    diagnosis_name varchar(255) NOT NULL
);

create table MedicalRecords (
    record_id int primary key auto_increment,
    appointment_id int,
    diagnosis_code varchar(10),
    treatment_notes TEXT,
    foreign key (appointment_id) references Appointments(appointment_id),
    foreign key (diagnosis_code) references DiagnosesList(diagnosis_code)
);