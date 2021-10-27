using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using Direct4Me_Test.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Direct4Me_Test.Services;
using Direct4Me_Test.Entities;
using Direct4Me_Test.Models.DeliveryServiceModel;
using Direct4Me_Test.Models.DeliveryServices;

namespace Direct4Me_Test.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DeliveryServicesController : ControllerBase
    {
        private IDelivery_Service _deliveryService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public DeliveryServicesController(
            IDelivery_Service deliveryService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _deliveryService = deliveryService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var deliverys = _deliveryService.GetAll();
            var model = _mapper.Map<IList<DeliveryServiceModel>>(deliverys);
            return Ok(model);
        }

        [AllowAnonymous]
        [HttpGet("count")]
        public IActionResult GetDeliveryCount()
        {
            var deliverys = _deliveryService.GetDeliveryCount();
            var model = _mapper.Map<IList<DeliveryServiceCountModel>>(deliverys);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var DeliveryService = _deliveryService.GetById(id);
            var model = _mapper.Map<DeliveryServiceModel>(DeliveryService);
            return Ok(model);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult Create([FromBody] SaveDeliveryServiceModel model)
        {
            // map model to entity
            var delivery = _mapper.Map<DeliveryService>(model);

            try
            {
                // create user
                _deliveryService.Create(delivery);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateDeliveryServiceModel model)
        {
            // map model to entity and set id
            var delivery = _mapper.Map<DeliveryService>(model);
            delivery.Id = id;

            try
            {
                // update DeliveryService 
                _deliveryService.Update(delivery);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _deliveryService.Delete(id);
            return Ok();
        }
    }
}
