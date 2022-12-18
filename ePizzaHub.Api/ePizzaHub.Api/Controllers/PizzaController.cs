using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceLayer.Services;
using DataModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ePizzaHub.Api.Controllers
{
    [Route("api/pizzas")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IPizzaIngredientsRepository _pizzaIngredientsRepository;
        private readonly ISaucesRepository _saucesRepository;
        private readonly IToppingsRepository _toppingsRepository;
        private readonly ISizeRepository _sizesRepository;
        private readonly ILogger<PizzaController> _logger;

        public PizzaController(ILogger<PizzaController> logger,IPizzaRepository pizzaRepository, IPizzaIngredientsRepository pizzaIngredientsRepository, ISaucesRepository saucesRepository, IToppingsRepository toppingsRepository, ISizeRepository sizeRepository)
        {
            _pizzaRepository = pizzaRepository;
            _pizzaIngredientsRepository = pizzaIngredientsRepository;
            _saucesRepository = saucesRepository;
            _toppingsRepository = toppingsRepository;
            _sizesRepository = sizeRepository;
            _logger = logger;
        }


        [HttpGet("pizzas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Pizzas>> GetAllPizzas()
        {
            var pizzas =  _pizzaRepository.GetPizzasAsync();

            _logger.LogInformation($"Total {pizzas.Count()} pizzas are returned.");
            return Ok(pizzas);
        }


        [HttpGet("ingredients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PizzaIngredients>> GetPizzaIngredients()
        {
            var ingredients = _pizzaIngredientsRepository.GetPizzasIngredientsAsync();

            _logger.LogInformation($"Total {ingredients.Count()} ingredients are returned.");
            return Ok(ingredients);
        }

        [HttpGet("sauces")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Sauces>> GetPizzaSauces()
        {
            var sauces = _saucesRepository.GetSaucesAsync();

            _logger.LogInformation($"Total {sauces.Count()} sauces are returned.");
            return Ok(sauces);
        }


        [HttpGet("sizes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Size>> GetPizzaSizes()
        {
            var sises = _sizesRepository.GetAllPizzaSizesAsync();

            _logger.LogInformation($"Total {sises.Count()} Pizza Sizes are returned.");
            return Ok(sises);
        }

        [HttpGet("toppings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Toppings>> GetPizzaToppings()
        {
            var toppings = _toppingsRepository.GetToppingsAsync();

            _logger.LogInformation($"Total {toppings.Count()} Toppings are returned.");
            return Ok(toppings);
        }
    }
}
