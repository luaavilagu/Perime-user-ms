
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



INSERT INTO "Users" ("id", "address", "cellphone", "email", "passhash", "username") 
VALUES (10001, 'Address1', 1, 'Email1', 'Passhash1', 'Username1');
INSERT INTO "Users" ("id", "address", "cellphone", "email", "passhash", "username")
VALUES (20001, 'Address2', 2, 'Email1', 'Passhash2', 'Username2');
