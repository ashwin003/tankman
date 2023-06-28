﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using tankman.Db;

#nullable disable

namespace tankman.Migrations
{
    [DbContext(typeof(TankmanDbContext))]
    partial class TankmanDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("tankman.Models.Org", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.HasKey("Id")
                        .HasName("pk_orgs");

                    b.ToTable("orgs", (string)null);
                });

            modelBuilder.Entity("tankman.Models.Resource", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("OrgId")
                        .HasColumnType("text")
                        .HasColumnName("org_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.HasKey("Id", "OrgId")
                        .HasName("pk_resources");

                    b.HasIndex("OrgId")
                        .HasDatabaseName("ix_resources_org_id");

                    b.ToTable("resources", (string)null);
                });

            modelBuilder.Entity("tankman.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("OrgId")
                        .HasColumnType("text")
                        .HasColumnName("org_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.HasKey("Id", "OrgId")
                        .HasName("pk_roles");

                    b.HasIndex("OrgId")
                        .HasDatabaseName("ix_roles_org_id");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("tankman.Models.RoleAssignment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("OrgId")
                        .HasColumnType("text")
                        .HasColumnName("org_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role_id");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id", "OrgId")
                        .HasName("pk_role_assignments");

                    b.HasIndex("OrgId")
                        .HasDatabaseName("ix_role_assignments_org_id");

                    b.HasIndex("RoleId", "OrgId")
                        .HasDatabaseName("ix_role_assignments_role_id_org_id");

                    b.HasIndex("UserId", "OrgId")
                        .HasDatabaseName("ix_role_assignments_user_id_org_id");

                    b.ToTable("role_assignments", (string)null);
                });

            modelBuilder.Entity("tankman.Models.RolePermission", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("text")
                        .HasColumnName("role_id");

                    b.Property<string>("ResourceId")
                        .HasColumnType("text")
                        .HasColumnName("resource_id");

                    b.Property<string>("OrgId")
                        .HasColumnType("text")
                        .HasColumnName("org_id");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("action");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.HasKey("RoleId", "ResourceId", "OrgId")
                        .HasName("pk_role_permissions");

                    b.HasIndex("OrgId")
                        .HasDatabaseName("ix_role_permissions_org_id");

                    b.HasIndex("ResourceId", "OrgId")
                        .HasDatabaseName("ix_role_permissions_resource_id_org_id");

                    b.HasIndex("RoleId", "OrgId")
                        .HasDatabaseName("ix_role_permissions_role_id_org_id");

                    b.ToTable("role_permissions", (string)null);
                });

            modelBuilder.Entity("tankman.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("OrgId")
                        .HasColumnType("text")
                        .HasColumnName("org_id");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("IdentityProvider")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("identity_provider");

                    b.Property<string>("IdentityProviderUserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("identity_provider_user_id");

                    b.HasKey("Id", "OrgId")
                        .HasName("pk_users");

                    b.HasIndex("OrgId")
                        .HasDatabaseName("ix_users_org_id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("tankman.Models.UserPermission", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<string>("ResourceId")
                        .HasColumnType("text")
                        .HasColumnName("resource_id");

                    b.Property<string>("OrgId")
                        .HasColumnType("text")
                        .HasColumnName("org_id");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("action");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.HasKey("UserId", "ResourceId", "OrgId")
                        .HasName("pk_user_permissions");

                    b.HasIndex("OrgId")
                        .HasDatabaseName("ix_user_permissions_org_id");

                    b.HasIndex("ResourceId", "OrgId")
                        .HasDatabaseName("ix_user_permissions_resource_id_org_id");

                    b.HasIndex("UserId", "OrgId")
                        .HasDatabaseName("ix_user_permissions_user_id_org_id");

                    b.ToTable("user_permissions", (string)null);
                });

            modelBuilder.Entity("tankman.Models.Resource", b =>
                {
                    b.HasOne("tankman.Models.Org", "Org")
                        .WithMany("Resources")
                        .HasForeignKey("OrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_resources_orgs_org_id");

                    b.Navigation("Org");
                });

            modelBuilder.Entity("tankman.Models.Role", b =>
                {
                    b.HasOne("tankman.Models.Org", "Org")
                        .WithMany("Roles")
                        .HasForeignKey("OrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_roles_orgs_org_id");

                    b.Navigation("Org");
                });

            modelBuilder.Entity("tankman.Models.RoleAssignment", b =>
                {
                    b.HasOne("tankman.Models.Org", "Org")
                        .WithMany()
                        .HasForeignKey("OrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_role_assignments_orgs_org_id");

                    b.HasOne("tankman.Models.Role", "Role")
                        .WithMany("RoleAssignments")
                        .HasForeignKey("RoleId", "OrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_role_assignments_roles_role_id_org_id");

                    b.HasOne("tankman.Models.User", "User")
                        .WithMany("RoleAssignments")
                        .HasForeignKey("UserId", "OrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_role_assignments_users_user_id_org_id");

                    b.Navigation("Org");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("tankman.Models.RolePermission", b =>
                {
                    b.HasOne("tankman.Models.Org", "Org")
                        .WithMany()
                        .HasForeignKey("OrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_role_permissions_orgs_org_id");

                    b.HasOne("tankman.Models.Resource", "Resource")
                        .WithMany("RolePermissions")
                        .HasForeignKey("ResourceId", "OrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_role_permissions_resources_resource_id_org_id");

                    b.HasOne("tankman.Models.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId", "OrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_role_permissions_roles_role_id_org_id");

                    b.Navigation("Org");

                    b.Navigation("Resource");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("tankman.Models.User", b =>
                {
                    b.HasOne("tankman.Models.Org", "Org")
                        .WithMany("Users")
                        .HasForeignKey("OrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_orgs_org_id");

                    b.Navigation("Org");
                });

            modelBuilder.Entity("tankman.Models.UserPermission", b =>
                {
                    b.HasOne("tankman.Models.Org", "Org")
                        .WithMany()
                        .HasForeignKey("OrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_permissions_orgs_org_id");

                    b.HasOne("tankman.Models.Resource", "Resource")
                        .WithMany("UserPermissions")
                        .HasForeignKey("ResourceId", "OrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_permissions_resources_resource_id_org_id");

                    b.HasOne("tankman.Models.User", "User")
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserId", "OrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_permissions_users_user_id_org_id");

                    b.Navigation("Org");

                    b.Navigation("Resource");

                    b.Navigation("User");
                });

            modelBuilder.Entity("tankman.Models.Org", b =>
                {
                    b.Navigation("Resources");

                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("tankman.Models.Resource", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserPermissions");
                });

            modelBuilder.Entity("tankman.Models.Role", b =>
                {
                    b.Navigation("RoleAssignments");

                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("tankman.Models.User", b =>
                {
                    b.Navigation("RoleAssignments");

                    b.Navigation("UserPermissions");
                });
#pragma warning restore 612, 618
        }
    }
}
