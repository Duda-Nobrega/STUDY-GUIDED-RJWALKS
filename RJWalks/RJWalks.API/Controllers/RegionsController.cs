using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJWalks.API.Data;
using RJWalks.API.Models.Domain;

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
            var regions = dBContext.Regions.ToList();

            return Ok(regions);
        }

        //Get Region by ID
        [HttpGet]
        [Route("{id: Guid}")]
        public IActionResult GetbyId([FromRoute] Guid id)
        {
            var region = dBContext.Regions.Find(id);

            if(region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }

    }
}
