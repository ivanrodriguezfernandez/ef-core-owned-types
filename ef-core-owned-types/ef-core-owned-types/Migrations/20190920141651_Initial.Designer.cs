﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ef_core_owned_types.Persistence;

namespace ef_core_owned_types.Migrations
{
    [DbContext(typeof(MyAppContext))]
    [Migration("20190920141651_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ef_core_owned_types.Domain.Dashboard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Dashboard");
                });

            modelBuilder.Entity("ef_core_owned_types.Domain.Dashboard", b =>
                {
                    b.OwnsMany("ef_core_owned_types.Domain.DashboardItem", "DashboardItems", b1 =>
                        {
                            b1.Property<Guid>("DashboardId");

                            b1.Property<string>("AppViewId");

                            b1.HasKey("DashboardId", "AppViewId");

                            b1.ToTable("DashboardItem");

                            b1.HasOne("ef_core_owned_types.Domain.Dashboard")
                                .WithMany("DashboardItems")
                                .HasForeignKey("DashboardId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("ef_core_owned_types.Domain.Position", "Position", b2 =>
                                {
                                    b2.Property<Guid>("DashboardItemDashboardId");

                                    b2.Property<string>("DashboardItemAppViewId");

                                    b2.Property<int>("X")
                                        .HasColumnName("Position_X");

                                    b2.Property<int>("Y")
                                        .HasColumnName("Position_Y");

                                    b2.HasKey("DashboardItemDashboardId", "DashboardItemAppViewId");

                                    b2.ToTable("DashboardItem");

                                    b2.HasOne("ef_core_owned_types.Domain.DashboardItem")
                                        .WithOne("Position")
                                        .HasForeignKey("ef_core_owned_types.Domain.Position", "DashboardItemDashboardId", "DashboardItemAppViewId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });

                            b1.OwnsOne("ef_core_owned_types.Domain.Size", "Size", b2 =>
                                {
                                    b2.Property<Guid>("DashboardItemDashboardId");

                                    b2.Property<string>("DashboardItemAppViewId");

                                    b2.Property<int>("Height")
                                        .HasColumnName("SizeHeight");

                                    b2.Property<int>("Width")
                                        .HasColumnName("SizeWidth");

                                    b2.HasKey("DashboardItemDashboardId", "DashboardItemAppViewId");

                                    b2.ToTable("DashboardItem");

                                    b2.HasOne("ef_core_owned_types.Domain.DashboardItem")
                                        .WithOne("Size")
                                        .HasForeignKey("ef_core_owned_types.Domain.Size", "DashboardItemDashboardId", "DashboardItemAppViewId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
