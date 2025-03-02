using Booking.ApiService;
using Booking.ApiService.Services.Interfaces;
using Booking.Domain.Entity;
using Booking.Infrastructure.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Booking.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {

        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly BaseApiResponse _response;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _response = new BaseApiResponse();
        }

        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategoryAsync(int page = 1, int pageSize = 10, string sortBy = "date_desc")
        {
            try
            {
                var result = await _categoryService.GetAllCategoryAsync(page, pageSize, sortBy);
                var jsonConvert = JsonConvert.SerializeObject(result, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented
                });
                return Ok(jsonConvert);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAllCategoryAsync");
                return NotFound();
            }
        }
        [HttpGet("GetCategoryByName")]
        public async Task<IActionResult> GetCategoryByNameAsync(string cateUrl)
        {
            try
            {
                var result = await _categoryService.GetCategoryAsync(cateUrl);
                var jsonConvert = JsonConvert.SerializeObject(result, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented
                });
                return Ok(jsonConvert);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAllCategoryAsync");
                return NotFound();
            }
        }
        [HttpPost("InsertCategory")]
        public async Task<IActionResult> InsertCategoryAsync(CategoryDTO category)
        {
            try
            {
                await _categoryService.AddCategoryAsync(category);
                _response.Message = "Insert success";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Insert Error");
                _response.Message = ex.Message;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return BadRequest(_response);
            }
        }
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategoryAsync(CategoryDTO category, string cateUrl)
        {
            try
            {
                await _categoryService.UpdateCategoryAsync(category, cateUrl);
                _response.Message = "Update success";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Update Error");
                _response.Message = ex.Message;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return BadRequest(_response);
            }
        }
        [HttpPut("DeleteCategory")]
        public async Task<IActionResult> DeleteCategoryAsync(string cateUrl, string deletedBy)
        {
            try
            {
                await _categoryService.DeleteCategory(cateUrl, deletedBy);
                _response.Message = "Delete success";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Delete Error");
                _response.Message = ex.Message;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return BadRequest(_response);
            }
        }
    }
}
