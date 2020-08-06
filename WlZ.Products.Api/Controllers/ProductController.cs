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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            try
            {
                var listEntites = (await _productRepository
                                    .Get(includeProperties: "IdsubcategoryNavigation,IdsubcategoryNavigation.IdcategoryNavigation"))
                                    .OrderByDescending(o => o.Id)
                                    .ToList();
                IList<ProductDto> list = _mapper.Map<IList<Product>, IList<ProductDto>>(listEntites);                              

                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        
        {
            try
            {
                var result = await _productRepository.GetById(id);

                if (result == null)
                {
                    return NotFound();
                }

                var dto = _mapper.Map<Product, ProductDto>(result);
                return dto;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(ProductDto productDto)
        {
            try
            {
                if (productDto == null)
                {
                    return BadRequest();
                }

                var product = _mapper.Map<ProductDto, Product>(productDto);
                product.CreationDate = DateTime.Now;

                _productRepository.Add(product);
                await _productRepository.SaveChangesAsync();

                return CreatedAtAction(nameof(CreateProduct), new { id = product.Id }, productDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error retrieving data from the database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<ProductDto>> UpdateProduct(ProductDto productDto)
        {
            try
            {
                if (productDto == null)
                {
                    return BadRequest();
                }

                var product = await _productRepository.GetById(productDto.Id);
                //product = _mapper.Map<ProductDto, Product>(productDto);

                product.Description = productDto.Description;
                product.Idsubcategory = productDto.Idsubcategory;
                product.Price = productDto.Price;
                product.Active = productDto.Active;
                product.ModifiedDate = DateTime.Now;

                _productRepository.Update(product);
                await _productRepository.SaveChangesAsync();

                return CreatedAtAction(nameof(UpdateProduct), new { id = product.Id }, productDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error retrieving data from the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                var productToDelete = await _productRepository.GetById(id);

                if (productToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                _productRepository.Remove(productToDelete);
                await _productRepository.SaveChangesAsync();

                return CreatedAtAction(nameof(DeleteProduct), new { ok = true });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Error updating data");
            }  
        }
    }
}