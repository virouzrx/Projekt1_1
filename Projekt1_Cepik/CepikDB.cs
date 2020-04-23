using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Projekt1_Cepik
{
    class CepikDB : DbContext
    {
        public CepikDB() : base()
        {
            Database.SetInitializer<CepikDB>(new CreateDatabaseIfNotExists<CepikDB>());
        }
        public DbSet<Cars> Pojazdy { get; set; }
        public DbSet<Drivers> Kierowcy { get; set; }
        public DbSet<DrivingLicense> PrawoJazdy { get; set; }
        public DbSet<InsurancePolicy> Polisa { get; set; }
        public DbSet<TechnicalReview> BadanieTechniczne { get; set; }
        public DbSet<CarDocsAndInfo> Informacje { get; set; }
    }
}