using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WlZ.Products.Api.Data.Repositories.Interfaces;
using WlZ.Products.Api.Models.DTOs;
using WlZ.Products.Api.Models.Entities;

namespace WlZ.Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            try
            {
                var listEntites = (await _categoryRepository.Get()).ToList();
                IList<CategoryDto> list = _mapper.Map<IList<Category>, IList<CategoryDto>>(listEntites);                              

                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        
        {
            try
            {
                var result = await _categoryRepository.GetById(id);

                if (result == null)
                {
                    return NotFound();
                }

                var dto = _mapper.Map<Category, CategoryDto>(result);
                return dto;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Error retrieving data from the database");
            }
        }
    }
}