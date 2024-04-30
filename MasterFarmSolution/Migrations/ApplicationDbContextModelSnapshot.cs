﻿// <auto-generated />
using System;
using MasterFarmSolution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MasterFarmSolution.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MasterFarmSolution.Entities.AgriculturalOperation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("cropId")
                        .HasColumnType("int");

                    b.Property<string>("dateOperation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("is_active")
                        .HasColumnType("bit");

                    b.Property<int>("operationTypeId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("cropId");

                    b.HasIndex("operationTypeId");

                    b.ToTable("AgriculturalOperations");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.AgriculturalOperationsType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("AgriculturalOperationsTypes");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.Animal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("nameAnimal")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("plotId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("plotId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.Crop", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("harvestDays")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<bool>("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("plotId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("plotId");

                    b.ToTable("Crops");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.Farm", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("farmName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("farmerId")
                        .HasColumnType("int");

                    b.Property<bool>("is_active")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("farmerId");

                    b.ToTable("Farms");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.Farmer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("addressFarmer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("emailFarmer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("firstNameFarmer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("lastNameFarmer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("phoneFarmer")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("id");

                    b.ToTable("Farmers");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.Game", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("dateLastConnection")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_active")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.HarvestRecord", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("is_active")
                        .HasColumnType("bit");

                    b.Property<int>("operationId")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("operationId");

                    b.HasIndex("productId");

                    b.ToTable("HarvestRecords");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.OperationXGame", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("agriculturalOperationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateTimeOperationXGame")
                        .HasColumnType("datetime2");

                    b.Property<int>("gameId")
                        .HasColumnType("int");

                    b.Property<bool>("is_active")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("agriculturalOperationId");

                    b.HasIndex("gameId");

                    b.ToTable("OperationXGames");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.Plot", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("farmId")
                        .HasColumnType("int");

                    b.Property<bool>("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("plotTypeId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("farmId");

                    b.HasIndex("plotTypeId");

                    b.ToTable("Plots");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.PlotType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("plotType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("PlotTypes");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("productTypeId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("productTypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.ProductType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("productType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("farmerId")
                        .HasColumnType("int");

                    b.Property<bool>("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.HasIndex("farmerId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.AgriculturalOperation", b =>
                {
                    b.HasOne("MasterFarmSolution.Entities.Crop", "crop")
                        .WithMany()
                        .HasForeignKey("cropId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasterFarmSolution.Entities.AgriculturalOperationsType", "operationType")
                        .WithMany()
                        .HasForeignKey("operationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("crop");

                    b.Navigation("operationType");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.Animal", b =>
                {
                    b.HasOne("MasterFarmSolution.Entities.Plot", "plot")
                        .WithMany()
                        .HasForeignKey("plotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("plot");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.Crop", b =>
                {
                    b.HasOne("MasterFarmSolution.Entities.Plot", "plot")
                        .WithMany()
                        .HasForeignKey("plotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("plot");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.Farm", b =>
                {
                    b.HasOne("MasterFarmSolution.Entities.Farmer", "farmer")
                        .WithMany()
                        .HasForeignKey("farmerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("farmer");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.HarvestRecord", b =>
                {
                    b.HasOne("MasterFarmSolution.Entities.AgriculturalOperation", "operation")
                        .WithMany()
                        .HasForeignKey("operationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasterFarmSolution.Entities.Product", "product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("operation");

                    b.Navigation("product");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.OperationXGame", b =>
                {
                    b.HasOne("MasterFarmSolution.Entities.AgriculturalOperation", "agriculturalOperation")
                        .WithMany()
                        .HasForeignKey("agriculturalOperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasterFarmSolution.Entities.Game", "game")
                        .WithMany()
                        .HasForeignKey("gameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("agriculturalOperation");

                    b.Navigation("game");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.Plot", b =>
                {
                    b.HasOne("MasterFarmSolution.Entities.Farm", "farm")
                        .WithMany()
                        .HasForeignKey("farmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasterFarmSolution.Entities.PlotType", "plotType")
                        .WithMany()
                        .HasForeignKey("plotTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("farm");

                    b.Navigation("plotType");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.Product", b =>
                {
                    b.HasOne("MasterFarmSolution.Entities.ProductType", "productType")
                        .WithMany()
                        .HasForeignKey("productTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("productType");
                });

            modelBuilder.Entity("MasterFarmSolution.Entities.User", b =>
                {
                    b.HasOne("MasterFarmSolution.Entities.Farmer", "farmer")
                        .WithMany()
                        .HasForeignKey("farmerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("farmer");
                });
#pragma warning restore 612, 618
        }
    }
}
