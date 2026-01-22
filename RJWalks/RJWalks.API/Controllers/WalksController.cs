using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJWalks.API.CustomActionFilters;
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
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {

            //Map Dto to Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDTO);

            await walkRepository.CreateAsync(walkDomainModel);

            //map DomainModel to dto
            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }

        //Get Walks
        //GET: /api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await walkRepository.GetAllAsync();

            //Map domain para dto
            return Ok(mapper.Map<List<WalkDTO>>(walksDomainModel));
        }

        //Get walk by ID
        //GET: /api/Walks/{id} [
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetbyId([FromRoute] Guid id)
        {
            var WalkDomainModel = await walkRepository.GetbyIdAsync(id);

            if (WalkDomainModel == null)
            {
                return NotFound();
            }

            //Map domain to dto
            return Ok(mapper.Map<WalkDTO>(WalkDomainModel));

        }

        //Update Walk by id
        //PUT: /api/Walks/{id}
        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDTO updateWalkRequest)
        {

            //Map DTO to domain
            var WalkDomainModel = mapper.Map<Walk>(updateWalkRequest);

            WalkDomainModel = await walkRepository.UpdateAsync(id, WalkDomainModel);

            if (WalkDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain Model to DTO
            return Ok(mapper.Map<UpdateWalkRequestDTO>(WalkDomainModel));


        }

        //DELETE walk by id
        //DELETE: /api/Walks/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalkDomainModel = await walkRepository.DeleteAsync(id);

            if (deletedWalkDomainModel == null) return NotFound();

            //Map Domain Model to dto
            return Ok(mapper.Map<WalkDTO?>(deletedWalkDomainModel));
        }
    }
}
