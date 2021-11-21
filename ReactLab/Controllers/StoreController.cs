using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core.Commands;
using Core.Queries;

namespace ReactLab.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class StoreController : ControllerBase {
        private readonly IMediator _mediator;
        private readonly ILogger<StoreController> _logger;

        public StoreController (ILogger<StoreController> logger, IMediator mediator) {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById ([FromRoute] GetStoreIdQuery query) {
            var result = await _mediator.Send (query);

            if (result is null) return NotFound ();

            return Ok (result);
        }

        [HttpGet]

        public async Task<IActionResult> GetAll ([FromQuery] GetAllStoreQuery query) {
            var result = await _mediator.Send (query);

            return Ok (result);
        }
    }
}