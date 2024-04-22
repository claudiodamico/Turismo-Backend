using AMV_Travel_Application.Services;
using AMV_Travel_Domain.Dtos;
using AMV_Travel_Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMV_Travel_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourService _tourService;
        private readonly IMapper _mapper;

        public TourController(ITourService tourService,
            IMapper mapper)
        {
            _tourService = tourService;
            _mapper = mapper;
        }

        /// <summary>
        /// Filtrar Tours 
        /// </summary>
        [HttpGet]       
        [ProducesResponseType(typeof(Tour), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> MostrarTours()
        {
            try
            {
                return new JsonResult(_tourService.MostrarTours()) { StatusCode = 200 };
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Crear Tour
        /// </summary>
        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(typeof(TourDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AgregarTour([FromBody] TourDto tour)
        {
            try
            {
                var tourEntity = _tourService.AgregarTour(tour);
                if (tourEntity != null)
                {
                    var tourCreado = _mapper.Map<TourDto>(tourEntity);
                    return new JsonResult(tourCreado) { StatusCode = 201 };
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
