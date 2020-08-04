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
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public SubCategoryController(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetSubCategories()
        {
            try
            {
                var listEntites = (await _subCategoryRepository.Get()).ToList();
                IList<SubCategoryDto> list = _mapper.Map<IList<Subcategory>, IList<SubCategoryDto>>(listEntites);                              

                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SubCategoryDto>> GetCategory(int id)
        
        {
            try
            {
                var result = await _subCategoryRepository.GetById(id);

                if (result == null)
                {
                    return NotFound();
                }

                var dto = _mapper.Map<Subcategory, SubCategoryDto>(result);
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