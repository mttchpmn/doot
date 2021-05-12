﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    migration_id character varying(150) NOT NULL,
    product_version character varying(32) NOT NULL,
    CONSTRAINT pk___ef_migrations_history PRIMARY KEY (migration_id)
);

START TRANSACTION;

CREATE TABLE todos (
    id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    title text NULL,
    description text NULL,
    completed boolean NOT NULL,
    CONSTRAINT pk_todos PRIMARY KEY (id)
);

INSERT INTO "__EFMigrationsHistory" (migration_id, product_version)
VALUES ('20210512064359_InitialCreate', '5.0.6');

COMMIT;

