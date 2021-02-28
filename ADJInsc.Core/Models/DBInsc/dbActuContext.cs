using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ADJInsc.Core.Models.DBInsc
{
    public partial class dbActuContext : DbContext
    {
        public dbActuContext()
        {
        }

        public dbActuContext(DbContextOptions<dbActuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barrios> Barrios { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Familia1> Familia1 { get; set; }
        public virtual DbSet<Familia2> Familia2 { get; set; }
        public virtual DbSet<InsDomici> InsDomici { get; set; }
        public virtual DbSet<InsFamilia> InsFamilia { get; set; }
        public virtual DbSet<Inscriptos> Inscriptos { get; set; }
        public virtual DbSet<Localidad> Localidad { get; set; }
        public virtual DbSet<Parentesco> Parentesco { get; set; }
        public virtual DbSet<SituacionLaboral> SituacionLaboral { get; set; }
        public virtual DbSet<TipoEmpleo> TipoEmpleo { get; set; }
        public virtual DbSet<TipoFamilia> TipoFamilia { get; set; }
        public virtual DbSet<TipoIngreso> TipoIngreso { get; set; }
        public virtual DbSet<TipoRevista> TipoRevista { get; set; }
        public virtual DbSet<TitularAs> TitularAs { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=199.5.83.228;Database=dbActu;user id=usrActu;password=usr0210#$*;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barrios>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Barbar).HasColumnName("barbar");

                entity.Property(e => e.Bardep).HasColumnName("bardep");

                entity.Property(e => e.Bardes)
                    .HasColumnName("bardes")
                    .HasMaxLength(255);

                entity.Property(e => e.Barloc).HasColumnName("barloc");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.DepartamentoKey)
                    .HasName("PK__Departam__A31840122D895C9B");

                entity.Property(e => e.DepartamentoKey).ValueGeneratedNever();

                entity.Property(e => e.DepartamentoDesc)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Dombar).HasColumnName("DOMBAR");

                entity.Property(e => e.Domcal)
                    .HasColumnName("DOMCAL")
                    .HasMaxLength(255);

                entity.Property(e => e.Domdep)
                    .HasColumnName("DOMDEP")
                    .HasMaxLength(255);

                entity.Property(e => e.Domdto).HasColumnName("DOMDTO");

                entity.Property(e => e.Domloc).HasColumnName("DOMLOC");

                entity.Property(e => e.Domlot)
                    .HasColumnName("DOMLOT")
                    .HasMaxLength(255);

                entity.Property(e => e.Dommza)
                    .HasColumnName("DOMMZA")
                    .HasMaxLength(255);

                entity.Property(e => e.Dompis)
                    .HasColumnName("DOMPIS")
                    .HasMaxLength(255);

                entity.Property(e => e.Dompue).HasColumnName("DOMPUE");

                entity.Property(e => e.Domref)
                    .HasColumnName("DOMREF")
                    .HasMaxLength(255);

                entity.Property(e => e.Flific).HasColumnName("FLIFIC");
            });

            modelBuilder.Entity<Familia1>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Fliapn)
                    .HasColumnName("FLIAPN")
                    .HasMaxLength(255);

                entity.Property(e => e.Flicfi).HasColumnName("FLICFI");

                entity.Property(e => e.Flicom).HasColumnName("FLICOM");

                entity.Property(e => e.Flicui).HasColumnName("FLICUI");

                entity.Property(e => e.Flidep).HasColumnName("FLIDEP");

                entity.Property(e => e.Flidis).HasColumnName("FLIDIS");

                entity.Property(e => e.Flieci).HasColumnName("FLIECI");

                entity.Property(e => e.Flific).HasColumnName("FLIFIC");

                entity.Property(e => e.Flifin).HasColumnName("FLIFIN");

                entity.Property(e => e.Flifna).HasColumnName("FLIFNA");

                entity.Property(e => e.Flilcm).HasColumnName("FLILCM");

                entity.Property(e => e.Fliloc).HasColumnName("FLILOC");

                entity.Property(e => e.Flinac).HasColumnName("FLINAC");

                entity.Property(e => e.Flindo).HasColumnName("FLINDO");

                entity.Property(e => e.Flipai).HasColumnName("FLIPAI");

                entity.Property(e => e.Flipro).HasColumnName("FLIPRO");

                entity.Property(e => e.Flisex).HasColumnName("FLISEX");

                entity.Property(e => e.Flisfi).HasColumnName("FLISFI");

                entity.Property(e => e.Flitdo).HasColumnName("FLITDO");

                entity.Property(e => e.Flitef)
                    .HasColumnName("FLITEF")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Familia2>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Fliapn)
                    .HasColumnName("FLIAPN")
                    .HasMaxLength(255);

                entity.Property(e => e.Flicfi).HasColumnName("FLICFI");

                entity.Property(e => e.Flicom).HasColumnName("FLICOM");

                entity.Property(e => e.Flicui).HasColumnName("FLICUI");

                entity.Property(e => e.Flidep).HasColumnName("FLIDEP");

                entity.Property(e => e.Flidis).HasColumnName("FLIDIS");

                entity.Property(e => e.Flieci).HasColumnName("FLIECI");

                entity.Property(e => e.Flific).HasColumnName("FLIFIC");

                entity.Property(e => e.Flifin).HasColumnName("FLIFIN");

                entity.Property(e => e.Flifna).HasColumnName("FLIFNA");

                entity.Property(e => e.Flilcm).HasColumnName("FLILCM");

                entity.Property(e => e.Fliloc).HasColumnName("FLILOC");

                entity.Property(e => e.Flinac).HasColumnName("FLINAC");

                entity.Property(e => e.Flindo).HasColumnName("FLINDO");

                entity.Property(e => e.Flipai).HasColumnName("FLIPAI");

                entity.Property(e => e.Flipro).HasColumnName("FLIPRO");

                entity.Property(e => e.Flisex).HasColumnName("FLISEX");

                entity.Property(e => e.Flisfi).HasColumnName("FLISFI");

                entity.Property(e => e.Flitdo).HasColumnName("FLITDO");

                entity.Property(e => e.Flitef)
                    .HasColumnName("FLITEF")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<InsDomici>(entity =>
            {
                entity.HasKey(e => e.InsdId);

                entity.Property(e => e.InsdId).HasColumnName("insd_id");

                entity.Property(e => e.InsId).HasColumnName("ins_id");

                entity.Property(e => e.InsdBarrio)
                    .IsRequired()
                    .HasColumnName("insd_barrio")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InsdDepar)
                    .IsRequired()
                    .HasColumnName("insd_depar")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InsdDirecc)
                    .IsRequired()
                    .HasColumnName("insd_direcc")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.InsdEstado)
                    .IsRequired()
                    .HasColumnName("insd_estado")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.InsdFecalt)
                    .HasColumnName("insd_fecalt")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InsdFicha).HasColumnName("insd_ficha");

                entity.Property(e => e.InsdLocal)
                    .IsRequired()
                    .HasColumnName("insd_local")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InsdRefer)
                    .IsRequired()
                    .HasColumnName("insd_refer")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InsFamilia>(entity =>
            {
                entity.HasKey(e => e.InsfId);

                entity.Property(e => e.InsfId).HasColumnName("insf_id");

                entity.Property(e => e.FecNacAnio)
                    .HasColumnName("fecNacAnio")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FecNacDia)
                    .HasColumnName("fecNacDia")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FecNacMes)
                    .HasColumnName("fecNacMes")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InsId).HasColumnName("ins_id");

                entity.Property(e => e.InsfDiscapacitado).HasColumnName("insf_discapacitado");

                entity.Property(e => e.InsfEstado)
                    .IsRequired()
                    .HasColumnName("insf_estado")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.InsfFecalt)
                    .HasColumnName("insf_fecalt")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InsfFicha).HasColumnName("insf_ficha");

                entity.Property(e => e.InsfMinero).HasColumnName("insf_minero");

                entity.Property(e => e.InsfNombre)
                    .HasColumnName("insf_nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsfNumdoc).HasColumnName("insf_numdoc");

                entity.Property(e => e.InsfTipdoc)
                    .HasColumnName("insf_tipdoc")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.InsfTipflia)
                    .HasColumnName("insf_tipflia")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsfVeterano).HasColumnName("insf_veterano");
            });

            modelBuilder.Entity<Inscriptos>(entity =>
            {
                entity.HasKey(e => e.InsId);

                entity.Property(e => e.InsId).HasColumnName("ins_id");

                entity.Property(e => e.CodigoVerificador).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CuitCuil)
                    .HasColumnName("cuit_cuil")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CuitCuilDos)
                    .HasColumnName("cuit_cuil_dos")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CuitCuilUno)
                    .HasColumnName("cuit_cuil_uno")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.InsDiscapacitado).HasColumnName("ins_discapacitado");

                entity.Property(e => e.InsEmail)
                    .HasColumnName("ins_email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InsEstado)
                    .HasColumnName("ins_estado")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InsFecalt)
                    .HasColumnName("ins_fecalt")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InsFecins)
                    .HasColumnName("ins_fecins")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.InsFicha).HasColumnName("ins_ficha");

                entity.Property(e => e.InsMinero).HasColumnName("ins_minero");

                entity.Property(e => e.InsNombre)
                    .HasColumnName("ins_nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsNumdoc)
                    .HasColumnName("ins_numdoc")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsTelef)
                    .HasColumnName("ins_telef")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InsTipdoc)
                    .HasColumnName("ins_tipdoc")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.InsTipflia)
                    .HasColumnName("ins_tipflia")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsVeterano).HasColumnName("ins_veterano");
            });

            modelBuilder.Entity<Localidad>(entity =>
            {
                entity.HasKey(e => new { e.LocalidadKey, e.DepartamentoKey })
                    .HasName("PK__Localida__710E3397E11306A9");

                entity.Property(e => e.LocalidadDesc)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.DepartamentoKeyNavigation)
                    .WithMany(p => p.Localidad)
                    .HasForeignKey(d => d.DepartamentoKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ILOCALIDAD1");
            });

            modelBuilder.Entity<Parentesco>(entity =>
            {
                entity.HasKey(e => e.ParentescoKey)
                    .HasName("PK__Parentes__65BFC8FA51A06095");

                entity.Property(e => e.ParentescoKey).ValueGeneratedNever();

                entity.Property(e => e.ParentescoDesc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SituacionLaboral>(entity =>
            {
                entity.Property(e => e.IngresoNeto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoEmpleo>(entity =>
            {
                entity.HasKey(e => e.TipoEmpleoKey)
                    .HasName("PK__TipoEmpl__B0AA76A0CBDB521B");

                entity.Property(e => e.TipoEmpleoKey).ValueGeneratedNever();

                entity.Property(e => e.TipoEmpleoDesc)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TipoFamilia>(entity =>
            {
                entity.HasKey(e => e.TipoFamiliaKey)
                    .HasName("PK__TipoFami__BDC7E2A4BD7E941C");

                entity.Property(e => e.TipoFamiliaKey).ValueGeneratedNever();

                entity.Property(e => e.TipoFamiliaDesc)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TipoIngreso>(entity =>
            {
                entity.HasKey(e => e.TipoIngresoKey)
                    .HasName("PK__TipoIngr__428196550EF67648");

                entity.Property(e => e.TipoIngresoKey)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TipoIngresoDesc)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TipoRevista>(entity =>
            {
                entity.HasKey(e => e.TipoRevistaKey)
                    .HasName("PK__TipoRevi__5C615BB5772D7F90");

                entity.Property(e => e.TipoRevistaKey).ValueGeneratedNever();

                entity.Property(e => e.TipoRevistaDesc)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TitularAs>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TitularAS");

                entity.Property(e => e.Fliapn)
                    .HasColumnName("FLIAPN")
                    .HasMaxLength(255);

                entity.Property(e => e.Flicfi).HasColumnName("FLICFI");

                entity.Property(e => e.Flicom).HasColumnName("FLICOM");

                entity.Property(e => e.Flicui).HasColumnName("FLICUI");

                entity.Property(e => e.Flidep).HasColumnName("FLIDEP");

                entity.Property(e => e.Flidis).HasColumnName("FLIDIS");

                entity.Property(e => e.Flieci).HasColumnName("FLIECI");

                entity.Property(e => e.Flific).HasColumnName("FLIFIC");

                entity.Property(e => e.Flifin).HasColumnName("FLIFIN");

                entity.Property(e => e.Flifna).HasColumnName("FLIFNA");

                entity.Property(e => e.Flilcm).HasColumnName("FLILCM");

                entity.Property(e => e.Fliloc).HasColumnName("FLILOC");

                entity.Property(e => e.Flinac).HasColumnName("FLINAC");

                entity.Property(e => e.Flindo).HasColumnName("FLINDO");

                entity.Property(e => e.Flipai).HasColumnName("FLIPAI");

                entity.Property(e => e.Flipro).HasColumnName("FLIPRO");

                entity.Property(e => e.Flisex).HasColumnName("FLISEX");

                entity.Property(e => e.Flisfi).HasColumnName("FLISFI");

                entity.Property(e => e.Flitdo).HasColumnName("FLITDO");

                entity.Property(e => e.Flitef)
                    .HasColumnName("FLITEF")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.HasIndex(e => e.Id)
                    .HasName("CIX_Usuario")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.ClaveUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
