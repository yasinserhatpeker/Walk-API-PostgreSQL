using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;
using MyApp.Models.DTOs;
using MyApp.Repositories;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NZWalkDbContext _context;
        private readonly IRegionRepository _regionRepository;

        public RegionController(NZWalkDbContext context, IRegionRepository regionRepository)
        {
            _context = context;
            _regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await _regionRepository.GetAllAsync();
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
            var region = await _regionRepository.GetByIdAsync(id);
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

         regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);
          

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
            var regionDomainModel = new Region
            {
                Name = updateRegionRequestDTO.Name
            };

            regionDomainModel = await _regionRepository.UpdateAsync(regionDomainModel,id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }

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
            var regionDomainModel = await _regionRepository.DeleteAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
         var regionDTO = new RegionDTO
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
            };
    
           
            return Ok(regionDTO);
            
        }
    }
}
