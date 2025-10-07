using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Models;
using MyApp.Models.DTOs;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NZWalkDbContext _context;

        public RegionController(NZWalkDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = _context.Regions.ToList();
            var regionDTO = new List<RegionDTO>();
            foreach (var region in regions)
            {
                regionDTO.Add(new RegionDTO()
                {
                    Id = region.Id,
                    Name = region.Name,
                });
            }
            return Ok(regionDTO);

        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            var region = _context.Regions.FirstOrDefault(x => x.Id == id);
            var regionDTO = new List<RegionDTO>();
            if (region == null)
            {
                return NotFound();
            }
            regionDTO.Add(new RegionDTO()
            {
                Id = region.Id,
                Name = region.Name,
            });
            return Ok(region);

        }
        [HttpPost]
        public IActionResult Create(AddRegionRequestDTO addRegionRequestDTO)
        {
            var regionDomainModel = new Region
            {
                Name = addRegionRequestDTO.Name,
            };

            _context.Regions.Add(regionDomainModel);
            _context.SaveChanges();

            var regionDTO = new RegionDTO()
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDTO.Id }, regionDTO);
        }
        [HttpPut]
        public IActionResult Update(Guid id)
        {
            var regionToUpdate = _context.Regions.FirstOrDefault(x => x.Id == id);
            if (regionToUpdate == null)
            {
                return NotFound();
            }
            
        }
    }
}
