using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CodeFirstContext : DbContext
    {
        /*
        public CodeFirstContext()
        {
            
        }
        */
        public virtual DbSet<Patient> Patient { get; set; }

        public virtual DbSet<Prescription> Prescription { get; set; }

        public virtual DbSet<Doctor> Doctor { get; set; }

        public virtual DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }

        public virtual DbSet<Medicament> Medicament { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s7973;Integrated Security=True");
            }
        }
        */
    
        public CodeFirstContext(DbContextOptions<CodeFirstContext> options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient).HasName("Patient_PK");

                entity.Property(e => e.IdPatient).ValueGeneratedNever();
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Birthdate).IsRequired();
            });


            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor).HasName("Doctor_PK");

                entity.Property(e => e.IdDoctor).ValueGeneratedNever();
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament).HasName("Medicament_PK");

                entity.Property(e => e.IdMedicament).ValueGeneratedNever();
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Type).HasMaxLength(100).IsRequired();
            });


            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription).HasName("Prescritpion_PK");

                entity.Property(e => e.IdPrescription).ValueGeneratedNever();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.DueDate).IsRequired();

                entity.HasOne(d => d.Patient)
                      .WithMany(p => p.Prescriptions)
                      .HasForeignKey(d => d.IdPatient)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Prescription_Patient");

                entity.HasOne(d => d.Doctor)
                      .WithMany(p => p.Prescriptions)
                      .HasForeignKey(d => d.IdDoctor)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Prescription_Doctor");
            });

            modelBuilder.Entity<Prescription_Medicament>(entity =>
            {
                entity.HasKey(e => new { e.IdMedicament, e.IdPrescription }).HasName("Prescription_Medicament_PK");

                entity.Property(e => e.IdMedicament).ValueGeneratedNever();
                entity.Property(e => e.IdPrescription).ValueGeneratedNever();
                entity.Property(e => e.Dose).IsRequired();
                entity.Property(e => e.Details).IsRequired();

                entity.HasOne(d => d.Medicament)
                      .WithMany(p => p.Medicaments_Prescriptions)
                      .HasForeignKey(d => d.IdMedicament)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Prescription_Medicament_Medicament");


                entity.HasOne(d => d.Prescription)
                      .WithMany(p => p.Prescriptions_Medicaments)
                      .HasForeignKey(d => d.IdPrescription)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Prescription_Medicament_Prescription");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                var list = new List<Patient>
               {
                   new Patient
                   {
                       IdPatient = 0,
                       FirstName = "Jan",
                       LastName = "Kowalski",
                       Birthdate = new DateTime(2012,9, 3, 0, 0, 0, 0, DateTimeKind.Local)
                   },
                   new Patient
                   {
                       IdPatient = 1,
                       FirstName = "Rafał",
                       LastName = "Smoczyński",
                       Birthdate = new DateTime(2000, 3, 1, 0, 0, 0, 0, DateTimeKind.Local)
                   },
                   new Patient
                   {
                       IdPatient = 2,
                       FirstName = "Piotr",
                       LastName = "Krótki",
                       Birthdate = new DateTime(2002, 8, 21, 0, 0, 0, 0, DateTimeKind.Local)
                   },
                   new Patient
                   {
                       IdPatient = 3,
                       FirstName = "Mateusz",
                       LastName = "Szybki",
                       Birthdate = new DateTime(2004, 6, 13, 0, 0, 0, 0, DateTimeKind.Local)
                   },
                   new Patient
                   {
                       IdPatient = 4,
                       FirstName = "Robert",
                       LastName = "Wolny",
                       Birthdate = new DateTime(1999, 2, 3, 0, 0, 0, 0, DateTimeKind.Local)
                   },
                   new Patient
                   {
                       IdPatient = 5,
                       FirstName = "Gosia",
                       LastName = "Miałczyńska",
                       Birthdate = new DateTime(1997, 6, 23, 0, 0, 0, 0, DateTimeKind.Local)
                   }
               };
                entity.HasData(list);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                var list = new List<Doctor>
                {
                    new Doctor
                    {
                        IdDoctor = 1,
                        FirstName = "Tadeusz",
                        LastName = "Rydzyk",
                        Email = "T.Rydzyk@gmail.com"
                    },
                    new Doctor
                    {
                        IdDoctor = 2,
                        FirstName = "Mariusz",
                        LastName = "Oktaba",
                        Email = "M.Oktaba@gmail.com"
                    },
                    new Doctor
                    {
                        IdDoctor = 3,
                        FirstName = "Grzegorz",
                        LastName = "Łomacz",
                        Email = "G.Lomacz@gmail.com"
                    }
                };
                entity.HasData(list);
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                var list = new List<Medicament>
                {
                    new Medicament
                    {
                        IdMedicament = 10,
                        Name = "Hyrosalic",
                        Description = "Na katar",
                        Type = "Tabletki"
                    },
                    new Medicament
                    {
                        IdMedicament = 20,
                        Name = "Tomysol",
                        Description = "Przeciwbólowy",
                        Type = "Tabletki"
                    },
                    new Medicament
                    {
                        IdMedicament = 30,
                        Name = "Mamarys",
                        Description = "Przeciwzapalny",
                        Type = "Tabletki"
                    },
                    new Medicament
                    {
                        IdMedicament = 40,
                        Name = "Kaselic",
                        Description = "Na kaszel",
                        Type = "Syrop"
                    },
                    new Medicament
                    {
                        IdMedicament = 50,
                        Name = "Parytol",
                        Description = "Antybiotyk",
                        Type = "Tabletki"
                    },
                };
                entity.HasData(list);
            });


            modelBuilder.Entity<Prescription>(entity =>
            {
                var list = new List<Prescription>
                {
                    new Prescription
                    {
                        IdPrescription = 331,
                        Date = DateTime.Today,
                        DueDate = new DateTime(2020, 6, 23, 0, 0, 0, 0, DateTimeKind.Local),
                        IdPatient = 1,
                        IdDoctor = 3
                    },
                    new Prescription
                    {
                        IdPrescription = 332,
                        Date = DateTime.Today,
                        DueDate = new DateTime(2020, 6, 23, 0, 0, 0, 0, DateTimeKind.Local),
                        IdPatient = 2,
                        IdDoctor = 2
                    },
                    new Prescription
                    {
                        IdPrescription = 333,
                        Date = DateTime.Today,
                        DueDate = new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Local),
                        IdPatient = 3,
                        IdDoctor = 2
                    },
                    new Prescription
                    {
                        IdPrescription = 334,
                        Date = DateTime.Today,
                        DueDate = new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Local),
                        IdPatient = 4,
                        IdDoctor = 3
                    },
                    new Prescription
                    {
                        IdPrescription = 335,
                        Date = DateTime.Today,
                        DueDate = new DateTime(2020, 6, 26, 0, 0, 0, 0, DateTimeKind.Local),
                        IdPatient = 5,
                        IdDoctor = 1
                    },
                };
                entity.HasData(list);
            });


            modelBuilder.Entity<Prescription_Medicament>(entity =>
            {
                var list = new List<Prescription_Medicament>
                {
                    new Prescription_Medicament
                    {
                        IdMedicament = 10,
                        IdPrescription = 335,
                        Dose = 15,
                        Details = "Rano i wieczorem"
                    },

                    new Prescription_Medicament
                    {
                        IdMedicament = 20,
                        IdPrescription = 334,
                        Dose = 18,
                        Details = "Tylko wieczorem"
                    },

                    new Prescription_Medicament
                    {
                        IdMedicament = 30,
                        IdPrescription = 333,
                        Dose = 5,
                        Details = "Tylko rano"
                    },

                    new Prescription_Medicament
                    {
                        IdMedicament = 40,
                        IdPrescription = 332,
                        Dose = 100,
                        Details = "Na czczo"
                    },
                    new Prescription_Medicament
                    {
                        IdMedicament = 50,
                        IdPrescription = 331,
                        Dose = 1,
                        Details = "Tylko gdy boli"
                    },

                };
                entity.HasData(list);
            });

        }
    }
}
