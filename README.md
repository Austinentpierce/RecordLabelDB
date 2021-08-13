# RecordLabelDB

CREATE TABLE "Band" (
"Id" PRIMARY SERIAL KEY,
"Name" TEXT,
"CountryOfOrigin" TEXT,
"NumberOfMembers" INTEGER,
"Website" TEXT,
"Style" TEXT,
"IsSigned" TEXT,
"ContactName" TEXT,
"ContactPhoneNumber" TYPE VARCHAR(12)
);

CREATE TABLE "Album" (
"Id" SERIAL PRIMARY KEY,
"Title" TEXT,
"IsExplicit" BOOLEAN,
"ReleaseDate" DATE,
"BandId" INTEGER NULL REFERENCES "Band" ("Id")
);

CREATE TABLE "Songs" (
"Id" SERIAL PRIMARY KEY,
"TrackNumber" INTEGER,
"Title" TEXT,
"Duration" TIME,
"AlbumId" INTEGER NULL REFERENCES "Album" ("Id")
);

INSERT INTO "Band" ("Name", "CountryOfOrigin","NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber")
VALUES ('Bone Thugs And Harmony', 'USA', '5', 'BoneThugs.com', 'HipHop', true, 'Austin Pierce', '813-431-7570');

SELECT \* FROM "Band";

INSERT INTO "Album" ("Title", "IsExplicit", "ReleaseDate")
VALUES ('E. 1999 Eternal', true, '07/25/95');

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumId")
VALUES ('1', 'East 1999', '00:04:22', '1' );
