﻿using HW_01_Eurich_Kapitonova.Infra;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Soft_01_Eurich_Kapitonova.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
            initializeTables(b);
        }
        private static void initializeTables(ModelBuilder b)
        {
            LibraryDb.InitializeTables(b);
        }
    }
}
