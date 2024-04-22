using AMV_Travel_Application.Services;
using AMV_Travel_Domain.Dtos;
using AMV_Travel_Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AMV_Travel_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _reservasService;
        private readonly IMapper _mapper;

        public ReservaController(IReservaService reservaService, IMapper mapper)
        {
            _reservasService = reservaService;
            _mapper = mapper;
        }

        /// <summary>
        /// Mostrar Reservas 
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReservaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> MostrarInformacion()
        {
            try
            {
                var reservas = await _reservasService.MostrarInformacion();
                var reservaDtos = _mapper.Map<IEnumerable<ReservaDto>>(reservas);
                return Ok(reservaDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Crear Reserva 
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ReservaDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ReservarTour([FromBody] Reserva reserva)
        {
            try
            {
                var reservaEntity = await _reservasService.CrearReserva(reserva);
                if (reservaEntity != null)
                {
                    var tourCreado = _mapper.Map<ReservaDto>(reservaEntity);
                    return new JsonResult(tourCreado) { StatusCode = 201 };
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Eliminar Reserva por ID
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EliminarReserva(int id)
        {
            try
            {
                var success = await _reservasService.EliminarReserva(id);
                if (!success)
                {
                    return NotFound($"No se encontró una reserva con ID {id} para eliminar.");
                }
                return NoContent();  
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

    }
}
