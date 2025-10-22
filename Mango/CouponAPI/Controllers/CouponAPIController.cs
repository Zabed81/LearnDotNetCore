using AutoMapper;
using CouponAPI.Data;
using CouponAPI.Models;
using CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CouponAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/api/coupon")]
    
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto Response;
        private IMapper _mapper;

        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            Response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<coupon> objList = _db.Coupons.ToList();
                Response.Result = _mapper.Map<IEnumerable<coupon>>(objList);
            }
            catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Message = ex.Message;
            }
            return Response;
        }
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                coupon obj = _db.Coupons.First(u => u.CouponId==id);

                Response.Result = _mapper.Map<couponDto>(obj);
            }
            catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Message = ex.Message;
            }
            return Response;

        }

        [HttpGet]
        [Route("GetByCode/{Code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                coupon obj = _db.Coupons.FirstOrDefault(u => u.CouponCode.ToLower()== code.ToLower());
                if (obj == null)
                {
                    Response.IsSuccess = false;
                }
                Response.Result = _mapper.Map<couponDto>(obj);
            }
            catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Message = ex.Message;
            }
            return Response;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromBody] couponDto CouponDto )
        {
            try
            {
                coupon obj = _mapper.Map<coupon>(CouponDto);
                _db.Coupons.Add(obj);
                _db.SaveChanges();
                Response.Result = _mapper.Map<couponDto>(obj);
            }
            catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Message = ex.Message;
            }
            return Response;
        }


        [HttpPut]
        public ResponseDto Put([FromBody] couponDto CouponDto)
        {
            try
            {
                coupon obj = _mapper.Map<coupon>(CouponDto);
                _db.Coupons.Update(obj);
                _db.SaveChanges();
                Response.Result = _mapper.Map<couponDto>(obj);
            }
            catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Message = ex.Message;
            }
            return Response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]

        public ResponseDto Delete(int id)
        {
            try
            {
                coupon obj = _db.Coupons.First(u=>u.CouponId==id) ;
                _db.Coupons.Remove(obj);
                _db.SaveChanges();
               
            }
            catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Message = ex.Message;
            }
            return Response;
        }
    }
}
