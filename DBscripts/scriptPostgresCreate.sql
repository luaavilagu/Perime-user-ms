
\connect perime-user-db

CREATE TABLE public."Users"
(
  "id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
  "username" text,
  "passhash" text,
  "address" text,
  "cellphone" bigint NOT NULL,
  "email" text,
  CONSTRAINT "PK_Users" PRIMARY KEY ("id")
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public."Users"
  OWNER TO postgresuser;

