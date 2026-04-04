using System;
using System.Collections.Generic;
using CMS_Riesgird.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Infrastructure.Data;

public partial class RiesgirdDbContext : DbContext
{
    public RiesgirdDbContext()
    {
    }

    public RiesgirdDbContext(DbContextOptions<RiesgirdDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievements> Achievements { get; set; }

    public virtual DbSet<Activities> Activities { get; set; }

    public virtual DbSet<AgendaItems> AgendaItems { get; set; }

    public virtual DbSet<Agreements> Agreements { get; set; }

    public virtual DbSet<AlbumPhotos> AlbumPhotos { get; set; }

    public virtual DbSet<Allies> Allies { get; set; }

    public virtual DbSet<ApplicationDocuments> ApplicationDocuments { get; set; }

    public virtual DbSet<ApplicationStatusHistory> ApplicationStatusHistory { get; set; }

    public virtual DbSet<Assemblies> Assemblies { get; set; }

    public virtual DbSet<AuditLogChanges> AuditLogChanges { get; set; }

    public virtual DbSet<AuditLogs> AuditLogs { get; set; }

    public virtual DbSet<Authorities> Authorities { get; set; }

    public virtual DbSet<CalendarEvents> CalendarEvents { get; set; }

    public virtual DbSet<CommitteeMembers> CommitteeMembers { get; set; }

    public virtual DbSet<Congresses> Congresses { get; set; }

    public virtual DbSet<DownloadableTemplates> DownloadableTemplates { get; set; }

    public virtual DbSet<EventPhotos> EventPhotos { get; set; }

    public virtual DbSet<Experts> Experts { get; set; }

    public virtual DbSet<ForumEvents> ForumEvents { get; set; }

    public virtual DbSet<InstitutionalContents> InstitutionalContents { get; set; }

    public virtual DbSet<ManagementMemories> ManagementMemories { get; set; }

    public virtual DbSet<MembershipApplications> MembershipApplications { get; set; }

    public virtual DbSet<MembershipCertificates> MembershipCertificates { get; set; }

    public virtual DbSet<MembershipRequirements> MembershipRequirements { get; set; }

    public virtual DbSet<NormativeDocuments> NormativeDocuments { get; set; }

    public virtual DbSet<PhotoAlbums> PhotoAlbums { get; set; }

    public virtual DbSet<Publications> Publications { get; set; }

    public virtual DbSet<Researchers> Researchers { get; set; }

    public virtual DbSet<RolePermissions> RolePermissions { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Speakers> Speakers { get; set; }

    public virtual DbSet<SpecializationPrograms> SpecializationPrograms { get; set; }

    public virtual DbSet<SystemConfig> SystemConfig { get; set; }

    public virtual DbSet<TechnicalTeamMembers> TechnicalTeamMembers { get; set; }

    public virtual DbSet<ThematicAxes> ThematicAxes { get; set; }

    public virtual DbSet<Universities> Universities { get; set; }

    public virtual DbSet<UniversityBrigades> UniversityBrigades { get; set; }

    public virtual DbSet<UniversityReports> UniversityReports { get; set; }

    public virtual DbSet<UserPermissions> UserPermissions { get; set; }

    public virtual DbSet<UserSessions> UserSessions { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<VideoItems> VideoItems { get; set; }

    public virtual DbSet<VwApplicationsDetail> VwApplicationsDetail { get; set; }

    public virtual DbSet<VwDashboardStats> VwDashboardStats { get; set; }

    public virtual DbSet<VwUniversitiesSummary> VwUniversitiesSummary { get; set; }

    public virtual DbSet<VwUsersDetail> VwUsersDetail { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("panel_red", "academic_degree", new[] { "licenciado", "maestro", "magister", "doctor", "postdoctor" })
            .HasPostgresEnum("panel_red", "action_type", new[] { "create", "read", "view", "update", "delete", "publish", "approve", "manage_visibility" })
            .HasPostgresEnum("panel_red", "activity_type", new[] { "academica", "investigacion", "extension", "gestion", "cooperacion" })
            .HasPostgresEnum("panel_red", "agreement_status", new[] { "pendiente", "en_proceso", "cumplido", "no_cumplido" })
            .HasPostgresEnum("panel_red", "album_event_type", new[] { "congreso", "asamblea", "foro", "actividad_academica", "institucional", "capacitacion", "otro" })
            .HasPostgresEnum("panel_red", "album_type", new[] { "fotos", "videos", "mixto" })
            .HasPostgresEnum("panel_red", "ally_type", new[] { "cooperacion_internacional", "gobierno", "colegio_profesional", "institucion_privada", "otro" })
            .HasPostgresEnum("panel_red", "application_doc_type", new[] { "carta_solicitud", "resolucion_secretario", "resolucion_comite", "otro" })
            .HasPostgresEnum("panel_red", "application_status", new[] { "pendiente", "recibida", "en_revision", "documentos_pendientes", "documentacion_incompleta", "aprobada", "rechazada" })
            .HasPostgresEnum("panel_red", "assembly_status", new[] { "programada", "en_curso", "finalizada", "completada", "cancelada" })
            .HasPostgresEnum("panel_red", "assembly_type", new[] { "ordinaria", "extraordinaria" })
            .HasPostgresEnum("panel_red", "authority_role", new[] { "rector", "vicerrector_academico", "vicerrector_investigacion", "director_gird", "coordinador", "otro" })
            .HasPostgresEnum("panel_red", "brigade_status", new[] { "activa", "en_formacion", "inactiva" })
            .HasPostgresEnum("panel_red", "brigade_type", new[] { "emergencias", "primeros_auxilios", "evacuacion", "comunicaciones", "logistica" })
            .HasPostgresEnum("panel_red", "calendar_event_status", new[] { "programada", "en_curso", "finalizada", "cancelada" })
            .HasPostgresEnum("panel_red", "calendar_event_type", new[] { "asamblea", "foro", "congreso", "reunion", "capacitacion", "general", "otro" })
            .HasPostgresEnum("panel_red", "config_value_type", new[] { "string", "number", "boolean", "json" })
            .HasPostgresEnum("panel_red", "congress_scope", new[] { "nacional", "internacional", "regional" })
            .HasPostgresEnum("panel_red", "congress_status", new[] { "planificado", "convocatoria_abierta", "en_curso", "finalizado" })
            .HasPostgresEnum("panel_red", "congress_type", new[] { "congreso", "simposio", "encuentro", "jornada", "foro" })
            .HasPostgresEnum("panel_red", "document_validation_status", new[] { "pendiente", "aprobado", "rechazado" })
            .HasPostgresEnum("panel_red", "event_modality", new[] { "presencial", "virtual", "hibrida" })
            .HasPostgresEnum("panel_red", "event_photo_event_type", new[] { "asamblea", "foro", "congreso", "actividad" })
            .HasPostgresEnum("panel_red", "forum_event_status", new[] { "borrador", "publicado", "en_curso", "finalizado", "cancelado" })
            .HasPostgresEnum("panel_red", "forum_event_type", new[] { "convocatoria", "evento_conjunto", "informacion", "capacitacion", "taller", "seminario", "congreso", "conferencia", "webinar", "reunion" })
            .HasPostgresEnum("panel_red", "impact_level", new[] { "alto", "medio", "bajo" })
            .HasPostgresEnum("panel_red", "institutional_content_type", new[] { "mision", "vision", "objetivos", "lineamientos" })
            .HasPostgresEnum("panel_red", "membership_status", new[] { "pendiente", "en_proceso", "activo", "suspendido", "inactivo" })
            .HasPostgresEnum("panel_red", "memory_status", new[] { "borrador", "revision", "publicada" })
            .HasPostgresEnum("panel_red", "memory_type", new[] { "anual", "semestral", "especial" })
            .HasPostgresEnum("panel_red", "module_name", new[] { "identidad_normativa", "universidades", "membresia", "gobernanza", "conocimiento", "memorias", "usuarios", "configuracion" })
            .HasPostgresEnum("panel_red", "normative_document_type", new[] { "estatuto", "plan_trabajo", "reglamento", "otro" })
            .HasPostgresEnum("panel_red", "presentation_type", new[] { "magistral", "conferencia", "panel", "taller" })
            .HasPostgresEnum("panel_red", "program_status", new[] { "planificado", "inscripciones_abiertas", "activo", "proximo", "en_curso", "finalizado", "cancelado" })
            .HasPostgresEnum("panel_red", "program_type", new[] { "diplomado", "especializacion", "maestria", "curso", "taller", "laboratorio_territorial" })
            .HasPostgresEnum("panel_red", "publication_type", new[] { "articulo", "libro", "capitulo_libro", "tesis", "ponencia", "informe", "otro" })
            .HasPostgresEnum("panel_red", "report_status", new[] { "borrador", "en_revision", "aprobado", "publicado" })
            .HasPostgresEnum("panel_red", "report_type", new[] { "actividades_gird", "actividades_acc", "informe_anual", "otro" })
            .HasPostgresEnum("panel_red", "requirement_category", new[] { "documentacion", "legal", "institucional", "tecnico", "financiero", "otro" })
            .HasPostgresEnum("panel_red", "requirement_type", new[] { "obligatorio", "opcional" })
            .HasPostgresEnum("panel_red", "team_type", new[] { "secretaria_tecnica", "comite_interareas", "grupo_trabajo" })
            .HasPostgresEnum("panel_red", "template_category", new[] { "membresia", "informes", "solicitudes", "otros" })
            .HasPostgresEnum("panel_red", "template_doc_type", new[] { "carta_solicitud", "resolucion_secretario", "resolucion_comite", "certificado_membresia", "otro" })
            .HasPostgresEnum("panel_red", "template_format", new[] { "PDF", "DOCX", "XLSX", "PPTX" })
            .HasPostgresEnum("panel_red", "user_role", new[] { "super_admin", "admin_red", "admin_universidad", "editor", "viewer" })
            .HasPostgresEnum("panel_red", "video_type", new[] { "conferencia", "panel", "entrevista", "resumen", "otro" })
            .HasPostgresExtension("panel_red", "pgcrypto")
            .HasPostgresExtension("panel_red", "uuid-ossp");

        modelBuilder.Entity<Achievements>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("achievements_pkey");

            entity.ToTable("achievements", "panel_red", tb => tb.HasComment("Logros destacados asociados a cada memoria de gestión"));

            entity.HasIndex(e => e.MemoryId, "idx_achievement_memory");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(255)
                .HasColumnName("category");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EvidenceUrl).HasColumnName("evidence_url");
            entity.Property(e => e.MemoryId).HasColumnName("memory_id");
            entity.Property(e => e.SortOrder)
                .HasDefaultValue(0)
                .HasColumnName("sort_order");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");

            entity.HasOne(d => d.Memory).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.MemoryId)
                .HasConstraintName("achievements_memory_id_fkey");
        });

        modelBuilder.Entity<Activities>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("activities_pkey");

            entity.ToTable("activities", "panel_red", tb => tb.HasComment("Actividades realizadas asociadas a cada memoria de gestión"));

            entity.HasIndex(e => e.MemoryId, "idx_activity_memory");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DocumentsUrls)
                .HasDefaultValueSql("'{}'::text[]")
                .HasColumnName("documents_urls");
            entity.Property(e => e.Location)
                .HasMaxLength(500)
                .HasColumnName("location");
            entity.Property(e => e.MemoryId).HasColumnName("memory_id");
            entity.Property(e => e.Participants).HasColumnName("participants");
            entity.Property(e => e.Photos)
                .HasDefaultValueSql("'{}'::text[]")
                .HasColumnName("photos");
            entity.Property(e => e.SortOrder)
                .HasDefaultValue(0)
                .HasColumnName("sort_order");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");

            entity.HasOne(d => d.Memory).WithMany(p => p.Activities)
                .HasForeignKey(d => d.MemoryId)
                .HasConstraintName("activities_memory_id_fkey");
        });

        modelBuilder.Entity<AgendaItems>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("agenda_items_pkey");

            entity.ToTable("agenda_items", "panel_red", tb => tb.HasComment("Puntos de agenda de cada asamblea"));

            entity.HasIndex(e => e.AssemblyId, "idx_agenda_assembly");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.AssemblyId).HasColumnName("assembly_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Presenter)
                .HasMaxLength(255)
                .HasColumnName("presenter");
            entity.Property(e => e.SortOrder)
                .HasDefaultValue(0)
                .HasColumnName("sort_order");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");

            entity.HasOne(d => d.Assembly).WithMany(p => p.AgendaItems)
                .HasForeignKey(d => d.AssemblyId)
                .HasConstraintName("agenda_items_assembly_id_fkey");
        });

        modelBuilder.Entity<Agreements>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("agreements_pkey");

            entity.ToTable("agreements", "panel_red", tb => tb.HasComment("Acuerdos tomados en cada asamblea"));

            entity.HasIndex(e => e.AssemblyId, "idx_agreement_assembly");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.AssemblyId).HasColumnName("assembly_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(false)
                .HasColumnName("is_public");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .HasColumnName("number");
            entity.Property(e => e.Responsible)
                .HasMaxLength(255)
                .HasColumnName("responsible");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");

            entity.HasOne(d => d.Assembly).WithMany(p => p.Agreements)
                .HasForeignKey(d => d.AssemblyId)
                .HasConstraintName("agreements_assembly_id_fkey");
        });

        modelBuilder.Entity<AlbumPhotos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("album_photos_pkey");

            entity.ToTable("album_photos", "panel_red", tb => tb.HasComment("Fotos individuales dentro de cada álbum"));

            entity.HasIndex(e => e.AlbumId, "idx_album_photo_album");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.AlbumId).HasColumnName("album_id");
            entity.Property(e => e.Caption)
                .HasMaxLength(500)
                .HasColumnName("caption");
            entity.Property(e => e.IsCover)
                .HasDefaultValue(false)
                .HasColumnName("is_cover");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(true)
                .HasColumnName("is_public");
            entity.Property(e => e.Photographer)
                .HasMaxLength(255)
                .HasColumnName("photographer");
            entity.Property(e => e.SortOrder)
                .HasDefaultValue(0)
                .HasColumnName("sort_order");
            entity.Property(e => e.TakenAt).HasColumnName("taken_at");
            entity.Property(e => e.ThumbnailUrl).HasColumnName("thumbnail_url");
            entity.Property(e => e.Url).HasColumnName("url");

            entity.HasOne(d => d.Album).WithMany(p => p.AlbumPhotos)
                .HasForeignKey(d => d.AlbumId)
                .HasConstraintName("album_photos_album_id_fkey");
        });

        modelBuilder.Entity<Allies>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("allies_pkey");

            entity.ToTable("allies", "panel_red", tb => tb.HasComment("Directorio de aliados estratégicos de la red"));

            entity.HasIndex(e => e.IsActive, "idx_allies_active");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(255)
                .HasColumnName("contact_email");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(50)
                .HasColumnName("contact_phone");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(true)
                .HasColumnName("is_public");
            entity.Property(e => e.LogoUrl).HasColumnName("logo_url");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.SortOrder)
                .HasDefaultValue(0)
                .HasColumnName("sort_order");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.WebsiteUrl).HasColumnName("website_url");
        });

        modelBuilder.Entity<ApplicationDocuments>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("application_documents_pkey");

            entity.ToTable("application_documents", "panel_red", tb => tb.HasComment("Documentos adjuntos a cada solicitud de membresía"));

            entity.HasIndex(e => e.ApplicationId, "idx_app_doc_application");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.FileName)
                .HasMaxLength(500)
                .HasColumnName("file_name");
            entity.Property(e => e.FileUrl).HasColumnName("file_url");
            entity.Property(e => e.IsValid)
                .HasDefaultValue(false)
                .HasColumnName("is_valid");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.UploadDate)
                .HasDefaultValueSql("now()")
                .HasColumnName("upload_date");
            entity.Property(e => e.ValidatedAt).HasColumnName("validated_at");
            entity.Property(e => e.ValidatedBy).HasColumnName("validated_by");
            entity.Property(e => e.ValidationNotes).HasColumnName("validation_notes");

            entity.HasOne(d => d.Application).WithMany(p => p.ApplicationDocuments)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("application_documents_application_id_fkey");

            entity.HasOne(d => d.ValidatedByNavigation).WithMany(p => p.ApplicationDocuments)
                .HasForeignKey(d => d.ValidatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("application_documents_validated_by_fkey");
        });

        modelBuilder.Entity<ApplicationStatusHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("application_status_history_pkey");

            entity.ToTable("application_status_history", "panel_red", tb => tb.HasComment("Trazabilidad de cambios de estado en solicitudes de membresía"));

            entity.HasIndex(e => e.ApplicationId, "idx_status_hist_app");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.ChangedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("changed_at");
            entity.Property(e => e.ChangedBy).HasColumnName("changed_by");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasColumnName("status");

            entity.HasOne(d => d.Application).WithMany(p => p.ApplicationStatusHistory)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("application_status_history_application_id_fkey");

            entity.HasOne(d => d.ChangedByNavigation).WithMany(p => p.ApplicationStatusHistory)
                .HasForeignKey(d => d.ChangedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("application_status_history_changed_by_fkey");
        });

        modelBuilder.Entity<Assemblies>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("assemblies_pkey");

            entity.ToTable("assemblies", "panel_red", tb => tb.HasComment("Asambleas ordinarias y extraordinarias de la red"));

            entity.HasIndex(e => e.Date, "idx_assembly_date");

            entity.HasIndex(e => e.Year, "idx_assembly_year");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.AgendaFileName)
                .HasMaxLength(500)
                .HasColumnName("agenda_file_name");
            entity.Property(e => e.AgendaFileUrl).HasColumnName("agenda_file_url");
            entity.Property(e => e.AgreementsFileName)
                .HasMaxLength(500)
                .HasColumnName("agreements_file_name");
            entity.Property(e => e.AgreementsFileUrl).HasColumnName("agreements_file_url");
            entity.Property(e => e.AttendeesCount).HasColumnName("attendees_count");
            entity.Property(e => e.ConvocationUrl).HasColumnName("convocation_url");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(false)
                .HasColumnName("is_public");
            entity.Property(e => e.Location)
                .HasMaxLength(500)
                .HasColumnName("location");
            entity.Property(e => e.MinutesFileName)
                .HasMaxLength(500)
                .HasColumnName("minutes_file_name");
            entity.Property(e => e.MinutesFileUrl).HasColumnName("minutes_file_url");
            entity.Property(e => e.MinutesUrl).HasColumnName("minutes_url");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.VirtualLink).HasColumnName("virtual_link");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Assemblies)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("assemblies_created_by_fkey");
        });

        modelBuilder.Entity<AuditLogChanges>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("audit_log_changes_pkey");

            entity.ToTable("audit_log_changes", "panel_red", tb => tb.HasComment("Detalle campo por campo de los cambios registrados en auditoría"));

            entity.HasIndex(e => e.AuditLogId, "idx_audit_changes_log");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.AuditLogId).HasColumnName("audit_log_id");
            entity.Property(e => e.Field)
                .HasMaxLength(255)
                .HasColumnName("field");
            entity.Property(e => e.NewValue).HasColumnName("new_value");
            entity.Property(e => e.OldValue).HasColumnName("old_value");

            entity.HasOne(d => d.AuditLog).WithMany(p => p.AuditLogChanges)
                .HasForeignKey(d => d.AuditLogId)
                .HasConstraintName("audit_log_changes_audit_log_id_fkey");
        });

        modelBuilder.Entity<AuditLogs>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("audit_logs_pkey");

            entity.ToTable("audit_logs", "panel_red", tb => tb.HasComment("Registro de auditoría de todas las acciones del sistema"));

            entity.HasIndex(e => new { e.EntityType, e.EntityId }, "idx_audit_entity");

            entity.HasIndex(e => e.Timestamp, "idx_audit_timestamp").IsDescending();

            entity.HasIndex(e => e.UserId, "idx_audit_user");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(100)
                .HasColumnName("action");
            entity.Property(e => e.EntityId)
                .HasMaxLength(255)
                .HasColumnName("entity_id");
            entity.Property(e => e.EntityType)
                .HasMaxLength(100)
                .HasColumnName("entity_type");
            entity.Property(e => e.IpAddress).HasColumnName("ip_address");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("now()")
                .HasColumnName("timestamp");
            entity.Property(e => e.UserAgent).HasColumnName("user_agent");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .HasColumnName("user_name");

            entity.HasOne(d => d.User).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("audit_logs_user_id_fkey");
        });

        modelBuilder.Entity<Authorities>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("authorities_pkey");

            entity.ToTable("authorities", "panel_red", tb => tb.HasComment("Autoridades de cada universidad miembro"));

            entity.HasIndex(e => e.IsCurrent, "idx_auth_current");

            entity.HasIndex(e => e.UniversityId, "idx_auth_university");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.AcademicDegree)
                .HasMaxLength(100)
                .HasColumnName("academic_degree");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Dni)
                .HasMaxLength(50)
                .HasColumnName("dni");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsCurrent)
                .HasDefaultValue(true)
                .HasColumnName("is_current");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(true)
                .HasColumnName("is_public");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");
            entity.Property(e => e.Position)
                .HasMaxLength(255)
                .HasColumnName("position");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.UniversityId).HasColumnName("university_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.University).WithMany(p => p.Authorities)
                .HasForeignKey(d => d.UniversityId)
                .HasConstraintName("authorities_university_id_fkey");
        });

        modelBuilder.Entity<CalendarEvents>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("calendar_events_pkey");

            entity.ToTable("calendar_events", "panel_red", tb => tb.HasComment("Calendario general de actividades de la red"));

            entity.HasIndex(e => e.IsPublic, "idx_calendar_public");

            entity.HasIndex(e => e.StartDate, "idx_calendar_start");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.AllDay)
                .HasDefaultValue(false)
                .HasColumnName("all_day");
            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .HasColumnName("color");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(true)
                .HasColumnName("is_public");
            entity.Property(e => e.Location)
                .HasMaxLength(500)
                .HasColumnName("location");
            entity.Property(e => e.RelatedEntityId).HasColumnName("related_entity_id");
            entity.Property(e => e.RelatedEntityType)
                .HasMaxLength(100)
                .HasColumnName("related_entity_type");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CalendarEvents)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("calendar_events_created_by_fkey");
        });

        modelBuilder.Entity<CommitteeMembers>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("committee_members_pkey");

            entity.ToTable("committee_members", "panel_red", tb => tb.HasComment("Miembros del comité organizador de cada congreso"));

            entity.HasIndex(e => e.CongressId, "idx_committee_congress");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CongressId).HasColumnName("congress_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.Institution)
                .HasMaxLength(500)
                .HasColumnName("institution");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .HasColumnName("role");
            entity.Property(e => e.SortOrder)
                .HasDefaultValue(0)
                .HasColumnName("sort_order");

            entity.HasOne(d => d.Congress).WithMany(p => p.CommitteeMembers)
                .HasForeignKey(d => d.CongressId)
                .HasConstraintName("committee_members_congress_id_fkey");
        });

        modelBuilder.Entity<Congresses>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("congresses_pkey");

            entity.ToTable("congresses", "panel_red", tb => tb.HasComment("Historial de congresos, simposios y encuentros de la red"));

            entity.HasIndex(e => e.Year, "idx_congress_year");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.AbstractsBookFileUrl).HasColumnName("abstracts_book_file_url");
            entity.Property(e => e.BannerUrl).HasColumnName("banner_url");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Edition).HasColumnName("edition");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.HostUniversity)
                .HasMaxLength(500)
                .HasColumnName("host_university");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(true)
                .HasColumnName("is_public");
            entity.Property(e => e.Location)
                .HasMaxLength(500)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.Objectives).HasColumnName("objectives");
            entity.Property(e => e.ParticipantsCount).HasColumnName("participants_count");
            entity.Property(e => e.PhotosAlbumUrl).HasColumnName("photos_album_url");
            entity.Property(e => e.PresentationsCount).HasColumnName("presentations_count");
            entity.Property(e => e.ProceedingsFileUrl).HasColumnName("proceedings_file_url");
            entity.Property(e => e.ProgramFileUrl).HasColumnName("program_file_url");
            entity.Property(e => e.RegistrationUrl).HasColumnName("registration_url");
            entity.Property(e => e.RomanNumber)
                .HasMaxLength(20)
                .HasColumnName("roman_number");
            entity.Property(e => e.SpeakersCount).HasColumnName("speakers_count");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Theme).HasColumnName("theme");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.Venue)
                .HasMaxLength(500)
                .HasColumnName("venue");
            entity.Property(e => e.VideosPlaylistUrl).HasColumnName("videos_playlist_url");
            entity.Property(e => e.WebsiteUrl).HasColumnName("website_url");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Congresses)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("congresses_created_by_fkey");
        });

        modelBuilder.Entity<DownloadableTemplates>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("downloadable_templates_pkey");

            entity.ToTable("downloadable_templates", "panel_red", tb => tb.HasComment("Plantillas y documentos descargables para el proceso de membresía"));

            entity.HasIndex(e => e.IsActive, "idx_template_active");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DownloadCount)
                .HasDefaultValue(0)
                .HasColumnName("download_count");
            entity.Property(e => e.FileName)
                .HasMaxLength(500)
                .HasColumnName("file_name");
            entity.Property(e => e.FileSize)
                .HasMaxLength(50)
                .HasColumnName("file_size");
            entity.Property(e => e.FileUrl).HasColumnName("file_url");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(true)
                .HasColumnName("is_public");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UploadDate)
                .HasDefaultValueSql("now()")
                .HasColumnName("upload_date");
            entity.Property(e => e.UploadedBy).HasColumnName("uploaded_by");
            entity.Property(e => e.Version)
                .HasMaxLength(50)
                .HasColumnName("version");

            entity.HasOne(d => d.UploadedByNavigation).WithMany(p => p.DownloadableTemplates)
                .HasForeignKey(d => d.UploadedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("downloadable_templates_uploaded_by_fkey");
        });

        modelBuilder.Entity<EventPhotos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_photos_pkey");

            entity.ToTable("event_photos", "panel_red", tb => tb.HasComment("Galería fotográfica de eventos (asambleas, foros, congresos)"));

            entity.HasIndex(e => e.IsFeatured, "idx_event_photo_featured");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Caption)
                .HasMaxLength(500)
                .HasColumnName("caption");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.IsFeatured)
                .HasDefaultValue(false)
                .HasColumnName("is_featured");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(true)
                .HasColumnName("is_public");
            entity.Property(e => e.Photographer)
                .HasMaxLength(255)
                .HasColumnName("photographer");
            entity.Property(e => e.SortOrder)
                .HasDefaultValue(0)
                .HasColumnName("sort_order");
            entity.Property(e => e.TakenAt).HasColumnName("taken_at");
            entity.Property(e => e.ThumbnailUrl).HasColumnName("thumbnail_url");
            entity.Property(e => e.UploadedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("uploaded_at");
            entity.Property(e => e.UploadedBy).HasColumnName("uploaded_by");
            entity.Property(e => e.Url).HasColumnName("url");

            entity.HasOne(d => d.UploadedByNavigation).WithMany(p => p.EventPhotos)
                .HasForeignKey(d => d.UploadedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("event_photos_uploaded_by_fkey");
        });

        modelBuilder.Entity<Experts>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("experts_pkey");

            entity.ToTable("experts", "panel_red", tb => tb.HasComment("Directorio de expertos en gestión del riesgo"));

            entity.HasIndex(e => e.IsActive, "idx_expert_active");

            entity.HasIndex(e => e.Country, "idx_expert_country");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.AvailableForConsulting)
                .HasDefaultValue(false)
                .HasColumnName("available_for_consulting");
            entity.Property(e => e.AvailableForResearch)
                .HasDefaultValue(false)
                .HasColumnName("available_for_research");
            entity.Property(e => e.AvailableForTraining)
                .HasDefaultValue(false)
                .HasColumnName("available_for_training");
            entity.Property(e => e.Bio).HasColumnName("bio");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CvFileUrl).HasColumnName("cv_file_url");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.ExpertiseAreas)
                .HasDefaultValueSql("'{}'::text[]")
                .HasColumnName("expertise_areas");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.Institution)
                .HasMaxLength(500)
                .HasColumnName("institution");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsAvailable)
                .HasDefaultValue(true)
                .HasColumnName("is_available");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(true)
                .HasColumnName("is_public");
            entity.Property(e => e.LinkedinUrl).HasColumnName("linkedin_url");
            entity.Property(e => e.Organization)
                .HasMaxLength(500)
                .HasColumnName("organization");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");
            entity.Property(e => e.Position)
                .HasMaxLength(255)
                .HasColumnName("position");
            entity.Property(e => e.Specialties)
                .HasDefaultValueSql("'{}'::text[]")
                .HasColumnName("specialties");
            entity.Property(e => e.SpecialtyInRiskGovernance).HasColumnName("specialty_in_risk_governance");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.Website).HasColumnName("website");
            entity.Property(e => e.YearsOfExperience).HasColumnName("years_of_experience");
        });

        modelBuilder.Entity<ForumEvents>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("forum_events_pkey");

            entity.ToTable("forum_events", "panel_red", tb => tb.HasComment("Foros, convocatorias, capacitaciones y eventos de la red"));

            entity.HasIndex(e => e.StartDate, "idx_forum_start");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.BannerUrl).HasColumnName("banner_url");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CurrentParticipants)
                .HasDefaultValue(0)
                .HasColumnName("current_participants");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(false)
                .HasColumnName("is_public");
            entity.Property(e => e.Location)
                .HasMaxLength(500)
                .HasColumnName("location");
            entity.Property(e => e.MaxParticipants).HasColumnName("max_participants");
            entity.Property(e => e.Organizers).HasColumnName("organizers");
            entity.Property(e => e.ProgramFileUrl).HasColumnName("program_file_url");
            entity.Property(e => e.RegisteredCount)
                .HasDefaultValue(0)
                .HasColumnName("registered_count");
            entity.Property(e => e.RegistrationUrl).HasColumnName("registration_url");
            entity.Property(e => e.RequiresRegistration)
                .HasDefaultValue(false)
                .HasColumnName("requires_registration");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.TargetAudience).HasColumnName("target_audience");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.VirtualLink).HasColumnName("virtual_link");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ForumEvents)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("forum_events_created_by_fkey");
        });

        modelBuilder.Entity<InstitutionalContents>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("institutional_contents_pkey");

            entity.ToTable("institutional_contents", "panel_red", tb => tb.HasComment("Contenido institucional: misión, visión, objetivos, lineamientos"));

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(true)
                .HasColumnName("is_public");
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("now()")
                .HasColumnName("last_updated");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.InstitutionalContents)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("institutional_contents_updated_by_fkey");
        });

        modelBuilder.Entity<ManagementMemories>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("management_memories_pkey");

            entity.ToTable("management_memories", "panel_red", tb => tb.HasComment("Memorias de gestión anuales, semestrales y especiales"));

            entity.HasIndex(e => e.Year, "idx_memory_year");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CoverImageUrl).HasColumnName("cover_image_url");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CustomStats)
                .HasDefaultValueSql("'[]'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("custom_stats");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DigitalBookUrl).HasColumnName("digital_book_url");
            entity.Property(e => e.DocumentUrl).HasColumnName("document_url");
            entity.Property(e => e.Highlights).HasColumnName("highlights");
            entity.Property(e => e.Introduction).HasColumnName("introduction");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(false)
                .HasColumnName("is_public");
            entity.Property(e => e.PageCount).HasColumnName("page_count");
            entity.Property(e => e.Period)
                .HasMaxLength(100)
                .HasColumnName("period");
            entity.Property(e => e.President)
                .HasMaxLength(255)
                .HasColumnName("president");
            entity.Property(e => e.PublishedAt).HasColumnName("published_at");
            entity.Property(e => e.PublishedDate).HasColumnName("published_date");
            entity.Property(e => e.Summary).HasColumnName("summary");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ManagementMemories)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("management_memories_created_by_fkey");
        });

        modelBuilder.Entity<MembershipApplications>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("membership_applications_pkey");

            entity.ToTable("membership_applications", "panel_red", tb => tb.HasComment("Solicitudes de membresía y adscripción de universidades"));

            entity.HasIndex(e => e.ApplicationDate, "idx_app_date");

            entity.HasIndex(e => e.UniversityId, "idx_app_university");

            entity.HasIndex(e => e.ApplicationNumber, "membership_applications_application_number_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.ApplicantEmail)
                .HasMaxLength(255)
                .HasColumnName("applicant_email");
            entity.Property(e => e.ApplicantName)
                .HasMaxLength(255)
                .HasColumnName("applicant_name");
            entity.Property(e => e.ApplicantPhone)
                .HasMaxLength(50)
                .HasColumnName("applicant_phone");
            entity.Property(e => e.ApplicationDate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("application_date");
            entity.Property(e => e.ApplicationNumber)
                .HasMaxLength(100)
                .HasColumnName("application_number");
            entity.Property(e => e.AssignedTo).HasColumnName("assigned_to");
            entity.Property(e => e.CertificateAssigned)
                .HasDefaultValue(false)
                .HasColumnName("certificate_assigned");
            entity.Property(e => e.CertificateDate).HasColumnName("certificate_date");
            entity.Property(e => e.CertificateFileUrl).HasColumnName("certificate_file_url");
            entity.Property(e => e.CertificateNumber)
                .HasMaxLength(100)
                .HasColumnName("certificate_number");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(255)
                .HasColumnName("contact_email");
            entity.Property(e => e.ContactName)
                .HasMaxLength(255)
                .HasColumnName("contact_name");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(50)
                .HasColumnName("contact_phone");
            entity.Property(e => e.ContactPosition)
                .HasMaxLength(255)
                .HasColumnName("contact_position");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.RejectionReason).HasColumnName("rejection_reason");
            entity.Property(e => e.ReviewCompletedAt).HasColumnName("review_completed_at");
            entity.Property(e => e.ReviewStartedAt).HasColumnName("review_started_at");
            entity.Property(e => e.ReviewedBy).HasColumnName("reviewed_by");
            entity.Property(e => e.SubmittedAt).HasColumnName("submitted_at");
            entity.Property(e => e.UniversityId).HasColumnName("university_id");
            entity.Property(e => e.UniversityName)
                .HasMaxLength(500)
                .HasColumnName("university_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.MembershipApplicationsAssignedToNavigation)
                .HasForeignKey(d => d.AssignedTo)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("membership_applications_assigned_to_fkey");

            entity.HasOne(d => d.ReviewedByNavigation).WithMany(p => p.MembershipApplicationsReviewedByNavigation)
                .HasForeignKey(d => d.ReviewedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("membership_applications_reviewed_by_fkey");

            entity.HasOne(d => d.University).WithMany(p => p.MembershipApplications)
                .HasForeignKey(d => d.UniversityId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("membership_applications_university_id_fkey");
        });

        modelBuilder.Entity<MembershipCertificates>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("membership_certificates_pkey");

            entity.ToTable("membership_certificates", "panel_red", tb => tb.HasComment("Certificados de membresía emitidos a universidades"));

            entity.HasIndex(e => e.CertificateNumber, "idx_cert_number");

            entity.HasIndex(e => e.Status, "idx_cert_status");

            entity.HasIndex(e => e.UniversityId, "idx_cert_university");

            entity.HasIndex(e => e.CertificateNumber, "membership_certificates_certificate_number_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CertificateNumber)
                .HasMaxLength(100)
                .HasColumnName("certificate_number");
            entity.Property(e => e.CertificateType)
                .HasMaxLength(100)
                .HasColumnName("certificate_type");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.GeneratedFileUrl).HasColumnName("generated_file_url");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IssueDate).HasColumnName("issue_date");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'activo'::character varying")
                .HasColumnName("status");
            entity.Property(e => e.TemplateId).HasColumnName("template_id");
            entity.Property(e => e.UniversityId).HasColumnName("university_id");
            entity.Property(e => e.UniversityName)
                .HasMaxLength(500)
                .HasColumnName("university_name");
            entity.Property(e => e.ValidFrom).HasColumnName("valid_from");
            entity.Property(e => e.ValidTo).HasColumnName("valid_to");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MembershipCertificates)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("membership_certificates_created_by_fkey");

            entity.HasOne(d => d.Template).WithMany(p => p.MembershipCertificates)
                .HasForeignKey(d => d.TemplateId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("membership_certificates_template_id_fkey");

            entity.HasOne(d => d.University).WithMany(p => p.MembershipCertificates)
                .HasForeignKey(d => d.UniversityId)
                .HasConstraintName("membership_certificates_university_id_fkey");
        });

        modelBuilder.Entity<MembershipRequirements>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("membership_requirements_pkey");

            entity.ToTable("membership_requirements", "panel_red", tb => tb.HasComment("Requisitos para el proceso de membresía / adscripción"));

            entity.HasIndex(e => e.IsActive, "idx_req_active");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DocumentFormat)
                .HasMaxLength(100)
                .HasColumnName("document_format");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsRequired)
                .HasDefaultValue(true)
                .HasColumnName("is_required");
            entity.Property(e => e.MaxFileSize)
                .HasMaxLength(50)
                .HasColumnName("max_file_size");
            entity.Property(e => e.SortOrder)
                .HasDefaultValue(0)
                .HasColumnName("sort_order");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<NormativeDocuments>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("normative_documents_pkey");

            entity.ToTable("normative_documents", "panel_red", tb => tb.HasComment("Documentos normativos: estatutos, planes de trabajo, reglamentos"));

            entity.HasIndex(e => e.IsActive, "idx_norm_doc_active");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.FileName)
                .HasMaxLength(500)
                .HasColumnName("file_name");
            entity.Property(e => e.FileSize)
                .HasDefaultValue(0L)
                .HasColumnName("file_size");
            entity.Property(e => e.FileUrl).HasColumnName("file_url");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(true)
                .HasColumnName("is_public");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.UploadDate)
                .HasDefaultValueSql("now()")
                .HasColumnName("upload_date");
            entity.Property(e => e.UploadedBy).HasColumnName("uploaded_by");
            entity.Property(e => e.ValidFrom).HasColumnName("valid_from");
            entity.Property(e => e.ValidTo).HasColumnName("valid_to");

            entity.HasOne(d => d.UploadedByNavigation).WithMany(p => p.NormativeDocuments)
                .HasForeignKey(d => d.UploadedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("normative_documents_uploaded_by_fkey");
        });

        modelBuilder.Entity<PhotoAlbums>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("photo_albums_pkey");

            entity.ToTable("photo_albums", "panel_red", tb => tb.HasComment("Álbumes de fotos y multimedia de eventos"));

            entity.HasIndex(e => e.Date, "idx_album_date");

            entity.HasIndex(e => e.IsFeatured, "idx_album_featured");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CoverImageUrl).HasColumnName("cover_image_url");
            entity.Property(e => e.CoverPhotoUrl).HasColumnName("cover_photo_url");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DownloadUrl).HasColumnName("download_url");
            entity.Property(e => e.EventDate).HasColumnName("event_date");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.EventName)
                .HasMaxLength(500)
                .HasColumnName("event_name");
            entity.Property(e => e.ExternalUrl).HasColumnName("external_url");
            entity.Property(e => e.IsFeatured)
                .HasDefaultValue(false)
                .HasColumnName("is_featured");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(true)
                .HasColumnName("is_public");
            entity.Property(e => e.ItemsCount)
                .HasDefaultValue(0)
                .HasColumnName("items_count");
            entity.Property(e => e.Tags).HasColumnName("tags");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PhotoAlbums)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("photo_albums_created_by_fkey");
        });

        modelBuilder.Entity<Publications>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("publications_pkey");

            entity.ToTable("publications", "panel_red", tb => tb.HasComment("Publicaciones y producción científica de investigadores"));

            entity.HasIndex(e => e.ResearcherId, "idx_pub_researcher");

            entity.HasIndex(e => e.Year, "idx_pub_year");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Abstract).HasColumnName("abstract");
            entity.Property(e => e.Authors)
                .HasDefaultValueSql("'{}'::text[]")
                .HasColumnName("authors");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Doi)
                .HasMaxLength(255)
                .HasColumnName("doi");
            entity.Property(e => e.FileUrl).HasColumnName("file_url");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(true)
                .HasColumnName("is_public");
            entity.Property(e => e.Journal)
                .HasMaxLength(500)
                .HasColumnName("journal");
            entity.Property(e => e.Keywords)
                .HasDefaultValueSql("'{}'::text[]")
                .HasColumnName("keywords");
            entity.Property(e => e.Pages)
                .HasMaxLength(100)
                .HasColumnName("pages");
            entity.Property(e => e.ResearcherId).HasColumnName("researcher_id");
            entity.Property(e => e.Title)
                .HasMaxLength(1000)
                .HasColumnName("title");
            entity.Property(e => e.Url).HasColumnName("url");
            entity.Property(e => e.Volume)
                .HasMaxLength(100)
                .HasColumnName("volume");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Researcher).WithMany(p => p.Publications)
                .HasForeignKey(d => d.ResearcherId)
                .HasConstraintName("publications_researcher_id_fkey");
        });

        modelBuilder.Entity<Researchers>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("researchers_pkey");

            entity.ToTable("researchers", "panel_red", tb => tb.HasComment("Investigadores registrados por universidad miembro"));

            entity.HasIndex(e => e.IsActive, "idx_researcher_active");

            entity.HasIndex(e => e.UniversityId, "idx_researcher_univ");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Bio).HasColumnName("bio");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Department)
                .HasMaxLength(255)
                .HasColumnName("department");
            entity.Property(e => e.Dni)
                .HasMaxLength(50)
                .HasColumnName("dni");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Faculty)
                .HasMaxLength(255)
                .HasColumnName("faculty");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.GoogleScholarUrl).HasColumnName("google_scholar_url");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(true)
                .HasColumnName("is_public");
            entity.Property(e => e.OrcidId)
                .HasMaxLength(100)
                .HasColumnName("orcid_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");
            entity.Property(e => e.Position)
                .HasMaxLength(255)
                .HasColumnName("position");
            entity.Property(e => e.PublicationsCount)
                .HasDefaultValue(0)
                .HasColumnName("publications_count");
            entity.Property(e => e.ResearchAreas)
                .HasDefaultValueSql("'{}'::text[]")
                .HasColumnName("research_areas");
            entity.Property(e => e.ScopusId)
                .HasMaxLength(100)
                .HasColumnName("scopus_id");
            entity.Property(e => e.Specialty)
                .HasMaxLength(255)
                .HasColumnName("specialty");
            entity.Property(e => e.UniversityId).HasColumnName("university_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.University).WithMany(p => p.Researchers)
                .HasForeignKey(d => d.UniversityId)
                .HasConstraintName("researchers_university_id_fkey");
        });

        modelBuilder.Entity<RolePermissions>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_permissions_pkey");

            entity.ToTable("role_permissions", "panel_red", tb => tb.HasComment("Matriz de permisos: qué acciones puede realizar cada rol en cada módulo"));

            entity.HasIndex(e => e.RoleId, "idx_role_perm_role");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.IsAllowed)
                .HasDefaultValue(true)
                .HasColumnName("is_allowed");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("role_permissions_role_id_fkey");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles", "panel_red", tb => tb.HasComment("Roles del sistema con niveles jerárquicos"));

            entity.HasIndex(e => e.Name, "roles_name_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .HasColumnName("color");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Level)
                .HasDefaultValue(0)
                .HasColumnName("level");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Speakers>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("speakers_pkey");

            entity.ToTable("speakers", "panel_red", tb => tb.HasComment("Ponentes y conferencistas de cada congreso"));

            entity.HasIndex(e => e.CongressId, "idx_speaker_congress");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Biography).HasColumnName("biography");
            entity.Property(e => e.CongressId).HasColumnName("congress_id");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.Institution)
                .HasMaxLength(500)
                .HasColumnName("institution");
            entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");
            entity.Property(e => e.PresentationTitle)
                .HasMaxLength(500)
                .HasColumnName("presentation_title");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Congress).WithMany(p => p.Speakers)
                .HasForeignKey(d => d.CongressId)
                .HasConstraintName("speakers_congress_id_fkey");
        });

        modelBuilder.Entity<SpecializationPrograms>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("specialization_programs_pkey");

            entity.ToTable("specialization_programs", "panel_red", tb => tb.HasComment("Programas de formación: diplomados, especializaciones, cursos, talleres"));

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.BrochureFileUrl).HasColumnName("brochure_file_url");
            entity.Property(e => e.Coordinator)
                .HasMaxLength(255)
                .HasColumnName("coordinator");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Credits).HasColumnName("credits");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration)
                .HasMaxLength(100)
                .HasColumnName("duration");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.EnrollmentOpen)
                .HasDefaultValue(false)
                .HasColumnName("enrollment_open");
            entity.Property(e => e.GraduatesCount)
                .HasDefaultValue(0)
                .HasColumnName("graduates_count");
            entity.Property(e => e.ImageUrl).HasColumnName("image_url");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(true)
                .HasColumnName("is_public");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.Objectives).HasColumnName("objectives");
            entity.Property(e => e.OrganizingUniversities).HasColumnName("organizing_universities");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.RegistrationDeadline).HasColumnName("registration_deadline");
            entity.Property(e => e.RegistrationUrl).HasColumnName("registration_url");
            entity.Property(e => e.Requirements).HasColumnName("requirements");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.SyllabusFileUrl).HasColumnName("syllabus_file_url");
            entity.Property(e => e.TargetAudience).HasColumnName("target_audience");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SystemConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("system_config_pkey");

            entity.ToTable("system_config", "panel_red", tb => tb.HasComment("Parámetros de configuración global del sistema"));

            entity.HasIndex(e => e.Key, "idx_sys_config_key").IsUnique();

            entity.HasIndex(e => e.Key, "system_config_key_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsEditable)
                .HasDefaultValue(true)
                .HasColumnName("is_editable");
            entity.Property(e => e.Key)
                .HasMaxLength(255)
                .HasColumnName("key");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.Value)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("value");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.SystemConfig)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("system_config_updated_by_fkey");
        });

        modelBuilder.Entity<TechnicalTeamMembers>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("technical_team_members_pkey");

            entity.ToTable("technical_team_members", "panel_red", tb => tb.HasComment("Miembros de equipos técnicos por universidad"));

            entity.HasIndex(e => e.IsActive, "idx_tech_team_active");

            entity.HasIndex(e => e.UniversityId, "idx_tech_team_univ");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.AreaRepresented)
                .HasMaxLength(255)
                .HasColumnName("area_represented");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Dni)
                .HasMaxLength(50)
                .HasColumnName("dni");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(true)
                .HasColumnName("is_public");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");
            entity.Property(e => e.Position)
                .HasMaxLength(255)
                .HasColumnName("position");
            entity.Property(e => e.ResolutionDate).HasColumnName("resolution_date");
            entity.Property(e => e.ResolutionFileUrl).HasColumnName("resolution_file_url");
            entity.Property(e => e.ResolutionNumber)
                .HasMaxLength(100)
                .HasColumnName("resolution_number");
            entity.Property(e => e.Specialty)
                .HasMaxLength(255)
                .HasColumnName("specialty");
            entity.Property(e => e.UniversityId).HasColumnName("university_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.University).WithMany(p => p.TechnicalTeamMembers)
                .HasForeignKey(d => d.UniversityId)
                .HasConstraintName("technical_team_members_university_id_fkey");
        });

        modelBuilder.Entity<ThematicAxes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("thematic_axes_pkey");

            entity.ToTable("thematic_axes", "panel_red", tb => tb.HasComment("Ejes temáticos de cada congreso"));

            entity.HasIndex(e => e.CongressId, "idx_axis_congress");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CongressId).HasColumnName("congress_id");
            entity.Property(e => e.Coordinator)
                .HasMaxLength(255)
                .HasColumnName("coordinator");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.SortOrder)
                .HasDefaultValue(0)
                .HasColumnName("sort_order");

            entity.HasOne(d => d.Congress).WithMany(p => p.ThematicAxes)
                .HasForeignKey(d => d.CongressId)
                .HasConstraintName("thematic_axes_congress_id_fkey");
        });

        modelBuilder.Entity<Universities>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("universities_pkey");

            entity.ToTable("universities", "panel_red", tb => tb.HasComment("Universidades miembros de la red"));

            entity.HasIndex(e => e.IsActive, "idx_univ_active");

            entity.HasIndex(e => e.Region, "idx_univ_region");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.CertificateFileUrl).HasColumnName("certificate_file_url");
            entity.Property(e => e.CertificateNumber)
                .HasMaxLength(100)
                .HasColumnName("certificate_number");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.FoundedYear).HasColumnName("founded_year");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(true)
                .HasColumnName("is_public");
            entity.Property(e => e.LogoUrl).HasColumnName("logo_url");
            entity.Property(e => e.MembershipDate).HasColumnName("membership_date");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.Region)
                .HasMaxLength(255)
                .HasColumnName("region");
            entity.Property(e => e.ShortName)
                .HasMaxLength(100)
                .HasColumnName("short_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.WebsiteUrl).HasColumnName("website_url");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UniversitiesCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("universities_created_by_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.UniversitiesUpdatedByNavigation)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("universities_updated_by_fkey");
        });

        modelBuilder.Entity<UniversityBrigades>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("university_brigades_pkey");

            entity.ToTable("university_brigades", "panel_red", tb => tb.HasComment("Brigadas de gestión del riesgo por universidad"));

            entity.HasIndex(e => e.UniversityId, "idx_brigade_univ");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Certifications).HasColumnName("certifications");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(255)
                .HasColumnName("contact_email");
            entity.Property(e => e.Coordinator)
                .HasMaxLength(255)
                .HasColumnName("coordinator");
            entity.Property(e => e.CoordinatorEmail)
                .HasMaxLength(255)
                .HasColumnName("coordinator_email");
            entity.Property(e => e.CoordinatorPhone)
                .HasMaxLength(50)
                .HasColumnName("coordinator_phone");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.FoundedDate).HasColumnName("founded_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(true)
                .HasColumnName("is_public");
            entity.Property(e => e.LogoUrl).HasColumnName("logo_url");
            entity.Property(e => e.MembersCount)
                .HasDefaultValue(0)
                .HasColumnName("members_count");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.UniversityId).HasColumnName("university_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.University).WithMany(p => p.UniversityBrigades)
                .HasForeignKey(d => d.UniversityId)
                .HasConstraintName("university_brigades_university_id_fkey");
        });

        modelBuilder.Entity<UniversityReports>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("university_reports_pkey");

            entity.ToTable("university_reports", "panel_red", tb => tb.HasComment("Informes y reportes de cada universidad miembro"));

            entity.HasIndex(e => e.UniversityId, "idx_univ_report_univ");

            entity.HasIndex(e => e.Year, "idx_univ_report_year");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DocumentUrl).HasColumnName("document_url");
            entity.Property(e => e.FileName)
                .HasMaxLength(500)
                .HasColumnName("file_name");
            entity.Property(e => e.FileSize).HasColumnName("file_size");
            entity.Property(e => e.FileUrl).HasColumnName("file_url");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(false)
                .HasColumnName("is_public");
            entity.Property(e => e.PeriodEnd)
                .HasMaxLength(50)
                .HasColumnName("period_end");
            entity.Property(e => e.PeriodStart)
                .HasMaxLength(50)
                .HasColumnName("period_start");
            entity.Property(e => e.SubmittedAt).HasColumnName("submitted_at");
            entity.Property(e => e.SubmittedBy).HasColumnName("submitted_by");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");
            entity.Property(e => e.UniversityId).HasColumnName("university_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UploadDate)
                .HasDefaultValueSql("now()")
                .HasColumnName("upload_date");
            entity.Property(e => e.UploadedBy).HasColumnName("uploaded_by");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.SubmittedByNavigation).WithMany(p => p.UniversityReportsSubmittedByNavigation)
                .HasForeignKey(d => d.SubmittedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("university_reports_submitted_by_fkey");

            entity.HasOne(d => d.University).WithMany(p => p.UniversityReports)
                .HasForeignKey(d => d.UniversityId)
                .HasConstraintName("university_reports_university_id_fkey");

            entity.HasOne(d => d.UploadedByNavigation).WithMany(p => p.UniversityReportsUploadedByNavigation)
                .HasForeignKey(d => d.UploadedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("university_reports_uploaded_by_fkey");
        });

        modelBuilder.Entity<UserPermissions>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_permissions_pkey");

            entity.ToTable("user_permissions", "panel_red", tb => tb.HasComment("Permisos específicos por usuario que sobreescriben los del rol"));

            entity.HasIndex(e => e.UserId, "idx_user_perm_user");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.IsAllowed)
                .HasDefaultValue(true)
                .HasColumnName("is_allowed");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserPermissions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_permissions_user_id_fkey");
        });

        modelBuilder.Entity<UserSessions>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_sessions_pkey");

            entity.ToTable("user_sessions", "panel_red", tb => tb.HasComment("Sesiones activas de usuarios con soporte para remember-me"));

            entity.HasIndex(e => new { e.IsActive, e.ExpiresAt }, "idx_session_active");

            entity.HasIndex(e => e.TokenHash, "idx_session_token");

            entity.HasIndex(e => e.UserId, "idx_session_user");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresAt).HasColumnName("expires_at");
            entity.Property(e => e.IpAddress).HasColumnName("ip_address");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LastActivity)
                .HasDefaultValueSql("now()")
                .HasColumnName("last_activity");
            entity.Property(e => e.RefreshToken)
                .HasMaxLength(512)
                .HasColumnName("refresh_token");
            entity.Property(e => e.RememberMe)
                .HasDefaultValue(false)
                .HasColumnName("remember_me");
            entity.Property(e => e.TokenHash)
                .HasMaxLength(512)
                .HasColumnName("token_hash");
            entity.Property(e => e.UserAgent).HasColumnName("user_agent");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserSessions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_sessions_user_id_fkey");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users", "panel_red", tb => tb.HasComment("Usuarios del sistema con autenticación y perfiles"));

            entity.HasIndex(e => e.IsActive, "idx_users_active");

            entity.HasIndex(e => e.Email, "idx_users_email");

            entity.HasIndex(e => e.RoleId, "idx_users_role");

            entity.HasIndex(e => e.UniversityId, "idx_users_university");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LastLogin).HasColumnName("last_login");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");
            entity.Property(e => e.Position)
                .HasMaxLength(255)
                .HasColumnName("position");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UniversityId).HasColumnName("university_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_role_id_fkey");

            entity.HasOne(d => d.University).WithMany(p => p.Users)
                .HasForeignKey(d => d.UniversityId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_users_university");
        });

        modelBuilder.Entity<VideoItems>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("video_items_pkey");

            entity.ToTable("video_items", "panel_red", tb => tb.HasComment("Videos asociados a congresos y álbumes multimedia"));

            entity.HasIndex(e => e.AlbumId, "idx_video_album");

            entity.HasIndex(e => e.CongressId, "idx_video_congress");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("panel_red.uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.AlbumId).HasColumnName("album_id");
            entity.Property(e => e.CongressId).HasColumnName("congress_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.SortOrder)
                .HasDefaultValue(0)
                .HasColumnName("sort_order");
            entity.Property(e => e.ThumbnailUrl).HasColumnName("thumbnail_url");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");
            entity.Property(e => e.Url).HasColumnName("url");

            entity.HasOne(d => d.Album).WithMany(p => p.VideoItems)
                .HasForeignKey(d => d.AlbumId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("video_items_album_id_fkey");

            entity.HasOne(d => d.Congress).WithMany(p => p.VideoItems)
                .HasForeignKey(d => d.CongressId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("video_items_congress_id_fkey");
        });

        modelBuilder.Entity<VwApplicationsDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_applications_detail", "panel_red");

            entity.Property(e => e.ApplicantEmail)
                .HasMaxLength(255)
                .HasColumnName("applicant_email");
            entity.Property(e => e.ApplicantName)
                .HasMaxLength(255)
                .HasColumnName("applicant_name");
            entity.Property(e => e.ApplicationDate)
                .HasColumnType("date")
                .HasColumnName("application_date");
            entity.Property(e => e.ApplicationNumber)
                .HasMaxLength(100)
                .HasColumnName("application_number");
            entity.Property(e => e.AssignedToName)
                .HasMaxLength(255)
                .HasColumnName("assigned_to_name");
            entity.Property(e => e.CertificateAssigned).HasColumnName("certificate_assigned");
            entity.Property(e => e.CertificateNumber)
                .HasMaxLength(100)
                .HasColumnName("certificate_number");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DocumentsCount).HasColumnName("documents_count");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ReviewedByName)
                .HasMaxLength(255)
                .HasColumnName("reviewed_by_name");
            entity.Property(e => e.UniversityName)
                .HasMaxLength(500)
                .HasColumnName("university_name");
            entity.Property(e => e.ValidDocumentsCount).HasColumnName("valid_documents_count");
        });

        modelBuilder.Entity<VwDashboardStats>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_dashboard_stats", "panel_red");

            entity.Property(e => e.ActiveEvents).HasColumnName("active_events");
            entity.Property(e => e.ActivePrograms).HasColumnName("active_programs");
            entity.Property(e => e.AssembliesThisYear).HasColumnName("assemblies_this_year");
            entity.Property(e => e.PendingApplications).HasColumnName("pending_applications");
            entity.Property(e => e.TotalAlbums).HasColumnName("total_albums");
            entity.Property(e => e.TotalBrigades).HasColumnName("total_brigades");
            entity.Property(e => e.TotalCongresses).HasColumnName("total_congresses");
            entity.Property(e => e.TotalExperts).HasColumnName("total_experts");
            entity.Property(e => e.TotalMembers).HasColumnName("total_members");
            entity.Property(e => e.TotalPublications).HasColumnName("total_publications");
            entity.Property(e => e.TotalResearchers).HasColumnName("total_researchers");
            entity.Property(e => e.TotalUniversitiesActive).HasColumnName("total_universities_active");
        });

        modelBuilder.Entity<VwUniversitiesSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_universities_summary", "panel_red");

            entity.Property(e => e.ActiveBrigadesCount).HasColumnName("active_brigades_count");
            entity.Property(e => e.ActiveResearchersCount).HasColumnName("active_researchers_count");
            entity.Property(e => e.ActiveTeamMembersCount).HasColumnName("active_team_members_count");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.CurrentAuthoritiesCount).HasColumnName("current_authorities_count");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.MembershipDate).HasColumnName("membership_date");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.Region)
                .HasMaxLength(255)
                .HasColumnName("region");
            entity.Property(e => e.ReportsCount).HasColumnName("reports_count");
            entity.Property(e => e.ShortName)
                .HasMaxLength(100)
                .HasColumnName("short_name");
        });

        modelBuilder.Entity<VwUsersDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_users_detail", "panel_red");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.LastLogin)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_login");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");
            entity.Property(e => e.Position)
                .HasMaxLength(255)
                .HasColumnName("position");
            entity.Property(e => e.RoleColor)
                .HasMaxLength(20)
                .HasColumnName("role_color");
            entity.Property(e => e.RoleLevel).HasColumnName("role_level");
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .HasColumnName("role_name");
            entity.Property(e => e.UniversityName)
                .HasMaxLength(500)
                .HasColumnName("university_name");
            entity.Property(e => e.UniversityShortName)
                .HasMaxLength(100)
                .HasColumnName("university_short_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
