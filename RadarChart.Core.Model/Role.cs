using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarChart.Core.Model
{
    public class Role
    {
        public string RoleId { get; set; }

        public string RoleName { get; set; }

        public bool Enabled { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }
    }
}
