using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace PostgreTest.Api.Models
{
    public class MyWebApiContext : DbContext
    {
        public virtual DbSet<GraphData> GraphData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseNpgsql("Host=localhost;Database=tutorial;Username=postgres;Password=1");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("timescaledb");

            modelBuilder.Entity<Chunk>(entity =>
            {
                entity.ToTable("chunk", "_timescaledb_catalog");

                entity.HasIndex(e => e.HypertableId)
                    .HasName("chunk_hypertable_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('_timescaledb_catalog.chunk_id_seq'::regclass)");

                entity.Property(e => e.HypertableId).HasColumnName("hypertable_id");

                entity.HasOne(d => d.Hypertable)
                    .WithMany(p => p.Chunk)
                    .HasForeignKey(d => d.HypertableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("chunk_hypertable_id_fkey");
            });

            modelBuilder.Entity<Dimension>(entity =>
            {
                entity.ToTable("dimension", "_timescaledb_catalog");

                entity.HasIndex(e => e.HypertableId)
                    .HasName("dimension_hypertable_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('_timescaledb_catalog.dimension_id_seq'::regclass)");

                entity.Property(e => e.Aligned).HasColumnName("aligned");

                entity.Property(e => e.ColumnType)
                    .HasColumnName("column_type")
                    .HasColumnType("regtype");

                entity.Property(e => e.HypertableId).HasColumnName("hypertable_id");

                entity.Property(e => e.IntervalLength).HasColumnName("interval_length");

                entity.Property(e => e.NumSlices).HasColumnName("num_slices");

                entity.HasOne(d => d.Hypertable)
                    .WithMany(p => p.Dimension)
                    .HasForeignKey(d => d.HypertableId)
                    .HasConstraintName("dimension_hypertable_id_fkey");
            });

            modelBuilder.Entity<DimensionSlice>(entity =>
            {
                entity.ToTable("dimension_slice", "_timescaledb_catalog");

                entity.HasIndex(e => new { e.DimensionId, e.RangeStart, e.RangeEnd })
                    .HasName("dimension_slice_dimension_id_range_start_range_end_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('_timescaledb_catalog.dimension_slice_id_seq'::regclass)");

                entity.Property(e => e.DimensionId).HasColumnName("dimension_id");

                entity.Property(e => e.RangeEnd).HasColumnName("range_end");

                entity.Property(e => e.RangeStart).HasColumnName("range_start");

                entity.HasOne(d => d.Dimension)
                    .WithMany(p => p.DimensionSlice)
                    .HasForeignKey(d => d.DimensionId)
                    .HasConstraintName("dimension_slice_dimension_id_fkey");
            });

            modelBuilder.Entity<Hypertable>(entity =>
            {
                entity.ToTable("hypertable", "_timescaledb_catalog");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('_timescaledb_catalog.hypertable_id_seq'::regclass)");

                entity.Property(e => e.NumDimensions).HasColumnName("num_dimensions");
            });

            modelBuilder.Entity<Tablespace>(entity =>
            {
                entity.ToTable("tablespace", "_timescaledb_catalog");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('_timescaledb_catalog.tablespace_id_seq'::regclass)");

                entity.Property(e => e.HypertableId).HasColumnName("hypertable_id");

                entity.HasOne(d => d.Hypertable)
                    .WithMany(p => p.Tablespace)
                    .HasForeignKey(d => d.HypertableId)
                    .HasConstraintName("tablespace_hypertable_id_fkey");
            });




            //modelBuilder.Entity<GraphTest>(entity =>
            //{
            //    entity.ToTable("test");

            //    entity.Property(e => e.Id)
            //       .HasColumnName("id");

            //    entity.Property(e => e.Name)
            //       .HasColumnName("name");
            //});


            modelBuilder.Entity<GraphData>(entity =>
            {
                entity.ToTable("graphdata");

                entity.Property(e => e.Id)
                   .HasColumnName("id");

                entity.Property(e => e.Open)
                   .HasColumnName("open");

                entity.Property(e => e.High)
                  .HasColumnName("high");

                entity.Property(e => e.Low)
                  .HasColumnName("low");

                entity.Property(e => e.Close)
                  .HasColumnName("close");

                entity.Property(e => e.Volume)
                  .HasColumnName("volume");

                entity.Property(e => e.CreatedDate)
                  .HasColumnName("createddate");

                

                

            });

            modelBuilder.HasSequence("chunk_constraint_name");

            modelBuilder.HasSequence<int>("chunk_id_seq");

            modelBuilder.HasSequence<int>("dimension_id_seq");

            modelBuilder.HasSequence<int>("dimension_slice_id_seq");

            modelBuilder.HasSequence<int>("hypertable_id_seq");

            modelBuilder.HasSequence<int>("tablespace_id_seq");
        }
    }




}
