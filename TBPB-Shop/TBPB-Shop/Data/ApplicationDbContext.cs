using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TBPB_Shop.ApplicationLogic.Models.Category> Category { get; set; }
        public DbSet<TBPB_Shop.ApplicationLogic.Models.Producer> Producer { get; set; }
    }
}
