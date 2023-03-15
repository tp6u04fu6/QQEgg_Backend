using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QQEgg_Backend.Models;

namespace QQEgg_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AdminController : ControllerBase
    {
        private readonly dbXContext _dbXContext;

        public AdminController(dbXContext dbXContext)
        {
            _dbXContext = dbXContext;
        }

       //GET: api/TCoupons
       /// <summary>
       /// 顧客打開優惠卷使用列出顧客的優惠卷，如果沒有則顯示空白
       /// </summary>
       /// <returns></returns>
       [HttpGet]
        public async Task<ActionResult<TCoupons>> GetCustomerTCoupons()
        {
            var customerId = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            var customer = await _dbXContext.TCustomers.FindAsync(customerId);

            //判斷顧客的帳號和黑名單
            if (customerId != null && customer.BlackListed == true)
            {
                //如果有且不是黑名單，秀出可以使用的優惠卷

                // 從資料庫中獲取該顧客的優惠卷資料


            }
                //直接顯示登入畫面
                return Unauthorized();
            

        }
        [HttpPost("{couponId}")]
        public async Task<IActionResult> UseCoupon(int couponId)
        {
            // 從數據庫中獲取優惠券
            var coupon = _dbXContext.TCoupons.FirstOrDefault(c => c.CouponId == couponId);

            if (coupon != null && coupon.Quantity > 0)
            {
                // 更新優惠券數量
                coupon.Quantity -= 1;
                await _dbXContext.SaveChangesAsync();

                // 返回使用成功的提示
                return Ok("使用優惠券成功！");
            }
            else
            {
                // 返回使用失敗的提示
                return BadRequest("該優惠券已經用完了！");
            }
        }
       
        private bool TCouponsExists(int id)
        {
            return (_dbXContext.TCoupons?.Any(e => e.CouponId == id)).GetValueOrDefault();
        }
    }
}
