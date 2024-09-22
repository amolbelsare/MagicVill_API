using Asp.Versioning;
using AutoMapper;
using MagicVill_VillAPI.Logging;
using MagicVill_VillAPI.Models;
using MagicVill_VillAPI.Models.APIResponses;
using MagicVill_VillAPI.Models.Dto;
using MagicVill_VillAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVill_VillAPI.Controllers.V2
{
    //[Route("api/[controller]]")]
    [Route("api/v{version:apiVersion}/VillaAPI")]
    [ApiController]
    [ApiVersion("2.0")]

    public class VillAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ILogging _logger;
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;
        public VillAPIController(ILogging logger, IVillaRepository dbVilla, IMapper mapper)
        {
            _logger = logger;
            _dbVilla = dbVilla;
            _mapper = mapper;
            _response = new();
        }

        //when working on api version upgrading from 1 to 2
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Version1", "Version2" };
        }
    }
}
