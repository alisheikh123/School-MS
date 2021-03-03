using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using School_MS.Models;

namespace School_MS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<School_MS.Models.tblSubject> tblSubject { get; set; }
        public DbSet<School_MS.Models.tblChapter> tblChapter { get; set; }
        public DbSet<School_MS.Models.tblQuestion> tblQuestion { get; set; }
    }
}
