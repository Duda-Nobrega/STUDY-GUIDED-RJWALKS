using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJWalks.API.Data;
using RJWalks.API.Models.Domain;
using RJWalks.API.Models.DTOs;

namespace RJWalks.API.Controllers
{

    //https://localhost:123/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly RJWalksDBContext dBContext;

        public RegionsController(RJWalksDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            //Get data from DataBase - Domains Models
            var regions = dBContext.Regions.ToList();

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
        public IActionResult GetbyId([FromRoute] Guid id)
        {   //Get Region Domain Modal from database
            var regionDomain = dBContext.Regions.Find(id);

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

        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map or Convert the DTO to Domain Model

            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImgURl = addRegionRequestDto.RegionImgURl
            };

            //Use Domain model to create region using DBContext

            dBContext.Regions.Add(regionDomainModel);

            dBContext.SaveChanges();

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
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //check if the region exists
            var regionDomainModel = dBContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Map dto to domain model

            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.RegionImgURl = updateRegionRequestDto.RegionImgURl;

            dBContext.SaveChanges();

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

    }
}
