﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SealabAPI.DataAccess;

#nullable disable

namespace SealabAPI.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231030022512_ptToPRT")]
    partial class ptToPRT
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.Assistant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uuid")
                        .HasColumnName("id_user");

                    b.Property<string>("Position")
                        .HasColumnType("text")
                        .HasColumnName("position");

                    b.HasKey("Id")
                        .HasName("pk_assistant");

                    b.HasIndex("IdUser")
                        .IsUnique()
                        .HasDatabaseName("ix_assistant_id_user");

                    b.ToTable("assistant", (string)null);
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.JournalAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("AssistantFeedback")
                        .HasColumnType("text")
                        .HasColumnName("assistant_feedback");

                    b.Property<string>("FilePath")
                        .HasColumnType("text")
                        .HasColumnName("file_path");

                    b.Property<Guid>("IdModule")
                        .HasColumnType("uuid")
                        .HasColumnName("id_module");

                    b.Property<Guid>("IdStudent")
                        .HasColumnType("uuid")
                        .HasColumnName("id_student");

                    b.Property<string>("LaboratoryFeedback")
                        .HasColumnType("text")
                        .HasColumnName("laboratory_feedback");

                    b.Property<string>("SessionFeedback")
                        .HasColumnType("text")
                        .HasColumnName("session_feedback");

                    b.Property<DateTime>("SubmitTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("submit_time");

                    b.HasKey("Id")
                        .HasName("pk_journal_answer");

                    b.HasIndex("IdModule")
                        .HasDatabaseName("ix_journal_answer_id_module");

                    b.HasIndex("IdStudent")
                        .HasDatabaseName("ix_journal_answer_id_student");

                    b.ToTable("journal_answer", (string)null);
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.Module", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("IsJOpen")
                        .HasColumnType("boolean")
                        .HasColumnName("is_j_open");

                    b.Property<bool>("IsPAOpen")
                        .HasColumnType("boolean")
                        .HasColumnName("is_pa_open");

                    b.Property<bool>("IsPRTOpen")
                        .HasColumnType("boolean")
                        .HasColumnName("is_prt_open");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("SeelabsId")
                        .HasColumnType("integer")
                        .HasColumnName("seelabs_id");

                    b.HasKey("Id")
                        .HasName("pk_module");

                    b.ToTable("module", (string)null);
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.PreliminaryAssignmentAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("FilePath")
                        .HasColumnType("text")
                        .HasColumnName("file_path");

                    b.Property<Guid>("IdModule")
                        .HasColumnType("uuid")
                        .HasColumnName("id_module");

                    b.Property<Guid>("IdStudent")
                        .HasColumnType("uuid")
                        .HasColumnName("id_student");

                    b.Property<DateTime>("SubmitTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("submit_time");

                    b.HasKey("Id")
                        .HasName("pk_preliminary_assignment_answer");

                    b.HasIndex("IdModule")
                        .HasDatabaseName("ix_preliminary_assignment_answer_id_module");

                    b.HasIndex("IdStudent")
                        .HasDatabaseName("ix_preliminary_assignment_answer_id_student");

                    b.ToTable("preliminary_assignment_answer", (string)null);
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.PreliminaryAssignmentQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("AnswerKey")
                        .HasColumnType("text")
                        .HasColumnName("answer_key");

                    b.Property<string>("FilePath")
                        .HasColumnType("text")
                        .HasColumnName("file_path");

                    b.Property<Guid>("IdModule")
                        .HasColumnType("uuid")
                        .HasColumnName("id_module");

                    b.Property<string>("Question")
                        .HasColumnType("text")
                        .HasColumnName("question");

                    b.Property<string>("Type")
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_preliminary_assignment_question");

                    b.HasIndex("IdModule")
                        .HasDatabaseName("ix_preliminary_assignment_question_id_module");

                    b.ToTable("preliminary_assignment_question", (string)null);
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.PreTestAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("IdOption")
                        .HasColumnType("uuid")
                        .HasColumnName("id_option");

                    b.Property<Guid>("IdStudent")
                        .HasColumnType("uuid")
                        .HasColumnName("id_student");

                    b.HasKey("Id")
                        .HasName("pk_pre_test_answer");

                    b.HasIndex("IdOption")
                        .HasDatabaseName("ix_pre_test_answer_id_option");

                    b.HasIndex("IdStudent")
                        .HasDatabaseName("ix_pre_test_answer_id_student");

                    b.ToTable("pre_test_answer", (string)null);
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.PreTestOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("IdQuestion")
                        .HasColumnType("uuid")
                        .HasColumnName("id_question");

                    b.Property<bool>("IsTrue")
                        .HasColumnType("boolean")
                        .HasColumnName("is_true");

                    b.Property<string>("Option")
                        .HasColumnType("text")
                        .HasColumnName("option");

                    b.HasKey("Id")
                        .HasName("pk_pre_test_option");

                    b.HasIndex("IdQuestion")
                        .HasDatabaseName("ix_pre_test_option_id_question");

                    b.ToTable("pre_test_option", (string)null);
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.PreTestQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("FilePath")
                        .HasColumnType("text")
                        .HasColumnName("file_path");

                    b.Property<Guid>("IdModule")
                        .HasColumnType("uuid")
                        .HasColumnName("id_module");

                    b.Property<string>("Question")
                        .HasColumnType("text")
                        .HasColumnName("question");

                    b.Property<string>("Type")
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_pre_test_question");

                    b.HasIndex("IdModule")
                        .HasDatabaseName("ix_pre_test_question_id_module");

                    b.ToTable("pre_test_question", (string)null);
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Classroom")
                        .HasColumnType("text")
                        .HasColumnName("classroom");

                    b.Property<int>("Day")
                        .HasColumnType("integer")
                        .HasColumnName("day");

                    b.Property<int>("Group")
                        .HasColumnType("integer")
                        .HasColumnName("group");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uuid")
                        .HasColumnName("id_user");

                    b.Property<int>("Shift")
                        .HasColumnType("integer")
                        .HasColumnName("shift");

                    b.HasKey("Id")
                        .HasName("pk_student");

                    b.HasIndex("IdUser")
                        .IsUnique()
                        .HasDatabaseName("ix_student_id_user");

                    b.ToTable("student", (string)null);
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("AppToken")
                        .HasColumnType("text")
                        .HasColumnName("app_token");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Nim")
                        .HasColumnType("text")
                        .HasColumnName("nim");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<string>("Role")
                        .HasColumnType("text")
                        .HasColumnName("role");

                    b.Property<string>("Username")
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_user");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.Assistant", b =>
                {
                    b.HasOne("SealabAPI.DataAccess.Entities.User", "User")
                        .WithOne("Assistant")
                        .HasForeignKey("SealabAPI.DataAccess.Entities.Assistant", "IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_assistant_user_id_user");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.JournalAnswer", b =>
                {
                    b.HasOne("SealabAPI.DataAccess.Entities.Module", "Module")
                        .WithMany("JAnswers")
                        .HasForeignKey("IdModule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_journal_answer_module_id_module");

                    b.HasOne("SealabAPI.DataAccess.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("IdStudent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_journal_answer_student_id_student");

                    b.Navigation("Module");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.PreliminaryAssignmentAnswer", b =>
                {
                    b.HasOne("SealabAPI.DataAccess.Entities.Module", "Module")
                        .WithMany("PAAnswers")
                        .HasForeignKey("IdModule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_preliminary_assignment_answer_module_id_module");

                    b.HasOne("SealabAPI.DataAccess.Entities.Student", "Student")
                        .WithMany("PAAnswers")
                        .HasForeignKey("IdStudent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_preliminary_assignment_answer_student_id_student");

                    b.Navigation("Module");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.PreliminaryAssignmentQuestion", b =>
                {
                    b.HasOne("SealabAPI.DataAccess.Entities.Module", "Module")
                        .WithMany("PAQuestions")
                        .HasForeignKey("IdModule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_preliminary_assignment_question_module_id_module");

                    b.Navigation("Module");
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.PreTestAnswer", b =>
                {
                    b.HasOne("SealabAPI.DataAccess.Entities.PreTestOption", "Option")
                        .WithMany("Answers")
                        .HasForeignKey("IdOption")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_pre_test_answer_pre_test_option_id_option");

                    b.HasOne("SealabAPI.DataAccess.Entities.Student", "Student")
                        .WithMany("PRTAnswers")
                        .HasForeignKey("IdStudent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_pre_test_answer_student_id_student");

                    b.Navigation("Option");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.PreTestOption", b =>
                {
                    b.HasOne("SealabAPI.DataAccess.Entities.PreTestQuestion", "Question")
                        .WithMany("PRTOptions")
                        .HasForeignKey("IdQuestion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_pre_test_option_pre_test_question_id_question");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.PreTestQuestion", b =>
                {
                    b.HasOne("SealabAPI.DataAccess.Entities.Module", "Module")
                        .WithMany("PRTQuestions")
                        .HasForeignKey("IdModule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_pre_test_question_module_id_module");

                    b.Navigation("Module");
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.Student", b =>
                {
                    b.HasOne("SealabAPI.DataAccess.Entities.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("SealabAPI.DataAccess.Entities.Student", "IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_student_user_id_user");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.Module", b =>
                {
                    b.Navigation("JAnswers");

                    b.Navigation("PAAnswers");

                    b.Navigation("PAQuestions");

                    b.Navigation("PRTQuestions");
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.PreTestOption", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.PreTestQuestion", b =>
                {
                    b.Navigation("PRTOptions");
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.Student", b =>
                {
                    b.Navigation("PAAnswers");

                    b.Navigation("PRTAnswers");
                });

            modelBuilder.Entity("SealabAPI.DataAccess.Entities.User", b =>
                {
                    b.Navigation("Assistant");

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
