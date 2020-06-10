using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CarService.Models;

namespace CarService.DataAccess
{

    // контекст для взаимодействия с базой данных
    public class CarServiceDbContext : DbContext {

        public CarServiceDbContext() : base("dbContext") { }
        public CarServiceDbContext(string connectionString) : base(connectionString) { }

        // наборы сущностей, хранящихся в базе данных
        public DbSet<Brand> Brands { get; set; }           // марки авто
        public DbSet<Car> Cars { get; set; }               // модели авто
        public DbSet<Person> People { get; set; }          // паспортные данные людей
        public DbSet<Client> Clients { get; set; }         // клиенты
        public DbSet<Specialty> Specialties  { get; set; } // специальности
        public DbSet<Worker> Workers  { get; set; }        // работники
        public DbSet<Service> Services  { get; set; }      // услуги
        public DbSet<SparePart> spareParts  { get; set; }  // запчасти
        public DbSet<ServiceSheet> ServiceSheets  { get; set; } // сервисные листы
        public DbSet<ActOfExecutedWorks> ActsOfExecutedWorks  { get; set; } // акты выполненных работ


        // настройка базы данных при помощи Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            #region Таблица брендов автомобилей
            modelBuilder.Entity<Brand>()
                .Property(br => br.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50)
                .HasColumnName("Mark");
            modelBuilder.Entity<Brand>()
                .HasMany(br => br.Cars)
                .WithRequired(br => br.Brand);
            #endregion

            #region Таблица автомобилей
            modelBuilder.Entity<Car>()
                .Property(c => c.Model)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            modelBuilder.Entity<Car>()
               .Property(c => c.Color)
               .IsRequired()
               .IsUnicode()
               .HasMaxLength(50);
            modelBuilder.Entity<Car>()
               .Property(c => c.Year)
               .IsRequired();
            modelBuilder.Entity<Car>()
               .Property(c => c.RegNumber)
               .IsRequired()
               .IsUnicode()
               .HasMaxLength(6);
            modelBuilder.Entity<Car>()
                .HasMany(c => c.Acts)
                .WithRequired(c => c.Car);
            #endregion

            #region Таблица людей
            modelBuilder.Entity<Person>()
                .Property(p => p.Surname)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            modelBuilder.Entity<Person>()
                .Property(p => p.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            modelBuilder.Entity<Person>()
                .Property(p => p.Patronymic)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            modelBuilder.Entity<Person>()
                .Property(p => p.Passport)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(8);
            modelBuilder.Entity<Person>()
                .Property(p => p.DateOfBirth)
                .IsRequired();
            modelBuilder.Entity<Person>()
                .Property(p => p.Registration)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Cars)
                .WithRequired(p => p.Owner);
            #endregion

            #region Таблица клиентов
            modelBuilder.Entity<Client>()
                .Property(c => c.PhoneNumber)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(14);
            modelBuilder.Entity<Client>()
                .HasRequired(c => c.Person)
                .WithOptional(c => c.Client);
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Acts)
                .WithRequired(c => c.Client);
            #endregion

            #region Таблица специальностей
            modelBuilder.Entity<Specialty>()
                .Property(sp => sp.Profession)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            modelBuilder.Entity<Specialty>()
                .HasMany(sp => sp.Workers)
                .WithRequired(sp => sp.Specialty);
            #endregion

            #region Таблица работников
            modelBuilder.Entity<Worker>()
                .Property(w => w.Busy)
                .IsRequired();
            modelBuilder.Entity<Worker>()
                .Property(w => w.Discharge)
                .IsRequired();
            modelBuilder.Entity<Worker>()
                .Property(w => w.WorkExperience)
                .IsRequired();
            modelBuilder.Entity<Worker>()
                .Property(w => w.Salaried)
                .IsRequired();
            modelBuilder.Entity<Worker>()
                .HasRequired(w => w.Person)
                .WithOptional(w => w.Worker);
            #endregion

            #region Таблица услуг
            modelBuilder.Entity<Service>()
                .Property(s => s.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(40);
            modelBuilder.Entity<Service>()
               .Property(s => s.Cost)
               .IsRequired();
            modelBuilder.Entity<Service>()
                .HasMany(s => s.ServiceSheets)
                .WithRequired(s => s.Service);
            #endregion

            #region Таблица запчастей
            modelBuilder.Entity<SparePart>()
                .Property(sp => sp.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(40);
            modelBuilder.Entity<SparePart>()
                .Property(sp => sp.Cost)
                .IsRequired();
            modelBuilder.Entity<SparePart>()
                .HasMany(sp => sp.ServiceSheets)
                .WithMany(sp => sp.SpareParts);
            #endregion

            #region Таблица сервисных листов
            modelBuilder.Entity<ServiceSheet>()
                .Property(ss => ss.EliminationTime)
                .IsRequired();
            modelBuilder.Entity<ServiceSheet>()
                .Property(ss => ss.Performed)
                .IsRequired();
            #endregion

            #region Таблица актов выполненных работ
            modelBuilder.Entity<ActOfExecutedWorks>()
                .Property(act => act.RepairAcceptanceDate)
                .IsRequired();
            modelBuilder.Entity<ActOfExecutedWorks>()
                .Property(act => act.RepairCompletionDate)
                .IsRequired();
            modelBuilder.Entity<ActOfExecutedWorks>()
                .Property(act => act.RepairCost)
                .IsRequired();
            modelBuilder.Entity<ActOfExecutedWorks>()
                .Property(act => act.CostOfSpareParts)
                .IsRequired();
            modelBuilder.Entity<ActOfExecutedWorks>()
                .HasMany(act => act.ServiceSheets)
                .WithRequired(act => act.Act);
            #endregion


            base.OnModelCreating(modelBuilder);
        }

    }//CarServiceDbContext
}
