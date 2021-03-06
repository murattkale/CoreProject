﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Services.Migrations
{
    [DbContext(typeof(myDBContext))]
    [Migration("20210130210552_dbdsfsdsfdfvfdsdfsdsdf")]
    partial class dbdsfsdsfdfvfdsdfsdsdf
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ActionData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ActionType")
                        .HasColumnType("int");

                    b.Property<int>("ContentID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreaUser")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IsState")
                        .HasColumnType("int");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModUser")
                        .HasColumnType("int");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("int");

                    b.Property<int>("ResponseDataId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContentID");

                    b.HasIndex("ResponseDataId");

                    b.ToTable("ActionData");
                });

            modelBuilder.Entity("Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ContentData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreaUser")
                        .HasColumnType("int");

                    b.Property<string>("DocVideoDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentType")
                        .HasColumnType("int");

                    b.Property<bool>("Interaction")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IsState")
                        .HasColumnType("int");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModUser")
                        .HasColumnType("int");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("int");

                    b.Property<int>("ResponseType")
                        .HasColumnType("int");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<string>("VideoLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Content");
                });

            modelBuilder.Entity("Documents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Alt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ContentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreaUser")
                        .HasColumnType("int");

                    b.Property<string>("Guid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IsState")
                        .HasColumnType("int");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Types")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("ResponseData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ContentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreaUser")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IsState")
                        .HasColumnType("int");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModUser")
                        .HasColumnType("int");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("int");

                    b.Property<string>("ReponseContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResponseType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.ToTable("ResponseData");
                });

            modelBuilder.Entity("Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreaUser")
                        .HasColumnType("int");

                    b.Property<string>("Definition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IsState")
                        .HasColumnType("int");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("No")
                        .HasColumnType("int");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("int");

                    b.Property<int>("WorkshopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreaUser")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IsState")
                        .HasColumnType("int");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("int");

                    b.Property<int?>("LoginCount")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("int");

                    b.Property<string>("Pass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("UserClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreaUser")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IsState")
                        .HasColumnType("int");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserClient");
                });

            modelBuilder.Entity("UserClientSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreaUser")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IsState")
                        .HasColumnType("int");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModUser")
                        .HasColumnType("int");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("int");

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.Property<string>("SessionGuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserClientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.HasIndex("UserClientId");

                    b.ToTable("UserClientSession");
                });

            modelBuilder.Entity("Workshop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoryType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreaUser")
                        .HasColumnType("int");

                    b.Property<string>("Definition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IsState")
                        .HasColumnType("int");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PublishDuration")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Workshop");
                });

            modelBuilder.Entity("ActionData", b =>
                {
                    b.HasOne("Content", "Content")
                        .WithMany("ActionData")
                        .HasForeignKey("ContentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ResponseData", "ResponseData")
                        .WithMany("ActionData")
                        .HasForeignKey("ResponseDataId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Content");

                    b.Navigation("ResponseData");
                });

            modelBuilder.Entity("Content", b =>
                {
                    b.HasOne("Section", "Section")
                        .WithMany("Content")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Section");
                });

            modelBuilder.Entity("Documents", b =>
                {
                    b.HasOne("Content", "Content")
                        .WithMany("Documents")
                        .HasForeignKey("ContentId");

                    b.Navigation("Content");
                });

            modelBuilder.Entity("ResponseData", b =>
                {
                    b.HasOne("Content", "Content")
                        .WithMany("ResponseData")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Content");
                });

            modelBuilder.Entity("Section", b =>
                {
                    b.HasOne("Workshop", "Workshop")
                        .WithMany("Section")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("UserClientSession", b =>
                {
                    b.HasOne("Section", "Section")
                        .WithMany("UserClientSession")
                        .HasForeignKey("SectionId");

                    b.HasOne("UserClient", "UserClient")
                        .WithMany("UserClientSession")
                        .HasForeignKey("UserClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Section");

                    b.Navigation("UserClient");
                });

            modelBuilder.Entity("Content", b =>
                {
                    b.Navigation("ActionData");

                    b.Navigation("Documents");

                    b.Navigation("ResponseData");
                });

            modelBuilder.Entity("ResponseData", b =>
                {
                    b.Navigation("ActionData");
                });

            modelBuilder.Entity("Section", b =>
                {
                    b.Navigation("Content");

                    b.Navigation("UserClientSession");
                });

            modelBuilder.Entity("UserClient", b =>
                {
                    b.Navigation("UserClientSession");
                });

            modelBuilder.Entity("Workshop", b =>
                {
                    b.Navigation("Section");
                });
#pragma warning restore 612, 618
        }
    }
}
