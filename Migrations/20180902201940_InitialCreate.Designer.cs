﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoDiaryWeb.Models;

namespace ToDoDiaryWeb.Migrations
{
    [DbContext(typeof(ToDoContext))]
    [Migration("20180902201940_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview1-35029");

            modelBuilder.Entity("ToDoDiaryWeb.Models.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("ToDos");
                });
#pragma warning restore 612, 618
        }
    }
}
