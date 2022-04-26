using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA.KodTest.Application.Package;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EA.KodTest.Infrastructure
{
    public class PackageContext : DbContext
    {
        public DbSet<PackageModel> Packages { get; set; }

        public string DbPath { get; }

        public PackageContext(DbContextOptions<PackageContext> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "EAKodtest.db");
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
            
    }
}
