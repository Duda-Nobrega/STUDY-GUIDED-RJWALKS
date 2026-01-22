using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RJWalks.API.CustomActionFilters;
using RJWalks.API.Data;
using RJWalks.API.Models.Domain;
using RJWalks.API.Models.DTOs;
using RJWalks.API.Repositories;

namespace RJWalks.API.Controllers
{

    //https://localhost:123/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly RJWalksDBContext dBContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(RJWalksDBContext dBContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await regionRepository.GetAllAsync();

            return Ok(mapper.Map<List<RegionDto>>(regions));
        }

        //Get Region by ID
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetbyId([FromRoute] Guid id)
        {   //Get Region Domain Modal from database
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        //POST to create new region
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            
                //Map or Convert the DTO to Domain Model

                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

                //Use Domain model to create region using DBContext

                await regionRepository.CreateAsync(regionDomainModel);
                await dBContext.SaveChangesAsync();

                //map domain model back to dto

                var regionDTO = mapper.Map<RegionDto>(regionDomainModel);

                //In post methods it responds with 201 instead of 200
                return CreatedAtAction(nameof(GetbyId), new { id = regionDomainModel.Id }, regionDomainModel);
            
        }

        //Update Region -> PUT: https:localhost/api/regions/{id}
        [HttpPut]
        [ValidateModel]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //Map dto to domain model
            var regionDomailModel = mapper.Map<Region>(updateRegionRequestDto);

            var regionDomainModel = await regionRepository.UpdateAsync(id, regionDomailModel);

            await dBContext.SaveChangesAsync();

            //Convert Domain Model to DTO

            return Ok(mapper.Map<RegionDto>(regionDomainModel));


        }
        //Delete Region
        //DELETE: https://localhost:123/api/regions/{id}

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null) return NotFound();



            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }


    }
}
