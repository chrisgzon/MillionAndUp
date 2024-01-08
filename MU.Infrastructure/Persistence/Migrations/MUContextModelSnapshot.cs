﻿// <auto-generated />
using System;
using MU.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MU.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(MUContext))]
    partial class MUContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MU.Domain.Entities.Owners.Owner", b =>
                {
                    b.Property<Guid>("IdOwner")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthay")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("IdOwner");

                    b.ToTable("Owner", (string)null);
                });

            modelBuilder.Entity("MU.Domain.Entities.Properties.Property", b =>
                {
                    b.Property<Guid>("IdProperty")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodeInternal")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<Guid>("IdOwner")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<double>("PriceSale")
                        .HasPrecision(28, 6)
                        .HasColumnType("float(28)");

                    b.Property<int>("YearBuild")
                        .HasColumnType("int");

                    b.HasKey("IdProperty");

                    b.HasIndex("IdOwner");

                    b.ToTable("Property", (string)null);
                });

            modelBuilder.Entity("MU.Domain.Entities.PropertyImages.PropertyImage", b =>
                {
                    b.Property<Guid>("IdPropertyImage")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("File")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid>("IdProperty")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdPropertyImage");

                    b.HasIndex("IdProperty");

                    b.ToTable("PropertyImage", (string)null);
                });

            modelBuilder.Entity("MU.Domain.Entities.PropertyTraces.PropertyTrace", b =>
                {
                    b.Property<Guid>("IdPropertyTrace")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdProperty")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameClient")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<decimal>("Tax")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<double>("Value")
                        .HasPrecision(28, 6)
                        .HasColumnType("float(28)");

                    b.HasKey("IdPropertyTrace");

                    b.HasIndex("IdProperty");

                    b.ToTable("PropertyTrace", (string)null);
                });

            modelBuilder.Entity("MU.Domain.Entities.Owners.Owner", b =>
                {
                    b.OwnsOne("MU.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("OwnerIdOwner")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.Property<string>("Line1")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.Property<string>("Line2")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.HasKey("OwnerIdOwner");

                            b1.ToTable("Owner");

                            b1.WithOwner()
                                .HasForeignKey("OwnerIdOwner");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("MU.Domain.Entities.Properties.Property", b =>
                {
                    b.HasOne("MU.Domain.Entities.Owners.Owner", "Owner")
                        .WithMany("_properties")
                        .HasForeignKey("IdOwner")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("MU.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("PropertyIdProperty")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.Property<string>("Line1")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.Property<string>("Line2")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.HasKey("PropertyIdProperty");

                            b1.ToTable("Property");

                            b1.WithOwner()
                                .HasForeignKey("PropertyIdProperty");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("MU.Domain.Entities.PropertyImages.PropertyImage", b =>
                {
                    b.HasOne("MU.Domain.Entities.Properties.Property", "Property")
                        .WithMany("PropertyImages")
                        .HasForeignKey("IdProperty")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("MU.Domain.Entities.PropertyTraces.PropertyTrace", b =>
                {
                    b.HasOne("MU.Domain.Entities.Properties.Property", "Property")
                        .WithMany("PropertyTraces")
                        .HasForeignKey("IdProperty")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("MU.Domain.Entities.Owners.Owner", b =>
                {
                    b.Navigation("_properties");
                });

            modelBuilder.Entity("MU.Domain.Entities.Properties.Property", b =>
                {
                    b.Navigation("PropertyImages");

                    b.Navigation("PropertyTraces");
                });
#pragma warning restore 612, 618
        }
    }
}
