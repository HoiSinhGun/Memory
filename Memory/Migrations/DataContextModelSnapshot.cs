﻿// <auto-generated />
using System;
using Memory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Memory.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("Memory.Data.Model.Agent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PersonID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("Memory.Data.Model.MoneyTransferCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("MoneyTransferCategories");
                });

            modelBuilder.Entity("Memory.Data.Model.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Memory.Data.Model.Transaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MoneyTransferCategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ReceiverID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SenderID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("MoneyTransferCategoryID");

                    b.HasIndex("ReceiverID");

                    b.HasIndex("SenderID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Memory.Data.Model.Agent", b =>
                {
                    b.HasOne("Memory.Data.Model.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonID");
                });

            modelBuilder.Entity("Memory.Data.Model.Transaction", b =>
                {
                    b.HasOne("Memory.Data.Model.MoneyTransferCategory", "MoneyTransferCategory")
                        .WithMany()
                        .HasForeignKey("MoneyTransferCategoryID");

                    b.HasOne("Memory.Data.Model.Agent", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverID");

                    b.HasOne("Memory.Data.Model.Agent", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderID");
                });
#pragma warning restore 612, 618
        }
    }
}