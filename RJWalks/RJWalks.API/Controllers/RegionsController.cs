using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public RegionsController(RJWalksDBContext dBContext, IRegionRepository regionRepository)
        {
            this.dBContext = dBContext;
            this.regionRepository = regionRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get data from DataBase - Domains Models
            var regions = await regionRepository.GetAllAsync();
            //Map domain model to dto
            var regionsDto = new List<RegionDto>();

            foreach (var region in regions) 
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImgURl = region.RegionImgURl,
                });
            }

            // Return DTOS back to the client

            return Ok(regionsDto);
        }

        //Get Region by ID
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetbyId([FromRoute] Guid id)
        {   //Get Region Domain Modal from database
            var regionDomain = await regionRepository.GetByIdAsync(id) ;

            if(regionDomain == null)
            {
                return NotFound();
            }
            //map the region domain model to region dto

            var RegionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImgURl = regionDomain.RegionImgURl
            };

            //Return DTO back to client

            return Ok(RegionDto);
        }

        //POST to create new region
        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map or Convert the DTO to Domain Model

            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImgURl = addRegionRequestDto.RegionImgURl
            };

            //Use Domain model to create region using DBContext

            await regionRepository.CreateAsync(regionDomainModel) ;
            await dBContext.SaveChangesAsync();

            //map domain model back to dto

            var regionDTO = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImgURl = regionDomainModel.RegionImgURl
            };

            //In post methods it responds with 201 instead of 200
            return CreatedAtAction(nameof(GetbyId), new { id = regionDomainModel.Id }, regionDomainModel);
        }

        //Update Region -> PUT: https:localhost/api/regions/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task <IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

            //Map dto to domain model

            var regionDomailModel = new Region
            {
                Code = updateRegionRequestDto.Code,
                Name = updateRegionRequestDto.Name,
                RegionImgURl = updateRegionRequestDto.RegionImgURl
            };

            var regionDomainModel = await regionRepository.UpdateAsync(id, regionDomailModel);

            await dBContext.SaveChangesAsync();

            //Convert Domain Model to DTO

            var regionDTO = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImgURl = regionDomainModel.RegionImgURl
            };

            return Ok();
        }
        //Delete Region
        //DELETE: https://localhost:123/api/regions/{id}

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null) return NotFound();

            var RegionDTO = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImgURl = regionDomainModel.RegionImgURl
            };

            return Ok(RegionDTO);
        }


    }
}
