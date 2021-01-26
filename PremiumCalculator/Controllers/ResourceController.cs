using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IRepository _repositoty;
        public ResourceController(IRepository repositoty)
        {
            _repositoty = repositoty ??
                throw new ArgumentNullException(nameof(repositoty));
        }

        [HttpGet("occupations")]
        public IActionResult GetOccupations()
        {
            try
            {
                var result = _repositoty.GetOccupations();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "InternalServerError - Some generic error");
            }
        }

        [HttpGet("occupations/{id}")]
        public IActionResult GetOccupationById(int id)
        {
            try
            {
                var result = _repositoty.GetOccupationById(id);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "InternalServerError - Some generic error");
            }
        }


        [HttpGet("ratingfactor")]
        public IActionResult GetRatingFactor()
        {
            try
            {
                var result = _repositoty.GetRatingFactor();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "InternalServerError - Some generic error");
            }
        }

        [HttpGet("ratingfactor/{id}")]
        public IActionResult GetRatingFactorById(int id)
        {
            try
            {
                var result = _repositoty.GetRatingFactorById(id);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "InternalServerError - Some generic error");
            }
        }

        [HttpGet("ratings")]
        public IActionResult GetRatings()
        {
            try
            {
                var result = _repositoty.GetRatings();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "InternalServerError - Some generic error");
            }
        }

        [HttpGet("ratings/{id}")]
        public IActionResult GetRatingById(int id)
        {
            try
            {
                var result = _repositoty.GetRatingById(id);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "InternalServerError - Some generic error");
            }
        }
    }
}
