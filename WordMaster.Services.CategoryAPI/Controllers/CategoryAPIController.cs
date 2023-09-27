using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WordMaster.Services.CategoryAPI.Data;
using WordMaster.Services.CategoryAPI.Models;
using WordMaster.Services.CategoryAPI.Models.Dto;

namespace WordMaster.Services.CategoryAPI.Controllers
{
    [ApiController]
    [Route("api/categories")]
    [Authorize]
    public class CategoryAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;
        private ResponseDto _response;
        //private string userid;

        public CategoryAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
            //userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        [HttpGet]
        public ResponseDto AllCategory()
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            try
            {
                IEnumerable<Category> objlist = _db.Categories.Where(u => u.UserId == userid).ToList();
                _response.Result = _mapper.Map<IEnumerable<Category>>(objlist);
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto GetCategory(int id)
        {
            try
            {
                Category obj = _db.Categories.First(u => u.Id == id);
                _response.Result = _mapper.Map<CategoryDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("language_id/{language_id:int}")]
        public ResponseDto Language(int language_id)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            try
            {
                IEnumerable<Category> list_category = _db.Categories
                    .Where(u => u.UserId == userid && u.LanguageId == language_id).ToList();
                _response.Result = list_category;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }

        [HttpPost]
        public ResponseDto Post([FromBody] CategoryDto languageDto)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            try
            {
                Category obj = _mapper.Map<Category>(languageDto);

                obj.UserId = userid;

                _db.Categories.Add(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CategoryDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] CategoryDto languageDto)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            try
            {
                Category obj = _mapper.Map<Category>(languageDto);

                obj.UserId = userid;

                _db.Categories.Update(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Category obj = _db.Categories.First(u => u.Id == id);
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
