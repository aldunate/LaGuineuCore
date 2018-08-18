using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LaGuineuData
{
    public partial class laguineuContext : DbContext
    {
        public laguineuContext()
        {
        }

        public laguineuContext(DbContextOptions<laguineuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<Clase> Clase { get; set; }
        public virtual DbSet<ClaseGrupoAlumno> ClaseGrupoAlumno { get; set; }
        public virtual DbSet<ClaseMonitor> ClaseMonitor { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Club> Club { get; set; }
        public virtual DbSet<Deporte> Deporte { get; set; }
        public virtual DbSet<Escuela> Escuela { get; set; }
        public virtual DbSet<EscuelaDeporte> EscuelaDeporte { get; set; }
        public virtual DbSet<EscuelaDisponible> EscuelaDisponible { get; set; }
        public virtual DbSet<EscuelaEstacion> EscuelaEstacion { get; set; }
        public virtual DbSet<Estacion> Estacion { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<GrupoMonitorPlantilla> GrupoMonitorPlantilla { get; set; }
        public virtual DbSet<Insituto> Insituto { get; set; }
        public virtual DbSet<Monitor> Monitor { get; set; }
        public virtual DbSet<MonitorDeporte> MonitorDeporte { get; set; }
        public virtual DbSet<MonitorDisponible> MonitorDisponible { get; set; }
        public virtual DbSet<MonitorEstacion> MonitorEstacion { get; set; }
        public virtual DbSet<MonitorTitulo> MonitorTitulo { get; set; }
        public virtual DbSet<Titulo> Titulo { get; set; }
        public virtual DbSet<Token> Token { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Database=laguineu;User=root;Password=Afa0659!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.ToTable("alumno");

                entity.HasIndex(e => e.IdGrupo)
                    .HasName("fk_alumno_grupo1_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Apellidos).HasColumnType("varchar(45)");

                entity.Property(e => e.Email).HasColumnType("varchar(45)");

                entity.Property(e => e.IdGrupo).HasColumnType("int(11)");

                entity.Property(e => e.IdNivel).HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(45)");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.Alumno)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_alumno_grupo1");
            });

            modelBuilder.Entity<Clase>(entity =>
            {
                entity.ToTable("clase");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("fk_clase_cliente1_idx");

                entity.HasIndex(e => e.IdEscuela)
                    .HasName("fk_clase_escuela_idx");

                entity.HasIndex(e => e.IdEstacion)
                    .HasName("fk_clase_estacion_idx");

                entity.HasIndex(e => e.IdGrupo)
                    .HasName("fk_clase_grupo1_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnType("int(11)");

                entity.Property(e => e.IdEscuela).HasColumnType("int(11)");

                entity.Property(e => e.IdEstacion).HasColumnType("int(11)");

                entity.Property(e => e.IdGrupo).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(45)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Clase)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clase_cliente1");

                entity.HasOne(d => d.IdEscuelaNavigation)
                    .WithMany(p => p.Clase)
                    .HasForeignKey(d => d.IdEscuela)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clase_escuela");

                entity.HasOne(d => d.IdEstacionNavigation)
                    .WithMany(p => p.Clase)
                    .HasForeignKey(d => d.IdEstacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clase_estacion");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.Clase)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clase_grupo1");
            });

            modelBuilder.Entity<ClaseGrupoAlumno>(entity =>
            {
                entity.ToTable("clase-grupo-alumno");

                entity.HasIndex(e => e.IdAlumno)
                    .HasName("fk_clase-grupo-alumno_alumno1_idx");

                entity.HasIndex(e => e.IdClase)
                    .HasName("fk_clase-grupo-alumno_clase1_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IdAlumno).HasColumnType("int(11)");

                entity.Property(e => e.IdClase).HasColumnType("int(11)");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.ClaseGrupoAlumno)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clase-grupo-alumno_alumno1");

                entity.HasOne(d => d.IdClaseNavigation)
                    .WithMany(p => p.ClaseGrupoAlumno)
                    .HasForeignKey(d => d.IdClase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clase-grupo-alumno_clase1");
            });

            modelBuilder.Entity<ClaseMonitor>(entity =>
            {
                entity.ToTable("clase-monitor");

                entity.HasIndex(e => e.IdClase)
                    .HasName("FK_Clase_ClaseMonitor_idx");

                entity.HasIndex(e => e.IdMonitor)
                    .HasName("FK_ClaseMonitor_Monitor_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IdClase).HasColumnType("int(11)");

                entity.Property(e => e.IdMonitor).HasColumnType("int(11)");

                entity.HasOne(d => d.IdClaseNavigation)
                    .WithMany(p => p.ClaseMonitor)
                    .HasForeignKey(d => d.IdClase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaseMonitor_Clase");

                entity.HasOne(d => d.IdMonitorNavigation)
                    .WithMany(p => p.ClaseMonitor)
                    .HasForeignKey(d => d.IdMonitor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaseMonitor_Monitor");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.HasIndex(e => e.IdClub)
                    .HasName("fk_cliente_Club1_idx");

                entity.HasIndex(e => e.IdEscuela)
                    .HasName("fk_cliente_escuela1_idx");

                entity.HasIndex(e => e.IdInstituto)
                    .HasName("fk_cliente_Insituto1_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Email).HasColumnType("varchar(45)");

                entity.Property(e => e.IdClub).HasColumnType("int(11)");

                entity.Property(e => e.IdEscuela).HasColumnType("int(11)");

                entity.Property(e => e.IdInstituto).HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(45)");

                entity.Property(e => e.Telefono).HasColumnType("varchar(45)");

                entity.HasOne(d => d.IdClubNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdClub)
                    .HasConstraintName("fk_cliente_Club1");

                entity.HasOne(d => d.IdEscuelaNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdEscuela)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cliente_escuela1");

                entity.HasOne(d => d.IdInstitutoNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdInstituto)
                    .HasConstraintName("fk_cliente_Insituto1");
            });

            modelBuilder.Entity<Club>(entity =>
            {
                entity.HasKey(e => e.IdClub);

                entity.ToTable("club");

                entity.Property(e => e.IdClub).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Deporte>(entity =>
            {
                entity.ToTable("deporte");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Escuela>(entity =>
            {
                entity.ToTable("escuela");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Direccion).HasColumnType("varchar(150)");

                entity.Property(e => e.Email).HasColumnType("varchar(45)");

                entity.Property(e => e.FotoPerfil).HasColumnType("varchar(45)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(45)");

                entity.Property(e => e.Telefono).HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<EscuelaDeporte>(entity =>
            {
                entity.ToTable("escuela-deporte");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IdDeporte).HasColumnType("varchar(45)");

                entity.Property(e => e.IdMonitor).HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<EscuelaDisponible>(entity =>
            {
                entity.ToTable("escuela-disponible");

                entity.HasIndex(e => e.IdEscuela)
                    .HasName("fk_escuela-disponible_escuela_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FechaEvento).HasColumnType("datetime");

                entity.Property(e => e.FechaFinal).HasColumnType("datetime");

                entity.Property(e => e.FechaInicial).HasColumnType("datetime");

                entity.Property(e => e.IdEscuela).HasColumnType("int(11)");

                entity.HasOne(d => d.IdEscuelaNavigation)
                    .WithMany(p => p.EscuelaDisponible)
                    .HasForeignKey(d => d.IdEscuela)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_escuela-disponible_escuela");
            });

            modelBuilder.Entity<EscuelaEstacion>(entity =>
            {
                entity.ToTable("escuela-estacion");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IdEscuela).HasColumnType("int(11)");

                entity.Property(e => e.IdEstacion).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Estacion>(entity =>
            {
                entity.ToTable("estacion");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Country).HasColumnType("varchar(45)");

                entity.Property(e => e.IdDefecto).HasColumnType("int(11)");

                entity.Property(e => e.Name).HasColumnType("varchar(45)");

                entity.Property(e => e.Notes).HasColumnType("varchar(135)");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.ToTable("grupo");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("fk_grupo_cliente1_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IdCliente).HasColumnType("int(11)");

                entity.Property(e => e.IdNivel).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(45)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Grupo)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_grupo_cliente");
            });

            modelBuilder.Entity<GrupoMonitorPlantilla>(entity =>
            {
                entity.ToTable("grupo-monitor-plantilla");

                entity.HasIndex(e => e.IdGrupo)
                    .HasName("fk_grupo-monitor-plantilla_grupo1_idx");

                entity.HasIndex(e => e.IdMonitor)
                    .HasName("fk_grupo-monitor-plantilla_monitor1_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IdGrupo).HasColumnType("int(11)");

                entity.Property(e => e.IdMonitor).HasColumnType("int(11)");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.GrupoMonitorPlantilla)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_grupo-monitor-plantilla_grupo1");

                entity.HasOne(d => d.IdMonitorNavigation)
                    .WithMany(p => p.GrupoMonitorPlantilla)
                    .HasForeignKey(d => d.IdMonitor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_grupo-monitor-plantilla_monitor1");
            });

            modelBuilder.Entity<Insituto>(entity =>
            {
                entity.ToTable("insituto");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Direccion).HasColumnType("varchar(45)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Monitor>(entity =>
            {
                entity.ToTable("monitor");

                entity.HasIndex(e => e.IdEscuela)
                    .HasName("fk_monitor_escuela_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_monitor_usuario_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Apellidos).HasColumnType("varchar(45)");

                entity.Property(e => e.FechaNacimiento).HasColumnType("varchar(45)");

                entity.Property(e => e.FotoPerfil).HasColumnType("varchar(100)");

                entity.Property(e => e.IdEscuela).HasColumnType("int(11)");

                entity.Property(e => e.IdInfo).HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Telefono).HasColumnType("varchar(45)");

                entity.HasOne(d => d.IdEscuelaNavigation)
                    .WithMany(p => p.Monitor)
                    .HasForeignKey(d => d.IdEscuela)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_monitor_escuela");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Monitor)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_monitor_usuario");
            });

            modelBuilder.Entity<MonitorDeporte>(entity =>
            {
                entity.ToTable("monitor-deporte");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IdDeporte).HasColumnType("varchar(45)");

                entity.Property(e => e.IdEscuela).HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<MonitorDisponible>(entity =>
            {
                entity.ToTable("monitor-disponible");

                entity.HasIndex(e => e.IdMonitor)
                    .HasName("FK_Monitor_MonitorDisponible_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FechaEvento).HasColumnType("datetime");

                entity.Property(e => e.FechaFinal).HasColumnType("datetime");

                entity.Property(e => e.FechaInicial).HasColumnType("datetime");

                entity.Property(e => e.IdMonitor).HasColumnType("int(11)");

                entity.HasOne(d => d.IdMonitorNavigation)
                    .WithMany(p => p.MonitorDisponible)
                    .HasForeignKey(d => d.IdMonitor)
                    .HasConstraintName("FK_MonitorDisponible_Monitor");
            });

            modelBuilder.Entity<MonitorEstacion>(entity =>
            {
                entity.ToTable("monitor-estacion");

                entity.HasIndex(e => e.IdEstacion)
                    .HasName("fk_monitor-estacion_estacion_idx");

                entity.HasIndex(e => e.IdMonitor)
                    .HasName("fk_monitor-estacion_monitor_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IdEstacion).HasColumnType("int(11)");

                entity.Property(e => e.IdMonitor).HasColumnType("int(11)");

                entity.HasOne(d => d.IdEstacionNavigation)
                    .WithMany(p => p.MonitorEstacion)
                    .HasForeignKey(d => d.IdEstacion)
                    .HasConstraintName("fk_monitor-estacion_estacion");

                entity.HasOne(d => d.IdMonitorNavigation)
                    .WithMany(p => p.MonitorEstacion)
                    .HasForeignKey(d => d.IdMonitor)
                    .HasConstraintName("fk_monitor-estacion_monitor");
            });

            modelBuilder.Entity<MonitorTitulo>(entity =>
            {
                entity.ToTable("monitor-titulo");

                entity.HasIndex(e => e.IdMonitor)
                    .HasName("fk_monitor-titulo_monitor1_idx");

                entity.HasIndex(e => e.IdTitulo)
                    .HasName("fk_monitor-titulo_titulo1_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IdMonitor).HasColumnType("int(11)");

                entity.Property(e => e.IdTitulo).HasColumnType("int(11)");

                entity.HasOne(d => d.IdMonitorNavigation)
                    .WithMany(p => p.MonitorTitulo)
                    .HasForeignKey(d => d.IdMonitor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_monitor-titulo_monitor1");

                entity.HasOne(d => d.IdTituloNavigation)
                    .WithMany(p => p.MonitorTitulo)
                    .HasForeignKey(d => d.IdTitulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_monitor-titulo_titulo1");
            });

            modelBuilder.Entity<Titulo>(entity =>
            {
                entity.ToTable("titulo");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Token>(entity =>
            {
                entity.ToTable("token");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FechaCrea).HasColumnType("datetime");

                entity.Property(e => e.IdEscuela).HasColumnType("varchar(45)");

                entity.Property(e => e.IdMonitor).HasColumnType("varchar(45)");

                entity.Property(e => e.IdUsuario).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Activado)
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Email).HasColumnType("varchar(65)");

                entity.Property(e => e.IdEscuela).HasColumnType("int(11)");

                entity.Property(e => e.IdInfo).HasColumnType("int(11)");

                entity.Property(e => e.IdPermisos).HasColumnType("int(11)");

                entity.Property(e => e.Password).HasColumnType("varchar(45)");
            });
        }
    }
}
