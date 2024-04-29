DROP SCHEMA stage;

CREATE SCHEMA stage AUTHORIZATION postgres;

stage.multistore definition

DROP TABLE stage.multistore;

CREATE TABLE stage.multistore (
	id int4 NOT NULL,
	order_id varchar(50) NULL,
	order_date date NULL,
	ship_date date NULL,
	ship_mode varchar(50) NULL,
	customer_id varchar(50) NULL,
	customer_name varchar(200) NULL,
	customer_age int4 NULL,
	customer_birthday varchar(10) NULL,
	customer_state bool NULL,
	segment varchar(50) NULL,
	country varchar(50) NULL,
	city varchar(100) NULL,
	state varchar(50) NULL,
	regional_manager_id varchar(50) NULL,
	regional_manager varchar(100) NULL,
	postal_code varchar(20) NULL,
	region varchar(50) NULL,
	product_id varchar(50) NULL,
	category varchar(50) NULL,
	sub_category varchar(50) NULL,
	product_name varchar(200) NULL,
	sales numeric(10, 2) NULL,
	quantity int4 NULL,
	discount numeric(5, 2) NULL,
	profit numeric(10, 2) NULL,
	CONSTRAINT multistore_pkey PRIMARY KEY (id)
);