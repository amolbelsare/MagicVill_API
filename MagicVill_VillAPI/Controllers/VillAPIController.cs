using AutoMapper;
using MagicVill_VillAPI.Data;
using MagicVill_VillAPI.Logging;
using MagicVill_VillAPI.Models;
using MagicVill_VillAPI.Models.Dto;
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
        //private readonly ILogger<VillAPIController> _logger;

        //public VillAPIController(ILogger<VillAPIController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly ILogging _logger;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public VillAPIController(ILogging logger, ApplicationDbContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()
        {
            
             _logger.Log("Getting all Villsa", "");
            //return Ok(await _db.Villas.ToListAsync());

            IEnumerable<Villa> villaList = await _db.Villas.ToListAsync();
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
                //_logger.LogError("Get Villa Error with Id" + id);
                _logger.Log("Get Villa Error with Id" + id, "error");
                return BadRequest();
            }
            var Villa = await _db.Villas.FirstOrDefaultAsync(u => u.Id == id);
            if (Villa == null)
            {
                return NotFound();
            }
            //return Ok(Villa);
            return Ok(_mapper.Map<VillaDTO>(Villa));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDTO>> CreateVilla([FromBody] VillaCreateDTO villaCreateDTO)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (await _db.Villas.FirstOrDefaultAsync(u => u.Name.ToLower() == villaCreateDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CusomError", "Villa already Exist!");
                return BadRequest(ModelState);
            }

            if (villaCreateDTO == null)
            {
                return BadRequest();
            }
            //if (villaDTO.Id > 0)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError);
            //}

            Villa model = _mapper.Map<Villa>(villaCreateDTO);

            //Villa model = new()
            //{
            //    Amenity = villaCreateDTO.Amenity,
            //    Details = villaCreateDTO.Details,
            //    ImageUrl = villaCreateDTO.ImageUrl,
            //    Name = villaCreateDTO.Name,
            //    Occupancy = villaCreateDTO.Occupancy,
            //    Rate = villaCreateDTO.Rate,
            //    Sqft = villaCreateDTO.Sqft,
            //};

            await _db.Villas.AddAsync(model);
            await _db.SaveChangesAsync();

            //villaDTO.Id = VillaStore.VillaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            //VillaStore.VillaList.Add(villaDTO);

            //return Ok(villaDTO);

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
            var vill = await _db.Villas.FirstOrDefaultAsync(v => v.Id == id);
            if (vill == null)
            {
                return NotFound();
            }

            _db.Villas.Remove(vill);
            await _db.SaveChangesAsync();
            //return Ok(vill);
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
            _db.Villas.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();
        }


        [HttpPatch("{id:int}, Name=UpdatePartialVilla")]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if(patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            //var villa = VillaStore.VillaList.FirstOrDefault(u=>u.Id == id);

            var villa = await _db.Villas.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

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
            _db.Update(model);
            await _db.SaveChangesAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
