--This query is for PostgresSQL
DROP TABLE IF EXISTS "product";
CREATE TABLE "public"."product"
(
    "Id"          integer     NOT NULL,
    "ProductName" text        NOT NULL,
    "CreatedDate" timestamptz NOT NULL,
    CONSTRAINT "product_Id" PRIMARY KEY ("Id")
) WITH (oids = false);

TRUNCATE "product";
INSERT INTO "product" ("Id", "ProductName", "CreatedDate")
VALUES (1, 'Mobile', '2019-08-02 16:59:04.772571+00'),
       (2, 'Laptop', '2019-08-02 16:59:16.698214+00');