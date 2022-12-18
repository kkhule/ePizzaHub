using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLayer.Services;
using DataModel.Models;

namespace ePizzaHub.Api.Controllers
{
    [Route("api/nonpizzas")]
    [ApiController]
    public class NonPizzaItemController : ControllerBase
    {
        private readonly INonPizzaRepository _nonPizzaRepository;
        private readonly ILogger<NonPizzaItemController> _logger;

        public NonPizzaItemController(ILogger<NonPizzaItemController> logger,INonPizzaRepository nonPizzaRepository)
        {
            _nonPizzaRepository = nonPizzaRepository;
            _logger = logger;
        }


        [HttpGet("nonpizzas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<NonPizzas>> GetAllNonPizzaItems()
        {
            var nonPizzaItems = _nonPizzaRepository.GetNonPizzaItemsAsync();

            _logger.LogInformation($"Total {nonPizzaItems.Count()} nonPizzaItems are returned.");
            return Ok(nonPizzaItems);
        }


        [HttpGet("nonpizzaid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<NonPizzas> GetNonPizzaItem(int nonPizzaItemId)
        {
            var nonPizzaItem = _nonPizzaRepository.GetNonPizzaItemAsync(nonPizzaItemId);

            if (nonPizzaItem == null)
            {
                _logger.LogInformation($"nonPizzaId with id {nonPizzaItemId} wasn't found when accessing nonPizzaItem.");
                return NotFound();
            }


            return Ok(nonPizzaItem);
        }
    }
}
