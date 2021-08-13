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
"ContactPhoneNumber" INTEGER
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
"Duration" TIME
);
