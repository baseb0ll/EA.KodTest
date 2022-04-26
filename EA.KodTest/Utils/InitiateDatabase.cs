using EA.KodTest.Application.Package;
using EA.KodTest.Infrastructure;
using System;

namespace EA.KodTest.Extensions
{
    //adds some rows to Sqlite database that's being used for data storage
    public static class InitiateDatabase
    {
        public static void Initiate(PackageContext packageContext)
        {
            Console.WriteLine($"Database path: {packageContext.DbPath}.");
            Console.WriteLine("Inserting packages..");
            packageContext.Add(new PackageModel { PackageNumber = "123453245678765679", Height = 15.0, Length = 21.0, Width = 18.0, Weight = 30.0 });
            packageContext.Add(new PackageModel { PackageNumber = "123453245678231679", Height = 25.0, Length = 28.0, Width = 12.0, Weight = 7.0 });
            packageContext.Add(new PackageModel { PackageNumber = "123419076678765679", Height = 10.0, Length = 10.0, Width = 22.0, Weight = 2.0 });
            packageContext.Add(new PackageModel { PackageNumber = "123451238678765679", Height = 22.0, Length = 65.0, Width = 30.0, Weight = 3.0 });
            packageContext.Add(new PackageModel { PackageNumber = "123453245678765409", Height = 13.0, Length = 20.0, Width = 40.0, Weight = 5.0 });
            packageContext.Add(new PackageModel { PackageNumber = "123453245678765123", Height = 37.0, Length = 25.0, Width = 25.0, Weight = 8.0 });
            packageContext.SaveChanges();
        }
    }
}
