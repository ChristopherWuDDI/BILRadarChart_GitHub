using RadarChart.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarChart.Core.Repository.Impl
{
    public class RoleRepository : RadarChartRepositoryBase<Role>
    {
        public RoleRepository()
            : base() { }
        public RoleRepository(UnitOfWork unitOfWork)
            : base(unitOfWork) { }
    }
}
