﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using csharpapp.Db;
#nullable disable

namespace csharpapp.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class TodoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("Todo", b =>
                {
                    b.Property<int>("TodoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TodoId");

                    b.ToTable("Todo");
                });

            modelBuilder.Entity("TodoItem", b =>
                {
                    b.Property<int>("TodoItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TodoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TodoItemId");

                    b.HasIndex("TodoId");

                    b.ToTable("TodoItem");
                });

            modelBuilder.Entity("TodoItem", b =>
                {
                    b.HasOne("Todo", "todo")
                        .WithMany("todoItems")
                        .HasForeignKey("TodoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("todo");
                });

            modelBuilder.Entity("Todo", b =>
                {
                    b.Navigation("todoItems");
                });
#pragma warning restore 612, 618
        }
    }
}