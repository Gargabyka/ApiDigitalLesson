﻿// <auto-generated />
using System;
using ApiDigitalLesson.Migrator.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiDigitalLesson.Migrator.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.AboutTeacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("AboutTeacher");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.Cities", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.GroupLesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CancelMessage")
                        .HasColumnType("text");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsCancel")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsConfirmedForStudent")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsConfirmedForTeacher")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsFinish")
                        .HasColumnType("boolean");

                    b.Property<int>("MaxQuantityStudents")
                        .HasColumnType("integer");

                    b.Property<Guid>("TeacherTypeLessonId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TeacherTypeLessonId");

                    b.ToTable("GroupLesson");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.GroupLessonStudents", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("StudentsId");

                    b.ToTable("GroupLessonStudents");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.Moderator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DateBirthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Moderators");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.Scheduler", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("GroupLessonId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsWeekend")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("SingleLessonId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GroupLessonId");

                    b.HasIndex("SingleLessonId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Schedulers");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.SettingsStudent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsAcceptForLessonEmail")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsAcceptForLessonTelegram")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsAllowCreateLesson")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsCancelLessonEmail")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsCancelLessonTelegram")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsLessonComingSoonEmail")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsLessonComingSoonTelegram")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsNotificationEmail")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsNotificationTelegram")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRequestForLessonEmail")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRequestForLessonTelegram")
                        .HasColumnType("boolean");

                    b.Property<int>("TimeBeforeLesson")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("SettingsStudent");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.SettingsTeacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsAcceptForLessonEmail")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsAcceptForLessonTelegram")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsAllowCreateLesson")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsCancelLessonEmail")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsCancelLessonTelegram")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsLessonComingSoonEmail")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsLessonComingSoonTelegram")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsNotificationEmail")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsNotificationTelegram")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRequestForLessonEmail")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRequestForLessonTelegram")
                        .HasColumnType("boolean");

                    b.Property<int>("TimeBeforeLesson")
                        .HasColumnType("integer");

                    b.Property<int>("TimeCancelLesson")
                        .HasColumnType("integer");

                    b.Property<int>("TimeCreateLesson")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("SettingsTeacher");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.SingleLesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CancelMessage")
                        .HasColumnType("text");

                    b.Property<bool>("IsCancel")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsConfirmedForStudent")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsConfirmedForTeacher")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsFinish")
                        .HasColumnType("boolean");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeacherTypeLessonId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StudentsId");

                    b.HasIndex("TeacherTypeLessonId");

                    b.ToTable("SingleLesson");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.Students", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CitiesId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DateBirthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<Guid>("SettingsStudentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("TelegramId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CitiesId");

                    b.HasIndex("SettingsStudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CitiesId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DateBirthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("bytea");

                    b.Property<Guid>("SettingsTeacherId")
                        .HasColumnType("uuid");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("TelegramId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CitiesId");

                    b.HasIndex("SettingsTeacherId");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.TeacherTypeLesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsGroup")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsOffline")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSingle")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TypeLessonsId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId")
                        .IsUnique();

                    b.HasIndex("TypeLessonsId");

                    b.ToTable("TeacherTypeLesson");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.TypeLessons", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("TypeLessons");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.Violators", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateBan")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateCreatedViolator")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsCancel")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("StudentsId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StudentsId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Violators");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.AboutTeacher", b =>
                {
                    b.HasOne("ApiDigitalLesson.Model.Entity.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.GroupLesson", b =>
                {
                    b.HasOne("ApiDigitalLesson.Model.Entity.TeacherTypeLesson", "TeacherTypeLesson")
                        .WithMany()
                        .HasForeignKey("TeacherTypeLessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TeacherTypeLesson");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.GroupLessonStudents", b =>
                {
                    b.HasOne("ApiDigitalLesson.Model.Entity.GroupLesson", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiDigitalLesson.Model.Entity.Students", "Students")
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.Scheduler", b =>
                {
                    b.HasOne("ApiDigitalLesson.Model.Entity.GroupLesson", "GroupLesson")
                        .WithMany()
                        .HasForeignKey("GroupLessonId");

                    b.HasOne("ApiDigitalLesson.Model.Entity.SingleLesson", "SingleLesson")
                        .WithMany()
                        .HasForeignKey("SingleLessonId");

                    b.HasOne("ApiDigitalLesson.Model.Entity.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GroupLesson");

                    b.Navigation("SingleLesson");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.SingleLesson", b =>
                {
                    b.HasOne("ApiDigitalLesson.Model.Entity.Students", "Students")
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiDigitalLesson.Model.Entity.TeacherTypeLesson", "TeacherTypeLesson")
                        .WithMany()
                        .HasForeignKey("TeacherTypeLessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Students");

                    b.Navigation("TeacherTypeLesson");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.Students", b =>
                {
                    b.HasOne("ApiDigitalLesson.Model.Entity.Cities", "Cities")
                        .WithMany()
                        .HasForeignKey("CitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiDigitalLesson.Model.Entity.SettingsStudent", "SettingsStudent")
                        .WithMany()
                        .HasForeignKey("SettingsStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cities");

                    b.Navigation("SettingsStudent");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.Teacher", b =>
                {
                    b.HasOne("ApiDigitalLesson.Model.Entity.Cities", "Cities")
                        .WithMany()
                        .HasForeignKey("CitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiDigitalLesson.Model.Entity.SettingsTeacher", "SettingsTeacher")
                        .WithMany()
                        .HasForeignKey("SettingsTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cities");

                    b.Navigation("SettingsTeacher");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.TeacherTypeLesson", b =>
                {
                    b.HasOne("ApiDigitalLesson.Model.Entity.Teacher", "Teacher")
                        .WithOne()
                        .HasForeignKey("ApiDigitalLesson.Model.Entity.TeacherTypeLesson", "TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiDigitalLesson.Model.Entity.TypeLessons", "TypeLessons")
                        .WithMany()
                        .HasForeignKey("TypeLessonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");

                    b.Navigation("TypeLessons");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.TypeLessons", b =>
                {
                    b.HasOne("ApiDigitalLesson.Model.Entity.TypeLessons", "Parent")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.Violators", b =>
                {
                    b.HasOne("ApiDigitalLesson.Model.Entity.Students", "Students")
                        .WithMany()
                        .HasForeignKey("StudentsId");

                    b.HasOne("ApiDigitalLesson.Model.Entity.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.Navigation("Students");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ApiDigitalLesson.Model.Entity.TypeLessons", b =>
                {
                    b.Navigation("SubCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
