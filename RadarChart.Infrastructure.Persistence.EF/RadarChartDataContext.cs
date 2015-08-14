using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RadarChart.Core.Model;


namespace RadarChart.Infrastructure.Persistence.EF
{
    public class RadarChartDataContext : DbContext
    {
        public RadarChartDataContext()
            : base("name=simockup")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Role> role { get; set; }

    }
}
