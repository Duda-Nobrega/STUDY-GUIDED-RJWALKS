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
        {   //Get data from DataBase - Domain Models
            var regionsDomain = dBContext.Regions.ToList();

            //Map Domain Models to Dtos

            var regionsDto = new List<Region>();
            foreach(var regionDomain in regionsDomain) 
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImgURl = regionsDomain.RegionImgURl
                });
            }

            //Return Dtos

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

    }
}
