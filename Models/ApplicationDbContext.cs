using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetMVCEFCode.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetMVCEFCode.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {          
        }
        public DbSet<Product> Products { get; set; }
    }
}