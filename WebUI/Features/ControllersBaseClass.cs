using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Features
{
    public class ControllersBaseClass: ControllerBase
    {
        protected readonly ApplicationDbContext context;
        public ControllersBaseClass(ApplicationDbContext _context)
        {
            context = _context;
        }
    }
}
