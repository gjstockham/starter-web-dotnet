﻿// <auto-generated />
using System;
using BPSample.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BPSample.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210915193238_Patients")]
    partial class Patients
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BPSample.Domain.Clinicians.Clinician", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GivenName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrganisationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Clinician");
                });

            modelBuilder.Entity("BPSample.Domain.Organisations.Organisation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organisation");
                });

            modelBuilder.Entity("BPSample.Domain.PatientInvites.PatientInvite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("PatientInvite");
                });

            modelBuilder.Entity("BPSample.Domain.Patients.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GivenName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrganisationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("BPSample.Domain.PatientInvites.PatientInvite", b =>
                {
                    b.OwnsOne("BPSample.Domain.Shared.ChiNumber", "CHI", b1 =>
                        {
                            b1.Property<Guid>("PatientInviteId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("PatientInviteId");

                            b1.ToTable("PatientInvite");

                            b1.WithOwner()
                                .HasForeignKey("PatientInviteId");
                        });

                    b.Navigation("CHI")
                        .IsRequired();
                });

            modelBuilder.Entity("BPSample.Domain.Patients.Patient", b =>
                {
                    b.OwnsOne("BPSample.Domain.Patients.BloodPressureMeasurement", "MostRecentMeasurement", b1 =>
                        {
                            b1.Property<Guid>("PatientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Category")
                                .HasColumnType("int");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patient");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.OwnsOne("BPSample.Domain.Shared.ChiNumber", "CHI", b1 =>
                        {
                            b1.Property<Guid>("PatientId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patient");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.Navigation("CHI")
                        .IsRequired();

                    b.Navigation("MostRecentMeasurement");
                });
#pragma warning restore 612, 618
        }
    }
}