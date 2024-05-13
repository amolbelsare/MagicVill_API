using AutoMapper;
using MagicVill_VillAPI.Data;
using MagicVill_VillAPI.Logging;
using MagicVill_VillAPI.Models;
using MagicVill_VillAPI.Models.Dto;
using MagicVill_VillAPI.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVill_VillAPI.Controllers
{
    //[Route("api/[controller]]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillAPIController : ControllerBase
    {
        
        private readonly ILogging _logger;
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;
        public VillAPIController(ILogging logger, IVillaRepository dbVilla, IMapper mapper)
        {
            _logger = logger;
            _dbVilla = dbVilla;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()
        {
            
             _logger.Log("Getting all Villsa", "");        
            IEnumerable<Villa> villaList = await _dbVilla.GetAllAsync();
            return Ok(_mapper.Map<List<VillaDTO>>(villaList));
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDTO>> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.Log("Get Villa Error with Id" + id, "error");
                return BadRequest();
            }
            var Villa = await _dbVilla.GetAsync(u => u.Id == id);
            if (Villa == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<VillaDTO>(Villa));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDTO>> CreateVilla([FromBody] VillaCreateDTO villaCreateDTO)
        {          
            if (await _dbVilla.GetAsync(u => u.Name.ToLower() == villaCreateDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CusomError", "Villa already Exist!");
                return BadRequest(ModelState);
            }

            if (villaCreateDTO == null)
            {
                return BadRequest();
            }        
            Villa model = _mapper.Map<Villa>(villaCreateDTO);
            await _dbVilla.CreateAsync(model);       
            return CreatedAtRoute("GetVilla", new { id = model.Id }, model);
        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var vill = await _dbVilla.GetAsync(v => v.Id == id);
            if (vill == null)
            {
                return NotFound();
            }           
            await _dbVilla.RevmoveAsync(vill);          
            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDTO villaUpdateDTO)
        {
            if (villaUpdateDTO.Id == null || id != villaUpdateDTO.Id)
            {
                return BadRequest();
            }       
            Villa model = _mapper.Map<Villa>(villaUpdateDTO);   // By Using AutoMapper class object convert to another class 
            await _dbVilla.UpdateAsync(model);
            return NoContent();
        }


        [HttpPatch("{id:int}, Name=UpdatePartialVilla")]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if(patchDTO == null || id == 0)
            {
                return BadRequest();
            }       

            var villa = await _dbVilla.GetAsync(u => u.Id == id, traked:false);

            VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa); // By Using AutoMapper class object convert to another class

            //VillaUpdateDTO villaDTO = new()
            //{
            //    Amenity = villa.Amenity,
            //    Details = villa.Details,
            //    Id = villa.Id,
            //    ImageUrl = villa.ImageUrl,
            //    Name = villa.Name,
            //    Occupancy = villa.Occupancy,
            //    Rate = villa.Rate,
            //    Sqft = villa.Sqft,
            //};

            if (villa == null)
            {
                return BadRequest();
            }
          
            patchDTO.ApplyTo(villaDTO, ModelState);

            Villa model = _mapper.Map<Villa>(villaDTO);  // By Using AutoMapper class object convert to another class
            //Villa model = new()
            //{
            //    Amenity = villaDTO.Amenity,
            //    Details = villaDTO.Details,
            //    Id = villaDTO.Id,
            //    ImageUrl = villaDTO.ImageUrl,
            //    Name = villaDTO.Name,
            //    Occupancy = villaDTO.Occupancy,
            //    Rate = villaDTO.Rate,
            //    Sqft = villaDTO.Sqft,
            //};
            
            await _dbVilla.UpdateAsync(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
