﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231001154046_New")]
    partial class New
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<Guid?>("OdeljenjeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specijalizacija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("OdeljenjeId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.Karton", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Dijagnoza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LekarId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("OdeljenjeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PacijentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Terapija")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LekarId");

                    b.HasIndex("OdeljenjeId");

                    b.HasIndex("PacijentId");

                    b.ToTable("Kartoni");
                });

            modelBuilder.Entity("Domain.Napomena", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("KartonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NezeljenoDejstvo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Primedba")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SestraId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("KartonId");

                    b.HasIndex("SestraId");

                    b.ToTable("Napomene");
                });

            modelBuilder.Entity("Domain.Odeljenje", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BrojKreveta")
                        .HasColumnType("int");

                    b.Property<int>("BrojPacijenata")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecijalizacijaNaziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Odeljenja");
                });

            modelBuilder.Entity("Domain.Pacijent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BrojGodina")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LekarId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("OdeljenjeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Pol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LekarId");

                    b.HasIndex("OdeljenjeId");

                    b.ToTable("Pacijenti");
                });

            modelBuilder.Entity("Domain.Pregled", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Anamneza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dijagnoza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("KartonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LekarId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Terapija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VremePregleda")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KartonId");

                    b.HasIndex("LekarId");

                    b.ToTable("Pregledi");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "508ae97e-9535-4fa2-a190-980a3251a4e2",
                            Name = "Lekar",
                            NormalizedName = "LEKAR"
                        },
                        new
                        {
                            Id = "0a4f668d-6a74-4732-9af9-94ed690b18df",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "39f44f27-3765-4de8-877c-7456c98e012f",
                            Name = "Sestra",
                            NormalizedName = "SESTRA"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.HasOne("Domain.Odeljenje", "Odeljenje")
                        .WithMany("Osoblje")
                        .HasForeignKey("OdeljenjeId");

                    b.Navigation("Odeljenje");
                });

            modelBuilder.Entity("Domain.Karton", b =>
                {
                    b.HasOne("Domain.AppUser", "Lekar")
                        .WithMany("Kartoni")
                        .HasForeignKey("LekarId");

                    b.HasOne("Domain.Odeljenje", "Odeljenje")
                        .WithMany()
                        .HasForeignKey("OdeljenjeId");

                    b.HasOne("Domain.Pacijent", "Pacijent")
                        .WithMany("Kartoni")
                        .HasForeignKey("PacijentId");

                    b.Navigation("Lekar");

                    b.Navigation("Odeljenje");

                    b.Navigation("Pacijent");
                });

            modelBuilder.Entity("Domain.Napomena", b =>
                {
                    b.HasOne("Domain.Karton", "Karton")
                        .WithMany("Nampomene")
                        .HasForeignKey("KartonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.AppUser", "Sestra")
                        .WithMany()
                        .HasForeignKey("SestraId");

                    b.Navigation("Karton");

                    b.Navigation("Sestra");
                });

            modelBuilder.Entity("Domain.Pacijent", b =>
                {
                    b.HasOne("Domain.AppUser", "Lekar")
                        .WithMany()
                        .HasForeignKey("LekarId");

                    b.HasOne("Domain.Odeljenje", "Odeljenje")
                        .WithMany("Pacijenti")
                        .HasForeignKey("OdeljenjeId");

                    b.Navigation("Lekar");

                    b.Navigation("Odeljenje");
                });

            modelBuilder.Entity("Domain.Pregled", b =>
                {
                    b.HasOne("Domain.Karton", "Karton")
                        .WithMany("Pregledi")
                        .HasForeignKey("KartonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.AppUser", "Lekar")
                        .WithMany("Pregledi")
                        .HasForeignKey("LekarId");

                    b.Navigation("Karton");

                    b.Navigation("Lekar");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Navigation("Kartoni");

                    b.Navigation("Pregledi");
                });

            modelBuilder.Entity("Domain.Karton", b =>
                {
                    b.Navigation("Nampomene");

                    b.Navigation("Pregledi");
                });

            modelBuilder.Entity("Domain.Odeljenje", b =>
                {
                    b.Navigation("Osoblje");

                    b.Navigation("Pacijenti");
                });

            modelBuilder.Entity("Domain.Pacijent", b =>
                {
                    b.Navigation("Kartoni");
                });
#pragma warning restore 612, 618
        }
    }
}
