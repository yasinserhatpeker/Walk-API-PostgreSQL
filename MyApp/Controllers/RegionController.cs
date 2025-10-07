using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetAll()
        {
            var regions = await _context.Regions.ToListAsync();
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
        public async Task<IActionResult> GetById(Guid id)
        {
            var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
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
        public async Task<IActionResult> Create(AddRegionRequestDTO addRegionRequestDTO)
        {
            var regionDomainModel = new Region
            {
                Name = addRegionRequestDTO.Name,
            };

            _context.Regions.Add(regionDomainModel);
           await _context.SaveChangesAsync();

            var regionDTO = new RegionDTO()
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDTO.Id }, regionDTO);
        }
        [HttpPut]
        [Route("{id}")]
        public  async Task<IActionResult> Update(Guid id, UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            // Checks if the region exist
            var regionDomainModel = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // Map DTO to DomainModel

            regionDomainModel.Name = updateRegionRequestDTO.Name;


           await _context.SaveChangesAsync();

            // Convert DomainModel to DTO
            var regionDTO = new RegionDTO
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
            };

            return Ok(regionDTO);



        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var regionDomainModel = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            _context.Regions.Remove(regionDomainModel);
           await _context.SaveChangesAsync();

            var regionDTO = new RegionDTO
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
            };
    
           
            return Ok(regionDTO);
            
        }
    }
}
