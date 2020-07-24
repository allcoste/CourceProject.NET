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

        // вызов инициализатора бд
        static CarServiceDbContext() { Database.SetInitializer(new CarServiceDbInitializer()); }

        public CarServiceDbContext() : base("DBConnection") { }
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
                .HasMaxLength(50);
            modelBuilder.Entity<Brand>()
                .HasMany(br => br.Cars)
                .WithRequired(c => c.Brand);
            #endregion

            #region Таблица автомобилей
            modelBuilder.Entity<Car>()
                .Property(c => c.Model)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Car>()
               .Property(c => c.Color)
               .IsRequired()
               .HasMaxLength(50);
            modelBuilder.Entity<Car>()
               .Property(c => c.Year)
               .IsRequired();
            modelBuilder.Entity<Car>()
               .Property(c => c.RegNumber)
               .IsRequired()
               .HasMaxLength(6);
            modelBuilder.Entity<Car>()
                .HasMany(c => c.Acts)
                .WithRequired(act => act.Car);
            #endregion

            #region Таблица людей
            modelBuilder.Entity<Person>()
                .Property(p => p.Surname)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Person>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Person>()
                .Property(p => p.Patronymic)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Person>()
                .Property(p => p.Passport)
                .IsRequired()
                .HasMaxLength(8);
            modelBuilder.Entity<Person>()
                .Property(p => p.DateOfBirth)
                .IsRequired();
            modelBuilder.Entity<Person>()
                .Property(p => p.Registration)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Cars)
                .WithRequired(c => c.Owner);
            #endregion

            #region Таблица клиентов
            modelBuilder.Entity<Client>()
                .Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(13);
            modelBuilder.Entity<Client>()
                .HasRequired(c => c.Person)
                .WithOptional(p => p.Client);
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Acts)
                .WithRequired(act => act.Client);
            #endregion

            #region Таблица специальностей
            modelBuilder.Entity<Specialty>()
                .Property(sp => sp.Profession)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Specialty>()
                .HasMany(sp => sp.Workers)
                .WithRequired(w => w.Specialty);
            modelBuilder.Entity<Specialty>()
                .HasMany(sp => sp.Services)
                .WithRequired(srv => srv.Specialty)
                .WillCascadeOnDelete(false);
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
                .WithOptional(p => p.Worker);
            modelBuilder.Entity<Worker>()
                .HasMany(w => w.ServiceSheets)
                .WithRequired(ss => ss.Worker);
            #endregion

            #region Таблица услуг
            modelBuilder.Entity<Service>()
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(40);
            modelBuilder.Entity<Service>()
                .Property(s => s.Cost)
                .IsRequired();
            #endregion

            #region Таблица запчастей
            modelBuilder.Entity<SparePart>()
                .Property(sp => sp.Name)
                .IsRequired()
                .HasMaxLength(40);
            modelBuilder.Entity<SparePart>()
                .Property(sp => sp.Cost)
                .IsRequired();
            #endregion

            #region Таблица сервисных листов
            modelBuilder.Entity<ServiceSheet>()
                .Property(ss => ss.EliminationTime)
                .IsRequired();
            modelBuilder.Entity<ServiceSheet>()
                .Property(ss => ss.Performed)
                .IsRequired();
            modelBuilder.Entity<ServiceSheet>()
                .HasMany(ss => ss.SpareParts)
                .WithMany(ss => ss.ServiceSheets);
            modelBuilder.Entity<ServiceSheet>()
                .HasRequired(ss => ss.Service)
                .WithMany(srv => srv.ServiceSheets);
            #endregion

            #region Таблица актов выполненных работ
            modelBuilder.Entity<ActOfExecutedWorks>()
                .Property(act => act.RepairAcceptanceDate)
                .IsRequired();
            modelBuilder.Entity<ActOfExecutedWorks>()
                .Property(act => act.RepairCompletionDate)
                .IsRequired();
            modelBuilder.Entity<ActOfExecutedWorks>()
                .Ignore(act => act.RepairCost);
            modelBuilder.Entity<ActOfExecutedWorks>()
                .Ignore(act => act.CostOfSpareParts);
            modelBuilder.Entity<ActOfExecutedWorks>()
                .HasMany(act => act.ServiceSheets)
                .WithRequired(act => act.Act);
            #endregion

            #region Настройка уникальных столбцов
            modelBuilder.Entity<Brand>()
                .HasIndex(br => br.Name).IsUnique();
            modelBuilder.Entity<Car>()
                .HasIndex(c => c.RegNumber).IsUnique();
            modelBuilder.Entity<Person>()
                .HasIndex(p => p.Passport).IsUnique();
            modelBuilder.Entity<Specialty>()
                .HasIndex(sp => sp.Profession).IsUnique();
            modelBuilder.Entity<Service>()
                .HasIndex(s => s.Name).IsUnique();
            modelBuilder.Entity<SparePart>()
                .HasIndex(s => s.Name).IsUnique();
            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }//CarServiceDbContext
}
