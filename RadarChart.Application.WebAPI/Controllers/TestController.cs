using RadarChart.Application.Services;
using RadarChart.Application.Services.Impl;
using RadarChart.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RadarChart.Application.WebAPI.Controllers
{
    public class TestController : ApiController
    {
        private IRoleService roleService = new RoleService();


        public IEnumerable<Role> GetAll()
        {
            //List<Role> roles = new List<Role>();
            //Role r = new Role();
            //r.RoleId = "D20D23AB-0A4A-41D1-8C3E-1B34010BF746";
            //r.RoleName = "testing";
            //r.Enabled = true;
            //r.CreatedDate = DateTime.Now;
            //r.CreatedBy = "CW";

            //roles.Add(r);

            //return roles;
            return roleService.GetAll();
        }
    }
}
