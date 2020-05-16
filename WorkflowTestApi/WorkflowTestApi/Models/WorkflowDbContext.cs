using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowTestApi.Models
{
    public class WorkflowDbContext : DbContext
    {
        public WorkflowDbContext (DbContextOptions<WorkflowDbContext> options) : base(options)
        {
             
        }

        public DbSet<CategorieClient> CategorieClients { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
