﻿using Linkedin_Automation.Models;
using Microsoft.EntityFrameworkCore;

namespace Linkedin_Automation.Database
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        { 

        }
        public DbSet<PostDetails> PostDetails { get; set; }
    }
}
