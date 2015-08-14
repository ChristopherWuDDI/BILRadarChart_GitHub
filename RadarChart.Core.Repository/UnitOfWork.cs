using RadarChart.Infrastructure.Persistence.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarChart.Core.Repository
{
    public class UnitOfWork
    {
        private RadarChartDataContext db;
        public UnitOfWork()
        {
            this.db = new RadarChartDataContext();
        }

        public RadarChartDataContext GetDBContext()
        {
            if (db == null)
            {
                db = new RadarChartDataContext();
            }
            return db;
        }

        public void Commit()
        {
            db.SaveChanges();
        }
    }
}
