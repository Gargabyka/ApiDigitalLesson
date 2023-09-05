CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Moderators" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Surname" text NOT NULL,
    "MiddleName" text NOT NULL,
    "Phone" text NULL,
    "Email" text NOT NULL,
    "DateBirthday" timestamp with time zone NULL,
    "UserId" uuid NOT NULL,
    "IsDelete" boolean NOT NULL,
    CONSTRAINT "PK_Moderators" PRIMARY KEY ("Id")
);

CREATE TABLE "SettingsStudent" (
    "Id" uuid NOT NULL,
    "IsAllowCreateLesson" boolean NOT NULL,
    "IsNotificationTelegram" boolean NOT NULL,
    "IsRequestForLessonTelegram" boolean NOT NULL,
    "IsAcceptForLessonTelegram" boolean NOT NULL,
    "IsCancelLessonTelegram" boolean NOT NULL,
    "IsLessonComingSoonTelegram" boolean NOT NULL,
    "TimeBeforeLesson" integer NOT NULL,
    "IsNotificationEmail" boolean NOT NULL,
    "IsRequestForLessonEmail" boolean NOT NULL,
    "IsAcceptForLessonEmail" boolean NOT NULL,
    "IsCancelLessonEmail" boolean NOT NULL,
    "IsLessonComingSoonEmail" boolean NOT NULL,
    CONSTRAINT "PK_SettingsStudent" PRIMARY KEY ("Id")
);

CREATE TABLE "SettingsTeacher" (
    "Id" uuid NOT NULL,
    "TimeCancelLesson" integer NOT NULL,
    "TimeCreateLesson" integer NOT NULL,
    "IsAllowCreateLesson" boolean NOT NULL,
    "IsNotificationTelegram" boolean NOT NULL,
    "IsRequestForLessonTelegram" boolean NOT NULL,
    "IsAcceptForLessonTelegram" boolean NOT NULL,
    "IsCancelLessonTelegram" boolean NOT NULL,
    "IsLessonComingSoonTelegram" boolean NOT NULL,
    "TimeBeforeLesson" integer NOT NULL,
    "IsNotificationEmail" boolean NOT NULL,
    "IsRequestForLessonEmail" boolean NOT NULL,
    "IsAcceptForLessonEmail" boolean NOT NULL,
    "IsCancelLessonEmail" boolean NOT NULL,
    "IsLessonComingSoonEmail" boolean NOT NULL,
    CONSTRAINT "PK_SettingsTeacher" PRIMARY KEY ("Id")
);

CREATE TABLE "TypeLessons" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Description" text NULL,
    "ParentId" uuid NULL,
    CONSTRAINT "PK_TypeLessons" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_TypeLessons_TypeLessons_ParentId" FOREIGN KEY ("ParentId") REFERENCES "TypeLessons" ("Id")
);

CREATE TABLE "Students" (
    "Id" uuid NOT NULL,
    "SettingsStudentId" uuid NOT NULL,
    "Name" text NOT NULL,
    "Surname" text NOT NULL,
    "MiddleName" text NOT NULL,
    "Phone" text NULL,
    "Email" text NOT NULL,
    "TelegramId" bigint NULL,
    "Description" text NULL,
    "DateBirthday" timestamp with time zone NULL,
    "UserId" uuid NOT NULL,
    CONSTRAINT "PK_Students" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Students_SettingsStudent_SettingsStudentId" FOREIGN KEY ("SettingsStudentId") REFERENCES "SettingsStudent" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Teacher" (
    "Id" uuid NOT NULL,
    "Photo" bytea NULL,
    "SettingsTeacherId" uuid NOT NULL,
    "Name" text NOT NULL,
    "Surname" text NOT NULL,
    "MiddleName" text NOT NULL,
    "Phone" text NULL,
    "Email" text NOT NULL,
    "TelegramId" bigint NULL,
    "Description" text NULL,
    "DateBirthday" timestamp with time zone NULL,
    "UserId" uuid NOT NULL,
    CONSTRAINT "PK_Teacher" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Teacher_SettingsTeacher_SettingsTeacherId" FOREIGN KEY ("SettingsTeacherId") REFERENCES "SettingsTeacher" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AboutTeacher" (
    "Id" uuid NOT NULL,
    "TeacherId" uuid NOT NULL,
    "Name" text NULL,
    "Rating" integer NOT NULL,
    "CreateDate" timestamp with time zone NOT NULL,
    "Comment" text NOT NULL,
    CONSTRAINT "PK_AboutTeacher" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_AboutTeacher_Teacher_TeacherId" FOREIGN KEY ("TeacherId") REFERENCES "Teacher" ("Id") ON DELETE CASCADE
);

CREATE TABLE "TeacherTypeLesson" (
    "Id" uuid NOT NULL,
    "TeacherId" uuid NOT NULL,
    "TypeLessonsId" uuid NOT NULL,
    "IsOnline" boolean NOT NULL,
    "IsOffline" boolean NOT NULL,
    "IsGroup" boolean NOT NULL,
    "IsSingle" boolean NOT NULL,
    "Description" text NULL,
    "Price" numeric NOT NULL,
    CONSTRAINT "PK_TeacherTypeLesson" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_TeacherTypeLesson_Teacher_TeacherId" FOREIGN KEY ("TeacherId") REFERENCES "Teacher" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_TeacherTypeLesson_TypeLessons_TypeLessonsId" FOREIGN KEY ("TypeLessonsId") REFERENCES "TypeLessons" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Violators" (
    "Id" uuid NOT NULL,
    "TeacherId" uuid NULL,
    "StudentId" uuid NULL,
    "DateCreatedViolator" timestamp with time zone NOT NULL,
    "Comment" text NOT NULL,
    "UserId" uuid NOT NULL,
    "IsBanned" boolean NOT NULL,
    "IsCancel" boolean NOT NULL,
    "DateBan" timestamp with time zone NULL,
    "StudentsId" uuid NOT NULL,
    CONSTRAINT "PK_Violators" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Violators_Students_StudentsId" FOREIGN KEY ("StudentsId") REFERENCES "Students" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Violators_Teacher_TeacherId" FOREIGN KEY ("TeacherId") REFERENCES "Teacher" ("Id")
);

CREATE TABLE "GroupLesson" (
    "Id" uuid NOT NULL,
    "GroupName" text NOT NULL,
    "MaxQuantityStudents" integer NOT NULL,
    "TeacherTypeLessonId" uuid NOT NULL,
    "IsCancel" boolean NOT NULL,
    "CancelMessage" text NULL,
    "IsFinish" boolean NOT NULL,
    "IsConfirmedForTeacher" boolean NOT NULL,
    "IsConfirmedForStudent" boolean NOT NULL,
    CONSTRAINT "PK_GroupLesson" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_GroupLesson_TeacherTypeLesson_TeacherTypeLessonId" FOREIGN KEY ("TeacherTypeLessonId") REFERENCES "TeacherTypeLesson" ("Id") ON DELETE CASCADE
);

CREATE TABLE "SingleLesson" (
    "Id" uuid NOT NULL,
    "StudentsId" uuid NOT NULL,
    "TeacherTypeLessonId" uuid NOT NULL,
    "IsCancel" boolean NOT NULL,
    "CancelMessage" text NULL,
    "IsFinish" boolean NOT NULL,
    "IsConfirmedForTeacher" boolean NOT NULL,
    "IsConfirmedForStudent" boolean NOT NULL,
    CONSTRAINT "PK_SingleLesson" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_SingleLesson_Students_StudentsId" FOREIGN KEY ("StudentsId") REFERENCES "Students" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_SingleLesson_TeacherTypeLesson_TeacherTypeLessonId" FOREIGN KEY ("TeacherTypeLessonId") REFERENCES "TeacherTypeLesson" ("Id") ON DELETE CASCADE
);

CREATE TABLE "GroupLessonStudents" (
    "Id" uuid NOT NULL,
    "GroupId" uuid NOT NULL,
    "StudentsId" uuid NOT NULL,
    CONSTRAINT "PK_GroupLessonStudents" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_GroupLessonStudents_GroupLesson_GroupId" FOREIGN KEY ("GroupId") REFERENCES "GroupLesson" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_GroupLessonStudents_Students_StudentsId" FOREIGN KEY ("StudentsId") REFERENCES "Students" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Schedulers" (
    "Id" uuid NOT NULL,
    "TeacherId" uuid NOT NULL,
    "SingleLessonId" uuid NULL,
    "GroupLessonId" uuid NULL,
    "IsWeekend" boolean NOT NULL,
    "Description" text NOT NULL,
    "DateStart" timestamp with time zone NOT NULL,
    "DateEnd" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Schedulers" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Schedulers_GroupLesson_GroupLessonId" FOREIGN KEY ("GroupLessonId") REFERENCES "GroupLesson" ("Id"),
    CONSTRAINT "FK_Schedulers_SingleLesson_SingleLessonId" FOREIGN KEY ("SingleLessonId") REFERENCES "SingleLesson" ("Id"),
    CONSTRAINT "FK_Schedulers_Teacher_TeacherId" FOREIGN KEY ("TeacherId") REFERENCES "Teacher" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_AboutTeacher_TeacherId" ON "AboutTeacher" ("TeacherId");

CREATE INDEX "IX_GroupLesson_TeacherTypeLessonId" ON "GroupLesson" ("TeacherTypeLessonId");

CREATE INDEX "IX_GroupLessonStudents_GroupId" ON "GroupLessonStudents" ("GroupId");

CREATE INDEX "IX_GroupLessonStudents_StudentsId" ON "GroupLessonStudents" ("StudentsId");

CREATE INDEX "IX_Schedulers_GroupLessonId" ON "Schedulers" ("GroupLessonId");

CREATE INDEX "IX_Schedulers_SingleLessonId" ON "Schedulers" ("SingleLessonId");

CREATE INDEX "IX_Schedulers_TeacherId" ON "Schedulers" ("TeacherId");

CREATE INDEX "IX_SingleLesson_StudentsId" ON "SingleLesson" ("StudentsId");

CREATE INDEX "IX_SingleLesson_TeacherTypeLessonId" ON "SingleLesson" ("TeacherTypeLessonId");

CREATE INDEX "IX_Students_SettingsStudentId" ON "Students" ("SettingsStudentId");

CREATE INDEX "IX_Teacher_SettingsTeacherId" ON "Teacher" ("SettingsTeacherId");

CREATE INDEX "IX_TeacherTypeLesson_TeacherId" ON "TeacherTypeLesson" ("TeacherId");

CREATE INDEX "IX_TeacherTypeLesson_TypeLessonsId" ON "TeacherTypeLesson" ("TypeLessonsId");

CREATE INDEX "IX_TypeLessons_ParentId" ON "TypeLessons" ("ParentId");

CREATE INDEX "IX_Violators_StudentsId" ON "Violators" ("StudentsId");

CREATE INDEX "IX_Violators_TeacherId" ON "Violators" ("TeacherId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230901143647_Initial', '6.0.1');

COMMIT;

