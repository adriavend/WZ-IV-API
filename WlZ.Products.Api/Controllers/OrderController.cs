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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetOrders()
        {
            try
            {
                var listEntities = (await _orderRepository.Get()).OrderByDescending(o => o.Id).ToList();
                IList<OrderResponseDto> listDto = _mapper.Map<IList<Order>, IList<OrderResponseDto>>(listEntities);

                return Ok(listDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderRequestDto>> CreateOrder(OrderRequestDto orderRequestDto)
        {
            try
            {
                if (orderRequestDto == null)
                {
                    return BadRequest();
                }

                var order = _mapper.Map<OrderRequestDto, Order>(orderRequestDto);
                order.Date = DateTime.Now;

                var listOrderDetails = _mapper.Map<IList<OrderDetailRequestDto>, IList<OrderDetails>>(orderRequestDto.Details).ToList();
                listOrderDetails.ForEach(f => f.Subtotal = f.Quantity * f.Price);
                order.Total = listOrderDetails.Sum(f => f.Subtotal);
                order.OrderDetails = listOrderDetails;

                _orderRepository.Add(order);
                await _orderRepository.SaveChangesAsync();

                return CreatedAtAction(nameof(CreateOrder), new { id = order.Id }, orderRequestDto);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error retrieving data from the database");
            }
        }
    }
}