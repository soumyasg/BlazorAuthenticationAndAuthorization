﻿// <auto-generated />
using BocesModule.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BocesModule.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BocesModule.Shared.CoSerGroup", b =>
                {
                    b.Property<int>("CoSerGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoSerGroupCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoSerGroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CoSerGroupId");

                    b.ToTable("CoSerGroups");

                    b.HasData(
                        new
                        {
                            CoSerGroupId = 1,
                            CoSerGroupCode = "CoSerGroup1",
                            CoSerGroupName = "CoSer Group 1"
                        },
                        new
                        {
                            CoSerGroupId = 2,
                            CoSerGroupCode = "CoSerGroup2",
                            CoSerGroupName = "CoSer Group 2"
                        },
                        new
                        {
                            CoSerGroupId = 3,
                            CoSerGroupCode = "CoSerGroup3",
                            CoSerGroupName = "CoSer Group 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
