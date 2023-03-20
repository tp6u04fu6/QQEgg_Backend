using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualBasic;
using QQEgg_Backend.Models;

namespace QQEgg_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly dbXContext _dbXContext;

        public AdminController(dbXContext dbXContext)
        {
            _dbXContext = dbXContext;
        }

  


        private bool TCouponsExists(int id)
        {
            return (_dbXContext.TCoupons?.Any(e => e.CouponId == id)).GetValueOrDefault();
        }
    }
}
