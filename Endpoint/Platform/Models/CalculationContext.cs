﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Platform.Models
{
    public class CalculationContext : DbContext
    {
        public CalculationContext(DbContextOptions<CalculationContext> options) : base(options) { }

        public DbSet<Calculation> Calculations => Set<Calculation>();
 
    }
}
