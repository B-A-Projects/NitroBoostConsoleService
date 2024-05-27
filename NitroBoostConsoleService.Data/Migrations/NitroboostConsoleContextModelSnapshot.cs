﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NitroBoostConsoleService.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NitroBoostConsoleService.Data.Migrations
{
    [DbContext(typeof(NitroboostConsoleContext))]
    partial class NitroboostConsoleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NitroBoostConsoleService.Data.Entities.Device", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<long>("DeviceId")
                        .HasColumnType("bigint")
                        .HasColumnName("device_id");

                    b.Property<string>("DeviceName")
                        .HasColumnType("text")
                        .HasColumnName("device_name");

                    b.Property<string>("MacAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("mac_address");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("NitroBoostConsoleService.Data.Entities.Friend", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<long?>("GameId")
                        .HasColumnType("bigint");

                    b.Property<long>("RecipientId")
                        .HasColumnType("bigint")
                        .HasColumnName("recipient_id");

                    b.Property<long>("SenderId")
                        .HasColumnType("bigint")
                        .HasColumnName("sender_id");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("NitroBoostConsoleService.Data.Entities.Game", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Aim")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("aim");

                    b.Property<int>("DeviceId")
                        .HasColumnType("integer")
                        .HasColumnName("device_id");

                    b.Property<long?>("DeviceId1")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("GameCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("gamecode");

                    b.Property<string>("Gsbrcd")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("gsbrcd");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<float>("Lattitude")
                        .HasColumnType("real")
                        .HasColumnName("lattitude");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("location");

                    b.Property<float>("Longnitude")
                        .HasColumnType("real")
                        .HasColumnName("longnitude");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nickname");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer")
                        .HasColumnName("player_id");

                    b.Property<string>("Signature")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("signature");

                    b.Property<string>("UniqueNickname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("unique_nickname");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("zipcode");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId1");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("NitroBoostConsoleService.Data.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birth_date");

                    b.Property<int?>("FavouriteGameId")
                        .HasColumnType("integer")
                        .HasColumnName("favourite_game_id");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nickname");

                    b.Property<bool>("ShowBirthdate")
                        .HasColumnType("boolean")
                        .HasColumnName("show_birth_date");

                    b.Property<bool>("Validated")
                        .HasColumnType("boolean")
                        .HasColumnName("validated");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NitroBoostConsoleService.Data.Entities.Device", b =>
                {
                    b.HasOne("NitroBoostConsoleService.Data.Entities.User", null)
                        .WithMany("Devices")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("NitroBoostConsoleService.Data.Entities.Friend", b =>
                {
                    b.HasOne("NitroBoostConsoleService.Data.Entities.Game", null)
                        .WithMany("Friends")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("NitroBoostConsoleService.Data.Entities.Game", b =>
                {
                    b.HasOne("NitroBoostConsoleService.Data.Entities.Device", null)
                        .WithMany("Games")
                        .HasForeignKey("DeviceId1");
                });

            modelBuilder.Entity("NitroBoostConsoleService.Data.Entities.Device", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("NitroBoostConsoleService.Data.Entities.Game", b =>
                {
                    b.Navigation("Friends");
                });

            modelBuilder.Entity("NitroBoostConsoleService.Data.Entities.User", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
