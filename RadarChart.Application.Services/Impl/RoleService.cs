using RadarChart.Core.Model;
using RadarChart.Core.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarChart.Application.Services.Impl
{
    public class RoleService : IRoleService
    {
        RoleRepository rr = new RoleRepository();

        public void Add(Role r)
        {
            rr.Add(r);
        }

        public List<Role> GetAll()
        {
            return rr.GetAll();
        }

        public Role GetOne(string roleId)
        {
            return rr.GetOne(arole => arole.RoleId == roleId);
        }

        public void Modify(Role r)
        {
            rr.Modify(r);
        }

        public void Delete(Role r)
        {
            rr.Delete(r);
        }
    }
}
