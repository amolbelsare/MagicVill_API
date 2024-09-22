using AutoMapper;
using MagicVill_VillAPI.Models;
using MagicVill_VillAPI.Models.APIResponses;
using MagicVill_VillAPI.Models.Dto;
using MagicVill_VillAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVill_VillAPI.Controllers
{
    [Route("api/v{version:apiVersion}/VillaNumber")]
    [ApiController]
    public class VillaNumberController : ControllerBase
    {
        protected APIResponse _response;
        private IVillaNumbeRepository _dbVillaNumber;
        private IVillaRepository _dbVilla;
        private readonly IMapper _mapper;

        public VillaNumberController(IMapper mapper, IVillaNumbeRepository dbVillaNumber, IVillaRepository dbVilla)
        {         
            _mapper = mapper;
            _dbVillaNumber = dbVillaNumber;
            _dbVilla = dbVilla;
            _response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillaNumbers()
        {
            try
            {
                IEnumerable<VillaNumber> villaNumberslist = await _dbVillaNumber.GetAllAsync(includeProperties: "Villa");
                _response.Result = _mapper.Map<List<VillaNumber>>(villaNumberslist);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var Villanumber = await _dbVillaNumber.GetAsync(u => u.VillaNo == id);
                if (Villanumber == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return BadRequest(_response);
                }
                _response.Result = _mapper.Map<VillaNumber>(Villanumber);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDTO villaNumberCreateDTO)
        {
            try
            {
                if (await _dbVillaNumber.GetAsync(u => u.VillaNo == villaNumberCreateDTO.VillaNo) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa number already Exist!");
                    return BadRequest(ModelState);
                }
                if (await _dbVilla.GetAsync(u=> u.Id == villaNumberCreateDTO.VillaID) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa ID Invalid!");
                    return BadRequest(ModelState);
                }
                if (villaNumberCreateDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                VillaNumber villaNumber = _mapper.Map<VillaNumber>(villaNumberCreateDTO);
                await _dbVillaNumber.CreateAsync(villaNumber);
                _response.Result = _mapper.Map<VillaNumberDTO>(villaNumber);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVillaNumber",new { id = villaNumber.VillaNo }, _response);
            } 
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int? id)
        {
            try
            {
                if(id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var villnumber = await _dbVillaNumber.GetAsync(v => v.VillaNo == id);
                if (id == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }              
                await _dbVillaNumber.RevmoveAsync(villnumber);
                _response.Result = _mapper.Map<VillaNumberDTO>(villnumber);
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id, [FromBody]VillaNumberUpdateDTO villaNumberUpdateDTO)
        {
            try
            {
                if (villaNumberUpdateDTO.VillaNo == null || id != villaNumberUpdateDTO.VillaNo)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                if (await _dbVilla.GetAsync(u =>u.Id == villaNumberUpdateDTO.VillaID) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "VIlla ID is Invalid!");
                    return BadRequest(ModelState);   
                }
                VillaNumber villaNumber = _mapper.Map<VillaNumber>(villaNumberUpdateDTO);
                await _dbVillaNumber.UpdateAsync(villaNumber);
                _response.Result = _mapper.Map<VillaNumberDTO>(villaNumber);
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(villaNumber);
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
    }
}
