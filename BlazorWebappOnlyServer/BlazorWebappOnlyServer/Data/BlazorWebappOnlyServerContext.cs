using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorWebappOnlyServer.Models;

namespace BlazorWebappOnlyServer.Data
{
    public class BlazorWebappOnlyServerContext : DbContext
    {
        public BlazorWebappOnlyServerContext (DbContextOptions<BlazorWebappOnlyServerContext> options)
            : base(options)
        {
        }

        public DbSet<BlazorWebappOnlyServer.Models.Employee> Employee { get; set; } = default!;
    }
}
