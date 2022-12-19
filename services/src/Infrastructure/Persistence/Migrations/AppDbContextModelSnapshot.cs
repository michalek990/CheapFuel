﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Favorite", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("FuelStationId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "FuelStationId");

                    b.HasIndex("FuelStationId");

                    b.ToTable("Favorites", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.FuelAtStation", b =>
                {
                    b.Property<long>("FuelTypeId")
                        .HasColumnType("bigint");

                    b.Property<long>("FuelStationId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("FuelTypeId", "FuelStationId");

                    b.HasIndex("FuelStationId");

                    b.ToTable("FuelAtStations", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.FuelPrice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<byte>("Available")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue((byte)1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<byte>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue((byte)0);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<long?>("FuelStationId")
                        .HasColumnType("bigint");

                    b.Property<long?>("FuelTypeId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<byte>("Priority")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("FuelStationId");

                    b.HasIndex("FuelTypeId");

                    b.HasIndex("UserId");

                    b.HasIndex("Status", "FuelTypeId", "Available", "Price");

                    b.ToTable("FuelPrices", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.FuelStation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<long>("StationChainId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StationChainId");

                    b.ToTable("FuelStations", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.FuelStationService", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Services", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.FuelType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("FuelTypes", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.OpeningClosingTime", b =>
                {
                    b.Property<long>("FuelStationId")
                        .HasColumnType("bigint");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<int?>("ClosingTime")
                        .IsRequired()
                        .HasPrecision(4)
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<int?>("OpeningTime")
                        .IsRequired()
                        .HasPrecision(4)
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("FuelStationId", "DayOfWeek");

                    b.ToTable("OpeningClosingTimes", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.OwnedStation", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("FuelStationId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "FuelStationId");

                    b.HasIndex("FuelStationId");

                    b.ToTable("OwnedStations", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<byte>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue((byte)0);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<long?>("FuelStationId")
                        .HasColumnType("bigint");

                    b.Property<int?>("Rate")
                        .IsRequired()
                        .HasPrecision(1)
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FuelStationId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ServiceAtStation", b =>
                {
                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.Property<long>("FuelStationId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("ServiceId", "FuelStationId");

                    b.HasIndex("FuelStationId");

                    b.ToTable("ServiceAtStations", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.StationChain", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("StationChains", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Tokens.EmailVerificationToken", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar(6)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EmailVerificationTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Tokens.PasswordResetToken", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar(6)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PasswordResetTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<byte>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue((byte)0);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<byte>("EmailConfirmed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue((byte)0);

                    b.Property<byte>("MultiFactorAuthEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue((byte)0);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Favorite", b =>
                {
                    b.HasOne("Domain.Entities.FuelStation", "FuelStation")
                        .WithMany()
                        .HasForeignKey("FuelStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FuelStation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.FuelAtStation", b =>
                {
                    b.HasOne("Domain.Entities.FuelStation", "FuelStation")
                        .WithMany("FuelTypes")
                        .HasForeignKey("FuelStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.FuelType", "FuelType")
                        .WithMany()
                        .HasForeignKey("FuelTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FuelStation");

                    b.Navigation("FuelType");
                });

            modelBuilder.Entity("Domain.Entities.FuelPrice", b =>
                {
                    b.HasOne("Domain.Entities.FuelStation", "FuelStation")
                        .WithMany("FuelPrices")
                        .HasForeignKey("FuelStationId");

                    b.HasOne("Domain.Entities.FuelType", "FuelType")
                        .WithMany()
                        .HasForeignKey("FuelTypeId");

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FuelStation");

                    b.Navigation("FuelType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.FuelStation", b =>
                {
                    b.HasOne("Domain.Entities.StationChain", "StationChain")
                        .WithMany()
                        .HasForeignKey("StationChainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Domain.Entities.FuelStation.Address#Domain.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<long>("FuelStationId")
                                .HasColumnType("bigint");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)")
                                .HasColumnName("City");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasMaxLength(5)
                                .HasColumnType("varchar(5)")
                                .HasColumnName("PostalCode");

                            b1.Property<string>("Street")
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Street");

                            b1.Property<string>("StreetNumber")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("varchar(10)")
                                .HasColumnName("StreetNumber");

                            b1.HasKey("FuelStationId");

                            b1.ToTable("FuelStations", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("FuelStationId");
                        });

                    b.OwnsOne("Domain.Entities.FuelStation.GeographicalCoordinates#Domain.Entities.GeographicalCoordinates", "GeographicalCoordinates", b1 =>
                        {
                            b1.Property<long>("FuelStationId")
                                .HasColumnType("bigint");

                            b1.Property<decimal>("Latitude")
                                .HasPrecision(17, 15)
                                .HasColumnType("decimal(17,15)")
                                .HasColumnName("Latitude");

                            b1.Property<decimal>("Longitude")
                                .HasPrecision(17, 15)
                                .HasColumnType("decimal(17,15)")
                                .HasColumnName("Longitude");

                            b1.HasKey("FuelStationId");

                            b1.ToTable("FuelStations", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("FuelStationId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("GeographicalCoordinates")
                        .IsRequired();

                    b.Navigation("StationChain");
                });

            modelBuilder.Entity("Domain.Entities.OpeningClosingTime", b =>
                {
                    b.HasOne("Domain.Entities.FuelStation", "FuelStation")
                        .WithMany("OpeningClosingTimes")
                        .HasForeignKey("FuelStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FuelStation");
                });

            modelBuilder.Entity("Domain.Entities.OwnedStation", b =>
                {
                    b.HasOne("Domain.Entities.FuelStation", "FuelStation")
                        .WithMany("OwnedStations")
                        .HasForeignKey("FuelStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FuelStation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Review", b =>
                {
                    b.HasOne("Domain.Entities.FuelStation", "FuelStation")
                        .WithMany()
                        .HasForeignKey("FuelStationId");

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FuelStation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.ServiceAtStation", b =>
                {
                    b.HasOne("Domain.Entities.FuelStation", "FuelStation")
                        .WithMany("ServiceAtStations")
                        .HasForeignKey("FuelStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.FuelStationService", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FuelStation");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Domain.Entities.Tokens.EmailVerificationToken", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Tokens.PasswordResetToken", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.FuelStation", b =>
                {
                    b.Navigation("FuelPrices");

                    b.Navigation("FuelTypes");

                    b.Navigation("OpeningClosingTimes");

                    b.Navigation("OwnedStations");

                    b.Navigation("ServiceAtStations");
                });
#pragma warning restore 612, 618
        }
    }
}
