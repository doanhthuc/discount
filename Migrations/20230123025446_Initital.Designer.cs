﻿// <auto-generated />
using System;
using DiscountAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DiscountAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230123025446_Initital")]
    partial class Initital
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DiscountAPI.Models.Discount", b =>
                {
                    b.Property<Guid>("discountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("discountName")
                        .HasColumnType("text");

                    b.Property<string>("discountType")
                        .HasColumnType("text");

                    b.Property<float>("discountValue")
                        .HasColumnType("real");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("timerId")
                        .HasColumnType("text");

                    b.HasKey("discountId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("DiscountAPI.Models.DiscountProduct", b =>
                {
                    b.Property<Guid>("discountId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("productId")
                        .HasColumnType("uuid");

                    b.HasKey("discountId", "productId");

                    b.ToTable("DiscountProducts");
                });

            modelBuilder.Entity("DiscountAPI.Models.DiscountProduct", b =>
                {
                    b.HasOne("DiscountAPI.Models.Discount", "discount")
                        .WithMany("discountProducts")
                        .HasForeignKey("discountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("discount");
                });

            modelBuilder.Entity("DiscountAPI.Models.Discount", b =>
                {
                    b.Navigation("discountProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
