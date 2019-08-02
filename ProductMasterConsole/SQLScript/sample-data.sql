DROP TABLE IF EXISTS "product";
CREATE TABLE "public"."product"
(
    "Id"          integer     NOT NULL,
    "ProductName" text        NOT NULL,
    "CreatedDate" timestamptz NOT NULL
) WITH (oids = false);