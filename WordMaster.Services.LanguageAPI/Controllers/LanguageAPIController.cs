using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WordMaster.Services.LanguageAPI.Data;
using WordMaster.Services.LanguageAPI.Models;
using WordMaster.Services.LanguageAPI.Models.Dto;

namespace WordMaster.Services.LanguageAPI.Controllers
{
    [Route("api/languages")]
    [ApiController]
    public class LanguageAPIController
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;
        private ResponseDto _responseDto;

        public LanguageAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _responseDto = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto AllLanguage()
        {
            try
            {
                IEnumerable<Language> objlist = _db.Languages.ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<Language>>(objlist);
                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto GetLanguage(int id)
        {
            try
            {
                Language obj = _db.Languages.First(u => u.Id == id);
                _responseDto.Result = _mapper.Map<LanguageDto>(obj);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] LanguageDto languageDto)
        {
            try
            {
                Language obj = _mapper.Map<Language>(languageDto);
                _db.Languages.Add(obj);
                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<LanguageDto>(obj);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] LanguageDto languageDto)
        {
            try
            {
                Language obj = _mapper.Map<Language>(languageDto);
                _db.Languages.Update(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Language obj = _db.Languages.First(u => u.Id == id);
                _db.Languages.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
    }
}
