using RadarChart.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarChart.Application.Services
{
    public interface IRoleService
    {
        void Add(Role r);

        List<Role> GetAll();

        Role GetOne(string roleId);

        void Modify(Role r);

        void Delete(Role r);
    }
}
