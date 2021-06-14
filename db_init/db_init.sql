CREATE DATABASE musichubdb;
\connect musichubdb

GRANT ALL PRIVILEGES ON DATABASE musichubdb to admin;
grant all on schema public to public;
GRANT CONNECT ON DATABASE musichubdb TO admin;
GRANT USAGE ON SCHEMA public TO admin;
GRANT SELECT ON ALL TABLES IN SCHEMA public TO admin;



CREATE TABLE Users(Id UUID Primary KEY, Login VARCHAR(100) NOT NULL, Password VARCHAR(100) NOT NULL);
CREATE TABLE Reports(id UUID PRIMARY KEY, file_id UUID NOT NULL, file_name VARCHAR(100) NOT NULL, task_id UUID NOT NULL, is_plagiarism boolean NOT NULL, process_date TIMESTAMP);

INSERT INTO Users VALUES ('eb88b77e-2259-4a0c-b109-35d1260e0b51', 'admin', 'admin');

INSERT INTO Reports VALUES ('4e2cba6f-431c-4d02-9e72-4f68d75f44c0', 'd2ee457f-c3d0-43de-a425-169da07f76eb', 'name3.cs', '8bdbf228-38fc-4fb4-9c6b-ee5a332f8dd3', true, '04/11/2021 13:18:51');