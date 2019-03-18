﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VirtualServersViewer.Data;

namespace VirtualServersViewer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190317225246_SetTimerStartValue")]
    partial class SetTimerStartValue
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VirtualServersViewer.Models.TimerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("StartTime");

                    b.Property<DateTime>("Timer");

                    b.HasKey("Id");

                    b.ToTable("Timer");
                });

            modelBuilder.Entity("VirtualServersViewer.Models.VirtualServer", b =>
                {
                    b.Property<int>("VirtualServerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<DateTime?>("RemoveDateTime");

                    b.Property<bool>("isSelectedForRemove");

                    b.HasKey("VirtualServerId");

                    b.ToTable("VirtualServers");
                });
#pragma warning restore 612, 618
        }
    }
}
