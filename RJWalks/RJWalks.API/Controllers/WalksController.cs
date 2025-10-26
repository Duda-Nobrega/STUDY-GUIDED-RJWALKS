using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJWalks.API.Models.Domain;
using RJWalks.API.Models.DTOs;
using RJWalks.API.Repositories;

namespace RJWalks.API.Controllers
{
    // api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        public IWalkRepository WalkRepository { get; }


        //Createwalk
        //POST: /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            //Map Dto to Domain Model
           var walkDomainModel =  mapper.Map<Walk>(addWalkRequestDTO);

            await walkRepository.CreateAsync(walkDomainModel);

            //map DomainModel to dto
            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }
    }
}
