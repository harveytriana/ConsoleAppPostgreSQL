using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EscuelaPG
{
    public partial class LabsContext : DbContext
    {
        public LabsContext()
        {
        }

        public LabsContext(DbContextOptions<LabsContext> options)
            : base(options)
        {
        }
        // django admin
        public virtual DbSet<AuthGroup> AuthGroup { get; set; }
        public virtual DbSet<AuthGroupPermissions> AuthGroupPermissions { get; set; }
        public virtual DbSet<AuthPermission> AuthPermission { get; set; }
        public virtual DbSet<AuthUser> AuthUser { get; set; }
        public virtual DbSet<AuthUserGroups> AuthUserGroups { get; set; }
        public virtual DbSet<AuthUserUserPermissions> AuthUserUserPermissions { get; set; }
        public virtual DbSet<DjangoAdminLog> DjangoAdminLog { get; set; }
        public virtual DbSet<DjangoContentType> DjangoContentType { get; set; }
        public virtual DbSet<DjangoMigrations> DjangoMigrations { get; set; }
        public virtual DbSet<DjangoSession> DjangoSession { get; set; }
        // application
        public virtual DbSet<EscuelaAlumno> EscuelaAlumno { get; set; }
        public virtual DbSet<EscuelaCurso> EscuelaCurso { get; set; }
        public virtual DbSet<EscuelaMatricula> EscuelaMatricula { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // To protect potentially sensitive information in your connection string, you should move it out of source code. 
                // See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=labs;Username=postgres;Password=Pragma$2020");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthGroup>(entity =>
            {
                entity.ToTable("auth_group");

                entity.HasIndex(e => e.Name)
                    .HasName("auth_group_name_a6ea08ec_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<AuthGroupPermissions>(entity =>
            {
                entity.ToTable("auth_group_permissions");

                entity.HasIndex(e => e.GroupId)
                    .HasName("auth_group_permissions_group_id_b120cbf9");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("auth_group_permissions_permission_id_84c5c92e");

                entity.HasIndex(e => new { e.GroupId, e.PermissionId })
                    .HasName("auth_group_permissions_group_id_permission_id_0cd325b0_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AuthGroupPermissions)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_group_permissions_group_id_b120cbf9_fk_auth_group_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.AuthGroupPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_group_permissio_permission_id_84c5c92e_fk_auth_perm");
            });

            modelBuilder.Entity<AuthPermission>(entity =>
            {
                entity.ToTable("auth_permission");

                entity.HasIndex(e => e.ContentTypeId)
                    .HasName("auth_permission_content_type_id_2f476e4b");

                entity.HasIndex(e => new { e.ContentTypeId, e.Codename })
                    .HasName("auth_permission_content_type_id_codename_01ab375a_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codename)
                    .IsRequired()
                    .HasColumnName("codename")
                    .HasMaxLength(100);

                entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.HasOne(d => d.ContentType)
                    .WithMany(p => p.AuthPermission)
                    .HasForeignKey(d => d.ContentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_permission_content_type_id_2f476e4b_fk_django_co");
            });

            modelBuilder.Entity<AuthUser>(entity =>
            {
                entity.ToTable("auth_user");

                entity.HasIndex(e => e.Username)
                    .HasName("auth_user_username_6821ab7c_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateJoined)
                    .HasColumnName("date_joined")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(254);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(150);

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsStaff).HasColumnName("is_staff");

                entity.Property(e => e.IsSuperuser).HasColumnName("is_superuser");

                entity.Property(e => e.LastLogin)
                    .HasColumnName("last_login")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(150);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(128);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<AuthUserGroups>(entity =>
            {
                entity.ToTable("auth_user_groups");

                entity.HasIndex(e => e.GroupId)
                    .HasName("auth_user_groups_group_id_97559544");

                entity.HasIndex(e => e.UserId)
                    .HasName("auth_user_groups_user_id_6a12ed8b");

                entity.HasIndex(e => new { e.UserId, e.GroupId })
                    .HasName("auth_user_groups_user_id_group_id_94350c0c_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AuthUserGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_user_groups_group_id_97559544_fk_auth_group_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuthUserGroups)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_user_groups_user_id_6a12ed8b_fk_auth_user_id");
            });

            modelBuilder.Entity<AuthUserUserPermissions>(entity =>
            {
                entity.ToTable("auth_user_user_permissions");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("auth_user_user_permissions_permission_id_1fbb5f2c");

                entity.HasIndex(e => e.UserId)
                    .HasName("auth_user_user_permissions_user_id_a95ead1b");

                entity.HasIndex(e => new { e.UserId, e.PermissionId })
                    .HasName("auth_user_user_permissions_user_id_permission_id_14a6b632_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.AuthUserUserPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_user_user_permi_permission_id_1fbb5f2c_fk_auth_perm");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuthUserUserPermissions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_user_user_permissions_user_id_a95ead1b_fk_auth_user_id");
            });

            modelBuilder.Entity<DjangoAdminLog>(entity =>
            {
                entity.ToTable("django_admin_log");

                entity.HasIndex(e => e.ContentTypeId)
                    .HasName("django_admin_log_content_type_id_c4bce8eb");

                entity.HasIndex(e => e.UserId)
                    .HasName("django_admin_log_user_id_c564eba6");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActionFlag).HasColumnName("action_flag");

                entity.Property(e => e.ActionTime)
                    .HasColumnName("action_time")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.ChangeMessage)
                    .IsRequired()
                    .HasColumnName("change_message");

                entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");

                entity.Property(e => e.ObjectId).HasColumnName("object_id");

                entity.Property(e => e.ObjectRepr)
                    .IsRequired()
                    .HasColumnName("object_repr")
                    .HasMaxLength(200);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.ContentType)
                    .WithMany(p => p.DjangoAdminLog)
                    .HasForeignKey(d => d.ContentTypeId)
                    .HasConstraintName("django_admin_log_content_type_id_c4bce8eb_fk_django_co");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DjangoAdminLog)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("django_admin_log_user_id_c564eba6_fk_auth_user_id");
            });

            modelBuilder.Entity<DjangoContentType>(entity =>
            {
                entity.ToTable("django_content_type");

                entity.HasIndex(e => new { e.AppLabel, e.Model })
                    .HasName("django_content_type_app_label_model_76bd3d3b_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AppLabel)
                    .IsRequired()
                    .HasColumnName("app_label")
                    .HasMaxLength(100);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnName("model")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DjangoMigrations>(entity =>
            {
                entity.ToTable("django_migrations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.App)
                    .IsRequired()
                    .HasColumnName("app")
                    .HasMaxLength(255);

                entity.Property(e => e.Applied)
                    .HasColumnName("applied")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<DjangoSession>(entity =>
            {
                entity.HasKey(e => e.SessionKey)
                    .HasName("django_session_pkey");

                entity.ToTable("django_session");

                entity.HasIndex(e => e.ExpireDate)
                    .HasName("django_session_expire_date_a5c62663");

                entity.HasIndex(e => e.SessionKey)
                    .HasName("django_session_session_key_c0390e0f_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.Property(e => e.SessionKey)
                    .HasColumnName("session_key")
                    .HasMaxLength(40);

                entity.Property(e => e.ExpireDate)
                    .HasColumnName("expire_date")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.SessionData)
                    .IsRequired()
                    .HasColumnName("session_data");
            });

            modelBuilder.Entity<EscuelaAlumno>(entity =>
            {
                entity.ToTable("Escuela_alumno");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("DNI")
                    .HasMaxLength(8);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<EscuelaCurso>(entity =>
            {
                entity.ToTable("Escuela_curso");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EscuelaMatricula>(entity =>
            {
                entity.ToTable("Escuela_matricula");

                entity.HasIndex(e => e.AlumnoId)
                    .HasName("Escuela_matricula_Alumno_id_9ec02f7c");

                entity.HasIndex(e => e.CursoId)
                    .HasName("Escuela_matricula_Curso_id_9ab9a3bc");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AlumnoId).HasColumnName("Alumno_id");

                entity.Property(e => e.CursoId).HasColumnName("Curso_id");

                entity.Property(e => e.FechaMatricula).HasColumnType("date");

                entity.HasOne(d => d.Alumno)
                    .WithMany(p => p.EscuelaMatricula)
                    .HasForeignKey(d => d.AlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Escuela_matricula_Alumno_id_9ec02f7c_fk_Escuela_alumno_id");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.EscuelaMatricula)
                    .HasForeignKey(d => d.CursoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Escuela_matricula_Curso_id_9ab9a3bc_fk_Escuela_curso_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
