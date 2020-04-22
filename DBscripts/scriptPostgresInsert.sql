
\connect perime-user-db

CREATE TABLE public."Users"
(
  id integer NOT NULL SERIAL,
  username text,
  passhash text,
  address text,
  cellphone bigint NOT NULL,
  email text,
  CONSTRAINT "PK_Users" PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public."Users"
  OWNER TO postgresuser;




----------- COPY SEED.SQL 21/04/2020

\connect perime-user-db

CREATE TABLE public."Users"
(
  id integer NULL GENERATED BY DEFAULT AS IDENTITY,
  username text,
  passhash text,
  address text,
  cellphone bigint NOT NULL,
  email text,
  CONSTRAINT "PK_Users" PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public."Users"
  OWNER TO postgresuser;


CREATE SEQUENCE public."Users_id_seq"
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9999
  START 1
  CACHE 0;
ALTER TABLE public."Users_id_seq"
  OWNER TO postgresuser;
  
  ----------------- FUNCIONA PARA CONTAINER

  CREATE TABLE "Users"
(
  id integer NULL GENERATED BY DEFAULT AS IDENTITY,
  username text,
  passhash text,
  address text,
  cellphone bigint NOT NULL,
  email text,
  CONSTRAINT "PK_Users" PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE "Users"
  OWNER TO postgresuser;

